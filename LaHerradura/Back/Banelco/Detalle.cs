using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LaHerradura.Back.Banelco
{
    public class Detalle
    {
        public int CodigoRegistro { get; set; }
        public string NroReferencia { get; set; }
        public string IdFactura { get; set; }
        public DateTime FechVencimiento { get; set; }
        public int CodigoMoneda { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public decimal Importe { get; set; }
        public int CodigoMovimiento { get; set; }
        public DateTime FechaAcreditacion { get; set; }
        public string CanalPago { get; set; }
        public string NroControl { get; set; }
        public string CodigoProvincia { get; set; }
        public string Filler { get; set; }

        public Detalle()
        {
            CodigoRegistro = 0;
            NroReferencia = string.Empty;
            IdFactura = string.Empty;
            CodigoMoneda = 0;
            Importe = 0;
            CodigoMovimiento = 0;
            CanalPago = string.Empty;
            NroControl = string.Empty;
            CodigoProvincia = string.Empty;
            Filler = string.Empty;

        }
        public static Detalle crea(string cadena)
        {
            var culturaArgentina = CultureInfo.GetCultureInfo("es-AR");
            Detalle obj = new Detalle();
            obj.CodigoRegistro = int.Parse(cadena.Substring(0, 1));
            obj.NroReferencia = cadena.Substring(1, 19);
            obj.IdFactura = cadena.Substring(20, 20);
            string fecha = cadena.Substring(40, 8);
            obj.FechVencimiento = Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                fecha.Substring(6, 2), fecha.Substring(4, 2), fecha.Substring(0, 4)), culturaArgentina);
            obj.CodigoMoneda = Convert.ToInt32(cadena.Substring(48, 1));
            fecha = cadena.Substring(49, 8);
            obj.FechaAplicacion = Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                fecha.Substring(6, 2), fecha.Substring(4, 2), fecha.Substring(0, 4)), culturaArgentina);
            string importe = cadena.Substring(57, 11);
            obj.Importe = decimal.Parse(importe.Substring(0, 9)) + (decimal.Parse(importe.Substring(9, 2)) / 100);
            obj.CodigoMovimiento = int.Parse(cadena.Substring(68, 1));
            fecha = cadena.Substring(69, 8);
            obj.FechaAcreditacion = Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                fecha.Substring(6, 2), fecha.Substring(4, 2), fecha.Substring(0, 4)), culturaArgentina);
            obj.CanalPago = cadena.Substring(77, 2);
            obj.NroControl = cadena.Substring(79, 4);
            obj.CodigoProvincia = cadena.Substring(83, 3);
            obj.Filler = cadena.Substring(84, 14);
            return obj; 
        }
    }
}