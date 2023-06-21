using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class provincias : DALBase
    {
        public int id_provincia { get; set; }
        public string provincia { get; set; }
        public int id_pais { get; set; }

        public provincias()
        {
            id_provincia = 0;
            provincia = string.Empty;
            id_pais = 0;
        }

        private static List<provincias> mapeo(SqlDataReader dr)
        {
            List<provincias> lst = new List<provincias>();
            provincias obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new provincias();
                    if (!dr.IsDBNull(0)) { obj.id_provincia = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.provincia = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.id_pais = dr.GetInt32(2); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<provincias> read(int idPais)
        {
            try
            {
                List<provincias> lst = new List<provincias>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM provincias WHERE ID_PAIS=@ID_PAIS";
                    cmd.Parameters.AddWithValue("@ID_PAIS", idPais);
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

        public static provincias getByPk(
        int id_provincia)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM provincias WHERE");
                sql.AppendLine("id_provincia = @id_provincia");
                provincias obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_provincia", id_provincia);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<provincias> lst = mapeo(dr);
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

        public static int insert(provincias obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO provincias(");
                sql.AppendLine("provincia");
                sql.AppendLine(", id_pais");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@provincia");
                sql.AppendLine(", @id_pais");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@provincia", obj.provincia);
                    cmd.Parameters.AddWithValue("@id_pais", obj.id_pais);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(provincias obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  provincias SET");
                sql.AppendLine("provincia=@provincia");
                sql.AppendLine(", id_pais=@id_pais");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_provincia=@id_provincia");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@provincia", obj.provincia);
                    cmd.Parameters.AddWithValue("@id_pais", obj.id_pais);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(provincias obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  provincias ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id_provincia=@id_provincia");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id_provincia", obj.id_provincia);
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

