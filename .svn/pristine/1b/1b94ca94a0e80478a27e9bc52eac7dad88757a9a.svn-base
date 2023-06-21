using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class INF_GASTOS:DALBase
    {
        public int ID { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string NOMBRE_FANTASIA { get; set; }
        public string FACTURA { get; set; }
        public string DETALLE_FACTURA { get; set; }
        public decimal MONTO_ORIGINAL { get; set; }
        public decimal PAGO { get; set; }
        public decimal SALDO { get; set; }

        public INF_GASTOS()
        {
            ID = 0;
            RAZON_SOCIAL = string.Empty;
            NOMBRE_FANTASIA = string.Empty;
            FACTURA = string.Empty;
            DETALLE_FACTURA = string.Empty;
            MONTO_ORIGINAL = 0;
            PAGO = 0;
            SALDO = 0;
        }
        public static List<INF_GASTOS> read()
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("SELECT A.ID, B.RAZON_SOCIAL, B.NOMBRE_FANTASIA,");
                    sql.AppendLine("RIGHT('0000' + Ltrim(Rtrim(A.PTO_VTA)),4) + '-' +");
                    sql.AppendLine("RIGHT('00000000' + Ltrim(Rtrim(A.NRO_CTE)),8) AS FACTURA,");
                    sql.AppendLine("A.OBS, A.MONTO_ORIGINAL, A.PAGO_A_CTA, A.SALDO");
                    sql.AppendLine("FROM CTACTE_GASTOS A");
                    sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROVEEDOR=B.ID");
                    sql.AppendLine("WHERE A.TIPO_MOVIMIENTO=1 AND PAGADO = 0");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<INF_GASTOS> lst = new List<INF_GASTOS>();
                    INF_GASTOS obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new INF_GASTOS();
                            if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.RAZON_SOCIAL = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.NOMBRE_FANTASIA = dr.GetString(2); }
                            if (!dr.IsDBNull(3)) { obj.FACTURA = dr.GetString(3); }
                            if (!dr.IsDBNull(4)) { obj.DETALLE_FACTURA = dr.GetString(4); }
                            if (!dr.IsDBNull(5)) { obj.MONTO_ORIGINAL = dr.GetDecimal(5); }
                            if (!dr.IsDBNull(6)) { obj.PAGO = dr.GetDecimal(6); }
                            if (!dr.IsDBNull(7)) { obj.SALDO = dr.GetDecimal(7); }
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
        public static List<INF_GASTOS> readResumen()
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("SELECT A.ID, B.RAZON_SOCIAL, B.NOMBRE_FANTASIA,");
                    sql.AppendLine("SUM(A.MONTO_ORIGINAL), SUM(A.PAGO_A_CTA), SUM(A.SALDO)");
                    sql.AppendLine("FROM CTACTE_GASTOS A");
                    sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROVEEDOR=B.ID");
                    sql.AppendLine("WHERE A.TIPO_MOVIMIENTO=1 AND PAGADO = 0");
                    sql.AppendLine("GROUP BY A.ID, B.RAZON_SOCIAL, B.NOMBRE_FANTASIA");

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<INF_GASTOS> lst = new List<INF_GASTOS>();
                    INF_GASTOS obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new INF_GASTOS();
                            if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.RAZON_SOCIAL = dr.GetString(1); }
                            if (!dr.IsDBNull(2)) { obj.NOMBRE_FANTASIA = dr.GetString(2); }
                            if (!dr.IsDBNull(3)) { obj.MONTO_ORIGINAL = dr.GetDecimal(3); }
                            if (!dr.IsDBNull(4)) { obj.PAGO = dr.GetDecimal(4); }
                            if (!dr.IsDBNull(5)) { obj.SALDO = dr.GetDecimal(5); }
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
        /* */
    }
}
