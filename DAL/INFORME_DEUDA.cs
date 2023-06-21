using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class INFORME_DEUDA : DALBase
    {
        public int NRO_CTA { get; set; }
        public int PERIODO { get; set; }
        public DateTime FECHA { get; set; }
        public string DESCRIPCION { get; set; }
        public string HABER { get; set; }
        public string PERIODO_MAQUILLADO { get; set; }

        public int NRO_PLAN_PAGO { get; set; }
        public int NRO_CUOTA { get; set; }

        public int COUNT { get; set; }
        public int CANT_CUENTAS { get; set; }
        public decimal TOTAL { get; set; }
        public int NRO_RECIBO_PAGO { get; set; }

        public INFORME_DEUDA()
        {
            NRO_CTA = 0;
            PERIODO = 0;
            DESCRIPCION = string.Empty;
            HABER = string.Empty;
            PERIODO_MAQUILLADO = string.Empty;
            NRO_PLAN_PAGO = 0;
            NRO_CUOTA = 0;
        }

        private static List<INFORME_DEUDA> mapeo(SqlDataReader dr)
        {
            List<INFORME_DEUDA> lst = new List<INFORME_DEUDA>();
            INFORME_DEUDA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    obj = new INFORME_DEUDA();
                    if (!dr.IsDBNull(0)) { obj.NRO_CTA = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.PERIODO = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.FECHA = dr.GetDateTime(2); }
                    if (!dr.IsDBNull(3)) { obj.TOTAL = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.NRO_PLAN_PAGO = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.NRO_CUOTA = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.NRO_RECIBO_PAGO = dr.GetInt32(6); }

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

                            if (obj.NRO_PLAN_PAGO != 0)
                                obj.PERIODO_MAQUILLADO = string.Format("Plan de pago Nro.: {0} - Cuota {1}",
                                    obj.NRO_PLAN_PAGO, obj.NRO_CUOTA);
                        }
                    }
                    else
                    {
                        obj.PERIODO_MAQUILLADO = "Saldo (capital) a Sept. 2019";
                    }

                    lst.Add(obj);
                }
            }
            return lst;
        }
        private static List<INFORME_DEUDA> mapeo2(SqlDataReader dr)
        {
            List<INFORME_DEUDA> lst = new List<INFORME_DEUDA>();
            INFORME_DEUDA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new INFORME_DEUDA();
                    if (!dr.IsDBNull(0)) { obj.DESCRIPCION = dr.GetString(0); }
                    if (!dr.IsDBNull(1)) { obj.CANT_CUENTAS = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.TOTAL = dr.GetDecimal(2); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        //MAPEO
        public static List<INFORME_DEUDA> read(int anio, int mes)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT NRO_CTA, PERIODO, FECHA,");
                sql.AppendLine("A.HABER, A.NRO_PLAN_PAGO, A.NRO_CUOTA,");
                sql.AppendLine("A.NRO_RECIBO_PAGO");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE TIPO_MOVIMIENTO = 2");
                if (mes != 0)
                    sql.AppendLine("AND  MONTH(FECHA) = @MES AND YEAR(FECHA) = @ANIO");
                else
                    sql.AppendLine("AND YEAR(FECHA) = @ANIO");
                List<INFORME_DEUDA> lst = new List<INFORME_DEUDA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    if (mes != 0)
                    {
                        cmd.Parameters.AddWithValue("@ANIO", anio);
                        cmd.Parameters.AddWithValue("@MES", mes);
                    }
                    else
                        cmd.Parameters.AddWithValue("@ANIO", anio);

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
        //MAPEO 2
        public static List<INFORME_DEUDA> readMediosPago(int anio, int mes)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT B.DESCRIPCION, COUNT(*) AS CANT_CUENTAS, SUM(A.MONTO) AS TOTAL");
                sql.AppendLine("FROM PAGOS_X_FACTURA A");
                sql.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_PLAN_PAGO=B.ID");
                if (mes != 0)
                    sql.AppendLine("WHERE MONTH(FECHA) = @MES AND YEAR(FECHA) = @ANIO");
                else
                    sql.AppendLine("WHERE YEAR(FECHA) = @ANIO");
                sql.AppendLine("GROUP BY B.DESCRIPCION");
                sql.AppendLine("ORDER BY B.DESCRIPCION");

                List<INFORME_DEUDA> lst = new List<INFORME_DEUDA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    if (mes != 0)
                    {
                        cmd.Parameters.AddWithValue("@ANIO", anio);
                        cmd.Parameters.AddWithValue("@MES", mes);
                    }
                    else
                        cmd.Parameters.AddWithValue("@ANIO", anio);
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
        //SIN MAPEO
        public static List<INFORME_DEUDA> readPeriodos(int anio, int _mes)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.PERIODO, COUNT(*) AS CANT_CUENTAS, SUM(A.HABER) AS TOTAL");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE TIPO_MOVIMIENTO = 2");
                if (_mes != 0)
                    sql.AppendLine("AND  MONTH(FECHA) = @MES AND YEAR(FECHA) = @ANIO");
                else
                    sql.AppendLine("AND YEAR(FECHA) = @ANIO");

                sql.AppendLine("AND (NRO_PLAN_PAGO = 0 OR NRO_PLAN_PAGO IS NULL)");
                sql.AppendLine("GROUP BY A.PERIODO");
                sql.AppendLine("UNION");
                sql.AppendLine("SELECT 0, COUNT(*) AS CANT_CUENTAS, SUM(A.HABER) AS TOTAL");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE TIPO_MOVIMIENTO = 2");
                if (_mes != 0)
                    sql.AppendLine("AND  MONTH(FECHA) = @MES AND YEAR(FECHA) = @ANIO AND NRO_PLAN_PAGO > 0");
                else
                    sql.AppendLine("AND YEAR(FECHA) = @ANIO AND NRO_PLAN_PAGO > 0");
                sql.AppendLine("ORDER BY A.PERIODO");

                List<INFORME_DEUDA> lst = new List<INFORME_DEUDA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    if (_mes != 0)
                    {
                        cmd.Parameters.AddWithValue("@ANIO", anio);
                        cmd.Parameters.AddWithValue("@MES", _mes);
                    }
                    else
                        cmd.Parameters.AddWithValue("@ANIO", anio);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    INFORME_DEUDA obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new INFORME_DEUDA();
                            if (!dr.IsDBNull(0)) { obj.PERIODO = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.CANT_CUENTAS = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.TOTAL = dr.GetDecimal(2); }

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
                                        if (int.Parse(
                                            obj.PERIODO.ToString().Substring(6, 2)) >= 10)
                                        {
                                            obj.PERIODO_MAQUILLADO = "Facturacion Externa";
                                        }
                                        else
                                        {
                                            obj.PERIODO_MAQUILLADO = string.Format("Expensas Extraordinarias mes de {0} de {1}",
                                                mes,
                                                obj.PERIODO.ToString().Substring(0, 4));
                                        }
                                    }
                                    //if (obj.NRO_CTA != 0)
                                    //{
                                    //    obj.PERIODO_MAQUILLADO = string.Format("Plan de pago Nro.: {0} - Cuota: {1}",
                                    //        obj.);
                                    //}
                                }
                            }
                            else
                            {
                                obj.PERIODO_MAQUILLADO = "Saldo (capital) a Sept. 2019";
                            }
                            if (obj.PERIODO == 0)
                                obj.PERIODO_MAQUILLADO = "Planes de pago";
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
    }
}
