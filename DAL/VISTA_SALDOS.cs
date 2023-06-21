using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class VISTA_SALDOS : DALBase
    {
        public int NRO_CTA { get; set; }
        public decimal FACTURACION_EXPENSAS { get; set; }
        public decimal PAGOS { get; set; }
        public decimal FACTURACION_INTERESES { get; set; }
        public decimal NOTAS_CREDITO { get; set; }
        public decimal INTERES_PLAN_PAGO { get; set; }
        public decimal FACTURAS_MANUALES { get; set; }
        public decimal NOTAS_DEBITO_INTERNA { get; set; }
        public decimal NOTAS_CREDITO_INTERNA { get; set; }
        public decimal SALDO { get; set; }

        public VISTA_SALDOS()
        {
            NRO_CTA = 0;
            FACTURACION_EXPENSAS = 0;
            PAGOS = 0;
            FACTURACION_INTERESES = 0;
            NOTAS_CREDITO = 0;
            INTERES_PLAN_PAGO = 0;
            FACTURAS_MANUALES = 0;
            NOTAS_DEBITO_INTERNA = 0;
            NOTAS_CREDITO_INTERNA = 0;
            SALDO = 0;
        }

        private static List<VISTA_SALDOS> mapeo(SqlDataReader dr)
        {
            List<VISTA_SALDOS> lst = new List<VISTA_SALDOS>();
            VISTA_SALDOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new VISTA_SALDOS();
                    if (!dr.IsDBNull(0)) { obj.NRO_CTA = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.FACTURACION_EXPENSAS = dr.GetDecimal(1); }
                    if (!dr.IsDBNull(2)) { obj.PAGOS = dr.GetDecimal(2); }
                    if (!dr.IsDBNull(3)) { obj.FACTURACION_INTERESES = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.NOTAS_CREDITO = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.INTERES_PLAN_PAGO = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.FACTURAS_MANUALES = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.NOTAS_DEBITO_INTERNA = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.NOTAS_CREDITO_INTERNA = dr.GetDecimal(8); }
                    if (!dr.IsDBNull(9)) { obj.SALDO = dr.GetDecimal(9); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<VISTA_SALDOS> read(DateTime fecha)
        {
            try
            {
                List<VISTA_SALDOS> lst = new List<VISTA_SALDOS>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT NRO_CTA,");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO_ORIGINAL)");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE A.NRO_CTA = Z.NRO_CTA AND TIPO_MOVIMIENTO IN (1) AND FECHA_CAE <= @FECHA),0) AS FACTURACION_EXPENSAS");
                sql.AppendLine(",");
                sql.AppendLine("ISNULL((SELECT SUM(A.MONTO)");
                sql.AppendLine("FROM PAGOS_CON_CUENTA A");
                sql.AppendLine("WHERE A.NRO_CTA = Z.NRO_CTA AND A.ID_PLAN_PAGO !=7 AND FECHA <= @FECHA),0) AS PAGOS");
                sql.AppendLine(",");
                sql.AppendLine("ISNULL((SELECT SUM(INTERES_PAGADO)");
                sql.AppendLine("FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE NRO_CTA = Z.NRO_CTA AND TIPO_MOVIMIENTO IN (2) AND INTERES_PAGADO <> 0 AND FECHA <= @FECHA),0) AS FACTURACION_INTERESES");
                sql.AppendLine(",");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO) FROM FACTURAS_X_EXPENSA");
                sql.AppendLine("WHERE NRO_CTA=Z.NRO_CTA AND TIPO_COMPROBANTE = 13 AND FECHA_CAE <= @FECHA),0) AS NOTAS_CREDITO");
                sql.AppendLine(",");
                sql.AppendLine("ISNULL((SELECT SUM(INTERES + A.MONTO_A_FINANCIAR) -");
                sql.AppendLine("(SELECT SUM(B.MONTO_ORIGINAL)");
                sql.AppendLine("FROM CTACTE_EXPENSAS B WHERE B.NRO_PLAN_PAGO IS NOT NULL AND TIPO_MOVIMIENTO = 1 AND B.NRO_CTA=Z.NRO_CTA AND FECHA <= @FECHA)");
                sql.AppendLine("FROM PLANES_PAGO A");
                sql.AppendLine("WHERE A.NRO_CTA=Z.NRO_CTA AND FECHA_INICIO <= @FECHA),0) AS INTERES_PLAN_PAGO");
                sql.AppendLine(",");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO_ORIGINAL)");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN FACTURAS_X_EXPENSA B ON B.ID_CTACTE=A.ID");
                sql.AppendLine("WHERE A.NRO_CTA = Z.NRO_CTA AND TIPO_MOVIMIENTO IN (100) AND FECHA <= @FECHA),0) AS FACTURAS_MANUALES,");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO_ORIGINAL)");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN FACTURAS_X_EXPENSA B ON B.ID_CTACTE=A.ID");
                sql.AppendLine("WHERE A.NRO_CTA = Z.NRO_CTA AND TIPO_MOVIMIENTO IN (21) AND FECHA <= @FECHA),0) AS NOTAS_DEBITO_INTERNA,");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO)");
                sql.AppendLine("FROM FACTURAS_X_EXPENSA A");
                sql.AppendLine("WHERE A.NRO_CTA = Z.NRO_CTA AND TIPO_COMPROBANTE IN (31) AND FECHA_CAE <= @FECHA),0) AS NOTAS_CREDITO_INTERNA");
                sql.AppendLine(",");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO_ORIGINAL)");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE A.NRO_CTA = Z.NRO_CTA AND TIPO_MOVIMIENTO IN (1) AND FECHA_CAE <= @FECHA),0) +");
                sql.AppendLine("ISNULL((SELECT SUM(INTERES_PAGADO)");
                sql.AppendLine("FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE NRO_CTA = Z.NRO_CTA AND TIPO_MOVIMIENTO IN (2) AND INTERES_PAGADO <> 0 AND FECHA <= @FECHA),0) +");
                sql.AppendLine("ISNULL((SELECT SUM(INTERES + A.MONTO_A_FINANCIAR) -");
                sql.AppendLine("(SELECT SUM(B.MONTO_ORIGINAL)");
                sql.AppendLine("FROM CTACTE_EXPENSAS B WHERE B.NRO_PLAN_PAGO IS NOT NULL AND TIPO_MOVIMIENTO = 1 AND B.NRO_CTA=Z.NRO_CTA AND FECHA <= @FECHA)");
                sql.AppendLine("FROM PLANES_PAGO A");
                sql.AppendLine("WHERE A.NRO_CTA=Z.NRO_CTA AND FECHA_INICIO <= @FECHA),0) +");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO_ORIGINAL)");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN FACTURAS_X_EXPENSA B ON B.ID_CTACTE=A.ID");
                sql.AppendLine("WHERE A.NRO_CTA = Z.NRO_CTA AND TIPO_MOVIMIENTO IN (21) AND FECHA <= @FECHA),0) +");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO_ORIGINAL)");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN FACTURAS_X_EXPENSA B ON B.ID_CTACTE=A.ID");
                sql.AppendLine("WHERE A.NRO_CTA = Z.NRO_CTA AND TIPO_MOVIMIENTO IN (100) AND FECHA <= @FECHA),0) -");
                sql.AppendLine("ISNULL((SELECT SUM(A.MONTO)");
                sql.AppendLine("FROM PAGOS_CON_CUENTA A");
                sql.AppendLine("WHERE A.NRO_CTA = Z.NRO_CTA AND A.ID_PLAN_PAGO !=7 AND FECHA <= @FECHA),0) -");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO) FROM FACTURAS_X_EXPENSA");
                sql.AppendLine("WHERE NRO_CTA=Z.NRO_CTA AND TIPO_COMPROBANTE = 13 AND FECHA_CAE <= @FECHA),0) -");
                sql.AppendLine("ISNULL((SELECT SUM(MONTO)");
                sql.AppendLine("FROM FACTURAS_X_EXPENSA A");
                sql.AppendLine("WHERE A.NRO_CTA = Z.NRO_CTA AND TIPO_COMPROBANTE IN (31) AND FECHA_CAE <= @FECHA),0) AS SALDO");
                sql.AppendLine("FROM INMUEBLES Z");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
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

        public static VISTA_SALDOS getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM VISTA_SALDOS WHERE");
                VISTA_SALDOS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<VISTA_SALDOS> lst = mapeo(dr);
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

        public static int insert(VISTA_SALDOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO VISTA_SALDOS(");
                sql.AppendLine("NRO_CTA");
                sql.AppendLine(", FACTURACION_EXPENSAS");
                sql.AppendLine(", PAGOS");
                sql.AppendLine(", FACTURACION_INTERESES");
                sql.AppendLine(", NOTAS_CREDITO");
                sql.AppendLine(", INTERES_PLAN_PAGO");
                sql.AppendLine(", FACTURAS_MANUALES");
                sql.AppendLine(", NOTAS_DEBITO_INTERNA");
                sql.AppendLine(", NOTAS_CREDITO_INTERNA");
                sql.AppendLine(", SALDO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@NRO_CTA");
                sql.AppendLine(", @FACTURACION_EXPENSAS");
                sql.AppendLine(", @PAGOS");
                sql.AppendLine(", @FACTURACION_INTERESES");
                sql.AppendLine(", @NOTAS_CREDITO");
                sql.AppendLine(", @INTERES_PLAN_PAGO");
                sql.AppendLine(", @FACTURAS_MANUALES");
                sql.AppendLine(", @NOTAS_DEBITO_INTERNA");
                sql.AppendLine(", @NOTAS_CREDITO_INTERNA");
                sql.AppendLine(", @SALDO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@FACTURACION_EXPENSAS", obj.FACTURACION_EXPENSAS);
                    cmd.Parameters.AddWithValue("@PAGOS", obj.PAGOS);
                    cmd.Parameters.AddWithValue("@FACTURACION_INTERESES", obj.FACTURACION_INTERESES);
                    cmd.Parameters.AddWithValue("@NOTAS_CREDITO", obj.NOTAS_CREDITO);
                    cmd.Parameters.AddWithValue("@INTERES_PLAN_PAGO", obj.INTERES_PLAN_PAGO);
                    cmd.Parameters.AddWithValue("@FACTURAS_MANUALES", obj.FACTURAS_MANUALES);
                    cmd.Parameters.AddWithValue("@NOTAS_DEBITO_INTERNA", obj.NOTAS_DEBITO_INTERNA);
                    cmd.Parameters.AddWithValue("@NOTAS_CREDITO_INTERNA", obj.NOTAS_CREDITO_INTERNA);
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

        public static void update(VISTA_SALDOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  VISTA_SALDOS SET");
                sql.AppendLine("NRO_CTA=@NRO_CTA");
                sql.AppendLine(", FACTURACION_EXPENSAS=@FACTURACION_EXPENSAS");
                sql.AppendLine(", PAGOS=@PAGOS");
                sql.AppendLine(", FACTURACION_INTERESES=@FACTURACION_INTERESES");
                sql.AppendLine(", NOTAS_CREDITO=@NOTAS_CREDITO");
                sql.AppendLine(", INTERES_PLAN_PAGO=@INTERES_PLAN_PAGO");
                sql.AppendLine(", FACTURAS_MANUALES=@FACTURAS_MANUALES");
                sql.AppendLine(", NOTAS_DEBITO_INTERNA=@NOTAS_DEBITO_INTERNA");
                sql.AppendLine(", NOTAS_CREDITO_INTERNA=@NOTAS_CREDITO_INTERNA");
                sql.AppendLine(", SALDO=@SALDO");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@FACTURACION_EXPENSAS", obj.FACTURACION_EXPENSAS);
                    cmd.Parameters.AddWithValue("@PAGOS", obj.PAGOS);
                    cmd.Parameters.AddWithValue("@FACTURACION_INTERESES", obj.FACTURACION_INTERESES);
                    cmd.Parameters.AddWithValue("@NOTAS_CREDITO", obj.NOTAS_CREDITO);
                    cmd.Parameters.AddWithValue("@INTERES_PLAN_PAGO", obj.INTERES_PLAN_PAGO);
                    cmd.Parameters.AddWithValue("@FACTURAS_MANUALES", obj.FACTURAS_MANUALES);
                    cmd.Parameters.AddWithValue("@NOTAS_DEBITO_INTERNA", obj.NOTAS_DEBITO_INTERNA);
                    cmd.Parameters.AddWithValue("@NOTAS_CREDITO_INTERNA", obj.NOTAS_CREDITO_INTERNA);
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

        public static void delete(VISTA_SALDOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  VISTA_SALDOS ");
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

