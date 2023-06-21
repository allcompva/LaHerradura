using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class TELEFONO_PERSONA : DALBase
    {
        public int ID { get; set; }
        public int ID_PERSONA { get; set; }
        public string COD_PAIS { get; set; }
        public string COD_AREA { get; set; }
        public string NUMERO { get; set; }
        public string REFERENCIA { get; set; }

        public TELEFONO_PERSONA()
        {
            ID = 0;
            ID_PERSONA = 0;
            COD_PAIS = string.Empty;
            COD_AREA = string.Empty;
            NUMERO = string.Empty;
            REFERENCIA = string.Empty;
        }

        private static List<TELEFONO_PERSONA> mapeo(SqlDataReader dr)
        {
            List<TELEFONO_PERSONA> lst = new List<TELEFONO_PERSONA>();
            TELEFONO_PERSONA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new TELEFONO_PERSONA();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.ID_PERSONA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.COD_PAIS = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.COD_AREA = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.NUMERO = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.REFERENCIA = dr.GetString(5); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<TELEFONO_PERSONA> read(int idPersona)
        {
            try
            {
                List<TELEFONO_PERSONA> lst = new List<TELEFONO_PERSONA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM TELEFONO_PERSONA WHERE ID_PERSONA=@ID_PERSONA";
                    cmd.Parameters.AddWithValue("@ID_PERSONA", idPersona);
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

        public static TELEFONO_PERSONA getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM TELEFONO_PERSONA WHERE");
                sql.AppendLine("ID = @ID");
                TELEFONO_PERSONA obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<TELEFONO_PERSONA> lst = mapeo(dr);
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

        public static int insert(TELEFONO_PERSONA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TELEFONO_PERSONA(");
                sql.AppendLine("ID_PERSONA");
                sql.AppendLine(", COD_PAIS");
                sql.AppendLine(", COD_AREA");
                sql.AppendLine(", NUMERO");
                sql.AppendLine(", REFERENCIA");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID_PERSONA");
                sql.AppendLine(", @COD_PAIS");
                sql.AppendLine(", @COD_AREA");
                sql.AppendLine(", @NUMERO");
                sql.AppendLine(", @REFERENCIA");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PERSONA", obj.ID_PERSONA);
                    cmd.Parameters.AddWithValue("@COD_PAIS", obj.COD_PAIS);
                    cmd.Parameters.AddWithValue("@COD_AREA", obj.COD_AREA);
                    cmd.Parameters.AddWithValue("@NUMERO", obj.NUMERO);
                    cmd.Parameters.AddWithValue("@REFERENCIA", obj.REFERENCIA);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(TELEFONO_PERSONA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  TELEFONO_PERSONA SET");
                sql.AppendLine("ID_PERSONA=@ID_PERSONA");
                sql.AppendLine(", COD_PAIS=@COD_PAIS");
                sql.AppendLine(", COD_AREA=@COD_AREA");
                sql.AppendLine(", NUMERO=@NUMERO");
                sql.AppendLine(", REFERENCIA=@REFERENCIA");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@ID_PERSONA", obj.ID_PERSONA);
                    cmd.Parameters.AddWithValue("@COD_PAIS", obj.COD_PAIS);
                    cmd.Parameters.AddWithValue("@COD_AREA", obj.COD_AREA);
                    cmd.Parameters.AddWithValue("@NUMERO", obj.NUMERO);
                    cmd.Parameters.AddWithValue("@REFERENCIA", obj.REFERENCIA);
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
                sql.AppendLine("DELETE  TELEFONO_PERSONA ");
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

