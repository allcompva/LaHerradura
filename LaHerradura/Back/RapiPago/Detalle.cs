using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaHerradura.Back.RapiPago
{
    public class Detalle
    {
        public DateTime fechaCobro { get; set; }
        public decimal importeCobrado { get; set; }
        public string codigoBarra { get; set; }

        public int nroCta { get; set; }
        public string factura { get; set; }
        public DateTime vencimiento { get; set; }


        public Detalle()
        {
            importeCobrado = 0;
            codigoBarra = string.Empty;
        }
        public static Detalle crea(string cadena)
        {
            Detalle obj = new Detalle();
            int anio = int.Parse(cadena.Substring(0, 4));
            int mes = int.Parse(cadena.Substring(4, 2));
            int dia = int.Parse(cadena.Substring(6, 2));
            obj.fechaCobro = new DateTime(anio, mes, dia);
            string importe = cadena.Substring(8, 15);
            obj.importeCobrado = decimal.Parse(importe.Substring(0, 13)) + (decimal.Parse(importe.Substring(13, 2)) / 100);
            obj.codigoBarra = cadena.Substring(23);
            obj.nroCta = int.Parse(obj.codigoBarra.Substring(3, 8));
            int ptoVta = int.Parse(obj.codigoBarra.Substring(11, 3));
            Int64 nroCte = Int64.Parse(obj.codigoBarra.Substring(14, 8));
            obj.factura = string.Format("{0}-{1}",
                ptoVta.ToString().PadLeft(4, Convert.ToChar("0")),
                nroCte.ToString().PadLeft(8, Convert.ToChar("0")));
            return obj;
        }
    }
}