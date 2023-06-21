using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AMORTIZACION
    {
        public int NRO_CUOTA { get; set; }
        public decimal MONTO_CUOTA { get; set; }
        public decimal CAPITAL_PAGADO { get; set; }
        public decimal INTERES_PAGADO { get; set; }
        public decimal SALDO { get; set; }
        public DateTime VENCIMIENTO { get; set; }

        public static List<AMORTIZACION> Calculo_frances(decimal Monto_del_prestamo, 
            decimal tasa_interes_anual, int Plazo, DateTime fec_primera_cuota)
        {
            List<AMORTIZACION> lst = new List<AMORTIZACION>();
            AMORTIZACION obj;
            decimal pago, Interes_pagado, Capital_pagado, tasa_interes_mensual;
            int fila, i;


            //Calculo del interes mensual
            tasa_interes_mensual = (tasa_interes_anual / 100) / 12;


            //Calculo de la cuota mensual
            pago = tasa_interes_mensual + 1;
            pago = (decimal)Math.Pow(Convert.ToDouble(pago), Plazo);
            pago = pago - 1;
            pago = tasa_interes_mensual / pago;
            pago = tasa_interes_mensual + pago;
            pago = Monto_del_prestamo * pago;

            Console.WriteLine();
            fila = 1;


            for (i = 1; i <= Plazo; i++)
            {
                obj = new AMORTIZACION();
                obj.NRO_CUOTA = fila;
                obj.MONTO_CUOTA = pago;
                
                Interes_pagado = tasa_interes_mensual * Monto_del_prestamo;
                obj.INTERES_PAGADO = Interes_pagado;

                Capital_pagado = pago - Interes_pagado;
                obj.CAPITAL_PAGADO = Capital_pagado;
                
                obj.SALDO = Monto_del_prestamo - Capital_pagado;
                obj.VENCIMIENTO = fec_primera_cuota;
                fec_primera_cuota = fec_primera_cuota.AddMonths(1);
                Monto_del_prestamo = Monto_del_prestamo - Capital_pagado;
                lst.Add(obj);
                fila = fila + 1;
            }
            return lst;
        }
        public static List<AMORTIZACION> Calculo_directo(decimal Monto_del_prestamo,
                    decimal tasa_interes_anual, int Plazo, DateTime fec_primera_cuota)
        {
            List<AMORTIZACION> lst = new List<AMORTIZACION>();
            AMORTIZACION obj;
            decimal cuota, interes, tasa_interes;
            int fila, i;
            fila = 1;
            tasa_interes = tasa_interes_anual / 12 * Plazo;
            interes = Monto_del_prestamo * tasa_interes / 100;
            cuota = (Monto_del_prestamo + interes) / Plazo;
            decimal saldo = Monto_del_prestamo + interes;
            for (i = 1; i <= Plazo; i++)
            {
                obj = new AMORTIZACION();
                obj.NRO_CUOTA = fila;
                obj.MONTO_CUOTA = cuota;

                obj.INTERES_PAGADO = interes / Plazo;

                obj.CAPITAL_PAGADO = Monto_del_prestamo / Plazo;

                obj.SALDO = saldo - cuota;
                obj.VENCIMIENTO = fec_primera_cuota;
                fec_primera_cuota = fec_primera_cuota.AddMonths(1);
                saldo = saldo - cuota;
                lst.Add(obj);
                fila = fila + 1;
            }
            return lst;
        }
    }
}
