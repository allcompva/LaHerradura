using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class CONCEPTOS_EXPENSA : DALBase
    {
        public int ID { get; set; }
        public string DESCRIPCION { get; set; }
        public bool SUMA { get; set; }
        public decimal MONTO { get; set; }
        public decimal PORCENTAJE { get; set; }
        public bool ACTIVOS { get; set; }
        public int TIPO { get; set; }

        public CONCEPTOS_EXPENSA()
        {
            ID = 0;
            DESCRIPCION = string.Empty;
            SUMA = false;
            MONTO = 0;
            PORCENTAJE = 0;
            ACTIVOS = false;
            TIPO = 0;
        }

        private static List<CONCEPTOS_EXPENSA> mapeo(SqlDataReader dr)
        {
            List<CONCEPTOS_EXPENSA> lst = new List<CONCEPTOS_EXPENSA>();
            CONCEPTOS_EXPENSA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new CONCEPTOS_EXPENSA();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.DESCRIPCION = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.SUMA = dr.GetBoolean(2); }
                    if (!dr.IsDBNull(3)) { obj.MONTO = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.PORCENTAJE = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.ACTIVOS = dr.GetBoolean(5); }
                    if (!dr.IsDBNull(6)) { obj.TIPO = dr.GetInt32(6); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<CONCEPTOS_EXPENSA> read()
        {
            try
            {
                List<CONCEPTOS_EXPENSA> lst = new List<CONCEPTOS_EXPENSA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM CONCEPTOS_EXPENSA WHERE ID NOT IN (1,15)";
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

        public static List<CONCEPTOS_EXPENSA> readActivos(int tipo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CONCEPTOS_EXPENSA WHERE ID NOT IN (1,15)");
                sql.AppendLine("AND ACTIVOS = 1 AND TIPO=@TIPO");

                List<CONCEPTOS_EXPENSA> lst = new List<CONCEPTOS_EXPENSA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@TIPO", tipo);
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

        public static CONCEPTOS_EXPENSA getByPk(int pk)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CONCEPTOS_EXPENSA WHERE ID=@ID");
                CONCEPTOS_EXPENSA obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", pk);
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CONCEPTOS_EXPENSA> lst = mapeo(dr);
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

        public static int insert(CONCEPTOS_EXPENSA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO CONCEPTOS_EXPENSA(");
                sql.AppendLine("DESCRIPCION");
                sql.AppendLine(", SUMA");
                sql.AppendLine(", MONTO");
                sql.AppendLine(", PORCENTAJE");
                sql.AppendLine(", ACTIVOS");
                sql.AppendLine(", TIPO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@DESCRIPCION");
                sql.AppendLine(", @SUMA");
                sql.AppendLine(", @MONTO");
                sql.AppendLine(", @PORCENTAJE");
                sql.AppendLine(", @ACTIVOS");
                sql.AppendLine(", @TIPO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@SUMA", obj.SUMA);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Parameters.AddWithValue("@PORCENTAJE", obj.PORCENTAJE);
                    cmd.Parameters.AddWithValue("@ACTIVOS", obj.ACTIVOS);
                    cmd.Parameters.AddWithValue("@TIPO", obj.TIPO);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(CONCEPTOS_EXPENSA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  CONCEPTOS_EXPENSA SET");
                sql.AppendLine("DESCRIPCION=@DESCRIPCION");
                sql.AppendLine(", SUMA=@SUMA");
                sql.AppendLine(", MONTO=@MONTO");
                sql.AppendLine(", PORCENTAJE=@PORCENTAJE");
                sql.AppendLine(", ACTIVOS=@ACTIVOS");
                sql.AppendLine(", TIPO=@TIPO");
                sql.AppendLine("WHERE ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@SUMA", obj.SUMA);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Parameters.AddWithValue("@PORCENTAJE", obj.PORCENTAJE);
                    cmd.Parameters.AddWithValue("@ACTIVOS", obj.ACTIVOS);
                    cmd.Parameters.AddWithValue("@TIPO", obj.TIPO);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void activaDesactiva(int id, bool activa)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  CONCEPTOS_EXPENSA SET");
                sql.AppendLine("ACTIVOS=@ACTIVOS");
                sql.AppendLine("WHERE ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@ACTIVOS", activa);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool verificaUso(int id_concepto)
        {
            try
            {
                bool control = false;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_CONCEPTO", id_concepto);
                    cmd.CommandText = @"SELECT ID_CONCEPTO FROM CONCEPTOS_X_LIQUIDACION
                                        WHERE ID_CONCEPTO=@ID_CONCEPTO
                                        UNION
                                        SELECT ID_CONCEPTO FROM CONCEPTOS_X_INMUEBLE
                                        WHERE ID_CONCEPTO=@ID_CONCEPTO";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        control = true;
                    }
                }
                return control;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool delete(int pk)
        {
            try
            {
                bool ret = true;
                if (!verificaUso(pk))
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("DELETE CONCEPTOS_EXPENSA ");
                    sql.AppendLine("WHERE ID=@ID");
                    using (SqlConnection con = GetConnection())
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@ID", pk);
                        cmd.CommandText = sql.ToString();
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                    ret = false;
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

