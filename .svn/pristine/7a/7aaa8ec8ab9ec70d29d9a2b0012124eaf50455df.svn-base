using Newtonsoft.Json;
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
    public partial class Pago : System.Web.UI.Page
    {
        //CORREGIDO
        protected void removeValorBilletera()
        {
            int index = 0;
            List<DAL.PAGOS_X_FACTURA_GASTOS> lst = leerGrilla();
            DAL.PAGOS_X_FACTURA_GASTOS obj = lst[index];
            lst.RemoveAt(index);
            fillGrilla(lst);
            lbtnAddValor.Visible = true;

            btnAcentarPago.Visible = false;
            var culturaArgentina = CultureInfo.GetCultureInfo("es-AR");
            txtMontoVal.Text =
                (Convert.ToDecimal(lblDeudaPagar.Text.Replace(".", ","),
                culturaArgentina) - acumulado()).ToString();

            spanSaldo.InnerHtml = acumulado().ToString();
            txtMontoVal.Focus();
            DDLMedioPago.SelectedIndex = 0;
            DDLMedioPago_SelectedIndexChanged(null, null);

            decimal montoFacturado = 
                Convert.ToDecimal(lblDeudaPagar.Text.Replace(".", ","),
                culturaArgentina);

            decimal montoValor = Convert.ToDecimal(
                txtMontoVal.Text.Replace(".", ","), culturaArgentina);

            if (acumulado() + montoValor > montoFacturado)
            {
                txtMontoVal.Focus();
                divBilletera.Visible = true;
                //return;
            }
            else
            {
                txtMontoVal.Focus();
                divBilletera.Visible = false;
            }

            decimal diferencia = 0;
            if (acumulado() > montoFacturado)
            {
                diferencia = acumulado() - montoFacturado;
            }
            spanAcreditar.InnerHtml = montoFacturado.ToString();
            spanBilletera.InnerHtml = diferencia.ToString();
            if (obj.ID_PLAN_PAGO == 9)
            {
                chkSelect.Checked = false;
                txtMontoBilleteraEditable.Text = hMontoOriginalBilletera.Value;
            }
        }
        //CORREGIDO
        protected void addValorBilletera()
        {
            try
            {
                var culturaArgentina = CultureInfo.GetCultureInfo("es-AR");
                divError.Visible = false;
                divBilletera.Visible = false;
                //TOTAL DE LA FACTURA
                decimal montoFacturado = Convert.ToDecimal(
                    lblDeudaPagar.Text.Replace(".", ","),
                culturaArgentina);
                //MONTO A PAGAR CON EL MEDIO DE PAGO
                decimal montoValor = Convert.ToDecimal(
                    txtMontoBilleteraEditable.Text.Replace(".", ","),
                culturaArgentina);

                decimal saldo = 0;
                decimal acumulado_ = 0;
                if (montoValor == 0)
                    return;
                if (montoValor > montoFacturado)
                {

                    txtMontoVal.Focus();
                    divBilletera.Visible = true;
                    //return;
                }
                if (acumulado() + montoValor > montoFacturado)
                {
                    txtMontoVal.Focus();
                    divBilletera.Visible = true;
                    //return;
                }
                List<DAL.PAGOS_X_FACTURA_GASTOS> lst = leerGrilla();
                DAL.PAGOS_X_FACTURA_GASTOS obj = new DAL.PAGOS_X_FACTURA_GASTOS();

                obj.ID_PLAN_PAGO = 9;
                obj.MEDIO_PAGO = "ANTICIPO PROVEEDORES";
                obj.MONTO = montoValor;
                if (DDLMedioPago.SelectedIndex == 0)
                {
                    DAL.PAGOS_X_FACTURA_GASTOS control = lst.Find(o => o.MEDIO_PAGO == obj.MEDIO_PAGO);
                    if (control == null)
                        lst.Insert(0, obj);
                    else
                        lst.Find(o => o.MEDIO_PAGO == obj.MEDIO_PAGO).MONTO += obj.MONTO;
                }
                else
                    lst.Insert(0, obj);
                fillGrilla(lst);
                DDLMedioPago.SelectedIndex = 0;
                acumulado_ = acumulado();
                saldo = montoFacturado - acumulado_;

                if (saldo >= 0)
                {
                    txtMontoVal.Text = saldo.ToString();
                    spanSaldo.InnerText = acumulado_.ToString();
                }
                else
                {
                    txtMontoVal.Text = 0.ToString();
                    spanSaldo.InnerText = acumulado_.ToString();
                }


                decimal diferencia = 0;
                if (acumulado() > montoFacturado)
                {
                    diferencia = acumulado() - montoFacturado;
                }
                spanAcreditar.InnerHtml = montoFacturado.ToString();
                spanBilletera.InnerHtml = diferencia.ToString();


                txtMontoVal.Focus();
                if (saldo <= 0)
                {
                    btnAcentarPago.Visible = true;
                    hPagoCuenta.Value = 0.ToString();
                }
                else
                {
                    hPagoCuenta.Value = 1.ToString();
                    btnAcentarPago.Visible = true;
                    //btnAcentarPago.Visible = false;
                }
                DDLMedioPago.SelectedIndex = 0;
                DDLMedioPago_SelectedIndexChanged(null, null);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CORREGIDO
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divErrorBilletera.Visible = false;
                divError.Visible = false;
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        hUsuario.Value = Request.Cookies["UserLh"]["Id"];

                        //List<DAL.CTACTE_GASTOS> lst = (List<DAL.CTACTE_GASTOS>)Session["CTAS"];

                        //List<int> lstIdCta = JsonConvert.DeserializeObject<List<int>>(Request.QueryString["lst"]);


                        List<DAL.CTACTE_GASTOS> lst = new
                            List<DAL.CTACTE_GASTOS>();
                        //DAL.CTACTE_GASTOS obj;
                        //foreach (var item in lstIdCta)
                        //{
                        //    obj = DAL.CTACTE_GASTOS.getByPk(item);
                        //    obj.FECHA = ;
                        //    lst.Add(obj);
                        //}
                        List<DAL.FACTURAS_X_OP> lstFact =
                            DAL.FACTURAS_X_OP.getByOrdenPago(int.Parse(
                                Request.QueryString["id"]));

                        DAL.CTACTE_GASTOS obj;
                        foreach (var item in lstFact)
                        {
                            obj = DAL.CTACTE_GASTOS.getByPk(item.ID_FACTURA);
                            obj.FECHA = LaHerradura.Utils.Utils.getFechaActual();
                            lst.Add(obj);
                        }

                        hNroCta.Value = lst[0].ID_PROVEEDOR.ToString();

                        gvCtaCte.DataSource = lst.OrderBy(l => l.FACTURA).ToList(); ;
                        gvCtaCte.DataBind();

                        DDLMedioPago.DataTextField = "DESCRIPCION";
                        DDLMedioPago.DataValueField = "ID";

                        DDLMedioPago.DataSource = DAL.MEDIOS_PAGO.readManual();
                        DDLMedioPago.DataBind();
                        fillDeuda(lst);
                        var culturaArgentina = CultureInfo.GetCultureInfo("es-AR");
                        DAL.BILLETERA_GASTOS objBilletera = DAL.BILLETERA_GASTOS.getByPk(lst[0].ID_PROVEEDOR);
                        if (objBilletera.SALDO == 0)
                        {
                            divSaldoBilletera.Visible = false;
                        }
                        else
                        {
                            divSaldoBilletera.Visible = true;
                            if (Convert.ToDecimal(lblDeudaPagar.Text
                                .Replace(".", ","),
                    culturaArgentina) > objBilletera.SALDO)
                            {
                                txtMontoBilleteraEditable.Text = objBilletera.SALDO.ToString();
                                hMontoOriginalBilletera.Value = objBilletera.SALDO.ToString();
                            }
                            else
                            {
                                txtMontoBilleteraEditable.Text = lblDeudaPagar.Text;
                                hMontoOriginalBilletera.Value = lblDeudaPagar.Text;
                            }
                            addValorBilletera();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //CORREGIDO
        private void fillDeuda(List<DAL.CTACTE_GASTOS> lst)
        {
            try
            {
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                lblMensaje.Text = string.Empty;
                decimal deuda = 0;
                decimal deudaOriginal = 0;
                decimal intereses = 0;
                decimal descuento = 0;
                decimal pagoACta = 0;
                int select = 0;
                List<DAL.CTACTE_GASTOS> lst2 = new List<DAL.CTACTE_GASTOS>();
                DAL.CTACTE_GASTOS obj;
                for (int i = 0; i < lst.Count; i++)
                {
                    obj = DAL.CTACTE_GASTOS.getByPk(lst[i].ID);
                    intereses += obj.INTERES_MORA;
                    if (obj.PAGO_A_CTA > 0)
                    {
                        deudaOriginal += obj.SALDO_CAPITAL;
                    }
                    else
                    {
                        deudaOriginal += obj.MONTO_ORIGINAL;
                    }
                    pagoACta += obj.PAGO_A_CTA;
                    lst2.Add(obj);
                    if (obj.DESCUENTO > 0)
                    {
                        descuento = obj.DESCUENTO;
                    }
                }
                deuda = deudaOriginal - descuento + intereses;
                txtFechaCobro.Text = string.Format("{0}-{1}-{2}",
                    fec.Year,
                    fec.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                    fec.Day.ToString().PadLeft(2, Convert.ToChar("0")));

                txtMontoVal.Text = deuda.ToString();
                lblDeudaPagar.Text = deuda.ToString();
                lblCantSelecionados.Text = select.ToString();
                lblDesc.Text = descuento.ToString();

                lblMontoOriginal.Text = deudaOriginal.ToString();
                gvConfirmoPago.DataSource = lst2.OrderBy(l => l.FACTURA).ToList();
                gvConfirmoPago.DataBind();
                txtTotDetalle.InnerHtml = deuda.ToString();
                //lblDeudaOriginal.Text = deudaOriginal.ToString();
                //lblIntereses.Text = intereses.ToString();
                if (lst2.Count == 0)
                    divAsiento.Visible = false;
                else
                    divAsiento.Visible = true;

                DDLBanco.DataValueField = "CODIGO";
                DDLBanco.DataTextField = "DENOMINACION";
                DDLBanco.DataSource = DAL.BANCOS.read();
                DDLBanco.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CORREGIDO
        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.CTACTE_GASTOS obj = (DAL.CTACTE_GASTOS)e.Row.DataItem;
                    Label lblPeriodo = (Label)e.Row.FindControl("lblPeriodo");

                    lblPeriodo.Text = obj.FACTURA;

                    HtmlGenericControl divDescuento = (HtmlGenericControl)
e.Row.FindControl("divDescuento");
                    divDescuento.InnerHtml =
                                string.Format(
       "<a href=\"#\" class=\"pull-right\" onclick=\"abreDescuento('{0}','{1}')\"><span class=\"fa fa-dollar\" style=\"color: green;\"></span></a>",
                                obj.ID, obj.SALDO);


                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        //CORREGIDO
        protected void btnCancela_Click(object sender, EventArgs e)
        {
            try
            {
                List<DAL.CTACTE_GASTOS> lst = new List<DAL.CTACTE_GASTOS>();
                DAL.CTACTE_GASTOS obj;
                for (int i = 0; i < gvCtaCte.Rows.Count; i++)
                {
                    GridViewRow row = gvCtaCte.Rows[i];
                    obj = DAL.CTACTE_GASTOS.getByPk(int.Parse(row.Cells[0].Text));
                    obj.FECHA = LaHerradura.Utils.Utils.getFechaActual();

                    obj = DAL.CTACTE_GASTOS.getByPk(int.Parse(row.Cells[0].Text));
                    lst.Add(obj);
                }
                gvCtaCte.DataSource = lst;
                gvCtaCte.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //CORREGIDO
        protected void btnAsientaPago_Click(object sender, EventArgs e)
        {
            try
            {
                List<DAL.CTACTE_GASTOS> lst = new List<DAL.CTACTE_GASTOS>();
                DAL.CTACTE_GASTOS obj;
                List<DAL.PAGOS_X_FACTURA_GASTOS> lstPagos = leerGrilla();
                decimal TotalPagado = lstPagos.Sum(p => p.MONTO);

                for (int i = 0; i < gvConfirmoPago.Rows.Count; i++)
                {
                    GridViewRow row = gvConfirmoPago.Rows[i];
                    int id = int.Parse(row.Cells[0].Text);

                    obj = DAL.CTACTE_GASTOS.getByPk(id);
                    hIdProv.Value = obj.ID_PROVEEDOR.ToString();
                    if (!obj.PAGADO)
                    {
                        obj.ID_MEDIO_PAGO = lstPagos[0].ID_PLAN_PAGO;
                        obj.FECHA = Convert.ToDateTime(txtFechaCobro.Text);
                        obj.ID_USUARIO_PAGA = int.Parse(hUsuario.Value);
                        if (obj.SALDO <= TotalPagado)
                        {
                            TotalPagado = TotalPagado - obj.SALDO;
                            obj.PAGO_TOTAL = true;
                            obj.MONTO_PAGADO = obj.SALDO;
                            lst.Add(obj);
                        }
                        else
                        {
                            obj.PAGO_TOTAL = false;
                            obj.MONTO_PAGADO = TotalPagado;
                            lst.Add(obj);
                            break;
                        }
                    }
                }
                lst = lst.OrderBy(p => p.FACTURA).ToList();
                decimal totalPago1 = lstPagos.Sum(s => s.MONTO);
                decimal totalPago2 = lst.Sum(c => c.MONTO_PAGADO);
                decimal control = totalPago1 - totalPago2;
                CTA_CTE_GASTOS.asientaPago(lst,
                    lstPagos, Convert.ToDateTime(txtFechaCobro.Text),
                    int.Parse(Request.QueryString["id"]),
                    Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                Response.Redirect(string.Format("CtasCtesGastos.aspx?ID={0}", int.Parse(hIdProv.Value)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CORREGIDO
        private List<DAL.PAGOS_X_FACTURA_GASTOS> leerGrilla()
        {
            decimal tot = 0;
            List<DAL.PAGOS_X_FACTURA_GASTOS> lst = new List<DAL.PAGOS_X_FACTURA_GASTOS>();
            for (int i = 0; i < gvValores.Rows.Count; i++)
            {
                GridViewRow row = gvValores.Rows[i];
                DAL.PAGOS_X_FACTURA_GASTOS obj = new DAL.PAGOS_X_FACTURA_GASTOS();
                obj.MEDIO_PAGO = gvValores.DataKeys[i].Values["MEDIO_PAGO"].ToString();
                obj.ID_PLAN_PAGO = Convert.ToInt32(gvValores.DataKeys[i].Values["ID_PLAN_PAGO"].ToString());
                if (gvValores.DataKeys[i].Values["BANCO"] != null)
                {
                    obj.BANCO = gvValores.DataKeys[i].Values["BANCO"].ToString();
                    obj.ID_BANCO = Convert.ToInt32(gvValores.DataKeys[i].Values["ID_BANCO"].ToString());
                    obj.NRO_CHEQUE = gvValores.DataKeys[i].Values["NRO_CHEQUE"].ToString();
                    obj.CUIT_PAGADOR = gvValores.DataKeys[i].Values["CUIT_PAGADOR"].ToString();
                    obj.FECHA_CHEQUE = Convert.ToDateTime(
                        gvValores.DataKeys[i].Values["FECHA_CHEQUE"]);
                }
                obj.MONTO = Convert.ToDecimal(gvValores.DataKeys[i].Values["MONTO"]);
                lst.Add(obj);
            }
            //txtTot.Text = tot.ToString();
            return lst;
        }
        //CORREGIDO
        protected void DDLMediosPAgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDLMedioPago.SelectedIndex == 1)
                    divCheque.Visible = true;
                else
                    divCheque.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CORREGIDO
        private decimal acumulado()
        {
            try
            {
                return leerGrilla().Sum(p => p.MONTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CORREGIDO
        protected void lbtnAddValor_Click(object sender, EventArgs e)
        {
            try
            {
                var culturaArgentina = CultureInfo.GetCultureInfo("es-AR");
                divError.Visible = false;
                divBilletera.Visible = false;
                //TOTAL DE LA FACTURA
                decimal montoFacturado = Convert.ToDecimal(
                    lblDeudaPagar.Text.Replace(".", ","),
                culturaArgentina);
                decimal montoValor = 0;

                montoValor = Convert.ToDecimal(
                    txtMontoVal.Text.Replace(".", ","),
                culturaArgentina);
                
                decimal saldo = 0;
                decimal acumulado_ = 0;
                if (montoValor == 0)
                    return;
                if (montoValor > montoFacturado)
                {

                    txtMontoVal.Focus();
                    divBilletera.Visible = true;
                    //return;
                }
                if (acumulado() + montoValor > montoFacturado)
                {
                    txtMontoVal.Focus();
                    divBilletera.Visible = true;
                    //return;
                }
                List<DAL.PAGOS_X_FACTURA_GASTOS> lst = leerGrilla();
                DAL.PAGOS_X_FACTURA_GASTOS obj = new DAL.PAGOS_X_FACTURA_GASTOS();
                if (divCheque.Visible)
                {
                    obj.ID_BANCO = int.Parse(DDLBanco.SelectedItem.Value);
                    obj.NRO_CHEQUE = txtNroCheque.Text;
                    obj.BANCO = DDLBanco.SelectedItem.Text;
                    obj.CUIT_PAGADOR = txtCuitPagador.Text;
                    obj.FECHA_CHEQUE = Convert.ToDateTime(txtFechaCheque.Text);
                }
                obj.ID_PLAN_PAGO = Convert.ToInt32(DDLMedioPago.SelectedItem.Value);
                obj.MEDIO_PAGO = DDLMedioPago.SelectedItem.Text;
                obj.MONTO = montoValor;
                if (DDLMedioPago.SelectedIndex == 0)
                {
                    DAL.PAGOS_X_FACTURA_GASTOS control = lst.Find(o => o.MEDIO_PAGO == obj.MEDIO_PAGO);
                    if (control == null)
                        lst.Add(obj);
                    else
                        lst.Find(o => o.MEDIO_PAGO == obj.MEDIO_PAGO).MONTO += obj.MONTO;
                }
                else
                    lst.Add(obj);
                fillGrilla(lst);
                DDLMedioPago.SelectedIndex = 0;
                acumulado_ = acumulado();
                saldo = montoFacturado - acumulado_;

                if (saldo >= 0)
                {
                    txtMontoVal.Text = saldo.ToString();
                    spanSaldo.InnerText = acumulado_.ToString();
                }
                else
                {
                    txtMontoVal.Text = 0.ToString();
                    spanSaldo.InnerText = acumulado_.ToString();
                }


                decimal diferencia = 0;
                if (acumulado() > montoFacturado)
                {
                    diferencia = acumulado() - montoFacturado;
                }
                spanAcreditar.InnerHtml = montoFacturado.ToString();
                spanBilletera.InnerHtml = diferencia.ToString();


                txtMontoVal.Focus();
                if (saldo <= 0)
                {
                    btnAcentarPago.Visible = true;
                    hPagoCuenta.Value = 0.ToString();
                }
                else
                {
                    hPagoCuenta.Value = 1.ToString();
                    btnAcentarPago.Visible = true;
                    //btnAcentarPago.Visible = false;
                }
                DDLMedioPago.SelectedIndex = 0;
                DDLMedioPago_SelectedIndexChanged(null, null);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CORREGIDO
        private void fillGrilla(List<DAL.PAGOS_X_FACTURA_GASTOS> lst)
        {
            gvValores.DataSource = lst;
            gvValores.DataBind();
        }
        //CORREGIDO
        protected void gvValores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var culturaArgentina = CultureInfo.GetCultureInfo("es-AR");
            if (e.CommandName == "eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                List<DAL.PAGOS_X_FACTURA_GASTOS> lst = leerGrilla();
                DAL.PAGOS_X_FACTURA_GASTOS obj = lst[index];
                lst.RemoveAt(index);
                fillGrilla(lst);
                lbtnAddValor.Visible = true;

                btnAcentarPago.Visible = false;

                txtMontoVal.Text = (Convert.ToDecimal(
                    lblDeudaPagar.Text.Replace(".", ","),
                culturaArgentina) - acumulado()).ToString();

                spanSaldo.InnerHtml = acumulado().ToString();
                txtMontoVal.Focus();
                DDLMedioPago.SelectedIndex = 0;
                DDLMedioPago_SelectedIndexChanged(null, null);

                decimal montoFacturado = Convert.ToDecimal(
                    lblDeudaPagar.Text.Replace(".", ","),
                culturaArgentina);

                decimal montoValor = Convert.ToDecimal(
                    txtMontoVal.Text.Replace(".", ","),
                culturaArgentina);

                if (acumulado() + montoValor > montoFacturado)
                {
                    txtMontoVal.Focus();
                    divBilletera.Visible = true;
                    //return;
                }
                else
                {
                    txtMontoVal.Focus();
                    divBilletera.Visible = false;
                }

                decimal diferencia = 0;
                if (acumulado() > montoFacturado)
                {
                    diferencia = acumulado() - montoFacturado;
                }
                spanAcreditar.InnerHtml = montoFacturado.ToString();
                spanBilletera.InnerHtml = diferencia.ToString();
                if (obj.ID_PLAN_PAGO == 7)
                {
                    chkSelect.Checked = false;
                    txtMontoBilleteraEditable.Text = hMontoOriginalBilletera.Value;
                }
            }
        }
        //CORREGIDO
        protected void DDLMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDLMedioPago.SelectedIndex == 1)
                    divCheque.Visible = true;
                else
                    divCheque.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CORREGIDO
        protected void btnSalir_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(string.Format(
                    "CtasCtesGastos.aspx?ID={0}", hNroCta.Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CORREGIDO
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.CTACTE_GASTOS obj = DAL.CTACTE_GASTOS.getByPk(
                    int.Parse(hIdCta.Value));


                List<DAL.CTACTE_GASTOS> lst = new List<DAL.CTACTE_GASTOS>();

                for (int i = 0; i < gvCtaCte.Rows.Count; i++)
                {
                    GridViewRow row = gvCtaCte.Rows[i];
                    obj = DAL.CTACTE_GASTOS.getByPk(int.Parse(row.Cells[0].Text));
                    DateTime fecha = Convert.ToDateTime(txtFechaCobro.Text);

                    obj = DAL.CTACTE_GASTOS.getByPk(int.Parse(row.Cells[0].Text));
                    lst.Add(obj);
                }
                gvCtaCte.DataSource = lst;
                gvCtaCte.DataBind();

                //fillDeuda(lst);
                txtObs.Text = string.Empty;
                txtAjusteInteres.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //CORREGIDO
        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSelect.Checked)
                {
                    addValorBilletera();
                    txtMontoBilleteraEditable.Enabled = true;
                }
                else
                {
                    removeValorBilletera();
                    txtMontoBilleteraEditable.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                txtError.InnerHtml = ex.Message;
                divError.Visible = true;
            }
        }
        //CORREGIDO
        protected void txtMontoBilleteraEditable_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var culturaArgentina = CultureInfo.GetCultureInfo("es-AR");
                decimal monto = 0;// Convert.ToDecimal(txtMontoBilleteraEditable.Text);
                decimal maximo = Convert.ToDecimal(
                    hMontoOriginalBilletera.Value.Replace(".", ","),
                culturaArgentina);

                monto = Convert.ToDecimal(
                    txtMontoBilleteraEditable.Text.Replace(".", ","),
                culturaArgentina);
                //MONTO A PAGAR CON EL MEDIO DE PAGO

                maximo = Convert.ToDecimal(
                    hMontoOriginalBilletera.Value.Replace(".", ","),
                culturaArgentina);
               
                if (monto > maximo)
                {
                    divErrorBilletera.Visible = true;
                    lblMsgErrorBilletera.InnerHtml = string.Format("El monto ingresado es mayor al monto disponible para utilizar ({0:c})",
                        hMontoOriginalBilletera.Value);
                    txtMontoBilleteraEditable.Text = maximo.ToString();
                }
                else
                {
                    removeValorBilletera();
                    txtMontoBilleteraEditable.Text = monto.ToString();
                    addValorBilletera();
                    chkSelect.Enabled = true;
                    txtMontoBilleteraEditable.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                txtError.InnerHtml = ex.Message;
                divError.Visible = true;
            }
        }
        //CORREGIDO
        protected void btnAceptarDescuento_Click(object sender, EventArgs e)
        {
            try
            {
                var culturaArgentina = CultureInfo.GetCultureInfo("es-AR");
                decimal descuento = Convert.ToDecimal(
                    txtAplicaDescuento.Text.Replace(".", ","),
                culturaArgentina);
                DAL.CTACTE_GASTOS obj =
                    DAL.CTACTE_GASTOS.getByPk(int.Parse(hIdCta.Value));
                //obj.DESC_VENCIMIENTO = descuento;
                obj.DEBE = obj.MONTO_ORIGINAL - Convert.ToDecimal(
                    txtAplicaDescuento.Text.Replace(".", ","),
                culturaArgentina);
                obj.SALDO = obj.MONTO_ORIGINAL - Convert.ToDecimal(
                    txtAplicaDescuento.Text.Replace(".", ","),
                culturaArgentina);
                obj.SALDO_CAPITAL = obj.MONTO_ORIGINAL - Convert.ToDecimal(
                    txtAplicaDescuento.Text.Replace(".", ","),
                culturaArgentina);
                obj.SALDO_INTERES = 0;
                obj.DESCUENTO = Convert.ToDecimal(
                    txtAplicaDescuento.Text.Replace(".", ","),
                culturaArgentina);
                obj.OBS = txtObservaciones.Text;
                obj.INTERES_MORA = 0;
                DAL.CTACTE_GASTOS.setDescuento(obj);
                List<DAL.CTACTE_GASTOS> lst = new List<DAL.CTACTE_GASTOS>();

                for (int i = 0; i < gvCtaCte.Rows.Count; i++)
                {
                    GridViewRow row = gvCtaCte.Rows[i];
                    obj = DAL.CTACTE_GASTOS.getByPk(int.Parse(row.Cells[0].Text));
                    DateTime fecha = Convert.ToDateTime(txtFechaCobro.Text);

                    obj = DAL.CTACTE_GASTOS.getByPk(int.Parse(row.Cells[0].Text));
                    lst.Add(obj);
                }
                gvCtaCte.DataSource = lst;
                gvCtaCte.DataBind();

                fillDeuda(lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}