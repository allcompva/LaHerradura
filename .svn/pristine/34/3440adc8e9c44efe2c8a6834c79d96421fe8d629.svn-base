using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class EXCLUSION_CONCEPTO : DALBase
    {
        public int PERIODO { get; set; }
        public int ID_CONCEPTO { get; set; }
        public int NRO_CTA { get; set; }

        public EXCLUSION_CONCEPTO()
        {
            PERIODO = 0;
            ID_CONCEPTO = 0;
            NRO_CTA = 0;
        }

        private static List<EXCLUSION_CONCEPTO> mapeo(SqlDataReader dr)
        {
            List<EXCLUSION_CONCEPTO> lst = new List<EXCLUSION_CONCEPTO>();
            EXCLUSION_CONCEPTO obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new EXCLUSION_CONCEPTO();
                    if (!dr.IsDBNull(0)) { obj.PERIODO = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.ID_CONCEPTO = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.NRO_CTA = dr.GetInt32(2); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<EXCLUSION_CONCEPTO> read()
        {
            try
            {
                List<EXCLUSION_CONCEPTO> lst = new List<EXCLUSION_CONCEPTO>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM EXCLUSION_CONCEPTO";
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

        public static EXCLUSION_CONCEPTO getByPk(
        int PERIODO, int ID_CONCEPTO, int NRO_CTA)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM EXCLUSION_CONCEPTO WHERE");
                sql.AppendLine("PERIODO = @PERIODO");
                sql.AppendLine("AND ID_CONCEPTO = @ID_CONCEPTO");
                sql.AppendLine("AND NRO_CTA = @NRO_CTA");
                EXCLUSION_CONCEPTO obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", PERIODO);
                    cmd.Parameters.AddWithValue("@ID_CONCEPTO", ID_CONCEPTO);
                    cmd.Parameters.AddWithValue("@NRO_CTA", NRO_CTA);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<EXCLUSION_CONCEPTO> lst = mapeo(dr);
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

        public static void insert(EXCLUSION_CONCEPTO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO EXCLUSION_CONCEPTO(");
                sql.AppendLine("PERIODO");
                sql.AppendLine(", ID_CONCEPTO");
                sql.AppendLine(", NRO_CTA");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@PERIODO");
                sql.AppendLine(", @ID_CONCEPTO");
                sql.AppendLine(", @NRO_CTA");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", obj.PERIODO);
                    cmd.Parameters.AddWithValue("@ID_CONCEPTO", obj.ID_CONCEPTO);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(EXCLUSION_CONCEPTO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  EXCLUSION_CONCEPTO SET");
                sql.AppendLine("WHERE");
                sql.AppendLine("PERIODO=@PERIODO");
                sql.AppendLine("AND ID_CONCEPTO=@ID_CONCEPTO");
                sql.AppendLine("AND NRO_CTA=@NRO_CTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", obj.PERIODO);
                    cmd.Parameters.AddWithValue("@ID_CONCEPTO", obj.ID_CONCEPTO);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(EXCLUSION_CONCEPTO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  EXCLUSION_CONCEPTO ");
                sql.AppendLine("WHERE");
                sql.AppendLine("PERIODO=@PERIODO");
                sql.AppendLine("AND ID_CONCEPTO=@ID_CONCEPTO");
                sql.AppendLine("AND NRO_CTA=@NRO_CTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", obj.PERIODO);
                    cmd.Parameters.AddWithValue("@ID_CONCEPTO", obj.ID_CONCEPTO);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(int periodo, int idConcepto)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  EXCLUSION_CONCEPTO ");
                sql.AppendLine("WHERE");
                sql.AppendLine("PERIODO=@PERIODO");
                sql.AppendLine("AND ID_CONCEPTO=@ID_CONCEPTO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@ID_CONCEPTO", idConcepto);
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

