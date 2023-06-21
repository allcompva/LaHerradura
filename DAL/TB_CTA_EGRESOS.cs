using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TB_CTA_EGRESOS:DALBase
    {
        public int ID { get; set; }
        public string DESCRIPCION { get; set; }
        public int TIPO_CUENTA { get; set; }
        public int TIPO_MOVIMIENTO { get; set; }

        public TB_CTA_EGRESOS()
        {
            ID = 0;
            DESCRIPCION = string.Empty;
            TIPO_CUENTA = 0;
            TIPO_MOVIMIENTO = 0;
        }
        public static void insert(TB_CTA_EGRESOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TB_CTA_EGRESOS");
                sql.AppendLine("(DESCRIPCION,TIPO_CUENTA,TIPO_MOVIMIENTO)");
                sql.AppendLine("VALUES");
                sql.AppendLine("(@DESCRIPCION,@TIPO_CUENTA,@TIPO_MOVIMIENTO)");


                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@TIPO_CUENTA", obj.TIPO_CUENTA);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", obj.TIPO_MOVIMIENTO);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void update(TB_CTA_EGRESOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE TB_CTA_EGRESOS");
                sql.AppendLine("SET DESCRIPCION=@DESCRIPCION,TIPO_CUENTA=@TIPO_CUENTA,TIPO_MOVIMIENTO=@TIPO_MOVIMIENTO");
                sql.AppendLine("WHERE ID=@ID");

                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@TIPO_CUENTA", obj.TIPO_CUENTA);
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", obj.TIPO_MOVIMIENTO);
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
                sql.AppendLine("UPDATE TB_CTA_EGRESOS");
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
        public static List<TB_CTA_EGRESOS> read(int idCta, int TIPO_MOV)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM TB_CTA_EGRESOS WHERE TIPO_CUENTA=@TIPO_CUENTA");
                sql.AppendLine("AND TIPO_MOVIMIENTO = @TIPO_MOVIMIENTO");
                TB_CTA_EGRESOS obj = null;
                List<TB_CTA_EGRESOS> lst = new List<TB_CTA_EGRESOS>();
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@TIPO_CUENTA", idCta);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", TIPO_MOV);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int DESCRIPCION = dr.GetOrdinal("DESCRIPCION");
                        int TIPO_CUENTA = dr.GetOrdinal("TIPO_CUENTA");
                        int TIPO_MOVIMIENTO = dr.GetOrdinal("TIPO_MOVIMIENTO");
                        while (dr.Read())
                        {
                            obj = new TB_CTA_EGRESOS();
                            if (!dr.IsDBNull(ID)) obj.ID = dr.GetInt32(ID);
                            if (!dr.IsDBNull(DESCRIPCION)) obj.DESCRIPCION = dr.GetString(DESCRIPCION);
                            if (!dr.IsDBNull(TIPO_CUENTA)) obj.TIPO_CUENTA = dr.GetInt32(TIPO_CUENTA);
                            if (!dr.IsDBNull(TIPO_MOVIMIENTO)) obj.TIPO_MOVIMIENTO = dr.GetInt32(TIPO_MOVIMIENTO);
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
        public static TB_CTA_EGRESOS getByPk(int pk)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM TB_CTA_EGRESOS WHERE ID=@ID");
                TB_CTA_EGRESOS obj = null;
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", pk);
                    cmd.CommandText = sql.ToString();

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int DESCRIPCION = dr.GetOrdinal("DESCRIPCION");
                        int TIPO_CUENTA = dr.GetOrdinal("TIPO_CUENTA");
                        int TIPO_MOVIMIENTO = dr.GetOrdinal("TIPO_MOVIMIENTO");
                        while (dr.Read())
                        {
                            obj = new TB_CTA_EGRESOS();
                            if (!dr.IsDBNull(ID)) obj.ID = dr.GetInt32(ID);
                            if (!dr.IsDBNull(DESCRIPCION)) obj.DESCRIPCION = dr.GetString(DESCRIPCION);
                            if (!dr.IsDBNull(TIPO_CUENTA)) obj.TIPO_CUENTA = dr.GetInt32(TIPO_CUENTA);
                            if (!dr.IsDBNull(TIPO_MOVIMIENTO)) obj.TIPO_MOVIMIENTO = dr.GetInt32(TIPO_MOVIMIENTO);
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
