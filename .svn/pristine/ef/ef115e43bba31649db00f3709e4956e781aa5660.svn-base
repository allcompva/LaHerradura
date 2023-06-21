using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class SERVICIOS : DALBase
    {
        public int ID { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal COSTO { get; set; }
        public int CANT_PERSONAS { get; set; }
        public decimal ADICIONAL { get; set; }
        public string LNK { get; set; }

        public SERVICIOS()
        {
            ID = 0;
            DESCRIPCION = string.Empty;
            COSTO = 0;
            CANT_PERSONAS = 0;
            ADICIONAL = 0;
        }

        private static List<SERVICIOS> mapeo(SqlDataReader dr)
        {
            List<SERVICIOS> lst = new List<SERVICIOS>();
            SERVICIOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new SERVICIOS();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.DESCRIPCION = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.COSTO = dr.GetDecimal(2); }
                    if (!dr.IsDBNull(3)) { obj.CANT_PERSONAS = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.ADICIONAL = dr.GetDecimal(4); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<SERVICIOS> read()
        {
            try
            {
                List<SERVICIOS> lst = new List<SERVICIOS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM SERVICIOS";
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

        public static SERVICIOS getByPk(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM SERVICIOS WHERE ID=@ID");
                SERVICIOS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("ID", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<SERVICIOS> lst = mapeo(dr);
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

        public static int insert(SERVICIOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO SERVICIOS (");
                sql.AppendLine("DESCRIPCION");
                sql.AppendLine(", COSTO");
                sql.AppendLine(", CANT_PERSONAS");
                sql.AppendLine(", ADICIONAL");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@DESCRIPCION");
                sql.AppendLine(", @COSTO");
                sql.AppendLine(", @CANT_PERSONAS");
                sql.AppendLine(", @ADICIONAL");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@COSTO", obj.COSTO);
                    cmd.Parameters.AddWithValue("@CANT_PERSONAS", obj.CANT_PERSONAS);
                    cmd.Parameters.AddWithValue("@ADICIONAL", obj.ADICIONAL);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(SERVICIOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  SERVICIOS SET");
                sql.AppendLine("DESCRIPCION=@DESCRIPCION");
                sql.AppendLine(", COSTO=@COSTO");
                sql.AppendLine(", CANT_PERSONAS=@CANT_PERSONAS");
                sql.AppendLine(", ADICIONAL=@ADICIONAL");
                sql.AppendLine("WHERE ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@COSTO", obj.COSTO);
                    cmd.Parameters.AddWithValue("@CANT_PERSONAS", obj.CANT_PERSONAS);
                    cmd.Parameters.AddWithValue("@ADICIONAL", obj.ADICIONAL);
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
                sql.AppendLine("DELETE  SERVICIOS ");
                sql.AppendLine("WHERE id=@id");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", id);
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

