﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Proveedores
{
    public partial class CtasCtesGastos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    if (Request.QueryString["ID"] == null)
                        Response.Redirect("CtaCteGastos1.aspx");
                    fillGastosaPagar(
                        Convert.ToInt32(Request.QueryString["ID"]), 0);
                    List<DAL.USUARIOS> lst = DAL.USUARIOS.read();
                    DDLUsuario.DataTextField = "USUARIO";
                    DDLUsuario.DataValueField = "ID";
                    DDLUsuario.DataSource = lst.FindAll(u => u.ROL == 1);
                    DDLUsuario.DataBind();
                    txtFecha.Text = LaHerradura.Utils.Utils.getFechaActual().ToShortDateString();
                    fillOrdenes();

                    List<DAL.VISTA_ANTICIPO_PROVEEDOR> lstAnticipos =
                        DAL.VISTA_ANTICIPO_PROVEEDOR.read(
                            Convert.ToInt32(Request.QueryString["ID"]));

                    gvAdelantos.DataSource = lstAnticipos;
                    gvAdelantos.DataBind();

                    if (lstAnticipos.Count > 0)
                    {
                        gvAdelantos.UseAccessibleHeader = true;
                        gvAdelantos.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void fillOrdenes()
        {
            //try
            //{
            //    List<DAL.ORDENES_PAGO> lst = DAL.ORDENES_PAGO.getAPagar(
            //        int.Parse(Request.QueryString["ID"]));

            //    gvAutorizadas.DataSource = lst;
            //    gvAutorizadas.DataBind();
            //    if (lst.Count > 0)
            //    {
            //        gvAutorizadas.UseAccessibleHeader = true;
            //        gvAutorizadas.HeaderRow.TableSection = 
            //            TableRowSection.TableHeader;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        private void fillGastosaPagar(int id, int opcion)
        {
            try
            {
                List<DAL.CTACTE_GASTOS> lst;
                DAL.PROVEEDORES obj = DAL.PROVEEDORES.getByPk(id);
                lblProv.InnerHtml = string.Format("Razón Social: {0} - Nombre Fantasia: {1}",
                    obj.RAZON_SOCIAL, obj.NOMBRE_FANTASIA);
                switch (opcion)
                {
                    case 0:
                        lst = DAL.CTACTE_GASTOS.readDeuda(id);
                        gvProveedores.DataSource = lst;
                        gvProveedores.DataBind();
                        if (lst.Count > 0)
                        {
                            gvProveedores.UseAccessibleHeader = true;
                            gvProveedores.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                        gvCtaTotal.DataSource = null;
                        gvCtaTotal.DataBind();
                        gvMovCta.DataSource = null;
                        gvMovCta.DataBind();
                        break;
                    case 1:
                        lst = DAL.CTACTE_GASTOS.read(id);
                        gvProveedores.DataSource = null;
                        gvProveedores.DataBind();
                        gvMovCta.DataSource = null;
                        gvMovCta.DataBind();
                        gvCtaTotal.DataSource = lst;
                        gvCtaTotal.DataBind();
                        if (lst.Count > 0)
                        {
                            gvCtaTotal.UseAccessibleHeader = true;
                            gvCtaTotal.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                        break;
                    case 2:
                        List< DAL.MOV_CTA_GASTOS> lst2 = DAL.MOV_CTA_GASTOS.read(id);
                        gvProveedores.DataSource = null;
                        gvProveedores.DataBind();
                        gvCtaTotal.DataSource = null;
                        gvCtaTotal.DataBind();
                        gvMovCta.DataSource = lst2;
                        gvMovCta.DataBind();
                        if (lst2.Count > 0)
                        {
                            gvMovCta.UseAccessibleHeader = true;
                            gvMovCta.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                        break;
                    default:
                        break;
                }
                List<DAL.VISTA_ANTICIPO_PROVEEDOR> lstAnticipos =
                    DAL.VISTA_ANTICIPO_PROVEEDOR.read(
                        Convert.ToInt32(Request.QueryString["ID"]));

                if (lstAnticipos.Count == 0)
                {
                    spanBilletera.Attributes.Remove("class");
                    spanBilletera.Attributes.Add(
                        "class", "pull-right badge bg-orange");
                }
                else
                {
                    spanBilletera.Attributes.Remove("class");
                    spanBilletera.Attributes.Add(
                        "class", "pull-right badge bg-green");
                }
                spanBilletera.InnerHtml = string.Format("{0:c}",
                    lstAnticipos.Sum(a=>a.MONTO));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "eliminar")
                {
                    DAL.CTACTE_GASTOS.delete(int.Parse(
                        e.CommandArgument.ToString()));
                    fillGastosaPagar(
    Convert.ToInt32(Request.QueryString["ID"]), 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGenerarGasto_Click(object sender, EventArgs e)
        {

        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = string.Empty;
                int select = 0;
                List<DAL.CTACTE_GASTOS> lst = new List<DAL.CTACTE_GASTOS>();
                DAL.CTACTE_GASTOS obj;
                for (int i = 0; i < gvProveedores.Rows.Count; i++)
                {
                    GridViewRow row = gvProveedores.Rows[i];
                    CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                    bool isChecked = chk.Checked;
                    if (isChecked)
                    {
                        select++;
                        obj = DAL.CTACTE_GASTOS.getByPk(int.Parse(row.Cells[0].Text));
                        lst.Add(obj);
                    }
                }
                lblCantFacturas.InnerHtml = select.ToString();
                decimal saldo = lst.Sum(c => c.SALDO);
                lblMonto.InnerHtml = string.Format("{0:c}", saldo);
                txtTotal.Text = string.Format("{0:c}", saldo);
                gvConfirmoPago.DataSource = lst;
                gvConfirmoPago.DataBind();


                if (lst.Count == 0)
                    divOrdenPago.Visible = false;
                else
                    divOrdenPago.Visible = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAcentarPago_ServerClick(object sender, EventArgs e)
        {
            try
            {
                List<DAL.CTACTE_GASTOS> lst = new List<DAL.CTACTE_GASTOS>();
                DAL.CTACTE_GASTOS obj;
                for (int i = 0; i < gvConfirmoPago.Rows.Count; i++)
                {
                    GridViewRow row = gvConfirmoPago.Rows[i];
                    obj = DAL.CTACTE_GASTOS.getByPk(int.Parse(row.Cells[0].Text));
                    //obj.ID_MEDIO_PAGO = Convert.ToInt32(DDLMedioPago.SelectedItem.Value);
                    obj.FECHA = LaHerradura.Utils.Utils.getFechaActual();
                    lst.Add(obj);
                }

                List<int> lstIdCta = new List<int>();
                foreach (var item in lst)
                {
                    lstIdCta.Add(item.ID);
                }
                string js = JsonConvert.SerializeObject(lstIdCta);

                Response.Redirect(string.Format(
                    "Pago.aspx?ID={0}&lst={1}",
                    Request.QueryString["ID"],
                    js));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void DDLFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillGastosaPagar(Convert.ToInt32(Request.QueryString["ID"]),
                    DDLFiltro.SelectedIndex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvCtaTotal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.CTACTE_GASTOS obj = (DAL.CTACTE_GASTOS)e.Row.DataItem;

                    HtmlGenericControl divAnchorRecibo = (HtmlGenericControl)
                        e.Row.FindControl("divAnchorRecibo");

                    DAL.USUARIOS objUsu =
DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));

                    HtmlGenericControl lblCta = (HtmlGenericControl)
    e.Row.FindControl("lblCta");
                    lblCta.InnerHtml =
                        BLL.CTACTE_GASTOS.detalle(obj.ID_PROVEEDOR, obj.PTO_VTA,
                        obj.NRO_CTE, obj.ID, objUsu.ROL);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void gvCtaTotal_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void btnAceptarCancelaDeuda_Click(object sender, EventArgs e)
        {
            try
            {
                string obs = txtObsAnulaComprobante.Text;
                int idUsuario = Convert.ToInt32(Request.Cookies["UserLh"]["Id"]);
                int nroRecibo = int.Parse(hNroRecibo.Value);

                int nro = BLL.ANULA_RECIBO.anulaPagoGasto(nroRecibo, obs, idUsuario);
                if (nro == 0)
                    Response.Redirect(string.Format("CtasCtesGastos.aspx?ID={0}", Request.QueryString["ID"]));
                else
                {
                    divError.Visible = true;
                    txtError.InnerHtml = string.Format(
                        "El recibo {0} no puede anularse. Debe anular previamente el recibo Nro.: {1}",
                        nroRecibo, nro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvProveedores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.USUARIOS objUsu =
DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                    LinkButton btnEliminar = (LinkButton)
                        e.Row.FindControl("btnEliminar");


                    DAL.CTACTE_GASTOS obj = (DAL.CTACTE_GASTOS)e.Row.DataItem;

                    if (!obj.PAGADO)
                    {
                        btnEliminar.Visible = true;
                    }
                    else
                    {
                        btnEliminar.Visible = false;
                    }

                    if (objUsu.ROL == 3)
                    {
                        CheckBox chkSelect = (CheckBox)
                            e.Row.FindControl("chkSelect");
                        chkSelect.Enabled = false;
                        btnEliminar.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAceptarOrdenPago_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.ORDENES_PAGO obj = new DAL.ORDENES_PAGO();
                obj.ESTADO = 0;
                obj.FECHA = Convert.ToDateTime(txtFecha.Text);
                obj.FECHA_CARGA = LaHerradura.Utils.Utils.getFechaActual();
                obj.ID_PROV = Convert.ToInt32(Request.QueryString["ID"]);
                obj.ID_USUARIO_CARGA = Convert.ToInt32(Request.Cookies["UserLh"]["Id"]);
                obj.PTO_VTA = 1;
                List<DAL.FACTURAS_X_OP> lst = new List<DAL.FACTURAS_X_OP>();
                DAL.FACTURAS_X_OP objF;
                decimal saldo = 0;
                for (int i = 0; i < gvConfirmoPago.Rows.Count; i++)
                {
                    GridViewRow row = gvConfirmoPago.Rows[i];
                    objF = new DAL.FACTURAS_X_OP();
                    objF.ID_FACTURA = int.Parse(row.Cells[0].Text);
                    saldo += decimal.Parse(row.Cells[3].Text);
                    lst.Add(objF);
                }
                obj.DEBE = saldo;
                obj.SALDO = saldo;
                BLL.ORDENES_PAGO.insert(obj, lst);
                fillGastosaPagar(
                    Convert.ToInt32(Request.QueryString["ID"]), 0);
                divOrdenPago.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvOP_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "delete")
                {

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

        protected void gvAdelantos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "eliminar")
                {
                    DAL.MOV_BILLETERA_GASTOS obj =
                        DAL.MOV_BILLETERA_GASTOS.getByPk(Convert.ToInt32(
                            e.CommandArgument));
                    DAL.MOV_BILLETERA_GASTOS.anular(obj.ID,
                        Convert.ToInt32(Request.Cookies["UserLh"]["Id"]),
                        LaHerradura.Utils.Utils.getFechaActual());
                    DAL.BILLETERA_GASTOS.setSaldo(
                        Convert.ToInt32(Request.QueryString["ID"]),
                        obj.MONTO - (obj.MONTO * 2));

                    Response.Redirect(string.Format(
                        "CtasCtesGastos.aspx?ID={0}",
                        Request.QueryString["ID"]));
                    //                List<DAL.VISTA_ANTICIPO_PROVEEDOR> lstAnticipos =
                    //DAL.VISTA_ANTICIPO_PROVEEDOR.read(
                    //    Convert.ToInt32(Request.QueryString["ID"]));

                    //                gvAdelantos.DataSource = lstAnticipos;
                    //                gvAdelantos.DataBind();

                    //                if (lstAnticipos.Count > 0)
                    //                {
                    //                    gvAdelantos.UseAccessibleHeader = true;
                    //                    gvAdelantos.HeaderRow.TableSection = TableRowSection.TableHeader;
                    //                }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvAdelantos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton btnDelete = (LinkButton)
                    e.Row.FindControl("btnDelete");
                    DAL.USUARIOS obj =
    DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));

                    if (obj.ROL == 3)
                    {
                        btnDelete.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}