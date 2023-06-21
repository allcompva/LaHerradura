using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class MEDIOS_PAGO : DALBase
    {
        public int ID { get; set; }
        public string DESCRIPCION { get; set; }
        public bool CARGA_MANUAL { get; set; }
        public decimal MONTO { get; set; }
        public int ID_PLAN_CUENTA { get; set; }

        public MEDIOS_PAGO()
        {
            ID = 0;
            DESCRIPCION = string.Empty;
            CARGA_MANUAL = false;
            MONTO = 0;
            ID_PLAN_CUENTA = 0;
        }

        private static List<MEDIOS_PAGO> mapeo(SqlDataReader dr)
        {
            List<MEDIOS_PAGO> lst = new List<MEDIOS_PAGO>();
            MEDIOS_PAGO obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new MEDIOS_PAGO();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.DESCRIPCION = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.CARGA_MANUAL = dr.GetBoolean(2); }
                    if (!dr.IsDBNull(3)) { obj.ID_PLAN_CUENTA = dr.GetInt32(3); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<MEDIOS_PAGO> read()
        {
            try
            {
                List<MEDIOS_PAGO> lst = new List<MEDIOS_PAGO>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM MEDIOS_PAGO";
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
        public static List<MEDIOS_PAGO> readManual()
        {
            try
            {
                List<MEDIOS_PAGO> lst = new List<MEDIOS_PAGO>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM MEDIOS_PAGO WHERE CARGA_MANUAL = 1";
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
        public static MEDIOS_PAGO getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM MEDIOS_PAGO WHERE");
                sql.AppendLine("ID = @ID");
                MEDIOS_PAGO obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<MEDIOS_PAGO> lst = mapeo(dr);
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

        public static int insert(MEDIOS_PAGO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO MEDIOS_PAGO(");
                sql.AppendLine("DESCRIPCION");
                sql.AppendLine(", CARGA_MANUAL");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@DESCRIPCION");
                sql.AppendLine(", @CARGA_MANUAL");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@CARGA_MANUAL", obj.CARGA_MANUAL);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(MEDIOS_PAGO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  MEDIOS_PAGO SET");
                sql.AppendLine("DESCRIPCION=@DESCRIPCION");
                sql.AppendLine(", CARGA_MANUAL=@CARGA_MANUAL");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@CARGA_MANUAL", obj.CARGA_MANUAL);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(MEDIOS_PAGO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  MEDIOS_PAGO ");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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

    }
}

