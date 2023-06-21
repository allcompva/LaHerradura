using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class INFORME_TRANSACCIONES : DALBase
    {
        public DateTime FECHA { get; set; }
        public Int64 NRO_RECIBO_PAGO { get; set; }
        public string MEDIO_PAGO { get; set; }
        public string BANCO { get; set; }
        public string NRO_CHEQUE { get; set; }
        public decimal MONTO { get; set; }
        public int NRO_CTA { get; set; }
        public int CANT_MOV { get; set; }

        public INFORME_TRANSACCIONES()
        {
            FECHA = UTILS.getFechaActual();
            NRO_RECIBO_PAGO = 0;
            MEDIO_PAGO = string.Empty;
            BANCO = string.Empty;
            NRO_CHEQUE = string.Empty;
            MONTO = 0;
            CANT_MOV = 0;
        }
        private static List<INFORME_TRANSACCIONES> mapeo(SqlDataReader dr)
        {
            List<INFORME_TRANSACCIONES> lst = new List<INFORME_TRANSACCIONES>();
            INFORME_TRANSACCIONES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    obj = new INFORME_TRANSACCIONES();
                    if (!dr.IsDBNull(0)) { obj.FECHA = dr.GetDateTime(0); }
                    if (!dr.IsDBNull(dr.GetOrdinal("ID_FACTURA")))
                    {
                        obj.NRO_RECIBO_PAGO = dr.GetInt64(dr.GetOrdinal("ID_FACTURA"));
                    }
                    if (!dr.IsDBNull(2)) { obj.MEDIO_PAGO = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.BANCO = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.NRO_CHEQUE = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.MONTO = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.NRO_CTA = dr.GetInt32(6); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<INFORME_TRANSACCIONES> read(int anio, int mes)
        {
            try
            {
                INFORME_TRANSACCIONES obj;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.FECHA, A.ID_FACTURA, B.DESCRIPCION, C.DENOMINACION, A.NRO_CHEQUE, A.MONTO,");
                sql.AppendLine("(SELECT NRO_CTA FROM CTACTE_EXPENSAS X WHERE A.ID_FACTURA=X.NRO_RECIBO_PAGO GROUP BY NRO_CTA) AS NRO_CTA");
                sql.AppendLine("FROM PAGOS_X_FACTURA A");
                sql.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_PLAN_PAGO = B.ID");
                sql.AppendLine("LEFT JOIN BANCOS C ON A.ID_BANCO = C.CODIGO");
                if (mes != 0)
                    sql.AppendLine("WHERE MONTH(A.FECHA) = @MES AND YEAR(A.FECHA) = @ANIO");
                else
                    sql.AppendLine("WHERE YEAR(A.FECHA) = @ANIO");
                sql.AppendLine("ORDER BY ID_FACTURA");

                List<INFORME_TRANSACCIONES> lst = new List<INFORME_TRANSACCIONES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    if (mes != 0)
                    {
                        cmd.Parameters.AddWithValue("@ANIO", anio);
                        cmd.Parameters.AddWithValue("@MES", mes);
                    }
                    else
                        cmd.Parameters.AddWithValue("@ANIO", anio);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            obj = new INFORME_TRANSACCIONES();
                            if (!dr.IsDBNull(0)) { obj.FECHA = dr.GetDateTime(0); }
                            if (!dr.IsDBNull(dr.GetOrdinal("ID_FACTURA")))
                            {
                                obj.NRO_RECIBO_PAGO = dr.GetInt64(dr.GetOrdinal("ID_FACTURA"));
                            }
                            if (!dr.IsDBNull(2)) { obj.MEDIO_PAGO = dr.GetString(2); }
                            if (!dr.IsDBNull(3)) { obj.BANCO = dr.GetString(3); }
                            if (!dr.IsDBNull(4)) { obj.NRO_CHEQUE = dr.GetString(4); }
                            if (!dr.IsDBNull(5)) { obj.MONTO = dr.GetDecimal(5); }
                            if (!dr.IsDBNull(6)) { obj.NRO_CTA = dr.GetInt32(6); }
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
        public static List<INFORME_TRANSACCIONES> readResumen(int anio, int mes)
        {
            try
            {
                INFORME_TRANSACCIONES obj;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.NRO_CTA, COUNT(*),");
                sql.AppendLine("SUM(A.MONTO) FROM RESUMEN_PAGOS A");
                if (mes != 0)
                {
                    sql.AppendLine("WHERE MONTH(A.FECHA) = @MES AND");
                    sql.AppendLine("YEAR(A.FECHA) = @ANIO");
                }
                else
                    sql.AppendLine("WHERE YEAR(A.FECHA) = @ANIO");
                sql.AppendLine("GROUP BY A.NRO_CTA");
                sql.AppendLine("ORDER BY A.NRO_CTA");

                List<INFORME_TRANSACCIONES> lst = new List<INFORME_TRANSACCIONES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    if (mes != 0)
                    {
                        cmd.Parameters.AddWithValue("@ANIO", anio);
                        cmd.Parameters.AddWithValue("@MES", mes);
                    }
                    else
                        cmd.Parameters.AddWithValue("@ANIO", anio);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            obj = new INFORME_TRANSACCIONES();
                            if (!dr.IsDBNull(0)) { obj.NRO_CTA = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.CANT_MOV = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.MONTO = dr.GetDecimal(2); }

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
        public static List<INFORME_TRANSACCIONES> getRecibo(int nroCta)
        {
            try
            {
                INFORME_TRANSACCIONES obj;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT DISTINCT A.FECHA, A.ID_FACTURA,  A.MONTO,");
                sql.AppendLine("(SELECT NRO_CTA FROM CTACTE_EXPENSAS X WHERE");
                sql.AppendLine("A.ID_FACTURA=X.NRO_RECIBO_PAGO GROUP BY NRO_CTA) AS NRO_CTA");
                sql.AppendLine("FROM PAGOS_X_FACTURA A");
                sql.AppendLine("INNER JOIN CTACTE_EXPENSAS D ON A.ID_FACTURA=D.NRO_RECIBO_PAGO");
                sql.AppendLine("WHERE D.NRO_CTA = @NRO_CTA AND A.ID_PLAN_PAGO=8");
                sql.AppendLine("ORDER BY ID_FACTURA DESC");

                List<INFORME_TRANSACCIONES> lst = new List<INFORME_TRANSACCIONES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            obj = new INFORME_TRANSACCIONES();
                            if (!dr.IsDBNull(0)) { obj.FECHA = dr.GetDateTime(0); }
                            if (!dr.IsDBNull(dr.GetOrdinal("ID_FACTURA")))
                            {
                                obj.NRO_RECIBO_PAGO = dr.GetInt64(dr.GetOrdinal("ID_FACTURA"));
                            }
                            if (!dr.IsDBNull(2)) { obj.MONTO = dr.GetDecimal(2); }
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
    }
}
