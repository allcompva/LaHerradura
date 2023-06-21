using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPerTic.SolicitudPago
{
    public class Detail
    {
        public string external_reference { get; set; }
        public string concept_id { get; set; }
        public string concept_description { get; set; }
        public double amount { get; set; }
        public string payment_id { get; set; }

        public Detail()
        {
            external_reference = string.Empty;
            concept_id = string.Empty;
            concept_description = string.Empty;
            amount = 0;
            payment_id = string.Empty;
        }
    }
}
