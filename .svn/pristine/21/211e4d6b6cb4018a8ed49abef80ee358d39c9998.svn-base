using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class INFORME_PERIODOS : DALBase
    {
        public int PERIODO { get; set; }
        public int CANT_CUENTAS { get; set; }
        public decimal SALDO { get; set; }
        public string PERIODO_MAQUILLADO { get; set; }
        public int NRO_CTA { get; set; }
        public int TIPO_MOVIMIENTO { get; set; }
        public int NRO_PLAN_PAGO { get; set; }
        public int NRO_CUOTA { get; set; }

        public int MAN { get; set; }
        public int LOTE { get; set; }

        private static List<INFORME_PERIODOS> mapeo(SqlDataReader dr)
        {
            List<INFORME_PERIODOS> lst = new List<INFORME_PERIODOS>();
            INFORME_PERIODOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new INFORME_PERIODOS();
                    if (!dr.IsDBNull(0)) { obj.PERIODO = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.CANT_CUENTAS = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.SALDO = dr.GetDecimal(2); }

                    if (obj.PERIODO > 20190100)
                    {
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
                                obj.PERIODO_MAQUILLADO = string.Format("Expensas Ordinarias mes de {0} de {1}",
                                    mes,
                                    obj.PERIODO.ToString().Substring(0, 4));
                            else
                            {
                                obj.PERIODO_MAQUILLADO = string.Format("Expensas Extraordinarias mes de {0} de {1}",
                                    mes,
                                    obj.PERIODO.ToString().Substring(0, 4));
                            }
                        }
                    }
                    else
                    {
                        obj.PERIODO_MAQUILLADO = "Saldo (capital) a Sept. 2019";
                    }
                    if (obj.PERIODO == 0)
                        obj.PERIODO_MAQUILLADO = "Planes de pago";
                    if (obj.PERIODO == 100)
                        obj.PERIODO_MAQUILLADO = "Facturacion Externa";
                    lst.Add(obj);
                }
            }
            return lst;
        }
        private static List<INFORME_PERIODOS> mapeo2(SqlDataReader dr)
        {
            List<INFORME_PERIODOS> lst = new List<INFORME_PERIODOS>();
            INFORME_PERIODOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new INFORME_PERIODOS();
                    if (!dr.IsDBNull(0)) { obj.NRO_CTA = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.PERIODO = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.SALDO = dr.GetDecimal(2); }
                    if (!dr.IsDBNull(3)) { obj.MAN = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.LOTE = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.TIPO_MOVIMIENTO = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.NRO_PLAN_PAGO = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.NRO_CUOTA = dr.GetInt32(7); }
                    if (obj.PERIODO != 20190100)
                    {
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
                                obj.PERIODO_MAQUILLADO = string.Format("Expensas Ordinarias mes de {0} de {1}",
                                    mes,
                                    obj.PERIODO.ToString().Substring(0, 4));
                            else
                            {
                                if (int.Parse(
    obj.PERIODO.ToString().Substring(6, 2)) >= 10)
                                {
                                    string det = string.Empty;
                                    List<DAL.DETALLE_DEUDA> objDet =
                                        DAL.DETALLE_DEUDA.read(obj.PERIODO,
                                        obj.NRO_CTA);
                                    if (objDet.Count > 0)
                                        det = objDet[0].OBS;
                                    obj.PERIODO_MAQUILLADO = det;
                                }
                                else
                                {
                                    obj.PERIODO_MAQUILLADO = string.Format("Expensas Extraordinarias mes de {0} de {1}",
                                        mes,
                                        obj.PERIODO.ToString().Substring(0, 4));
                                }
                            }

                            if (obj.TIPO_MOVIMIENTO == 3)
                            {
                                obj.PERIODO_MAQUILLADO = string.Format("Plan de pago Nro: {0} - Cuota {1}",
                                    obj.NRO_PLAN_PAGO, obj.NRO_CUOTA);
                            }
                            if (obj.PERIODO == 100)
                                obj.PERIODO_MAQUILLADO = "Facturacion Externa";
                        }
                    }
                    else
                    {
                        obj.PERIODO_MAQUILLADO = "Saldo (capital) a Sept. 2019";
                    }
                    if (obj.PERIODO == 20191212)
                        obj.PERIODO_MAQUILLADO = "Saldo Diciembre de 2019";

                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<INFORME_PERIODOS> read()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT PERIODO, COUNT(*) AS CANT_CUENTAS, SUM(SALDO_CAPITAL + INTERES_MORA)");
                sql.AppendLine("FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE");
                sql.AppendLine("PAGADO=0 AND TIPO_MOVIMIENTO=1 AND (NRO_PLAN_PAGO = 0 OR NRO_PLAN_PAGO IS NULL)");
                sql.AppendLine("GROUP BY PERIODO");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT 0, COUNT(*) AS CANT_CUENTAS, SUM(SALDO_CAPITAL + INTERES_MORA)");
                sql.AppendLine("FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE PAGADO = 0 AND TIPO_MOVIMIENTO = 3");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT 100, COUNT(*) AS CANT_CUENTAS, SUM(SALDO_CAPITAL + INTERES_MORA)");
                sql.AppendLine("FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE PAGADO = 0 AND TIPO_MOVIMIENTO = 100");

                List<INFORME_PERIODOS> lst = new List<INFORME_PERIODOS>();
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
        public static List<INFORME_PERIODOS> readMora()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.PERIODO, COUNT(*) AS CANT_CUENTAS, SUM(SALDO_CAPITAL + INTERES_MORA)");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS B ON A.PERIODO=B.PERIODO");
                sql.AppendLine("WHERE");
                sql.AppendLine("PAGADO=0 AND TIPO_MOVIMIENTO=1 AND (NRO_PLAN_PAGO = 0 OR NRO_PLAN_PAGO IS NULL)");
                sql.AppendLine("AND B.VENCIMIENTO_3 <= GETDATE()");
                sql.AppendLine("GROUP BY A.PERIODO");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT 0, COUNT(*) AS CANT_CUENTAS, SUM(SALDO_CAPITAL + INTERES_MORA)");
                sql.AppendLine("FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE PAGADO = 0 AND TIPO_MOVIMIENTO = 3");
                sql.AppendLine("AND VENCIMIENTO <= GETDATE()");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT 100, COUNT(*) AS CANT_CUENTAS, SUM(SALDO_CAPITAL + INTERES_MORA)");
                sql.AppendLine("FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE PAGADO = 0 AND TIPO_MOVIMIENTO = 100");
                sql.AppendLine("AND VENCIMIENTO <= GETDATE()");

                List<INFORME_PERIODOS> lst = new List<INFORME_PERIODOS>();
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
        public static List<INFORME_PERIODOS> readPeriodos(int NRO_CTA)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.NRO_CTA, A.PERIODO, A.SALDO, B.MANZANA, B.LOTE, A.TIPO_MOVIMIENTO, A.NRO_PLAN_PAGO, A.NRO_CUOTA");
                sql.AppendLine("FROM CTACTE_EXPENSAS A INNER JOIN INMUEBLES B ON A.NRO_CTA=B.NRO_CTA");
                sql.AppendLine("WHERE A.NRO_CTA=@NRO_CTA AND");
                sql.AppendLine("((TIPO_MOVIMIENTO IN (1,100) AND (NRO_PLAN_PAGO IS NULL OR NRO_PLAN_PAGO = 0)) OR TIPO_MOVIMIENTO = 3) AND PAGADO = 0 AND CAE IS NOT NULL");
                sql.AppendLine("ORDER BY PERIODO DESC");
                List<INFORME_PERIODOS> lst = new List<INFORME_PERIODOS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", NRO_CTA);
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
        public static List<INFORME_PERIODOS> readPeriodosMora(int NRO_CTA)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.NRO_CTA, A.PERIODO, A.SALDO, B.MANZANA, B.LOTE, A.TIPO_MOVIMIENTO,");
                sql.AppendLine("A.NRO_PLAN_PAGO, A.NRO_CUOTA");
                sql.AppendLine("FROM CTACTE_EXPENSAS A INNER JOIN INMUEBLES B ON A.NRO_CTA=B.NRO_CTA");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS C ON A.PERIODO=C.PERIODO");
                sql.AppendLine("WHERE A.NRO_CTA=@NRO_CTA AND");
                sql.AppendLine("((TIPO_MOVIMIENTO IN (1,100) AND (NRO_PLAN_PAGO IS NULL OR NRO_PLAN_PAGO = 0))");
                sql.AppendLine("OR TIPO_MOVIMIENTO = 3) AND PAGADO = 0 AND CAE IS NOT NULL");
                sql.AppendLine("AND C.VENCIMIENTO_3 <= GETDATE()");
                sql.AppendLine("ORDER BY PERIODO DESC");


                List<INFORME_PERIODOS> lst = new List<INFORME_PERIODOS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", NRO_CTA);
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
        public static List<INFORME_PERIODOS> readPeriodos()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.NRO_CTA, A.PERIODO, A.SALDO_CAPITAL + A.INTERES_MORA, B.MANZANA, B.LOTE, A.TIPO_MOVIMIENTO, A.NRO_PLAN_PAGO, A.NRO_CUOTA");
                sql.AppendLine("FROM CTACTE_EXPENSAS A INNER JOIN INMUEBLES B ON A.NRO_CTA=B.NRO_CTA");
                sql.AppendLine("WHERE ((TIPO_MOVIMIENTO IN (1,100) AND (NRO_PLAN_PAGO IS NULL OR NRO_PLAN_PAGO = 0)) OR TIPO_MOVIMIENTO = 3) AND PAGADO = 0 AND CAE IS NOT NULL");
                sql.AppendLine("ORDER BY A.NRO_CTA ASC, A.PERIODO DESC");

                List<INFORME_PERIODOS> lst = new List<INFORME_PERIODOS>();
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
        public static List<INFORME_PERIODOS> readPeriodosMora()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.NRO_CTA, A.PERIODO, A.SALDO_CAPITAL + A.INTERES_MORA, B.MANZANA,");
                sql.AppendLine("B.LOTE, A.TIPO_MOVIMIENTO, A.NRO_PLAN_PAGO, A.NRO_CUOTA");
                sql.AppendLine("FROM CTACTE_EXPENSAS A INNER JOIN INMUEBLES B ON A.NRO_CTA=B.NRO_CTA");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS C ON A.PERIODO=C.PERIODO");
                sql.AppendLine("WHERE ((TIPO_MOVIMIENTO IN (1,100) AND (NRO_PLAN_PAGO IS NULL OR");
                sql.AppendLine("NRO_PLAN_PAGO = 0)) OR TIPO_MOVIMIENTO = 3) AND PAGADO = 0 AND CAE IS NOT NULL");
                sql.AppendLine("AND C.VENCIMIENTO_3 <= GETDATE()");
                sql.AppendLine("ORDER BY A.NRO_CTA ASC, A.PERIODO DESC");


                List<INFORME_PERIODOS> lst = new List<INFORME_PERIODOS>();
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
    }
}
