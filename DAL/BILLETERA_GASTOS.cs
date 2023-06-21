using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class BILLETERA_GASTOS : DALBase
    {
        public int ID_PROVEEDOR { get; set; }
        public decimal SALDO { get; set; }

        public BILLETERA_GASTOS()
        {
            ID_PROVEEDOR = 0;
            SALDO = 0;
        }

        private static List<BILLETERA_GASTOS> mapeo(SqlDataReader dr)
        {
            List<BILLETERA_GASTOS> lst = new List<BILLETERA_GASTOS>();
            BILLETERA_GASTOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new BILLETERA_GASTOS();
                    if (!dr.IsDBNull(0)) { obj.ID_PROVEEDOR = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.SALDO = dr.GetDecimal(1); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<BILLETERA_GASTOS> read()
        {
            try
            {
                List<BILLETERA_GASTOS> lst = new List<BILLETERA_GASTOS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM BILLETERA_GASTOS";
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

        public static BILLETERA_GASTOS getByPk(
        int ID_PROVEEDOR)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM BILLETERA_GASTOS WHERE");
                sql.AppendLine("ID_PROVEEDOR = @ID_PROVEEDOR");
                BILLETERA_GASTOS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", ID_PROVEEDOR);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<BILLETERA_GASTOS> lst = mapeo(dr);
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

        public static int insert(BILLETERA_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO BILLETERA_GASTOS(");
                sql.AppendLine("ID_PROVEEDOR");
                sql.AppendLine(", SALDO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID_PROVEEDOR");
                sql.AppendLine(", @SALDO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", obj.ID_PROVEEDOR);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(BILLETERA_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  BILLETERA_GASTOS SET");
                sql.AppendLine("SALDO=@SALDO");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID_PROVEEDOR=@ID_PROVEEDOR");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", obj.ID_PROVEEDOR);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setSaldo(int idProv, decimal monto)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE BILLETERA_GASTOS SET");
                sql.AppendLine("SALDO=SALDO + @MONTO");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID_PROVEEDOR=@ID_PROVEEDOR");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProv);
                    cmd.Parameters.AddWithValue("@MONTO", monto);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(BILLETERA_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  BILLETERA_GASTOS ");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID_PROVEEDOR=@ID_PROVEEDOR");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", obj.ID_PROVEEDOR);
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

