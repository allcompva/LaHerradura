using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Secure
{
    public partial class PlanesPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["nroPlan"] == null)
                {
                    fill();
                }
                else
                {
                    fillPlan(Convert.ToInt32(Request.QueryString["nroPlan"]));
                }
            }

        }
        private void fill()
        {
            if (Request.QueryString["monto"] == null)
                return;
            if (Request.QueryString["tasa"] == null)
                return;
            if (Request.QueryString["cuotas"] == null)
                return;
            if (Request.QueryString["fecha"] == null)
                return;
            if (Request.QueryString["sistema"] == null)
                return;
            if (Request.QueryString["nroCta"] == null)
                return;

            int sistema = Convert.ToInt32(Request.QueryString["sistema"]);
            decimal monto = Convert.ToDecimal(Request.QueryString["monto"]);
            decimal tasa = Convert.ToDecimal(Request.QueryString["tasa"]);
            int cuotas = Convert.ToInt32(Request.QueryString["cuotas"]);
            DateTime fecha = Convert.ToDateTime(Request.QueryString["fecha"]);
            int nroCta = Convert.ToInt32(Request.QueryString["nroCta"]);

            List<int> lstIdCta =
                JsonConvert.DeserializeObject<List<int>>(
                    Request.QueryString["lst"]);

            List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();
            DAL.CTACTE_EXPENSAS obj;
            foreach (var item in lstIdCta)
            {
                obj = DAL.CTACTE_EXPENSAS.getByPk(item);
                obj.FECHA = Utils.Utils.getFechaActual();
                lst.Add(obj);
            }

            gvExpensas.DataSource = lst;
            gvExpensas.DataBind();
            lblCantCuotas.InnerHtml = cuotas.ToString();
            lblMontoOriginal.InnerHtml = string.Format("{0:c}", monto);
            lblTNA.InnerHtml = string.Format("{0:p}", tasa / 100);

            if (sistema == 1)
            {
                List<BLL.AMORTIZACION> lstTblAmortizacion =
                    BLL.AMORTIZACION.Calculo_frances(
                    monto, tasa, cuotas, fecha);
                lblTotal.InnerHtml = string.Format("{0:c}",
                    lstTblAmortizacion.Sum(z => z.MONTO_CUOTA));
                lblSistAmortizacion.InnerHtml = "Frances";
                gvTablaAmortizacion.DataSource = lstTblAmortizacion;
                gvTablaAmortizacion.DataBind();
            }
            if (sistema == 2)
            {
                List<BLL.AMORTIZACION> lstTblAmortizacion =
                    BLL.AMORTIZACION.Calculo_directo(
                    monto, tasa, cuotas, fecha);
                lblTotal.InnerHtml = string.Format("{0:c}",
                    lstTblAmortizacion.Sum(z => z.MONTO_CUOTA));
                lblSistAmortizacion.InnerHtml = "Directo";
                gvTablaAmortizacion.DataSource = lstTblAmortizacion;
                gvTablaAmortizacion.DataBind();
            }

            List<DAL.PERSONAS_GRILLA> lstP = new List<DAL.PERSONAS_GRILLA>();
            lstP = DAL.PERSONAS_GRILLA.getByNroCta(nroCta);
            List<DAL.PERSONAS_GRILLA> lstProp = lstP.FindAll(p => p.RELACION == "Propietario");
            List<DAL.PERSONAS_GRILLA> lstInq = lstP.FindAll(p => p.RELACION == "Inquilino");

            string pro = "Propietario/s: ";

            foreach (var item in lstProp)
            {
                pro += string.Format("{0} ", item.NOMBRE);
            }
            if (lstInq.Count > 0)
            {
                pro += " - Inquilinos: ";
                foreach (var item in lstInq)
                {
                    pro += string.Format("{0} ", item.NOMBRE);
                }
            }
            lblCuenta.InnerHtml = string.Format(
                "Plan de Pago Cuenta Nro: {0} ({1})", nroCta, pro);
        }

        private void fillPlan(int nroPlan)
        {
            try
            {
                DAL.PLANES_PAGO objPlan = DAL.PLANES_PAGO.getByPk(nroPlan);
                List<DAL.CTACTE_EXPENSAS> lstPeriodosIncluidos =
                    DAL.CTACTE_EXPENSAS.readCtasPlan(nroPlan, 1);

                lstPeriodosIncluidos.AddRange(
                    DAL.CTACTE_EXPENSAS.readCtasPlan(nroPlan, 100));

                List<DAL.CTACTE_EXPENSAS> lstCuotas = DAL.CTACTE_EXPENSAS.readCtasPlan(nroPlan, 3);

                gvExpensas.DataSource = lstPeriodosIncluidos;
                gvExpensas.DataBind();
                txtTotalOriginal.Text = string.Format("Total:     {0:c}",
                    lstPeriodosIncluidos.Sum(l => l.SALDO));
                lblCantCuotas.InnerHtml = objPlan.CANT_CUOTAS.ToString();
                lblMontoOriginal.InnerHtml = string.Format("{0:c}", objPlan.MONTO_A_FINANCIAR);
                lblTNA.InnerHtml = string.Format("{0:p}", objPlan.TNA / 100);
                lblTotal.InnerHtml = string.Format("{0:c}", objPlan.SALDO);
                lblSistAmortizacion.InnerHtml = objPlan.SIST_AMORTIZACION;
                List<DAL.PERSONAS_GRILLA> lstP = new List<DAL.PERSONAS_GRILLA>();
                lstP = DAL.PERSONAS_GRILLA.getByNroCta(lstPeriodosIncluidos[0].NRO_CTA);
                List<DAL.PERSONAS_GRILLA> lstProp = lstP.FindAll(p => p.RELACION == "Propietario");
                List<DAL.PERSONAS_GRILLA> lstInq = lstP.FindAll(p => p.RELACION == "Inquilino");

                string pro = "Propietario/s: ";

                foreach (var item in lstProp)
                {
                    pro += string.Format("{0} ", item.NOMBRE);
                }
                if (lstInq.Count > 0)
                {
                    pro += " - Inquilinos: ";
                    foreach (var item in lstInq)
                    {
                        pro += string.Format("{0} ", item.NOMBRE);
                    }
                }
                lblCuenta.InnerHtml = string.Format(
                    "Plan de Pago Cuenta Nro: {0} ({1})", lstPeriodosIncluidos[0].NRO_CTA, pro);

                List<BLL.AMORTIZACION> lstTblAmortizacion = new List<BLL.AMORTIZACION>();

                BLL.AMORTIZACION objAmortizacion = new BLL.AMORTIZACION();

                //if (objPlan.SIST_AMORTIZACION == "FRANCES")
                //{
                lstTblAmortizacion = new List<BLL.AMORTIZACION>();
                List<DAL.CTACTE_EXPENSAS> lst = DAL.CTACTE_EXPENSAS.readPlan(nroPlan);
                foreach (var item in lst)
                {
                    BLL.AMORTIZACION obj = new BLL.AMORTIZACION();
                    obj.MONTO_CUOTA = item.MONTO_ORIGINAL;
                    obj.NRO_CUOTA = item.NRO_CUOTA;
                    obj.VENCIMIENTO = item.VENCIMIENTO;
                    lstTblAmortizacion.Add(obj);
                }


                gvTablaAmortizacion2.DataSource = lstTblAmortizacion;
                gvTablaAmortizacion2.DataBind();
                btnAceptar.Visible = false;
                //}
                btnAceptar.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int sistema = Convert.ToInt32(Request.QueryString["sistema"]);
                decimal monto = Convert.ToDecimal(Request.QueryString["monto"]);
                decimal tasa = Convert.ToDecimal(Request.QueryString["tasa"]);
                int cuotas = Convert.ToInt32(Request.QueryString["cuotas"]);
                DateTime fecha = Convert.ToDateTime(Request.QueryString["fecha"]);
                int nroCta = Convert.ToInt32(Request.QueryString["nroCta"]);
                decimal total = decimal.Parse(lblTotal.InnerHtml.Replace("$", ""));

                DAL.PLANES_PAGO obj = new DAL.PLANES_PAGO();
                obj.CANT_CUOTAS = cuotas;
                obj.ESTADO = 0;
                obj.FECHA_INICIO = Utils.Utils.getFechaActual();
                obj.FECHA_PRIMERA_CUOTA = fecha;
                obj.INTERES = total - monto;
                obj.MONTO_A_FINANCIAR = monto;
                obj.NRO_CTA = nroCta;
                obj.SALDO = total;
                decimal montoCuota = 0;
                if (sistema == 1)
                {
                    obj.SIST_AMORTIZACION = "FRANCES";
                    List<BLL.AMORTIZACION> lstTblAmortizacion =
    BLL.AMORTIZACION.Calculo_frances(
    monto, tasa, cuotas, fecha);
                    montoCuota = lstTblAmortizacion[0].MONTO_CUOTA;
                }
                else
                {
                    List<BLL.AMORTIZACION> lstTblAmortizacion =
    BLL.AMORTIZACION.Calculo_directo(
    monto, tasa, cuotas, fecha);
                    montoCuota = lstTblAmortizacion[0].MONTO_CUOTA;
                    obj.SIST_AMORTIZACION = "DIRECTO";
                }
                obj.TNA = tasa;
                obj.USUARIO_CREA = 1;
                BLL.PLANES_PAGO.insert(obj, montoCuota, leerGrilla(),
                    Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                Response.Redirect(string.Format("../Back/inmueble.aspx?nrocta={0}",
                    nroCta));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<int> leerGrilla()
        {
            List<int> lst = new List<int>();
            int id = 0;
            for (int i = 0; i < gvExpensas.Rows.Count; i++)
            {
                GridViewRow row = gvExpensas.Rows[i];
                id = int.Parse(gvExpensas.DataKeys[i].Values["ID"].ToString());
                lst.Add(id);
            }
            return lst;
        }
        decimal subtotal = 0;
        protected void gvExpensas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                //if ((e.Row.RowType == DataControlRowType.DataRow) && (e.Row.RowType != DataControlRowType.EmptyDataRow))
                //{
                //    subtotal += Convert.ToInt32(e.Row.Cells[1].Text);
                //}
                //if (e.Row.RowType == DataControlRowType.Footer)
                //{
                //    e.Row.Cells[0].Text = "Totales";

                //    e.Row.Cells[1].Text = Convert.ToString(subtotal);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvTablaAmortizacion2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if ((e.Row.RowType == DataControlRowType.DataRow) && (e.Row.RowType != DataControlRowType.EmptyDataRow))
                {
                    var culturaArgentina = CultureInfo.GetCultureInfo("es-AR");
                    decimal numero = Convert.ToDecimal(
                        e.Row.Cells[1].Text.Replace(".", ","),
                        culturaArgentina);
                    subtotal += numero;
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[0].Text = "Total";

                    e.Row.Cells[1].Text = string.Format("{0:c}", subtotal);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnRecalculo_Click(object sender, EventArgs e)
        {
            try
            {
                List<int> lstIdCta =
                    JsonConvert.DeserializeObject<List<int>>(
                        Request.QueryString["lst"]);

                List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();
                DAL.CTACTE_EXPENSAS obj;
                foreach (var item in lstIdCta)
                {
                    obj = DAL.CTACTE_EXPENSAS.getByPk(item);
                    obj.FECHA = Utils.Utils.getFechaActual();
                    lst.Add(obj);
                }
                List<DAL.CTACTE_EXPENSAS> lst2 =
                    new List<DAL.CTACTE_EXPENSAS>();

                DateTime fechaRecalculo = Convert.ToDateTime(
                    txtFechaRecalculo.Text);
                foreach (var item in lst)
                {
                    obj = item;


                    if (obj.TIPO_MOVIMIENTO == 1)
                        DAL.CTACTE_EXPENSAS.recalculo(fechaRecalculo,
                            obj.PERIODO, obj.NRO_CTA, obj.ID);
                    if (obj.TIPO_MOVIMIENTO == 3)
                        DAL.CTACTE_EXPENSAS.recalculoPlan(fechaRecalculo, obj.PERIODO, obj.NRO_CTA, obj.ID, obj.NRO_PLAN_PAGO);
                    obj = DAL.CTACTE_EXPENSAS.getByPk(item.ID);
                    lst2.Add(obj);
                }

                int sistema = Convert.ToInt32(Request.QueryString["sistema"]);
                decimal monto = lst2.Sum(l => l.SALDO);
                decimal tasa = Convert.ToDecimal(Request.QueryString["tasa"]);
                int cuotas = Convert.ToInt32(Request.QueryString["cuotas"]);
                DateTime fecha = Convert.ToDateTime(txtFechaRecalculo.Text);
                int nroCta = Convert.ToInt32(Request.QueryString["nroCta"]);

                lstIdCta = new List<int>();
                foreach (var item in lst2)
                {
                    lstIdCta.Add(item.ID);
                }
                string js = JsonConvert.SerializeObject(lstIdCta);
                Response.Redirect(string.Format(
                    "../Secure/PlanesPago.aspx?monto={0}&tasa={1}&cuotas={2}&fecha={3}&sistema={4}&nroCta={5}&lst={6}",
                    monto, tasa, cuotas, fechaRecalculo, sistema, nroCta, js));


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}