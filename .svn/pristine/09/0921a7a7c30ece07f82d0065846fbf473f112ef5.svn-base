
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Carnets
{
    public class TURNOS
    {
        public static List<DAL.Carnets.TURNOS> read(int idServ)
        {
            try
            {
                return DAL.Carnets.TURNOS.read(idServ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DAL.Carnets.TURNOS getByPk(int pk)
        {
            try
            {
                return DAL.Carnets.TURNOS.getByPk(pk);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<DAL.Carnets.TURNOS> getByFecha(DateTime _fecha, int idServ)
        {
            try
            {
                return DAL.Carnets.TURNOS.getByFecha(_fecha, idServ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<DAL.Carnets.TURNOS> getByCuit(string _cuit, int idServ)
        {
            try
            {
                return DAL.Carnets.TURNOS.getByCuit(_cuit, idServ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<DAL.Carnets.TURNOS> getAllByCuit(string _cuit, int idServ)
        {
            try
            {
                return DAL.Carnets.TURNOS.getAllByCuit(_cuit, idServ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<DAL.Carnets.TURNOS> getByFechaHora(DateTime _fecha, TimeSpan _hora, int idServ)
        {
            try
            {
                return DAL.Carnets.TURNOS.getByFechaHora(_fecha, _hora, idServ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int insert(DAL.Carnets.TURNOS obj, string reprogramacion)
        {
            try
            {
                obj.id = DAL.Carnets.TURNOS.insert(obj);
                //envioMail(obj, reprogramacion);
                return obj.id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void update(DAL.Carnets.TURNOS obj)
        {
            try
            {
                DAL.Carnets.TURNOS.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void updateEstado(int id, DAL.Carnets.TURNOS.est estado, int usuario_confirma)
        {
            try
            {
                DAL.Carnets.TURNOS.updateEstado(id, estado, usuario_confirma);
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
                DAL.Carnets.TURNOS.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static string envioMailAviso(string cuit, string asunto, string cuerpo)
        //{
            //StringBuilder html = new StringBuilder();
            //DAL.VecinoDigital objVecino = VecinoDigital.getByPk(cuit);
            //html.AppendLine("<!DOCTYPE html>");
            //html.AppendLine("<html>");
            //html.AppendLine("<head>");
            //html.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
            //html.AppendLine("<title></title>");
            //html.AppendLine("</head>");
            //html.AppendLine("<body>");
            //html.AppendLine("<table width=\"560\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"");
            //html.AppendLine("style=\"margin: 0 auto 0; padding-top: 30px; width: 560px\">");
            //html.AppendLine("<tbody>");
            //html.AppendLine("<tr>");
            //html.AppendLine("<td>");
            //html.AppendLine("<div style=\"display: block; margin: 10px auto; width: 100%\">");
            //html.AppendLine("<div style=\"display: block; \"><img style=\"display: block; width: 100 %; \"");
            //html.AppendLine("src=\"https://vecino.villaallende.gov.ar/img/cedulon.png\" alt =\"\">");
            //html.AppendLine("</div>");
            //html.AppendLine("<div style=\"display: block; float: left; width: 100 %; \">");
            //html.AppendLine("<div style=\"display: block; float:left\"></div>");
            //html.AppendLine("<div style=\"display: block; float:right; font-family:Arial; float:right; font-size:11px;");
            //html.AppendFormat("color:#333333; text-align:right;padding-right: 33px; line-height:27px\">{0}</div></div>",
            //    ..ToShortDateString());
            //html.AppendLine("<div style=\"display: block; padding: 20px; \">");
            //html.AppendLine("<div style=\"padding: 15px 30px; display: block; font-family:Arial; font-size:12px;");
            //html.AppendLine("color:#333333; text-align:justify; min:height:300px; padding:20px;\">");
            //html.AppendLine("<h2 style=\"font-size:18px; font-family:roboto;\">Oficina de Licencias de Conducir</h2>");
            //html.AppendFormat("<p>{0}</p></div></div>", cuerpo);
            //html.AppendLine("<div style=\"display: block;\">");
            //html.AppendLine("<img style=\"display: block; width: 100 %;\" src=\"https://vecino.villaallende.gov.ar/img/footer.jpg?v=1\" alt =\"\">");
            //html.AppendLine("</div></div></td></tr></tbody></table></body></html>");
           

            //try
            //{
            //    API sendinBlue = new mailinblue.API("79LpGPhkUMDKbHqs");

            //    Dictionary<string, Object> data = new Dictionary<string, Object>();
            //    Dictionary<string, string> to = new Dictionary<string, string>();
            //    to.Add(objVecino.MAIL, objVecino.NOMBRE);
            //    List<string> from_name = new List<string>();
            //    from_name.Add("noresponder@villaallende.gov.ar");
            //    from_name.Add("Vecino Digital");

            //    data.Add("to", to);
            //    data.Add("from", from_name);
            //    data.Add("subject", asunto);
            //    data.Add("html", html.ToString());

            //    Object sendEmail = sendinBlue.send_email(data);

            //    return sendEmail.ToString();
            //}
            //catch (System.Net.Mail.SmtpException ex)
            //{
            //    throw ex;
            //}
        //}

        //public static string envioMail(DAL.Carnets.TURNOS objT, string reprogramacion)
        //{
        //    StringBuilder html = new StringBuilder();
        //    DAL.VecinoDigital objVecino = VecinoDigital.getByPk(objT.cuit);
        //    html.AppendLine("<!DOCTYPE html>");
        //    html.AppendLine("<html>");
        //    html.AppendLine("<head>");
        //    html.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">");
        //    html.AppendLine("<title></title>");
        //    html.AppendLine("<style>");
        //    html.AppendLine("body {background-color:#ffffff; padding:0; margin:0;}");
        //    html.AppendLine(".st-key {width:30%; text-align:left; padding-right:1%; background-color:dimgrey;");
        //    html.AppendLine("color:white; padding:8px; line-height:1.42857143; vertical-align:top;");
        //    html.AppendLine("border-top:1px solid #ddd;}");
        //    html.AppendLine(".st-val {width:68%; padding-left:1%;}");
        //    html.AppendLine(".stacktable.small-only {display:none;}");
        //    html.AppendLine(".stacktable {width: 100%;}");
        //    html.AppendLine(".table {width:100%; max-width:100%; margin-bottom:20px;}");
        //    html.AppendLine("table {background-color:transparent;}");
        //    html.AppendLine("table {border-spacing:0; border-collapse:collapse;}");
        //    html.AppendLine("</style>");
        //    html.AppendLine("</head>");
        //    html.AppendLine("<body>");
        //    html.AppendLine("<table width=\"560\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\"");
        //    html.AppendLine("style=\"margin: 0 auto 0; padding-top:30px; width:560px;\">");
        //    html.AppendLine("<tbody>");
        //    html.AppendLine("<tr>");
        //    html.AppendLine("<td>");
        //    html.AppendLine("<div style=\"display:block; margin:10px auto; width:100%\">");
        //    html.AppendLine("<div style=\"display:block;\"><img style=\"display:block; width:100 %;\"");
        //    html.AppendLine("src=\"https://vecino.villaallende.gov.ar/img/cedulon.png\" alt =\"\">");
        //    html.AppendLine("</div>");
        //    html.AppendLine("<div style=\"display:block; float:left; width:100%;\">");
        //    html.AppendLine("<div style=\"display:block; float:left\"></div>");
        //    html.AppendLine("<div style=\"display:block; float:right; font-family:Arial; float:right; font-size:11px;");
        //    html.AppendFormat("color:#333333; text-align:right;padding-right: 33px; line-height:27px\">{0}",
        //        .ToShortDateString());
        //    html.AppendLine("</div></div><div style=\"display:block; padding:20px;\">");
        //    html.AppendLine("<div style=\"padding:15px 30px; display:block; font-family:Arial; font-size:12px;");
        //    html.AppendLine("color:#333333; text-align:justify; min:height:300px; padding:20px;\">");
        //    html.AppendLine("<h2 style=\"font-size:18px; font-family:roboto;\">Turno Licencias de Conducir</h2>");
        //    if (reprogramacion != string.Empty)
        //        html.AppendLine(reprogramacion);
        //    html.AppendLine("<p><table><tbody><tr>");
        //    html.AppendLine("<td class=\"st-key\">Fecha:</td>");
        //    html.AppendFormat("<td class=\"st-val\">{0}</td></tr>", objT.fecha.ToShortDateString());
        //    html.AppendLine("<tr><td class=\"st-key\">Hora:</td>");
        //    html.AppendFormat("<td class=\"st-val\">{0}</td></tr>", objT.hora);
        //    html.AppendLine("<tr><td class=\"st-key\">Solicitante:</td>");
        //    html.AppendFormat("<td class=\"st-val\">{0}, {1}</td></tr>", objVecino.APELLIDO, objVecino.NOMBRE);
        //    html.AppendLine("<tr><td class=\"st-key\">Trámite:</td><td class=\"st-val\">SOLICITUD LICENCIA</td></tr>");
        //    html.AppendLine("<tr><td class=\"st-key\">Dependencia:</td>");
        //    html.AppendLine("<td class=\"st-val\">Centro emisor de Licencias de Conducir  - Av. Goycoechea 586, Villa Allende – TE. 03543-439280</td>");
        //    html.AppendLine("</tr></tbody></table></p><div style=\"text-align:justify; padding-top:30px;\">");
        //    html.AppendLine("<p><strong>Sr. Vecino, le solicitamos que en caso de no poder asistir al turno, cancele el mismo desde");
        //    html.AppendFormat("<a href=\"https://vecino.villaallende.gov.ar/Cedulones/Landing-Cancel-Carnet.aspx?id={0}\">aquí.</a></strong></p><p>",
        //        objT.id);
        //    html.AppendLine("Le recordamos que este turno es solo valido, si posee domicilio en la Ciudad de Villa Allende y es Intransferible.</p>");
        //    html.AppendLine("<p>Para comenzar cualquier trámite Ud. debe realizar el pago en el CENAT. Para ello");
        //    html.AppendLine("puede obtener su “boleta de pago” desde la siguiente página: ");
        //    html.AppendFormat("<a href=\"https://boletadepago.seguridadvial.gob.ar/\">Boleta de Pago CENAT</a> y pagar en las entidades habilitadas: Boleta de Pago CENAT</p>");
        //    html.AppendLine("<p>Vencida su Licencia de conducir por más de 90 días,  deberá realizar el curso online en:");
        //    html.AppendFormat("<a href=\"http://curso.seguridadvial.gob.ar\">Curso de Seguridad Vial</a></p>");
        //    html.AppendLine("<p>Si Ud. solicita la Licencia por primera vez es obligatorio el curso presencial en el centro emisor.</p>");
        //    html.AppendLine("<p>Los montos y/o requisitos podrían ser modificados, por favor, verificar los mismos 48 Hs. Antes de acudir al centro Emisor.</p>");
        //    html.AppendLine("<p>Cualquier modificación sobre el presente turno, será notificada vía correo electrónico.</p>");
        //    if (reprogramacion != string.Empty)
        //    {
        //        html.AppendLine("<p>En caso de ser una reprogramación masiva, y el horario no se encuentra dentro");
        //        html.AppendLine("de sus posibilidades, lo invitamos a llamar al Número Telefónico de referencia y");
        //        html.AppendLine("acordar con un operador un nuevo turno – estos casos tendrán prioridad - .</p>");
        //    }
        //    html.AppendLine("<p>Muchas Gracias.</p></div></div></div>");
        //    html.AppendLine("<div style=\"display: block;\">");
        //    html.AppendLine("<img style=\"display:block; width:100%;\" src=\"https://vecino.villaallende.gov.ar/img/footer.jpg?v=1\" alt=\"\">");
        //    html.AppendLine("</div></div></td></tr></tbody></table></body></html>");
           
        //    try
        //    {
        //        API sendinBlue = new mailinblue.API("79LpGPhkUMDKbHqs");

        //        Dictionary<string, Object> data = new Dictionary<string, Object>();
        //        Dictionary<string, string> to = new Dictionary<string, string>();
        //        to.Add(objVecino.MAIL, objVecino.NOMBRE);
        //        List<string> from_name = new List<string>();
        //        from_name.Add("noresponder@villaallende.gov.ar");
        //        from_name.Add("Vecino Digital");

        //        data.Add("to", to);
        //        data.Add("from", from_name);
        //        if (reprogramacion != string.Empty)
        //            data.Add("subject", "Su turno ha sido Reprogramado");
        //        else
        //            data.Add("subject", "Turno Licencias de Conducir - CUIT: " + objT.cuit);
        //        data.Add("html", html.ToString());

        //        Object sendEmail = sendinBlue.send_email(data);

        //        return sendEmail.ToString();
        //    }
        //    catch (System.Net.Mail.SmtpException ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
