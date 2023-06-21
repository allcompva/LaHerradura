using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PRUEBA : DALBase
    {
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public bool acreditada { get; set; }

        public PRUEBA()
        {
            codigo = 0;
            descripcion = string.Empty;
            acreditada = false;
        }

        private static List<PRUEBA> mapeo(SqlDataReader dr)
        {
            List<PRUEBA> lst = new List<PRUEBA>();
            PRUEBA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new PRUEBA();
                    if (!dr.IsDBNull(0)) { obj.codigo = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.descripcion = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.acreditada = dr.GetBoolean(2); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PRUEBA> read()
        {
            try
            {
                List<PRUEBA> lst = new List<PRUEBA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM PRUEBA WHERE acreditada IS NULL";
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

        public static PRUEBA getByPk(
        int codigo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM PRUEBA WHERE");
                sql.AppendLine("codigo = @codigo");
                PRUEBA obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@codigo", codigo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PRUEBA> lst = mapeo(dr);
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

        public static int insert(PRUEBA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO PRUEBA(");
                sql.AppendLine("descripcion");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@descripcion");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@descripcion", obj.descripcion);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(PRUEBA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  PRUEBA SET");
                sql.AppendLine("acreditada=1");
                sql.AppendLine("WHERE");
                sql.AppendLine("codigo=@codigo");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@codigo", obj.codigo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(PRUEBA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  PRUEBA ");
                sql.AppendLine("WHERE");
                sql.AppendLine("codigo=@codigo");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@codigo", obj.codigo);
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
