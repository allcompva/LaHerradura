using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class paises : DALBase
    {
        public int id { get; set; }
        public Int16 code { get; set; }
        public string iso3166a1 { get; set; }
        public string iso3166a2 { get; set; }
        public string nombre { get; set; }

        public paises()
        {
            id = 0;
            code = 0;
            iso3166a1 = string.Empty;
            iso3166a2 = string.Empty;
            nombre = string.Empty;
        }

        private static List<paises> mapeo(SqlDataReader dr)
        {
            List<paises> lst = new List<paises>();
            paises obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new paises();
                    if (!dr.IsDBNull(0)) { obj.id = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.code = dr.GetInt16(1); }
                    if (!dr.IsDBNull(2)) { obj.iso3166a1 = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.iso3166a2 = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.nombre = dr.GetString(4); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<paises> read()
        {
            try
            {
                List<paises> lst = new List<paises>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM paises";
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

        public static paises getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM paises WHERE");
                sql.AppendLine("id = @id");
                paises obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<paises> lst = mapeo(dr);
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

        public static int insert(paises obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO paises(");
                sql.AppendLine("id");
                sql.AppendLine(", code");
                sql.AppendLine(", iso3166a1");
                sql.AppendLine(", iso3166a2");
                sql.AppendLine(", nombre");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@id");
                sql.AppendLine(", @code");
                sql.AppendLine(", @iso3166a1");
                sql.AppendLine(", @iso3166a2");
                sql.AppendLine(", @nombre");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@code", obj.code);
                    cmd.Parameters.AddWithValue("@iso3166a1", obj.iso3166a1);
                    cmd.Parameters.AddWithValue("@iso3166a2", obj.iso3166a2);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(paises obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  paises SET");
                sql.AppendLine("code=@code");
                sql.AppendLine(", iso3166a1=@iso3166a1");
                sql.AppendLine(", iso3166a2=@iso3166a2");
                sql.AppendLine(", nombre=@nombre");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
                    cmd.Parameters.AddWithValue("@code", obj.code);
                    cmd.Parameters.AddWithValue("@iso3166a1", obj.iso3166a1);
                    cmd.Parameters.AddWithValue("@iso3166a2", obj.iso3166a2);
                    cmd.Parameters.AddWithValue("@nombre", obj.nombre);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(paises obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  paises ");
                sql.AppendLine("WHERE");
                sql.AppendLine("id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", obj.id);
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

