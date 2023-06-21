using mailinblue;
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
    public partial class Notificacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {

                    List<DAL.PAGOS_PAYPERTIC> lstHuerfanos = DAL.PAGOS_PAYPERTIC.getHuerfanos();
                    foreach (var item2 in lstHuerfanos)
                    {
                        PayPerTic.Notificaciones.Noti noti =
                        PayPerTic.SolicitudPago.SolicitudPago.CosultaPago(
                            item2.HASH_TRANSACCION);


                        if (noti.status == "approved")
                        {
                            try
                            {

                                List<DAL.CTACTE_EXPENSAS> lst =
                                    DAL.CTACTE_EXPENSAS.getByPayPerTic(item2.ID);

                                List<DAL.CTACTE_EXPENSAS> lstAsiento = new List<DAL.CTACTE_EXPENSAS>();

                                DAL.CTACTE_EXPENSAS objExpensa;
                                foreach (var item in lst)
                                {
                                    objExpensa = item;
                                    objExpensa.ID_MEDIO_PAGO = 8;
                                    objExpensa.FECHA = Convert.ToDateTime(
                                        Utils.Utils.getFechaActual());
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
                                objPago.MONTO = Convert.ToDecimal(lst.Sum(d => d.SALDO));
                                lstPagos.Add(objPago);

                                if (lstAsiento.Count > 0)
                                {
                                    CTA_CTE.asientaPago(lstAsiento,
                                        lstPagos, Convert.ToDateTime(Utils.Utils.getFechaActual()), string.Empty);
                                }
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
                                DAL.PAGOS_PAYPERTIC objPay = DAL.PAGOS_PAYPERTIC.getByPk(int.Parse(
        noti.external_transaction_id));

                                objPay.ESTADO = noti.status;

                                DAL.PAGOS_PAYPERTIC.setPago(objPay);
                                //envioMailRechazo(objPago, noti.external_transaction_id);
                            }
                        }
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
        //if (!IsPostBack)
        //{
        //    try
        //    {
        //        List<DAL.PAGOS_PAYPERTIC> lst = DAL.PAGOS_PAYPERTIC.read();
        //        foreach (var item in lst)
        //        {
        //            if (item.ESTADO == string.Empty)
        //            {
        //                PayPerTic.Notificaciones.Noti noti =
        //                    PayPerTic.SolicitudPago.SolicitudPago.CosultaPago(item.HASH_TRANSACCION);

        //                if (noti.external_transaction_id != null)
        //                {
        //                    DAL.PAGOS_PAYPERTIC objPay = DAL.PAGOS_PAYPERTIC.getByPk(int.Parse(
        //                        noti.external_transaction_id));

        //                    objPay.ESTADO = noti.status;
        //                    if (noti.status == "approved")
        //                    {
        //                        objPay.ULTIMOS_4 = int.Parse(
        //                            noti.payment_methods[0].last_four_digits);
        //                        objPay.FECHA_ACREDITACION = noti.accreditation_date;
        //                        objPay.PRIMEROS_6 = int.Parse(
        //                            noti.payment_methods[0].first_six_digits);
        //                        objPay.DESC_TARJETA = noti.payment_methods[0].media_payment_detail;
        //                        objPay.COD_TARJETA = noti.payment_methods[0].payment_method_id;
        //                    }
        //                    DAL.PAGOS_PAYPERTIC.setPago(objPay);
        //                }
        //            }
        //        }



        //        //if (Request.QueryString["id"] != null)
        //        //{
        //        //    List<DAL.CTACTE_EXPENSAS> lst = DAL.CTACTE_EXPENSAS.getByPayPerTic(
        //        //        int.Parse(Request.QueryString["id"].ToString()));

        //        //    List<DAL.CTACTE_EXPENSAS> lstAsiento = new List<DAL.CTACTE_EXPENSAS>();

        //        //    DAL.CTACTE_EXPENSAS objExpensa;
        //        //    foreach (var item in lst)
        //        //    {
        //        //        objExpensa = item;
        //        //        objExpensa.ID_MEDIO_PAGO = 8;
        //        //        objExpensa.FECHA = Convert.ToDateTime(
        //        //            );
        //        //        objExpensa.ID_USUARIO_PAGA = 0;

        //        //        objExpensa.PAGO_TOTAL = true;
        //        //        objExpensa.MONTO_PAGADO =
        //        //            Convert.ToDecimal(item.SALDO - item.DESC_VENCIMIENTO);
        //        //        lstAsiento.Add(objExpensa);

        //        //    }

        //        //    List<DAL.PAGOS_X_FACTURA> lstPagos = new List<DAL.PAGOS_X_FACTURA>();

        //        //    DAL.PAGOS_X_FACTURA objPago = new DAL.PAGOS_X_FACTURA();
        //        //    objPago.MEDIO_PAGO = "PAGO EN LINEA";
        //        //    objPago.ID_PLAN_PAGO = 8;
        //        //    objPago.MONTO = Convert.ToDecimal(lst.Sum(d => d.SALDO) -
        //        //        lst.Sum(c => c.SALDO - c.DESC_VENCIMIENTO));
        //        //    lstPagos.Add(objPago);

        //        //    CTA_CTE.asientaPago(lstAsiento,
        //        //        lstPagos, Convert.ToDateTime());
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        //Response.Clear();
        //        //Response.ContentType = "application/json";
        //        //Response.Status = "500 Error";
        //        //Response.StatusCode = 500;
        //        //Response.StatusDescription = ex.Message;
        //        //Response.End();
        //    }

        //}
    }
}
