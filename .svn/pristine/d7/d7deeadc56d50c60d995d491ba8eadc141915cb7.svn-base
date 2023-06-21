using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TB_CTA_INGRESO:DALBase
    {
        public int ID { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal SALDO { get; set; }

        public TB_CTA_INGRESO()
        {
            ID = 0;
            DESCRIPCION = string.Empty;
            SALDO = 0;
        }
        public static void insert(TB_CTA_INGRESO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TB_CTA_INGRESO");
                sql.AppendLine("(DESCRIPCION,SALDO)");
                sql.AppendLine("VALUES");
                sql.AppendLine("(@DESCRIPCION,@SALDO)");


                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
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
        public static void update(TB_CTA_INGRESO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE TB_CTA_INGRESO");
                sql.AppendLine("SET DESCRIPCION=@DESCRIPCION,SALDO=@SALDO");
                sql.AppendLine("WHERE ID=@ID");

                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
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
        public static void delete(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE TB_CTA_INGRESO");
                sql.AppendLine("WHERE ID=@ID");

                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
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
        public static List<TB_CTA_INGRESO> read()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM TB_CTA_INGRESO");
                TB_CTA_INGRESO obj = null;
                List<TB_CTA_INGRESO> lst = new List<TB_CTA_INGRESO>();
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int DESCRIPCION = dr.GetOrdinal("DESCRIPCION");
                        int SALDO = dr.GetOrdinal("SALDO");
                        while (dr.Read())
                        {
                            obj = new TB_CTA_INGRESO();
                            if (!dr.IsDBNull(ID)) obj.ID = dr.GetInt32(ID);
                            if (!dr.IsDBNull(DESCRIPCION)) obj.DESCRIPCION = dr.GetString(DESCRIPCION);
                            if (!dr.IsDBNull(SALDO)) obj.SALDO = dr.GetDecimal(SALDO);
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
        public static TB_CTA_INGRESO getByPk(int pk)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM TB_CTA_INGRESO WHERE ID=@ID");
                TB_CTA_INGRESO obj = null;
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", pk);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int DESCRIPCION = dr.GetOrdinal("DESCRIPCION");
                        int SALDO = dr.GetOrdinal("SALDO");
                        while (dr.Read())
                        {
                            obj = new TB_CTA_INGRESO();
                            if (!dr.IsDBNull(ID)) obj.ID = dr.GetInt32(ID);
                            if (!dr.IsDBNull(DESCRIPCION)) obj.DESCRIPCION = dr.GetString(DESCRIPCION);
                            if (!dr.IsDBNull(SALDO)) obj.SALDO = dr.GetDecimal(SALDO);
                        }
                    }
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
