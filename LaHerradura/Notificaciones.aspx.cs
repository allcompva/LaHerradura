﻿using mailinblue;
using Newtonsoft.Json;
using PayPerTic.Notificaciones;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace LaHerradura
{
    public partial class Notificaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                    var stream = new StreamReader(HttpContext.Current.Request.InputStream);
                    stream.BaseStream.Seek(0, SeekOrigin.Begin);
                    var miCadena = stream.ReadToEnd();

                    DAL.PRUEBA objPrueba = new DAL.PRUEBA();
                    objPrueba.descripcion = miCadena;
                    int idPrueba = DAL.PRUEBA.insert(objPrueba);
                    objPrueba.codigo = idPrueba;
                    dynamic objeto = JsonConvert.DeserializeObject(miCadena);
                    string id = objeto.id;
                    string status = objeto.status;

                    if (miCadena.Length > 10)
                    {

                        PayPerTic.Notificaciones.Noti noti =
                            PayPerTic.SolicitudPago.SolicitudPago.CosultaPago(id);

                        if (noti.status == "approved")
                        {
                            try
                            {
                                List<DAL.CTACTE_EXPENSAS> lst =
                                    DAL.CTACTE_EXPENSAS.getByPayPerTic(
    int.Parse(noti.external_transaction_id));

                                List<DAL.CTACTE_EXPENSAS> lstAsiento = new List<DAL.CTACTE_EXPENSAS>();

                                DAL.CTACTE_EXPENSAS objExpensa;
                                foreach (var item in lst)
                                {
                                    objExpensa = item;
                                    objExpensa.ID_MEDIO_PAGO = 8;
                                    objExpensa.FECHA = Convert.ToDateTime(
                                        LaHerradura.Utils.Utils.getFechaActual());
                                    objExpensa.ID_USUARIO_PAGA = 0;

                                    objExpensa.PAGO_TOTAL = true;
                                    objExpensa.MONTO_PAGADO =
                                        Convert.ToDecimal(item.SALDO - item.DESC_VENCIMIENTO);
                                    lstAsiento.Add(objExpensa);

                                }

                                List<DAL.PAGOS_X_FACTURA> lstPagos = new List<DAL.PAGOS_X_FACTURA>();

                                DAL.PAGOS_X_FACTURA objPago = new DAL.PAGOS_X_FACTURA();
                                objPago.MEDIO_PAGO = "PAGO EN LINEA";
                                objPago.ID_PLAN_PAGO = 8;
                                objPago.MONTO = Convert.ToDecimal(
                                    lst.Sum(d => d.SALDO) - lst.Sum(f => f.DESC_VENCIMIENTO));
                                lstPagos.Add(objPago);

                                CTA_CTE.asientaPago(lstAsiento,
                                    lstPagos, Convert.ToDateTime(LaHerradura.Utils.Utils.getFechaActual()), string.Empty);

                                DAL.PAGOS_PAYPERTIC objPay = DAL.PAGOS_PAYPERTIC.getByPk(int.Parse(
                                    noti.external_transaction_id));

                                objPay.ESTADO = noti.status;
                                objPay.ULTIMOS_4 = int.Parse(
                                    noti.payment_methods[0].last_four_digits);
                                objPay.FECHA_ACREDITACION = noti.accreditation_date;
                                objPay.PRIMEROS_6 = int.Parse(
                                    noti.payment_methods[0].first_six_digits);
                                objPay.DESC_TARJETA = noti.payment_methods[0].media_payment_detail;
                                objPay.COD_TARJETA = noti.payment_methods[0].payment_method_id;

                                DAL.PAGOS_PAYPERTIC.setPago(objPay);
                            }
                            catch (Exception ex)
                            {

                                throw;
                            }

                        }
                        else
                        {
                            if (noti.status != "pending")
                            {

                                //envioMailRechazo(objPago, noti.external_transaction_id);
                            }
                        }


                        Response.Clear();
                        Response.ContentType = "application/json";
                        Response.Status = "200 Ok";
                        Response.StatusCode = 200;
                        Response.StatusDescription = "OK";
                        Response.End();

                    }
                    else
                    {
                        Response.Clear();
                        Response.ContentType = "application/json";
                        Response.Status = "500 Error";
                        Response.StatusCode = 500;
                        Response.StatusDescription = "Error";
                        Response.End();
                    }
                }
                catch (Exception ex)
                {
                    //Response.Clear();
                    //Response.ContentType = "application/json";
                    //Response.Status = "500 Error";
                    //Response.StatusCode = 500;
                    //Response.StatusDescription = ex.Message;
                    //Response.End();
                }

            }
        }

        //private void AsientoPago()
        //{
        //    try
        //    {
        //        List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();
        //        DAL.CTACTE_EXPENSAS obj;
        //        List<DAL.PAGOS_X_FACTURA> lstPagos = leerGrilla();
        //        decimal TotalPagado = lstPagos.Sum(p => p.MONTO);

        //        for (int i = 0; i < gvConfirmoPago.Rows.Count; i++)
        //        {
        //            GridViewRow row = gvConfirmoPago.Rows[i];
        //            int id = int.Parse(row.Cells[0].Text);
        //            obj = DAL.CTACTE_EXPENSAS.getByPk(id);
        //            obj.ID_MEDIO_PAGO = lstPagos[0].ID_PLAN_PAGO;
        //            obj.FECHA = Convert.ToDateTime(txtFechaCobro.Text);
        //            obj.ID_USUARIO_PAGA = int.Parse(hUsuario.Value);
        //            if (obj.SALDO - obj.DESC_VENCIMIENTO <= TotalPagado)
        //            {
        //                TotalPagado = TotalPagado - obj.SALDO - obj.DESC_VENCIMIENTO;
        //                obj.PAGO_TOTAL = true;
        //                obj.MONTO_PAGADO = obj.SALDO - obj.DESC_VENCIMIENTO;
        //                lst.Add(obj);
        //            }
        //            else
        //            {
        //                obj.PAGO_TOTAL = false;
        //                obj.MONTO_PAGADO = TotalPagado;
        //                lst.Add(obj);
        //                break;
        //            }
        //        }
        //        lst = lst.OrderBy(p => p.PERIODO).ToList();
        //        decimal totalPago1 = lstPagos.Sum(s => s.MONTO);
        //        decimal totalPago2 = lst.Sum(c => c.MONTO_PAGADO);
        //        decimal control = totalPago1 - totalPago2;
        //        CTA_CTE.asientaPago(lst,
        //            lstPagos, Convert.ToDateTime(txtFechaCobro.Text));
        //        Response.Redirect(string.Format("inmueble.aspx?nrocta={0}", Request.QueryString["nrocta"]));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static void envioMailRechazo(DAL.Pagos obj, string nroCedulon)
        //{
        //    StringBuilder stringBuilder = new StringBuilder();
        //    stringBuilder.AppendLine("<!DOCTYPE html>");
        //    stringBuilder.AppendLine("<html>");
        //    stringBuilder.AppendLine("<head>");
        //    stringBuilder.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
        //    stringBuilder.AppendLine("<title></title>");
        //    stringBuilder.AppendLine("<style>body {background-color: #ffffff;padding: 0;margin: 0}</style>");
        //    stringBuilder.AppendLine("</head>");
        //    stringBuilder.AppendLine("<body>");
        //    stringBuilder.AppendLine("<table width=\"560\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"");
        //    stringBuilder.AppendLine("style=\"margin:0 auto 0; padding-top: 30px;width:560px\">");
        //    stringBuilder.AppendLine("<tbody>");
        //    stringBuilder.AppendLine("<tr>");
        //    stringBuilder.AppendLine("<td>");
        //    stringBuilder.AppendLine("<div style=\"display:block;margin:10px auto; width:100%\">");
        //    stringBuilder.AppendLine("<div style=\"display:block;\"><img style=\"display:block;\" ");
        //    stringBuilder.AppendLine("src=\"http://vecino.villaallende.gov.ar/img/cedulon.png\" alt =\"\">");
        //    stringBuilder.AppendLine("</div>");
        //    stringBuilder.AppendLine("<div style=\"display:block;float: left;width: 100%;\">");
        //    stringBuilder.AppendLine("<div style=\"display:block; float:left\"></div>");
        //    stringBuilder.AppendLine("<div style=\"display:block; float:right;font-family:Arial; float:right; font-size:11px;");
        //    stringBuilder.AppendFormat("color:#333333; text-align:right;padding-right: 33px; line-height:27px\">{0}", (object).ToShortDateString());
        //    stringBuilder.AppendLine("</div>");
        //    stringBuilder.AppendLine("</div>");
        //    stringBuilder.AppendLine("<div style=\"display:block; padding:20px;\">");
        //    stringBuilder.AppendLine("<div style=\"padding:15px 30px; display:block; font-family:Arial; font-size:12px;");
        //    stringBuilder.AppendLine("color:#333333; text-align:justify; min:height:300px; padding:20px;\">");

        //    stringBuilder.AppendLine("<h2 style=\"font-size:18px; font-family:verdana;\">Vecino Digital - Error en el proceso de pago</h2>");
        //    stringBuilder.AppendFormat(
        //        "<p>Estimado {0}, {1}, detectamos que no se ha podido procesar el pago que intento en <a href=\"vecino.villaallende.gov.ar\">vecino.villaallende.gov.ar.</a></p><br>", (object)obj.APELLIDO, (object)obj.NOMBRE);

        //    stringBuilder.AppendLine("<p>Si ha presentado algún inconveniente, le recordamos que de Lunes a Viernes de 9 a 18 Hs. Un operador se encuentra disponible para brindarle asistencia de ser necesaria.</p>");
        //    stringBuilder.AppendLine("<p>También es posible abonar mediante la aplicación de Mercado Pago, escaneando el Código de barras de entes recaudadores.</p>");
        //    stringBuilder.AppendLine("<p>Si lo requiere, podemos realizar el cobro mediante transferencia bancaría, pídale al Operador que le envié el instructivo.</p>");
        //    stringBuilder.AppendLine("<div style=\"text-align:center;\">");

        //    //stringBuilder.AppendFormat("<a href=\"https://servicios.paypertic.com/formularios/comprobantes/{0}\" target=\"_blank\"><img src=\"http://vecino.villaallende.gov.ar/img/ImprimirComprobante.png\"/></a>", (object)obj.HASH_TRANSACCION);

        //    stringBuilder.AppendLine("</div></div></div>");
        //    stringBuilder.AppendLine("<div style=\"display:block;\"><img style=\"display:block;width:100 %;\"");
        //    stringBuilder.AppendLine("src=\"http://vecino.villaallende.gov.ar/img/footer.jpg?v=1\" alt =\"\">");
        //    stringBuilder.AppendLine("</div></div></td></tr></tbody></table></body></html>");
        //    try
        //    {
        //        try
        //        {
        //            API api = new API("79LpGPhkUMDKbHqs");
        //            Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
        //            Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
        //            dictionary2.Add(obj.MAIL, obj.NOMBRE);
        //            List<string> stringList = new List<string>();
        //            stringList.Add("noresponder@villaallende.gov.ar");
        //            stringList.Add("Vecino Digital");
        //            dictionary1.Add("to", (object)dictionary2);
        //            dictionary1.Add("from", (object)stringList);
        //            dictionary1.Add("subject", "Vecino Digital - Error en el proceso de pago");
        //            dictionary1.Add("html", (object)stringBuilder.ToString());
        //            Dictionary<string, object> dictionary3 = dictionary1;
        //            api.send_email((object)dictionary3).ToString();
        //        }
        //        catch (SmtpException ex)
        //        {
        //            throw ex;
        //        }
        //    }
        //    catch (SmtpException ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}