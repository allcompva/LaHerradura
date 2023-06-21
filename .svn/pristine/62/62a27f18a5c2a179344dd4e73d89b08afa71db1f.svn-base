using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class MAIL_X_CTAS : DALBase
    {
        public int ID { get; set; }
        public int NRO_CTA { get; set; }
        public string REFERENCIA { get; set; }
        public string MAIL { get; set; }

        public MAIL_X_CTAS()
        {
            ID = 0;
            NRO_CTA = 0;
            REFERENCIA = string.Empty;
            MAIL = string.Empty;
        }

        private static List<MAIL_X_CTAS> mapeo(SqlDataReader dr)
        {
            List<MAIL_X_CTAS> lst = new List<MAIL_X_CTAS>();
            MAIL_X_CTAS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new MAIL_X_CTAS();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.REFERENCIA = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.MAIL = dr.GetString(3); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<MAIL_X_CTAS> read()
        {
            try
            {
                List<MAIL_X_CTAS> lst = new List<MAIL_X_CTAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM MAIL_X_CTAS";
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

        public static List<MAIL_X_CTAS> getByCta(int cta)
        {
            try
            {
                List<MAIL_X_CTAS> lst = new List<MAIL_X_CTAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM MAIL_X_CTAS WHERE NRO_CTA=@NRO_CTA";
                    cmd.Parameters.AddWithValue("@NRO_CTA", cta);
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

        public static MAIL_X_CTAS getByPk(
        int INT)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM MAIL_X_CTAS WHERE");
                sql.AppendLine("ID = @ID");
                MAIL_X_CTAS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", INT);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<MAIL_X_CTAS> lst = mapeo(dr);
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

        public static int insert(MAIL_X_CTAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO MAIL_X_CTAS(");
                sql.AppendLine("NRO_CTA");
                sql.AppendLine(", REFERENCIA");
                sql.AppendLine(", MAIL");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@NRO_CTA");
                sql.AppendLine(", @REFERENCIA");
                sql.AppendLine(", @MAIL");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@REFERENCIA", obj.REFERENCIA);
                    cmd.Parameters.AddWithValue("@MAIL", obj.MAIL);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(MAIL_X_CTAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  MAIL_X_CTAS SET");
                sql.AppendLine("NRO_CTA=@NRO_CTA");
                sql.AppendLine(", REFERENCIA=@REFERENCIA");
                sql.AppendLine(", MAIL=@MAIL");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@REFERENCIA", obj.REFERENCIA);
                    cmd.Parameters.AddWithValue("@MAIL", obj.MAIL);
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

        public static void delete(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  MAIL_X_CTAS ");
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

    }
}

