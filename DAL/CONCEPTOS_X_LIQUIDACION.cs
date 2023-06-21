using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class CONCEPTOS_X_LIQUIDACION : DALBase
    {
        public int PERIODO { get; set; }
        public int ID_CONCEPTO { get; set; }
        public int CANT { get; set; }
        public decimal MONTO { get; set; }
        public string OBS { get; set; }
        public int NRO_ORDEN { get; set; }
        public int USUARIO_CARGA { get; set; }
        public DateTime FECHA_CARGA { get; set; }
        public string DESC_CONCEPTO { get; set; }
        public decimal SUBTOTAL { get; set; }
        public int CANT_CTAS { get; set; }

        public CONCEPTOS_X_LIQUIDACION()
        {
            PERIODO = 0;
            ID_CONCEPTO = 0;
            CANT = 0;
            MONTO = 0;
            OBS = string.Empty;
            NRO_ORDEN = 0;
            USUARIO_CARGA = 0;
            FECHA_CARGA = UTILS.getFechaActual();
            DESC_CONCEPTO = string.Empty;
            SUBTOTAL = 0;
            CANT_CTAS = 0;
        }

        private static List<CONCEPTOS_X_LIQUIDACION> mapeo(SqlDataReader dr)
        {
            List<CONCEPTOS_X_LIQUIDACION> lst = new List<CONCEPTOS_X_LIQUIDACION>();
            CONCEPTOS_X_LIQUIDACION obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new CONCEPTOS_X_LIQUIDACION();
                    if (!dr.IsDBNull(0)) { obj.PERIODO = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.ID_CONCEPTO = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.CANT = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.MONTO = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.OBS = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.NRO_ORDEN = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.USUARIO_CARGA = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.FECHA_CARGA = dr.GetDateTime(7); }
                    if (!dr.IsDBNull(8)) { obj.DESC_CONCEPTO = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.CANT_CTAS = dr.GetInt32(9); }

                    obj.SUBTOTAL = obj.CANT * obj.MONTO;
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<CONCEPTOS_X_LIQUIDACION> read(int periodo)
        {
            try
            {
                StringBuilder SQL = new StringBuilder();
                SQL.AppendLine("SELECT A.*, B.DESCRIPCION,");
                SQL.AppendLine("CUENTAS_EXCLUIDAS = (SELECT COUNT(*)FROM EXCLUSION_CONCEPTO ");
                SQL.AppendLine("WHERE PERIODO = @PERIODO AND ID_CONCEPTO = A.ID_CONCEPTO)");
                SQL.AppendLine("FROM CONCEPTOS_X_LIQUIDACION A");
                SQL.AppendLine("INNER JOIN CONCEPTOS_EXPENSA B ON A.ID_CONCEPTO = B.ID");
                SQL.AppendLine("WHERE PERIODO=@PERIODO");

                List<CONCEPTOS_X_LIQUIDACION> lst = new List<CONCEPTOS_X_LIQUIDACION>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
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
        public static List<CONCEPTOS_X_LIQUIDACION> read(int periodo, int nro_cta)
        {
            try
            {
                StringBuilder SQL = new StringBuilder();
                SQL.AppendLine("SELECT A.*, B.DESCRIPCION, 0");
                SQL.AppendLine("FROM CONCEPTOS_X_LIQUIDACION A");
                SQL.AppendLine("INNER JOIN CONCEPTOS_EXPENSA B ON A.ID_CONCEPTO = B.ID");
                SQL.AppendLine("WHERE PERIODO=@PERIODO AND A.ID_CONCEPTO NOT IN");
                SQL.AppendLine("(SELECT ID_CONCEPTO FROM EXCLUSION_CONCEPTO WHERE NRO_CTA = @NRO_CTA)");
                SQL.AppendLine("ORDER BY A.NRO_ORDEN");

                List<CONCEPTOS_X_LIQUIDACION> lst = new List<CONCEPTOS_X_LIQUIDACION>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nro_cta);
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
        //public static CONCEPTOS_X_LIQUIDACION getByPk(int periodo, int idConcepto)
        //{
        //    try
        //    {
        //        StringBuilder sql = new StringBuilder();
        //        sql.AppendLine("SELECT *FROM CONCEPTOS_X_LIQUIDACION A");
        //        sql.AppendLine("INNER INNER JOIN CONCEPTOS_EXPENSA B ON A.ID_CONCEPTO = B.ID");
        //        sql.AppendLine("WHERE PERIODO=@PERIODO AND ID_CONCEPTO=@ID_CONCEPTO");

        //        CONCEPTOS_X_LIQUIDACION obj = null;
        //        using (SqlConnection con = GetConnection())
        //        {
        //            SqlCommand cmd = con.CreateCommand();
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = sql.ToString();
        //            cmd.Parameters.AddWithValue("@PERIODO", periodo);
        //            cmd.Parameters.AddWithValue("@ID_CONCEPTO", idConcepto);
        //            cmd.Connection.Open();
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            List<CONCEPTOS_X_LIQUIDACION> lst = mapeo(dr);
        //            if (lst.Count != 0)
        //                obj = lst[0];
        //        }
        //        return obj;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static void insert(CONCEPTOS_X_LIQUIDACION obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO CONCEPTOS_X_LIQUIDACION(");
                sql.AppendLine("PERIODO");
                sql.AppendLine(", ID_CONCEPTO");
                sql.AppendLine(", CANT");
                sql.AppendLine(", MONTO");
                sql.AppendLine(", OBS");
                sql.AppendLine(", NRO_ORDEN");
                sql.AppendLine(", USUARIO_CARGA");
                sql.AppendLine(", FECHA_CARGA");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@PERIODO");
                sql.AppendLine(", @ID_CONCEPTO");
                sql.AppendLine(", @CANT");
                sql.AppendLine(", @MONTO");
                sql.AppendLine(", @OBS");
                sql.AppendLine(", @NRO_ORDEN");
                sql.AppendLine(", @USUARIO_CARGA");
                sql.AppendLine(", @FECHA_CARGA");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", obj.PERIODO);
                    cmd.Parameters.AddWithValue("@ID_CONCEPTO", obj.ID_CONCEPTO);
                    cmd.Parameters.AddWithValue("@CANT", obj.CANT);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Parameters.AddWithValue("@OBS", obj.OBS);
                    cmd.Parameters.AddWithValue("@NRO_ORDEN", obj.NRO_ORDEN);
                    cmd.Parameters.AddWithValue("@USUARIO_CARGA", obj.USUARIO_CARGA);
                    cmd.Parameters.AddWithValue("@FECHA_CARGA", obj.FECHA_CARGA);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(int periodo, decimal monto, int idConcepto)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CONCEPTOS_X_LIQUIDACION SET");
                sql.AppendLine("MONTO=@MONTO");
                sql.AppendLine("WHERE PERIODO=@PERIODO AND ID_CONCEPTO=@ID_CONCEPTO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@ID_CONCEPTO", idConcepto);
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

        public static void delete(int periodo, int idConcepto)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  CONCEPTOS_X_LIQUIDACION ");
                sql.AppendLine("WHERE PERIODO = @PERIODO AND ID_CONCEPTO=@ID_CONCEPTO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@ID_CONCEPTO", idConcepto);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int periodo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  CONCEPTOS_X_LIQUIDACION ");
                sql.AppendLine("WHERE PERIODO = @PERIODO AND ID_CONCEPTO <> 1");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int getMaxOrden(int periodo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT ISNULL(MAX(NRO_ORDEN), 0) ");
                sql.AppendLine("FROM CONCEPTOS_X_LIQUIDACION");
                sql.AppendLine("WHERE PERIODO = @PERIODO");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Connection.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

