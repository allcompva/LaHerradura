using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class InfPagos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                    DDLAnio.SelectedValue = fec.Year.ToString();
                    DDLMes.SelectedValue = fec.Month.ToString();
                    DDLMes.SelectedValue = fec.Month.ToString();
                    fillGrillas(int.Parse(DDLAnio.SelectedItem.Value),
                        int.Parse(DDLMes.SelectedItem.Value));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void fillGrillas(int anio, int mes)
        {
            List<DAL.INFORME_DEUDA> lst = DAL.INFORME_DEUDA.read(anio, mes);

            gvCtas.DataSource = lst;
            gvCtas.DataBind();
            if (lst.Count > 0)
            {
                gvCtas.UseAccessibleHeader = true;
                gvCtas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            List<DAL.INFORME_DEUDA> lstPagos = DAL.INFORME_DEUDA.readMediosPago(anio, mes);
            gvPeriodos.DataSource = lstPagos;
            gvPeriodos.DataBind();
            if (lstPagos.Count > 0)
            {
                gvPeriodos.UseAccessibleHeader = true;
                gvPeriodos.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            List<DAL.INFORME_DEUDA> lstPagos2 = DAL.INFORME_DEUDA.readPeriodos(anio, mes);
            gvPeriodos2.DataSource = lstPagos2;
            gvPeriodos2.DataBind();
            if (lstPagos.Count > 0)
            {
                gvPeriodos2.UseAccessibleHeader = true;
                gvPeriodos2.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            lblDeuda.InnerHtml = string.Format("{0:c}",
                lst.Sum(d => d.TOTAL));
            lblCantCta.InnerHtml = lst.Count.ToString();
            lblDeudaPeriodo.InnerHtml = string.Format("{0:c}",
                lstPagos.Sum(d => d.TOTAL));
            lblCantCtaPeriodo.InnerHtml = lstPagos.Count.ToString();
            lblTotPeriodo.InnerHtml = string.Format("{0:c}",
                lst.Sum(d => d.TOTAL));
            lblCantPeriodo.InnerHtml = lst.Count.ToString();

            //DETALLE DE TRANSACCIONES POR RECIBO
            List<DAL.INFORME_TRANSACCIONES> lstTran = 
                DAL.INFORME_TRANSACCIONES.read(
                anio, mes);
            lblTotTransaccion.InnerHtml = string.Format("{0:c}",
                lstTran.Sum(d => d.MONTO));
            lblCantTransaccion.InnerHtml = lstTran.Count.ToString();
            gvTransaccion.DataSource = lstTran;
            gvTransaccion.DataBind();
            if (lstTran.Count > 0)
            {
                gvTransaccion.UseAccessibleHeader = true;
                gvTransaccion.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            List<DAL.INFORME_TRANSACCIONES> lstResumen =
                DAL.INFORME_TRANSACCIONES.readResumen(anio, mes);
            lblTotResumen.InnerHtml = string.Format("{0:c}",
                lstResumen.Sum(d => d.MONTO));
            lblCantResumen.InnerHtml = lstResumen.Count.ToString();
            gvResumen.DataSource = lstResumen;
            gvResumen.DataBind();
            if (lstResumen.Count > 0)
            {
                gvResumen.UseAccessibleHeader = true;
                gvResumen.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            List<DAL.INFORME_PAGO_DETALLE> lstDetalle =
    DAL.INFORME_PAGO_DETALLE.read(anio, mes);
            lblTotDetalleGeneral.InnerHtml = string.Format("{0:c}",
                lstResumen.Sum(d => d.MONTO));
            
            gvTotDetalleGral.DataSource = lstDetalle;
            gvTotDetalleGral.DataBind();
            if (lstDetalle.Count > 0)
            {
                gvTotDetalleGral.UseAccessibleHeader = true;
                gvTotDetalleGral.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void gvCtas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.INFORME_DEUDA obj = new DAL.INFORME_DEUDA();
                    obj = (DAL.INFORME_DEUDA)e.Row.DataItem;

                    HtmlGenericControl ulResponsables =
                        (HtmlGenericControl)e.Row.FindControl("ulResponsables");

                    if (obj == null)
                        return;

                    List<DAL.PERSONAS_GRILLA> lst = new List<DAL.PERSONAS_GRILLA>();
                    lst = DAL.PERSONAS_GRILLA.getByNroCta(obj.NRO_CTA);

                    foreach (var item in lst)
                    {
                        HtmlGenericControl li = new HtmlGenericControl();
                        li.TagName = "li";
                        HtmlGenericControl p = new HtmlGenericControl();
                        p.TagName = "p";
                        p.Style.Add("padding", "0");
                        if (item.RELACION == "Propietario")
                        {
                            p.InnerHtml = string.Format(
                                "{0}<small class=\"pull-right\">{1}</small>",
                                item.NOMBRE,
                                item.RELACION);

                            li.Controls.Add(p);
                        }
                        else
                        {
                            p.InnerHtml = string.Format(
                                "{0} <small class=\"pull-right\">{1}</small>",
                                item.NOMBRE, item.RELACION);
                            li.Controls.Add(p);
                        }
                        if (ulResponsables != null)
                            ulResponsables.Controls.Add(li);
                    }
                    HtmlGenericControl divMedioPago =
    (HtmlGenericControl)e.Row.FindControl("divMedioPago");

                    List<DAL.PAGOS_X_FACTURA> lstPagos =
                        DAL.PAGOS_X_FACTURA.read(obj.NRO_RECIBO_PAGO);
                    HtmlGenericControl ulPago = new HtmlGenericControl();
                    ulPago.TagName = "ul";
                    ulPago.Attributes.Add("class", "nav nav-stacked");
                    foreach (var item in lstPagos)
                    {
                        HtmlGenericControl li = new HtmlGenericControl();
                        li.TagName = "li";
                        li.InnerHtml = string.Format(
                            "{0}",item.MEDIO_PAGO);
                        ulPago.Controls.Add(li);
                    }
                    divMedioPago.Controls.Add(ulPago);

                    HtmlGenericControl divRecibo =
                        (HtmlGenericControl)e.Row.FindControl("divRecibo");
                    HtmlAnchor a = new HtmlAnchor();
                    //CAMBIO CRYSTALREPORTS
                    //a.HRef = string.Format(
                    //        "Reportes/Print.aspx?op=recibo&nroRecibo={0}&fecha={1}",
                    //         obj.NRO_RECIBO_PAGO, obj.FECHA);

                    a.HRef = string.Format(
        "Reportes/Recibo.aspx?nroRecibo={0}",
         obj.NRO_RECIBO_PAGO);

                    a.Target = "_BLANK";
                    HtmlGenericControl span = new HtmlGenericControl();
                    span.TagName = "span";
                    span.Attributes.Add("class", "fa fa-search");
                    a.Controls.Add(span);
                    divRecibo.Controls.Add(a);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvPeriodos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void DDLAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillGrillas(int.Parse(DDLAnio.SelectedItem.Value),
    int.Parse(DDLMes.SelectedItem.Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillGrillas(int.Parse(DDLAnio.SelectedItem.Value),
    int.Parse(DDLMes.SelectedItem.Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvTransaccion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.INFORME_TRANSACCIONES obj = (DAL.INFORME_TRANSACCIONES)
                        e.Row.DataItem;
                    HtmlGenericControl divRecibo =
                        (HtmlGenericControl)e.Row.FindControl("divRecibo");
                    HtmlAnchor a = new HtmlAnchor();
                    //CAMBIO CRYSTALREPORTS
                    //a.HRef = string.Format(
                    //        "Reportes/Print.aspx?op=recibo&nroRecibo={0}&fecha={1}",
                    //         obj.NRO_RECIBO_PAGO, obj.FECHA);

                    a.HRef = string.Format(
        "Reportes/Recibo.aspx?nroRecibo={0}",
         obj.NRO_RECIBO_PAGO, obj.FECHA);

                    a.Target = "_BLANK";
                    HtmlGenericControl span = new HtmlGenericControl();
                    span.TagName = "span";
                    span.Attributes.Add("class", "fa fa-search");
                    a.Controls.Add(span);
                    divRecibo.Controls.Add(a);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvResumen_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}