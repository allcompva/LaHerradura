using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPerTic.Notificaciones
{
    public class Presets
    {
        public string type { get; set; }
        public int installments { get; set; }
        public IList<int> media_payment_ids { get; set; }
    }
}
