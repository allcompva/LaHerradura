﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MOVIMIENTO_CTACTE : DALBase
    {
        //1. FACTURA EXPENSAS 2. PAGO 3. INTERESES 4. NOTA DE CREDITO 
        //4. INTERES PLAN DE PAGOS, 6. FACTURACION EXTERNA
        public int TIPO { get; set; }
        public int ID { get; set; }
        public string NRO_FACTURA { get; set; }
        public string PERIODO { get; set; }
        public DateTime FECHA { get; set; }
        public decimal DEBE { get; set; }
        public decimal HABER { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal SALDO { get; set; }

        public MOVIMIENTO_CTACTE()
        {
            TIPO = 0;
            ID = 0;
            NRO_FACTURA = string.Empty;
            PERIODO = string.Empty;
            FECHA = UTILS.getFechaActual();
            DEBE = 0;
            HABER = 0;
            DESCRIPCION = string.Empty;
            SALDO = 0;
        }
        private static List<MOVIMIENTO_CTACTE> mapeo(SqlDataReader dr)
        {
            List<MOVIMIENTO_CTACTE> lst = new List<MOVIMIENTO_CTACTE>();
            MOVIMIENTO_CTACTE obj;
            int i = 0;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new MOVIMIENTO_CTACTE();
                    if (!dr.IsDBNull(0)) { obj.TIPO = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.ID = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.NRO_FACTURA = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.PERIODO = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.FECHA = dr.GetDateTime(4); }
                    if (!dr.IsDBNull(5)) { obj.DEBE = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.HABER = dr.GetDecimal(6); }
                    switch (obj.TIPO)
                    {
                        case 1:
                            obj.DESCRIPCION =
                                getPeriodo(int.Parse(obj.PERIODO),
                                obj.NRO_FACTURA);
                            break;
                        case 2:
                            obj.DESCRIPCION = string.Format(
                                "Pago Recibo N°: {0}",
                                obj.PERIODO);
                            break;
                        case 3:
                            obj.DESCRIPCION = string.Format(
                                "Facturacion intereses: {0} - Recibo Nro.: {1}",
                            getPeriodo(int.Parse(obj.PERIODO), string.Empty),
                            obj.NRO_FACTURA);
                            break;
                        case 4:
                            if (obj.PERIODO != string.Empty)
                                obj.DESCRIPCION = getPeriodo2(int.Parse(obj.PERIODO),
                                    obj.NRO_FACTURA);
                            break;
                        case 5:
                            obj.DESCRIPCION = string.Format(
                                "Intereses Plan de Pagos N°: {0}", obj.ID);
                            break;
                        case 6:
                            obj.DESCRIPCION = string.Format("Factura N°: {0} - {1}",
                                obj.NRO_FACTURA,
                                obj.PERIODO);
                            break;
                        case 7:
                            //obj.DESCRIPCION = string.Format(
                            //    "A Billetera en recibo N°: {0}", obj.PERIODO);
                            obj.DESCRIPCION = string.Format(
                                "Nota de Crédito interna N°: {0} - {1}",
                                obj.NRO_FACTURA, obj.PERIODO);
                            break;
                        case 8:
                            obj.DESCRIPCION = string.Format(
                                "De Billetera en N°: {0}", obj.PERIODO);
                            break;
                        case 9:
                            obj.DESCRIPCION = string.Format("Nota de Débito Interna N°: {0} - {1}",
                                obj.NRO_FACTURA,
                                obj.PERIODO);
                            break;
                        case 10:
                            obj.DESCRIPCION = string.Format("Nota de Crédito Interna N°: {0} - {1}",
                                obj.NRO_FACTURA,
                                obj.PERIODO);
                            break;
                        default:
                            break;
                    }
                    if (i == 0)
                    {
                        obj.SALDO = obj.HABER - obj.DEBE;
                    }
                    else
                    {
                        obj.SALDO = lst[i - 1].SALDO - obj.DEBE + obj.HABER;
                    }
                    lst.Add(obj);
                    i++;
                }
            }
            return lst;
        }
        public static List<MOVIMIENTO_CTACTE> read(int nroCta)
        {
            try
            {
                List<MOVIMIENTO_CTACTE> lst = new List<MOVIMIENTO_CTACTE>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT 1 AS TIPO, A.ID,");
                sql.AppendLine("RIGHT('0000' + Ltrim(Rtrim(A.PTO_VTA)),4) + '-' +");
                sql.AppendLine("RIGHT('00000000' + Ltrim(Rtrim(A.NRO_CTE)),8),");
                sql.AppendLine("CONVERT(VARCHAR(MAX), A.PERIODO),");
                sql.AppendLine("FECHA_CAE, MONTO_ORIGINAL AS DEBE, 0 AS HABER ");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE A.NRO_CTA = @NRO_CTA AND TIPO_MOVIMIENTO IN (1)");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT 2, A.ID, 'PAGO', CONVERT(VARCHAR(MAX),A.ID_FACTURA),");
                sql.AppendLine("A.FECHA, 0, A.MONTO");
                sql.AppendLine("FROM PAGOS_CON_CUENTA A");
                sql.AppendLine("WHERE A.NRO_CTA = @NRO_CTA AND A.ID_PLAN_PAGO !=7");//);
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT 3, ID, CONVERT(VARCHAR(MAX),NRO_RECIBO_PAGO), CONVERT(VARCHAR(MAX),PERIODO), FECHA, INTERES_PAGADO, 0 FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE NRO_CTA = @NRO_CTA AND TIPO_MOVIMIENTO IN (2) AND INTERES_PAGADO <> 0");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT 4, 0, ");
                sql.AppendLine("RIGHT('0000' + Ltrim(Rtrim(PTO_VTA)),4) + '-' +");
                sql.AppendLine("RIGHT('00000000' + Ltrim(Rtrim(NRO_CTE)),8),");
                sql.AppendLine("CONVERT(VARCHAR(MAX),PERIODO), FECHA_CAE, 0, MONTO FROM FACTURAS_X_EXPENSA");
                sql.AppendLine("WHERE NRO_CTA=@NRO_CTA AND TIPO_COMPROBANTE = 13");
                sql.AppendLine("UNION ");
                sql.AppendLine("SELECT 5, A.ID, 'INTERESES PLAN DE PAGO', '', FECHA_INICIO, INTERES + A.MONTO_A_FINANCIAR -");
                sql.AppendLine("(SELECT SUM(B.MONTO_ORIGINAL)");
                sql.AppendLine("FROM CTACTE_EXPENSAS B WHERE A.ID = B.NRO_PLAN_PAGO AND TIPO_MOVIMIENTO = 1), 0 ");
                sql.AppendLine("FROM PLANES_PAGO A");
                sql.AppendLine("WHERE A.NRO_CTA=@NRO_CTA");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT 6 AS TIPO, A.ID, ");
                sql.AppendLine("RIGHT('0000' + Ltrim(Rtrim(A.PTO_VTA)),4) + '-' +");
                sql.AppendLine("RIGHT('00000000' + Ltrim(Rtrim(A.NRO_CTE)),8),");
                sql.AppendLine("CONVERT(VARCHAR(MAX),B.DETALLE),");
                sql.AppendLine("A.FECHA_CAE, MONTO_ORIGINAL AS DEBE, 0 AS HABER");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN FACTURAS_X_EXPENSA B ON B.ID_CTACTE=A.ID AND B.TIPO_COMPROBANTE = 11 ");
                sql.AppendLine("WHERE A.NRO_CTA = @NRO_CTA AND TIPO_MOVIMIENTO IN (100)");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT 9 AS TIPO, A.ID, ");
                sql.AppendLine("RIGHT('0000' + Ltrim(Rtrim(A.PTO_VTA)),4) + '-' +");
                sql.AppendLine("RIGHT('00000000' + Ltrim(Rtrim(A.NRO_CTE)),8),");
                sql.AppendLine("CONVERT(VARCHAR(MAX),B.DETALLE),");
                sql.AppendLine("A.FECHA_CAE, MONTO_ORIGINAL AS DEBE, 0 AS HABER");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN FACTURAS_X_EXPENSA B ON B.ID_CTACTE=A.ID ");
                sql.AppendLine("WHERE A.NRO_CTA = @NRO_CTA AND TIPO_MOVIMIENTO IN (21)");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT 10 AS TIPO, A.ID_CTACTE,");
                sql.AppendLine("RIGHT('0000' + Ltrim(Rtrim(A.PTO_VTA)),4) + '-' +");
                sql.AppendLine("RIGHT('00000000' + Ltrim(Rtrim(A.NRO_CTE)),8),");
                sql.AppendLine("CONVERT(VARCHAR(MAX),A.DETALLE),");
                sql.AppendLine("A.FECHA_CAE, 0 AS DEBE, MONTO AS HABER");
                sql.AppendLine("FROM FACTURAS_X_EXPENSA A");
                sql.AppendLine("WHERE A.NRO_CTA = @NRO_CTA AND TIPO_COMPROBANTE IN (31)");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT 7, 0, ");
                sql.AppendLine("RIGHT('0000' + Ltrim(Rtrim(A.PTO_VTA_NOTA_CREDITO)),4) + '-' +");
                sql.AppendLine("RIGHT('00000000' + Ltrim(Rtrim(A.NRO_NOTA_CREDITO)),8),");
                sql.AppendLine("CONVERT(VARCHAR(MAX),B.DETALLE),A.FECHA, 0, A.MONTO");
                sql.AppendLine("FROM MOV_BILLETERA A");
                sql.AppendLine("INNER JOIN FACTURAS_X_EXPENSA B ON A.PTO_VTA_NOTA_CREDITO=B.PTO_VTA");
                sql.AppendLine("AND A.NRO_NOTA_CREDITO=B.NRO_CTE");
                sql.AppendLine("WHERE A.NRO_CTA = 1 AND TIPO_MOVIMIENTO = 1");
                sql.AppendLine("AND ISNULL(A.NRO_NOTA_CREDITO,0) <> 0");
                sql.AppendLine("ORDER BY FECHA_CAE ASC");

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
        public static string getPeriodo(int periodo, string nroFactu)
        {
            try
            {
                string ret = string.Empty;
                string me, mes = string.Empty;
                me = periodo.ToString().Substring(4, 2);
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
                if (periodo >= 20200400)
                {

                    if (periodo.ToString().Substring(6, 2) == "00")
                    {
                        ret =
                            string.Format(
                            "Factura {0} Expensas Ordinarias mes de {1} de {2}",
                            nroFactu,
                            mes,
                            periodo.ToString().Substring(0, 4));
                    }
                    else
                    {
                        ret =
                            string.Format(
                            "Factura {0} Expensas Extraordinarias mes de {1} de {2}",
                            nroFactu,
                            mes,
                            periodo.ToString().Substring(0, 4));
                    }
                }
                else
                {
                    if (periodo != 20190100)
                    {
                        if (periodo.ToString().Substring(6, 2) == "00")
                        {
                            ret =
                                string.Format(
                                "Deuda de Expensas Ordinarias mes de {0} de {1}",
                                    mes,
                                    periodo.ToString().Substring(0, 4));
                        }
                        else
                        {
                            ret =
                                string.Format(
                                "Deuda de Expensas Estraordinarias mes de {0} de {1}",
                                    mes,
                                    periodo.ToString().Substring(0, 4));
                        }
                    }
                    else
                    {
                        ret = "Saldo (capital) a Sept. 2019";
                    }
                }

                if (nroFactu == string.Empty)
                {
                    ret =
                    string.Format(
                    "Expensas Extraordinarias mes de {0} de {1}",
                    mes,
                    periodo.ToString().Substring(0, 4));
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string getPeriodo2(int periodo, string nroFactu)
        {
            try
            {
                string ret = string.Empty;
                string me, mes = string.Empty;
                me = periodo.ToString().Substring(4, 2);
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
                if (periodo >= 20200400)
                {

                    if (periodo.ToString().Substring(6, 2) == "00")
                    {
                        ret =
                            string.Format(
                            "Nota de Credito N°: {0} por Expensas Ordinarias mes de {1} de {2}",
                            nroFactu,
                            mes,
                            periodo.ToString().Substring(0, 4));
                    }
                    else
                    {
                        ret =
                            string.Format(
                            "Nota de Credito N°: {0} por Expensas Extraordinarias mes de {1} de {2}",
                            nroFactu,
                            mes,
                            periodo.ToString().Substring(0, 4));
                    }
                }
                else
                {
                    string[] datos = nroFactu.Split(Convert.ToChar("-"));
                    DAL.FACTURAS_X_EXPENSA objNC =
                        DAL.FACTURAS_X_EXPENSA.getByPk(int.Parse(datos[0]),
                        int.Parse(datos[1]), 13);
                    ret = objNC.DETALLE;
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
