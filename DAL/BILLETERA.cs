using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class BILLETERA : DALBase
    {
        public int NRO_CTA { get; set; }
        public int ID_PERSONA { get; set; }
        public decimal SALDO { get; set; }

        public BILLETERA()
        {
            NRO_CTA = 0;
            ID_PERSONA = 0;
            SALDO = 0;
        }

        private static List<BILLETERA> mapeo(SqlDataReader dr)
        {
            List<BILLETERA> lst = new List<BILLETERA>();
            BILLETERA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new BILLETERA();
                    if (!dr.IsDBNull(0)) { obj.NRO_CTA = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.ID_PERSONA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.SALDO = dr.GetDecimal(2); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<BILLETERA> read()
        {
            try
            {
                List<BILLETERA> lst = new List<BILLETERA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM BILLETERA";
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

        public static BILLETERA getByPk(int NRO_CTA)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM BILLETERA WHERE");
                sql.AppendLine("NRO_CTA = @NRO_CTA");
                BILLETERA obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", NRO_CTA);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<BILLETERA> lst = mapeo(dr);
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

        public static BILLETERA getByPk(
        int NRO_CTA, int ID_PERSONA)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM BILLETERA WHERE");
                sql.AppendLine("NRO_CTA = @NRO_CTA AND ID_PERSONA=@ID_PERSONA");
                BILLETERA obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", NRO_CTA);
                    cmd.Parameters.AddWithValue("@ID_PERSONA", ID_PERSONA);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<BILLETERA> lst = mapeo(dr);
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

        public static int insert(BILLETERA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO BILLETERA(");
                sql.AppendLine("NRO_CTA");
                sql.AppendLine(", SALDO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@NRO_CTA");
                sql.AppendLine(", @SALDO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
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

        public static void update(BILLETERA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE BILLETERA SET");
                sql.AppendLine("SALDO=@SALDO");
                sql.AppendLine("WHERE");
                sql.AppendLine("NRO_CTA=@NRO_CTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
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
        public static void setSaldo(int nroCta, decimal monto)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE BILLETERA SET");
                sql.AppendLine("SALDO=SALDO + @MONTO");
                sql.AppendLine("WHERE");
                sql.AppendLine("NRO_CTA=@NRO_CTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
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
        public static void delete(BILLETERA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  BILLETERA ");
                sql.AppendLine("WHERE");
                sql.AppendLine("NRO_CTA=@NRO_CTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
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

