using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class FACTURAS_X_OP : DALBase
    {
        public int ID_OP { get; set; }
        public int ID_FACTURA { get; set; }

        public FACTURAS_X_OP()
        {
            ID_OP = 0;
            ID_FACTURA = 0;
        }

        private static List<FACTURAS_X_OP> mapeo(SqlDataReader dr)
        {
            List<FACTURAS_X_OP> lst = new List<FACTURAS_X_OP>();
            FACTURAS_X_OP obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new FACTURAS_X_OP();
                    if (!dr.IsDBNull(0)) { obj.ID_OP = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.ID_FACTURA = dr.GetInt32(1); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<FACTURAS_X_OP> read()
        {
            try
            {
                List<FACTURAS_X_OP> lst = new List<FACTURAS_X_OP>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM FACTURAS_X_OP";
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
        public static FACTURAS_X_OP getByFactura(int idFactura)
        {
            try
            {
                FACTURAS_X_OP obj = null;
                List<FACTURAS_X_OP> lst = new List<FACTURAS_X_OP>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM FACTURAS_X_OP WHERE ID_FACTURA=@ID_FACTURA";
                    cmd.Parameters.AddWithValue("@ID_FACTURA", idFactura);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<FACTURAS_X_OP> getByOrdenPago(int idOp)
        {
            try
            {
                FACTURAS_X_OP obj = null;
                List<FACTURAS_X_OP> lst = new List<FACTURAS_X_OP>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM FACTURAS_X_OP WHERE ID_OP=@ID_OP";
                    cmd.Parameters.AddWithValue("@ID_OP", idOp);
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
        public static FACTURAS_X_OP getByPk(
        int ID_OP, int ID_FACTURA)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM FACTURAS_X_OP WHERE");
                sql.AppendLine("ID_OP = @ID_OP");
                sql.AppendLine("AND ID_FACTURA = @ID_FACTURA");
                FACTURAS_X_OP obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_OP", ID_OP);
                    cmd.Parameters.AddWithValue("@ID_FACTURA", ID_FACTURA);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<FACTURAS_X_OP> lst = mapeo(dr);
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

        public static void insert(FACTURAS_X_OP obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO FACTURAS_X_OP(");
                sql.AppendLine("ID_OP");
                sql.AppendLine(", ID_FACTURA");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID_OP");
                sql.AppendLine(", @ID_FACTURA");
                sql.AppendLine(")");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_OP", obj.ID_OP);
                    cmd.Parameters.AddWithValue("@ID_FACTURA", obj.ID_FACTURA);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(FACTURAS_X_OP obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  FACTURAS_X_OP SET");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID_OP=@ID_OP");
                sql.AppendLine("AND ID_FACTURA=@ID_FACTURA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_OP", obj.ID_OP);
                    cmd.Parameters.AddWithValue("@ID_FACTURA", obj.ID_FACTURA);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(FACTURAS_X_OP obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  FACTURAS_X_OP ");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID_OP=@ID_OP");
                sql.AppendLine("AND ID_FACTURA=@ID_FACTURA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_OP", obj.ID_OP);
                    cmd.Parameters.AddWithValue("@ID_FACTURA", obj.ID_FACTURA);
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

