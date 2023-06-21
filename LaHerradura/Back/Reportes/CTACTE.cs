using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaHerradura.Back.Reportes
{
    public class CTACTE
    {
        public int ID { get; set; }
        public int TIPO_MOVIMIENTO { get; set; }
        public int PERIODO { get; set; }
        public int NRO_CTA { get; set; }
        public decimal MONTO_ORIGINAL { get; set; }
        public decimal RECARGO_VENCIMIENTO { get; set; }
        public decimal DEBE { get; set; }
        public decimal HABER { get; set; }
        public decimal SALDO { get; set; }
        public int PTO_VTA { get; set; }
        public Int64 NRO_CTE { get; set; }
        public Int64 CAE { get; set; }
        public DateTime FECHA_CAE { get; set; }
        public DateTime VENC_CAE { get; set; }
        public DateTime FECHA { get; set; }
        public bool PAGADO { get; set; }
        public decimal DESCUENTO { get; set; }
        public decimal COSTO_FINANCIERO { get; set; }
        public DateTime VENCIMIENTO { get; set; }

        public string MANZANA { get; set; }
        public string LOTE { get; set; }
        public string DIRECCION { get; set; }

        public string NOMBRE { get; set; }
        public string TIPO_DOC { get; set; }
        public string NRO_DOC { get; set; }

        public decimal MONTO_FACTURACION { get; set; }
        public string NRO_CUIT { get; set; }

        public int ID_MEDIO_PAGO { get; set; }
        public string MEDIO_PAGO { get; set; }
        public string COD_BARRA_RAPIPAGO { get; set; }

        public decimal INTERES_MORA { get; set; }
        public decimal DESC_VENCIMIENTO { get; set; }
        public string FACTURA { get; set; }
        public string PERIODOMAQUILLADO { get; set; }

        public string LNK { get; set; }

        public decimal PAGO_A_CTA { get; set; }
    }
}