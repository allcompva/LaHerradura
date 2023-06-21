using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Servicios
{
    public class GrillaTurnos
    {
        public DateTime fecha { get; set; }
        public string hora { get; set; }
        public int id { get; set; }

        public GrillaTurnos()
        {
            fecha = UTILS.getFechaActual();
            hora = string.Empty;
            id = 0;
        }
    }
}
