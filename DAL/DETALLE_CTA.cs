using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DETALLE_CTA
    {
        public DateTime fecha { get; set; }
        public string detalle { get; set; }
        public decimal debe { get; set; }
        public decimal haber { get; set; }
        public decimal saldo { get; set; }
    }
}
