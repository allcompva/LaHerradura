using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class ASIENTOS_DETALLE : DALBase
    {
        public int ID_ASIENTO { get; set; }
        public int ID_CUENTA { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal DEBE { get; set; }
        public decimal HABER { get; set; }
        public string NOMBRE_CUENTA { get; set; }
        public string N5 { get; set; }
        public string ID_REFERENCIA { get; set; }

        public ASIENTOS_DETALLE()
        {
            ID_ASIENTO = 0;
            ID_CUENTA = 0;
            DESCRIPCION = string.Empty;
            DEBE = 0;
            HABER = 0;
            NOMBRE_CUENTA = string.Empty;
            ID_REFERENCIA = string.Empty;
        }

        private static List<ASIENTOS_DETALLE> mapeo(SqlDataReader dr)
        {
            List<ASIENTOS_DETALLE> lst = new List<ASIENTOS_DETALLE>();
            ASIENTOS_DETALLE obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new ASIENTOS_DETALLE();
                    if (!dr.IsDBNull(0)) { obj.ID_ASIENTO = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.ID_CUENTA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.DESCRIPCION = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.DEBE = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.HABER = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.ID_REFERENCIA = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.NOMBRE_CUENTA = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.N5 = dr.GetString(7); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<ASIENTOS_DETALLE> read(int idAsiento)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.DESC_SUBCUENTA, B.N5, FROM ASIENTOS_DETALLE A");
                sql.AppendLine("INNER JOIN PLAN_CUENTA B ON A.ID_CUENTA=B.ID");
                sql.AppendLine("WHERE A.ID_ASIENTO=@ID");

                List<ASIENTOS_DETALLE> lst = new List<ASIENTOS_DETALLE>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", idAsiento);
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
        public static List<ASIENTOS_DETALLE> read()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.DESC_SUBCUENTA, B.N5, FROM ASIENTOS_DETALLE A");
                sql.AppendLine("INNER JOIN PLAN_CUENTA B ON A.ID_CUENTA=B.ID");


                List<ASIENTOS_DETALLE> lst = new List<ASIENTOS_DETALLE>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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

        public static ASIENTOS_DETALLE getByPk(
        int ID_ASIENTO, int ID_CUENTA)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.DESC_SUBCUENTA, B.N5, FROM ASIENTOS_DETALLE A");
                sql.AppendLine("INNER JOIN PLAN_CUENTA B ON A.ID_CUENTA=B.ID");
                sql.AppendLine("WHERE ID_ASIENTO = @ID_ASIENTO");
                sql.AppendLine("AND ID_CUENTA = @ID_CUENTA");
                ASIENTOS_DETALLE obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_ASIENTO", ID_ASIENTO);
                    cmd.Parameters.AddWithValue("@ID_CUENTA", ID_CUENTA);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ASIENTOS_DETALLE> lst = mapeo(dr);
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

        public static void insert(ASIENTOS_DETALLE obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO ASIENTOS_DETALLE(");
                sql.AppendLine("ID_ASIENTO");
                sql.AppendLine(", ID_CUENTA");
                sql.AppendLine(", DESCRIPCION");
                sql.AppendLine(", DEBE");
                sql.AppendLine(", HABER");
                sql.AppendLine(", ID_REFERENCIA");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID_ASIENTO");
                sql.AppendLine(", @ID_CUENTA");
                sql.AppendLine(", @DESCRIPCION");
                sql.AppendLine(", @DEBE");
                sql.AppendLine(", @HABER");
                sql.AppendLine(", @ID_REFERENCIA");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_ASIENTO", obj.ID_ASIENTO);
                    cmd.Parameters.AddWithValue("@ID_CUENTA", obj.ID_CUENTA);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@DEBE", obj.DEBE);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@ID_REFERENCIA", obj.ID_REFERENCIA);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(ASIENTOS_DETALLE obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  ASIENTOS_DETALLE SET");
                sql.AppendLine("DESCRIPCION=@DESCRIPCION");
                sql.AppendLine(", DEBE=@DEBE");
                sql.AppendLine(", HABER=@HABER");
                sql.AppendLine(", ID_REFERENCIA=@ID_REFERENCIA");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID_ASIENTO=@ID_ASIENTO");
                sql.AppendLine("AND ID_CUENTA=@ID_CUENTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_ASIENTO", obj.ID_ASIENTO);
                    cmd.Parameters.AddWithValue("@ID_CUENTA", obj.ID_CUENTA);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@DEBE", obj.DEBE);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@ID_REFERENCIA", obj.ID_REFERENCIA);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int idAsiento)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  ASIENTOS_DETALLE ");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID_ASIENTO=@ID_ASIENTO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_ASIENTO", idAsiento);
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

