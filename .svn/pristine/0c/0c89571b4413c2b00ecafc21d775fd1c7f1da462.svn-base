using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class ASIENTO_PAGO_EXPENSAS_HABER : DALBase
    {
        public int NRO_CTA { get; set; }
        public decimal CAPITAL { get; set; }
        public decimal INTERES { get; set; }
        public decimal TOTAL { get; set; }

        public ASIENTO_PAGO_EXPENSAS_HABER()
        {
            NRO_CTA = 0;
            CAPITAL = 0;
            INTERES = 0;
            TOTAL = 0;
        }

        private static List<ASIENTO_PAGO_EXPENSAS_HABER> mapeo(SqlDataReader dr)
        {
            List<ASIENTO_PAGO_EXPENSAS_HABER> lst = new List<ASIENTO_PAGO_EXPENSAS_HABER>();
            ASIENTO_PAGO_EXPENSAS_HABER obj;

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new ASIENTO_PAGO_EXPENSAS_HABER();
                    if (!dr.IsDBNull(0)) { obj.NRO_CTA = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.CAPITAL = dr.GetDecimal(1); }
                    if (!dr.IsDBNull(2)) { obj.INTERES = dr.GetDecimal(2); }
                    if (!dr.IsDBNull(3)) { obj.TOTAL = dr.GetDecimal(3); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<ASIENTO_PAGO_EXPENSAS_HABER> read(int nroRecibo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT  A.NRO_CTA, SUM(A.CAPITAL_PAGADO) AS CAPITAL,");
                sql.AppendLine("SUM(A.INTERES_PAGADO) AS INTERES, SUM(A.HABER) AS TOTAL");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE TIPO_MOVIMIENTO=2 AND A.NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO");
                sql.AppendLine("GROUP BY A.NRO_CTA");

                List<ASIENTO_PAGO_EXPENSAS_HABER> lst = new List<ASIENTO_PAGO_EXPENSAS_HABER>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", nroRecibo);
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

        public static ASIENTO_PAGO_EXPENSAS_HABER getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM ASIENTO_PAGO_EXPENSAS_HABER WHERE");
                ASIENTO_PAGO_EXPENSAS_HABER obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ASIENTO_PAGO_EXPENSAS_HABER> lst = mapeo(dr);
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

        public static int insert(ASIENTO_PAGO_EXPENSAS_HABER obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO ASIENTO_PAGO_EXPENSAS_HABER(");
                sql.AppendLine("NRO_CTA");
                sql.AppendLine(", CAPITAL");
                sql.AppendLine(", INTERES");
                sql.AppendLine(", TOTAL");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@NRO_CTA");
                sql.AppendLine(", @CAPITAL");
                sql.AppendLine(", @INTERES");
                sql.AppendLine(", @TOTAL");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@CAPITAL", obj.CAPITAL);
                    cmd.Parameters.AddWithValue("@INTERES", obj.INTERES);
                    cmd.Parameters.AddWithValue("@TOTAL", obj.TOTAL);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(ASIENTO_PAGO_EXPENSAS_HABER obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  ASIENTO_PAGO_EXPENSAS_HABER SET");
                sql.AppendLine("NRO_CTA=@NRO_CTA");
                sql.AppendLine(", CAPITAL=@CAPITAL");
                sql.AppendLine(", INTERES=@INTERES");
                sql.AppendLine(", TOTAL=@TOTAL");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@CAPITAL", obj.CAPITAL);
                    cmd.Parameters.AddWithValue("@INTERES", obj.INTERES);
                    cmd.Parameters.AddWithValue("@TOTAL", obj.TOTAL);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(ASIENTO_PAGO_EXPENSAS_HABER obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  ASIENTO_PAGO_EXPENSAS_HABER ");
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

