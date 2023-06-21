using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class INF_DEUDA_PERIODO : DALBase
    {
        public int ID { get; set; }
        public int NRO_CTA { get; set; }
        public string PROPIETARIO { get; set; }
        public decimal SALDO { get; set; }

        public INF_DEUDA_PERIODO()
        {
            ID = 0;
            NRO_CTA = 0;
            PROPIETARIO = string.Empty;
            SALDO = 0;
        }

        private static List<INF_DEUDA_PERIODO> mapeo(SqlDataReader dr)
        {
            List<INF_DEUDA_PERIODO> lst = new List<INF_DEUDA_PERIODO>();
            INF_DEUDA_PERIODO obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new INF_DEUDA_PERIODO();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.PROPIETARIO = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.SALDO = dr.GetDecimal(3); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<INF_DEUDA_PERIODO> read(int periodo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID, A.NRO_CTA, C.APELLIDO + ', ' + C.NOMBRE");
                sql.AppendLine("AS PROPIETARIO, SALDO ");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON B.NRO_CTA=A.NRO_CTA");
                sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA=C.ID");
                sql.AppendLine("WHERE TIPO_MOVIMIENTO=1 AND PERIODO=@PERIODO");
                sql.AppendLine("AND PAGADO=0");
                List<INF_DEUDA_PERIODO> lst = new List<INF_DEUDA_PERIODO>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
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

        public static INF_DEUDA_PERIODO getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM INF_DEUDA_PERIODO WHERE");
                INF_DEUDA_PERIODO obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<INF_DEUDA_PERIODO> lst = mapeo(dr);
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

        public static int insert(INF_DEUDA_PERIODO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO INF_DEUDA_PERIODO(");
                sql.AppendLine("ID");
                sql.AppendLine(", NRO_CTA");
                sql.AppendLine(", PROPIETARIO");
                sql.AppendLine(", SALDO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID");
                sql.AppendLine(", @NRO_CTA");
                sql.AppendLine(", @PROPIETARIO");
                sql.AppendLine(", @SALDO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@PROPIETARIO", obj.PROPIETARIO);
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

        public static void update(INF_DEUDA_PERIODO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  INF_DEUDA_PERIODO SET");
                sql.AppendLine("ID=@ID");
                sql.AppendLine(", NRO_CTA=@NRO_CTA");
                sql.AppendLine(", PROPIETARIO=@PROPIETARIO");
                sql.AppendLine(", SALDO=@SALDO");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@PROPIETARIO", obj.PROPIETARIO);
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

        public static void delete(INF_DEUDA_PERIODO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  INF_DEUDA_PERIODO ");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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

