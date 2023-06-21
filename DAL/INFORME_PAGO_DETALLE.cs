using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class INFORME_PAGO_DETALLE : DALBase
    {
        public DateTime FECHA { get; set; }
        public int NRO_CTA { get; set; }
        public int NRO_RECIBO_PAGO { get; set; }
        public decimal HABER { get; set; }
        public decimal CAPITAL_PAGADO { get; set; }
        public decimal INTERES_PAGADO { get; set; }
        public decimal EFECTIVO_EDMINISTRACION { get; set; }
        public decimal CHEQUE { get; set; }
        public decimal BANELCO { get; set; }
        public decimal RAPI_PAGO { get; set; }
        public decimal TRANSFERENCIA_BANCARIA { get; set; }
        public decimal DEBITO_AUTOMATICO { get; set; }
        public decimal PAYPERTIC { get; set; }
        public decimal DE_BILLETERA { get; set; }
        public decimal A_BILLETERA { get; set; }

        public INFORME_PAGO_DETALLE()
        {
            FECHA = UTILS.getFechaActual();
            NRO_CTA = 0;
            NRO_RECIBO_PAGO = 0;
            HABER = 0;
            CAPITAL_PAGADO = 0;
            INTERES_PAGADO = 0;
            EFECTIVO_EDMINISTRACION = 0;
            CHEQUE = 0;
            BANELCO = 0;
            RAPI_PAGO = 0;
            TRANSFERENCIA_BANCARIA = 0;
            DEBITO_AUTOMATICO = 0;
            PAYPERTIC = 0;
            DE_BILLETERA = 0;
            A_BILLETERA = 0;
        }

        private static List<INFORME_PAGO_DETALLE> mapeo(SqlDataReader dr)
        {
            List<INFORME_PAGO_DETALLE> lst = new List<INFORME_PAGO_DETALLE>();
            INFORME_PAGO_DETALLE obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new INFORME_PAGO_DETALLE();
                    if (!dr.IsDBNull(0)) { obj.FECHA = dr.GetDateTime(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.NRO_RECIBO_PAGO = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.HABER = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.CAPITAL_PAGADO = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.INTERES_PAGADO = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.EFECTIVO_EDMINISTRACION = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.CHEQUE = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.BANELCO = dr.GetDecimal(8); }
                    if (!dr.IsDBNull(9)) { obj.RAPI_PAGO = dr.GetDecimal(9); }
                    if (!dr.IsDBNull(10)) { obj.TRANSFERENCIA_BANCARIA = dr.GetDecimal(10); }
                    if (!dr.IsDBNull(11)) { obj.DEBITO_AUTOMATICO = dr.GetDecimal(11); }
                    if (!dr.IsDBNull(12)) { obj.PAYPERTIC = dr.GetDecimal(12); }
                    if (!dr.IsDBNull(13)) { obj.DE_BILLETERA = dr.GetDecimal(13); }
                    if (!dr.IsDBNull(14)) { obj.A_BILLETERA = dr.GetDecimal(14); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<INFORME_PAGO_DETALLE> read(int anio, int mes)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT CONVERT(DATE,FECHA) AS FECHA, NRO_CTA, NRO_RECIBO_PAGO,");
                sql.AppendLine("ISNULL(SUM(HABER), 0) AS HABER, ");
                sql.AppendLine("ISNULL(SUM(CAPITAL_PAGADO), 0) AS CAPITAL_PAGADO,");
                sql.AppendLine("ISNULL(SUM(INTERES_PAGADO), 0) AS INTERES_PAGADO,");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO) FROM PAGOS_X_FACTURA B");
                sql.AppendLine("WHERE B.ID_FACTURA=A.NRO_RECIBO_PAGO AND B.ID_PLAN_PAGO=1), 0)");
                sql.AppendLine("AS EFECTIVO_EDMINISTRACION,");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO) FROM PAGOS_X_FACTURA B");
                sql.AppendLine("WHERE B.ID_FACTURA=A.NRO_RECIBO_PAGO AND B.ID_PLAN_PAGO=2), 0)");
                sql.AppendLine("AS CHEQUE,");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO) FROM PAGOS_X_FACTURA B");
                sql.AppendLine("WHERE B.ID_FACTURA=A.NRO_RECIBO_PAGO AND B.ID_PLAN_PAGO=3), 0)");
                sql.AppendLine("AS BANELCO,");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO) FROM PAGOS_X_FACTURA B");
                sql.AppendLine("WHERE B.ID_FACTURA=A.NRO_RECIBO_PAGO AND B.ID_PLAN_PAGO=4), 0)");
                sql.AppendLine("AS RAPI_PAGO,");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO) FROM PAGOS_X_FACTURA B");
                sql.AppendLine("WHERE B.ID_FACTURA=A.NRO_RECIBO_PAGO AND B.ID_PLAN_PAGO=5), 0)");
                sql.AppendLine("AS TRANSFERENCIA_BANCARIA,");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO) FROM PAGOS_X_FACTURA B");
                sql.AppendLine("WHERE B.ID_FACTURA=A.NRO_RECIBO_PAGO AND B.ID_PLAN_PAGO=6), 0)");
                sql.AppendLine("AS DEBITO_AUTOMATICO,");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO) FROM PAGOS_X_FACTURA B");
                sql.AppendLine("WHERE B.ID_FACTURA=A.NRO_RECIBO_PAGO AND B.ID_PLAN_PAGO=8), 0)");
                sql.AppendLine("AS PAYPERTIC,");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO) FROM PAGOS_X_FACTURA B");
                sql.AppendLine("WHERE B.ID_FACTURA=A.NRO_RECIBO_PAGO AND B.ID_PLAN_PAGO=7), 0)");
                sql.AppendLine("AS DE_BILLETERA,");
                sql.AppendLine("CASE");
                sql.AppendLine("WHEN SUM(HABER) <> (SELECT SUM(MONTO) FROM PAGOS_X_FACTURA B");
                sql.AppendLine("WHERE B.ID_FACTURA=A.NRO_RECIBO_PAGO) THEN");
                sql.AppendLine("(SELECT SUM(MONTO) FROM PAGOS_X_FACTURA B");
                sql.AppendLine("WHERE B.ID_FACTURA=A.NRO_RECIBO_PAGO) - SUM(HABER)");
                sql.AppendLine("ELSE 0");
                sql.AppendLine("END AS A_BILLETERA");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE TIPO_MOVIMIENTO=2 AND YEAR(FECHA)=@ANIO");
                if (mes != 0)
                    sql.AppendLine("AND MONTH(FECHA)=@MES");
                sql.AppendLine("GROUP BY NRO_RECIBO_PAGO, CONVERT(DATE,FECHA), NRO_CTA");

                List<INFORME_PAGO_DETALLE> lst = new List<INFORME_PAGO_DETALLE>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ANIO", anio);
                    cmd.Parameters.AddWithValue("@MES", mes);
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

        public static INFORME_PAGO_DETALLE getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM INFORME_PAGO_DETALLE WHERE");
                INFORME_PAGO_DETALLE obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<INFORME_PAGO_DETALLE> lst = mapeo(dr);
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

        public static int insert(INFORME_PAGO_DETALLE obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO INFORME_PAGO_DETALLE(");
                sql.AppendLine("FECHA");
                sql.AppendLine(", NRO_CTA");
                sql.AppendLine(", NRO_RECIBO_PAGO");
                sql.AppendLine(", HABER");
                sql.AppendLine(", CAPITAL_PAGADO");
                sql.AppendLine(", INTERES_PAGADO");
                sql.AppendLine(", EFECTIVO_EDMINISTRACION");
                sql.AppendLine(", CHEQUE");
                sql.AppendLine(", BANELCO");
                sql.AppendLine(", RAPI_PAGO");
                sql.AppendLine(", TRANSFERENCIA_BANCARIA");
                sql.AppendLine(", DEBITO_AUTOMATICO");
                sql.AppendLine(", PAYPERTIC");
                sql.AppendLine(", DE_BILLETERA");
                sql.AppendLine(", A_BILLETERA");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@FECHA");
                sql.AppendLine(", @NRO_CTA");
                sql.AppendLine(", @NRO_RECIBO_PAGO");
                sql.AppendLine(", @HABER");
                sql.AppendLine(", @CAPITAL_PAGADO");
                sql.AppendLine(", @INTERES_PAGADO");
                sql.AppendLine(", @EFECTIVO_EDMINISTRACION");
                sql.AppendLine(", @CHEQUE");
                sql.AppendLine(", @BANELCO");
                sql.AppendLine(", @RAPI_PAGO");
                sql.AppendLine(", @TRANSFERENCIA_BANCARIA");
                sql.AppendLine(", @DEBITO_AUTOMATICO");
                sql.AppendLine(", @PAYPERTIC");
                sql.AppendLine(", @DE_BILLETERA");
                sql.AppendLine(", @A_BILLETERA");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", obj.NRO_RECIBO_PAGO);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@CAPITAL_PAGADO", obj.CAPITAL_PAGADO);
                    cmd.Parameters.AddWithValue("@INTERES_PAGADO", obj.INTERES_PAGADO);
                    cmd.Parameters.AddWithValue("@EFECTIVO_EDMINISTRACION", obj.EFECTIVO_EDMINISTRACION);
                    cmd.Parameters.AddWithValue("@CHEQUE", obj.CHEQUE);
                    cmd.Parameters.AddWithValue("@BANELCO", obj.BANELCO);
                    cmd.Parameters.AddWithValue("@RAPI_PAGO", obj.RAPI_PAGO);
                    cmd.Parameters.AddWithValue("@TRANSFERENCIA_BANCARIA", obj.TRANSFERENCIA_BANCARIA);
                    cmd.Parameters.AddWithValue("@DEBITO_AUTOMATICO", obj.DEBITO_AUTOMATICO);
                    cmd.Parameters.AddWithValue("@PAYPERTIC", obj.PAYPERTIC);
                    cmd.Parameters.AddWithValue("@DE_BILLETERA", obj.DE_BILLETERA);
                    cmd.Parameters.AddWithValue("@A_BILLETERA", obj.A_BILLETERA);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(INFORME_PAGO_DETALLE obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  INFORME_PAGO_DETALLE SET");
                sql.AppendLine("FECHA=@FECHA");
                sql.AppendLine(", NRO_CTA=@NRO_CTA");
                sql.AppendLine(", NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO");
                sql.AppendLine(", HABER=@HABER");
                sql.AppendLine(", CAPITAL_PAGADO=@CAPITAL_PAGADO");
                sql.AppendLine(", INTERES_PAGADO=@INTERES_PAGADO");
                sql.AppendLine(", EFECTIVO_EDMINISTRACION=@EFECTIVO_EDMINISTRACION");
                sql.AppendLine(", CHEQUE=@CHEQUE");
                sql.AppendLine(", BANELCO=@BANELCO");
                sql.AppendLine(", RAPI_PAGO=@RAPI_PAGO");
                sql.AppendLine(", TRANSFERENCIA_BANCARIA=@TRANSFERENCIA_BANCARIA");
                sql.AppendLine(", DEBITO_AUTOMATICO=@DEBITO_AUTOMATICO");
                sql.AppendLine(", PAYPERTIC=@PAYPERTIC");
                sql.AppendLine(", DE_BILLETERA=@DE_BILLETERA");
                sql.AppendLine(", A_BILLETERA=@A_BILLETERA");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", obj.NRO_RECIBO_PAGO);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@CAPITAL_PAGADO", obj.CAPITAL_PAGADO);
                    cmd.Parameters.AddWithValue("@INTERES_PAGADO", obj.INTERES_PAGADO);
                    cmd.Parameters.AddWithValue("@EFECTIVO_EDMINISTRACION", obj.EFECTIVO_EDMINISTRACION);
                    cmd.Parameters.AddWithValue("@CHEQUE", obj.CHEQUE);
                    cmd.Parameters.AddWithValue("@BANELCO", obj.BANELCO);
                    cmd.Parameters.AddWithValue("@RAPI_PAGO", obj.RAPI_PAGO);
                    cmd.Parameters.AddWithValue("@TRANSFERENCIA_BANCARIA", obj.TRANSFERENCIA_BANCARIA);
                    cmd.Parameters.AddWithValue("@DEBITO_AUTOMATICO", obj.DEBITO_AUTOMATICO);
                    cmd.Parameters.AddWithValue("@PAYPERTIC", obj.PAYPERTIC);
                    cmd.Parameters.AddWithValue("@DE_BILLETERA", obj.DE_BILLETERA);
                    cmd.Parameters.AddWithValue("@A_BILLETERA", obj.A_BILLETERA);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(INFORME_PAGO_DETALLE obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  INFORME_PAGO_DETALLE ");
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

