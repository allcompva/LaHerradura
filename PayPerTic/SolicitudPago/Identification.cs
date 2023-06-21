using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPerTic.SolicitudPago
{
    public class Identification
    {
        public string type { get; set; }
        public string number { get; set; }
        public string country { get; set; }

        public Identification()
        {

            type = string.Empty;
            number = string.Empty;
            country = string.Empty;
        }
    }
}
