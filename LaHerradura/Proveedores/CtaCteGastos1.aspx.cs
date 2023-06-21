using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Proveedores
{
    public partial class CtaCteGastos1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DAL.USUARIOS obj = DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                if (obj.ROL == 3)
                {
                    divBotones.Visible = false;
                }
                if (!IsPostBack)
                {
                    rbtnFiltro.SelectedIndex = 0;
                    DDLProveedor.DataValueField = "ID";
                    DDLProveedor.DataTextField = "NOMBRE_FANTASIA";
                    DDLProveedor2.DataValueField = "ID";
                    DDLProveedor2.DataTextField = "NOMBRE_FANTASIA";
                    List<DAL.PROVEEDORES> lst = DAL.PROVEEDORES.read();
                    if (lst.Count > 0)
                    {
                        DDLProveedor.DataSource = lst;
                        DDLProveedor.DataBind();

                        DDLProveedor2.DataSource = lst;
                        DDLProveedor2.DataBind();
                        fillCta(lst[0].ID);
                    }
                    DDLMedioPago.DataTextField = "DESCRIPCION";
                    DDLMedioPago.DataValueField = "ID";

                    DDLMedioPago.DataSource = DAL.MEDIOS_PAGO.readManual();
                    DDLMedioPago.DataBind();
                    fillGastosaPagar(true);

                    DDLBanco.DataValueField = "CODIGO";
                    DDLBanco.DataTextField = "DENOMINACION";
                    DDLBanco.DataSource = DAL.BANCOS.read();
                    DDLBanco.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : ", ex);
            }
        }
        private void fillCta(int idProv)
        {
            try
            {
                DDLCtaGasto.DataTextField = "CUENTA_GASTO";
                DDLCtaGasto.DataValueField = "ID_CTA_CONTABLE_GASTO";
                List<DAL.CUENTAS_X_PROVEEDOR> lst = DAL.CUENTAS_X_PROVEEDOR.read(idProv);
                if (lst.Count > 0)
                {
                    DDLCtaGasto.DataSource = lst;
                    DDLCtaGasto.DataBind();
                    btnConsulta.Visible = true;
                    DDLCtaGasto.Visible = true;
                    lblError.Visible = false;
                }
                else
                {
                    btnConsulta.Visible = false;
                    DDLCtaGasto.Visible = false;
                    lblError.Visible = true;
                    lblError.Text =
                        "No pueden cargarse facturas porque el proveedor no tiene asignadas cuentas contables";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fillGastosaPagar(bool conDeuda)
        {
            try
            {
                List<DAL.PROVEEDORES> lst = new List<DAL.PROVEEDORES>();
                if (conDeuda)
                    lst = DAL.PROVEEDORES.readDeudas(true);
                else
                    lst = DAL.PROVEEDORES.readDeudas(false);
                gvDeudas.DataSource = lst;
                gvDeudas.DataBind();
                if (lst.Count > 0)
                {
                    gvDeudas.UseAccessibleHeader = true;
                    gvDeudas.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Metodo fillGastosaPagar : ", ex);
            }
        }
        protected void btnConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                int idProv = Convert.ToInt32(DDLProveedor.SelectedItem.Value);
                int ptoVta = int.Parse(txtPuntoVenta.Text);
                int nroCte = int.Parse(txtNumeroComprobante.Text);
                DAL.CTACTE_GASTOS objValida = DAL.CTACTE_GASTOS.getByPk(idProv, ptoVta, nroCte);
                if (objValida == null)
                {
                    DAL.CTACTE_GASTOS obj = new DAL.CTACTE_GASTOS();
                    obj.ID_PROVEEDOR = idProv;
                    obj.TIPO_MOVIMIENTO = 1;

                    var culturaArgentina = CultureInfo.GetCultureInfo("es-AR");
                    decimal importe =
                        Convert.ToDecimal(
                            txtImporte.Text.Replace(".", ","),
                            culturaArgentina);

                    obj.MONTO_ORIGINAL = importe;
                    obj.DEBE = importe;
                    obj.SALDO = importe;
                    obj.PTO_VTA = ptoVta;
                    obj.NRO_CTE = nroCte;
                    obj.CAE = long.Parse(txtCAE.Text);
                    obj.FECHA_CAE = DateTime.Parse(txtFechaEmision.Text);
                    obj.FECHA_CARGA = LaHerradura.Utils.Utils.getFechaActual();
                    obj.FECHA = Convert.ToDateTime(txtFechaCarga.Text);
                    obj.PAGADO = false;
                    obj.SALDO_CAPITAL = Convert.ToDecimal(
                        txtImporte.Text.Replace(".", ","),
                    culturaArgentina);
                    obj.SALDO_INTERES = 0;
                    obj.ESTADO = 0;
                    obj.OBS = txtDetalleFactura.Text;
                    obj.ID_USUARIO_CARGA = Convert.ToInt32(Request.Cookies["UserLh"]["Id"]);
                    obj.ID_PLAN_CUENTA = Convert.ToInt32(
                        DDLCtaGasto.SelectedItem.Value);
                    obj.TIPO_GASTO = int.Parse(DDLTipoGasto.SelectedItem.Value);
                    DAL.CTACTE_GASTOS.insert(obj);
                    Response.Redirect("CtaCteGastos1.aspx");
                }
                else
                {
                    divError.Visible = true;
                    lblError2.InnerHtml = "No puede cargarse mas de una ves el mismo comprobante";
                }

                fillGastosaPagar(true);
            }
            catch (Exception ex)
            {
                lblError2.InnerHtml = ex.Message;
            }
        }

        protected void DDLFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLF_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rbtnFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtnFiltro.SelectedIndex == 0)
                    fillGastosaPagar(true);
                else
                    fillGastosaPagar(false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvDeudas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl divBilletera =
                        (HtmlGenericControl)e.Row.FindControl("divBilletera");
                    /*<span class="pull-right badge bg-green">12</span>*/
                    DAL.PROVEEDORES obj = (DAL.PROVEEDORES)e.Row.DataItem;
                    DAL.BILLETERA_GASTOS objBilletera =
                        DAL.BILLETERA_GASTOS.getByPk(obj.ID);
                    HtmlGenericControl bg = new HtmlGenericControl();
                    bg.TagName = "span";
                    if (objBilletera.SALDO > 0)
                        bg.Attributes.Add("class", "pull-right badge bg-green");
                    else
                        bg.Attributes.Add("class", "pull-right badge bg-orange");
                    bg.InnerHtml = string.Format("{0:c}", objBilletera.SALDO);
                    divBilletera.Controls.Add(bg);
                }
            }
            catch (Exception ex)
            {
                txtError.InnerText = ex.Message;
                throw ex;
            }
        }

        protected void DDLProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillCta(int.Parse(DDLProveedor.SelectedItem.Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lbtnAddValor_Click(object sender, EventArgs e)
        {

        }

        protected void gvValores_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnAceptarAdelanto_ServerClick(object sender, EventArgs e)
        {
            try
            {
                DAL.MOV_BILLETERA_GASTOS obj = new DAL.MOV_BILLETERA_GASTOS();

                obj.FECHA = Convert.ToDateTime(txtFechaAdelanto.Text);
                obj.ID_MEDIO_PAGO = int.Parse(DDLMedioPago.SelectedItem.Value);
                obj.ID_PROVEEDOR = int.Parse(DDLProveedor2.SelectedItem.Value);

                var culturaArgentina = CultureInfo.GetCultureInfo("es-AR");
                decimal importe = 0;
                importe = Convert.ToDecimal(txtMontoVal.Text.Replace(".", ","),
                    culturaArgentina);
                obj.MONTO = importe;
                obj.NRO_RECIBO_ADELANTO = DAL.MOV_BILLETERA_GASTOS.getUltimoRecibo() + 1;
                obj.NRO_RECIBO = 0;
                obj.TIPO_MOVIMIENTO = 1;
                if (DDLMedioPago.SelectedItem.Value == "2")
                {
                    obj.CUIT_PAGADOR = txtCuitPagador.Text;
                    obj.FECHA_CHEQUE = Convert.ToDateTime(
                        txtFechaCheque.Text);
                    obj.ID_BANCO = int.Parse(DDLBanco.SelectedItem.Value);
                    obj.NRO_CHEQUE = txtNroCheque.Text;
                }
                obj.FECHA_CARGA = LaHerradura.Utils.Utils.getFechaActual();
                obj.ID_USUARIO_CARGA = Convert.ToInt32(Request.Cookies["UserLh"]["Id"]);
                DAL.MOV_BILLETERA_GASTOS.insert(obj);
                DAL.BILLETERA_GASTOS.setSaldo(obj.ID_PROVEEDOR, obj.MONTO);
                Response.Redirect(string.Format(
                    "CtasCtesGastos.aspx?ID={0}", obj.ID_PROVEEDOR));

                DAL.PROVEEDORES objProv =
                                DAL.PROVEEDORES.getByPk(obj.ID_PROVEEDOR);
                //MOVIMIENTO DE CAJA
                DAL.TB_MOVIM_CAJA objMovim = new DAL.TB_MOVIM_CAJA();
                objMovim.DETALLE = string.Format(
                    "Adelanto a {0} - Recibio Adelanto Nro.: {1}",
                    objProv.RAZON_SOCIAL, obj.NRO_RECIBO_ADELANTO);
                objMovim.HORA = obj.FECHA;
                objMovim.ID_CAJA = 1;
                //objMovim.ID_PLANILLA = objPlanilla.ID;
                objMovim.ID_PLANILLA = 0;
                switch (obj.ID_MEDIO_PAGO)
                {
                    case 1:
                        objMovim.ID_CTA_INGRESO = 1;
                        objMovim.ID_CTA_EGRESO = 1;
                        break;
                    case 2:
                        objMovim.ID_CTA_INGRESO = 3;
                        objMovim.ID_CTA_EGRESO = 3;
                        break;
                    default:
                        objMovim.ID_CTA_INGRESO = 2;
                        objMovim.ID_CTA_EGRESO = 2;
                        break;
                }

                objMovim.ID_RESPONSABLE = 1;
                objMovim.ID_USUARIO = 1;
                objMovim.MONTO = obj.MONTO;
                objMovim.ID_FACTURA = obj.NRO_RECIBO_ADELANTO;
                objMovim.TIPO_MOV = 2;
                objMovim.ID_SUCURSAL = 1;
                DAL.TB_MOVIM_CAJA.insert(objMovim);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}