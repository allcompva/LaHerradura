using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class CTACTE_EXPENSAS : DALBase
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
        public int NRO_RECIBO_PAGO { get; set; }

        public string FACTURA { get; set; }
        public string PERIODOMAQUILLADO { get; set; }

        public int DIAS_MORA { get; set; }

        public string LNK { get; set; }

        public decimal TOT_SIN_DESC { get; set; }
        public string CBU { get; set; }
        public string BANCO { get; set; }
        public string SUCURSAL { get; set; }
        public string TIPO_COBIS { get; set; }
        public string CUENTA_BANCO { get; set; }
        public string IDENTIFICACION { get; set; }

        public string DETALLE_DEUDA { get; set; }
        public int NRO_RECIBO_PAYPERTIC { get; set; }

        public DateTime FECHA_ULTIMO_PAGO { get; set; }
        public decimal PAGO_A_CTA { get; set; }
        public decimal SALDO_CAPITAL { get; set; }
        public decimal SALDO_INTERES { get; set; }


        public decimal PAGO_CUENTA { get; set; }

        public decimal AJUSTE_INTERES { get; set; }
        public string OBS_AJUSTE { get; set; }

        public decimal CAPITAL_PAGADO { get; set; }
        public decimal INTERES_PAGADO { get; set; }

        public bool PAGO_TOTAL { get; set; }
        public decimal MONTO_PAGADO { get; set; }

        public int NRO_PLAN_PAGO { get; set; }
        public int ESTADO { get; set; }
        public int NRO_CUOTA { get; set; }

        public int ID_USUARIO_PAGA { get; set; }
        public int ID_USUARIO_ANULA { get; set; }
        public string OBS { get; set; }
        public string DESCRIPCION { get; set; }

        public CTACTE_EXPENSAS()
        {
            ID = 0;
            TIPO_MOVIMIENTO = 0;
            PERIODO = 0;
            NRO_CTA = 0;
            MONTO_ORIGINAL = 0;
            RECARGO_VENCIMIENTO = 0;
            DEBE = 0;
            HABER = 0;
            SALDO = 0;
            PTO_VTA = 0;
            NRO_CTE = 0;
            CAE = 0;
            FECHA_CAE = UTILS.getFechaActual();
            VENC_CAE = UTILS.getFechaActual();
            FECHA = UTILS.getFechaActual();
            PAGADO = false;
            DESCUENTO = 0;
            COSTO_FINANCIERO = 0;
            MONTO_FACTURACION = 0;
            ID_MEDIO_PAGO = 0;
            COD_BARRA_RAPIPAGO = string.Empty;
            INTERES_MORA = 0;
            DESC_VENCIMIENTO = 0;
            NRO_RECIBO_PAGO = 0;
            DIAS_MORA = 0;
            NRO_RECIBO_PAYPERTIC = 0;
            AJUSTE_INTERES = 0;
            OBS_AJUSTE = string.Empty;
            CAPITAL_PAGADO = 0;
            INTERES_PAGADO = 0;
            NRO_PLAN_PAGO = 0;
            ESTADO = 0;
            NRO_CUOTA = 0;
            FECHA_ULTIMO_PAGO = Convert.ToDateTime("1900-01-01");
            ID_USUARIO_ANULA = 0;
            ID_USUARIO_PAGA = 0;
            OBS = string.Empty;
        }

        private static List<CTACTE_EXPENSAS> mapeo(SqlDataReader dr)
        {
            List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
            CTACTE_EXPENSAS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new CTACTE_EXPENSAS();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.TIPO_MOVIMIENTO = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.PERIODO = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.MONTO_ORIGINAL = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.RECARGO_VENCIMIENTO = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.DEBE = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.HABER = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.SALDO = dr.GetDecimal(8); }
                    if (!dr.IsDBNull(9)) { obj.PTO_VTA = dr.GetInt32(9); }
                    if (!dr.IsDBNull(10)) { obj.NRO_CTE = dr.GetInt64(10); }
                    if (!dr.IsDBNull(11)) { obj.CAE = dr.GetInt64(11); }
                    if (!dr.IsDBNull(12)) { obj.FECHA_CAE = dr.GetDateTime(12); }
                    if (!dr.IsDBNull(13)) { obj.VENC_CAE = dr.GetDateTime(13); }
                    if (!dr.IsDBNull(14)) { obj.FECHA = dr.GetDateTime(14); }
                    if (!dr.IsDBNull(15)) { obj.PAGADO = dr.GetBoolean(15); }
                    if (!dr.IsDBNull(16)) { obj.DESCUENTO = dr.GetDecimal(16); }
                    if (!dr.IsDBNull(17)) { obj.COSTO_FINANCIERO = dr.GetDecimal(17); }
                    if (!dr.IsDBNull(18)) { obj.VENCIMIENTO = dr.GetDateTime(18); }
                    if (!dr.IsDBNull(19)) { obj.ID_MEDIO_PAGO = dr.GetInt32(19); }
                    if (!dr.IsDBNull(20)) { obj.COD_BARRA_RAPIPAGO = dr.GetString(20); }
                    if (!dr.IsDBNull(21)) { obj.INTERES_MORA = dr.GetDecimal(21); }
                    if (!dr.IsDBNull(22)) { obj.DESC_VENCIMIENTO = dr.GetDecimal(22); }
                    if (!dr.IsDBNull(23)) { obj.NRO_RECIBO_PAGO = dr.GetInt32(23); }
                    if (!dr.IsDBNull(24)) { obj.DIAS_MORA = dr.GetInt32(24); }
                    if (!dr.IsDBNull(25)) { obj.NRO_RECIBO_PAYPERTIC = dr.GetInt32(25); }
                    if (!dr.IsDBNull(26)) { obj.FECHA_ULTIMO_PAGO = dr.GetDateTime(26); }
                    if (!dr.IsDBNull(27)) { obj.PAGO_A_CTA = dr.GetDecimal(27); }
                    if (!dr.IsDBNull(28)) { obj.SALDO_CAPITAL = dr.GetDecimal(28); }
                    if (!dr.IsDBNull(29)) { obj.SALDO_INTERES = dr.GetDecimal(29); }
                    if (!dr.IsDBNull(30)) { obj.AJUSTE_INTERES = dr.GetDecimal(30); }
                    if (!dr.IsDBNull(31)) { obj.OBS_AJUSTE = dr.GetString(31); }
                    if (!dr.IsDBNull(32)) { obj.CAPITAL_PAGADO = dr.GetDecimal(32); }
                    if (!dr.IsDBNull(33)) { obj.INTERES_PAGADO = dr.GetDecimal(33); }
                    if (!dr.IsDBNull(34)) { obj.NRO_PLAN_PAGO = dr.GetInt32(34); }
                    if (!dr.IsDBNull(35)) { obj.ESTADO = dr.GetInt32(35); }
                    if (!dr.IsDBNull(36)) { obj.NRO_CUOTA = dr.GetInt32(36); }

                    if (!dr.IsDBNull(37)) { obj.ID_USUARIO_PAGA = dr.GetInt32(37); }
                    if (!dr.IsDBNull(38)) { obj.ID_USUARIO_ANULA = dr.GetInt32(38); }
                    if (!dr.IsDBNull(39)) { obj.OBS = dr.GetString(39); }

                    obj.TOT_SIN_DESC = obj.MONTO_ORIGINAL +
    obj.INTERES_MORA;

                    if (obj.PERIODO != 20190100)
                    {
                        string me, mes = string.Empty;
                        me = obj.PERIODO.ToString().Substring(4, 2);
                        switch (me)
                        {
                            case "01":
                                mes = "Enero";
                                break;
                            case "02":
                                mes = "Febrero";
                                break;
                            case "03":
                                mes = "Marzo";
                                break;
                            case "04":
                                mes = "Abril";
                                break;
                            case "05":
                                mes = "Mayo";
                                break;
                            case "06":
                                mes = "Junio";
                                break;
                            case "07":
                                mes = "Julio";
                                break;
                            case "08":
                                mes = "Agosto";
                                break;
                            case "09":
                                mes = "Septiembre";
                                break;
                            case "10":
                                mes = "Octubre";
                                break;
                            case "11":
                                mes = "Noviembre";
                                break;
                            case "12":
                                mes = "Diciembre";
                                break;
                            default:
                                break;
                        }
                        DateTime fechaVenc = obj.VENCIMIENTO;
                        LIQUIDACION_EXPENSAS objLiq = DAL.LIQUIDACION_EXPENSAS.getByPk(obj.PERIODO);
                        if (objLiq != null)
                            fechaVenc = objLiq.VENCIMIENTO_3;


                        if (obj.PERIODO.ToString().Substring(6, 2) == "00")
                        {
                            if (fechaVenc < UTILS.getFechaActual())
                            {
                                obj.PERIODOMAQUILLADO =
                                    string.Format(
                                        "<small class=\"label bg-yellow\">En mora</small><strong style=\"font-size: 16px;\"> Expensas Ordinarias mes de {0} de {1}<span class=\"pull-right\">{2:c}</span></strong><p>Venci� el: {3}</p>",
                                        mes,
                                        obj.PERIODO.ToString().Substring(0, 4),
                                    obj.SALDO, fechaVenc.ToShortDateString());

                                if (obj.TIPO_MOVIMIENTO == 3)
                                {
                                    obj.PERIODOMAQUILLADO =
                                        string.Format(
                                            "<small class=\"label bg-yellow\">En mora</small><strong style=\"font-size: 16px;\"> Plan de pago Nro.: {0} Cuota: {1} <span class=\"pull-right\">{2:c}</span></strong><p>Venci� el: {3}</p>",
                                            obj.NRO_PLAN_PAGO,
                                            obj.NRO_CUOTA,
                                        obj.SALDO, fechaVenc.ToShortDateString());
                                }

                                if (obj.ESTADO == 0)
                                {
                                    obj.PERIODOMAQUILLADO =
                                string.Format(
                                    "<small class=\"label bg-yellow\">En mora</small><strong style=\"font-size: 16px;\"> Expensas Ordinarias mes de {0} de {1}<span class=\"pull-right\"></span></strong><p>Venci� el: {2}</p><P>{3}</P>",
                                    mes,
                                    obj.PERIODO.ToString().Substring(0, 4),
                                    fechaVenc.ToShortDateString(),
                                    "Usted posee deuda en gestion judicial. Comunicarse con el Estudio Juridico Diaz Yofre para su cancelacion. Te. 351-6539434");
                                }

                            }
                            else
                            {
                                obj.PERIODOMAQUILLADO =
                                string.Format(
                                "<strong style=\"font-size: 16px;\">Expensas Ordinarias mes de {0} de {1}<span class=\"pull-right\">{2:c}</span></strong><p>Vence el: {3}</p>",
                                mes,
                                obj.PERIODO.ToString().Substring(0, 4),
                                obj.SALDO, fechaVenc.ToShortDateString());
                                if (obj.TIPO_MOVIMIENTO == 3)
                                {
                                    obj.PERIODOMAQUILLADO =
                                string.Format(
                                "<strong style=\"font-size: 16px;\">Plan de pago Nro.: {0} Cuota: {1}<span class=\"pull-right\">{2:c}</span></strong><p>Vence el: {3}</p>",
                                obj.NRO_PLAN_PAGO,
                                obj.NRO_CUOTA,
                                obj.SALDO, fechaVenc.ToShortDateString());
                                }
                                if (obj.ESTADO == 0)
                                {
                                    obj.PERIODOMAQUILLADO =
                                string.Format(
                                "<strong style=\"font-size: 16px;\">Expensas Ordinarias mes de {0} de {1}<span class=\"pull-right\"></span></strong><p>Vence el: {2}</p><P>{3}</P>",
                                mes,
                                obj.PERIODO.ToString().Substring(0, 4),
                                fechaVenc.ToShortDateString(),
                                "Usted posee deuda en gestion judicial. Comunicarse con el Estudio Juridico Diaz Yofre para su cancelacion. Te. 351-6539434");
                                }
                            }
                        }
                        else
                        {
                            if (fechaVenc < UTILS.getFechaActual())
                            {
                                switch (obj.TIPO_MOVIMIENTO)
                                {
                                    case 100:
                                        DAL.FACTURAS_X_EXPENSA objF =
                                            DAL.FACTURAS_X_EXPENSA.getByPk(obj.PTO_VTA,
                                            obj.NRO_CTE, 11);
                                        obj.PERIODOMAQUILLADO = string.Format(
                                            "<small class=\"label bg-yellow\">En mora</small><strong style=\"font-size: 16px;\"> Facturaci�n externa: {0}<span class=\"pull-right\">{1:c}</span></strong><p>Venci� el: {2}</p>",
                                            objF.DETALLE,
                                            obj.SALDO,
                                            obj.VENCIMIENTO.ToShortDateString());
                                        if (obj.ESTADO == 0)
                                        {
                                            obj.PERIODOMAQUILLADO = string.Format(
                                                "<small class=\"label bg-yellow\">En mora</small><strong style=\"font-size: 16px;\"> Facturaci�n externa: {0}<span class=\"pull-right\"></span></strong><p>Venci� el: {1}</p><p>{2}</p>",
                                                objF.DETALLE,
                                                obj.VENCIMIENTO.ToShortDateString(),
                                                "Usted posee deuda en gestion judicial. Comunicarse con el Estudio Juridico Diaz Yofre para su cancelacion. Te. 351-6539434");
                                        }
                                        break;
                                    case 21:
                                        DAL.FACTURAS_X_EXPENSA objD =
                                            DAL.FACTURAS_X_EXPENSA.getByPk(obj.PTO_VTA,
                                            obj.NRO_CTE, 21);
                                        obj.PERIODOMAQUILLADO = string.Format(
                                            "<small class=\"label bg-yellow\">En mora</small><strong style=\"font-size: 16px;\"> Nota D�bito Interna: {0}<span class=\"pull-right\">{1:c}</span></strong><p>Venci� el: {2}</p>",
                                            objD.DETALLE,
                                            obj.SALDO,
                                            obj.VENCIMIENTO.ToShortDateString());
                                        break;
                                    default:
                                        obj.PERIODOMAQUILLADO =
                                        string.Format(
                                            "<small class=\"label bg-yellow\">En mora</small><strong style=\"font-size: 16px;\"> Expensas Extraordinarias mes de {0} de {1}<span class=\"pull-right\">{2:c}</span></strong><p>Venci� el: {3}</p>",
                                            mes,
                                            obj.PERIODO.ToString().Substring(0, 4),
                                        obj.SALDO, fechaVenc.ToShortDateString());
                                        if (obj.ESTADO == 0)
                                        {
                                            obj.PERIODOMAQUILLADO =
                                        string.Format(
                                            "<small class=\"label bg-yellow\">En mora</small><strong style=\"font-size: 16px;\"> Expensas Extraordinarias mes de {0} de {1}<span class=\"pull-right\"></span></strong><p>Venci� el: {2}</p><p>{3}</p>",
                                            mes,
                                            obj.PERIODO.ToString().Substring(0, 4),
                                            fechaVenc.ToShortDateString(),
                                            "Usted posee deuda en gestion judicial. Comunicarse con el Estudio Juridico Diaz Yofre para su cancelacion. Te. 351-6539434");
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                switch (obj.TIPO_MOVIMIENTO)
                                {
                                    case 100:
                                        DAL.FACTURAS_X_EXPENSA objF = DAL.FACTURAS_X_EXPENSA.getByPk(obj.PTO_VTA,
                                        obj.NRO_CTE, 21);
                                        obj.PERIODOMAQUILLADO =
                                            string.Format(
                                            "<strong style=\"font-size: 16px;\"> Facturaci�n externa: {0}<span class=\"pull-right\">{1:c}</span></strong><p>Vence el: {2}</p>",
                                            objF.DETALLE,
                                            obj.SALDO,
                                            obj.VENCIMIENTO.ToShortDateString());
                                        if (obj.ESTADO == 0)
                                        {
                                            obj.PERIODOMAQUILLADO =
                                                string.Format(
                                                "<strong style=\"font-size: 16px;\"> Facturaci�n externa: {0}<span class=\"pull-right\"></span></strong><p>Vence el: {1}</p><p>{2}</p>",
                                                objF.DETALLE,
                                                obj.VENCIMIENTO.ToShortDateString(),
                                                "Usted posee deuda en gestion judicial. Comunicarse con el Estudio Juridico Diaz Yofre para su cancelacion. Te. 351-6539434");
                                        }
                                        break;
                                    case 21:
                                        DAL.FACTURAS_X_EXPENSA objD = DAL.FACTURAS_X_EXPENSA.getByPk(obj.PTO_VTA,
                                        obj.NRO_CTE, 21);
                                        obj.PERIODOMAQUILLADO =
                                            string.Format(
                                            "<strong style=\"font-size: 16px;\"> Nota de D�bito Interna: {0}<span class=\"pull-right\">{1:c}</span></strong><p>Vence el: {2}</p>",
                                            objD.DETALLE,
                                            obj.SALDO,
                                            obj.VENCIMIENTO.ToShortDateString());
                                        break;
                                    case 12:
                                        DAL.FACTURAS_X_EXPENSA objDF = DAL.FACTURAS_X_EXPENSA.getByPk(obj.PTO_VTA,
                                        obj.NRO_CTE, 21);
                                        obj.PERIODOMAQUILLADO =
                                            string.Format(
                                            "<strong style=\"font-size: 16px;\"> Nota de D�bito Fiscal: {0}<span class=\"pull-right\">{1:c}</span></strong><p>Vence el: {2}</p>",
                                            objDF.DETALLE,
                                            obj.SALDO,
                                            obj.VENCIMIENTO.ToShortDateString());
                                        break;
                                    default:
                                        obj.PERIODOMAQUILLADO =
                                    string.Format(
                                        "<strong style=\"font-size: 16px;\">Expensas Extraordinarias mes de {0} de {1}<span class=\"pull-right\">{2:c}</span></strong><p>Vence el: {3}</p>",
                                        mes,
                                        obj.PERIODO.ToString().Substring(0, 4),
                                        obj.SALDO, fechaVenc.ToShortDateString());
                                        if (obj.ESTADO == 0)
                                        {
                                            obj.PERIODOMAQUILLADO =
                                        string.Format(
                                            "<strong style=\"font-size: 16px;\">Expensas Extraordinarias mes de {0} de {1}<span class=\"pull-right\"></span></strong><p>Vence el: {2}</p><p>{3}</p>",
                                            mes,
                                            obj.PERIODO.ToString().Substring(0, 4),
                                            fechaVenc.ToShortDateString(),
                                            "Usted posee deuda en gestion judicial. Comunicarse con el Estudio Juridico Diaz Yofre para su cancelacion. Te. 351-6539434");
                                        }
                                        break;
                                }
                            }

                        }
                    }
                    else
                    {
                        obj.PERIODOMAQUILLADO = string.Format(
                            "<small class=\"label bg-yellow\">En mora</small><strong style=\"font-size: 16px;\">Saldo (capital) a Sept. 2019<span class=\"pull-right\">{0:c}</span></strong><p>Venci� el: {1}</p>",
                            obj.SALDO, obj.VENCIMIENTO);

                    }
                    if (obj.PERIODO == 20191212)
                    {
                        obj.PERIODOMAQUILLADO = string.Format(
                            "<small class=\"label bg-yellow\">En mora</small><strong style=\"font-size: 16px;\">Saldo a Diciembre. 2019<span class=\"pull-right\">{0:c}</span></strong><p>Venci� el: {1}</p>",
                            obj.SALDO, obj.VENCIMIENTO);
                    }
                    List<DAL.DETALLE_DEUDA> lstDet = DAL.DETALLE_DEUDA.read(obj.PERIODO,
                        obj.NRO_CTA);

                    obj.DETALLE_DEUDA = "<ul class=\"nav nav-stacked\">";
                    foreach (var item in lstDet)
                    {
                        obj.DETALLE_DEUDA += string.Format(
                            "<li><span>{0}</span><span class=\"pull-right\">{1:c}</span></li>",
                            item.DESC_CONCEPTO, item.COSTO);
                    }
                    obj.DETALLE_DEUDA += "</ul>";

                    if (obj.NRO_RECIBO_PAGO != 0)
                    {
                        obj.PAGO_CUENTA = getPagoCta(obj.PERIODO, obj.NRO_CTA);
                    }


                    lst.Add(obj);
                }
            }
            return lst;
        }
        private static List<CTACTE_EXPENSAS> mapeo2(SqlDataReader dr)
        {
            List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
            CTACTE_EXPENSAS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new CTACTE_EXPENSAS();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.TIPO_MOVIMIENTO = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.PERIODO = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.MONTO_ORIGINAL = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.RECARGO_VENCIMIENTO = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.DEBE = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.HABER = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.SALDO = dr.GetDecimal(8); }
                    if (!dr.IsDBNull(9)) { obj.PTO_VTA = dr.GetInt32(9); }
                    if (!dr.IsDBNull(10)) { obj.NRO_CTE = dr.GetInt64(10); }
                    if (!dr.IsDBNull(11)) { obj.CAE = dr.GetInt64(11); }
                    if (!dr.IsDBNull(12)) { obj.FECHA_CAE = dr.GetDateTime(12); }
                    if (!dr.IsDBNull(13)) { obj.VENC_CAE = dr.GetDateTime(13); }
                    if (!dr.IsDBNull(14)) { obj.FECHA = dr.GetDateTime(14); }
                    if (!dr.IsDBNull(15)) { obj.PAGADO = dr.GetBoolean(15); }
                    if (!dr.IsDBNull(16)) { obj.DESCUENTO = dr.GetDecimal(16); }
                    if (!dr.IsDBNull(17)) { obj.COSTO_FINANCIERO = dr.GetDecimal(17); }
                    if (!dr.IsDBNull(18)) { obj.VENCIMIENTO = dr.GetDateTime(18); }
                    if (!dr.IsDBNull(19)) { obj.ID_MEDIO_PAGO = dr.GetInt32(19); }
                    if (!dr.IsDBNull(20)) { obj.COD_BARRA_RAPIPAGO = dr.GetString(20); }
                    if (!dr.IsDBNull(21)) { obj.INTERES_MORA = dr.GetDecimal(21); }
                    if (!dr.IsDBNull(22)) { obj.DESC_VENCIMIENTO = dr.GetDecimal(22); }
                    if (!dr.IsDBNull(23)) { obj.NRO_RECIBO_PAGO = dr.GetInt32(23); }
                    if (!dr.IsDBNull(24)) { obj.DIAS_MORA = dr.GetInt32(24); }
                    if (!dr.IsDBNull(25)) { obj.NRO_RECIBO_PAYPERTIC = dr.GetInt32(25); }
                    if (!dr.IsDBNull(26)) { obj.FECHA_ULTIMO_PAGO = dr.GetDateTime(26); }
                    if (!dr.IsDBNull(27)) { obj.PAGO_A_CTA = dr.GetDecimal(27); }
                    if (!dr.IsDBNull(28)) { obj.SALDO_CAPITAL = dr.GetDecimal(28); }
                    if (!dr.IsDBNull(29)) { obj.SALDO_INTERES = dr.GetDecimal(29); }
                    if (!dr.IsDBNull(30)) { obj.AJUSTE_INTERES = dr.GetDecimal(30); }
                    if (!dr.IsDBNull(31)) { obj.OBS_AJUSTE = dr.GetString(31); }
                    if (!dr.IsDBNull(32)) { obj.CAPITAL_PAGADO = dr.GetDecimal(32); }
                    if (!dr.IsDBNull(33)) { obj.INTERES_PAGADO = dr.GetDecimal(33); }
                    if (!dr.IsDBNull(34)) { obj.NRO_PLAN_PAGO = dr.GetInt32(34); }
                    if (!dr.IsDBNull(35)) { obj.ESTADO = dr.GetInt32(35); }
                    if (!dr.IsDBNull(36)) { obj.NRO_CUOTA = dr.GetInt32(36); }
                    if (!dr.IsDBNull(37)) { obj.ID_USUARIO_PAGA = dr.GetInt32(37); }
                    if (!dr.IsDBNull(38)) { obj.ID_USUARIO_ANULA = dr.GetInt32(38); }
                    if (!dr.IsDBNull(39)) { obj.OBS = dr.GetString(39); }


                    if (!dr.IsDBNull(40)) { obj.NOMBRE = dr.GetString(40); }
                    if (!dr.IsDBNull(41)) { obj.TIPO_DOC = dr.GetString(41); }
                    if (!dr.IsDBNull(42)) { obj.NRO_DOC = dr.GetString(42); }
                    if (!dr.IsDBNull(43)) { obj.NRO_CUIT = dr.GetString(43); }

                    obj.TOT_SIN_DESC = obj.MONTO_ORIGINAL +
    obj.INTERES_MORA;

                    lst.Add(obj);
                }
            }
            return lst;
        }

        private static List<CTACTE_EXPENSAS> mapeo3(SqlDataReader dr)
        {
            List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
            CTACTE_EXPENSAS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new CTACTE_EXPENSAS();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.TIPO_MOVIMIENTO = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.PERIODO = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.MONTO_ORIGINAL = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.RECARGO_VENCIMIENTO = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.DEBE = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.HABER = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.SALDO = dr.GetDecimal(8); }
                    if (!dr.IsDBNull(9)) { obj.PTO_VTA = dr.GetInt32(9); }
                    if (!dr.IsDBNull(10)) { obj.NRO_CTE = dr.GetInt64(10); }
                    if (!dr.IsDBNull(11)) { obj.CAE = dr.GetInt64(11); }
                    if (!dr.IsDBNull(12)) { obj.FECHA_CAE = dr.GetDateTime(12); }
                    if (!dr.IsDBNull(13)) { obj.VENC_CAE = dr.GetDateTime(13); }
                    if (!dr.IsDBNull(14)) { obj.FECHA = dr.GetDateTime(14); }
                    if (!dr.IsDBNull(15)) { obj.PAGADO = dr.GetBoolean(15); }
                    if (!dr.IsDBNull(16)) { obj.DESCUENTO = dr.GetDecimal(16); }
                    if (!dr.IsDBNull(17)) { obj.COSTO_FINANCIERO = dr.GetDecimal(17); }
                    if (!dr.IsDBNull(18)) { obj.VENCIMIENTO = dr.GetDateTime(18); }
                    if (!dr.IsDBNull(19)) { obj.ID_MEDIO_PAGO = dr.GetInt32(19); }
                    if (!dr.IsDBNull(20)) { obj.COD_BARRA_RAPIPAGO = dr.GetString(20); }
                    if (!dr.IsDBNull(21)) { obj.INTERES_MORA = dr.GetDecimal(21); }
                    if (!dr.IsDBNull(22)) { obj.DESC_VENCIMIENTO = dr.GetDecimal(22); }
                    if (!dr.IsDBNull(23)) { obj.NRO_RECIBO_PAGO = dr.GetInt32(23); }
                    if (!dr.IsDBNull(24)) { obj.DIAS_MORA = dr.GetInt32(24); }
                    if (!dr.IsDBNull(25)) { obj.NRO_RECIBO_PAYPERTIC = dr.GetInt32(25); }
                    if (!dr.IsDBNull(26)) { obj.FECHA_ULTIMO_PAGO = dr.GetDateTime(26); }
                    if (!dr.IsDBNull(27)) { obj.PAGO_A_CTA = dr.GetDecimal(27); }
                    if (!dr.IsDBNull(28)) { obj.SALDO_CAPITAL = dr.GetDecimal(28); }
                    if (!dr.IsDBNull(29)) { obj.SALDO_INTERES = dr.GetDecimal(29); }
                    if (!dr.IsDBNull(30)) { obj.AJUSTE_INTERES = dr.GetDecimal(30); }
                    if (!dr.IsDBNull(31)) { obj.OBS_AJUSTE = dr.GetString(31); }
                    if (!dr.IsDBNull(32)) { obj.CAPITAL_PAGADO = dr.GetDecimal(32); }
                    if (!dr.IsDBNull(33)) { obj.INTERES_PAGADO = dr.GetDecimal(33); }
                    if (!dr.IsDBNull(34)) { obj.NRO_PLAN_PAGO = dr.GetInt32(34); }
                    if (!dr.IsDBNull(35)) { obj.ESTADO = dr.GetInt32(35); }
                    if (!dr.IsDBNull(36)) { obj.NRO_CUOTA = dr.GetInt32(36); }
                    if (!dr.IsDBNull(37)) { obj.ID_USUARIO_PAGA = dr.GetInt32(37); }
                    if (!dr.IsDBNull(38)) { obj.ID_USUARIO_ANULA = dr.GetInt32(38); }
                    if (!dr.IsDBNull(39)) { obj.OBS = dr.GetString(39); }


                    if (!dr.IsDBNull(40)) { obj.NOMBRE = dr.GetString(40); }
                    if (!dr.IsDBNull(41)) { obj.TIPO_DOC = dr.GetString(41); }
                    if (!dr.IsDBNull(42)) { obj.NRO_DOC = dr.GetString(42); }
                    if (!dr.IsDBNull(43)) { obj.NRO_CUIT = dr.GetString(43); }
                    if (!dr.IsDBNull(44)) { obj.DESCRIPCION = dr.GetString(44); }
                    obj.TOT_SIN_DESC = obj.MONTO_ORIGINAL +
    obj.INTERES_MORA;

                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<CTACTE_EXPENSAS> readNoEnviados()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE MONTH(FECHA) > 5 AND YEAR(FECHA) >= 2020 AND TIPO_MOVIMIENTO = 2");
                sql.AppendLine("AND NRO_RECIBO_PAGO NOT IN");
                sql.AppendLine("(SELECT NRO_RECIBO_PAGO FROM ENVIO_COMPROBANTES)");
                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> readEnviados()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE MONTH(FECHA) > 5 AND YEAR(FECHA) >= 2020 AND TIPO_MOVIMIENTO = 2");
                sql.AppendLine("AND NRO_RECIBO_PAGO IN");
                sql.AppendLine("(SELECT NRO_RECIBO_PAGO FROM ENVIO_COMPROBANTES)");
                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<int> readPeriodos(int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT DISTINCT PERIODO");
                sql.AppendLine("FROM CTACTE_EXPENSAS WHERE NRO_CTA = @NRO_CTA");



                List<int> lst = new List<int>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            lst.Add(dr.GetInt32(0));
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<int> readRecibos()
        {
            try
            {
                List<int> lst = new List<int>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT DISTINCT NRO_RECIBO_PAGO");
                sql.AppendLine("FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE TIPO_MOVIMIENTO=2 AND NRO_RECIBO_PAGO NOT IN");
                sql.AppendLine("(SELECT REFERENCIA FROM ASIENTOS WHERE TIPO=5)");
                sql.AppendLine("ORDER BY NRO_RECIBO_PAGO");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            lst.Add(dr.GetInt32(0));
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CTACTE_EXPENSAS> Read_NC_aEmitir(int periodo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ', ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT,");
                sql.AppendLine("(SELECT MAX(NRO_RECIBO_PAGO) FROM CTACTE_EXPENSAS X WHERE A.PERIODO = X.PERIODO AND A.NRO_CTA=X.NRO_CTA AND TIPO_MOVIMIENTO = 2),");
                sql.AppendLine("(SELECT MAX(FECHA) FROM CTACTE_EXPENSAS X WHERE A.PERIODO = X.PERIODO AND A.NRO_CTA=X.NRO_CTA AND TIPO_MOVIMIENTO = 2)");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO");
                sql.AppendLine("WHERE A.TIPO_MOVIMIENTO = 1 AND A.PERIODO = @PERIODO AND A.PAGADO = 1 AND A.DESC_VENCIMIENTO > 0");
                sql.AppendLine("AND A.ID NOT IN (SELECT ID_CTACTE FROM FACTURAS_X_EXPENSA WHERE TIPO_COMPROBANTE = 13)");
                sql.AppendLine("ORDER BY A.NRO_CTA, A.PERIODO, A.TIPO_MOVIMIENTO");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                    CTACTE_EXPENSAS obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new CTACTE_EXPENSAS();
                            if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.TIPO_MOVIMIENTO = dr.GetInt32(2); }
                            if (!dr.IsDBNull(3)) { obj.PERIODO = dr.GetInt32(3); }
                            if (!dr.IsDBNull(4)) { obj.MONTO_ORIGINAL = dr.GetDecimal(4); }
                            if (!dr.IsDBNull(5)) { obj.RECARGO_VENCIMIENTO = dr.GetDecimal(5); }
                            if (!dr.IsDBNull(6)) { obj.DEBE = dr.GetDecimal(6); }
                            if (!dr.IsDBNull(7)) { obj.HABER = dr.GetDecimal(7); }
                            if (!dr.IsDBNull(8)) { obj.SALDO = dr.GetDecimal(8); }
                            if (!dr.IsDBNull(9)) { obj.PTO_VTA = dr.GetInt32(9); }
                            if (!dr.IsDBNull(10)) { obj.NRO_CTE = dr.GetInt64(10); }
                            if (!dr.IsDBNull(11)) { obj.CAE = dr.GetInt64(11); }
                            if (!dr.IsDBNull(12)) { obj.FECHA_CAE = dr.GetDateTime(12); }
                            if (!dr.IsDBNull(13)) { obj.VENC_CAE = dr.GetDateTime(13); }
                            if (!dr.IsDBNull(45)) { obj.FECHA = dr.GetDateTime(45); }
                            if (!dr.IsDBNull(15)) { obj.PAGADO = dr.GetBoolean(15); }
                            if (!dr.IsDBNull(16)) { obj.DESCUENTO = dr.GetDecimal(16); }
                            if (!dr.IsDBNull(17)) { obj.COSTO_FINANCIERO = dr.GetDecimal(17); }
                            if (!dr.IsDBNull(18)) { obj.VENCIMIENTO = dr.GetDateTime(18); }
                            if (!dr.IsDBNull(19)) { obj.ID_MEDIO_PAGO = dr.GetInt32(19); }
                            if (!dr.IsDBNull(20)) { obj.COD_BARRA_RAPIPAGO = dr.GetString(20); }
                            if (!dr.IsDBNull(21)) { obj.INTERES_MORA = dr.GetDecimal(21); }
                            if (!dr.IsDBNull(22)) { obj.DESC_VENCIMIENTO = dr.GetDecimal(22); }
                            if (!dr.IsDBNull(44)) { obj.NRO_RECIBO_PAGO = dr.GetInt32(44); }
                            if (!dr.IsDBNull(24)) { obj.DIAS_MORA = dr.GetInt32(24); }
                            if (!dr.IsDBNull(25)) { obj.NRO_RECIBO_PAYPERTIC = dr.GetInt32(25); }
                            if (!dr.IsDBNull(26)) { obj.FECHA_ULTIMO_PAGO = dr.GetDateTime(26); }
                            if (!dr.IsDBNull(27)) { obj.PAGO_A_CTA = dr.GetDecimal(27); }
                            if (!dr.IsDBNull(28)) { obj.SALDO_CAPITAL = dr.GetDecimal(28); }
                            if (!dr.IsDBNull(29)) { obj.SALDO_INTERES = dr.GetDecimal(29); }
                            if (!dr.IsDBNull(30)) { obj.AJUSTE_INTERES = dr.GetDecimal(30); }
                            if (!dr.IsDBNull(31)) { obj.OBS_AJUSTE = dr.GetString(31); }
                            if (!dr.IsDBNull(32)) { obj.CAPITAL_PAGADO = dr.GetDecimal(32); }
                            if (!dr.IsDBNull(33)) { obj.INTERES_PAGADO = dr.GetDecimal(33); }
                            if (!dr.IsDBNull(34)) { obj.NRO_PLAN_PAGO = dr.GetInt32(34); }
                            if (!dr.IsDBNull(35)) { obj.ESTADO = dr.GetInt32(35); }
                            if (!dr.IsDBNull(36)) { obj.NRO_CUOTA = dr.GetInt32(36); }
                            if (!dr.IsDBNull(37)) { obj.ID_USUARIO_PAGA = dr.GetInt32(37); }
                            if (!dr.IsDBNull(38)) { obj.ID_USUARIO_ANULA = dr.GetInt32(38); }
                            if (!dr.IsDBNull(39)) { obj.OBS = dr.GetString(39); }


                            if (!dr.IsDBNull(40)) { obj.NOMBRE = dr.GetString(40); }
                            if (!dr.IsDBNull(41)) { obj.TIPO_DOC = dr.GetString(41); }
                            if (!dr.IsDBNull(42)) { obj.NRO_DOC = dr.GetString(42); }
                            if (!dr.IsDBNull(43)) { obj.NRO_CUIT = dr.GetString(43); }

                            obj.TOT_SIN_DESC = obj.MONTO_ORIGINAL +
            obj.INTERES_MORA;

                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> Read_NC_aEmitirManual(int ptovta, long nroCbte)
        {
            try
            {
                string sql = @"SELECT A.*, C.APELLIDO + ', ' + C.NOMBRE AS NOMBRE,
                C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT,
                (SELECT MAX(NRO_RECIBO_PAGO) FROM CTACTE_EXPENSAS X WHERE A.PERIODO = X.PERIODO AND A.NRO_CTA=X.NRO_CTA AND TIPO_MOVIMIENTO = 2),
                (SELECT MAX(FECHA) FROM CTACTE_EXPENSAS X WHERE A.PERIODO = X.PERIODO AND A.NRO_CTA=X.NRO_CTA AND TIPO_MOVIMIENTO = 2)
                FROM CTACTE_EXPENSAS A
                INNER JOIN PERSONAS_X_INMUEBLES B ON
                A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1
                INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID
                INNER JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO
                WHERE A.NRO_CTE=@NRO_CTE AND A.PTO_VTA=@PTO_VTA AND A.TIPO_MOVIMIENTO=1";

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTE", nroCbte);
                    cmd.Parameters.AddWithValue("@PTO_VTA", ptovta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                    CTACTE_EXPENSAS obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new CTACTE_EXPENSAS();
                            if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.TIPO_MOVIMIENTO = dr.GetInt32(2); }
                            if (!dr.IsDBNull(3)) { obj.PERIODO = dr.GetInt32(3); }
                            if (!dr.IsDBNull(4)) { obj.MONTO_ORIGINAL = dr.GetDecimal(4); }
                            if (!dr.IsDBNull(5)) { obj.RECARGO_VENCIMIENTO = dr.GetDecimal(5); }
                            if (!dr.IsDBNull(6)) { obj.DEBE = dr.GetDecimal(6); }
                            if (!dr.IsDBNull(7)) { obj.HABER = dr.GetDecimal(7); }
                            if (!dr.IsDBNull(8)) { obj.SALDO = dr.GetDecimal(8); }
                            if (!dr.IsDBNull(9)) { obj.PTO_VTA = dr.GetInt32(9); }
                            if (!dr.IsDBNull(10)) { obj.NRO_CTE = dr.GetInt64(10); }
                            if (!dr.IsDBNull(11)) { obj.CAE = dr.GetInt64(11); }
                            if (!dr.IsDBNull(12)) { obj.FECHA_CAE = dr.GetDateTime(12); }
                            if (!dr.IsDBNull(13)) { obj.VENC_CAE = dr.GetDateTime(13); }
                            if (!dr.IsDBNull(45)) { obj.FECHA = dr.GetDateTime(45); }
                            if (!dr.IsDBNull(15)) { obj.PAGADO = dr.GetBoolean(15); }
                            if (!dr.IsDBNull(16)) { obj.DESCUENTO = dr.GetDecimal(16); }
                            if (!dr.IsDBNull(17)) { obj.COSTO_FINANCIERO = dr.GetDecimal(17); }
                            if (!dr.IsDBNull(18)) { obj.VENCIMIENTO = dr.GetDateTime(18); }
                            if (!dr.IsDBNull(19)) { obj.ID_MEDIO_PAGO = dr.GetInt32(19); }
                            if (!dr.IsDBNull(20)) { obj.COD_BARRA_RAPIPAGO = dr.GetString(20); }
                            if (!dr.IsDBNull(21)) { obj.INTERES_MORA = dr.GetDecimal(21); }
                            if (!dr.IsDBNull(22)) { obj.DESC_VENCIMIENTO = dr.GetDecimal(22); }
                            if (!dr.IsDBNull(44)) { obj.NRO_RECIBO_PAGO = dr.GetInt32(44); }
                            if (!dr.IsDBNull(24)) { obj.DIAS_MORA = dr.GetInt32(24); }
                            if (!dr.IsDBNull(25)) { obj.NRO_RECIBO_PAYPERTIC = dr.GetInt32(25); }
                            if (!dr.IsDBNull(26)) { obj.FECHA_ULTIMO_PAGO = dr.GetDateTime(26); }
                            if (!dr.IsDBNull(27)) { obj.PAGO_A_CTA = dr.GetDecimal(27); }
                            if (!dr.IsDBNull(28)) { obj.SALDO_CAPITAL = dr.GetDecimal(28); }
                            if (!dr.IsDBNull(29)) { obj.SALDO_INTERES = dr.GetDecimal(29); }
                            if (!dr.IsDBNull(30)) { obj.AJUSTE_INTERES = dr.GetDecimal(30); }
                            if (!dr.IsDBNull(31)) { obj.OBS_AJUSTE = dr.GetString(31); }
                            if (!dr.IsDBNull(32)) { obj.CAPITAL_PAGADO = dr.GetDecimal(32); }
                            if (!dr.IsDBNull(33)) { obj.INTERES_PAGADO = dr.GetDecimal(33); }
                            if (!dr.IsDBNull(34)) { obj.NRO_PLAN_PAGO = dr.GetInt32(34); }
                            if (!dr.IsDBNull(35)) { obj.ESTADO = dr.GetInt32(35); }
                            if (!dr.IsDBNull(36)) { obj.NRO_CUOTA = dr.GetInt32(36); }
                            if (!dr.IsDBNull(37)) { obj.ID_USUARIO_PAGA = dr.GetInt32(37); }
                            if (!dr.IsDBNull(38)) { obj.ID_USUARIO_ANULA = dr.GetInt32(38); }
                            if (!dr.IsDBNull(39)) { obj.OBS = dr.GetString(39); }


                            if (!dr.IsDBNull(40)) { obj.NOMBRE = dr.GetString(40); }
                            if (!dr.IsDBNull(41)) { obj.TIPO_DOC = dr.GetString(41); }
                            if (!dr.IsDBNull(42)) { obj.NRO_DOC = dr.GetString(42); }
                            if (!dr.IsDBNull(43)) { obj.NRO_CUIT = dr.GetString(43); }

                            obj.TOT_SIN_DESC = obj.MONTO_ORIGINAL +
            obj.INTERES_MORA;

                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
         SELECT * FROM CTACTE_EXPENSAS
WHERE PERIODO = 20191100  AND NRO_CTA = 27 AND TIPO_MOVIMIENTO = 2
ORDER BY FECHA DESC

             */
        public static List<CTACTE_EXPENSAS> readPagos(int periodo, int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ' ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO");
                sql.AppendLine("WHERE A.PERIODO = @PERIODO  AND A.NRO_CTA = @NRO_CTA AND A.TIPO_MOVIMIENTO = 2");
                sql.AppendLine("ORDER BY NRO_RECIBO_PAGO ASC");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CTACTE_EXPENSAS read(int periodo, string cuit)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ' ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO");
                sql.AppendLine("WHERE A.PERIODO=@PERIODO AND TIPO_MOVIMIENTO = 1 AND NRO_CUIT = @cuit");
                //sql.AppendLine("AND A.NRO_CTA NOT IN(59, 58, 56, 55, 54, 50,");
                //sql.AppendLine("49,48,47,46,44,43,42,39,26,38,37,36,34,32,31,");
                //sql.AppendLine("30,27,24,22,18,20,19,17,15,14,13,9,12,6,8,7,6,");
                //sql.AppendLine("4,3,1)");
                //sql.AppendLine("123,96,111,115,110,108,89,82,102,104,101,97,91,114,79,93,113,98,99,75,94,95,78,84,92,85,90,83,43,67,69,49,70,59,");
                //sql.AppendLine("73,66,62,56,58,60,44,53,71,61,63,47,54,55,50,46,48,34,32,42,26,38,36,39,37,31,30,27,24,22,20,19,18,17,15,14,13,");
                //sql.AppendLine("12,9,8,7,6,4,3,1)");

                CTACTE_EXPENSAS lst = new CTACTE_EXPENSAS();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@cuit", cuit);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr)[0];
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> read(int periodo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ' ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO");
                sql.AppendLine("WHERE A.PERIODO=@PERIODO AND TIPO_MOVIMIENTO = 1");
                //sql.AppendLine("AND A.NRO_CTA NOT IN(59, 58, 56, 55, 54, 50,");
                //sql.AppendLine("49,48,47,46,44,43,42,39,26,38,37,36,34,32,31,");
                //sql.AppendLine("30,27,24,22,18,20,19,17,15,14,13,9,12,6,8,7,6,");
                //sql.AppendLine("4,3,1)");
                //sql.AppendLine("123,96,111,115,110,108,89,82,102,104,101,97,91,114,79,93,113,98,99,75,94,95,78,84,92,85,90,83,43,67,69,49,70,59,");
                //sql.AppendLine("73,66,62,56,58,60,44,53,71,61,63,47,54,55,50,46,48,34,32,42,26,38,36,39,37,31,30,27,24,22,20,19,18,17,15,14,13,");
                //sql.AppendLine("12,9,8,7,6,4,3,1)");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CTACTE_EXPENSAS> readCtas_email_no_enviados(int periodo)
        {
            try
            {
                string sql = @"SELECT A.*, C.APELLIDO + ' ' + C.NOMBRE AS NOMBRE,
                             C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT
                             FROM CTACTE_EXPENSAS A
                             INNER JOIN PERSONAS_X_INMUEBLES B ON
                             A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1
                             INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID
                             INNER JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO
                             INNER JOIN mail_x_ctas_no_enviados z on z.nro_cta=a.nro_cta
                             WHERE A.PERIODO=@PERIODO AND TIPO_MOVIMIENTO = 1";


                //sql.AppendLine("AND A.NRO_CTA NOT IN(59, 58, 56, 55, 54, 50,");
                //sql.AppendLine("49,48,47,46,44,43,42,39,26,38,37,36,34,32,31,");
                //sql.AppendLine("30,27,24,22,18,20,19,17,15,14,13,9,12,6,8,7,6,");
                //sql.AppendLine("4,3,1)");
                //sql.AppendLine("123,96,111,115,110,108,89,82,102,104,101,97,91,114,79,93,113,98,99,75,94,95,78,84,92,85,90,83,43,67,69,49,70,59,");
                //sql.AppendLine("73,66,62,56,58,60,44,53,71,61,63,47,54,55,50,46,48,34,32,42,26,38,36,39,37,31,30,27,24,22,20,19,18,17,15,14,13,");
                //sql.AppendLine("12,9,8,7,6,4,3,1)");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CTACTE_EXPENSAS> readAsientoExpensa()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ' ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT,");
                sql.AppendLine("CASE A.PERIODO");
                sql.AppendLine("WHEN 20200100 THEN 'Expensas Ordinarias Enero 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20200101 THEN 'Expensas Extra Ordinarias Enero 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20200200 THEN 'Expensas Ordinarias Febrero 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20200201 THEN 'Expensas Extra Ordinarias Febrero 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20200300 THEN 'Expensas Ordinarias Enero 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20200100 THEN 'Expensas Ordinarias Marzo 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20200400 THEN 'Expensas Ordinarias Abril 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20200500 THEN 'Expensas Ordinarias Mayo 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20200600 THEN 'Expensas Ordinarias Junio 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20200700 THEN 'Expensas Ordinarias Julio 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20200800 THEN 'Expensas Ordinarias Agosto 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20200900 THEN 'Expensas Ordinarias Septiembre 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20201000 THEN 'Expensas Ordinarias Octubre 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20201100 THEN 'Expensas Ordinarias Noviembre 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20201200 THEN 'Expensas Ordinarias Diciembre 2020 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20210100 THEN 'Expensas Ordinarias Enero 2021 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20210200 THEN 'Expensas Ordinarias Febrero 2021 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20210300 THEN 'Expensas Ordinarias Marzo 2021 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20210400 THEN 'Expensas Ordinarias Abril 2021 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20210500 THEN 'Expensas Ordinarias Mayo 2021 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20210600 THEN 'Expensas Ordinarias Junio 2021 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20210700 THEN 'Expensas Ordinarias Julio 2021 Cuenta N�: ' +");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20210800 THEN 'Expensas Ordinarias Agosto 2021 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20210900 THEN 'Expensas Ordinarias Septiembre 2021 Cuenta N�: ' + ");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("WHEN 20211000 THEN 'Expensas Ordinarias Octubre 2021 Cuenta N�: ' +");
                sql.AppendLine("CONVERT(VARCHAR(20), A.NRO_CTA)");
                sql.AppendLine("END AS DESCRIPCION");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO");
                sql.AppendLine("WHERE TIPO_MOVIMIENTO = 1 AND A.PERIODO > 20200000");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo3(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*WHERE TIPO_MOVIMIENTO = 1 AND PERIODO = 20200600 AND PAGADO = 1*/

        public static List<CTACTE_EXPENSAS> getDebito(int periodo)
        {
            try
            {
                DAL.CTACTE_EXPENSAS obj = null;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ' ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT, E.CBU,");
                sql.AppendLine("E.BANCO, E.SUCURSAL, E.TIPO_COBIS, E.CUENTA_BANCO, E.IDENTIFICACION");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO");
                sql.AppendLine("INNER JOIN INMUEBLES E ON A.NRO_CTA = E.NRO_CTA AND E.DEBITO_AUTOMATICO = 1");
                sql.AppendLine("WHERE A.PERIODO=@PERIODO AND TIPO_MOVIMIENTO = 1");
                //AND A.NRO_CTA NOT IN (265,268,264,267,260,259,261,258,263,257,262,256,255,254,253,251,");
                //sql.AppendLine("250,249,248,247,246,245,244,241,240,239,238,237,236,235,234,233,232,231,229,228,227,225,222,215,220,216,214,218,");
                //sql.AppendLine("217,219,212,210,184,162,190,151,193,189,175,202,177,204,209,168,176,171,167,158,172,153,157,174,163,160,165,164,");
                //sql.AppendLine("161,156,155,152,141,131,147,150,122,148,135,146,145,149,128,126,127,143,140,139,138,132,130,137,133,129,116,124,");
                //sql.AppendLine("123,96,111,115,110,108,89,82,102,104,101,97,91,114,79,93,113,98,99,75,94,95,78,84,92,85,90,83,43,67,69,49,70,59,");
                //sql.AppendLine("73,66,62,56,58,60,44,53,71,61,63,47,54,55,50,46,48,34,32,42,26,38,36,39,37,31,30,27,24,22,20,19,18,17,15,14,13,");
                //sql.AppendLine("12,9,8,7,6,4,3,1)");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new CTACTE_EXPENSAS();
                            if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.TIPO_MOVIMIENTO = dr.GetInt32(2); }
                            if (!dr.IsDBNull(3)) { obj.PERIODO = dr.GetInt32(3); }
                            if (!dr.IsDBNull(4)) { obj.MONTO_ORIGINAL = dr.GetDecimal(4); }
                            if (!dr.IsDBNull(5)) { obj.RECARGO_VENCIMIENTO = dr.GetDecimal(5); }
                            if (!dr.IsDBNull(6)) { obj.DEBE = dr.GetDecimal(6); }
                            if (!dr.IsDBNull(7)) { obj.HABER = dr.GetDecimal(7); }
                            if (!dr.IsDBNull(8)) { obj.SALDO = dr.GetDecimal(8); }
                            if (!dr.IsDBNull(9)) { obj.PTO_VTA = dr.GetInt32(9); }
                            if (!dr.IsDBNull(10)) { obj.NRO_CTE = dr.GetInt64(10); }
                            if (!dr.IsDBNull(11)) { obj.CAE = dr.GetInt64(11); }
                            if (!dr.IsDBNull(12)) { obj.FECHA_CAE = dr.GetDateTime(12); }
                            if (!dr.IsDBNull(13)) { obj.VENC_CAE = dr.GetDateTime(13); }
                            if (!dr.IsDBNull(14)) { obj.FECHA = dr.GetDateTime(14); }
                            if (!dr.IsDBNull(15)) { obj.PAGADO = dr.GetBoolean(15); }
                            if (!dr.IsDBNull(16)) { obj.DESCUENTO = dr.GetDecimal(16); }
                            if (!dr.IsDBNull(17)) { obj.COSTO_FINANCIERO = dr.GetDecimal(17); }
                            if (!dr.IsDBNull(18)) { obj.VENCIMIENTO = dr.GetDateTime(18); }
                            if (!dr.IsDBNull(19)) { obj.ID_MEDIO_PAGO = dr.GetInt32(19); }
                            if (!dr.IsDBNull(20)) { obj.COD_BARRA_RAPIPAGO = dr.GetString(20); }
                            if (!dr.IsDBNull(21)) { obj.INTERES_MORA = dr.GetDecimal(21); }
                            if (!dr.IsDBNull(22)) { obj.DESC_VENCIMIENTO = dr.GetDecimal(22); }
                            if (!dr.IsDBNull(23)) { obj.NRO_RECIBO_PAGO = dr.GetInt32(23); }
                            if (!dr.IsDBNull(24)) { obj.DIAS_MORA = dr.GetInt32(24); }
                            if (!dr.IsDBNull(25)) { obj.NRO_RECIBO_PAYPERTIC = dr.GetInt32(25); }
                            if (!dr.IsDBNull(26)) { obj.FECHA_ULTIMO_PAGO = dr.GetDateTime(26); }
                            if (!dr.IsDBNull(27)) { obj.PAGO_A_CTA = dr.GetDecimal(27); }
                            if (!dr.IsDBNull(28)) { obj.SALDO_CAPITAL = dr.GetDecimal(28); }
                            if (!dr.IsDBNull(29)) { obj.SALDO_INTERES = dr.GetDecimal(29); }
                            if (!dr.IsDBNull(30)) { obj.AJUSTE_INTERES = dr.GetDecimal(30); }
                            if (!dr.IsDBNull(31)) { obj.OBS_AJUSTE = dr.GetString(31); }
                            if (!dr.IsDBNull(32)) { obj.CAPITAL_PAGADO = dr.GetDecimal(32); }
                            if (!dr.IsDBNull(33)) { obj.INTERES_PAGADO = dr.GetDecimal(33); }
                            if (!dr.IsDBNull(34)) { obj.NRO_PLAN_PAGO = dr.GetInt32(34); }
                            if (!dr.IsDBNull(35)) { obj.ESTADO = dr.GetInt32(35); }
                            if (!dr.IsDBNull(36)) { obj.NRO_CUOTA = dr.GetInt32(36); }
                            if (!dr.IsDBNull(37)) { obj.ID_USUARIO_PAGA = dr.GetInt32(37); }
                            if (!dr.IsDBNull(38)) { obj.ID_USUARIO_ANULA = dr.GetInt32(38); }
                            if (!dr.IsDBNull(39)) { obj.OBS = dr.GetString(39); }


                            if (!dr.IsDBNull(40)) { obj.NOMBRE = dr.GetString(40); }
                            if (!dr.IsDBNull(41)) { obj.TIPO_DOC = dr.GetString(41); }
                            if (!dr.IsDBNull(42)) { obj.NRO_DOC = dr.GetString(42); }
                            if (!dr.IsDBNull(43)) { obj.NRO_CUIT = dr.GetString(43); }
                            if (!dr.IsDBNull(44)) { obj.CBU = dr.GetString(44); }

                            if (!dr.IsDBNull(45)) { obj.BANCO = dr.GetString(45); }
                            if (!dr.IsDBNull(46)) { obj.SUCURSAL = dr.GetString(46); }
                            if (!dr.IsDBNull(47)) { obj.TIPO_COBIS = dr.GetString(47); }
                            if (!dr.IsDBNull(48)) { obj.CUENTA_BANCO = dr.GetString(48); }
                            if (!dr.IsDBNull(49)) { obj.IDENTIFICACION = dr.GetString(49); }


                            obj.TOT_SIN_DESC = obj.MONTO_ORIGINAL +
            obj.INTERES_MORA;

                            lst.Add(obj);
                        }

                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> read(int periodo, int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ', ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO");
                sql.AppendLine("WHERE A.PERIODO=@PERIODO AND A.NRO_CTA=@NRO_CTA");
                sql.AppendLine("AND (A.NRO_PLAN_PAGO IS NULL OR A.NRO_PLAN_PAGO = 0)");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> read2(int periodo, int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ', ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("FULL JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO");
                sql.AppendLine("WHERE A.PERIODO=@PERIODO AND A.NRO_CTA=@NRO_CTA");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool getByPeriodo(
            int periodo, int nro_cta)
        {
            try
            {
                bool ret = false;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE A.PERIODO=@PERIODO AND A.TIPO_MOVIMIENTO = 100 AND NRO_CTA=@NRO_CTA");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nro_cta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    if (lst.Count > 0)
                        ret = true;
                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool getByPeriodo2(
            int periodo, int nro_cta)
        {
            try
            {
                bool ret = false;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE A.PERIODO=@PERIODO AND A.TIPO_MOVIMIENTO = 21 AND NRO_CTA=@NRO_CTA");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nro_cta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    if (lst.Count > 0)
                        ret = true;
                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool getByPeriodo3(
                    int periodo, int nro_cta)
        {
            try
            {
                bool ret = false;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE A.PERIODO=@PERIODO AND A.TIPO_MOVIMIENTO = 31 AND NRO_CTA=@NRO_CTA");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nro_cta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    if (lst.Count > 0)
                        ret = true;
                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> readDeudaCorregido(int periodo, int nroCta, int tipoMov)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ', ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("FULL JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO");
                sql.AppendLine("WHERE A.PERIODO=@PERIODO AND A.NRO_CTA=@NRO_CTA");
                sql.AppendLine("AND TIPO_MOVIMIENTO IN (2, @TIPO_MOVIMIENTO)");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", tipoMov);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> readPlan(int periodo, int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ', ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO");
                sql.AppendLine("WHERE A.PERIODO=@PERIODO AND A.NRO_CTA=@NRO_CTA");
                sql.AppendLine("AND (A.NRO_PLAN_PAGO IS NOT NULL OR A.NRO_PLAN_PAGO <> 0)");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> readCtasPlan(int nroPlan, int tipoMov)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ', ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("WHERE A.NRO_PLAN_PAGO=@NRO_PLAN_PAGO AND TIPO_MOVIMIENTO = @TIPO_MOVIMIENTO");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_PLAN_PAGO", nroPlan);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", tipoMov);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> readPlan(int nroPlan)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ', ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("FULL JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO");
                sql.AppendLine("WHERE NRO_PLAN_PAGO = @NRO_PLAN_PAGO AND TIPO_MOVIMIENTO = 3");
                sql.AppendLine("ORDER BY NRO_CTA, PERIODO, TIPO_MOVIMIENTO");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NRO_PLAN_PAGO", nroPlan);
                    cmd.CommandText = sql.ToString();

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> read()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ', ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO");
                sql.AppendLine("ORDER BY NRO_CTA, PERIODO, TIPO_MOVIMIENTO");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CTACTE_EXPENSAS> actualizaFacturas(Int64 periodo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE PERIODO = @PERIODO AND");
                sql.AppendLine("TIPO_MOVIMIENTO = 1 AND ID NOT IN");
                sql.AppendLine("(SELECT ID_CTACTE FROM FACTURAS_X_EXPENSA)");


                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.CommandText = sql.ToString();

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<CTACTE_EXPENSAS> getByPayPerTic(int reciboPayPerTic)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ', ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("FULL JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("FULL JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO");
                sql.AppendLine("WHERE NRO_RECIBO_PAYPERTIC=@NRO_RECIBO_PAYPERTIC AND TIPO_MOVIMIENTO = 1");
                sql.AppendLine("ORDER BY NRO_CTA, PERIODO, TIPO_MOVIMIENTO");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAYPERTIC", reciboPayPerTic);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> readAnio(int anio)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, C.APELLIDO + ', ' + C.NOMBRE AS NOMBRE,");
                sql.AppendLine("C.TIPO_DOC, C.NRO_DOC, C.NRO_CUIT");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON");
                sql.AppendLine("A.NRO_CTA = B.NRO_CTA AND B.RESPONSABLE_FACTURACION = 1");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA = C.ID");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS D ON D.PERIODO = A.PERIODO");
                //sql.AppendLine("WHERE SUBSTRING(CONVERT(VARCHAR,a.PERIODO), 1, 4)=@PERIODO");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", anio);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> readCta(int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.DESCRIPCION FROM CTACTE_EXPENSAS A");
                sql.AppendLine("FULL JOIN MEDIOS_PAGO B ON A.ID_MEDIO_PAGO = B.ID");
                sql.AppendLine("FULL JOIN LIQUIDACION_EXPENSAS C ON A.PERIODO = C.PERIODO");
                sql.AppendLine("WHERE NRO_CTA=@NRO_CTA AND");
                sql.AppendLine("(((TIPO_MOVIMIENTO IN (1,21,100)) AND (NRO_PLAN_PAGO IS NULL OR NRO_PLAN_PAGO = 0)) OR TIPO_MOVIMIENTO = 3) AND CAE IS NOT NULL");
                // ");
                sql.AppendLine("ORDER BY PERIODO DESC, TIPO_MOVIMIENTO ASC");


                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    CTACTE_EXPENSAS obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new CTACTE_EXPENSAS();
                            if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.TIPO_MOVIMIENTO = dr.GetInt32(2); }
                            if (!dr.IsDBNull(3)) { obj.PERIODO = dr.GetInt32(3); }
                            if (!dr.IsDBNull(4)) { obj.MONTO_ORIGINAL = dr.GetDecimal(4); }
                            if (!dr.IsDBNull(5)) { obj.RECARGO_VENCIMIENTO = dr.GetDecimal(5); }
                            if (!dr.IsDBNull(6)) { obj.DEBE = dr.GetDecimal(6); }
                            if (!dr.IsDBNull(7)) { obj.HABER = dr.GetDecimal(7); }
                            if (!dr.IsDBNull(8)) { obj.SALDO = dr.GetDecimal(8); }
                            if (!dr.IsDBNull(9)) { obj.PTO_VTA = dr.GetInt32(9); }
                            if (!dr.IsDBNull(10)) { obj.NRO_CTE = dr.GetInt64(10); }
                            if (!dr.IsDBNull(11)) { obj.CAE = dr.GetInt64(11); }
                            if (!dr.IsDBNull(12)) { obj.FECHA_CAE = dr.GetDateTime(12); }
                            if (!dr.IsDBNull(13)) { obj.VENC_CAE = dr.GetDateTime(13); }
                            if (!dr.IsDBNull(14)) { obj.FECHA = dr.GetDateTime(14); }
                            if (!dr.IsDBNull(15)) { obj.PAGADO = dr.GetBoolean(15); }
                            if (!dr.IsDBNull(16)) { obj.DESCUENTO = dr.GetDecimal(16); }
                            if (!dr.IsDBNull(17)) { obj.COSTO_FINANCIERO = dr.GetDecimal(17); }
                            if (!dr.IsDBNull(18)) { obj.VENCIMIENTO = dr.GetDateTime(18); }
                            if (!dr.IsDBNull(19)) { obj.ID_MEDIO_PAGO = dr.GetInt32(19); }
                            if (!dr.IsDBNull(20)) { obj.COD_BARRA_RAPIPAGO = dr.GetString(20); }
                            if (!dr.IsDBNull(21)) { obj.INTERES_MORA = dr.GetDecimal(21); }
                            if (!dr.IsDBNull(22)) { obj.DESC_VENCIMIENTO = dr.GetDecimal(22); }
                            if (!dr.IsDBNull(23)) { obj.NRO_RECIBO_PAGO = dr.GetInt32(23); }
                            if (!dr.IsDBNull(24)) { obj.DIAS_MORA = dr.GetInt32(24); }
                            if (!dr.IsDBNull(25)) { obj.NRO_RECIBO_PAYPERTIC = dr.GetInt32(25); }
                            if (!dr.IsDBNull(26)) { obj.FECHA_ULTIMO_PAGO = dr.GetDateTime(26); }
                            if (!dr.IsDBNull(27)) { obj.PAGO_A_CTA = dr.GetDecimal(27); }
                            if (!dr.IsDBNull(28)) { obj.SALDO_CAPITAL = dr.GetDecimal(28); }
                            if (!dr.IsDBNull(29)) { obj.SALDO_INTERES = dr.GetDecimal(29); }
                            if (!dr.IsDBNull(30)) { obj.AJUSTE_INTERES = dr.GetDecimal(30); }
                            if (!dr.IsDBNull(31)) { obj.OBS_AJUSTE = dr.GetString(31); }
                            if (!dr.IsDBNull(32)) { obj.CAPITAL_PAGADO = dr.GetDecimal(32); }
                            if (!dr.IsDBNull(33)) { obj.INTERES_PAGADO = dr.GetDecimal(33); }
                            if (!dr.IsDBNull(34)) { obj.NRO_PLAN_PAGO = dr.GetInt32(34); }
                            if (!dr.IsDBNull(35)) { obj.ESTADO = dr.GetInt32(35); }
                            if (!dr.IsDBNull(36)) { obj.NRO_CUOTA = dr.GetInt32(36); }
                            if (!dr.IsDBNull(37)) { obj.ID_USUARIO_PAGA = dr.GetInt32(37); }
                            if (!dr.IsDBNull(38)) { obj.ID_USUARIO_ANULA = dr.GetInt32(38); }
                            if (!dr.IsDBNull(39)) { obj.OBS = dr.GetString(39); }


                            if (!dr.IsDBNull(40)) { obj.MEDIO_PAGO = dr.GetString(40); }

                            obj.TOT_SIN_DESC = obj.MONTO_ORIGINAL +
                                obj.INTERES_MORA;

                            if (obj.NRO_RECIBO_PAGO != 0)
                            {
                                obj.PAGO_CUENTA = getPagoCta(obj.PERIODO, obj.NRO_CTA);
                            }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static decimal getPagoCta(int periodo, int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT ISNULL(SUM(HABER), 0) FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE PERIODO = @PERIODO AND TIPO_MOVIMIENTO = 2 AND NRO_CTA = @NRO_CTA");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int getPagos(int periodo, int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT COUNT(*) FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE PERIODO = @PERIODO AND TIPO_MOVIMIENTO = 2 AND NRO_CTA = @NRO_CTA");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool libreDeuda(int nroCta)
        {
            try
            {
                bool ret = false;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS A ");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS B ON A.PERIODO=B.PERIODO");
                sql.AppendLine("WHERE A.PAGADO=0 AND ISNULL(NRO_PLAN_PAGO,0)=0 AND CONVERT(DATE, B.VENCIMIENTO_3) <= CONVERT(DATE, GETDATE())");
                sql.AppendLine("AND NRO_CTA = @NRO_CTA");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                        ret = true;
                    return ret;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> getByRecibo(int nroRecibo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.DESCRIPCION, C.PTO_VTA, C.NRO_CTE, C.VENCIMIENTO FROM CTACTE_EXPENSAS A");
                sql.AppendLine("FULL JOIN MEDIOS_PAGO B ON A.ID_MEDIO_PAGO = B.ID");
                sql.AppendLine("INNER JOIN CTACTE_EXPENSAS C ON A.NRO_CTA=C.NRO_CTA AND A.PERIODO=C.PERIODO AND C.TIPO_MOVIMIENTO = 2");
                sql.AppendLine("WHERE A.NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO");
                sql.AppendLine("ORDER BY PERIODO DESC, TIPO_MOVIMIENTO ASC");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", nroRecibo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    CTACTE_EXPENSAS obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new CTACTE_EXPENSAS();
                            if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.TIPO_MOVIMIENTO = dr.GetInt32(2); }
                            if (!dr.IsDBNull(3)) { obj.PERIODO = dr.GetInt32(3); }
                            if (!dr.IsDBNull(4)) { obj.MONTO_ORIGINAL = dr.GetDecimal(4); }
                            if (!dr.IsDBNull(5)) { obj.RECARGO_VENCIMIENTO = dr.GetDecimal(5); }
                            if (!dr.IsDBNull(6)) { obj.DEBE = dr.GetDecimal(6); }
                            if (!dr.IsDBNull(7)) { obj.HABER = dr.GetDecimal(7); }
                            if (!dr.IsDBNull(8)) { obj.SALDO = dr.GetDecimal(8); }
                            if (!dr.IsDBNull(9)) { obj.PTO_VTA = dr.GetInt32(9); }
                            if (!dr.IsDBNull(10)) { obj.NRO_CTE = dr.GetInt64(10); }
                            if (!dr.IsDBNull(11)) { obj.CAE = dr.GetInt64(11); }
                            if (!dr.IsDBNull(12)) { obj.FECHA_CAE = dr.GetDateTime(12); }
                            if (!dr.IsDBNull(13)) { obj.VENC_CAE = dr.GetDateTime(13); }
                            if (!dr.IsDBNull(14)) { obj.FECHA = dr.GetDateTime(14); }
                            if (!dr.IsDBNull(15)) { obj.PAGADO = dr.GetBoolean(15); }
                            if (!dr.IsDBNull(16)) { obj.DESCUENTO = dr.GetDecimal(16); }
                            if (!dr.IsDBNull(17)) { obj.COSTO_FINANCIERO = dr.GetDecimal(17); }
                            if (!dr.IsDBNull(18)) { obj.VENCIMIENTO = dr.GetDateTime(18); }
                            if (!dr.IsDBNull(19)) { obj.ID_MEDIO_PAGO = dr.GetInt32(19); }
                            if (!dr.IsDBNull(20)) { obj.COD_BARRA_RAPIPAGO = dr.GetString(20); }
                            if (!dr.IsDBNull(21)) { obj.INTERES_MORA = dr.GetDecimal(21); }
                            if (!dr.IsDBNull(22)) { obj.DESC_VENCIMIENTO = dr.GetDecimal(22); }
                            if (!dr.IsDBNull(23)) { obj.NRO_RECIBO_PAGO = dr.GetInt32(23); }
                            if (!dr.IsDBNull(24)) { obj.DIAS_MORA = dr.GetInt32(24); }
                            if (!dr.IsDBNull(25)) { obj.NRO_RECIBO_PAYPERTIC = dr.GetInt32(25); }
                            if (!dr.IsDBNull(26)) { obj.FECHA_ULTIMO_PAGO = dr.GetDateTime(26); }
                            if (!dr.IsDBNull(27)) { obj.PAGO_A_CTA = dr.GetDecimal(27); }
                            if (!dr.IsDBNull(28)) { obj.SALDO_CAPITAL = dr.GetDecimal(28); }
                            if (!dr.IsDBNull(29)) { obj.SALDO_INTERES = dr.GetDecimal(29); }
                            if (!dr.IsDBNull(30)) { obj.AJUSTE_INTERES = dr.GetDecimal(30); }
                            if (!dr.IsDBNull(31)) { obj.OBS_AJUSTE = dr.GetString(31); }
                            if (!dr.IsDBNull(32)) { obj.CAPITAL_PAGADO = dr.GetDecimal(32); }
                            if (!dr.IsDBNull(33)) { obj.INTERES_PAGADO = dr.GetDecimal(33); }
                            if (!dr.IsDBNull(34)) { obj.NRO_PLAN_PAGO = dr.GetInt32(34); }
                            if (!dr.IsDBNull(35)) { obj.ESTADO = dr.GetInt32(35); }
                            if (!dr.IsDBNull(36)) { obj.NRO_CUOTA = dr.GetInt32(36); }
                            if (!dr.IsDBNull(37)) { obj.ID_USUARIO_PAGA = dr.GetInt32(37); }
                            if (!dr.IsDBNull(38)) { obj.ID_USUARIO_ANULA = dr.GetInt32(38); }
                            if (!dr.IsDBNull(39)) { obj.OBS = dr.GetString(39); }


                            if (!dr.IsDBNull(40)) { obj.MEDIO_PAGO = dr.GetString(40); }
                            if (!dr.IsDBNull(41)) { obj.PTO_VTA = dr.GetInt32(41); }
                            if (!dr.IsDBNull(42)) { obj.NRO_CTE = dr.GetInt64(42); }
                            if (!dr.IsDBNull(43)) { obj.VENCIMIENTO = dr.GetDateTime(43); }

                            obj.FACTURA = string.Format("{0}-{1}",
                                obj.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                obj.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));

                            obj.PERIODOMAQUILLADO = string.Format("{0}-{1}/{2}",
                                obj.PERIODO.ToString().Substring(0, 4),
                                obj.PERIODO.ToString().Substring(4, 2),
                                obj.PERIODO.ToString().Substring(6, 2));

                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> getByRecibo2(int nroRecibo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO AND TIPO_MOVIMIENTO = 2");
                sql.AppendLine("ORDER BY PERIODO DESC, TIPO_MOVIMIENTO ASC");

                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", nroRecibo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    CTACTE_EXPENSAS obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new CTACTE_EXPENSAS();
                            if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.TIPO_MOVIMIENTO = dr.GetInt32(2); }
                            if (!dr.IsDBNull(3)) { obj.PERIODO = dr.GetInt32(3); }
                            if (!dr.IsDBNull(4)) { obj.MONTO_ORIGINAL = dr.GetDecimal(4); }
                            if (!dr.IsDBNull(5)) { obj.RECARGO_VENCIMIENTO = dr.GetDecimal(5); }
                            if (!dr.IsDBNull(6)) { obj.DEBE = dr.GetDecimal(6); }
                            if (!dr.IsDBNull(7)) { obj.HABER = dr.GetDecimal(7); }
                            if (!dr.IsDBNull(8)) { obj.SALDO = dr.GetDecimal(8); }
                            if (!dr.IsDBNull(9)) { obj.PTO_VTA = dr.GetInt32(9); }
                            if (!dr.IsDBNull(10)) { obj.NRO_CTE = dr.GetInt64(10); }
                            if (!dr.IsDBNull(11)) { obj.CAE = dr.GetInt64(11); }
                            if (!dr.IsDBNull(12)) { obj.FECHA_CAE = dr.GetDateTime(12); }
                            if (!dr.IsDBNull(13)) { obj.VENC_CAE = dr.GetDateTime(13); }
                            if (!dr.IsDBNull(14)) { obj.FECHA = dr.GetDateTime(14); }
                            if (!dr.IsDBNull(15)) { obj.PAGADO = dr.GetBoolean(15); }
                            if (!dr.IsDBNull(16)) { obj.DESCUENTO = dr.GetDecimal(16); }
                            if (!dr.IsDBNull(17)) { obj.COSTO_FINANCIERO = dr.GetDecimal(17); }
                            if (!dr.IsDBNull(18)) { obj.VENCIMIENTO = dr.GetDateTime(18); }
                            if (!dr.IsDBNull(19)) { obj.ID_MEDIO_PAGO = dr.GetInt32(19); }
                            if (!dr.IsDBNull(20)) { obj.COD_BARRA_RAPIPAGO = dr.GetString(20); }
                            if (!dr.IsDBNull(21)) { obj.INTERES_MORA = dr.GetDecimal(21); }
                            if (!dr.IsDBNull(22)) { obj.DESC_VENCIMIENTO = dr.GetDecimal(22); }
                            if (!dr.IsDBNull(23)) { obj.NRO_RECIBO_PAGO = dr.GetInt32(23); }
                            if (!dr.IsDBNull(24)) { obj.DIAS_MORA = dr.GetInt32(24); }
                            if (!dr.IsDBNull(25)) { obj.NRO_RECIBO_PAYPERTIC = dr.GetInt32(25); }
                            if (!dr.IsDBNull(26)) { obj.FECHA_ULTIMO_PAGO = dr.GetDateTime(26); }
                            if (!dr.IsDBNull(27)) { obj.PAGO_A_CTA = dr.GetDecimal(27); }
                            if (!dr.IsDBNull(28)) { obj.SALDO_CAPITAL = dr.GetDecimal(28); }
                            if (!dr.IsDBNull(29)) { obj.SALDO_INTERES = dr.GetDecimal(29); }
                            if (!dr.IsDBNull(30)) { obj.AJUSTE_INTERES = dr.GetDecimal(30); }
                            if (!dr.IsDBNull(31)) { obj.OBS_AJUSTE = dr.GetString(31); }
                            if (!dr.IsDBNull(32)) { obj.CAPITAL_PAGADO = dr.GetDecimal(32); }
                            if (!dr.IsDBNull(33)) { obj.INTERES_PAGADO = dr.GetDecimal(33); }
                            if (!dr.IsDBNull(34)) { obj.NRO_PLAN_PAGO = dr.GetInt32(34); }
                            if (!dr.IsDBNull(35)) { obj.ESTADO = dr.GetInt32(35); }
                            if (!dr.IsDBNull(36)) { obj.NRO_CUOTA = dr.GetInt32(36); }
                            if (!dr.IsDBNull(37)) { obj.ID_USUARIO_PAGA = dr.GetInt32(37); }
                            if (!dr.IsDBNull(38)) { obj.ID_USUARIO_ANULA = dr.GetInt32(38); }
                            if (!dr.IsDBNull(39)) { obj.OBS = dr.GetString(39); }
                            obj.FACTURA = string.Format("{0}-{1}",
                                obj.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                obj.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));

                            if (obj.NRO_PLAN_PAGO == 0)
                                obj.PERIODOMAQUILLADO = UTILS.getNombrePeriodo(obj.PERIODO,
                                    obj.NRO_CTA);
                            else
                                obj.PERIODOMAQUILLADO = string.Format("PLAN DE PAGO {0} - CUOTA: {1}",
                                    obj.NRO_PLAN_PAGO, obj.NRO_CUOTA);
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> readCtaDeuda(int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE NRO_CTA=@NRO_CTA");
                sql.AppendLine("AND ((TIPO_MOVIMIENTO = 1 AND (NRO_PLAN_PAGO IS NULL OR NRO_PLAN_PAGO = 0)) OR TIPO_MOVIMIENTO = 3) AND PAGADO = 0 AND CAE IS NOT NULL");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE NRO_CTA=@NRO_CTA");
                sql.AppendLine("AND (TIPO_MOVIMIENTO = 100 AND (NRO_PLAN_PAGO IS NULL OR NRO_PLAN_PAGO = 0)) AND PAGADO = 0 AND CAE IS NOT NULL");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE NRO_CTA=@NRO_CTA");
                sql.AppendLine("AND (TIPO_MOVIMIENTO = 21 AND (NRO_PLAN_PAGO IS NULL OR NRO_PLAN_PAGO = 0)) AND PAGADO = 0 AND CAE IS NOT NULL");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE NRO_CTA=@NRO_CTA");
                sql.AppendLine("AND (TIPO_MOVIMIENTO = 12 AND (NRO_PLAN_PAGO IS NULL OR NRO_PLAN_PAGO = 0)) AND PAGADO = 0 AND CAE IS NOT NULL");
                sql.AppendLine("ORDER BY PERIODO DESC");
                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> readCtaDeuda2(int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE NRO_CTA=@NRO_CTA");
                sql.AppendLine("AND ((TIPO_MOVIMIENTO = 1 AND (NRO_PLAN_PAGO IS NULL OR NRO_PLAN_PAGO = 0)) OR TIPO_MOVIMIENTO = 3) AND PAGADO = 0 AND CAE IS NOT NULL");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE NRO_CTA=@NRO_CTA");
                sql.AppendLine("AND (TIPO_MOVIMIENTO = 100 AND (NRO_PLAN_PAGO IS NULL OR NRO_PLAN_PAGO = 0)) AND PAGADO = 0 AND CAE IS NOT NULL");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE NRO_CTA=@NRO_CTA");
                sql.AppendLine("AND (TIPO_MOVIMIENTO = 21 AND (NRO_PLAN_PAGO IS NULL OR NRO_PLAN_PAGO = 0)) AND PAGADO = 0 AND CAE IS NOT NULL");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE NRO_CTA=@NRO_CTA");
                sql.AppendLine("AND (TIPO_MOVIMIENTO = 12 AND (NRO_PLAN_PAGO IS NULL OR NRO_PLAN_PAGO = 0)) AND PAGADO = 0 AND CAE IS NOT NULL");
                sql.AppendLine("ORDER BY PERIODO DESC");
                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_EXPENSAS> readCtaDeudaWeb(int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE NRO_CTA=@NRO_CTA");
                sql.AppendLine("AND ((TIPO_MOVIMIENTO = 1 AND (NRO_PLAN_PAGO IS NULL OR NRO_PLAN_PAGO = 0)) OR TIPO_MOVIMIENTO = 3) AND PAGADO = 0 AND CAE IS NOT NULL");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE NRO_CTA=@NRO_CTA");
                sql.AppendLine("AND (TIPO_MOVIMIENTO = 100 AND (NRO_PLAN_PAGO IS NULL OR NRO_PLAN_PAGO = 0)) AND PAGADO = 0 AND CAE IS NOT NULL");
                sql.AppendLine("ORDER BY PERIODO DESC");
                List<CTACTE_EXPENSAS> lst = new List<CTACTE_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CTACTE_EXPENSAS getByComp(string comp)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS WHERE");
                sql.AppendLine("RIGHT(REPLICATE('0', 4)+ CAST(PTO_VTA AS VARCHAR(4)), 4) + '-' +");
                sql.AppendLine("RIGHT(REPLICATE('0', 8) + CAST(NRO_CTE AS VARCHAR(8)), 8) = @NROCOMP");
                CTACTE_EXPENSAS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NROCOMP", comp);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CTACTE_EXPENSAS> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CTACTE_EXPENSAS getByPk(int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS WHERE");
                sql.AppendLine("ID = @ID");
                CTACTE_EXPENSAS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CTACTE_EXPENSAS> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CTACTE_EXPENSAS getByCuitResponsable(string cuit)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON A.NRO_CTA=B.NRO_CTA AND B.RESPONSABLE_FACTURACION=1");
                sql.AppendLine("INNER JOIN PERSONAS C ON C.ID=B.ID_PERSONA");
                sql.AppendLine("WHERE C.NRO_CUIT = @NRO_CUIT AND PERIODO = 20200700");
                CTACTE_EXPENSAS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CUIT", cuit);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CTACTE_EXPENSAS> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CTACTE_EXPENSAS getByPk2(int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CTACTE_EXPENSAS WHERE");
                sql.AppendLine("ID = @ID");
                CTACTE_EXPENSAS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new CTACTE_EXPENSAS();
                            if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.TIPO_MOVIMIENTO = dr.GetInt32(2); }
                            if (!dr.IsDBNull(3)) { obj.PERIODO = dr.GetInt32(3); }
                            if (!dr.IsDBNull(4)) { obj.MONTO_ORIGINAL = dr.GetDecimal(4); }
                            if (!dr.IsDBNull(5)) { obj.RECARGO_VENCIMIENTO = dr.GetDecimal(5); }
                            if (!dr.IsDBNull(6)) { obj.DEBE = dr.GetDecimal(6); }
                            if (!dr.IsDBNull(7)) { obj.HABER = dr.GetDecimal(7); }
                            if (!dr.IsDBNull(8)) { obj.SALDO = dr.GetDecimal(8); }
                            if (!dr.IsDBNull(9)) { obj.PTO_VTA = dr.GetInt32(9); }
                            if (!dr.IsDBNull(10)) { obj.NRO_CTE = dr.GetInt64(10); }
                            if (!dr.IsDBNull(11)) { obj.CAE = dr.GetInt64(11); }
                            if (!dr.IsDBNull(12)) { obj.FECHA_CAE = dr.GetDateTime(12); }
                            if (!dr.IsDBNull(13)) { obj.VENC_CAE = dr.GetDateTime(13); }
                            if (!dr.IsDBNull(14)) { obj.FECHA = dr.GetDateTime(14); }
                            if (!dr.IsDBNull(15)) { obj.PAGADO = dr.GetBoolean(15); }
                            if (!dr.IsDBNull(16)) { obj.DESCUENTO = dr.GetDecimal(16); }
                            if (!dr.IsDBNull(17)) { obj.COSTO_FINANCIERO = dr.GetDecimal(17); }
                            if (!dr.IsDBNull(18)) { obj.VENCIMIENTO = dr.GetDateTime(18); }
                            if (!dr.IsDBNull(19)) { obj.ID_MEDIO_PAGO = dr.GetInt32(19); }
                            if (!dr.IsDBNull(20)) { obj.COD_BARRA_RAPIPAGO = dr.GetString(20); }
                            if (!dr.IsDBNull(21)) { obj.INTERES_MORA = dr.GetDecimal(21); }
                            if (!dr.IsDBNull(22)) { obj.DESC_VENCIMIENTO = dr.GetDecimal(22); }
                            if (!dr.IsDBNull(23)) { obj.NRO_RECIBO_PAGO = dr.GetInt32(23); }
                            if (!dr.IsDBNull(24)) { obj.DIAS_MORA = dr.GetInt32(24); }
                            if (!dr.IsDBNull(25)) { obj.NRO_RECIBO_PAYPERTIC = dr.GetInt32(25); }
                            if (!dr.IsDBNull(26)) { obj.FECHA_ULTIMO_PAGO = dr.GetDateTime(26); }
                            if (!dr.IsDBNull(27)) { obj.PAGO_A_CTA = dr.GetDecimal(27); }
                            if (!dr.IsDBNull(28)) { obj.SALDO_CAPITAL = dr.GetDecimal(28); }
                            if (!dr.IsDBNull(29)) { obj.SALDO_INTERES = dr.GetDecimal(29); }
                            if (!dr.IsDBNull(30)) { obj.AJUSTE_INTERES = dr.GetDecimal(30); }
                            if (!dr.IsDBNull(31)) { obj.OBS_AJUSTE = dr.GetString(31); }
                            if (!dr.IsDBNull(32)) { obj.CAPITAL_PAGADO = dr.GetDecimal(32); }
                            if (!dr.IsDBNull(33)) { obj.INTERES_PAGADO = dr.GetDecimal(33); }
                            if (!dr.IsDBNull(34)) { obj.NRO_PLAN_PAGO = dr.GetInt32(34); }
                            if (!dr.IsDBNull(35)) { obj.ESTADO = dr.GetInt32(35); }
                            if (!dr.IsDBNull(36)) { obj.NRO_CUOTA = dr.GetInt32(36); }
                            if (!dr.IsDBNull(37)) { obj.ID_USUARIO_PAGA = dr.GetInt32(37); }
                            if (!dr.IsDBNull(38)) { obj.ID_USUARIO_ANULA = dr.GetInt32(38); }
                            if (!dr.IsDBNull(39)) { obj.OBS = dr.GetString(39); }
                            obj.TOT_SIN_DESC = obj.MONTO_ORIGINAL +
            obj.INTERES_MORA;

                            if (obj.PERIODO != 20190100)
                            {
                                string me, mes = string.Empty;
                                me = obj.PERIODO.ToString().Substring(4, 2);
                                switch (me)
                                {
                                    case "01":
                                        mes = "Enero";
                                        break;
                                    case "02":
                                        mes = "Febrero";
                                        break;
                                    case "03":
                                        mes = "Marzo";
                                        break;
                                    case "04":
                                        mes = "Abril";
                                        break;
                                    case "05":
                                        mes = "Mayo";
                                        break;
                                    case "06":
                                        mes = "Junio";
                                        break;
                                    case "07":
                                        mes = "Julio";
                                        break;
                                    case "08":
                                        mes = "Agosto";
                                        break;
                                    case "09":
                                        mes = "Septiembre";
                                        break;
                                    case "10":
                                        mes = "Octubre";
                                        break;
                                    case "11":
                                        mes = "Noviembre";
                                        break;
                                    case "12":
                                        mes = "Diciembre";
                                        break;
                                    default:
                                        break;
                                }
                                if (obj.PERIODO.ToString().Substring(6, 2) == "00")
                                {
                                    if (obj.VENCIMIENTO < UTILS.getFechaActual())
                                    {
                                        obj.PERIODOMAQUILLADO =
                                        string.Format(
                                            "<small class=\"label bg-yellow\">En mora</small><strong style=\"font-size: 16px;\"> Expensas Ordinarias mes de {0} de {1}<span class=\"pull-right\">{2:c}</span></strong><p>Venci� el: {3}</p>",
                                            mes,
                                            obj.PERIODO.ToString().Substring(0, 4),
                                        obj.SALDO, obj.VENCIMIENTO.ToShortDateString());
                                    }
                                    else
                                    {
                                        obj.PERIODOMAQUILLADO =
                                        string.Format(
                                            "<strong style=\"font-size: 16px;\">Expensas Ordinarias mes de {0} de {1}<span class=\"pull-right\">{2:c}</span></strong><p>Vence el: {3}</p>",
                                            mes,
                                            obj.PERIODO.ToString().Substring(0, 4),
                                        obj.SALDO, obj.VENCIMIENTO.ToShortDateString());
                                    }
                                }
                                else
                                {
                                    if (obj.VENCIMIENTO < UTILS.getFechaActual())
                                    {
                                        obj.PERIODOMAQUILLADO =
                                        string.Format(
                                            "<small class=\"label bg-yellow\">En mora</small><strong style=\"font-size: 16px;\"> Expensas Extraordinarias mes de {0} de {1}<span class=\"pull-right\">{2:c}</span></strong><p>Venci� el: {3}</p>",
                                            mes,
                                            obj.PERIODO.ToString().Substring(0, 4),
                                        obj.SALDO, obj.VENCIMIENTO.ToShortDateString());
                                    }
                                    else
                                    {
                                        obj.PERIODOMAQUILLADO =
                                        string.Format(
                                            "<strong style=\"font-size: 16px;\">Expensas Extraordinarias mes de {0} de {1}<span class=\"pull-right\">{2:c}</span></strong><p>Vence el: {3}</p>",
                                            mes,
                                            obj.PERIODO.ToString().Substring(0, 4),
                                        obj.SALDO, obj.VENCIMIENTO.ToShortDateString());
                                    }
                                }
                            }
                            else
                            {
                                obj.PERIODOMAQUILLADO = string.Format(
                                    "<small class=\"label bg-yellow\">En mora</small><strong style=\"font-size: 16px;\">Saldo (capital) a Sept. 2019<span class=\"pull-right\">{0:c}</span></strong><p>Para regularizar sus obigaciones adeudadas anteriores a Septiembre de 2019 por favor comuniquese con la Administraci�n</p>",
                                    obj.SALDO);

                            }
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int insert(CTACTE_EXPENSAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO CTACTE_EXPENSAS(");
                sql.AppendLine("TIPO_MOVIMIENTO");
                sql.AppendLine(", PERIODO");
                sql.AppendLine(", NRO_CTA");
                sql.AppendLine(", MONTO_ORIGINAL");
                sql.AppendLine(", RECARGO_VENCIMIENTO");
                sql.AppendLine(", DEBE");
                sql.AppendLine(", HABER");
                sql.AppendLine(", SALDO");
                sql.AppendLine(", FECHA");
                sql.AppendLine(", PAGADO");
                sql.AppendLine(", DESCUENTO");
                sql.AppendLine(", COSTO_FINANCIERO");
                sql.AppendLine(", VENCIMIENTO");
                sql.AppendLine(", INTERES_MORA");
                sql.AppendLine(", DESC_VENCIMIENTO");
                sql.AppendLine(", SALDO_CAPITAL");
                sql.AppendLine(", FECHA_ULTIMO_PAGO");
                sql.AppendLine(", SALDO_INTERES");
                sql.AppendLine(", PAGO_A_CTA");
                sql.AppendLine(", NRO_RECIBO_PAGO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@TIPO_MOVIMIENTO");
                sql.AppendLine(", @PERIODO");
                sql.AppendLine(", @NRO_CTA");
                sql.AppendLine(", @MONTO_ORIGINAL");
                sql.AppendLine(", @RECARGO_VENCIMIENTO");
                sql.AppendLine(", @DEBE");
                sql.AppendLine(", @HABER");
                sql.AppendLine(", @SALDO");
                sql.AppendLine(", GETDATE()");
                sql.AppendLine(", 0");
                sql.AppendLine(", 0");
                sql.AppendLine(", 0");
                sql.AppendLine(", @VENCIMIENTO");
                sql.AppendLine(", 0");
                sql.AppendLine(", @DESC_VENCIMIENTO");
                sql.AppendLine(", @SALDO");
                sql.AppendLine(", @VENCIMIENTO");
                sql.AppendLine(", 0");
                sql.AppendLine(", 0");
                sql.AppendLine(", @NRO_RECIBO_PAGO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", obj.TIPO_MOVIMIENTO);
                    cmd.Parameters.AddWithValue("@PERIODO", obj.PERIODO);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@MONTO_ORIGINAL", obj.MONTO_ORIGINAL);
                    cmd.Parameters.AddWithValue("@RECARGO_VENCIMIENTO", obj.RECARGO_VENCIMIENTO);
                    cmd.Parameters.AddWithValue("@DEBE", obj.DEBE);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
                    cmd.Parameters.AddWithValue("@VENCIMIENTO", obj.VENCIMIENTO);
                    cmd.Parameters.AddWithValue("@DESC_VENCIMIENTO", obj.DESC_VENCIMIENTO);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", obj.NRO_RECIBO_PAGO);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int insertPlanPago(CTACTE_EXPENSAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO CTACTE_EXPENSAS(");
                sql.AppendLine("TIPO_MOVIMIENTO");
                sql.AppendLine(", PERIODO");
                sql.AppendLine(", NRO_CTA");
                sql.AppendLine(", MONTO_ORIGINAL");
                sql.AppendLine(", RECARGO_VENCIMIENTO");
                sql.AppendLine(", DEBE");
                sql.AppendLine(", HABER");
                sql.AppendLine(", SALDO");
                sql.AppendLine(", FECHA");
                sql.AppendLine(", PAGADO");
                sql.AppendLine(", DESCUENTO");
                sql.AppendLine(", COSTO_FINANCIERO");
                sql.AppendLine(", VENCIMIENTO");
                sql.AppendLine(", INTERES_MORA");
                sql.AppendLine(", DESC_VENCIMIENTO");
                sql.AppendLine(", SALDO_CAPITAL");
                sql.AppendLine(", FECHA_ULTIMO_PAGO");
                sql.AppendLine(", SALDO_INTERES");
                sql.AppendLine(", PAGO_A_CTA");
                sql.AppendLine(", NRO_PLAN_PAGO");
                sql.AppendLine(", ESTADO");
                sql.AppendLine(", NRO_CUOTA");
                sql.AppendLine(", CAE");
                sql.AppendLine(", PTO_VTA");
                sql.AppendLine(", NRO_CTE");
                sql.AppendLine(", COD_BARRA_RAPIPAGO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@TIPO_MOVIMIENTO");
                sql.AppendLine(", @PERIODO");
                sql.AppendLine(", @NRO_CTA");
                sql.AppendLine(", @MONTO_ORIGINAL");
                sql.AppendLine(", 0");
                sql.AppendLine(", @DEBE");
                sql.AppendLine(", @HABER");
                sql.AppendLine(", @SALDO");
                sql.AppendLine(", GETDATE()");
                sql.AppendLine(", 0");
                sql.AppendLine(", 0");
                sql.AppendLine(", 0");
                sql.AppendLine(", @VENCIMIENTO");
                sql.AppendLine(", 0");
                sql.AppendLine(", 0");
                sql.AppendLine(", @SALDO");
                sql.AppendLine(", @VENCIMIENTO");
                sql.AppendLine(", 0");
                sql.AppendLine(", 0");
                sql.AppendLine(", @NRO_PLAN_PAGO");
                sql.AppendLine(", 1");
                sql.AppendLine(", @NRO_CUOTA");
                sql.AppendLine(", 11111111111111");
                sql.AppendLine(", @PTO_VTA");
                sql.AppendLine(", @NRO_CTE");
                sql.AppendLine(", @COD_BARRA_RAPIPAGO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", obj.TIPO_MOVIMIENTO);
                    cmd.Parameters.AddWithValue("@PERIODO", obj.PERIODO);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@MONTO_ORIGINAL", obj.MONTO_ORIGINAL);
                    cmd.Parameters.AddWithValue("@RECARGO_VENCIMIENTO", obj.RECARGO_VENCIMIENTO);
                    cmd.Parameters.AddWithValue("@DEBE", obj.DEBE);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
                    cmd.Parameters.AddWithValue("@VENCIMIENTO", obj.VENCIMIENTO);
                    cmd.Parameters.AddWithValue("@DESC_VENCIMIENTO", obj.DESC_VENCIMIENTO);
                    cmd.Parameters.AddWithValue("@NRO_PLAN_PAGO", obj.NRO_PLAN_PAGO);
                    cmd.Parameters.AddWithValue("@ESTADO", obj.ESTADO);
                    cmd.Parameters.AddWithValue("@NRO_CUOTA", obj.NRO_CUOTA);
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@COD_BARRA_RAPIPAGO", obj.COD_BARRA_RAPIPAGO);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void update(CTACTE_EXPENSAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  CTACTE_EXPENSAS SET");
                sql.AppendLine("TIPO_MOVIMIENTO=@TIPO_MOVIMIENTO");
                sql.AppendLine(", PERIODO=@PERIODO");
                sql.AppendLine(", NRO_CTA=@NRO_CTA");
                sql.AppendLine(", MONTO_ORIGINAL=@MONTO_ORIGINAL");
                sql.AppendLine(", RECARGO_VENCIMIENTO=@RECARGO_VENCIMIENTO");
                sql.AppendLine(", DEBE=@DEBE");
                sql.AppendLine(", HABER=@HABER");
                sql.AppendLine(", SALDO=@SALDO");
                sql.AppendLine(", PTO_VTA=@PTO_VTA");
                sql.AppendLine(", NRO_CTE=@NRO_CTE");
                sql.AppendLine(", CAE=@CAE");
                sql.AppendLine(", FECHA_CAE=@FECHA_CAE");
                sql.AppendLine(", VENC_CAE=@VENC_CAE");
                sql.AppendLine(", INTERES_MORA=@INTERES_MORA");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", obj.TIPO_MOVIMIENTO);
                    cmd.Parameters.AddWithValue("@PERIODO", obj.PERIODO);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@MONTO_ORIGINAL", obj.MONTO_ORIGINAL);
                    cmd.Parameters.AddWithValue("@RECARGO_VENCIMIENTO", obj.RECARGO_VENCIMIENTO);
                    cmd.Parameters.AddWithValue("@DEBE", obj.DEBE);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@CAE", obj.CAE);
                    cmd.Parameters.AddWithValue("@FECHA_CAE", obj.FECHA_CAE);
                    cmd.Parameters.AddWithValue("@VENC_CAE", obj.VENC_CAE);
                    cmd.Parameters.AddWithValue("@INTERES_MORA", obj.INTERES_MORA);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void setAFIP(CTACTE_EXPENSAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  CTACTE_EXPENSAS SET");
                sql.AppendLine("PTO_VTA=@PTO_VTA");
                sql.AppendLine(", NRO_CTE=@NRO_CTE");
                sql.AppendLine(", CAE=@CAE");
                sql.AppendLine(", FECHA_CAE=@FECHA_CAE");
                sql.AppendLine(", VENC_CAE=@VENC_CAE");
                sql.AppendLine(", COD_BARRA_RAPIPAGO=@COD_BARRA_RAPIPAGO");
                sql.AppendLine(", ESTADO=1");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@CAE", obj.CAE);

                    cmd.Parameters.AddWithValue("@FECHA_CAE", obj.FECHA_CAE);
                    cmd.Parameters.AddWithValue("@VENC_CAE", obj.VENC_CAE);
                    cmd.Parameters.AddWithValue("@COD_BARRA_RAPIPAGO", obj.COD_BARRA_RAPIPAGO);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setDescuento(CTACTE_EXPENSAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  CTACTE_EXPENSAS SET");
                sql.AppendLine("DESC_VENCIMIENTO=@DESC_VENCIMIENTO");
                sql.AppendLine(", HABER=@HABER");
                sql.AppendLine(", SALDO=@SALDO");
                sql.AppendLine(", DEBE=@DEBE");
                sql.AppendLine(", SALDO_CAPITAL=@SALDO_CAPITAL");
                sql.AppendLine(", SALDO_INTERES=0");
                sql.AppendLine(", INTERES_MORA=@INTERES_MORA");
                sql.AppendLine(", OBS=@OBS");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@DESC_VENCIMIENTO", obj.DESC_VENCIMIENTO);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
                    cmd.Parameters.AddWithValue("@DEBE", obj.DEBE);
                    cmd.Parameters.AddWithValue("@SALDO_CAPITAL", obj.SALDO_CAPITAL);
                    cmd.Parameters.AddWithValue("@INTERES_MORA", obj.INTERES_MORA);
                    cmd.Parameters.AddWithValue("@OBS", obj.OBS);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setCodBarra(int id, string codBarra)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CTACTE_EXPENSAS SET");
                sql.AppendLine("COD_BARRA_RAPIPAGO=@COD_BARRA_RAPIPAGO");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@COD_BARRA_RAPIPAGO", codBarra);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void activaDesactivaWeb(int id, int estado)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CTACTE_EXPENSAS SET");
                sql.AppendLine("ESTADO=@ESTADO");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@ESTADO", estado);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setPlanPago(int id, int nroPlan)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CTACTE_EXPENSAS SET");
                sql.AppendLine("NRO_PLAN_PAGO=@NRO_PLAN_PAGO");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NRO_PLAN_PAGO", nroPlan);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void anulaPlanPago(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CTACTE_EXPENSAS SET");
                sql.AppendLine("NRO_PLAN_PAGO=NULL");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void asientoPago(int id, int nroComprobante, decimal saldo,
            DateTime fecha_pago, decimal montoPagado, decimal saldoCapital,
            decimal saldoInteres, decimal pagoCtaAnt)
        {
            try
            {
                StringBuilder sql = new StringBuilder();

                using (SqlConnection con = GetConnection())
                {
                    if (saldo == 0)
                    {
                        sql.AppendLine("UPDATE  CTACTE_EXPENSAS SET");
                        sql.AppendLine("SALDO=0, PAGADO=1, NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO");
                        sql.AppendLine("WHERE");
                        sql.AppendLine("ID=@ID");
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql.ToString();
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", nroComprobante);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        decimal PORC_PAGO = montoPagado / (saldoCapital + saldoInteres);
                        decimal CAPITAL_PAGADO = saldoCapital * PORC_PAGO;
                        decimal INTERES_PAGADO = saldoInteres * PORC_PAGO;
                        decimal SALDO_CAPITAL = saldoCapital - CAPITAL_PAGADO;
                        decimal SALDO_INTERES = saldoInteres - INTERES_PAGADO;

                        sql.AppendLine("UPDATE  CTACTE_EXPENSAS SET");
                        sql.AppendLine("FECHA_ULTIMO_PAGO=@FECHA_ULTIMO_PAGO,");
                        sql.AppendLine("PAGADO=0,");
                        sql.AppendLine("PAGO_A_CTA = @PAGO_A_CTA,");
                        sql.AppendLine("SALDO_CAPITAL=@SALDO_CAPITAL,");
                        sql.AppendLine("SALDO_INTERES=@SALDO_INTERES,");
                        sql.AppendLine("INTERES_MORA=0,");
                        sql.AppendLine("DEBE=@SALDO,");
                        sql.AppendLine("SALDO=@SALDO,");
                        sql.AppendLine("NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO");
                        sql.AppendLine("WHERE");
                        sql.AppendLine("ID=@ID");
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql.ToString();

                        decimal pagoCtaTotal = montoPagado + pagoCtaAnt;
                        decimal pendiente = SALDO_CAPITAL + SALDO_INTERES;
                        cmd.Parameters.AddWithValue("@FECHA_ULTIMO_PAGO", fecha_pago);
                        cmd.Parameters.AddWithValue("@PAGO_A_CTA", pagoCtaTotal);
                        cmd.Parameters.AddWithValue("@MONTO", montoPagado);
                        cmd.Parameters.AddWithValue("@SALDO_CAPITAL", SALDO_CAPITAL);
                        cmd.Parameters.AddWithValue("@SALDO_INTERES", SALDO_INTERES);
                        cmd.Parameters.AddWithValue("@SALDO", pendiente);
                        cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", nroComprobante);
                        cmd.Parameters.AddWithValue("@ID", id);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void asientoPagoMasivo(int id, int nroComprobante)
        {
            try
            {
                StringBuilder sql = new StringBuilder();

                using (SqlConnection con = GetConnection())
                {
                    sql.AppendLine("UPDATE  CTACTE_EXPENSAS SET");
                    sql.AppendLine("SALDO=0, PAGADO=1, NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO");
                    sql.AppendLine("WHERE");
                    sql.AppendLine("ID=@ID");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", nroComprobante);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setPayPerTic(int id, int nroComprobantePayPerTic)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  CTACTE_EXPENSAS SET");
                sql.AppendLine("NRO_RECIBO_PAYPERTIC=@NRO_RECIBO_PAYPERTIC");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAYPERTIC", nroComprobantePayPerTic);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setPayPerTic(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  CTACTE_EXPENSAS SET");
                sql.AppendLine("NRO_RECIBO_PAYPERTIC=NULL");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setSALDOS(int id, decimal interesPagado, decimal saldoInteres,
            decimal capitalPagado, decimal saldoCapital)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CTACTE_EXPENSAS SET");
                sql.AppendLine("CAPITAL_PAGADO=@CAPITAL_PAGADO,");
                sql.AppendLine("INTERES_PAGADO=@INTERES_PAGADO,");
                sql.AppendLine("SALDO_CAPITAL=@SALDO_CAPITAL,");
                sql.AppendLine("SALDO_INTERES=@SALDO_INTERES");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@CAPITAL_PAGADO", capitalPagado);
                    cmd.Parameters.AddWithValue("@INTERES_PAGADO", interesPagado);
                    cmd.Parameters.AddWithValue("@SALDO_CAPITAL", saldoCapital);
                    cmd.Parameters.AddWithValue("@SALDO_INTERES", saldoInteres);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void asientoPagoCtaMov1(CTACTE_EXPENSAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CTACTE_EXPENSAS");
                sql.AppendLine("SET FECHA_ULTIMO_PAGO=@FECHA_ULTIMO_PAGO, PAGADO=@PAGADO, PAGO_A_CTA=@PAGO_A_CTA,");
                sql.AppendLine("SALDO_CAPITAL=@SALDO_CAPITAL, SALDO_INTERES=@SALDO_INTERES,");
                sql.AppendLine("CAPITAL_PAGADO=@CAPITAL_PAGADO, INTERES_PAGADO=@INTERES_PAGADO,");
                sql.AppendLine("INTERES_MORA=@INTERES_MORA, DEBE=@DEBE, SALDO=@SALDO, NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO, ID_MEDIO_PAGO=@ID_MEDIO_PAGO");
                sql.AppendLine("WHERE ID=@ID");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@FECHA_ULTIMO_PAGO", obj.FECHA_ULTIMO_PAGO);
                    cmd.Parameters.AddWithValue("@PAGADO", obj.PAGADO);
                    cmd.Parameters.AddWithValue("@PAGO_A_CTA", obj.PAGO_A_CTA);
                    cmd.Parameters.AddWithValue("@SALDO_CAPITAL", obj.SALDO_CAPITAL);
                    cmd.Parameters.AddWithValue("@SALDO_INTERES", obj.SALDO_INTERES);
                    cmd.Parameters.AddWithValue("@CAPITAL_PAGADO", obj.CAPITAL_PAGADO);
                    cmd.Parameters.AddWithValue("@INTERES_PAGADO", obj.INTERES_PAGADO);
                    cmd.Parameters.AddWithValue("@INTERES_MORA", obj.INTERES_MORA);
                    cmd.Parameters.AddWithValue("@DEBE", obj.DEBE);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", obj.NRO_RECIBO_PAGO);
                    cmd.Parameters.AddWithValue("@ID_MEDIO_PAGO", obj.ID_MEDIO_PAGO);
                    cmd.Parameters.AddWithValue("@ID", obj.ID);





                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void asientoPago(CTACTE_EXPENSAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT CTACTE_EXPENSAS");
                sql.AppendLine("(FECHA,CAPITAL_PAGADO,HABER,INTERES_MORA,INTERES_PAGADO,NRO_CTA,");
                sql.AppendLine("NRO_RECIBO_PAGO, PERIODO, SALDO_CAPITAL, SALDO_INTERES, VENCIMIENTO,");
                sql.AppendLine("TIPO_MOVIMIENTO, ID_MEDIO_PAGO, NRO_PLAN_PAGO, NRO_CUOTA,ID_USUARIO_PAGA,OBS,FECHA_ULTIMO_PAGO)");
                sql.AppendLine("VALUES");
                sql.AppendLine("(@FECHA,@CAPITAL_PAGADO,@HABER,@INTERES_MORA,@INTERES_PAGADO,@NRO_CTA,");
                sql.AppendLine("@NRO_RECIBO_PAGO, @PERIODO, @SALDO_CAPITAL, @SALDO_INTERES, @VENCIMIENTO,");
                sql.AppendLine("2, @ID_MEDIO_PAGO, @NRO_PLAN_PAGO, @NRO_CUOTA,@ID_USUARIO_PAGA,@OBS,@FECHA_ULTIMO_PAGO)");


                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@FECHA_ULTIMO_PAGO", obj.FECHA_ULTIMO_PAGO);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@CAPITAL_PAGADO", obj.CAPITAL_PAGADO);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@INTERES_MORA", obj.INTERES_MORA);
                    cmd.Parameters.AddWithValue("@INTERES_PAGADO", obj.INTERES_PAGADO);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", obj.NRO_RECIBO_PAGO);
                    cmd.Parameters.AddWithValue("@PERIODO", obj.PERIODO);
                    cmd.Parameters.AddWithValue("@SALDO_CAPITAL", obj.SALDO_CAPITAL);
                    cmd.Parameters.AddWithValue("@SALDO_INTERES", obj.SALDO_INTERES);
                    cmd.Parameters.AddWithValue("@VENCIMIENTO", obj.VENCIMIENTO);
                    cmd.Parameters.AddWithValue("@ID_MEDIO_PAGO", obj.ID_MEDIO_PAGO);
                    cmd.Parameters.AddWithValue("@NRO_PLAN_PAGO", obj.NRO_PLAN_PAGO);
                    cmd.Parameters.AddWithValue("@NRO_CUOTA", obj.NRO_CUOTA);
                    cmd.Parameters.AddWithValue("@ID_USUARIO_PAGA", obj.ID_USUARIO_PAGA);
                    cmd.Parameters.AddWithValue("@OBS", obj.OBS);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  CTACTE_EXPENSAS ");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void quitaDeudaFactura(int nroCta, int periodo)
        {
            try
            {

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE FACTURAS_X_EXPENSA");
                sql.AppendLine("WHERE PERIODO = @PERIODO AND NRO_CTA = @NRO_CTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void quitaDeudaDetalle(int nroCta, int periodo)
        {
            try
            {

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE DETALLE_DEUDA");
                sql.AppendLine("WHERE PERIODO = @PERIODO AND NRO_CTA = @NRO_CTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void quitaDeudaCta(int nroCta, int periodo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE CTACTE_EXPENSAS");
                sql.AppendLine("WHERE PERIODO = @PERIODO AND NRO_CTA = @NRO_CTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void deletePeriodo(int periodo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE CTACTE_EXPENSAS ");
                sql.AppendLine("WHERE");
                sql.AppendLine("PERIODO=@PERIODO AND TIPO_MOVIMIENTO = 1");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int getMaxNroRecibo()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT ISNULL(MAX(NRO_RECIBO_PAGO),0)FROM CTACTE_EXPENSAS");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int getMaxNroCtePlan()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT ISNULL(MAX(NRO_CTE),1)");
                sql.AppendLine("FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE TIPO_MOVIMIENTO = 3");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void recalculo(DateTime fecha, int periodo, int nroCta, int id)
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "RECALCULO_MANUAL";
                    cmd.Parameters.AddWithValue("@HOY", fecha);
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void recalculoPlan(DateTime fecha, int periodo, int nroCta, int id, int nroPlan)
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "RECALCULO_MANUAL_PLAN";
                    cmd.Parameters.AddWithValue("@HOY", fecha);
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@NRO_PLAN", nroPlan);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void recalculo()
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CALCULA_INTERESES";

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ajusteInteres(int idCta, decimal ajuste,
            decimal interesMora, string obs)
        {
            try
            {
                StringBuilder SQL = new StringBuilder();
                SQL.AppendLine("UPDATE CTACTE_EXPENSAS");
                SQL.AppendLine("SET AJUSTE_INTERES=@AJUSTE_INTERES");
                SQL.AppendLine(", OBS_AJUSTE=@OBS_AJUSTE");
                SQL.AppendLine(", SALDO = SALDO - INTERES_MORA + @INTERES_MORA");
                SQL.AppendLine(", DEBE = SALDO - INTERES_MORA + @INTERES_MORA");
                SQL.AppendLine(", INTERES_MORA=@INTERES_MORA");
                SQL.AppendLine("WHERE ID=@ID");

                decimal diferencia = 0;

                diferencia = ajuste - interesMora;


                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
                    cmd.Parameters.AddWithValue("@AJUSTE_INTERES", diferencia);
                    cmd.Parameters.AddWithValue("@OBS_AJUSTE", obs);
                    cmd.Parameters.AddWithValue("@INTERES_MORA", ajuste);
                    cmd.Parameters.AddWithValue("@ID", idCta);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void DescuentoNCFiscal(int idCta, decimal monto, bool pagado)
        {
            try
            {
                StringBuilder SQL = new StringBuilder();
                if (!pagado)
                {
                    SQL.AppendLine("UPDATE CTACTE_EXPENSAS");
                    SQL.AppendLine("SET DESCUENTO=@DESCUENTO, SALDO=SALDO-@DESCUENTO,");
                    SQL.AppendLine("DEBE=DEBE-@DESCUENTO, SALDO_CAPITAL=SALDO_CAPITAL-@DESCUENTO");
                    SQL.AppendLine("WHERE ID=@ID");
                }
                else
                {
                    SQL.AppendLine("UPDATE CTACTE_EXPENSAS");
                    SQL.AppendLine("SET DESCUENTO=@DESCUENTO, PAGADO=1, DEBE=0, SALDO=0, SALDO_CAPITAL=0");
                    SQL.AppendLine("WHERE ID=@ID");
                }
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
                    cmd.Parameters.AddWithValue("@DESCUENTO", monto);
                    cmd.Parameters.AddWithValue("@ID", idCta);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

