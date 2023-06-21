using LaHerradura.FEProd;
using LaHerradura.wsaa;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;
using System.Xml;

namespace LaHerradura.AFIPHomo
{
    public class LogiAfipHomo
    {
        private static UInt32 UniqueId; // Entero de 32 bits sin signo que identifica el requerimiento
        private static DateTime GenerationTime; // Momento en que fue generado el requerimiento
        private static DateTime ExpirationTime; // Momento en el que expira la solicitud
        private static string Service; // Identificacion del WSN para el cual se solicita el TA
        private static string Sign; // Firma de seguridad recibida en la respuesta
        private static string Token; // Token de seguridad recibido en la respuesta
        private static XmlDocument XmlLoginTicketRequest = null;
        private static XmlDocument XmlLoginTicketResponse = null;
        private static string RutaDelCertificadoFirmante;
        private static string XmlStrLoginTicketRequestTemplate = "<loginTicketRequest><header><uniqueId></uniqueId><generationTime></generationTime><expirationTime></expirationTime></header><service></service></loginTicketRequest>";
        private static bool _verboseMode = true;
        private static UInt32 _globalUniqueID = 0; // OJO! NO ES THREAD-SAFE

        private static string CUIT =
            System.Configuration.ConfigurationManager.AppSettings["CUIT"].ToString();

        public static FEHomo.FEAuthRequest ObtenerLoginTicketResponse(string path)
        {
            const string ID_FNC = "[ObtenerLoginTicketResponse]";

            SecureString strPasswordSecureString = new SecureString();
            string pass =
                System.Configuration.ConfigurationManager.AppSettings["PASS"].ToString();

            for (int i = 0; i < pass.Length; i++)
                strPasswordSecureString.AppendChar(Convert.ToChar(pass.Substring(i, 1)));

            strPasswordSecureString.MakeReadOnly();

            RutaDelCertificadoFirmante = path;
            _verboseMode = true;
            CertificadosX509Lib.VerboseMode = true;
            string cmsFirmadoBase64 = null;
            string loginTicketResponse = null;
            XmlNode xmlNodoUniqueId = default(XmlNode);
            XmlNode xmlNodoGenerationTime = default(XmlNode);
            XmlNode xmlNodoExpirationTime = default(XmlNode);
            XmlNode xmlNodoService = default(XmlNode);

            // PASO 1: Genero el Login Ticket Request
            try
            {
                _globalUniqueID += 1;

                XmlLoginTicketRequest = new XmlDocument();
                XmlLoginTicketRequest.LoadXml(XmlStrLoginTicketRequestTemplate);

                xmlNodoUniqueId = XmlLoginTicketRequest.SelectSingleNode("//uniqueId");
                xmlNodoGenerationTime = XmlLoginTicketRequest.SelectSingleNode("//generationTime");
                xmlNodoExpirationTime = XmlLoginTicketRequest.SelectSingleNode("//expirationTime");
                xmlNodoService = XmlLoginTicketRequest.SelectSingleNode("//service");
                xmlNodoGenerationTime.InnerText = DateTime.Now.AddMinutes(-10).ToString("s");
                xmlNodoExpirationTime.InnerText = DateTime.Now.AddMinutes(+10).ToString("s");
                xmlNodoUniqueId.InnerText = Convert.ToString(_globalUniqueID);
                xmlNodoService.InnerText = "wsfe";
                Service = "wsfe";
            }
            catch (Exception excepcionAlGenerarLoginTicketRequest)
            {
                throw new Exception(ID_FNC + "***Error GENERANDO el LoginTicketRequest : " + excepcionAlGenerarLoginTicketRequest.Message + excepcionAlGenerarLoginTicketRequest.StackTrace);
            }

            // PASO 2: Firmo el Login Ticket Request
            try
            {
                X509Certificate2 certFirmante =
                    CertificadosX509Lib.ObtieneCertificadoDesdeArchivo(
                    RutaDelCertificadoFirmante, strPasswordSecureString);

                // Convierto el Login Ticket Request a bytes, firmo el msg y lo convierto a Base64
                Encoding EncodedMsg = Encoding.UTF8;
                byte[] msgBytes = EncodedMsg.GetBytes(XmlLoginTicketRequest.OuterXml);
                byte[] encodedSignedCms =
                    CertificadosX509Lib.FirmaBytesMensaje(msgBytes, certFirmante);
                cmsFirmadoBase64 = Convert.ToBase64String(encodedSignedCms);

            }
            catch (Exception excepcionAlFirmar)
            {
                throw new Exception(ID_FNC + "***Error FIRMANDO el LoginTicketRequest : " +
                    excepcionAlFirmar.Message);
            }

            // PASO 3: Invoco al WSAA para obtener el Login Ticket Response
            try
            {
                wsaahomo.LoginCMSService servicioWsaa = new wsaahomo.LoginCMSService();
                servicioWsaa.Url = "https://wsaahomo.afip.gov.ar/ws/services/LoginCms";

                // Veo si hay que salir a traves de un proxy
                //if (dirProxy != null)
                //{
                //    servicioWsaa.Proxy = new WebProxy(dirProxy, true);
                //    //if (proxyUser != null)
                //    //{
                //    //    NetworkCredential Credentials = new NetworkCredential(proxyUser, proxyPassword);
                //    //    servicioWsaa.Proxy.Credentials = Credentials;
                //    //}
                //}


                string pathXML = path.Replace("certificado.pfx", "certificado.xml");
                if (File.Exists(pathXML))
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load(pathXML);
                    ExpirationTime =
                        DateTime.Parse(xDoc.SelectSingleNode("//expirationTime").InnerText);
                    if (DateTime.Now < ExpirationTime)
                    {
                        XmlLoginTicketResponse = xDoc;

                    }
                    else
                    {
                        File.Delete(pathXML);
                        loginTicketResponse = servicioWsaa.loginCms(cmsFirmadoBase64);
                        XmlLoginTicketResponse = new XmlDocument();
                        XmlLoginTicketResponse.LoadXml(loginTicketResponse);
                        XmlLoginTicketResponse.Save(pathXML);
                    }
                }
                else
                {
                    loginTicketResponse = servicioWsaa.loginCms(cmsFirmadoBase64);
                    XmlLoginTicketResponse = new XmlDocument();
                    XmlLoginTicketResponse.LoadXml(loginTicketResponse);
                    XmlLoginTicketResponse.Save(pathXML);
                }

            }
            catch (Exception excepcionAlInvocarWsaa)
            {
                throw new Exception(ID_FNC + "***Error INVOCANDO al servicio WSAA : " +
                    excepcionAlInvocarWsaa.Message);
            }

            // PASO 4: Analizo el Login Ticket Response recibido del WSAA
            try
            {
                UniqueId =
                    UInt32.Parse(XmlLoginTicketResponse.SelectSingleNode("//uniqueId").InnerText);
                GenerationTime =
                    DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//generationTime").InnerText);
                ExpirationTime =
                    DateTime.Parse(XmlLoginTicketResponse.SelectSingleNode("//expirationTime").InnerText);

                FEHomo.FEAuthRequest obj = new FEHomo.FEAuthRequest();

                obj.Sign = XmlLoginTicketResponse.SelectSingleNode("//sign").InnerText;
                obj.Token = XmlLoginTicketResponse.SelectSingleNode("//token").InnerText;
                obj.Cuit = long.Parse(CUIT);
                return obj;

            }
            catch (Exception excepcionAlAnalizarLoginTicketResponse)
            {
                return null;
                throw new Exception(ID_FNC + "***Error ANALIZANDO el LoginTicketResponse : " + excepcionAlAnalizarLoginTicketResponse.Message);
            }

        }
    }

}