﻿using mailinblue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace LaHerradura.Back
{
    public class mail
    {
        public static void cambioPass(string mail, string nombre, string usuario, int id)
        {
            try
            {
                StringBuilder html = new StringBuilder();
                html.AppendLine("<!DOCTYPE html>");
                html.AppendLine("<html>");
                html.AppendLine("<head>");
                html.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
                html.AppendLine("<title></title>");
                html.AppendLine("<style>body {background-color: #ffffff;padding: 0;margin: 0}</style>");
                html.AppendLine("</head>");
                html.AppendLine("<body>");
                html.AppendLine("<table width=\"560\" border =\"0\" align =\"center\" cellpadding =\"0\" cellspacing =\"0\"");
                html.AppendLine("style=\"margin: 0 auto 0; padding-top: 30px; width: 560px\">");
                html.AppendLine("<tbody>");
                html.AppendLine("<tr>");
                html.AppendLine("<td>");
                html.AppendLine("<div style=\"display: block; margin: 10px auto; width: 100 % \">");
                html.AppendLine("<div style=\"display: block; border: 1px solid; border-color: #3c4c39;\">");
                html.AppendLine("<img style=\"display: block;\" src=\"http://200.89.178.11/img/mailRecuperoPass.png\" alt=\"\">");
                html.AppendLine("</div>");
                html.AppendLine("<div style=\"display: block; float: left; width: 100 %;\">");
                html.AppendLine("<div style=\"display: block; float:left\" ></div>");
                html.AppendLine("<div style=\"display: block; float:right; font-family:Arial; float:right; font-size:11px; color:#333333;");
                html.AppendLine("text-align:right;padding-right: 33px; line-height:27px\">");
                html.AppendLine(string.Format("<p>{0}</p>", LaHerradura.Utils.Utils.getFechaActual().ToShortDateString()));
                html.AppendLine("</div>");
                html.AppendLine("</div>");
                html.AppendLine("<div style=\"display: block; border-bottom: 1px solid; padding: 20px;\">");
                html.AppendLine("<div style=\"padding: 15px 30px; display: block; font-family:Arial; font-size:12px;");
                html.AppendLine("color:#333333; text-align:justify; min:height:300px; padding:20px;\">");
                html.AppendLine("<h2 style=\"font-size:14px;\">¿Restablecer tu contraseña?</h2>");
                html.AppendLine(string.Format(
                    "<p>Si solicitaste un restablecimiento de contraseña para el usuario <strong>{0}</strong>, haz clic en el botón que aparece a continuación.",
                    usuario));
                html.AppendLine("</p>");
                html.AppendLine("<br><br>");
                html.AppendLine("<div style=\"text-align:center;\">");
                html.AppendLine(string.Format("<a href=\"http://200.89.178.11/CambioPass.aspx?id={0}\"",
                    id));
                html.AppendLine(
                    "style =\"text-decoration:none; border-style:none; border: 0; padding: 0; margin: 0; font-size:12px;");
                html.AppendLine(
                    "font-family:'HelveticaNeue','Helvetica Neue',Helvetica,Arial,sans-serif; color:white;text-decoration:none;");
                html.AppendLine("border-radius:4px;padding:8px 17px; border: 1px solid #293127; background-color:#3c4c39;");
                html.AppendLine("display:inline-block;font-weight:bold\" target=\"_blank\">");
                html.AppendLine("<strong>Restablecer contraseña</strong>");
                html.AppendLine("</a>");
                html.AppendLine("</div>");
                html.AppendLine("<br><br>Si no solicitaste esto, ignora este correo electrónico.");
                html.AppendLine("</div>");
                html.AppendLine("</div>");
                html.AppendLine("</div>");
                html.AppendLine("</td>");
                html.AppendLine("</tr>");
                html.AppendLine("</tbody>");
                html.AppendLine("</table>");
                html.AppendLine("</body>");
                html.AppendLine("</html>");
                List<string> lstMail = new List<string>();
                lstMail.Add(mail);
                envioMailSmtp(lstMail, nombre, "Solicitud Recupero de Contraseña", html.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void cambioPassVecino(string mail, string nombre, string usuario, int id)
        {
            try
            {
                StringBuilder html = new StringBuilder();
                html.AppendLine("<!DOCTYPE html>");
                html.AppendLine("<html>");
                html.AppendLine("<head>");
                html.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
                html.AppendLine("<title></title>");
                html.AppendLine("<style>body {background-color: #ffffff;padding: 0;margin: 0}</style>");
                html.AppendLine("</head>");
                html.AppendLine("<body>");
                html.AppendLine("<table width=\"560\" border =\"0\" align =\"center\" cellpadding =\"0\" cellspacing =\"0\"");
                html.AppendLine("style=\"margin: 0 auto 0; padding-top: 30px; width: 560px\">");
                html.AppendLine("<tbody>");
                html.AppendLine("<tr>");
                html.AppendLine("<td>");
                html.AppendLine("<div style=\"display: block; margin: 10px auto; width: 100 % \">");
                html.AppendLine("<div style=\"display: block; border: 1px solid; border-color: #3c4c39;\">");
                html.AppendLine("<img style=\"display: block;\" src=\"https://aclaherradura.com.ar/img/mailRecuperoPass.png\" alt=\"\">");
                html.AppendLine("</div>");
                html.AppendLine("<div style=\"display: block; float: left; width: 100 %;\">");
                html.AppendLine("<div style=\"display: block; float:left\" ></div>");
                html.AppendLine("<div style=\"display: block; float:right; font-family:Arial; float:right; font-size:11px; color:#333333;");
                html.AppendLine("text-align:right;padding-right: 33px; line-height:27px\">");
                html.AppendLine(string.Format("<p>{0}</p>", LaHerradura.Utils.Utils.getFechaActual().ToShortDateString()));
                html.AppendLine("</div>");
                html.AppendLine("</div>");
                html.AppendLine("<div style=\"display: block; border-bottom: 1px solid; padding: 20px;\">");
                html.AppendLine("<div style=\"padding: 15px 30px; display: block; font-family:Arial; font-size:12px;");
                html.AppendLine("color:#333333; text-align:justify; min:height:300px; padding:20px;\">");
                html.AppendLine("<h2 style=\"font-size:14px;\">¿Restablecer tu contraseña?</h2>");
                html.AppendLine(string.Format(
                    "<p>Si solicitaste un restablecimiento de contraseña para el usuario <strong>{0}</strong>, haz clic en el botón que aparece a continuación.",
                    usuario));
                html.AppendLine("</p>");
                html.AppendLine("<br><br>");
                html.AppendLine("<div style=\"text-align:center;\">");
                html.AppendLine(string.Format("<a href=\"https://aclaherradura.com.ar/CambioPassVecino.aspx?id={0}\"",
                    id));
                html.AppendLine(
                    "style =\"text-decoration:none; border-style:none; border: 0; padding: 0; margin: 0; font-size:12px;");
                html.AppendLine(
                    "font-family:'HelveticaNeue','Helvetica Neue',Helvetica,Arial,sans-serif; color:white;text-decoration:none;");
                html.AppendLine("border-radius:4px;padding:8px 17px; border: 1px solid #293127; background-color:#3c4c39;");
                html.AppendLine("display:inline-block;font-weight:bold\" target=\"_blank\">");
                html.AppendLine("<strong>Restablecer contraseña</strong>");
                html.AppendLine("</a>");
                html.AppendLine("</div>");
                html.AppendLine("<br><br>Si no solicitaste esto, ignora este correo electrónico.");
                html.AppendLine("</div>");
                html.AppendLine("</div>");
                html.AppendLine("</div>");
                html.AppendLine("</td>");
                html.AppendLine("</tr>");
                html.AppendLine("</tbody>");
                html.AppendLine("</table>");
                html.AppendLine("</body>");
                html.AppendLine("</html>");
                List<string> lstMail = new List<string>();
                lstMail.Add(mail);
                envioMailSmtp(lstMail, nombre, "Solicitud Recupero de Contraseña", html.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void reciboPago(List<string> mail, string nombre, DateTime fechaPago,
            decimal saldo, int nroRecibo)
        {
            try
            {
                StringBuilder html = new StringBuilder();
                html.AppendLine("<!DOCTYPE html>");
                html.AppendLine("<html>");
                html.AppendLine("<head>");
                html.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
                html.AppendLine("<title></title>");
                html.AppendLine("<style>body {background-color: #ffffff;padding: 0;margin: 0}</style>");
                html.AppendLine("</head>");
                html.AppendLine("<body>");
                html.AppendLine("<table width=\"560\" border =\"0\" align =\"center\" cellpadding =\"0\" cellspacing =\"0\"");
                html.AppendLine("style=\"margin: 0 auto 0; padding-top: 30px; width: 560px\">");
                html.AppendLine("<tbody>");
                html.AppendLine("<tr>");
                html.AppendLine("<td>");
                html.AppendLine("<div style=\"display: block; margin: 10px auto; width: 100 % \">");
                html.AppendLine("<div style=\"display: block; border: 1px solid; border-color: #3c4c39;\">");
                html.AppendLine("<img style=\"display: block;\" src=\"http://200.89.178.11/img/ReciboPago.png\" alt=\"\">");
                html.AppendLine("</div>");
                html.AppendLine("<div style=\"display: block; float: left; width: 100 %;\">");
                html.AppendLine("<div style=\"display: block; float:left\" ></div>");
                html.AppendLine("<div style=\"display: block; float:right; font-family:Arial; float:right; font-size:11px; color:#333333;");
                html.AppendLine("text-align:right;padding-right: 33px; line-height:27px\">");
                html.AppendLine(string.Format("<p>{0}</p>", LaHerradura.Utils.Utils.getFechaActual().ToShortDateString()));
                html.AppendLine("</div>");
                html.AppendLine("</div>");
                html.AppendLine("<div style=\"display: block; border-bottom: 1px solid; padding: 20px;\">");
                html.AppendLine("<div style=\"padding: 15px 30px; display: block; font-family:Arial; font-size:12px;");
                html.AppendLine("color:#333333; text-align:justify; min:height:300px; padding:20px;\">");
                html.AppendLine(string.Format("<h2 style=\"font-size:14px;\">Hola {0}</h2>",
                    nombre));
                html.AppendLine(string.Format(
                    "<p>Le informamos que el día <strong style=\"font-size:14px;\">{0}</strong> hemos registrado un pago por el monto de <br/><strong style=\"font-size:14px;\">{1:c}</strong>",
                    fechaPago.ToShortDateString(), saldo));
                html.AppendLine("</p>");
                html.AppendLine("<br><br>");
                html.AppendLine("<div style=\"text-align:center;\">");
                //CAMBIO CRYSTALREPORTS
                //html.AppendLine(string.Format("<a href=\"http://200.89.178.11/Back/Reportes/Print.aspx?op=recibo&nroRecibo={0}&fecha={1}\"",
                //    nroRecibo, fechaPago));

                html.AppendLine(string.Format(
                    "<a href=\"http://aclaherradura.com.ar/Back/Reportes/Recibo.aspx?nroRecibo={0}\"",
                    nroRecibo));

                html.AppendLine(
                    "style =\"text-decoration:none; border-style:none; border: 0; padding: 0; margin: 0; font-size:12px;");
                html.AppendLine(
                    "font-family:'HelveticaNeue','Helvetica Neue',Helvetica,Arial,sans-serif; color:white;text-decoration:none;");
                html.AppendLine("border-radius:4px;padding:8px 17px; border: 1px solid #293127; background-color:#3c4c39;");
                html.AppendLine("display:inline-block;font-weight:bold\" target=\"_blank\">");
                html.AppendLine("<strong>Ver Comprobante de Pago</strong>");
                html.AppendLine("</a>");
                html.AppendLine("</div>");

                html.AppendLine("<br><br><p>Importante: por favor no respondas a esta casilla de correo.</p>");
                html.AppendLine("</div>");
                html.AppendLine("</div>");
                html.AppendLine("</div>");
                html.AppendLine("</td>");
                html.AppendLine("</tr>");
                html.AppendLine("</tbody>");
                html.AppendLine("</table>");
                html.AppendLine("</body>");
                html.AppendLine("</html>");

                envioMailSmtp(mail, nombre, "Confirmación de Pago Efectuado", html.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void envioExpensas(List<string> mail, string nombre, Int64 periodo,
            int nroCta, int idCta)
        {
            try
            {
                int anio = 0;
                int mes = 0;
                int tipo = 0;
                anio = int.Parse(periodo.ToString().Substring(0, 4));
                mes = int.Parse(periodo.ToString().Substring(4, 2));
                tipo = int.Parse(periodo.ToString().Substring(6, 2));
                string me = string.Empty;
                switch (mes)
                {
                    case 1:
                        me = "Enero";
                        break;
                    case 2:
                        me = "Febrero";
                        break;
                    case 3:
                        me = "Marzo";
                        break;
                    case 4:
                        me = "Abril";
                        break;
                    case 5:
                        me = "Mayo";
                        break;
                    case 6:
                        me = "Junio";
                        break;
                    case 7:
                        me = "Julio";
                        break;
                    case 8:
                        me = "Agosto";
                        break;
                    case 9:
                        me = "Septiembre";
                        break;
                    case 10:
                        me = "Octubre";
                        break;
                    case 11:
                        me = "Noviembre";
                        break;
                    case 12:
                        me = "Diciembre";
                        break;

                    default:
                        break;
                }
                string tipoExpesa = string.Empty;
                switch (tipo)
                {
                    case 0:
                        tipoExpesa = "Ordinarias";
                        break;
                    case 1:
                        tipoExpesa = "Extraordinarias";
                        break;
                    default:
                        break;
                }
                StringBuilder html = new StringBuilder();
                html.AppendLine("<!DOCTYPE html>");
                html.AppendLine("<html>");
                html.AppendLine("<head>");
                html.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
                html.AppendLine("<title></title>");
                html.AppendLine("<style>body {background-color: #ffffff;padding: 0;margin: 0}</style>");
                html.AppendLine("</head>");
                html.AppendLine("<body>");
                html.AppendLine("<table width=\"560\" border =\"0\" align =\"center\" cellpadding =\"0\" cellspacing =\"0\"");
                html.AppendLine("style=\"margin: 0 auto 0; padding-top: 30px; width: 560px\">");
                html.AppendLine("<tbody>");
                html.AppendLine("<tr>");
                html.AppendLine("<td>");
                html.AppendLine("<div style=\"display: block; margin: 10px auto; width: 100 % \">");
                html.AppendLine("<div style=\"display: block; border: 1px solid; border-color: #3c4c39;\">");
                html.AppendLine("<img style=\"display: block;\" src=\"https://aclaherradura.com.ar/img/mailFactuExpensas.png\" alt=\"\">");
                html.AppendLine("</div>");
                html.AppendLine("<div style=\"display: block; float: left; width: 100 %;\">");
                html.AppendLine("<div style=\"display: block; float:left\" ></div>");
                html.AppendLine("<div style=\"display: block; float:right; font-family:Arial; float:right; font-size:11px; color:#333333;");
                html.AppendLine("text-align:right;padding-right: 33px; line-height:27px\">");
                html.AppendLine(string.Format("<p>{0}</p>", LaHerradura.Utils.Utils.getFechaActual().ToShortDateString()));
                html.AppendLine("</div>");
                html.AppendLine("</div>");
                html.AppendLine("<div style=\"display: block; border-bottom: 1px solid; padding: 20px;\">");
                html.AppendLine("<div style=\"padding: 15px 30px; display: block; font-family:Arial; font-size:12px;");
                html.AppendLine("color:#333333; text-align:justify; min:height:300px; padding:20px;\">");
                html.AppendLine(string.Format("<h2 style=\"font-size:14px;\">Hola {0}</h2>",
                    nombre));
                html.AppendLine(string.Format(
                    "<p>Tenemos el agrado de informarle que ya está disponible la factura correspondiente a las <strong style=\"font-size:14px;\">Expensas {0} del mes de {1} de {2}.</strong>",
                    tipoExpesa, me, anio));
                html.AppendLine("</p>");
                html.AppendLine("<br><br>");
                html.AppendLine("<div style=\"text-align:center;\">");
                //CAMBIO CRYSTALREPORTS
                //html.AppendLine(string.Format("<a href=\"https://aclaherradura.com.ar/Back/Reportes/Print.aspx?op=factura&nrocta={0}&periodo={1}&idcta={2}\"",
                //    nroCta, periodo, idCta));

                html.AppendLine(string.Format(
                    "<a href=\"http://aclaherradura.com.ar/Back/Reportes/Reports.aspx?&nrocta={0}&periodo={1}&idcta={2}\"",
                    nroCta, periodo, idCta));

                html.AppendLine(
                    "style =\"text-decoration:none; border-style:none; border: 0; padding: 0; margin: 0; font-size:12px;");
                html.AppendLine(
                    "font-family:'HelveticaNeue','Helvetica Neue',Helvetica,Arial,sans-serif; color:white;text-decoration:none;");
                html.AppendLine("border-radius:4px;padding:8px 17px; border: 1px solid #293127; background-color:#3c4c39;");
                html.AppendLine("display:inline-block;font-weight:bold\" target=\"_blank\">");
                html.AppendLine("<strong>Ver Comprobante</strong>");
                html.AppendLine("</a>");
                html.AppendLine("</div>");

                html.AppendLine("<br><br><p>Importante: por favor no respondas a esta casilla de correo.</p>");
                html.AppendLine("</div>");
                html.AppendLine("</div>");
                html.AppendLine("</div>");
                html.AppendLine("</td>");
                html.AppendLine("</tr>");
                html.AppendLine("</tbody>");
                html.AppendLine("</table>");
                html.AppendLine("</body>");
                html.AppendLine("</html>");

                envioMailSmtp(mail, nombre,
                    string.Format("Facturación Expensa {0} mes de {1} de {2} - Cuenta Nro.: {3}",
                    tipoExpesa, me, anio, nroCta), html.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void envioMailDeuda(List<string> mail, int nroCta)
        {
            List<DAL.INFORME_PERIODOS> lstInfTotal = DAL.INFORME_PERIODOS.readPeriodos(nroCta);
            List<DAL.PERSONAS_GRILLA> lst = new List<DAL.PERSONAS_GRILLA>();
            lst = DAL.PERSONAS_GRILLA.getByNroCta(nroCta);
            StringBuilder propietarios = new StringBuilder();

            foreach (var item in lst)
            {
                propietarios.Append(string.Format(
                                      "{0}&nbsp;<small>({1})</small>&nbsp;",
                                      item.NOMBRE, item.RELACION));
            }

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("<!DOCTYPE html>");
            stringBuilder.AppendLine("<html>");
            stringBuilder.AppendLine("<head>");
            stringBuilder.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
            stringBuilder.AppendLine("<title></title>");
            stringBuilder.AppendLine("<style>body {background-color: #ffffff;padding: 0;margin: 0}</style>");
            stringBuilder.AppendLine("</head>");
            stringBuilder.AppendLine("<body>");
            stringBuilder.AppendLine("<table width=\"560\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"");
            stringBuilder.AppendLine("style=\"margin:0 auto 0; padding-top: 30px;width:560px\">");
            stringBuilder.AppendLine("<tbody>");
            stringBuilder.AppendLine("<tr>");
            stringBuilder.AppendLine("<td>");
            stringBuilder.AppendLine("<div style=\"display:block;margin:10px auto; width:100%\">");
            stringBuilder.AppendLine("<div style=\"display:block;\"><img style=\"display:block;\" ");
            stringBuilder.AppendLine("src=\"http://200.89.178.11/img/AvisoDeuda.png\" alt =\"\">");
            stringBuilder.AppendLine("</div>");
            stringBuilder.AppendLine("<div style=\"display:block;float: left;width: 100%;\">");
            stringBuilder.AppendLine("<div style=\"display:block; float:left\"></div>");
            stringBuilder.AppendLine("<div style=\"display:block; float:right;font-family:Arial; float:right; font-size:11px;");
            stringBuilder.AppendFormat("color:#333333; text-align:right;padding-right: 33px; line-height:27px\">{0}", (object)LaHerradura.Utils.Utils.getFechaActual().ToShortDateString());
            stringBuilder.AppendLine("</div>");
            stringBuilder.AppendLine("</div>");
            stringBuilder.AppendLine("<div style=\"display:block; padding:20px;\">");
            stringBuilder.AppendLine("<div style=\"padding:15px 30px; display:block; font-family:Arial; font-size:12px;");
            stringBuilder.AppendLine("color:#333333; text-align:justify; min:height:300px; padding:20px;\">");
            stringBuilder.AppendLine("<h2 style=\"font-size:18px; font-family:verdana;\">AVISO POR EXPENSAS IMPAGAS</h2>");

            stringBuilder.AppendFormat("<p>Estimado {0},  </p>", propietarios);
            stringBuilder.AppendLine("<p>Por el presente queremos informarle que de acuerdo a nuestros registros Ud. presenta la siguiente deuda:</p><br>");
            stringBuilder.AppendLine("<p><h2>DETALLE DE LA DEUDA</h2></p>");

            stringBuilder.AppendLine("<table style=\"width:100%;max-width:100%;margin-bottom:20px;margin-top:20px;background-color:transparent;");
            stringBuilder.AppendLine("border-spacing:0;border-collapse: collapse;display:table;border-color:grey;\">");
            stringBuilder.AppendLine("<tbody style=\"box-sizing:border-box;display:table-row-group;vertical-align:middle;\">");
            stringBuilder.AppendLine("<tr>");
            stringBuilder.AppendLine("<th style=\"padding:5px;line-height:1.42857143;vertical-align:top;border-top:1px solid #ddd;text-align:left;\">Expensas</th>");
            stringBuilder.AppendLine("<th style=\"padding:5px;line-height:1.42857143;vertical-align:top;border-top:1px solid #ddd;text-align:left;\">Saldo</th>");
            stringBuilder.AppendLine("<th style=\"padding:5px;line-height:1.42857143;vertical-align:top;border-top:1px solid #ddd;text-align:left;\">&nbsp;</th>");
            //stringBuilder.AppendLine("<th style=\"padding:5px;line-height:1.42857143;vertical-align:top;border-top:1px solid #ddd;text-align:left;\">Importe</th>");
            stringBuilder.AppendLine("</tr>");

            foreach (var item in lstInfTotal)
            {
                stringBuilder.AppendLine("<tr>");
                stringBuilder.AppendFormat(
                    "<td style=\"padding:5px;line-height:1.42857143;vertical-align:top;border-top:1px solid #ddd;text-align:left;\">{0}</td>",
                    item.PERIODO_MAQUILLADO);
                stringBuilder.AppendFormat(
                    "<td style=\"padding:5px;line-height:1.42857143;vertical-align:top;border-top:1px solid #ddd;text-align:left;\">{0:c}</td>",
                    item.SALDO);
                stringBuilder.AppendLine("<td style=\"padding:5px;line-height:1.42857143;vertical-align:top;border-top:1px solid #ddd;text-align:left;\">&nbsp;</td>");
                //stringBuilder.AppendFormat("<td style=\"padding:5px;line-height:1.42857143;vertical-align:top;border-top:1px solid #ddd;text-align:left;\">{0:c}</td>", (object)obj.monto);
                stringBuilder.AppendLine("</tr>");
            }
            stringBuilder.AppendLine("<tr>");
            stringBuilder.AppendFormat(
                "<td style=\"padding:5px;line-height:1.42857143;vertical-align:top;border-top:1px solid #ddd;text-align:left;\"><strong>{0}</strong></td>",
                "DEUDA TOTAL");
            stringBuilder.AppendFormat(
                "<td style=\"padding:5px;line-height:1.42857143;vertical-align:top;border-top:1px solid #ddd;text-align:left;\"><strong>{0:c}</strong></td>",
                lstInfTotal.Sum(D => D.SALDO));
            stringBuilder.AppendLine("<td style=\"padding:5px;line-height:1.42857143;vertical-align:top;border-top:1px solid #ddd;text-align:left;\">&nbsp;</td>");
            //stringBuilder.AppendFormat("<td style=\"padding:5px;line-height:1.42857143;vertical-align:top;border-top:1px solid #ddd;text-align:left;\">{0:c}</td>", (object)obj.monto);
            stringBuilder.AppendLine("</tr>");
            stringBuilder.AppendLine("</tbody></table>");

            stringBuilder.AppendLine("<div>");
            stringBuilder.AppendLine("<p style=\"font-size:14px;\">La deuda posterior al 30 de Septiembre de 2019 posee intereses hasta el día de hoy. Para las deudas anteriores al 30 de septiembre de 2019, los intereses por dichos periodos serán calculados por la administración al momento del pago.</p>");

            stringBuilder.AppendLine("<p style=\"font-size:14px;\">Atento a que hemos recibido depósitos y transferencias sin identificación de quienes lo realizaron, es que le solicitamos que en caso de haber pagado alguno de los periodos detallados nos haga llegar el comprobante para su correcta imputación.</p>");

            stringBuilder.AppendLine("<p style=\"font-size:14px;\">Le recordamos que de no recibir respuesta de su parte en el término de 72hs hábiles (al mail <a href=\"mailto: laherradura_ac@yahoo.com.ar\">laherradura_ac@yahoo.com.ar</a> o al teléfono 351 650-0248), en cumplimiento de nuestras obligaciones como comisión directiva, encomendaremos la gestión de su deuda al estudio jurídico con la consecuente generación de cargos por honorarios y gastos, reservándonos además el derecho de informarlo a las centrales de deudores (Veraz).</p>");

            stringBuilder.AppendLine("<p style=\"font-size:14px;\">Aguardamos su respuesta.</p>");

            stringBuilder.AppendLine("<p style=\"font-size:14px;\">Atentamente,</p>");
            stringBuilder.AppendLine("<p></p>");
            stringBuilder.AppendLine("<p style=\"font-size:14px; text-align:right;\">La Administración</p>");
            stringBuilder.AppendLine("</div></div></div>");
            stringBuilder.AppendLine("</div></td></tr></tbody></table></body></html>");
            try
            {
                //envioMailSmtp(mail, propietarios.ToString(), 
                //    string.Format(
                //        "AVISO POR EXPENSAS IMPAGAS CUENTA: {0}",
                //        nroCta), stringBuilder.ToString());
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }
        public static void envioMailSmtp(List<string> mail, string nombre, string asunto, string cuerpo)
        {
            try
            {
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();
                foreach (var item in mail)
                {
                    mmsg.To.Add(new MailAddress(item));
                }
                //mmsg.To.Add(new MailAddress("allcompva@gmail.com"));
                mmsg.Subject = asunto;
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;
                mmsg.Body = cuerpo;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true;

                mmsg.From = new System.Net.Mail.MailAddress("administracion@aclaherradura.com.ar");

                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient("smtp-relay.sendinblue.com", 587);//
                cliente.UseDefaultCredentials = false;
                cliente.Credentials =
                    new System.Net.NetworkCredential("allcompva@gmail.com", "1sNvLEjr2thbMYOg");
                cliente.EnableSsl = true;
                cliente.DeliveryMethod = SmtpDeliveryMethod.Network;

                cliente.Send(mmsg);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}