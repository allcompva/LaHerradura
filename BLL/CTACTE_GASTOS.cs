using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CTACTE_GASTOS
    {
        public static string detalle(int idProv, int ptoVta, long nroCte,
            int id, int rol)
        {
            try
            {
                StringBuilder html = new StringBuilder();
                html.AppendLine("");
                decimal debe = 0;
                decimal haber = 0;
                List<DAL.CTACTE_GASTOS> lstCta =
DAL.CTACTE_GASTOS.readDeuda(idProv, ptoVta, nroCte);
                List<DAL.DETALLE_CTA> lst = new List<DAL.DETALLE_CTA>();

                List<DAL.CTACTE_GASTOS> lstCtaDeuda =
                    lstCta.FindAll(c => (c.TIPO_MOVIMIENTO == 1));
                //html.AppendLine(string.Format("",));
                DAL.FACTURAS_X_OP objOP = DAL.FACTURAS_X_OP.getByFactura(id);
                DAL.ORDENES_PAGO objOrde = null;
                if (objOP != null)
                {
                    objOrde = DAL.ORDENES_PAGO.getByPk(objOP.ID_OP);
                }
                foreach (var item in lstCtaDeuda)
                {
                    if (item.PAGADO)
                    {
                        html.AppendLine("<div class=\"box box-success\">");
                        html.AppendLine("<div class=\"box-header\">");
                        if (objOP != null)
                        {
                            html.AppendLine(
                                string.Format(
                                    "<h3 class=\"box-title\" style=\"width: 100%;\">Factura: {0}-{1}",
                                    item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                    item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0"))));
                            html.AppendLine(
                                    "<a target =\"_BLANK\" role=\"menuitem\" tabindex=\"-1\"");
                            html.AppendLine(
                                string.Format("href =\"../Back/Reportes/ordenPago.aspx?nroOP={0}\">",
                                objOP.ID_OP));
                            html.AppendLine(
                                string.Format("<small style=\"color: #3c8dbc;\">(Orde de Pago: {0}-{1})</small>",
                                objOrde.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                objOrde.NRO.ToString().PadLeft(8, Convert.ToChar("0"))));
                            html.AppendLine(
                                string.Format("</a><span class=\"pull-right\">{0:c}</span></h3>",
                                    item.SALDO));
                        }
                        else
                        {
                            html.AppendLine(
                                string.Format(
                                    "<h3 class=\"box-title\" style=\"width: 100%;\">Factura: {0}-{1}<span class=\"pull-right\">{2:c}</span></h3>",
                                    item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                    item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")),
                                    item.SALDO));
                        }
                        html.AppendLine("</div>");
                    }
                    else
                    {
                        html.AppendLine("<div class=\"box box-danger\">");
                        html.AppendLine("<div class=\"box-header\">");
                        if (objOP != null)
                        {
                            html.AppendLine(
                                string.Format(
                                    "<h3 class=\"box-title\" style=\"width: 100%;\">Factura: {0}-{1}",
                                    item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                    item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0"))));
                            html.AppendLine(
                                    "<a target =\"_BLANK\" role=\"menuitem\" tabindex=\"-1\"");
                            html.AppendLine(
                                string.Format("href =\"../Back/Reportes/ordenPago.aspx?nroOP={0}\">",
                                objOP.ID_OP));
                            html.AppendLine(
                                string.Format("<small style=\"color: #3c8dbc;\">(Orde de Pago: {0}-{1})</small>",
                                objOrde.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                objOrde.NRO.ToString().PadLeft(8, Convert.ToChar("0"))));
                            html.AppendLine(
                                string.Format("</a><span class=\"pull-right\">{0:c}</span></h3>",
                                    item.SALDO));
                        }
                        else
                        {
                            html.AppendLine(
                                string.Format(
                                    "<h3 class=\"box-title\" style=\"width: 100%;\">Factura: {0}-{1}<span class=\"pull-right\">{2:c}</span></h3>",
                                    item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                    item.NRO_CTE.ToString().PadLeft(10, Convert.ToChar("0")),
                                    item.SALDO));
                        }
                        html.AppendLine("</div>");
                    }
                    html.AppendLine("<div class=\"box-body no-padding\">");

                    html.AppendLine("<table class=\"table table-striped\">");
                    html.AppendLine("<tbody><tr>");
                    html.AppendLine("<th>FECHA</th>");
                    html.AppendLine("<th>CONCEPTO</th>");
                    html.AppendLine("<th>DEBE</th>");
                    html.AppendLine("<th>DESCUENTO</th>");
                    html.AppendLine("<th>HABER</th>");
                    html.AppendLine("<th>SALDO</th>");
                    html.AppendLine("<th></th>");
                    html.AppendLine("</tr>");


                    List<DAL.CTACTE_GASTOS> lstCtaPagos =
                        lstCta.FindAll(c => c.TIPO_MOVIMIENTO == 2).OrderBy(l => l.NRO_RECIBO_PAGO).ToList();
                    html.AppendLine("<tr>");
                    //VENCIMIENTO
                    html.AppendLine(string.Format("<td>{0:d}</td>", item.FECHA));
                    //CONCEPTO
                    html.AppendLine(string.Format("<td>{0}</td>",
                        item.OBS));
                    //DEBE
                    html.AppendLine(string.Format("<td>{0:c}</td>", item.MONTO_ORIGINAL));
                    //DESCUENTO
                    html.AppendLine(string.Format("<td>{0:c}</td>", item.DESCUENTO));
                    //HABER
                    html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                    //SALDO
                    html.AppendLine(string.Format("<td>{0:c}</td>",
                        item.MONTO_ORIGINAL - item.DESCUENTO));
                    //html.AppendLine("<td><a target=\"_blank\"");
                    //html.AppendLine(string.Format(
                    //    "href=\"Reportes/Print.aspx?op=factura&nrocta={0}&periodo={1}&idcta={2}\">",
                    //     item.ID_PROVEEDOR, item.FACTURA, item.ID));
                    //html.AppendLine("<span class=\"fa fa-download\"");
                    //html.AppendLine("style =\"text-align: center; font-size: 14px;\">");
                    //html.AppendLine("Factura expensa</span></a></td>");
                    html.AppendLine("</tr>");
                    debe += item.MONTO_ORIGINAL;


                    for (int i = 0; i < lstCtaPagos.Count; i++)
                    {
                        DAL.MOV_BILLETERA_GASTOS objBilletera =
    DAL.MOV_BILLETERA_GASTOS.getByNroRecibo(lstCtaPagos[i].NRO_RECIBO_PAGO);

                        haber += lstCtaPagos[i].HABER;
                        html.AppendLine("<tr>");
                        //FECHA
                        html.AppendLine(string.Format("<td>{0:d}</td>",
                            lstCtaPagos[i].FECHA.ToShortDateString()));
                        //CONCEPTO
                        html.AppendLine(string.Format("<td>Pago - Recibo Nro.:{0}</td>",
                            lstCtaPagos[i].NRO_RECIBO_PAGO));
                        //DEBE
                        html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                        //DESCUENTO
                        html.AppendLine(string.Format("<td>{0:c}</td>", item.DESCUENTO));
                        //HABER
                        if (objBilletera == null)
                            html.AppendLine(string.Format("<td>{0:c}</td>",
                                lstCtaPagos[i].HABER));
                        else
                        {
                            html.AppendLine(string.Format("<td>{0:c}</td>",
                                lstCtaPagos[i].HABER + objBilletera.MONTO));
                            haber += objBilletera.MONTO;
                        }
                        //SALDO
                        html.AppendLine(string.Format("<td>{0:c}</td>",
                            debe - item.DESCUENTO - haber));

                        //html.AppendLine("<td><a target=\"_blank\"");
                        //html.AppendLine(string.Format(
                        //    "href=\"../Back/Reportes/reciboGasto.aspx?nroRecibo={0}\">",
                        //     lstCtaPagos[i].NRO_RECIBO_PAGO));

                        //html.AppendLine("<span class=\"fa fa-download\"");
                        //html.AppendLine("style =\"text-align: center; font-size: 14px;\">");
                        //html.AppendLine("Comprobante pago</span></a></td>");

                        if (rol != 3)
                        {
                            html.AppendLine(string.Format(
                                "<td><a href=\"#\" onclick=\"abrirAnulaComprobante({0})\">",
                                lstCtaPagos[i].NRO_RECIBO_PAGO));

                            html.AppendLine("<span class=\"fa fa-remove\"");
                            html.AppendLine("style =\"text-align: center; font-size: 14px; color:red;\">");
                            html.AppendLine("Anular pago</span></a></td>");
                        }
                        html.AppendLine("</tr>");

                        if (objBilletera != null)
                        {
                            html.AppendLine("<tr>");
                            html.AppendLine(string.Format("<td>{0:d}</td>", objBilletera.FECHA));
                            html.AppendLine("<td>Saldo a cuenta a billetera virtual</td>");
                            html.AppendLine(string.Format("<td>{0:c}</td>", objBilletera.MONTO));
                            html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                            html.AppendLine(string.Format("<td>{0:c}</td>", 0));
                            html.AppendLine("<td></td>");
                            html.AppendLine("</tr>");
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
    }
}
