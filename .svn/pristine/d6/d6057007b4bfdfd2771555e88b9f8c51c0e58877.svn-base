using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class VISTA_FACTURAS : DALBase
    {
        public int ID { get; set; }
        public DateTime FECHA { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string NOMBRE_FANTASIA { get; set; }
        public string FACTURA { get; set; }
        public string CONCEPTO { get; set; }
        public decimal MONTO { get; set; }
        public int ID_PLAN_CUENTA { get; set; }
        public string CUENTA_PASIVO { get; set; }
        public string CUENTA_GASTO { get; set; }
        public int NRO_ORDEN_PAGO { get; set; }
        public bool PAGADO { get; set; }
        public decimal SALDO { get; set; }
        public string DESCRIPCION { get; set; }

        public VISTA_FACTURAS()
        {
            ID = 0;
            FECHA = UTILS.getFechaActual();
            RAZON_SOCIAL = string.Empty;
            NOMBRE_FANTASIA = string.Empty;
            FACTURA = string.Empty;
            CONCEPTO = string.Empty;
            MONTO = 0;
            ID_PLAN_CUENTA = 0;
            CUENTA_PASIVO = string.Empty;
            CUENTA_GASTO = string.Empty;
            NRO_ORDEN_PAGO = 0;
            PAGADO = false;
            SALDO = 0;
            DESCRIPCION = string.Empty;
        }

        private static List<VISTA_FACTURAS> mapeo(SqlDataReader dr)
        {
            List<VISTA_FACTURAS> lst = new List<VISTA_FACTURAS>();
            VISTA_FACTURAS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new VISTA_FACTURAS();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.FECHA = dr.GetDateTime(1); }
                    if (!dr.IsDBNull(2)) { obj.RAZON_SOCIAL = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.NOMBRE_FANTASIA = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.FACTURA = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.CONCEPTO = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.MONTO = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.ID_PLAN_CUENTA = dr.GetInt32(7); }
                    if (!dr.IsDBNull(8)) { obj.CUENTA_PASIVO = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.CUENTA_GASTO = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.NRO_ORDEN_PAGO = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.PAGADO = dr.GetBoolean(11); }
                    if (!dr.IsDBNull(12)) { obj.SALDO = dr.GetDecimal(12); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        private static List<VISTA_FACTURAS> mapeo2(SqlDataReader dr)
        {
            List<VISTA_FACTURAS> lst = new List<VISTA_FACTURAS>();
            VISTA_FACTURAS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new VISTA_FACTURAS();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.FECHA = dr.GetDateTime(1); }
                    if (!dr.IsDBNull(2)) { obj.RAZON_SOCIAL = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.NOMBRE_FANTASIA = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.FACTURA = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.CONCEPTO = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.MONTO = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.ID_PLAN_CUENTA = dr.GetInt32(7); }
                    if (!dr.IsDBNull(8)) { obj.CUENTA_PASIVO = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.CUENTA_GASTO = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.NRO_ORDEN_PAGO = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.PAGADO = dr.GetBoolean(11); }
                    if (!dr.IsDBNull(12)) { obj.SALDO = dr.GetDecimal(12); }
                    if (!dr.IsDBNull(13)) { obj.DESCRIPCION = dr.GetString(13); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        private static List<VISTA_FACTURAS> mapeo3(SqlDataReader dr)
        {
            List<VISTA_FACTURAS> lst = new List<VISTA_FACTURAS>();
            VISTA_FACTURAS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new VISTA_FACTURAS();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.FECHA = dr.GetDateTime(1); }
                    if (!dr.IsDBNull(2)) { obj.RAZON_SOCIAL = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.NOMBRE_FANTASIA = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.DESCRIPCION = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.MONTO = dr.GetDecimal(5); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<VISTA_FACTURAS> read()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID, A.FECHA_CAE, B.RAZON_SOCIAL, B.NOMBRE_FANTASIA,");
                sql.AppendLine("RIGHT('0000'+CAST(A.PTO_VTA AS VARCHAR(4)),4) + '-' +");
                sql.AppendLine("RIGHT('0000000000'+CAST(A.NRO_CTE AS VARCHAR(10)),10) AS FACTURA,");
                sql.AppendLine("A.OBS AS CONCEPTO, A.MONTO_ORIGINAL AS MONTO, A.ID_PLAN_CUENTA,");
                sql.AppendLine("E.DESC_SUBCUENTA AS 'CUENTA PASIVO',");
                sql.AppendLine("D.DESC_SUBCUENTA AS 'CUENTA GASTO', ");
                sql.AppendLine("G.NRO AS 'NRO. ORDEN PAGO',");
                sql.AppendLine("A.PAGADO, ");
                sql.AppendLine("A.SALDO ");
                sql.AppendLine("FROM CTACTE_GASTOS A");
                sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROVEEDOR=B.ID");
                sql.AppendLine("FULL JOIN CUENTAS_X_PROVEEDOR C ON A.ID_PLAN_CUENTA=C.ID_CTA_CONTABLE_GASTO AND A.ID_PROVEEDOR=C.ID_PROV");
                sql.AppendLine("FULL JOIN PLAN_CUENTA D ON C.ID_CTA_CONTABLE_GASTO=D.ID");
                sql.AppendLine("FULL JOIN PLAN_CUENTA E ON C.ID_CTA_CONTABLE_PASIVO=E.ID");
                sql.AppendLine("FULL JOIN FACTURAS_X_OP F ON A.ID=F.ID_FACTURA");
                sql.AppendLine("FULL JOIN ORDENES_PAGO G ON F.ID_OP = G.ID");
                sql.AppendLine("WHERE A.TIPO_MOVIMIENTO = 1 ");
                sql.AppendLine("ORDER BY F.ID_OP");
                List<VISTA_FACTURAS> lst = new List<VISTA_FACTURAS>();
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
        public static List<VISTA_FACTURAS> readPagos(int anio)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID, A.FECHA,");
                sql.AppendLine("(SELECT RAZON_SOCIAL FROM PROVEEDORES");
                sql.AppendLine("WHERE ID IN (SELECT ID_PROVEEDOR FROM CTACTE_GASTOS");
                sql.AppendLine("WHERE NRO_RECIBO_PAGO=A.ID_FACTURA GROUP BY ID_PROVEEDOR))");
                sql.AppendLine("AS RAZON_SOCIAL,");
                sql.AppendLine("(SELECT NOMBRE_FANTASIA FROM PROVEEDORES");
                sql.AppendLine("WHERE ID IN (SELECT ID_PROVEEDOR FROM CTACTE_GASTOS");
                sql.AppendLine("WHERE NRO_RECIBO_PAGO=A.ID_FACTURA GROUP BY ID_PROVEEDOR))");
                sql.AppendLine("AS NOMBRE_FANTASIA, B.DESCRIPCION, A.MONTO");
                sql.AppendLine("FROM PAGOS_X_FACTURA_GASTOS A");
                sql.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_PLAN_PAGO=B.ID");
                sql.AppendLine("WHERE YEAR(A.FECHA)=@ANIO");
                //sql.AppendLine("SELECT A.ID, A.FECHA, B.RAZON_SOCIAL, B.NOMBRE_FANTASIA,");
                //sql.AppendLine("RIGHT('0000'+CAST(A.PTO_VTA AS VARCHAR(4)),4) + '-' +");
                //sql.AppendLine("RIGHT('0000000000'+CAST(A.NRO_CTE AS VARCHAR(10)),10) AS FACTURA,");
                //sql.AppendLine("A.OBS AS CONCEPTO, A.HABER AS MONTO, A.ID_PLAN_CUENTA,");
                //sql.AppendLine("E.DESC_SUBCUENTA AS 'CUENTA PASIVO',");
                //sql.AppendLine("D.DESC_SUBCUENTA AS 'CUENTA GASTO',");
                //sql.AppendLine("G.NRO AS 'NRO. ORDEN PAGO',");
                //sql.AppendLine("A.PAGADO, A.SALDO , H.DESCRIPCION");
                //sql.AppendLine("FROM CTACTE_GASTOS A");
                //sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROVEEDOR=B.ID");
                //sql.AppendLine("FULL JOIN CUENTAS_X_PROVEEDOR C ON A.ID_PLAN_CUENTA=");
                //sql.AppendLine("C.ID_CTA_CONTABLE_GASTO AND A.ID_PROVEEDOR=C.ID_PROV");
                //sql.AppendLine("FULL JOIN PLAN_CUENTA D ON C.ID_CTA_CONTABLE_GASTO=D.ID");
                //sql.AppendLine("FULL JOIN PLAN_CUENTA E ON C.ID_CTA_CONTABLE_PASIVO=E.ID");
                //sql.AppendLine("INNER JOIN FACTURAS_X_OP F ON F.ID_FACTURA=");
                //sql.AppendLine("(SELECT ID FROM CTACTE_GASTOS X WHERE A.ID_PROVEEDOR=X.ID_PROVEEDOR AND");
                //sql.AppendLine("A.PTO_VTA=X.PTO_VTA AND A.NRO_CTE=X.NRO_CTE AND X.TIPO_MOVIMIENTO=1)");
                //sql.AppendLine("FULL JOIN ORDENES_PAGO G ON F.ID_OP = G.ID");
                //sql.AppendLine("INNER JOIN MEDIOS_PAGO H ON A.ID_MEDIO_PAGO=H.ID");
                //sql.AppendLine("WHERE A.TIPO_MOVIMIENTO = 2");
                List<VISTA_FACTURAS> lst = new List<VISTA_FACTURAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ANIO", anio);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo3(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<VISTA_FACTURAS> readPasivo(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID, A.FECHA, B.RAZON_SOCIAL, B.NOMBRE_FANTASIA,");
                sql.AppendLine("RIGHT('0000'+CAST(A.PTO_VTA AS VARCHAR(4)),4) + '-' +");
                sql.AppendLine("RIGHT('0000000000'+CAST(A.NRO_CTE AS VARCHAR(10)),10) AS FACTURA,");
                sql.AppendLine("A.OBS AS CONCEPTO, A.MONTO_ORIGINAL AS MONTO, A.ID_PLAN_CUENTA,");
                sql.AppendLine("E.DESC_SUBCUENTA AS 'CUENTA PASIVO',");
                sql.AppendLine("D.DESC_SUBCUENTA AS 'CUENTA GASTO', ");
                sql.AppendLine("G.NRO AS 'NRO. ORDEN PAGO',");
                sql.AppendLine("A.PAGADO, ");
                sql.AppendLine("A.SALDO ");
                sql.AppendLine("FROM CTACTE_GASTOS A");
                sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROVEEDOR=B.ID");
                sql.AppendLine("FULL JOIN CUENTAS_X_PROVEEDOR C ON A.ID_PLAN_CUENTA=C.ID_CTA_CONTABLE_GASTO AND A.ID_PROVEEDOR=C.ID_PROV");
                sql.AppendLine("FULL JOIN PLAN_CUENTA D ON C.ID_CTA_CONTABLE_GASTO=D.ID");
                sql.AppendLine("FULL JOIN PLAN_CUENTA E ON C.ID_CTA_CONTABLE_PASIVO=E.ID");
                sql.AppendLine("FULL JOIN FACTURAS_X_OP F ON A.ID=F.ID_FACTURA");
                sql.AppendLine("FULL JOIN ORDENES_PAGO G ON F.ID_OP = G.ID");
                sql.AppendLine("WHERE A.TIPO_MOVIMIENTO = 1 AND D.ID = @ID");
                sql.AppendLine("ORDER BY F.ID_OP");
                List<VISTA_FACTURAS> lst = new List<VISTA_FACTURAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
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
        public static List<VISTA_FACTURAS> readGastos(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID, A.FECHA, B.RAZON_SOCIAL, B.NOMBRE_FANTASIA,");
                sql.AppendLine("RIGHT('0000'+CAST(A.PTO_VTA AS VARCHAR(4)),4) + '-' +");
                sql.AppendLine("RIGHT('0000000000'+CAST(A.NRO_CTE AS VARCHAR(10)),10) AS FACTURA,");
                sql.AppendLine("A.OBS AS CONCEPTO, A.MONTO_ORIGINAL AS MONTO, A.ID_PLAN_CUENTA,");
                sql.AppendLine("E.DESC_SUBCUENTA AS 'CUENTA PASIVO',");
                sql.AppendLine("D.DESC_SUBCUENTA AS 'CUENTA GASTO', ");
                sql.AppendLine("G.NRO AS 'NRO. ORDEN PAGO',");
                sql.AppendLine("A.PAGADO, ");
                sql.AppendLine("A.SALDO ");
                sql.AppendLine("FROM CTACTE_GASTOS A");
                sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROVEEDOR=B.ID");
                sql.AppendLine("FULL JOIN CUENTAS_X_PROVEEDOR C ON A.ID_PLAN_CUENTA=C.ID_CTA_CONTABLE_GASTO AND A.ID_PROVEEDOR=C.ID_PROV");
                sql.AppendLine("FULL JOIN PLAN_CUENTA D ON C.ID_CTA_CONTABLE_GASTO=D.ID");
                sql.AppendLine("FULL JOIN PLAN_CUENTA E ON C.ID_CTA_CONTABLE_PASIVO=E.ID");
                sql.AppendLine("FULL JOIN FACTURAS_X_OP F ON A.ID=F.ID_FACTURA");
                sql.AppendLine("FULL JOIN ORDENES_PAGO G ON F.ID_OP = G.ID");
                sql.AppendLine("WHERE A.TIPO_MOVIMIENTO = 1 AND E.ID = @ID");
                sql.AppendLine("ORDER BY F.ID_OP");
                List<VISTA_FACTURAS> lst = new List<VISTA_FACTURAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
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
        public static List<VISTA_FACTURAS> read(int anio, int mes)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID, A.FECHA_CAE, B.RAZON_SOCIAL, B.NOMBRE_FANTASIA,");
                sql.AppendLine("RIGHT('0000'+CAST(A.PTO_VTA AS VARCHAR(4)),4) + '-' +");
                sql.AppendLine("RIGHT('0000000000'+CAST(A.NRO_CTE AS VARCHAR(10)),10) AS FACTURA,");
                sql.AppendLine("A.OBS AS CONCEPTO, A.MONTO_ORIGINAL AS MONTO, A.ID_PLAN_CUENTA,");
                sql.AppendLine("E.DESC_SUBCUENTA AS 'CUENTA PASIVO',");
                sql.AppendLine("D.DESC_SUBCUENTA AS 'CUENTA GASTO', ");
                sql.AppendLine("G.NRO AS 'NRO. ORDEN PAGO',");
                sql.AppendLine("A.PAGADO, ");
                sql.AppendLine("A.SALDO ");
                sql.AppendLine("FROM CTACTE_GASTOS A");
                sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROVEEDOR=B.ID");
                sql.AppendLine("FULL JOIN CUENTAS_X_PROVEEDOR C ON A.ID_PLAN_CUENTA=C.ID_CTA_CONTABLE_GASTO AND A.ID_PROVEEDOR=C.ID_PROV");
                sql.AppendLine("FULL JOIN PLAN_CUENTA D ON C.ID_CTA_CONTABLE_GASTO=D.ID");
                sql.AppendLine("FULL JOIN PLAN_CUENTA E ON C.ID_CTA_CONTABLE_PASIVO=E.ID");
                sql.AppendLine("FULL JOIN FACTURAS_X_OP F ON A.ID=F.ID_FACTURA");
                sql.AppendLine("FULL JOIN ORDENES_PAGO G ON F.ID_OP = G.ID");
                if (mes != 0)
                    sql.AppendLine("WHERE A.TIPO_MOVIMIENTO = 1 AND YEAR(A.FECHA) = @ANIO AND MONTH(A.FECHA) = @MES");
                else
                    sql.AppendLine("WHERE A.TIPO_MOVIMIENTO = 1 AND YEAR(A.FECHA) = @ANIO");
                sql.AppendLine("ORDER BY F.ID_OP");
                List<VISTA_FACTURAS> lst = new List<VISTA_FACTURAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ANIO", anio);
                    if (mes != 0)
                        cmd.Parameters.AddWithValue("@MES", mes);
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
        public static List<VISTA_FACTURAS> readPagos(int anio, int mes)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID, A.FECHA,");
                sql.AppendLine("(SELECT RAZON_SOCIAL FROM PROVEEDORES");
                sql.AppendLine("WHERE ID IN (SELECT ID_PROVEEDOR FROM CTACTE_GASTOS");
                sql.AppendLine("WHERE NRO_RECIBO_PAGO=A.ID_FACTURA GROUP BY ID_PROVEEDOR))");
                sql.AppendLine("AS RAZON_SOCIAL,");
                sql.AppendLine("(SELECT NOMBRE_FANTASIA FROM PROVEEDORES");
                sql.AppendLine("WHERE ID IN (SELECT ID_PROVEEDOR FROM CTACTE_GASTOS");
                sql.AppendLine("WHERE NRO_RECIBO_PAGO=A.ID_FACTURA GROUP BY ID_PROVEEDOR))");
                sql.AppendLine("AS NOMBRE_FANTASIA, B.DESCRIPCION, A.MONTO");
                sql.AppendLine("FROM PAGOS_X_FACTURA_GASTOS A");
                sql.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_PLAN_PAGO=B.ID");
                sql.AppendLine("WHERE YEAR(A.FECHA)=@ANIO AND MONTH(A.FECHA)=@MES");

                //sql.AppendLine("SELECT A.ID, A.FECHA, B.RAZON_SOCIAL, B.NOMBRE_FANTASIA,");
                //sql.AppendLine("RIGHT('0000'+CAST(A.PTO_VTA AS VARCHAR(4)),4) + '-' +");
                //sql.AppendLine("RIGHT('0000000000'+CAST(A.NRO_CTE AS VARCHAR(10)),10) AS FACTURA,");
                //sql.AppendLine("A.OBS AS CONCEPTO, A.HABER AS MONTO, A.ID_PLAN_CUENTA,");
                //sql.AppendLine("E.DESC_SUBCUENTA AS 'CUENTA PASIVO',");
                //sql.AppendLine("D.DESC_SUBCUENTA AS 'CUENTA GASTO',");
                //sql.AppendLine("G.NRO AS 'NRO. ORDEN PAGO',");
                //sql.AppendLine("A.PAGADO, A.SALDO , H.DESCRIPCION");
                //sql.AppendLine("FROM CTACTE_GASTOS A");
                //sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROVEEDOR=B.ID");
                //sql.AppendLine("FULL JOIN CUENTAS_X_PROVEEDOR C ON A.ID_PLAN_CUENTA=");
                //sql.AppendLine("C.ID_CTA_CONTABLE_GASTO AND A.ID_PROVEEDOR=C.ID_PROV");
                //sql.AppendLine("FULL JOIN PLAN_CUENTA D ON C.ID_CTA_CONTABLE_GASTO=D.ID");
                //sql.AppendLine("FULL JOIN PLAN_CUENTA E ON C.ID_CTA_CONTABLE_PASIVO=E.ID");
                //sql.AppendLine("INNER JOIN FACTURAS_X_OP F ON F.ID_FACTURA=");
                //sql.AppendLine("(SELECT ID FROM CTACTE_GASTOS X WHERE A.ID_PROVEEDOR=X.ID_PROVEEDOR AND");
                //sql.AppendLine("A.PTO_VTA=X.PTO_VTA AND A.NRO_CTE=X.NRO_CTE AND X.TIPO_MOVIMIENTO=1)");
                //sql.AppendLine("FULL JOIN ORDENES_PAGO G ON F.ID_OP = G.ID");
                //sql.AppendLine("INNER JOIN MEDIOS_PAGO H ON A.ID_MEDIO_PAGO=H.ID");
                //sql.AppendLine("WHERE A.TIPO_MOVIMIENTO = 2 AND YEAR(A.FECHA) = @ANIO AND MONTH(A.FECHA) = @MES");

                List<VISTA_FACTURAS> lst = new List<VISTA_FACTURAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ANIO", anio);
                    cmd.Parameters.AddWithValue("@MES", mes);
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo3(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static VISTA_FACTURAS getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM VISTA_FACTURAS WHERE");
                VISTA_FACTURAS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<VISTA_FACTURAS> lst = mapeo(dr);
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

        public static int insert(VISTA_FACTURAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO VISTA_FACTURAS(");
                sql.AppendLine("ID");
                sql.AppendLine(", FECHA");
                sql.AppendLine(", RAZON_SOCIAL");
                sql.AppendLine(", NOMBRE_FANTASIA");
                sql.AppendLine(", FACTURA");
                sql.AppendLine(", CONCEPTO");
                sql.AppendLine(", MONTO");
                sql.AppendLine(", ID_PLAN_CUENTA");
                sql.AppendLine(", CUENTA_PASIVO");
                sql.AppendLine(", CUENTA_GASTO");
                sql.AppendLine(", NRO_ORDEN_PAGO");
                sql.AppendLine(", PAGADO");
                sql.AppendLine(", SALDO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID");
                sql.AppendLine(", @FECHA");
                sql.AppendLine(", @RAZON_SOCIAL");
                sql.AppendLine(", @NOMBRE_FANTASIA");
                sql.AppendLine(", @FACTURA");
                sql.AppendLine(", @CONCEPTO");
                sql.AppendLine(", @MONTO");
                sql.AppendLine(", @ID_PLAN_CUENTA");
                sql.AppendLine(", @CUENTA_PASIVO");
                sql.AppendLine(", @CUENTA_GASTO");
                sql.AppendLine(", @NRO_ORDEN_PAGO");
                sql.AppendLine(", @PAGADO");
                sql.AppendLine(", @SALDO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", obj.RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("@NOMBRE_FANTASIA", obj.NOMBRE_FANTASIA);
                    cmd.Parameters.AddWithValue("@FACTURA", obj.FACTURA);
                    cmd.Parameters.AddWithValue("@CONCEPTO", obj.CONCEPTO);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Parameters.AddWithValue("@ID_PLAN_CUENTA", obj.ID_PLAN_CUENTA);
                    cmd.Parameters.AddWithValue("@CUENTA_PASIVO", obj.CUENTA_PASIVO);
                    cmd.Parameters.AddWithValue("@CUENTA_GASTO", obj.CUENTA_GASTO);
                    cmd.Parameters.AddWithValue("@NRO_ORDEN_PAGO", obj.NRO_ORDEN_PAGO);
                    cmd.Parameters.AddWithValue("@PAGADO", obj.PAGADO);
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

        public static void update(VISTA_FACTURAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  VISTA_FACTURAS SET");
                sql.AppendLine("ID=@ID");
                sql.AppendLine(", FECHA=@FECHA");
                sql.AppendLine(", RAZON_SOCIAL=@RAZON_SOCIAL");
                sql.AppendLine(", NOMBRE_FANTASIA=@NOMBRE_FANTASIA");
                sql.AppendLine(", FACTURA=@FACTURA");
                sql.AppendLine(", CONCEPTO=@CONCEPTO");
                sql.AppendLine(", MONTO=@MONTO");
                sql.AppendLine(", ID_PLAN_CUENTA=@ID_PLAN_CUENTA");
                sql.AppendLine(", CUENTA_PASIVO=@CUENTA_PASIVO");
                sql.AppendLine(", CUENTA_GASTO=@CUENTA_GASTO");
                sql.AppendLine(", NRO_ORDEN_PAGO=@NRO_ORDEN_PAGO");
                sql.AppendLine(", PAGADO=@PAGADO");
                sql.AppendLine(", SALDO=@SALDO");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", obj.RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("@NOMBRE_FANTASIA", obj.NOMBRE_FANTASIA);
                    cmd.Parameters.AddWithValue("@FACTURA", obj.FACTURA);
                    cmd.Parameters.AddWithValue("@CONCEPTO", obj.CONCEPTO);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Parameters.AddWithValue("@ID_PLAN_CUENTA", obj.ID_PLAN_CUENTA);
                    cmd.Parameters.AddWithValue("@CUENTA_PASIVO", obj.CUENTA_PASIVO);
                    cmd.Parameters.AddWithValue("@CUENTA_GASTO", obj.CUENTA_GASTO);
                    cmd.Parameters.AddWithValue("@NRO_ORDEN_PAGO", obj.NRO_ORDEN_PAGO);
                    cmd.Parameters.AddWithValue("@PAGADO", obj.PAGADO);
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

        public static void delete(VISTA_FACTURAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  VISTA_FACTURAS ");
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

