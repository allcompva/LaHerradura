using mailinblue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EnvioMail
    {
        public static void envMail(string mailDestinatario, string mailNombre,
            string mailCuerpo, string mailAsunto)
        {
            try
            {
                API sendinBlue = new mailinblue.API("79LpGPhkUMDKbHqs");

                Dictionary<string, Object> data = new Dictionary<string, Object>();
                Dictionary<string, string> to = new Dictionary<string, string>();
                to.Add(mailDestinatario, mailNombre);
                List<string> from_name = new List<string>();
                from_name.Add("laherradura_ac@yahoo.com.ar ");
                from_name.Add("Vecino Digital");

                data.Add("to", to);
                data.Add("from", from_name);
                data.Add("subject", mailAsunto);
                data.Add("html", mailCuerpo);
                //data.Add("attachment", attachment);

                Object sendEmail = sendinBlue.send_email(data);

                sendEmail.ToString();
                //cliente.Send(mmsg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                throw ex;
            }
        }
    }
}
