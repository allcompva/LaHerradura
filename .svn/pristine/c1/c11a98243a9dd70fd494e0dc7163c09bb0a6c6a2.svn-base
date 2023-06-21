using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class BANCOS : DALBase
    {
        public string CODIGO { get; set; }
        public string DENOMINACION { get; set; }

        public BANCOS()
        {
            CODIGO = string.Empty;
            DENOMINACION = string.Empty;
        }

        private static List<BANCOS> mapeo(SqlDataReader dr)
        {
            List<BANCOS> lst = new List<BANCOS>();
            BANCOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new BANCOS();
                    if (!dr.IsDBNull(0)) { obj.CODIGO = dr.GetString(0); }
                    if (!dr.IsDBNull(1)) { obj.DENOMINACION = dr.GetString(1); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<BANCOS> read()
        {
            try
            {
                List<BANCOS> lst = new List<BANCOS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM BANCOS ORDER BY DENOMINACION";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en el Metodo Bancos.read : ", ex);
            }
        }

        public static BANCOS getByPk(
        string CODIGO)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM BANCOS WHERE");
                sql.AppendLine("CODIGO = @CODIGO");
                BANCOS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@CODIGO",
                        CODIGO.PadLeft(5,Convert.ToChar("0")));
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<BANCOS> lst = mapeo(dr);
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

        public static int insert(BANCOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO BANCOS(");
                sql.AppendLine("CODIGO");
                sql.AppendLine(", DENOMINACION");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@CODIGO");
                sql.AppendLine(", @DENOMINACION");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@CODIGO", obj.CODIGO);
                    cmd.Parameters.AddWithValue("@DENOMINACION", obj.DENOMINACION);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(BANCOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  BANCOS SET");
                sql.AppendLine("DENOMINACION=@DENOMINACION");
                sql.AppendLine("WHERE");
                sql.AppendLine("CODIGO=@CODIGO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@CODIGO", obj.CODIGO);
                    cmd.Parameters.AddWithValue("@DENOMINACION", obj.DENOMINACION);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(BANCOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  BANCOS ");
                sql.AppendLine("WHERE");
                sql.AppendLine("CODIGO=@CODIGO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@CODIGO", obj.CODIGO);
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

