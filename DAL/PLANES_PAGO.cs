using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class PLANES_PAGO : DALBase
    {
        public int ID { get; set; }
        public int NRO_CTA { get; set; }
        public DateTime FECHA_INICIO { get; set; }
        public decimal MONTO_A_FINANCIAR { get; set; }
        public decimal TNA { get; set; }
        public decimal INTERES { get; set; }
        public decimal SALDO { get; set; }
        public int CANT_CUOTAS { get; set; }
        public string SIST_AMORTIZACION { get; set; }
        public DateTime FECHA_PRIMERA_CUOTA { get; set; }
        public int USUARIO_CREA { get; set; }
        public int ESTADO { get; set; }

        public PLANES_PAGO()
        {
            ID = 0;
            NRO_CTA = 0;
            FECHA_INICIO = UTILS.getFechaActual();
            MONTO_A_FINANCIAR = 0;
            TNA = 0;
            INTERES = 0;
            SALDO = 0;
            CANT_CUOTAS = 0;
            SIST_AMORTIZACION = string.Empty;
            FECHA_PRIMERA_CUOTA = UTILS.getFechaActual();
            USUARIO_CREA = 0;
            ESTADO = 0;
        }

        private static List<PLANES_PAGO> mapeo(SqlDataReader dr)
        {
            List<PLANES_PAGO> lst = new List<PLANES_PAGO>();
            PLANES_PAGO obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new PLANES_PAGO();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.FECHA_INICIO = dr.GetDateTime(2); }
                    if (!dr.IsDBNull(3)) { obj.MONTO_A_FINANCIAR = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.TNA = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.INTERES = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.SALDO = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.CANT_CUOTAS = dr.GetInt32(7); }
                    if (!dr.IsDBNull(8)) { obj.SIST_AMORTIZACION = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.FECHA_PRIMERA_CUOTA = dr.GetDateTime(9); }
                    if (!dr.IsDBNull(10)) { obj.USUARIO_CREA = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.ESTADO = dr.GetInt32(11); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PLANES_PAGO> read()
        {
            try
            {
                List<PLANES_PAGO> lst = new List<PLANES_PAGO>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM PLANES_PAGO";
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

        public static PLANES_PAGO getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM PLANES_PAGO WHERE");
                sql.AppendLine("ID = @ID");
                PLANES_PAGO obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PLANES_PAGO> lst = mapeo(dr);
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

        public static int insert(PLANES_PAGO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO PLANES_PAGO(");
                sql.AppendLine("NRO_CTA");
                sql.AppendLine(", FECHA_INICIO");
                sql.AppendLine(", MONTO_A_FINANCIAR");
                sql.AppendLine(", TNA");
                sql.AppendLine(", INTERES");
                sql.AppendLine(", SALDO");
                sql.AppendLine(", CANT_CUOTAS");
                sql.AppendLine(", SIST_AMORTIZACION");
                sql.AppendLine(", FECHA_PRIMERA_CUOTA");
                sql.AppendLine(", USUARIO_CREA");
                sql.AppendLine(", ESTADO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@NRO_CTA");
                sql.AppendLine(", @FECHA_INICIO");
                sql.AppendLine(", @MONTO_A_FINANCIAR");
                sql.AppendLine(", @TNA");
                sql.AppendLine(", @INTERES");
                sql.AppendLine(", @SALDO");
                sql.AppendLine(", @CANT_CUOTAS");
                sql.AppendLine(", @SIST_AMORTIZACION");
                sql.AppendLine(", @FECHA_PRIMERA_CUOTA");
                sql.AppendLine(", @USUARIO_CREA");
                sql.AppendLine(", @ESTADO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", obj.FECHA_INICIO);
                    cmd.Parameters.AddWithValue("@MONTO_A_FINANCIAR", obj.MONTO_A_FINANCIAR);
                    cmd.Parameters.AddWithValue("@TNA", obj.TNA);
                    cmd.Parameters.AddWithValue("@INTERES", obj.INTERES);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
                    cmd.Parameters.AddWithValue("@CANT_CUOTAS", obj.CANT_CUOTAS);
                    cmd.Parameters.AddWithValue("@SIST_AMORTIZACION", obj.SIST_AMORTIZACION);
                    cmd.Parameters.AddWithValue("@FECHA_PRIMERA_CUOTA", obj.FECHA_PRIMERA_CUOTA);
                    cmd.Parameters.AddWithValue("@USUARIO_CREA", obj.USUARIO_CREA);
                    cmd.Parameters.AddWithValue("@ESTADO", obj.ESTADO);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(PLANES_PAGO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  PLANES_PAGO SET");
                sql.AppendLine("NRO_CTA=@NRO_CTA");
                sql.AppendLine(", FECHA_INICIO=@FECHA_INICIO");
                sql.AppendLine(", MONTO_A_FINANCIAR=@MONTO_A_FINANCIAR");
                sql.AppendLine(", TNA=@TNA");
                sql.AppendLine(", INTERES=@INTERES");
                sql.AppendLine(", SALDO=@SALDO");
                sql.AppendLine(", CANT_CUOTAS=@CANT_CUOTAS");
                sql.AppendLine(", SIST_AMORTIZACION=@SIST_AMORTIZACION");
                sql.AppendLine(", FECHA_PRIMERA_CUOTA=@FECHA_PRIMERA_CUOTA");
                sql.AppendLine(", USUARIO_CREA=@USUARIO_CREA");
                sql.AppendLine(", ESTADO=@ESTADO");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", obj.FECHA_INICIO);
                    cmd.Parameters.AddWithValue("@MONTO_A_FINANCIAR", obj.MONTO_A_FINANCIAR);
                    cmd.Parameters.AddWithValue("@TNA", obj.TNA);
                    cmd.Parameters.AddWithValue("@INTERES", obj.INTERES);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
                    cmd.Parameters.AddWithValue("@CANT_CUOTAS", obj.CANT_CUOTAS);
                    cmd.Parameters.AddWithValue("@SIST_AMORTIZACION", obj.SIST_AMORTIZACION);
                    cmd.Parameters.AddWithValue("@FECHA_PRIMERA_CUOTA", obj.FECHA_PRIMERA_CUOTA);
                    cmd.Parameters.AddWithValue("@USUARIO_CREA", obj.USUARIO_CREA);
                    cmd.Parameters.AddWithValue("@ESTADO", obj.ESTADO);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(PLANES_PAGO obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  PLANES_PAGO ");
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

