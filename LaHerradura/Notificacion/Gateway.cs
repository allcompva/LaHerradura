using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalServicios.PayPerTicApi2.Notificacion
{
    public class Gateway
    {
        public string establishment_number { get; set; }
        public string transaction_id { get; set; }
        public string batch_number { get; set; }
        public string ticket_number { get; set; }
        public bool ppt_owner { get; set; }
    }
}