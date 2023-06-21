using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PayPerTic.Autorizacion
{
    public class Solicitud
    {
        public string username { get; set; }
        public string password { get; set; }
        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }

        public Solicitud()
        {
            username = string.Empty;
            password = string.Empty;
            grant_type = string.Empty;
            client_id = string.Empty;
            client_secret = string.Empty;
        }

        public static string getToken()
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient("https://a.paypertic.com/auth/realms/entidades/protocol/openid-connect/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "username=d978d1822779&password=6593be913b81&grant_type=password&client_id=16465308-1844-4abe-abe6-f184149ee740&client_secret=a2d03fa3-f6c4-45e5-9792-dc0d8b51a25c", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Respuesta token = JsonConvert.DeserializeObject<Respuesta>(response.Content);
            return token.access_token;
        }
    }
}
