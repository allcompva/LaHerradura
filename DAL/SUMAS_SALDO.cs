using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class SUMAS_SALDO : DALBase
    {
        public string N5 { get; set; }
        public string DESC_SUBCUENTA { get; set; }
        public decimal SALDO_ANTERIOR_DEBE { get; set; }
        public decimal SALDO_ANTERIOR_HABER { get; set; }
        public decimal DEBE { get; set; }
        public decimal HABER { get; set; }
        public decimal SALDO_DEBE { get; set; }
        public decimal SALDO_HABER { get; set; }

        public SUMAS_SALDO()
        {
            N5 = string.Empty;
            DESC_SUBCUENTA = string.Empty;
            SALDO_ANTERIOR_DEBE = 0;
            SALDO_ANTERIOR_HABER = 0;
            DEBE = 0;
            HABER = 0;
            SALDO_DEBE = 0;
            SALDO_HABER = 0;
        }

        private static List<SUMAS_SALDO> mapeo(SqlDataReader dr)
        {
            List<SUMAS_SALDO> lst = new List<SUMAS_SALDO>();
            SUMAS_SALDO obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new SUMAS_SALDO();
                    if (!dr.IsDBNull(0)) { obj.N5 = dr.GetString(0); }
                    if (!dr.IsDBNull(1)) { obj.DESC_SUBCUENTA = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.SALDO_ANTERIOR_DEBE = dr.GetDecimal(2); }
                    if (!dr.IsDBNull(3)) { obj.SALDO_ANTERIOR_HABER = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.DEBE = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.HABER = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.SALDO_DEBE = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.SALDO_HABER = dr.GetDecimal(7); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<SUMAS_SALDO> read(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT N5, DESC_SUBCUENTA,");
                if (fechaDesde.Day == 1 && fechaDesde.Month == 1)
                    sql.AppendLine("CONVERT(DECIMAL(16,2),0),CONVERT(DECIMAL(16,2),0),");
                else
                {
                    sql.AppendLine("(SELECT ISNULL(SUM(DEBE),0) FROM ASIENTOS_DETALLE B");
                    sql.AppendLine("INNER JOIN ASIENTOS B1 ON B.ID_ASIENTO=B1.ID");
                    sql.AppendLine("WHERE A.ID=B.ID_CUENTA AND CONVERT(DATE,B1.FECHA) BETWEEN @FECHA_DESDE_ANT");
                    sql.AppendLine("AND @FEHCA_HASTA_ANT and b1.tipo<>6)");
                    sql.AppendLine("AS SALDO_ANTERIOR_DEBE,");
                    sql.AppendLine("(SELECT ISNULL(SUM(HABER),0) FROM ASIENTOS_DETALLE B");
                    sql.AppendLine("INNER JOIN ASIENTOS B1 ON B.ID_ASIENTO=B1.ID");
                    sql.AppendLine("WHERE A.ID=B.ID_CUENTA AND CONVERT(DATE,B1.FECHA) BETWEEN @FECHA_DESDE_ANT ");
                    sql.AppendLine("AND @FEHCA_HASTA_ANT and b1.tipo<>6)");
                    sql.AppendLine("AS SALDO_ANTERIOR_HABER,");
                }


                sql.AppendLine("(SELECT ISNULL(SUM(DEBE),0) FROM ASIENTOS_DETALLE B");
                sql.AppendLine("INNER JOIN ASIENTOS B1 ON B.ID_ASIENTO=B1.ID");
                sql.AppendLine("WHERE A.ID=B.ID_CUENTA AND CONVERT(DATE,B1.FECHA) BETWEEN @FECHA_DESDE AND @FECHA_HASTA and b1.tipo<>6)");
                sql.AppendLine("AS DEBE,");
                sql.AppendLine("(SELECT ISNULL(SUM(HABER),0) FROM ASIENTOS_DETALLE B");
                sql.AppendLine("INNER JOIN ASIENTOS B1 ON B.ID_ASIENTO=B1.ID");
                sql.AppendLine("WHERE A.ID=B.ID_CUENTA AND CONVERT(DATE,B1.FECHA) BETWEEN @FECHA_DESDE AND @FECHA_HASTA and b1.tipo<>6)");
                sql.AppendLine("AS HABER,");
                if (fechaDesde.Day == 1 && fechaDesde.Month == 1)
                {
                    sql.AppendLine("(SELECT ISNULL(SUM(DEBE),0) FROM ASIENTOS_DETALLE B");
                    sql.AppendLine("INNER JOIN ASIENTOS B1 ON B.ID_ASIENTO=B1.ID");
                    sql.AppendLine("WHERE A.ID=B.ID_CUENTA AND CONVERT(DATE,B1.FECHA) BETWEEN @FECHA_DESDE AND @FECHA_HASTA and b1.tipo<>6)");
                    sql.AppendLine("AS SALDO_DEBE,");
                }
                else
                {
                    sql.AppendLine("(SELECT ISNULL(SUM(DEBE),0) FROM ASIENTOS_DETALLE B");
                    sql.AppendLine("INNER JOIN ASIENTOS B1 ON B.ID_ASIENTO=B1.ID");
                    sql.AppendLine("WHERE A.ID=B.ID_CUENTA AND CONVERT(DATE,B1.FECHA) BETWEEN @FECHA_DESDE_ANT");
                    sql.AppendLine("AND @FEHCA_HASTA_ANT and b1.tipo<>6) +");
                    sql.AppendLine("(SELECT ISNULL(SUM(DEBE),0) FROM ASIENTOS_DETALLE B");
                    sql.AppendLine("INNER JOIN ASIENTOS B1 ON B.ID_ASIENTO=B1.ID");
                    sql.AppendLine("WHERE A.ID=B.ID_CUENTA AND CONVERT(DATE,B1.FECHA) BETWEEN @FECHA_DESDE AND @FECHA_HASTA and b1.tipo<>6)");
                    sql.AppendLine("AS SALDO_DEBE,");
                }

                if (fechaDesde.Day == 1 && fechaDesde.Month == 1)
                {
                    sql.AppendLine("(SELECT ISNULL(SUM(HABER),0) FROM ASIENTOS_DETALLE B");
                    sql.AppendLine("INNER JOIN ASIENTOS B1 ON B.ID_ASIENTO=B1.ID");
                    sql.AppendLine("WHERE A.ID=B.ID_CUENTA AND CONVERT(DATE,B1.FECHA) BETWEEN @FECHA_DESDE AND @FECHA_HASTA and b1.tipo<>6)");
                    sql.AppendLine("AS SALDO_HABER");
                    sql.AppendLine("FROM PLAN_CUENTA A");
                }
                else
                {
                    sql.AppendLine("(SELECT ISNULL(SUM(HABER),0) FROM ASIENTOS_DETALLE B");
                    sql.AppendLine("INNER JOIN ASIENTOS B1 ON B.ID_ASIENTO=B1.ID");
                    sql.AppendLine("WHERE A.ID=B.ID_CUENTA AND CONVERT(DATE,B1.FECHA) BETWEEN @FECHA_DESDE_ANT");
                    sql.AppendLine("AND @FEHCA_HASTA_ANT and tipo<>6) +");
                    sql.AppendLine("(SELECT ISNULL(SUM(HABER),0) FROM ASIENTOS_DETALLE B");
                    sql.AppendLine("INNER JOIN ASIENTOS B1 ON B.ID_ASIENTO=B1.ID");
                    sql.AppendLine("WHERE A.ID=B.ID_CUENTA AND CONVERT(DATE,B1.FECHA) BETWEEN @FECHA_DESDE AND @FECHA_HASTA and b1.tipo<>6)");
                    sql.AppendLine("AS SALDO_HABER");
                    sql.AppendLine("FROM PLAN_CUENTA A");
                }


                List<SUMAS_SALDO> lst = new List<SUMAS_SALDO>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    if (fechaDesde.Day == 1 && fechaDesde.Month == 1)
                    {
                        string desde = string.Format("{0}{1}{2}",
                        fechaDesde.Year,
                        fechaDesde.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                        fechaDesde.Day.ToString().PadLeft(2, Convert.ToChar("0")));
                        cmd.Parameters.AddWithValue("@FECHA_DESDE", desde);
                        string hasta = string.Format("{0}{1}{2}",
                            fechaHasta.Year,
                            fechaHasta.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                            fechaHasta.Day.ToString().PadLeft(2, Convert.ToChar("0")));
                        cmd.Parameters.AddWithValue("@FECHA_HASTA", hasta);

                    }
                    else
                    {
                        string desde = string.Format("{0}{1}{2}",
                            fechaDesde.Year,
                            fechaDesde.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                            fechaDesde.Day.ToString().PadLeft(2, Convert.ToChar("0")));
                        cmd.Parameters.AddWithValue("@FECHA_DESDE", desde);
                        string hasta = string.Format("{0}{1}{2}",
                            fechaHasta.Year,
                            fechaHasta.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                            fechaHasta.Day.ToString().PadLeft(2, Convert.ToChar("0")));
                        cmd.Parameters.AddWithValue("@FECHA_HASTA", hasta);

                        DateTime hastaAnt = fechaHasta.AddMonths(-1);

                        string _desdeAnt = string.Format("{0}{1}{2}",
                        fechaDesde.Year,
                        "01",
                        "01");

                        int anioAnt = fechaHasta.Year;
                        int mesAnt = fechaHasta.Month - 1;
                        int diaAnt =
                        DateTime.DaysInMonth(anioAnt, mesAnt);


                        string _hastaAnt = string.Format("{0}{1}{2}",
                        hastaAnt.Year,
                        mesAnt.ToString().PadLeft(2, Convert.ToChar("0")),
                        diaAnt.ToString().PadLeft(2, Convert.ToChar("0")));

                        cmd.Parameters.AddWithValue("@FECHA_DESDE_ANT", _desdeAnt);
                        cmd.Parameters.AddWithValue("@FEHCA_HASTA_ANT", _hastaAnt);
                    }
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

        public static SUMAS_SALDO getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM SUMAS_SALDO WHERE");
                SUMAS_SALDO obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<SUMAS_SALDO> lst = mapeo(dr);
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

        public static int insert(SUMAS_SALDO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO SUMAS_SALDO(");
                sql.AppendLine("N5");
                sql.AppendLine(", DESC_SUBCUENTA");
                sql.AppendLine(", SALDO_ANTERIOR_DEBE");
                sql.AppendLine(", SALDO_ANTERIOR_HABER");
                sql.AppendLine(", DEBE");
                sql.AppendLine(", HABER");
                sql.AppendLine(", SALDO_DEBE");
                sql.AppendLine(", SALDO_HABER");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@N5");
                sql.AppendLine(", @DESC_SUBCUENTA");
                sql.AppendLine(", @SALDO_ANTERIOR_DEBE");
                sql.AppendLine(", @SALDO_ANTERIOR_HABER");
                sql.AppendLine(", @DEBE");
                sql.AppendLine(", @HABER");
                sql.AppendLine(", @SALDO_DEBE");
                sql.AppendLine(", @SALDO_HABER");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@N5", obj.N5);
                    cmd.Parameters.AddWithValue("@DESC_SUBCUENTA", obj.DESC_SUBCUENTA);
                    cmd.Parameters.AddWithValue("@SALDO_ANTERIOR_DEBE", obj.SALDO_ANTERIOR_DEBE);
                    cmd.Parameters.AddWithValue("@SALDO_ANTERIOR_HABER", obj.SALDO_ANTERIOR_HABER);
                    cmd.Parameters.AddWithValue("@DEBE", obj.DEBE);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@SALDO_DEBE", obj.SALDO_DEBE);
                    cmd.Parameters.AddWithValue("@SALDO_HABER", obj.SALDO_HABER);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(SUMAS_SALDO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  SUMAS_SALDO SET");
                sql.AppendLine("N5=@N5");
                sql.AppendLine(", DESC_SUBCUENTA=@DESC_SUBCUENTA");
                sql.AppendLine(", SALDO_ANTERIOR_DEBE=@SALDO_ANTERIOR_DEBE");
                sql.AppendLine(", SALDO_ANTERIOR_HABER=@SALDO_ANTERIOR_HABER");
                sql.AppendLine(", DEBE=@DEBE");
                sql.AppendLine(", HABER=@HABER");
                sql.AppendLine(", SALDO_DEBE=@SALDO_DEBE");
                sql.AppendLine(", SALDO_HABER=@SALDO_HABER");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@N5", obj.N5);
                    cmd.Parameters.AddWithValue("@DESC_SUBCUENTA", obj.DESC_SUBCUENTA);
                    cmd.Parameters.AddWithValue("@SALDO_ANTERIOR_DEBE", obj.SALDO_ANTERIOR_DEBE);
                    cmd.Parameters.AddWithValue("@SALDO_ANTERIOR_HABER", obj.SALDO_ANTERIOR_HABER);
                    cmd.Parameters.AddWithValue("@DEBE", obj.DEBE);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@SALDO_DEBE", obj.SALDO_DEBE);
                    cmd.Parameters.AddWithValue("@SALDO_HABER", obj.SALDO_HABER);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(SUMAS_SALDO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  SUMAS_SALDO ");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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

