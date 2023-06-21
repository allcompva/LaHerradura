using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class INFORME_SALDOS : DALBase
    {
        public int NRO_CTA { get; set; }
        public decimal FACTURACION_EXPENSAS { get; set; }
        public decimal PAGOS { get; set; }
        public decimal INTERESES_FACTURADOS { get; set; }
        public decimal NOTAS_CREDITO { get; set; }
        public decimal INTERES_PLAN_PAGO { get; set; }
        public decimal FACTURACION_EXTERNA { get; set; }
        public decimal A_BILLETERA { get; set; }
        public decimal DE_BILLETERA { get; set; }
        public decimal SALDO { get; set; }

        public INFORME_SALDOS()
        {
            NRO_CTA = 0;
            FACTURACION_EXPENSAS = 0;
            PAGOS = 0;
            INTERESES_FACTURADOS = 0;
            NOTAS_CREDITO = 0;
            INTERES_PLAN_PAGO = 0;
            FACTURACION_EXTERNA = 0;
            A_BILLETERA = 0;
            DE_BILLETERA = 0;
            SALDO = 0;
        }
        private static List<INFORME_SALDOS> mapeo(SqlDataReader dr)
        {
            List<INFORME_SALDOS> lst = new List<INFORME_SALDOS>();
            INFORME_SALDOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new INFORME_SALDOS();
                    if (!dr.IsDBNull(0)) { obj.NRO_CTA = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.FACTURACION_EXPENSAS = dr.GetDecimal(1); }
                    if (!dr.IsDBNull(2)) { obj.PAGOS = dr.GetDecimal(2); }
                    if (!dr.IsDBNull(3)) { obj.INTERESES_FACTURADOS = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.NOTAS_CREDITO = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.INTERES_PLAN_PAGO = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.FACTURACION_EXTERNA = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.A_BILLETERA = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.DE_BILLETERA = dr.GetDecimal(8); }

                    obj.SALDO = obj.FACTURACION_EXPENSAS - obj.PAGOS +
                        obj.INTERESES_FACTURADOS - obj.NOTAS_CREDITO +
                        obj.INTERES_PLAN_PAGO + obj.FACTURACION_EXTERNA - 
                        obj.A_BILLETERA + obj.DE_BILLETERA;

                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<INFORME_SALDOS> read(DateTime FECHA)
        {
            try
            {
                List<INFORME_SALDOS> lst = new List<INFORME_SALDOS>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT X.NRO_CTA,");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO_ORIGINAL),0)");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE A.NRO_CTA = X.NRO_CTA AND TIPO_MOVIMIENTO IN (1)");
                sql.AppendLine("AND A.FECHA_CAE < @FECHA) AS 'FACTURACION EXPENSAS'");
                sql.AppendLine(",");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO),0)");
                sql.AppendLine("FROM PAGOS_CON_CUENTA A");
                sql.AppendLine("WHERE  A.ID_PLAN_PAGO !=7 AND A.NRO_CTA=X.NRO_CTA");
                sql.AppendLine("AND A.FECHA <= @FECHA) AS 'PAGOS'");
                sql.AppendLine(",");
                sql.AppendLine("(SELECT ISNULL(SUM(INTERES_PAGADO),0) FROM CTACTE_EXPENSAS A");
                sql.AppendLine("WHERE A.NRO_CTA = X.NRO_CTA AND TIPO_MOVIMIENTO IN (2) AND INTERES_PAGADO <> 0");
                sql.AppendLine("AND A.FECHA <= @FECHA) ");
                sql.AppendLine("AS 'INTERES FACTURADO'");
                sql.AppendLine(",");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO),0) FROM FACTURAS_X_EXPENSA A");
                sql.AppendLine("WHERE A.NRO_CTA= X.NRO_CTA AND TIPO_COMPROBANTE = 13");
                sql.AppendLine("AND A.FECHA_CAE <= @FECHA) AS 'NOTAS DE CREDITO'");
                sql.AppendLine(",");
                sql.AppendLine("ISNULL((SELECT ISNULL( ");
                sql.AppendLine("ISNULL(INTERES,0) + ISNULL(A.MONTO_A_FINANCIAR,0) -");
                sql.AppendLine("(SELECT ISNULL(SUM(B.MONTO_ORIGINAL),0)");
                sql.AppendLine("FROM CTACTE_EXPENSAS B WHERE A.ID = B.NRO_PLAN_PAGO AND TIPO_MOVIMIENTO = 1),0)");
                sql.AppendLine("FROM PLANES_PAGO A");
                sql.AppendLine("WHERE A.NRO_CTA= X.NRO_CTA");
                sql.AppendLine("AND A.FECHA_INICIO <= @FECHA),0) AS 'INTERES PLAN PAGO'");
                sql.AppendLine(",");
                sql.AppendLine("(SELECT ISNULL(SUM(DEBE),0)");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN FACTURAS_X_EXPENSA B ON B.ID_CTACTE=A.ID");
                sql.AppendLine("WHERE A.NRO_CTA =  X.NRO_CTA AND TIPO_MOVIMIENTO IN (100)");
                sql.AppendLine("AND A.FECHA_CAE <= @FECHA) AS 'FACTURACION EXTERNA'");
                sql.AppendLine(",");
                sql.AppendLine("(SELECT ISNULL(SUM(A.MONTO),0)");
                sql.AppendLine("FROM MOV_BILLETERA A");
                sql.AppendLine("WHERE A.NRO_CTA = X.NRO_CTA AND TIPO_MOVIMIENTO = 1");
                sql.AppendLine("AND A.FECHA <= @FECHA) AS 'A BILLETERA'");
                sql.AppendLine(",");
                sql.AppendLine("(SELECT ISNULL(SUM(A.MONTO),0)");
                sql.AppendLine("FROM MOV_BILLETERA A");
                sql.AppendLine("WHERE A.NRO_CTA =  X.NRO_CTA AND TIPO_MOVIMIENTO = 2");
                sql.AppendLine("AND A.FECHA <= @FECHA) AS 'DE BILLETERA'");
                sql.AppendLine("FROM INMUEBLES X");
                sql.AppendLine("GROUP BY X.NRO_CTA");
                sql.AppendLine("ORDER BY X.NRO_CTA");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@FECHA", FECHA);
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
    }
}
