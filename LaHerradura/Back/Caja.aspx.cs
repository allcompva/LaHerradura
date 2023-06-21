using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class Caja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            lblMsjError.InnerHtml = string.Empty;
            lblTitError.InnerHtml = string.Empty;

            if (Request.Cookies["UserLh"] != null)
            {
                hUsuario.Value = Request.Cookies["UserLh"]["Id"].ToString();
                DAL.USUARIOS objUsu = DAL.USUARIOS.getByPk(int.Parse(hUsuario.Value));
                txtUsuario.Text = objUsu.USUARIO;
                txtFechaHora.Text = LaHerradura.Utils.Utils.getFechaActual().ToShortDateString();
                txtFechaHora.Enabled = false;
                txtFecha.Text = Request.QueryString["id"].ToString();
                txtFecha.Enabled = false;
                //            if (Request.QueryString["id"] != null)
                //            {
                //                hIdPlanilla.Value = Request.QueryString["id"].ToString();
                //                DAL.PLANILLA_CAJA objCaja = DAL.PLANILLA_CAJA.getByPk(
                //int.Parse(hIdPlanilla.Value));

                //                if (!IsPostBack)
                //                {
                //                    txtFecha.Text = objCaja.FECHA.ToShortDateString();
                //                    txtFecha.Enabled = false;
                //                    fillCtaIngresos();
                //                    fillCtaEgreso(Convert.ToInt32(DDLCuentaEgreso.Items[0].Value), 2);
                //                    fillCtaEgreso2(Convert.ToInt32(DDLCuentaEgreso.Items[0].Value), 1);
                //                    fillEgresos(objCaja);
                //                }
                //                switch (objCaja.ESTADO)
                //                {
                //                    case 0:
                //                        btnAddEgreso.Enabled = true;
                //                        btnAddIngreso.Enabled = true;
                //                        btnCerraCa.Disabled = false;
                //                        break;
                //                    case 1:
                //                        btnAddEgreso.Enabled = false;
                //                        btnAddIngreso.Enabled = false;
                //                        btnCerraCa.Disabled = true;
                //                        break;
                //                    default:
                //                        break;
                //                }
                //            }
                //            else
                //            {
                //                divError.Visible = true;
                //                lblMsjError.InnerHtml = string.Empty;
                //                lblTitError.InnerHtml = "No se encontro una caja abierta";
                //            }
            }
            else
                Response.Redirect("../Login.aspx");
            if (Request.QueryString["id"] == null)
                Response.Redirect("../Login.aspx");
            fillIngresosEgresos(Convert.ToDateTime(Request.QueryString["id"]));
            DAL.USUARIOS obj =
    DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
            if (obj.ROL == 3)
            {
                Button1.Visible = false;
            }
        }
        private void fillIngresosEgresos(DateTime fecha)
        {
            try
            {
                List<DAL.MOVIM_CAJA_GRILLA> lstIngresos = DAL.MOVIM_CAJA_GRILLA.read(
                    fecha, 1, 1);

                List<DAL.MOVIM_CAJA_GRILLA> lstEgresos = 
                    DAL.MOVIM_CAJA_GRILLA.read(
                    fecha, 2, 1);

                gvEgresos.DataSource = lstEgresos;
                gvEgresos.DataBind();
                if (lstEgresos.Count > 0)
                {
                    gvEgresos.UseAccessibleHeader = true;
                    gvEgresos.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                gvIngresos.DataSource = lstIngresos;
                gvIngresos.DataBind();
                if (lstIngresos.Count > 0)
                {
                    gvIngresos.UseAccessibleHeader = true;
                    gvIngresos.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                DAL.VISTA_CAJAS objCaja = DAL.VISTA_CAJAS.getByFecha(fecha);

                spanSaldoAntCajaEfvo.InnerHtml = string.Format
                    ("{0:c}", objCaja.SALDO_ANTERIOR_EFECTIVO);
                spanSaldoAntCheque.InnerHtml = string.Format
                    ("{0:c}", objCaja.SALDO_ANTERIOR_CHEQUE);
                spanSaldoAntBanco.InnerHtml = string.Format
                    ("{0:c}", objCaja.SALDO_ANTERIOR_BANCO);

                //INGRESOS
                spanIngresosCajaEfvo.InnerHtml = string.Format
                    ("{0:c}", objCaja.INGRESO_EFECTIVO);

                spanIngresosCajaCheque.InnerHtml = string.Format
                    ("{0:c}", objCaja.INGRESO_CHEQUE);

                spanIngresosBanco.InnerHtml = string.Format
                    ("{0:c}", objCaja.INGRESO_BANCO);

                hIngresosBanco.Value = objCaja.INGRESO_BANCO.ToString();
                hIngresosCaja.Value = objCaja.INGRESO_EFECTIVO.ToString();
                hIngresosCajaCheque.Value = objCaja.INGRESO_CHEQUE.ToString();

                //EGRESOS
                spanEgresosCajaEfvo.InnerHtml = string.Format
                    ("{0:c}", objCaja.EGRESO_EFECTIVO);

                spanEgresosCajaCheque.InnerHtml = string.Format
                    ("{0:c}", objCaja.EGRESO_CHEQUE);

                spanEgresosBanco.InnerHtml = string.Format
                    ("{0:c}", objCaja.EGRESO_BANCO);

                hEgresosBanco.Value = objCaja.EGRESO_BANCO.ToString();
                hEgresosCaja.Value = objCaja.EGRESO_EFECTIVO.ToString();
                hEgresosCajaCheque.Value = objCaja.EGRESO_CHEQUE.ToString();

                spanSaldoBanco.InnerHtml = string.Format
                    ("{0:c}", objCaja.SALDO_BANCO);
                spanSaldoCajaEfvo.InnerHtml = string.Format
                    ("{0:c}", objCaja.SALDO_EFECTIVO);
                spanSaldoCheque.InnerHtml = string.Format
                    ("{0:c}", objCaja.SALDO_CHEQUE);

                txtSaldoBanco.Text = string.Format
                    ("{0:c}", objCaja.SALDO_BANCO);
                txtSaldoCajaEfvo.Text = string.Format
                    ("{0:c}", objCaja.SALDO_EFECTIVO);
                txtSaldoCajaCheque.Text = string.Format
                    ("{0:c}", objCaja.SALDO_CHEQUE);

                hSaldoBanco.Value = objCaja.SALDO_BANCO.ToString();
                hSaldoCajaCheque.Value = objCaja.SALDO_CHEQUE.ToString();
                hSaldoCajaEfvo.Value = objCaja.SALDO_EFECTIVO.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fillEgresos(DAL.PLANILLA_CAJA objCaja)
        {
            //clearEgreso();
            //clearIngreso();


            DateTime fecha = Convert.ToDateTime(txtFecha.Text);

            List<DAL.MOVIM_CAJA_GRILLA> lstIngresos = DAL.MOVIM_CAJA_GRILLA.getByPlanilla(
                objCaja.ID, 1);

            List<DAL.MOVIM_CAJA_GRILLA> lstEgresos = DAL.MOVIM_CAJA_GRILLA.getByPlanilla(
                objCaja.ID, 2);

            gvEgresos.DataSource = lstEgresos;
            gvEgresos.DataBind();
            if (lstEgresos.Count > 0)
            {
                gvEgresos.UseAccessibleHeader = true;
                gvEgresos.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            gvIngresos.DataSource = lstIngresos;
            gvIngresos.DataBind();
            if (lstIngresos.Count > 0)
            {
                gvIngresos.UseAccessibleHeader = true;
                gvIngresos.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            spanSaldoAntCajaEfvo.InnerHtml = string.Format
                ("{0:c}", objCaja.SALDO_ANTERIOR_EFVO);
            spanSaldoAntCheque.InnerHtml = string.Format
                ("{0:c}", objCaja.SALDO_ANTERIOR_CHEQUES);
            spanSaldoAntBanco.InnerHtml = string.Format
                ("{0:c}", objCaja.SALDO_ANTERIOR_BANCO);

            switch (objCaja.ESTADO)
            {
                case 0:
                    //INGRESOS
                    decimal cajaEfvoI = lstIngresos.FindAll(
                            i => i.CUENTA == "CAJA").Sum(e => e.MONTO);
                    decimal cajaChequeI = lstIngresos.FindAll(
                            i => i.CUENTA == "CAJA CHEQUES").Sum(e => e.MONTO);
                    decimal cajaBancoI = lstIngresos.FindAll(
                            i => i.CUENTA == "BANCO").Sum(e => e.MONTO);

                    spanIngresosCajaEfvo.InnerHtml = string.Format
                        ("{0:c}", cajaEfvoI);

                    spanIngresosCajaCheque.InnerHtml = string.Format
                        ("{0:c}", cajaChequeI);

                    spanIngresosBanco.InnerHtml = string.Format
                        ("{0:c}", cajaBancoI);

                    hIngresosBanco.Value = cajaBancoI.ToString();
                    hIngresosCaja.Value = cajaEfvoI.ToString();
                    hIngresosCajaCheque.Value = cajaChequeI.ToString();

                    //EGRESOS
                    decimal cajaEfvoE = lstEgresos.FindAll(
                i => i.CUENTA == "CAJA").Sum(e => e.MONTO);
                    decimal cajaChequeE = lstEgresos.FindAll(
                            i => i.CUENTA == "CAJA CHEQUES").Sum(e => e.MONTO);
                    decimal cajaBancoE = lstEgresos.FindAll(
                            i => i.CUENTA == "BANCO").Sum(e => e.MONTO);

                    spanEgresosCajaEfvo.InnerHtml = string.Format
                        ("{0:c}", cajaEfvoE);

                    spanEgresosCajaCheque.InnerHtml = string.Format
                        ("{0:c}", cajaChequeE);

                    spanEgresosBanco.InnerHtml = string.Format
                        ("{0:c}", cajaBancoE);

                    hEgresosBanco.Value = cajaBancoE.ToString();
                    hEgresosCaja.Value = cajaEfvoE.ToString();
                    hEgresosCajaCheque.Value = cajaChequeE.ToString();

                    decimal saldoCajaEfvo =
                        objCaja.SALDO_ANTERIOR_EFVO + cajaEfvoI - cajaEfvoE;
                    decimal saldoCajaCheque =
                        objCaja.SALDO_ANTERIOR_CHEQUES + cajaChequeI - cajaChequeE;
                    decimal saldoCajaBanco =
                        objCaja.SALDO_ANTERIOR_BANCO + cajaBancoI - cajaBancoE;

                    spanSaldoBanco.InnerHtml = string.Format
                        ("{0:c}", saldoCajaBanco);
                    spanSaldoCajaEfvo.InnerHtml = string.Format
                        ("{0:c}", saldoCajaEfvo);
                    spanSaldoCheque.InnerHtml = string.Format
                        ("{0:c}", saldoCajaCheque);

                    txtSaldoBanco.Text = string.Format
                        ("{0:c}", saldoCajaBanco);
                    txtSaldoCajaEfvo.Text = string.Format
                        ("{0:c}", saldoCajaEfvo);
                    txtSaldoCajaCheque.Text = string.Format
                        ("{0:c}", saldoCajaCheque);

                    hSaldoBanco.Value = saldoCajaBanco.ToString();
                    hSaldoCajaCheque.Value = saldoCajaCheque.ToString();
                    hSaldoCajaEfvo.Value = saldoCajaEfvo.ToString();
                    break;


                case 1:
                    //INGRESOS
                    spanIngresosCajaEfvo.InnerHtml = string.Format
                        ("{0:c}", objCaja.INGRESOS_EFVO);

                    spanIngresosCajaCheque.InnerHtml = string.Format
                        ("{0:c}", objCaja.INGRESOS_CHEQUES);

                    spanIngresosBanco.InnerHtml = string.Format
                        ("{0:c}", objCaja.INGRESOS_BANCO);

                    hIngresosBanco.Value = objCaja.INGRESOS_BANCO.ToString();
                    hIngresosCaja.Value = objCaja.INGRESOS_EFVO.ToString();
                    hIngresosCajaCheque.Value = objCaja.INGRESOS_CHEQUES.ToString();

                    //EGRESOS
                    spanEgresosCajaEfvo.InnerHtml = string.Format
                        ("{0:c}", objCaja.EGRESOS_EFVO);

                    spanEgresosCajaCheque.InnerHtml = string.Format
                        ("{0:c}", objCaja.EGRESOS_CHEQUES);

                    spanEgresosBanco.InnerHtml = string.Format
                        ("{0:c}", objCaja.EGRESOS_BANCO);

                    hEgresosBanco.Value = objCaja.EGRESOS_BANCO.ToString();
                    hEgresosCaja.Value = objCaja.EGRESOS_EFVO.ToString();
                    hEgresosCajaCheque.Value = objCaja.EGRESOS_CHEQUES.ToString();

                    spanSaldoBanco.InnerHtml = string.Format
                        ("{0:c}", objCaja.SALDO_BANCO);
                    spanSaldoCajaEfvo.InnerHtml = string.Format
                        ("{0:c}", objCaja.SALDO_EFVO);
                    spanSaldoCheque.InnerHtml = string.Format
                        ("{0:c}", objCaja.SALDO_CHEQUES);

                    txtSaldoBanco.Text = string.Format
                        ("{0:c}", objCaja.SALDO_BANCO);
                    txtSaldoCajaEfvo.Text = string.Format
                        ("{0:c}", objCaja.SALDO_EFVO);
                    txtSaldoCajaCheque.Text = string.Format
                        ("{0:c}", objCaja.SALDO_CHEQUES);

                    hSaldoBanco.Value = objCaja.SALDO_BANCO.ToString();
                    hSaldoCajaCheque.Value = objCaja.SALDO_CHEQUES.ToString();
                    hSaldoCajaEfvo.Value = objCaja.SALDO_EFVO.ToString();
                    break;
                default:
                    break;
            }

        }

        private void clearEgreso()
        {

            hEgresosBanco.Value = "0";
            hEgresosCaja.Value = "0";

        }
        private void clearIngreso()
        {
            hIngresosBanco.Value = "0";
            hIngresosCaja.Value = "0";
        }
        protected void DDLCuentaEgreso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnAceptarEgreso_ServerClick(object sender, EventArgs e)
        {


        }
        protected void btnCancelarEgreso_ServerClick(object sender, EventArgs e)
        {

        }
        protected void btnAddEgreso_Click(object sender, EventArgs e)
        {

        }
        protected void DDLCuentaIngreso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnCancelarIngresos_ServerClick(object sender, EventArgs e)
        {

        }
        protected void btnAceptarIngresos_ServerClick(object sender, EventArgs e)
        {

        }
        protected void txtFecha_TextChanged(object sender, EventArgs e)
        {
            DAL.PLANILLA_CAJA objCaja = DAL.PLANILLA_CAJA.getByPk(
                int.Parse(hIdPlanilla.Value));
            fillEgresos(objCaja);
        }
        protected void gvIngresos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            decimal ingresosCaja = Convert.ToDecimal(hIngresosCaja.Value);
            decimal ingresosBanco = Convert.ToDecimal(hIngresosBanco.Value);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbtnEliminar = (LinkButton)e.Row.FindControl("lbtnEliminar");
                //LinkButton lbtnEditar = (LinkButton)e.Row.FindControl("lbtnEditar");
                DAL.MOVIM_CAJA_GRILLA obj = (DAL.MOVIM_CAJA_GRILLA)e.Row.DataItem;
                if (obj.ID_CTA_EGRESO == 10)
                {
                    //lbtnEditar.Visible = false;
                    lbtnEliminar.Visible = false;
                }
                if (obj.CUENTA == "CAJA")
                {
                    ingresosCaja += obj.MONTO;
                    hIngresosCaja.Value = ingresosCaja.ToString();
                }
                if (obj.CUENTA == "BANCO")
                {
                    ingresosBanco += obj.MONTO;
                    hIngresosBanco.Value = ingresosBanco.ToString();
                }
            }
            //txtIngresosCaja.InnerText = string.Format("{0:c}", Convert.ToDecimal(hIngresosCaja.Value));
            //txtIngresosBanco.InnerText = string.Format("{0:c}", Convert.ToDecimal(hIngresosBanco.Value));
        }
        protected void gvEgresos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
        protected void gvIngresos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "eliminar")
            {
                DAL.TB_MOVIM_CAJA.delete((Convert.ToInt32(e.CommandArgument)));
                DAL.PLANILLA_CAJA objCaja = DAL.PLANILLA_CAJA.getByPk(
                    int.Parse(hIdPlanilla.Value));
                fillEgresos(objCaja);
            }
            //if (e.CommandName == "editar")
            //{
            //    DAL.Factu.TB_MOVIM_CAJA obj = DAL.Factu.TB_MOVIM_CAJA.getByPk(
            //        Convert.ToInt32(e.CommandArgument));
            //    DDLCuentaIngreso.SelectedValue = obj.ID_CTA_INGRESO.ToString();
            //    DDLCuentaIngreso_SelectedIndexChanged(null, null);
            //    DDLCtaIngreso.SelectedValue = obj.ID_CTA_EGRESO.ToString();
            //    DDLResponsableIngreso.SelectedValue = obj.ID_RESPONSABLE.ToString();
            //    txtDetalleIngresos.Text = obj.DETALLE;
            //    txtMontoIngresos.Text = obj.MONTO.ToString();
            //    UpdatePanel3.Update();
            //    btnAddIngreso_ModalPopupExtender.Show();
            //}
        }
        protected void gvEgresos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "eliminar")
            {
                DAL.TB_MOVIM_CAJA.delete((Convert.ToInt32(e.CommandArgument)));
                DAL.PLANILLA_CAJA objCaja = DAL.PLANILLA_CAJA.getByPk(
                    int.Parse(hIdPlanilla.Value));
                fillEgresos(objCaja);
            }
        }
        protected void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    DAL.PLANILLA_CAJA obj = DAL.PLANILLA_CAJA.getByPk(int.Parse(hIdPlanilla.Value));
            //    obj.EGRESOS_BANCO = Convert.ToDecimal(hEgresosBanco.Value);
            //    obj.EGRESOS_CHEQUES = Convert.ToDecimal(hEgresosCajaCheque.Value);
            //    obj.EGRESOS_EFVO = Convert.ToDecimal(hEgresosCaja.Value);
            //    obj.ESTADO = 1;
            //    obj.FECHA_CIERRE = ;
            //    obj.INGRESOS_BANCO = Convert.ToDecimal(hIngresosBanco.Value);
            //    obj.INGRESOS_CHEQUES = Convert.ToDecimal(hIngresosCajaCheque.Value);
            //    obj.INGRESOS_EFVO = Convert.ToDecimal(hIngresosCaja.Value);
            //    obj.OBS_CIERRE = txtObs.Text;
            //    obj.SALDO_BANCO = Convert.ToDecimal(hSaldoBanco.Value);
            //    obj.SALDO_CHEQUES = Convert.ToDecimal(hSaldoCajaCheque.Value);
            //    obj.SALDO_EFVO = Convert.ToDecimal(hSaldoCajaEfvo.Value);
            //    obj.USUARIO_CIERRA = int.Parse(hUsuario.Value);
            //    DAL.PLANILLA_CAJA.update(obj);
            //    Response.Redirect("ListaCajas.aspx");
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        protected void btnAddMovimiento_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.TB_MOVIM_CAJA objMovEgresa = new DAL.TB_MOVIM_CAJA();
                objMovEgresa.DETALLE = string.Format("Salida de {0} a {1} en concepto de {2}",
                    DDLEgreso.SelectedItem.Text,
                    DDLIngreso.SelectedItem.Text,
                    txtDetalleMov.Text);
                objMovEgresa.HORA = Convert.ToDateTime(txtFechaMov.Text);
                objMovEgresa.ID_CAJA = 1;
                objMovEgresa.ID_CTA_EGRESO = int.Parse(DDLEgreso.SelectedItem.Value);
                objMovEgresa.ID_CTA_INGRESO = int.Parse(DDLEgreso.SelectedItem.Value);
                objMovEgresa.ID_FACTURA = 0;
                objMovEgresa.MONTO = decimal.Parse(txtMonto.Text);
                objMovEgresa.TIPO_MOV = 2;
                objMovEgresa.ID_RESPONSABLE = 1;
                objMovEgresa.ID_USUARIO = 1;
                objMovEgresa.ID_SUCURSAL = 1;

                DAL.TB_MOVIM_CAJA objMovIngresa = new DAL.TB_MOVIM_CAJA();
                objMovIngresa.DETALLE = string.Format("Ingreso a {0} de {1} en concepto de {2}",
                    DDLIngreso.SelectedItem.Text,
                    DDLEgreso.SelectedItem.Text,
                    txtDetalleMov.Text);
                objMovIngresa.HORA = Convert.ToDateTime(txtFechaMov.Text);
                objMovIngresa.ID_CAJA = 1;
                objMovIngresa.ID_CTA_EGRESO = int.Parse(DDLIngreso.SelectedItem.Value);
                objMovIngresa.ID_CTA_INGRESO = int.Parse(DDLIngreso.SelectedItem.Value);
                objMovIngresa.ID_FACTURA = DAL.TB_MOVIM_CAJA.insert(objMovEgresa);
                objMovIngresa.MONTO = decimal.Parse(txtMonto.Text);
                objMovIngresa.TIPO_MOV = 1;
                objMovIngresa.ID_RESPONSABLE = 1;
                objMovIngresa.ID_USUARIO = 1;
                objMovIngresa.ID_SUCURSAL = 1;
                DAL.TB_MOVIM_CAJA.insert(objMovIngresa);
                Response.Redirect(string.Format("Caja.aspx?id={0}",
                    Request.QueryString["id"]));

                int mes = Convert.ToDateTime(
                    txtFecha.Text).Month;
                int anio = Convert.ToDateTime(
                    txtFecha.Text).Year;
                int nroAsiento = DAL.ASIENTOS.getMaxAsiento(
                    mes, anio);
                DAL.ASIENTOS objAsiento = new DAL.ASIENTOS();

                objAsiento.DESCRIPCION = string.Format(
                    "Movimiento de {0} a {1} {2}",
                    objMovIngresa.ID_CTA_INGRESO,
                    objMovEgresa.ID_CTA_EGRESO,
                    txtDetalleMov.Text);

                objAsiento.FECHA = objMovEgresa.HORA.Value;
                objAsiento.MONTO = objMovEgresa.MONTO;
                objAsiento.USUARIO = 1;
                objAsiento.NRO = nroAsiento + 1;
                objAsiento.TIPO = 7;
                objAsiento.EJERCICIO = objMovEgresa.HORA.Value.Year;
                objAsiento.REFERENCIA = objMovIngresa.ID.ToString();

                int idAsiento = DAL.ASIENTOS.insert(objAsiento);
                DAL.ASIENTOS_DETALLE objDebe = new DAL.ASIENTOS_DETALLE();
                objDebe.HABER = objMovEgresa.MONTO;
                objDebe.ID_CUENTA = objMovEgresa.ID_CTA_EGRESO;
                objDebe.ID_ASIENTO = idAsiento;
                objDebe.ID_REFERENCIA = objMovEgresa.ID.ToString();
                DAL.ASIENTOS_DETALLE.insert(objDebe);


                DAL.ASIENTOS_DETALLE objHaber = new DAL.ASIENTOS_DETALLE();
                objHaber.DEBE = objMovIngresa.MONTO;
                objHaber.ID_CUENTA = objMovIngresa.ID_CTA_INGRESO;
                objHaber.ID_ASIENTO = idAsiento;
                objHaber.ID_REFERENCIA = objMovIngresa.ID.ToString();
                DAL.ASIENTOS_DETALLE.insert(objHaber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}