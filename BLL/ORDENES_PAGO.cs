using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class ORDENES_PAGO
    {
        public static void insert(DAL.ORDENES_PAGO obj,
            List<DAL.FACTURAS_X_OP> lst)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    int nro = DAL.ORDENES_PAGO.getNroOrdenByMes(obj.FECHA.Month,
                        obj.FECHA.Year);
                    if (nro == 0)
                        nro = int.Parse(string.Format("{0}001",
                            obj.FECHA.Month));
                    else
                        nro = nro + 1;
                    obj.NRO = nro;
                    int id = DAL.ORDENES_PAGO.insert(obj);
                    foreach (var item in lst)
                    {
                        item.ID_OP = id;
                        DAL.FACTURAS_X_OP.insert(item);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string detalle(DAL.ORDENES_PAGO obj, int estados, 
            int rol)
        {
            try
            {
                DAL.PROVEEDORES objProv = DAL.PROVEEDORES.getByPk(obj.ID_PROV);
                StringBuilder html = new StringBuilder();

                html.AppendLine("<div class=\"box box-success\">");
                html.AppendLine("<div class=\"box-header\">");
                StringBuilder html2 = new StringBuilder();

                if (rol != 3)
                {
                    switch (estados)
                    {
                        case 0:
                            html2.AppendLine("<ul class=\"nav nav-tabs pull-right\" style=\"margin-top: -15px;border-bottom: transparent;\">");
                            html2.AppendLine("<li class=\"dropdown\">");
                            html2.AppendLine("<a class=\"dropdown-toggle\" data-toggle=\"dropdown\" style=\"border: transparent;\"");
                            html2.AppendLine("href=\"#\" aria-expanded=\"false\"><span class=\"fa fa-bars\"></span></a>");
                            html2.AppendLine("<ul class=\"dropdown-menu\" style=\"margin-top: -15px;border-bottom: transparent;\">");
                            html2.AppendLine("<li role=\"presentation\">");
                            html2.AppendLine("<a role=\"menuitem\" tabindex=\"-1\" href=\"#\"");
                            html2.AppendLine(string.Format("onclick=\"abrirAuorizar('{0}', '{1}-{2}', '{3}', '{4}')\">",
                                obj.ID,
                                obj.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                obj.NRO.ToString().PadLeft(8, Convert.ToChar("0")),
                                objProv.RAZON_SOCIAL,
                                obj.SALDO));

                            html2.AppendLine("Autorizar</a></li>");
                            html2.AppendLine("<li role=\"presentation\">");
                            html2.AppendLine("<a role=\"menuitem\" tabindex=\"-1\" href=\"#\"");
                            html2.AppendLine(string.Format("onclick=\"abrirAnular('{0}', '{1}-{2}', '{3}', '{4}')\">",
                                obj.ID,
                                obj.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                obj.NRO.ToString().PadLeft(8, Convert.ToChar("0")),
                                objProv.RAZON_SOCIAL,
                                obj.SALDO));
                            html2.AppendLine("Anular</a></li>");
                            html2.AppendLine("<li role=\"presentation\">");
                            html2.AppendLine(string.Format(
                                "<a target=\"_BLANK\" role=\"menuitem\" tabindex=\"-1\" href=\"../Back/Reportes/ordenPago.aspx?nroOP={0}\">",
                                obj.ID));
                            html2.AppendLine("Ver</a></li>");
                            html2.AppendLine("</ul>");
                            html2.AppendLine("</li>");
                            html2.AppendLine("</ul>");
                            break;
                        case 1:
                            html2.AppendLine("<ul class=\"nav nav-tabs pull-right\" style=\"margin-top: -15px;border-bottom: transparent;\">");
                            html2.AppendLine("<li class=\"dropdown\">");
                            html2.AppendLine("<a class=\"dropdown-toggle noback\" data-toggle=\"dropdown\" style=\"border: transparent;\"");
                            html2.AppendLine("href=\"#\" aria-expanded=\"false\"><span class=\"fa fa-bars\"></span></a>");
                            html2.AppendLine("<ul class=\"dropdown-menu\">");
                            html2.AppendLine("<li role=\"presentation\">");
                            html2.AppendLine(
                                string.Format(
                                    "<a role=\"menuitem\" tabindex=\"-1\" href=\"Pago.aspx?id={0}\">",
                                    obj.ID));
                            html2.AppendLine("Pagar</a></li>");
                            html2.AppendLine("<li role=\"presentation\">");
                            html2.AppendLine("<a role=\"menuitem\" tabindex=\"-1\" href=\"#\"");
                            html2.AppendLine(string.Format("onclick=\"abrirAnular('{0}', '{1}-{2}', '{3}', '{4}')\">",
                                obj.ID,
                                obj.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                obj.NRO.ToString().PadLeft(8, Convert.ToChar("0")),
                                objProv.RAZON_SOCIAL,
                                obj.SALDO));
                            html2.AppendLine("Anular</a></li>");
                            html2.AppendLine("<li role=\"presentation\">");
                            html2.AppendLine(string.Format(
                                "<a target=\"_BLANK\" role=\"menuitem\" tabindex=\"-1\" href=\"../Back/Reportes/ordenPago.aspx?nroOP={0}\">",
                                obj.ID));
                            html2.AppendLine("Ver</a></li>");
                            html2.AppendLine("</ul>");
                            html2.AppendLine("</li>");
                            html2.AppendLine("</ul>");
                            break;
                        case 3:
                            html2.AppendLine("<ul class=\"nav nav-tabs pull-right\" style=\"margin-top: -15px;border-bottom: transparent;\">");
                            html2.AppendLine("<li class=\"dropdown\">");
                            html2.AppendLine("<a class=\"dropdown-toggle noback\" data-toggle=\"dropdown\" style=\"border: transparent;\"");
                            html2.AppendLine("href=\"#\" aria-expanded=\"false\"><span class=\"fa fa-bars\"></span></a>");
                            html2.AppendLine("<ul class=\"dropdown-menu\">");
                            html2.AppendLine("<li role=\"presentation\">");
                            html2.AppendLine(
                                string.Format(
                                    "<a role=\"menuitem\" tabindex=\"-1\" href=\"Pago.aspx?id={0}\">",
                                    obj.ID));
                            html2.AppendLine("Pagar</a></li>");
                            html2.AppendLine("<li role=\"presentation\">");
                            html2.AppendLine(string.Format(
                                "<a target=\"_BLANK\" role=\"menuitem\" tabindex=\"-1\" href=\"../Back/Reportes/ordenPago.aspx?nroOP={0}\">",
                                obj.ID));
                            html2.AppendLine("Ver</a></li>");
                            html2.AppendLine("</ul>");
                            html2.AppendLine("</li>");
                            html2.AppendLine("</ul>");
                            break;
                        default:
                            html2.AppendLine("<ul class=\"nav nav-tabs pull-right\" style=\"margin-top: -15px;border-bottom: transparent;\">");
                            html2.AppendLine("<li class=\"dropdown\">");
                            html2.AppendLine("<a class=\"dropdown-toggle noback\" data-toggle=\"dropdown\" style=\"border: transparent;\"");
                            html2.AppendLine("href=\"#\" aria-expanded=\"false\"><span class=\"fa fa-bars\"></span></a>");
                            html2.AppendLine("<ul class=\"dropdown-menu\" style=\"margin-top: -15px;border-bottom: transparent;\">");
                            html2.AppendLine("<li role=\"presentation\">");
                            html2.AppendLine(string.Format(
                                "<a target=\"_BLANK\" role=\"menuitem\" tabindex=\"-1\" href=\"../Back/Reportes/ordenPago.aspx?nroOP={0}\">",
                                obj.ID));
                            html2.AppendLine("Ver</a></li>");
                            html2.AppendLine("</ul>");
                            html2.AppendLine("</li>");
                            html2.AppendLine("</ul>");
                            break;
                    }
                }
                else
                {
                    html2.AppendLine("<ul class=\"nav nav-tabs pull-right\" style=\"margin-top: -15px;border-bottom: transparent;\">");
                    html2.AppendLine("<li class=\"dropdown\">");
                    html2.AppendLine("<a class=\"dropdown-toggle noback\" data-toggle=\"dropdown\" style=\"border: transparent;\"");
                    html2.AppendLine("href=\"#\" aria-expanded=\"false\"><span class=\"fa fa-bars\"></span></a>");
                    html2.AppendLine("<ul class=\"dropdown-menu\" style=\"margin-top: -15px;border-bottom: transparent;\">");
                    html2.AppendLine("<li role=\"presentation\">");
                    html2.AppendLine(string.Format(
                        "<a target=\"_BLANK\" role=\"menuitem\" tabindex=\"-1\" href=\"../Back/Reportes/ordenPago.aspx?nroOP={0}\">",
                        obj.ID));
                    html2.AppendLine("Ver</a></li>");
                    html2.AppendLine("</ul>");
                    html2.AppendLine("</li>");
                    html2.AppendLine("</ul>");
                }
                html.AppendLine(
                    string.Format(
                        "<h3 class=\"box-title\" style=\"width: 100%; color: #00a65a;\">Orden de Pago Nro.: {0}-{1} {4}<span class=\"pull-right\">{2} - {3}</span></h3>",
                        obj.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                        obj.NRO.ToString().PadLeft(8, Convert.ToChar("0")),
                        objProv.RAZON_SOCIAL,
                        objProv.NOMBRE_FANTASIA,
                        html2.ToString()));

                html.AppendLine("</div>");

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


                List<DAL.FACTURAS_X_OP> lstCtaPagos =
                    DAL.FACTURAS_X_OP.getByOrdenPago(obj.ID);
                foreach (var item2 in lstCtaPagos)
                {
                    DAL.CTACTE_GASTOS objFactura =
                        DAL.CTACTE_GASTOS.getByPk(item2.ID_FACTURA);
                    html.AppendLine("<tr>");
                    //VENCIMIENTO
                    html.AppendLine(string.Format("<td>{0:d}</td>",
                        objFactura.FECHA));
                    //CONCEPTO
                    html.AppendLine(string.Format("<td>{0}</td>",
                        objFactura.OBS));
                    //DEBE
                    html.AppendLine(string.Format("<td>{0:c}</td>",
                        objFactura.DEBE));
                    //HABER
                    html.AppendLine(string.Format("<td>{0:c}</td>",
                        objFactura.HABER));
                    //SALDO
                    html.AppendLine(string.Format("<td>{0:c}</td>",
                        objFactura.SALDO));
                    //html.AppendLine("<td><a target=\"_blank\"");
                    //html.AppendLine(string.Format(
                    //    "href=\"Reportes/Print.aspx?op=factura&nrocta={0}&periodo={1}&idcta={2}\">",
                    //     item.ID_PROVEEDOR, item.FACTURA, item.ID));
                    //html.AppendLine("<span class=\"fa fa-download\"");
                    //html.AppendLine("style =\"text-align: center; font-size: 14px;\">");
                    //html.AppendLine("Factura expensa</span></a></td>");
                    html.AppendLine("</tr>");

                }
                html.AppendLine("<tr>");
                //VENCIMIENTO
                html.AppendLine("<td></td>");
                //CONCEPTO
                html.AppendLine("<td><strong>TOTAL</strong></td>");
                //DEBE
                html.AppendLine(string.Format("<td><strong>{0:c}</strong></td>",
                    obj.DEBE));
                //HABER
                html.AppendLine(string.Format("<td><strong>{0:c}</strong></td>",
                    obj.HABER));
                //SALDO
                html.AppendLine(string.Format("<td><strong>{0:c}</strong></td>",
                    obj.SALDO));
                //html.AppendLine("<td><a target=\"_blank\"");
                //html.AppendLine(string.Format(
                //    "href=\"Reportes/Print.aspx?op=factura&nrocta={0}&periodo={1}&idcta={2}\">",
                //     item.ID_PROVEEDOR, item.FACTURA, item.ID));
                //html.AppendLine("<span class=\"fa fa-download\"");
                //html.AppendLine("style =\"text-align: center; font-size: 14px;\">");
                //html.AppendLine("Factura expensa</span></a></td>");
                html.AppendLine("</tr>");
                html.AppendLine("</tbody></table>");
                html.AppendLine("</div></div>");

                return html.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
