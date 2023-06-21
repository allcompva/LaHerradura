using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPerTic.SolicitudPago
{
    public class RespuestaPago
    {
        public string id { get; set; }
        public string form_url { get; set; }
        public string final_amount { get; set; }
        public string status { get; set; }
        public string last_update_date { get; set; }
    }
}
