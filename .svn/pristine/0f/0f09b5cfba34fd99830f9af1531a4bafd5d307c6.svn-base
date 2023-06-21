using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class CUENTAS_X_PROVEEDOR : DALBase
    {
        public int ID_PROV { get; set; }
        public int ID_CTA_CONTABLE_PASIVO { get; set; }
        public int ID_CTA_CONTABLE_GASTO { get; set; }

        public string CUENTA_PASIVO { get; set; }
        public string CUENTA_GASTO { get; set; }
        public CUENTAS_X_PROVEEDOR()
        {
            ID_PROV = 0;
            ID_CTA_CONTABLE_PASIVO = 0;
            ID_CTA_CONTABLE_GASTO = 0;
            CUENTA_PASIVO = string.Empty;
            CUENTA_GASTO = string.Empty;
        }

        private static List<CUENTAS_X_PROVEEDOR> mapeo(SqlDataReader dr)
        {
            List<CUENTAS_X_PROVEEDOR> lst = new List<CUENTAS_X_PROVEEDOR>();
            CUENTAS_X_PROVEEDOR obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new CUENTAS_X_PROVEEDOR();
                    if (!dr.IsDBNull(0)) { obj.ID_PROV = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.ID_CTA_CONTABLE_PASIVO = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.ID_CTA_CONTABLE_GASTO = dr.GetInt32(2); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<CUENTAS_X_PROVEEDOR> read()
        {
            try
            {
                List<CUENTAS_X_PROVEEDOR> lst = new List<CUENTAS_X_PROVEEDOR>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM CUENTAS_X_PROVEEDOR";
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
        public static List<CUENTAS_X_PROVEEDOR> read(int idProv)
        {
            try
            {
                List<CUENTAS_X_PROVEEDOR> lst = new List<CUENTAS_X_PROVEEDOR>();
                CUENTAS_X_PROVEEDOR obj;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.DESC_SUBCUENTA CTA_PASIVO, C.DESC_SUBCUENTA CTA_GASTO");
                sql.AppendLine("FROM CUENTAS_X_PROVEEDOR A");
                sql.AppendLine("INNER JOIN PLAN_CUENTA B ON A.ID_CTA_CONTABLE_PASIVO=B.ID");
                sql.AppendLine("INNER JOIN PLAN_CUENTA C ON A.ID_CTA_CONTABLE_GASTO=C.ID");
                sql.AppendLine("WHERE A.ID_PROV=@ID_PROV");
                sql.AppendLine(" ORDER BY B.DESC_SUBCUENTA ASC");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROV", idProv);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new CUENTAS_X_PROVEEDOR();
                            if (!dr.IsDBNull(0)) { obj.ID_PROV = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.ID_CTA_CONTABLE_PASIVO = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.ID_CTA_CONTABLE_GASTO = dr.GetInt32(2); }
                            if (!dr.IsDBNull(3)) { obj.CUENTA_PASIVO = dr.GetString(3); }
                            if (!dr.IsDBNull(4)) { obj.CUENTA_GASTO = dr.GetString(4); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CUENTAS_X_PROVEEDOR getByPk(
        int ID_PROV, int ID_CTA_CONTABLE_PASIVO, int ID_CTA_CONTABLE_GASTO)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CUENTAS_X_PROVEEDOR WHERE");
                sql.AppendLine("ID_PROV = @ID_PROV");
                sql.AppendLine("AND ID_CTA_CONTABLE_PASIVO = @ID_CTA_CONTABLE_PASIVO");
                sql.AppendLine("AND ID_CTA_CONTABLE_GASTO = @ID_CTA_CONTABLE_GASTO");
                CUENTAS_X_PROVEEDOR obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROV", ID_PROV);
                    cmd.Parameters.AddWithValue("@ID_CTA_CONTABLE_PASIVO", ID_CTA_CONTABLE_PASIVO);
                    cmd.Parameters.AddWithValue("@ID_CTA_CONTABLE_GASTO", ID_CTA_CONTABLE_GASTO);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CUENTAS_X_PROVEEDOR> lst = mapeo(dr);
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

        public static void insert(CUENTAS_X_PROVEEDOR obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO CUENTAS_X_PROVEEDOR(");
                sql.AppendLine("ID_PROV");
                sql.AppendLine(", ID_CTA_CONTABLE_PASIVO");
                sql.AppendLine(", ID_CTA_CONTABLE_GASTO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID_PROV");
                sql.AppendLine(", @ID_CTA_CONTABLE_PASIVO");
                sql.AppendLine(", @ID_CTA_CONTABLE_GASTO");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROV", obj.ID_PROV);
                    cmd.Parameters.AddWithValue("@ID_CTA_CONTABLE_PASIVO", obj.ID_CTA_CONTABLE_PASIVO);
                    cmd.Parameters.AddWithValue("@ID_CTA_CONTABLE_GASTO", obj.ID_CTA_CONTABLE_GASTO);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(CUENTAS_X_PROVEEDOR obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  CUENTAS_X_PROVEEDOR SET");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID_PROV=@ID_PROV");
                sql.AppendLine("AND ID_CTA_CONTABLE_PASIVO=@ID_CTA_CONTABLE_PASIVO");
                sql.AppendLine("AND ID_CTA_CONTABLE_GASTO=@ID_CTA_CONTABLE_GASTO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROV", obj.ID_PROV);
                    cmd.Parameters.AddWithValue("@ID_CTA_CONTABLE_PASIVO", obj.ID_CTA_CONTABLE_PASIVO);
                    cmd.Parameters.AddWithValue("@ID_CTA_CONTABLE_GASTO", obj.ID_CTA_CONTABLE_GASTO);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int idProv, int ctaPasivo, int ctaGasto)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  CUENTAS_X_PROVEEDOR ");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID_PROV=@ID_PROV");
                sql.AppendLine("AND ID_CTA_CONTABLE_PASIVO=@ID_CTA_CONTABLE_PASIVO");
                sql.AppendLine("AND ID_CTA_CONTABLE_GASTO=@ID_CTA_CONTABLE_GASTO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROV", idProv);
                    cmd.Parameters.AddWithValue("@ID_CTA_CONTABLE_PASIVO", ctaPasivo);
                    cmd.Parameters.AddWithValue("@ID_CTA_CONTABLE_GASTO", ctaGasto);
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

