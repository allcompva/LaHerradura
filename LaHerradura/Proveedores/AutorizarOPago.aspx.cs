using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Proveedores
{
    public partial class AutorizarOPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                if (!IsPostBack)
                {
                    fillGrillas();
                    DDLMes.SelectedValue = fec.Month.ToString();
                    DDLAnio.SelectedValue = fec.Year.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fillGrillas()
        {
            try
            {
                //PARA AUTORIZAR
                List<DAL.ORDENES_PAGO> lstParaAutorizar =
                    DAL.ORDENES_PAGO.readParaAprobar();
                gvParaAutorizar.DataSource = lstParaAutorizar;
                gvParaAutorizar.DataBind();
                if (lstParaAutorizar.Count > 0)
                {
                    gvParaAutorizar.UseAccessibleHeader = true;
                    gvParaAutorizar.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                //AUTORIZADAS
                List<DAL.ORDENES_PAGO> lstAutorizadas =
                    DAL.ORDENES_PAGO.getByEstado(1);
                gvAutorizadas.DataSource = lstAutorizadas;
                gvAutorizadas.DataBind();
                if (lstAutorizadas.Count > 0)
                {
                    gvAutorizadas.UseAccessibleHeader = true;
                    gvAutorizadas.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                //CON PAGO A CUENTA
                List<DAL.ORDENES_PAGO> lstPagoACta =
                    DAL.ORDENES_PAGO.getByEstado(3);
                gvACta.DataSource = lstPagoACta;
                gvACta.DataBind();
                if (lstPagoACta.Count > 0)
                {
                    gvACta.UseAccessibleHeader = true;
                    gvACta.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                //ANULADAS
                //List<DAL.ORDENES_PAGO> lstAnuladas =
                //    DAL.ORDENES_PAGO.getByEstado(4);
                //gvAnuladas.DataSource = lstAnuladas;
                //gvAnuladas.DataBind();
                //if (lstAnuladas.Count > 0)
                //{
                //    gvAnuladas.UseAccessibleHeader = true;
                //    gvAnuladas.HeaderRow.TableSection = TableRowSection.TableHeader;
                //}

                //PAGADAS
                List<DAL.VISTA_PAGO_PROVEEDORES> lstPagadas =
                    DAL.VISTA_PAGO_PROVEEDORES.read();
                gvPagados.DataSource = lstPagadas;
                gvPagados.DataBind();
                if (lstPagadas.Count > 0)
                {
                    gvPagados.UseAccessibleHeader = true;
                    gvPagados.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvParaAutorizar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl divAnchorRecibo = (HtmlGenericControl)
                        e.Row.FindControl("divDetalle");
                    DAL.USUARIOS obj =
    DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                    divAnchorRecibo.InnerHtml =
                        BLL.ORDENES_PAGO.detalle(
                        (DAL.ORDENES_PAGO)e.Row.DataItem, 0, obj.ROL);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvAutorizadas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl divAnchorRecibo = (HtmlGenericControl)
                        e.Row.FindControl("divDetalle");
                    DAL.USUARIOS obj =
    DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                    divAnchorRecibo.InnerHtml =
                        BLL.ORDENES_PAGO.detalle(
                        (DAL.ORDENES_PAGO)e.Row.DataItem, 1, obj.ROL);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvPagados_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl divAnchorRecibo = (HtmlGenericControl)
                        e.Row.FindControl("divDetalle");
                    DAL.USUARIOS obj =
    DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                    divAnchorRecibo.InnerHtml =
                        BLL.ORDENES_PAGO.detalle(
                        (DAL.ORDENES_PAGO)e.Row.DataItem, 2, obj.ROL);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvACta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl divAnchorRecibo = (HtmlGenericControl)
                        e.Row.FindControl("divDetalle");
                    DAL.USUARIOS obj =
    DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                    divAnchorRecibo.InnerHtml =
                        BLL.ORDENES_PAGO.detalle(
                        (DAL.ORDENES_PAGO)e.Row.DataItem, 3, obj.ROL);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvAnuladas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl divAnchorRecibo = (HtmlGenericControl)
                        e.Row.FindControl("divDetalle");
                    DAL.USUARIOS obj =
    DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                    divAnchorRecibo.InnerHtml =
                        BLL.ORDENES_PAGO.detalle(
                        (DAL.ORDENES_PAGO)e.Row.DataItem, 4, obj.ROL);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAutorizar_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.ORDENES_PAGO obj = DAL.ORDENES_PAGO.getByPk(
                    int.Parse(hIdOp.Value));
                obj.FECHA_AUTORIZA = LaHerradura.Utils.Utils.getFechaActual();
                obj.USUARIO_AUTORIZA =
                    Convert.ToInt32(Request.Cookies["UserLh"]["Id"]);
                DAL.ORDENES_PAGO.autorizarOrden(obj);
                fillGrillas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.ORDENES_PAGO obj = DAL.ORDENES_PAGO.getByPk(
    int.Parse(hIdOp.Value));
                obj.FECHA_ANULA = LaHerradura.Utils.Utils.getFechaActual();
                obj.USUARIO_ANULA =
                    Convert.ToInt32(Request.Cookies["UserLh"]["Id"]);
                DAL.ORDENES_PAGO.anulaOrden(obj);
                fillGrillas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnPagadas_Click(object sender, EventArgs e)
        {
            try
            {
                //PAGADAS
                List<DAL.ORDENES_PAGO> lstPagadas =
                    DAL.ORDENES_PAGO.getByEstado(2);
                gvPagados.DataSource = lstPagadas;
                gvPagados.DataBind();
                if (lstPagadas.Count > 0)
                {
                    gvPagados.UseAccessibleHeader = true;
                    gvPagados.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLFiltroFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDLFiltroFecha.SelectedIndex == 0)
                {
                    divAnio.Visible = false;
                    divMes.Visible = false;
                    List<DAL.VISTA_PAGO_PROVEEDORES> lstPagadas =
                        DAL.VISTA_PAGO_PROVEEDORES.read();
                    gvPagados.DataSource = lstPagadas;
                    gvPagados.DataBind();
                    if (lstPagadas.Count > 0)
                    {
                        gvPagados.UseAccessibleHeader = true;
                        gvPagados.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                else
                {
                    divAnio.Visible = true;
                    divMes.Visible = true;
                    List<DAL.VISTA_PAGO_PROVEEDORES> lstPagadas =
                        DAL.VISTA_PAGO_PROVEEDORES.read(int.Parse(DDLAnio.SelectedItem.Value),
                        int.Parse(DDLMes.SelectedItem.Value));
                    gvPagados.DataSource = lstPagadas;
                    gvPagados.DataBind();
                    if (lstPagadas.Count > 0)
                    {
                        gvPagados.UseAccessibleHeader = true;
                        gvPagados.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                divAnio.Visible = true;
                divMes.Visible = true;
                List<DAL.VISTA_PAGO_PROVEEDORES> lstPagadas =
                    DAL.VISTA_PAGO_PROVEEDORES.read(int.Parse(DDLAnio.SelectedItem.Value),
                    int.Parse(DDLMes.SelectedItem.Value));
                gvPagados.DataSource = lstPagadas;
                gvPagados.DataBind();
                if (lstPagadas.Count > 0)
                {
                    gvPagados.UseAccessibleHeader = true;
                    gvPagados.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

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
                divAnio.Visible = true;
                divMes.Visible = true;
                List<DAL.VISTA_PAGO_PROVEEDORES> lstPagadas =
                    DAL.VISTA_PAGO_PROVEEDORES.read(int.Parse(DDLAnio.SelectedItem.Value),
                    int.Parse(DDLMes.SelectedItem.Value));
                gvPagados.DataSource = lstPagadas;
                gvPagados.DataBind();
                if (lstPagadas.Count > 0)
                {
                    gvPagados.UseAccessibleHeader = true;
                    gvPagados.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}