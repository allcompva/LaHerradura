using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalServicios.PayPerTicApi2.Notificacion
{
    public class Presets
    {
        public string type { get; set; }
        public int installments { get; set; }
        public IList<int> media_payment_ids { get; set; }
    }
}