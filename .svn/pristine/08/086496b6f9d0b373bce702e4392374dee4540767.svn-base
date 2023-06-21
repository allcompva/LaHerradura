using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaHerradura.Macro
{
    public class Detalle
    {
        public string Filler { get; set; }
        public string Nro_de_convenio { get; set; }
        public string Nro_de_servicio { get; set; }
        public string Nro_de_empresa_de_sueldos { get; set; }
        public string Codigo_de_banco_del_adherente { get; set; }
        public string Codigo_de_sucursal_de_la_cuenta { get; set; }
        public string Tipo_de_cuenta { get; set; }
        public string Cuenta_bancaria_del_adherente { get; set; }
        public string Identificacion_actual_del_adherente { get; set; }
        public string Identificacion_del_debito { get; set; }
        public string Funcion_o_uso_del_movimiento { get; set; }
        public string codigo_de_motivo_o_rechazo { get; set; }
        public DateTime Fecha_de_vencimiento { get; set; }

        public string Moneda_del_debito { get; set; }
        public string Importe_a_debitar { get; set; }
        public string fecha_reintento { get; set; }
        public decimal Importe_debitado { get; set; }
        public string Nueva_sucursal_bancaria { get; set; }
        public string Nuevo_Tipo_de_cuenta { get; set; }
        public string Nueva_cuenta_bancaria { get; set; }
        public string Nueva_identificacion_del_adherente { get; set; }
        public string Datos_de_retorno { get; set; }
        public string Sin_uso { get; set; }
        public string Filler2 { get; set; }
        public int NRO_CTA { get; set; }

        public Detalle()
        {
            Filler = string.Empty;
            Nro_de_convenio = string.Empty;
            Nro_de_servicio = string.Empty;
            Nro_de_empresa_de_sueldos = string.Empty;
            Codigo_de_banco_del_adherente = string.Empty;
            Codigo_de_sucursal_de_la_cuenta = string.Empty;
            Tipo_de_cuenta = string.Empty;
            Cuenta_bancaria_del_adherente = string.Empty;
            Identificacion_actual_del_adherente = string.Empty;
            Identificacion_del_debito = string.Empty;
            Funcion_o_uso_del_movimiento = string.Empty;
            codigo_de_motivo_o_rechazo = string.Empty;
            Fecha_de_vencimiento = LaHerradura.Utils.Utils.getFechaActual();
            Moneda_del_debito = string.Empty;
            Importe_a_debitar = string.Empty;
            fecha_reintento = string.Empty;
            Importe_debitado = 0;
            Nueva_sucursal_bancaria = string.Empty;
            Nuevo_Tipo_de_cuenta = string.Empty;
            Nueva_cuenta_bancaria = string.Empty;
            Nueva_identificacion_del_adherente = string.Empty;
            Datos_de_retorno = string.Empty;
            Sin_uso = string.Empty;
            Filler2 = string.Empty;
            NRO_CTA = 0;
        }
        public static Detalle crea(string cadena)
        {
            Detalle obj = new Detalle();
            obj.Filler = cadena.Substring(0, 1);
            obj.Nro_de_convenio = cadena.Substring(1, 5);
            obj.Nro_de_servicio = cadena.Substring(6, 10);
            obj.Nro_de_empresa_de_sueldos = cadena.Substring(16, 5);
            obj.Codigo_de_banco_del_adherente = cadena.Substring(21, 3);
            obj.Codigo_de_sucursal_de_la_cuenta = cadena.Substring(24, 4);
            obj.Tipo_de_cuenta = cadena.Substring(28, 1);
            obj.Cuenta_bancaria_del_adherente = cadena.Substring(29, 15);
            obj.Identificacion_actual_del_adherente = cadena.Substring(44, 22);
            obj.NRO_CTA = int.Parse(obj.Identificacion_actual_del_adherente.Substring(0, 5));
            obj.Identificacion_del_debito = cadena.Substring(66, 15);
            obj.Identificacion_del_debito = string.Format("{0}-{1}", 
                obj.Identificacion_del_debito.Substring(0, 4),
                obj.Identificacion_del_debito.Substring(7));
            obj.Funcion_o_uso_del_movimiento = cadena.Substring(81, 2);
            obj.codigo_de_motivo_o_rechazo = cadena.Substring(83, 4);
            string fecha = cadena.Substring(87, 8);
            obj.Fecha_de_vencimiento = Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                fecha.Substring(6, 2), fecha.Substring(4, 2), fecha.Substring(0, 4)));
            obj.Moneda_del_debito = cadena.Substring(95, 3);
            obj.Importe_a_debitar = cadena.Substring(98, 13);
            obj.fecha_reintento = cadena.Substring(111, 8);
            obj.Moneda_del_debito = cadena.Substring(95, 3);
            string importe = cadena.Substring(98, 13);
            obj.Importe_debitado = 
                decimal.Parse(importe.Substring(0, 11)) + 
                (decimal.Parse(importe.Substring(11, 2)) / 100);

            return obj;
        }
    }
}