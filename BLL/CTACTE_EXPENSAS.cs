using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class CTACTE_EXPENSAS
    {
        public static List<DAL.CTACTE_EXPENSAS> read(int periodo)
        {
            try
            {
                return DAL.CTACTE_EXPENSAS.read(periodo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void detalle()
        {
            try
            {

                List<DAL.INMUEBLES> lstTotalCtas = DAL.INMUEBLES.read();

                foreach (var item in lstTotalCtas)
                {

                    List<int> periodos = DAL.CTACTE_EXPENSAS.readPeriodos(item.NRO_CTA);
                    foreach (var item2 in periodos)
                    {
                        List<DAL.CTACTE_EXPENSAS> lstCta =
                            DAL.CTACTE_EXPENSAS.read(item2, item.NRO_CTA);
                        List<DAL.DETALLE_CTA> lst = new List<DAL.DETALLE_CTA>();

                        DAL.CTACTE_EXPENSAS objCtaDeuda = lstCta.Find(c => c.TIPO_MOVIMIENTO == 1);
                        List<DAL.CTACTE_EXPENSAS> lstCtaPagos =
                            lstCta.FindAll(c => c.TIPO_MOVIMIENTO == 2).OrderBy(l => l.FECHA).ToList();

                        for (int i = 0; i < lstCtaPagos.Count; i++)
                        {
                            if (i == 0)
                            {
                                decimal saldoCapital = 0;
                                decimal saldoInteres = 0;

                                decimal porcentaje = 0;
                                decimal capitalPagado = 0;
                                decimal interesPagado = 0;

                                porcentaje =
            lstCtaPagos[i].HABER / (objCtaDeuda.MONTO_ORIGINAL + lstCtaPagos[i].INTERES_MORA);
                                capitalPagado = objCtaDeuda.MONTO_ORIGINAL * porcentaje;
                                saldoCapital = objCtaDeuda.MONTO_ORIGINAL - capitalPagado - objCtaDeuda.DESC_VENCIMIENTO;
                                interesPagado = lstCtaPagos[i].INTERES_MORA * porcentaje;
                                saldoInteres = lstCtaPagos[i].INTERES_MORA - interesPagado;

                                DAL.CTACTE_EXPENSAS.setSALDOS(lstCtaPagos[i].ID, interesPagado,
                                    saldoInteres, capitalPagado, saldoCapital);
                            }
                            else
                            {
                                decimal saldoCapital = 0;
                                decimal saldoInteres = 0;

                                decimal porcentaje = 0;
                                decimal capitalPagado = 0;
                                decimal interesPagado = 0;

                                porcentaje =
            lstCtaPagos[i].HABER / (lstCtaPagos[i - 1].SALDO_CAPITAL + lstCtaPagos[i].INTERES_MORA);
                                capitalPagado = lstCtaPagos[i - 1].SALDO_CAPITAL * porcentaje;
                                saldoCapital = lstCtaPagos[i - 1].SALDO_CAPITAL - capitalPagado;
                                interesPagado = lstCtaPagos[i].INTERES_MORA * porcentaje;
                                saldoInteres = lstCtaPagos[i].INTERES_MORA - interesPagado;

                                DAL.CTACTE_EXPENSAS.setSALDOS(lstCtaPagos[i].ID, interesPagado,
                                    saldoInteres, capitalPagado, saldoCapital);
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string detalle(int nroCta, int periodo, int tipoMov,
            int rol)
        {
            try
            {
                StringBuilder html = new StringBuilder();
                html.AppendLine("");
                decimal debe = 0;
                decimal haber = 0;
                List<DAL.CTACTE_EXPENSAS> lstCta =
DAL.CTACTE_EXPENSAS.readDeudaCorregido(periodo, nroCta, tipoMov);
                List<DAL.DETALLE_CTA> lst = new List<DAL.DETALLE_CTA>();


                List<DAL.CTACTE_EXPENSAS> lstCtaDeuda =
                    lstCta.FindAll(c => (c.TIPO_MOVIMIENTO == 1 &&
                    c.NRO_PLAN_PAGO == 0) || c.TIPO_MOVIMIENTO == 3 ||
                    c.TIPO_MOVIMIENTO == 100 ||
                    c.TIPO_MOVIMIENTO == 21);

                //lstCtaDeuda =
                //    lstCta.FindAll(c => (c.TIPO_MOVIMIENTO == 1 && c.NRO_PLAN_PAGO == 0)); //|| c.TIPO_MOVIMIENTO == 3);

                //html.AppendLine(string.Format("",));

                foreach (var item in lstCtaDeuda)
                {
                    string det = string.Empty;
                    if (item.TIPO_MOVIMIENTO == 100)
                    {
                        DAL.FACTURAS_X_EXPENSA objFactu =
                            DAL.FACTURAS_X_EXPENSA.getByPk(item.PTO_VTA,
                            item.NRO_CTE, 11);
                        det = objFactu.DETALLE;
                    }
                    if (item.TIPO_MOVIMIENTO == 21)
                    {
                        List<DAL.DETALLE_DEUDA> objDet =
                            DAL.DETALLE_DEUDA.getByIdCta(item.ID);
                        if (objDet.Count > 0)
                            det = objDet[0].OBS;
                    }
                    if (item.PAGADO)
                    {
                        html.AppendLine("<div class=\"box box-success\">");
                        html.AppendLine("<div class=\"box-header\">");
                        if (item.NRO_PLAN_PAGO != 0)
                            html.AppendLine(string.Format("<h3 class=\"box-title\" style=\"width: 100%; color: #00a65a;\">{0}<span class=\"pull-right\">{1:c}</span>&nbsp;<a href=\"../Secure/PlanesPago.aspx?nroPlan={2}\"target=\"_blank\"><span class=\"fa fa-search\"></span></a></h3>",
                            Utiles.periodo(item.PERIODO, item.TIPO_MOVIMIENTO,
                            item.NRO_PLAN_PAGO, item.NRO_CUOTA, det, item.PTO_VTA, item.NRO_CTE), item.SALDO,
                            item.NRO_PLAN_PAGO));
                        else
                            html.AppendLine(string.Format("<h3 class=\"box-title\" style=\"width: 100%; color: #00a65a;\">{0}<span class=\"pull-right\">{1:c}</span></h3>",
                            Utiles.periodo(item.PERIODO, item.TIPO_MOVIMIENTO,
                            item.NRO_PLAN_PAGO, item.NRO_CUOTA, det, item.PTO_VTA, item.NRO_CTE), item.SALDO));
                        html.AppendLine("</div>");
                    }
                    else
                    {
                        html.AppendLine("<div class=\"box box-danger\">");
                        html.AppendLine("<div class=\"box-header\">");
                        if (item.NRO_PLAN_PAGO != 0)
                            html.AppendLine(string.Format("<h3 class=\"box-title\" style=\"width: 100%; color:#dd4b39;\">{0}<span class=\"pull-right\">{1:c}</span>&nbsp;<a href=\"../Secure/PlanesPago.aspx?nroPlan={2}\"target=\"_blank\"><span class=\"fa fa-search\"></span></a></h3>",
                            Utiles.periodo(item.PERIODO, item.TIPO_MOVIMIENTO,
                            item.NRO_PLAN_PAGO, item.NRO_CUOTA, det, item.PTO_VTA, item.NRO_CTE),
                            item.SALDO, item.NRO_PLAN_PAGO));
                        else
                            html.AppendLine(string.Format("<h3 class=\"box-title\" style=\"width: 100%; color:#dd4b39;\">{0}<span class=\"pull-right\">{1:c}</span></h3>",
                            Utiles.periodo(item.PERIODO, item.TIPO_MOVIMIENTO,
                            item.NRO_PLAN_PAGO, item.NRO_CUOTA, det, item.PTO_VTA, item.NRO_CTE), item.SALDO));

                        html.AppendLine("</div>");
                    }
                    html.AppendLine("<div class=\"box-body no-padding\">");

                    html.AppendLine("<table class=\"table table-striped\">");
                    html.AppendLine("<tbody><tr>");
                    html.AppendLine("<th>FECHA</th>");
                    html.AppendLine("<th>CONCEPTO</th>");
                    html.AppendLine("<th>DEBE</th>");
                    html.AppendLine("<th>HABER</th>");
                    html.AppendLine("<th>SALDO</th>");
                    html.AppendLine("<th></th>");
                    html.AppendLine("</tr>");

                    List<DAL.CTACTE_EXPENSAS> lstCtaPagos = new List<DAL.CTACTE_EXPENSAS>();

                    if (item.TIPO_MOVIMIENTO == 1 || item.TIPO_MOVIMIENTO == 100
                         || item.TIPO_MOVIMIENTO == 21)
                        lstCtaPagos =
                            lstCta.FindAll(c => c.TIPO_MOVIMIENTO == 2 &&
                            c.NRO_PLAN_PAGO == 0).OrderBy(
                                l => l.NRO_RECIBO_PAGO).ToList();
                    if (item.TIPO_MOVIMIENTO == 3)
                        lstCtaPagos =
                            lstCta.FindAll(c => c.TIPO_MOVIMIENTO == 2 &&
                            c.NRO_PLAN_PAGO != 0).OrderBy(
                                l => l.NRO_RECIBO_PAGO).ToList();

                    html.AppendLine("<tr>");
                    html.AppendLine(string.Format("<td>{0:d}</td>",
                        item.VENCIMIENTO));
                    if (item.TIPO_MOVIMIENTO != 21)
                        html.AppendLine(string.Format("<td>{0}</td>",
                            Utiles.periodo(item.PERIODO, item.TIPO_MOVIMIENTO,
                                item.NRO_PLAN_PAGO, item.NRO_CUOTA, det, item.PTO_VTA, item.NRO_CTE)));
                    else
                        html.AppendLine(string.Format("<td>{0}</td>", det));
                    html.AppendLine(string.Format("<td>{0:c}</td>",
                            item.MONTO_ORIGINAL));
                    html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                    html.AppendLine(string.Format("<td>{0:c}</td>",
                        item.MONTO_ORIGINAL));
                    html.AppendLine("<td><a target=\"_blank\"");
                    //CAMBIO CRYSTALREPORTS
                    //html.AppendLine(string.Format(
                    //    "href=\"Reportes/Print.aspx?op=factura&nrocta={0}&periodo={1}&idcta={2}\">",
                    //     item.NRO_CTA, item.PERIODO, item.ID));

                    switch (item.TIPO_MOVIMIENTO)
                    {
                        case 1:
                            html.AppendLine(string.Format(
                            "href=\"Reportes/Reports.aspx?&nrocta={0}&periodo={1}&idcta={2}\">",
                             item.NRO_CTA, item.PERIODO, item.ID));
                            break;
                        case 100:
                            html.AppendLine(string.Format(
                            "href=\"Reportes/Factura.aspx?&nrocta={0}&periodo={1}&idcta={2}\">",
                             item.NRO_CTA, item.PERIODO, item.ID));
                            break;
                        case 21:
                            html.AppendLine(string.Format(
                            "href=\"Reportes/Factura.aspx?&nrocta={0}&periodo={1}&idcta={2}\">",
                             item.NRO_CTA, item.PERIODO, item.ID));
                            break;
                        default:
                            break;


                    }


                    html.AppendLine("<span class=\"fa fa-download\"");
                    html.AppendLine("style =\"text-align: center; font-size: 14px;\">");
                    html.AppendLine("Factura expensa</span></a></td>");

                    debe += item.MONTO_ORIGINAL;
                    if (item.TIPO_MOVIMIENTO == 1 || item.TIPO_MOVIMIENTO == 100)
                    {
                        List<DAL.FACTURAS_X_EXPENSA> lstNC =
                            DAL.FACTURAS_X_EXPENSA.readNC(item.NRO_CTA,
                            item.PERIODO);
                        if (item.TIPO_MOVIMIENTO == 100)
                        {
                            html.AppendLine("<td><a href=\"#\"");
                            html.AppendLine(string.Format("onclick=\"abrirModalAddComprobante('{0}', '{1}')\">",
                                item.ID, item.MONTO_ORIGINAL));
                            html.AppendLine("<span class=\"fa fa-credit-card\"></span>NC");
                            html.AppendLine("</a></td>");
                        }
                            html.AppendLine("</tr>");
                        //NOTA DE CREDITO
                        if (lstNC != null)
                        {
                            if (lstNC.Count > 0)
                            {
                                foreach (var itemNC in lstNC)
                                {


                                    html.AppendLine("<tr>");
                                    html.AppendLine(string.Format("<td>{0:d}</td>",
                                        itemNC.FECHA_CAE));
                                    html.AppendLine("<td>Nota de Credito</td>");
                                    html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                                    html.AppendLine(string.Format("<td>{0:c}</td>", itemNC.MONTO));
                                    html.AppendLine(string.Format("<td>{0:c}</td>",
                                        debe - itemNC.MONTO));
                                    html.AppendLine("<td><a target=\"_blank\"");
                                    html.AppendLine(string.Format(
                                        "href=\"Reportes/NotaCredito.aspx?&nrocta={0}&nrocte={1}&periodo={2}&cuit={3}\">",
                                         itemNC.NRO_CTA, itemNC.NRO_CTE, itemNC.PERIODO, item.NRO_CUIT));

                                    html.AppendLine("<span class=\"fa fa-download\"");
                                    html.AppendLine("style =\"text-align: center; font-size: 14px;\">");
                                    html.AppendLine("Nota de Credito</span></a></td>");
                                    html.AppendLine("</tr>");
                                    debe -= itemNC.MONTO;
                                }
                            }
                        }
                    }
                    if (!item.PAGADO)
                    {
                        if (item.INTERES_MORA > 0)
                        {
                            if (item.PAGO_A_CTA == 0)
                            {
                                if (item.INTERES_MORA != 0)
                                {
                                    debe += item.INTERES_MORA;
                                    html.AppendLine("<tr>");
                                    html.AppendLine(string.Format("<td>{0:d}</td>",
                                        UTILS.getFechaActual().ToShortDateString()));
                                    html.AppendLine(string.Format("<td>Intereses mora al {0:d}</td>",
                                        UTILS.getFechaActual().ToShortDateString()));
                                    html.AppendLine(string.Format("<td>{0:c}</td>",
                                        item.INTERES_MORA));
                                    html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                                    html.AppendLine(string.Format("<td>{0:c}</td>",
                                        debe - haber));
                                    html.AppendLine("</tr>");
                                }
                            }
                        }
                    }

                    for (int i = 0; i < lstCtaPagos.Count; i++)
                    {
                        if (i == 0)
                        {
                            if (lstCtaPagos[i].INTERES_MORA > 0)
                            {
                                debe += lstCtaPagos[i].INTERES_MORA;
                                html.AppendLine("<tr>");
                                html.AppendLine(string.Format("<td>{0:d}</td>",
                                    lstCtaPagos[i].FECHA.ToShortDateString()));
                                if (lstCtaPagos[i].FECHA.ToShortDateString() == lstCtaPagos[i].FECHA_ULTIMO_PAGO.ToShortDateString())
                                {
                                    html.AppendLine(string.Format("<td>Intereses mora al {0:d}</td>",
                                        lstCtaPagos[i].FECHA.ToShortDateString()));
                                }
                                else
                                {
                                    if (lstCtaPagos[i].OBS != "")
                                        html.AppendLine(string.Format("<td>{0}</td>",
                                            lstCtaPagos[i].OBS));
                                    else
                                        html.AppendLine(string.Format("<td>Intereses mora al {0:d}</td>",
    lstCtaPagos[i].FECHA.ToShortDateString()));
                                }
                                html.AppendLine(string.Format("<td>{0:c}</td>",
                                    lstCtaPagos[i].INTERES_MORA));
                                html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                                html.AppendLine(string.Format("<td>{0:c}</td>",
                                    debe - haber));
                                html.AppendLine("</tr>");
                            }
                            haber += lstCtaPagos[i].HABER;
                            html.AppendLine("<tr>");
                            html.AppendLine(string.Format("<td>{0:d}</td>",
                                lstCtaPagos[i].FECHA.ToShortDateString()));
                            html.AppendLine(string.Format("<td>Pago - Recibo Nro.:{0}</td>",
                                lstCtaPagos[i].NRO_RECIBO_PAGO));
                            html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                            html.AppendLine(string.Format("<td>{0:c}</td>",
                                lstCtaPagos[i].HABER));
                            html.AppendLine(string.Format("<td>{0:c}</td>",
                                debe - haber));

                            html.AppendLine("<td><a target=\"_blank\"");
                            //CAMBIO CRYSTALREPORTS
                            //html.AppendLine(string.Format(
                            //    "href=\"Reportes/Print.aspx?op=recibo&nroRecibo={0}&fecha={1}\">",
                            //     lstCtaPagos[i].NRO_RECIBO_PAGO, lstCtaPagos[i].FECHA));

                            html.AppendLine(string.Format(
    "href=\"Reportes/Recibo.aspx?nroRecibo={0}\">",
     lstCtaPagos[i].NRO_RECIBO_PAGO));

                            html.AppendLine("<span class=\"fa fa-download\"");
                            html.AppendLine("style =\"text-align: center; font-size: 14px;\">");
                            html.AppendLine("Comprobante pago</span></a></td>");

                            if (rol != 3)
                            {
                                if (lstCtaPagos[i].FECHA >= Convert.ToDateTime("2022-08-22"))
                                {
                                    html.AppendLine(string.Format(
                                    "<td><a href=\"#\" onclick=\"abrirAnulaComprobante({0})\">",
                                    lstCtaPagos[i].NRO_RECIBO_PAGO));

                                    html.AppendLine("<span class=\"fa fa-remove\"");
                                    html.AppendLine("style =\"text-align: center; font-size: 14px; color:red;\">");
                                    html.AppendLine("Anular pago</span></a></td>");
                                }
                            }
                            html.AppendLine("</tr>");
                        }
                        else
                        {
                            debe += lstCtaPagos[i].INTERES_MORA - lstCtaPagos[i - 1].SALDO_INTERES;

                            if (item.AJUSTE_INTERES == 0)
                            {
                                if ((lstCtaPagos[i].INTERES_MORA - lstCtaPagos[i - 1].SALDO_INTERES) != 0)
                                {
                                    html.AppendLine("<tr>");
                                    html.AppendLine(string.Format("<td>{0:d}</td>",
                                        lstCtaPagos[i].FECHA.ToShortDateString()));

                                    string fecha_desde = lstCtaPagos[i - 1].FECHA.ToShortDateString();
                                    string fecha_hasta = lstCtaPagos[i].FECHA.ToShortDateString();
                                    if (lstCtaPagos[i - 1].FECHA.ToShortDateString() != lstCtaPagos[i - 1].FECHA_ULTIMO_PAGO.ToShortDateString())
                                    {
                                        if (lstCtaPagos[i - 1].FECHA_ULTIMO_PAGO.ToShortDateString() != Convert.ToDateTime("1900-01-01").ToShortDateString())
                                            fecha_desde = lstCtaPagos[i - 1].FECHA_ULTIMO_PAGO.ToShortDateString();
                                    }
                                    if (lstCtaPagos[i].FECHA.ToShortDateString() != lstCtaPagos[i].FECHA_ULTIMO_PAGO.ToShortDateString())
                                    {
                                        if (lstCtaPagos[i].FECHA_ULTIMO_PAGO.ToShortDateString() != Convert.ToDateTime("1900-01-01").ToShortDateString())
                                            fecha_hasta = lstCtaPagos[i].FECHA_ULTIMO_PAGO.ToShortDateString();
                                    }
                                    html.AppendLine(
                                        string.Format("<td>Intereses mora entre el {0:d} y {1:d}</td>",
                                        fecha_desde, fecha_hasta));


                                    html.AppendLine(string.Format("<td>{0:c}</td>",
                                        lstCtaPagos[i].INTERES_MORA - lstCtaPagos[i - 1].SALDO_INTERES));
                                    html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                                    html.AppendLine(string.Format("<td>{0:c}</td>",
                                        debe - haber));
                                    html.AppendLine("</tr>");
                                }
                            }
                            else
                            {
                                html.AppendLine("<tr>");
                                html.AppendLine(string.Format("<td>{0:d}</td>",
                                    lstCtaPagos[i].FECHA.ToShortDateString()));
                                html.AppendLine(
                                    string.Format("<td>Descuento</td>",
                                    lstCtaPagos[i - 1].FECHA.ToShortDateString(),
                                    lstCtaPagos[i].FECHA.ToShortDateString()));
                                html.AppendLine(string.Format("<td>{0:c}</td>",
                                    item.AJUSTE_INTERES));
                                html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                                html.AppendLine(string.Format("<td>{0:c}</td>",
                                    debe - haber));
                                html.AppendLine("</tr>");
                            }
                            haber += lstCtaPagos[i].HABER;
                            html.AppendLine("<tr>");
                            html.AppendLine(string.Format("<td>{0:d}</td>",
                                lstCtaPagos[i].FECHA));
                            html.AppendLine(string.Format("<td>Pago - Recibo Nro.:{0}</td>",
                                lstCtaPagos[i].NRO_RECIBO_PAGO));
                            html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                            html.AppendLine(string.Format("<td>{0:c}</td>",
                                lstCtaPagos[i].HABER));

                            html.AppendLine(string.Format("<td>{0:c}</td>",
                                debe - haber));

                            html.AppendLine("<td><a target=\"_blank\"");
                            //CAMBIO CRYSTALREPORTS
                            //html.AppendLine(string.Format(
                            //    "href=\"Reportes/Print.aspx?op=recibo&nroRecibo={0}&fecha={1}\">",
                            //     lstCtaPagos[i].NRO_RECIBO_PAGO, lstCtaPagos[i].FECHA));
                            html.AppendLine(string.Format(
                                "href=\"Reportes/Recibo.aspx?nroRecibo={0}\">",
                                 lstCtaPagos[i].NRO_RECIBO_PAGO));
                            html.AppendLine("<span class=\"fa fa-download\"");
                            html.AppendLine("style =\"text-align: center; font-size: 14px;\">");
                            html.AppendLine("Comprobante pago</span></a></td>");
                            if (lstCtaPagos[i].FECHA >= Convert.ToDateTime("2022-08-22"))
                            {
                                html.AppendLine(string.Format(
                                "<td><a href=\"#\" onclick=\"abrirAnulaComprobante({0})\">",
                                lstCtaPagos[i].NRO_RECIBO_PAGO));
                                if (rol != 3)
                                {
                                    html.AppendLine("<span class=\"fa fa-remove\"");
                                    html.AppendLine("style =\"text-align: center; font-size: 14px; color:red;\">");
                                    html.AppendLine("Anular pago</span></a></td>");
                                }
                            }
                            html.AppendLine("</tr>");
                        }
                    }

                    if (!item.PAGADO)
                    {
                        if (item.INTERES_MORA > 0)
                        {
                            if (item.PAGO_A_CTA > 0)
                            {
                                debe += item.INTERES_MORA - item.SALDO_INTERES;
                                html.AppendLine("<tr>");
                                html.AppendLine(string.Format("<td>{0:d}</td>",
                                    UTILS.getFechaActual().ToShortDateString()));
                                html.AppendLine(string.Format("<td>Intereses mora al {0:d}</td>",
                                    UTILS.getFechaActual().ToShortDateString()));
                                html.AppendLine(string.Format("<td>{0:c}</td>",
                                    item.INTERES_MORA - item.SALDO_INTERES));
                                html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                                html.AppendLine(string.Format("<td>{0:c}</td>",
                                    debe - haber));
                                html.AppendLine("</tr>");
                            }
                        }
                    }

                    html.AppendLine("</tbody></table>");
                    html.AppendLine("</div></div>");
                }
                return html.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string detallePlan(int nroCta, int periodo, int rol)
        {
            try
            {
                StringBuilder html = new StringBuilder();
                html.AppendLine("");
                decimal debe = 0;
                decimal haber = 0;
                List<DAL.CTACTE_EXPENSAS> lstCta =
DAL.CTACTE_EXPENSAS.readPlan(periodo, nroCta);
                List<DAL.DETALLE_CTA> lst = new List<DAL.DETALLE_CTA>();

                List<DAL.CTACTE_EXPENSAS> lstCtaDeuda =
                    lstCta.FindAll(c => (c.TIPO_MOVIMIENTO == 3));
                //|| c.TIPO_MOVIMIENTO == 3);
                //html.AppendLine(string.Format("",));

                foreach (var item in lstCtaDeuda)
                {
                    string det = string.Empty;
                    if (item.TIPO_MOVIMIENTO == 100)
                    {
                        List<DAL.DETALLE_DEUDA> objDet =
                            DAL.DETALLE_DEUDA.getByIdCta(item.ID);
                        if (objDet.Count > 0)
                            det = objDet[0].OBS;
                    }
                    if (item.PAGADO)
                    {
                        html.AppendLine("<div class=\"box box-success\">");
                        html.AppendLine("<div class=\"box-header\">");
                        html.AppendLine(string.Format("<h3 class=\"box-title\" style=\"width: 100%; color: #00a65a;\">{0}<span class=\"pull-right\">{1:c}</span></h3>",
                            Utiles.periodo(item.PERIODO, item.TIPO_MOVIMIENTO,
                            item.NRO_PLAN_PAGO, item.NRO_CUOTA, det, item.PTO_VTA, item.NRO_CTE), item.SALDO));
                        html.AppendLine("</div>");
                    }
                    else
                    {
                        html.AppendLine("<div class=\"box box-danger\">");
                        html.AppendLine("<div class=\"box-header\">");
                        html.AppendLine(string.Format("<h3 class=\"box-title\" style=\"width: 100%; color:#dd4b39;\">{0}<span class=\"pull-right\">{1:c}</span></h3>",
                            Utiles.periodo(item.PERIODO, item.TIPO_MOVIMIENTO,
                            item.NRO_PLAN_PAGO, item.NRO_CUOTA, det, item.PTO_VTA, item.NRO_CTE), item.SALDO));
                        html.AppendLine("</div>");
                    }
                    html.AppendLine("<div class=\"box-body no-padding\">");

                    html.AppendLine("<table class=\"table table-striped\">");
                    html.AppendLine("<tbody><tr>");
                    html.AppendLine("<th>FECHA</th>");
                    html.AppendLine("<th>CONCEPTO</th>");
                    html.AppendLine("<th>DEBE</th>");
                    html.AppendLine("<th>HABER</th>");
                    html.AppendLine("<th>SALDO</th>");
                    html.AppendLine("<th></th>");
                    html.AppendLine("</tr>");

                    List<DAL.CTACTE_EXPENSAS> lstCtaPagos = new List<DAL.CTACTE_EXPENSAS>();

                    lstCtaPagos =
                        lstCta.FindAll(c => c.TIPO_MOVIMIENTO == 2 &&
                        c.NRO_PLAN_PAGO != 0).OrderBy(
                            l => l.NRO_RECIBO_PAGO).ToList();


                    html.AppendLine("<tr>");
                    html.AppendLine(string.Format("<td>{0:d}</td>",
                        item.VENCIMIENTO));
                    html.AppendLine(string.Format("<td>{0}</td>",
                        Utiles.periodo(item.PERIODO, item.TIPO_MOVIMIENTO,
                            item.NRO_PLAN_PAGO, item.NRO_CUOTA, det, item.PTO_VTA, item.NRO_CTE)));
                    html.AppendLine(string.Format("<td>{0:c}</td>",
                        item.MONTO_ORIGINAL - item.DESC_VENCIMIENTO));
                    html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                    html.AppendLine(string.Format("<td>{0:c}</td>",
                        item.MONTO_ORIGINAL - item.DESC_VENCIMIENTO));
                    html.AppendLine("<td><a target=\"_blank\"");
                    //CAMBIO CRYSTALREPORTS
                    //html.AppendLine(string.Format(
                    //    "href=\"Reportes/Print.aspx?op=factura&nrocta={0}&periodo={1}&idcta={2}\">",
                    //     item.NRO_CTA, item.PERIODO, item.ID));
                    if (item.TIPO_MOVIMIENTO != 100)
                        html.AppendLine(string.Format(
                        "href=\"Reportes/Reports.aspx?&nrocta={0}&periodo={1}&idcta={2}\">",
                         item.NRO_CTA, item.PERIODO, item.ID));
                    else
                        html.AppendLine(string.Format(
                        "href=\"Reportes/Factura.aspx?&nrocta={0}&periodo={1}&idcta={2}\">",
                         item.NRO_CTA, item.PERIODO, item.ID));

                    html.AppendLine("<span class=\"fa fa-download\"");
                    html.AppendLine("style =\"text-align: center; font-size: 14px;\">");
                    html.AppendLine("Factura expensa</span></a></td>");
                    html.AppendLine("</tr>");
                    debe += item.MONTO_ORIGINAL - item.DESC_VENCIMIENTO;

                    if (!item.PAGADO)
                    {
                        if (item.INTERES_MORA > 0)
                        {
                            if (item.PAGO_A_CTA == 0)
                            {
                                debe += item.INTERES_MORA;
                                html.AppendLine("<tr>");
                                html.AppendLine(string.Format("<td>{0:d}</td>",
                                    UTILS.getFechaActual().ToShortDateString()));
                                html.AppendLine(string.Format("<td>Intereses mora al {0:d}</td>",
                                    UTILS.getFechaActual().ToShortDateString()));
                                html.AppendLine(string.Format("<td>{0:c}</td>",
                                    item.INTERES_MORA));
                                html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                                html.AppendLine(string.Format("<td>{0:c}</td>",
                                    debe - haber));
                                html.AppendLine("</tr>");
                            }
                        }
                    }

                    for (int i = 0; i < lstCtaPagos.Count; i++)
                    {
                        if (i == 0)
                        {
                            if (lstCtaPagos[i].INTERES_MORA > 0)
                            {
                                debe += lstCtaPagos[i].INTERES_MORA;
                                html.AppendLine("<tr>");
                                html.AppendLine(string.Format("<td>{0:d}</td>",
                                    lstCtaPagos[i].FECHA.ToShortDateString()));
                                html.AppendLine(string.Format("<td>Intereses mora al {0:d}</td>",
                                    lstCtaPagos[i].FECHA.ToShortDateString()));
                                html.AppendLine(string.Format("<td>{0:c}</td>",
                                    lstCtaPagos[i].INTERES_MORA));
                                html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                                html.AppendLine(string.Format("<td>{0:c}</td>",
                                    debe - haber));
                                html.AppendLine("</tr>");
                            }
                            haber += lstCtaPagos[i].HABER;
                            html.AppendLine("<tr>");
                            html.AppendLine(string.Format("<td>{0:d}</td>",
                                lstCtaPagos[i].FECHA.ToShortDateString()));
                            html.AppendLine(string.Format("<td>Pago - Recibo Nro.:{0}</td>",
                                lstCtaPagos[i].NRO_RECIBO_PAGO));
                            html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                            html.AppendLine(string.Format("<td>{0:c}</td>",
                                lstCtaPagos[i].HABER));
                            html.AppendLine(string.Format("<td>{0:c}</td>",
                                debe - haber));

                            html.AppendLine("<td><a target=\"_blank\"");
                            //CAMBIO CRYSTALREPORTS
                            //html.AppendLine(string.Format(
                            //    "href=\"Reportes/Print.aspx?op=recibo&nroRecibo={0}&fecha={1}\">",
                            //     lstCtaPagos[i].NRO_RECIBO_PAGO, lstCtaPagos[i].FECHA));

                            html.AppendLine(string.Format(
    "href=\"Reportes/Recibo.aspx?nroRecibo={0}\">",
     lstCtaPagos[i].NRO_RECIBO_PAGO));

                            html.AppendLine("<span class=\"fa fa-download\"");
                            html.AppendLine("style =\"text-align: center; font-size: 14px;\">");
                            html.AppendLine("Comprobante pago</span></a></td>");
                            if (rol != 3)
                            {
                                if (lstCtaPagos[i].FECHA >= Convert.ToDateTime("2022-08-22"))
                                {
                                    html.AppendLine(string.Format(
                                    "<td><a href=\"#\" onclick=\"abrirAnulaComprobante({0})\">",
                                    lstCtaPagos[i].NRO_RECIBO_PAGO));

                                    html.AppendLine("<span class=\"fa fa-remove\"");
                                    html.AppendLine("style =\"text-align: center; font-size: 14px; color:red;\">");
                                    html.AppendLine("Anular pago</span></a></td>");
                                }
                            }
                            html.AppendLine("</tr>");
                        }
                        else
                        {
                            debe += lstCtaPagos[i].INTERES_MORA - lstCtaPagos[i - 1].SALDO_INTERES;
                            html.AppendLine("<tr>");
                            html.AppendLine(string.Format("<td>{0:d}</td>",
                                lstCtaPagos[i].FECHA.ToShortDateString()));
                            html.AppendLine(
                                string.Format("<td>Intereses mora entre el {0:d} y {1:d}</td>",
                                lstCtaPagos[i - 1].FECHA.ToShortDateString(),
                                lstCtaPagos[i].FECHA.ToShortDateString()));
                            html.AppendLine(string.Format("<td>{0:c}</td>",
                                lstCtaPagos[i].INTERES_MORA - lstCtaPagos[i - 1].SALDO_INTERES));
                            html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                            html.AppendLine(string.Format("<td>{0:c}</td>",
                                debe - haber));
                            html.AppendLine("</tr>");
                            haber += lstCtaPagos[i].HABER;
                            html.AppendLine("<tr>");
                            html.AppendLine(string.Format("<td>{0:d}</td>",
                                lstCtaPagos[i].FECHA));
                            html.AppendLine(string.Format("<td>Pago - Recibo Nro.:{0}</td>",
                                lstCtaPagos[i].NRO_RECIBO_PAGO));
                            html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                            html.AppendLine(string.Format("<td>{0:c}</td>",
                                lstCtaPagos[i].HABER));

                            html.AppendLine(string.Format("<td>{0:c}</td>",
                                debe - haber));

                            html.AppendLine("<td><a target=\"_blank\"");
                            //CAMBIO CRYSTALREPORTS
                            //html.AppendLine(string.Format(
                            //    "href=\"Reportes/Print.aspx?op=recibo&nroRecibo={0}&fecha={1}\">",
                            //     lstCtaPagos[i].NRO_RECIBO_PAGO, lstCtaPagos[i].FECHA));
                            html.AppendLine(string.Format(
                                "href=\"Reportes/Recibo.aspx?nroRecibo=8{0}\">",
                                 lstCtaPagos[i].NRO_RECIBO_PAGO));
                            html.AppendLine("<span class=\"fa fa-download\"");
                            html.AppendLine("style =\"text-align: center; font-size: 14px;\">");
                            html.AppendLine("Comprobante pago</span></a></td>");
                            if (rol != 3)
                            {
                                if (lstCtaPagos[i].FECHA >= Convert.ToDateTime("2022-08-22"))
                                {
                                    html.AppendLine(string.Format(
                                "<td><a href=\"#\" onclick=\"abrirAnulaComprobante({0})\">",
                                lstCtaPagos[i].NRO_RECIBO_PAGO));

                                    html.AppendLine("<span class=\"fa fa-remove\"");
                                    html.AppendLine("style =\"text-align: center; font-size: 14px; color:red;\">");
                                    html.AppendLine("Anular pago</span></a></td>");
                                }
                            }
                            html.AppendLine("</tr>");
                        }
                    }

                    if (!item.PAGADO)
                    {
                        if (item.INTERES_MORA > 0)
                        {
                            if (item.PAGO_A_CTA > 0)
                            {
                                debe += item.INTERES_MORA;
                                html.AppendLine("<tr>");
                                html.AppendLine(string.Format("<td>{0:d}</td>",
                                    UTILS.getFechaActual().ToShortDateString()));
                                html.AppendLine(string.Format("<td>Intereses mora al {0:d}</td>",
                                    UTILS.getFechaActual().ToShortDateString()));
                                html.AppendLine(string.Format("<td>{0:c}</td>",
                                    item.INTERES_MORA));
                                html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                                html.AppendLine(string.Format("<td>{0:c}</td>",
                                    debe - haber));
                                html.AppendLine("</tr>");
                            }
                        }
                    }

                    html.AppendLine("</tbody></table>");
                    html.AppendLine("</div></div>");
                }
                return html.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int factura(DAL.FACTURAS_X_EXPENSA objFE,
            int idUsuario, int tipoMov)
        {
            try
            {
                DAL.DETALLE_DEUDA obj = new DAL.DETALLE_DEUDA();
                obj.CANT = 1;
                obj.COSTO = objFE.MONTO;
                obj.DEBE = objFE.MONTO;
                obj.FECHA = objFE.FECHA_CAE;
                obj.FECHA_CARGA = UTILS.getFechaActual();
                obj.HABER = 0;
                obj.ID_CONCEPTO = 20;
                obj.MASIVO = false;
                obj.NRO_CTA = objFE.NRO_CTA;
                obj.NRO_ORDEN = 1;

                obj.OBS = objFE.DETALLE;
                obj.PERIODO = objFE.PERIODO;
                obj.SALDO = objFE.MONTO;
                obj.SUBTOTAL = objFE.MONTO;
                obj.USUARIO_CARGA = idUsuario;
                obj.MONTO_ORIGINAL = objFE.MONTO;

                DAL.CTACTE_EXPENSAS objMaestro = new DAL.CTACTE_EXPENSAS();
                objMaestro.HABER = 0;
                objMaestro.MONTO_ORIGINAL = objFE.MONTO;
                objMaestro.NRO_CTA = objFE.NRO_CTA;
                objMaestro.PERIODO = objFE.PERIODO;

                objMaestro.TIPO_MOVIMIENTO = tipoMov;
                objMaestro.RECARGO_VENCIMIENTO = 0;
                objMaestro.DESC_VENCIMIENTO = 0;
                objMaestro.SALDO = objFE.MONTO;
                objMaestro.DEBE = objFE.MONTO;
                objMaestro.VENCIMIENTO = objFE.FECHA_CAE;
                int id = DAL.CTACTE_EXPENSAS.insert(objMaestro);

                obj.ID_CTA = id;

                DAL.DETALLE_DEUDA.insert(obj);
                return id;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int facturaND(DAL.FACTURAS_X_EXPENSA objFE,
                    int idUsuario, int tipoMov, int nroReciboPago)
        {
            try
            {
                DAL.DETALLE_DEUDA obj = new DAL.DETALLE_DEUDA();
                obj.CANT = 1;
                obj.COSTO = objFE.MONTO;
                obj.DEBE = objFE.MONTO;
                obj.FECHA = objFE.FECHA_CAE;
                obj.FECHA_CARGA = UTILS.getFechaActual();
                obj.HABER = 0;
                obj.ID_CONCEPTO = 20;
                obj.MASIVO = false;
                obj.NRO_CTA = objFE.NRO_CTA;
                obj.NRO_ORDEN = 1;

                obj.OBS = objFE.DETALLE;
                obj.PERIODO = objFE.PERIODO;
                obj.SALDO = objFE.MONTO;
                obj.SUBTOTAL = objFE.MONTO;
                obj.USUARIO_CARGA = idUsuario;
                obj.MONTO_ORIGINAL = objFE.MONTO;

                DAL.CTACTE_EXPENSAS objMaestro = new DAL.CTACTE_EXPENSAS();
                objMaestro.HABER = 0;
                objMaestro.MONTO_ORIGINAL = objFE.MONTO;
                objMaestro.NRO_CTA = objFE.NRO_CTA;
                objMaestro.PERIODO = objFE.PERIODO;
                objMaestro.NRO_RECIBO_PAGO = nroReciboPago;
                objMaestro.TIPO_MOVIMIENTO = tipoMov;
                objMaestro.RECARGO_VENCIMIENTO = 0;
                objMaestro.DESC_VENCIMIENTO = 0;
                objMaestro.SALDO = objFE.MONTO;
                objMaestro.DEBE = objFE.MONTO;
                objMaestro.VENCIMIENTO = objFE.FECHA_CAE;
                int id = DAL.CTACTE_EXPENSAS.insert(objMaestro);

                obj.ID_CTA = id;

                DAL.DETALLE_DEUDA.insert(obj);
                return id;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void liquida(int periodo)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    List<DAL.INMUEBLES> lst = DAL.INMUEBLES.read();
                    List<DAL.DETALLE_DEUDA> lstDetalle = new List<DAL.DETALLE_DEUDA>();
                    DAL.LIQUIDACION_EXPENSAS liq = DAL.LIQUIDACION_EXPENSAS.getByPk(periodo);
                    decimal totGeneral = 0;
                    foreach (var item in lst)
                    {
                        int orden = 1;
                        //INSERT DETALLE_DEUDA CONCEPTOS MASIVOS
                        List<DAL.CONCEPTOS_X_LIQUIDACION> lstMasivos = DAL.CONCEPTOS_X_LIQUIDACION.read(periodo, item.NRO_CTA);
                        foreach (var item2 in lstMasivos)
                        {
                            DAL.DETALLE_DEUDA obj = new DAL.DETALLE_DEUDA();
                            obj.CANT = item2.CANT;
                            obj.COSTO = item2.MONTO;
                            obj.DEBE = item2.CANT * item2.MONTO;
                            obj.FECHA = item2.FECHA_CARGA;
                            obj.FECHA_CARGA = UTILS.getFechaActual();
                            obj.HABER = 0;
                            obj.ID_CONCEPTO = item2.ID_CONCEPTO;
                            obj.MASIVO = true;
                            obj.NRO_CTA = item.NRO_CTA;
                            obj.NRO_ORDEN = orden;
                            orden++;
                            obj.OBS = item2.OBS;
                            obj.PERIODO = periodo;
                            obj.SALDO = obj.DEBE;
                            obj.SUBTOTAL = obj.DEBE;
                            obj.USUARIO_CARGA = item2.USUARIO_CARGA;
                            obj.MONTO_ORIGINAL = obj.DEBE;
                            lstDetalle.Add(obj);
                        }
                        List<DAL.CONCEPTOS_X_INMUEBLE> lstIndividuales = DAL.CONCEPTOS_X_INMUEBLE.readSinImputar(
                            item.NRO_CTA);
                        foreach (var item2 in lstIndividuales)
                        {
                            DAL.DETALLE_DEUDA obj = new DAL.DETALLE_DEUDA();
                            obj.CANT = item2.CANT;
                            obj.COSTO = item2.COSTO;
                            obj.DEBE = item2.CANT * item2.COSTO;
                            obj.FECHA = item2.FECHA_CARGA;
                            obj.FECHA_CARGA = UTILS.getFechaActual();
                            obj.HABER = 0;
                            obj.ID_CONCEPTO = item2.ID_CONCEPTO;
                            obj.MASIVO = true;
                            obj.NRO_CTA = item.NRO_CTA;
                            obj.NRO_ORDEN = orden;
                            orden++;
                            obj.OBS = item2.OBS;
                            obj.PERIODO = periodo;
                            obj.SALDO = obj.DEBE;
                            obj.SUBTOTAL = obj.DEBE;
                            obj.USUARIO_CARGA = item2.USUARIO_CARGA;
                            obj.MONTO_ORIGINAL = obj.DEBE;
                            lstDetalle.Add(obj);
                        }

                        decimal tot = lstDetalle.Sum(t => t.SUBTOTAL);
                        totGeneral = totGeneral + tot;
                        DAL.CTACTE_EXPENSAS objMaestro = new DAL.CTACTE_EXPENSAS();
                        objMaestro.HABER = 0;
                        objMaestro.MONTO_ORIGINAL = tot;
                        objMaestro.NRO_CTA = item.NRO_CTA;
                        objMaestro.PERIODO = periodo;
                        objMaestro.TIPO_MOVIMIENTO = 1;
                        objMaestro.RECARGO_VENCIMIENTO = 0;
                        objMaestro.DESC_VENCIMIENTO = liq.MONTO_3 - liq.MONTO_1;
                        objMaestro.SALDO = tot - objMaestro.DESC_VENCIMIENTO;
                        objMaestro.DEBE = tot - objMaestro.DESC_VENCIMIENTO;
                        objMaestro.VENCIMIENTO = liq.VENCIMIENTO_1;
                        DAL.CTACTE_EXPENSAS.insert(objMaestro);
                        foreach (var det in lstDetalle)
                        {
                            DAL.DETALLE_DEUDA.insert(det);
                        }
                        lstDetalle.Clear();
                    }
                    DAL.LIQUIDACION_EXPENSAS.updateLiquida(periodo, 1, lst.Count, totGeneral, 1);
                    DAL.CONCEPTOS_X_INMUEBLE.imputar(periodo);
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void liquida(int periodo, int cta)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    List<DAL.INMUEBLES> lst = new List<DAL.INMUEBLES>();
                    DAL.INMUEBLES oI = DAL.INMUEBLES.getByNroCta(cta);
                    lst.Add(oI);
                    List<DAL.DETALLE_DEUDA> lstDetalle = new List<DAL.DETALLE_DEUDA>();
                    DAL.LIQUIDACION_EXPENSAS liq = DAL.LIQUIDACION_EXPENSAS.getByPk(periodo);
                    decimal totGeneral = 0;
                    foreach (var item in lst)
                    {
                        int orden = 1;
                        //INSERT DETALLE_DEUDA CONCEPTOS MASIVOS
                        List<DAL.CONCEPTOS_X_LIQUIDACION> lstMasivos = DAL.CONCEPTOS_X_LIQUIDACION.read(periodo, item.NRO_CTA);
                        foreach (var item2 in lstMasivos)
                        {
                            DAL.DETALLE_DEUDA obj = new DAL.DETALLE_DEUDA();
                            obj.CANT = item2.CANT;
                            obj.COSTO = item2.MONTO;
                            obj.DEBE = item2.CANT * item2.MONTO;
                            obj.FECHA = item2.FECHA_CARGA;
                            obj.FECHA_CARGA = UTILS.getFechaActual();
                            obj.HABER = 0;
                            obj.ID_CONCEPTO = item2.ID_CONCEPTO;
                            obj.MASIVO = true;
                            obj.NRO_CTA = item.NRO_CTA;
                            obj.NRO_ORDEN = orden;
                            orden++;
                            obj.OBS = item2.OBS;
                            obj.PERIODO = periodo;
                            obj.SALDO = obj.DEBE;
                            obj.SUBTOTAL = obj.DEBE;
                            obj.USUARIO_CARGA = item2.USUARIO_CARGA;
                            obj.MONTO_ORIGINAL = obj.DEBE;
                            lstDetalle.Add(obj);
                        }
                        List<DAL.CONCEPTOS_X_INMUEBLE> lstIndividuales = DAL.CONCEPTOS_X_INMUEBLE.readSinImputar(
                            item.NRO_CTA);
                        foreach (var item2 in lstIndividuales)
                        {
                            DAL.DETALLE_DEUDA obj = new DAL.DETALLE_DEUDA();
                            obj.CANT = item2.CANT;
                            obj.COSTO = item2.COSTO;
                            obj.DEBE = item2.CANT * item2.COSTO;
                            obj.FECHA = item2.FECHA_CARGA;
                            obj.FECHA_CARGA = UTILS.getFechaActual();
                            obj.HABER = 0;
                            obj.ID_CONCEPTO = item2.ID_CONCEPTO;
                            obj.MASIVO = true;
                            obj.NRO_CTA = item.NRO_CTA;
                            obj.NRO_ORDEN = orden;
                            orden++;
                            obj.OBS = item2.OBS;
                            obj.PERIODO = periodo;
                            obj.SALDO = obj.DEBE;
                            obj.SUBTOTAL = obj.DEBE;
                            obj.USUARIO_CARGA = item2.USUARIO_CARGA;
                            obj.MONTO_ORIGINAL = obj.DEBE;
                            lstDetalle.Add(obj);
                        }

                        decimal tot = lstDetalle.Sum(t => t.SUBTOTAL);
                        totGeneral = totGeneral + tot;
                        DAL.CTACTE_EXPENSAS objMaestro = new DAL.CTACTE_EXPENSAS();
                        objMaestro.HABER = 0;
                        objMaestro.MONTO_ORIGINAL = tot;
                        objMaestro.NRO_CTA = item.NRO_CTA;
                        objMaestro.PERIODO = periodo;
                        objMaestro.TIPO_MOVIMIENTO = 1;
                        objMaestro.RECARGO_VENCIMIENTO = 0;
                        objMaestro.DESC_VENCIMIENTO = liq.MONTO_3 - liq.MONTO_1;
                        objMaestro.SALDO = tot - objMaestro.DESC_VENCIMIENTO;
                        objMaestro.DEBE = tot - objMaestro.DESC_VENCIMIENTO;
                        objMaestro.VENCIMIENTO = liq.VENCIMIENTO_1;
                        DAL.CTACTE_EXPENSAS.insert(objMaestro);
                        foreach (var det in lstDetalle)
                        {
                            DAL.DETALLE_DEUDA.insert(det);
                        }
                        lstDetalle.Clear();
                    }
                    DAL.LIQUIDACION_EXPENSAS.updateLiquida(periodo, 1, lst.Count, totGeneral, 1);
                    DAL.CONCEPTOS_X_INMUEBLE.imputar(periodo);
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DAL.CTACTE_EXPENSAS getByPk(
        int ID)
        {
            try
            {
                return DAL.CTACTE_EXPENSAS.getByPk(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(DAL.CTACTE_EXPENSAS obj)
        {
            try
            {
                return DAL.CTACTE_EXPENSAS.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(DAL.CTACTE_EXPENSAS obj)
        {
            try
            {
                DAL.CTACTE_EXPENSAS.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int id)
        {
            try
            {
                DAL.CTACTE_EXPENSAS.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void quitaDeuda(int nroCta, int periodo)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.CTACTE_EXPENSAS.quitaDeudaFactura(nroCta, periodo);
                    DAL.CTACTE_EXPENSAS.quitaDeudaDetalle(nroCta, periodo);
                    DAL.CTACTE_EXPENSAS.quitaDeudaCta(nroCta, periodo);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
