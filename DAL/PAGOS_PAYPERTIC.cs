using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class PAGOS_PAYPERTIC : DALBase
    {
        public int ID { get; set; }
        public DateTime FECHA { get; set; }
        public int NRO_CTA { get; set; }
        public string CUIT { get; set; }
        public string CEL { get; set; }
        public string MAIL { get; set; }
        public int COD_TARJETA { get; set; }
        public int CANT_CUOTAS { get; set; }
        public string ESTADO { get; set; }
        public string HASH_TRANSACCION { get; set; }
        public int ULTIMOS_4 { get; set; }
        public DateTime FECHA_ACREDITACION { get; set; }
        public int PRIMEROS_6 { get; set; }
        public decimal MONTO { get; set; }
        public string DESC_TARJETA { get; set; }
        public string NRO_LOTE { get; set; }
        public string NRO_CUPON { get; set; }

        public PAGOS_PAYPERTIC()
        {
            ID = 0;
            FECHA = UTILS.getFechaActual();
            NRO_CTA = 0;
            CUIT = string.Empty;
            CEL = string.Empty;
            MAIL = string.Empty;
            COD_TARJETA = 0;
            CANT_CUOTAS = 0;
            ESTADO = string.Empty;
            HASH_TRANSACCION = string.Empty;
            ULTIMOS_4 = 0;
            FECHA_ACREDITACION = UTILS.getFechaActual();
            PRIMEROS_6 = 0;
            MONTO = 0;
            DESC_TARJETA = string.Empty;
            NRO_LOTE = string.Empty;
            NRO_CUPON = string.Empty;
        }

        private static List<PAGOS_PAYPERTIC> mapeo(SqlDataReader dr)
        {
            List<PAGOS_PAYPERTIC> lst = new List<PAGOS_PAYPERTIC>();
            PAGOS_PAYPERTIC obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new PAGOS_PAYPERTIC();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.FECHA = dr.GetDateTime(1); }
                    if (!dr.IsDBNull(2)) { obj.NRO_CTA = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.CUIT = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.CEL = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.MAIL = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.COD_TARJETA = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.CANT_CUOTAS = dr.GetInt32(7); }
                    if (!dr.IsDBNull(8)) { obj.ESTADO = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.HASH_TRANSACCION = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.ULTIMOS_4 = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.FECHA_ACREDITACION = dr.GetDateTime(11); }
                    if (!dr.IsDBNull(12)) { obj.PRIMEROS_6 = dr.GetInt32(12); }
                    if (!dr.IsDBNull(13)) { obj.MONTO = dr.GetDecimal(13); }
                    if (!dr.IsDBNull(14)) { obj.DESC_TARJETA = dr.GetString(14); }
                    if (!dr.IsDBNull(15)) { obj.NRO_LOTE = dr.GetString(15); }
                    if (!dr.IsDBNull(16)) { obj.NRO_CUPON = dr.GetString(16); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PAGOS_PAYPERTIC> read()
        {
            try
            {
                List<PAGOS_PAYPERTIC> lst = new List<PAGOS_PAYPERTIC>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM PAGOS_PAYPERTIC";
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
        public static List<PAGOS_PAYPERTIC> getHuerfanos()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM PAGOS_PAYPERTIC WHERE");
                sql.AppendLine("HASH_TRANSACCION IS NOT NULL AND ESTADO IS NULL");
                List<PAGOS_PAYPERTIC> lst = new List<PAGOS_PAYPERTIC>();
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
        public static PAGOS_PAYPERTIC getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM PAGOS_PAYPERTIC WHERE");
                sql.AppendLine("ID = @ID");
                PAGOS_PAYPERTIC obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PAGOS_PAYPERTIC> lst = mapeo(dr);
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

        public static int insert(PAGOS_PAYPERTIC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO PAGOS_PAYPERTIC(");
                sql.AppendLine("FECHA");
                sql.AppendLine(", NRO_CTA");
                sql.AppendLine(", CUIT");
                sql.AppendLine(", CEL");
                sql.AppendLine(", MAIL");
                sql.AppendLine(", MONTO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@FECHA");
                sql.AppendLine(", @NRO_CTA");
                sql.AppendLine(", @CUIT");
                sql.AppendLine(", @CEL");
                sql.AppendLine(", @MAIL");
                sql.AppendLine(", @MONTO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@CUIT", obj.CUIT);
                    cmd.Parameters.AddWithValue("@CEL", obj.CEL);
                    cmd.Parameters.AddWithValue("@MAIL", obj.MAIL);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(PAGOS_PAYPERTIC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  PAGOS_PAYPERTIC SET");
                sql.AppendLine("COD_TARJETA=@COD_TARJETA");
                sql.AppendLine(", CANT_CUOTAS=@CANT_CUOTAS");
                sql.AppendLine(", ESTADO=@ESTADO");
                sql.AppendLine(", HASH_TRANSACCION=@HASH_TRANSACCION");
                sql.AppendLine(", ULTIMOS_4=@ULTIMOS_4");
                sql.AppendLine(", FECHA_ACREDITACION=@FECHA_ACREDITACION");
                sql.AppendLine(", PRIMEROS_6=@PRIMEROS_6");
                sql.AppendLine(", DESC_TARJETA=@DESC_TARJETA");
                sql.AppendLine(", NRO_LOTE=@NRO_LOTE");
                sql.AppendLine(", NRO_CUPON=@NRO_CUPON");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Parameters.AddWithValue("@COD_TARJETA", obj.COD_TARJETA);
                    cmd.Parameters.AddWithValue("@CANT_CUOTAS", obj.CANT_CUOTAS);
                    cmd.Parameters.AddWithValue("@ESTADO", obj.ESTADO);
                    cmd.Parameters.AddWithValue("@HASH_TRANSACCION", obj.HASH_TRANSACCION);
                    cmd.Parameters.AddWithValue("@ULTIMOS_4", obj.ULTIMOS_4);
                    cmd.Parameters.AddWithValue("@FECHA_ACREDITACION", obj.FECHA_ACREDITACION);
                    cmd.Parameters.AddWithValue("@PRIMEROS_6", obj.PRIMEROS_6);
                    cmd.Parameters.AddWithValue("@DESC_TARJETA", obj.DESC_TARJETA);
                    cmd.Parameters.AddWithValue("@NRO_LOTE", obj.NRO_LOTE);
                    cmd.Parameters.AddWithValue("@NRO_CUPON", obj.NRO_CUPON);
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

        public static void updateDEN(int id, string status)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE PAGOS_PAYPERTIC SET");
                sql.AppendLine("ESTADO=@ESTADO");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Parameters.AddWithValue("@ESTADO", status);
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

        public static void setHash(int id, string hash)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  PAGOS_PAYPERTIC SET");
                sql.AppendLine("HASH_TRANSACCION=@HASH_TRANSACCION");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Parameters.AddWithValue("@HASH_TRANSACCION",hash);
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

        public static void setPago(PAGOS_PAYPERTIC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE PAGOS_PAYPERTIC SET");
                sql.AppendLine("ESTADO=@ESTADO, ULTIMOS_4=@ULTIMOS_4, FECHA_ACREDITACION=@FECHA_ACREDITACION,");
                sql.AppendLine("PRIMEROS_6=@PRIMEROS_6, COD_TARJETA=@COD_TARJETA, DESC_TARJETA=@DESC_TARJETA");
                sql.AppendLine("WHERE ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Parameters.AddWithValue("@ESTADO", obj.ESTADO);
                    cmd.Parameters.AddWithValue("@ULTIMOS_4", obj.ULTIMOS_4);
                    cmd.Parameters.AddWithValue("@FECHA_ACREDITACION", obj.FECHA_ACREDITACION);
                    cmd.Parameters.AddWithValue("@PRIMEROS_6", obj.PRIMEROS_6);
                    cmd.Parameters.AddWithValue("@COD_TARJETA", obj.COD_TARJETA);
                    cmd.Parameters.AddWithValue("@DESC_TARJETA", obj.DESC_TARJETA);
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

        public static void delete(PAGOS_PAYPERTIC obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  PAGOS_PAYPERTIC ");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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

    }
}

