using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPerTic.Autorizacion
{
    public class Respuesta
    {
        [JsonProperty("access_token")]
        public string access_token { get; set; }

        [JsonProperty("expires_in")]
        public string expires_in { get; set; }

        [JsonProperty("refresh_token")]
        public string refresh_token { get; set; }

        [JsonProperty("refresh_expires_in")]
        public string refresh_expires_in { get; set; }

        [JsonProperty("token_type")]
        public string token_type { get; set; }

        [JsonProperty("not-before-policy")]
        public string not_before_policy { get; set; }

        [JsonProperty("session_state")]
        public string session_state { get; set; }

        public Respuesta()
        {
            access_token = string.Empty;
            expires_in = string.Empty;
            refresh_token = string.Empty;
            refresh_expires_in = string.Empty;
            token_type = string.Empty;
            not_before_policy = string.Empty;
            session_state = string.Empty;

        }
    }
}
