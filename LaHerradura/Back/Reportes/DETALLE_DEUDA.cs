using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaHerradura.Back.Reportes
{
    public class DETALLE_DEUDA
    {
        public int ID { get; set; }
        public int NRO_CTA { get; set; }
        public int ID_CONCEPTO { get; set; }
        public int PERIODO { get; set; }
        public DateTime FECHA { get; set; }
        public string OBS { get; set; }
        public int CANT { get; set; }
        public decimal COSTO { get; set; }
        public decimal SUBTOTAL { get; set; }
        public bool MASIVO { get; set; }
        public DateTime FECHA_CARGA { get; set; }
        public int USUARIO_CARGA { get; set; }
        public int NRO_ORDEN { get; set; }
        public decimal DEBE { get; set; }
        public decimal HABER { get; set; }
        public decimal SALDO { get; set; }
        public decimal MONTO_ORIGINAL { get; set; }
        public string DESC_CONCEPTO { get; set; }



    }
}