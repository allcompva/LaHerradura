using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class VISTA_PAGO_PROVEEDORES : DALBase
    {
        public int EJERCICIO { get; set; }
        public int ORDEN_PEDIDO { get; set; }
        public DateTime FECHA_ORDEN { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string FACTURA { get; set; }
        public string CONCEPTO { get; set; }
        public decimal MONTO_ORIGINAL { get; set; }
        public DateTime FECHA_PAGO { get; set; }
        public string MEDIO_PAGO { get; set; }
        public decimal MONTO_PAGADO { get; set; }
        public int ID_OP { get; set; }

        public VISTA_PAGO_PROVEEDORES()
        {
            EJERCICIO = 0;
            ORDEN_PEDIDO = 0;
            FECHA_ORDEN = UTILS.getFechaActual();
            RAZON_SOCIAL = string.Empty;
            FACTURA = String.Empty;
            CONCEPTO = string.Empty;
            MONTO_ORIGINAL = 0;
            FECHA_PAGO = UTILS.getFechaActual();
            MEDIO_PAGO = string.Empty;
            MONTO_PAGADO = 0;
            ID_OP = 0;
        }

        private static List<VISTA_PAGO_PROVEEDORES> mapeo(SqlDataReader dr)
        {
            List<VISTA_PAGO_PROVEEDORES> lst = new List<VISTA_PAGO_PROVEEDORES>();
            VISTA_PAGO_PROVEEDORES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new VISTA_PAGO_PROVEEDORES();
                    if (!dr.IsDBNull(0)) { obj.EJERCICIO = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.ORDEN_PEDIDO = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.FECHA_ORDEN = dr.GetDateTime(2); }
                    if (!dr.IsDBNull(3)) { obj.RAZON_SOCIAL = dr.GetString(3); }
                    //if (!dr.IsDBNull(4)) { obj.FACTURA = dr.GetString(4); }
                    //if (!dr.IsDBNull(5)) { obj.CONCEPTO = dr.GetString(5); }
                    if (!dr.IsDBNull(4)) { obj.MONTO_ORIGINAL = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.ID_OP = dr.GetInt32(5); }

                    //if (!dr.IsDBNull(7)) { obj.FECHA_PAGO = dr.GetDateTime(7); }
                    //if (!dr.IsDBNull(8)) { obj.MEDIO_PAGO = dr.GetString(8); }
                    //if (!dr.IsDBNull(9)) { obj.MONTO_PAGADO = dr.GetDecimal(9); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<VISTA_PAGO_PROVEEDORES> read()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT YEAR(A.FECHA) AS EJERCICIO, A.NRO AS ORDEN_PEDIDO,");
                sql.AppendLine("A.FECHA AS FECHA_ORDEN, B.RAZON_SOCIAL, A.DEBE AS MONTO_ORIGINAL");
                sql.AppendLine(", A.ID");
                sql.AppendLine("FROM ORDENES_PAGO A");
                sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROV=B.ID");
                sql.AppendLine("WHERE ESTADO=2");
                sql.AppendLine("ORDER BY A.FECHA DESC, A.NRO");
                //sql.AppendLine("SELECT YEAR(F.FECHA) AS EJERCICIO, F.NRO AS ORDEN_PEDIDO, F.FECHA AS FECHA_ORDEN,");
                //sql.AppendLine("G.RAZON_SOCIAL,");
                //sql.AppendLine("RIGHT('0000' + Ltrim(Rtrim(C.PTO_VTA)),4) + '-' +");
                //sql.AppendLine("RIGHT('0000000000' + Ltrim(Rtrim(C.NRO_CTE)),10) AS FACTURA,");
                //sql.AppendLine("C.OBS AS CONCEPTO, C.MONTO_ORIGINAL, A.FECHA AS FECHA_PAGO,");
                //sql.AppendLine("H.DESCRIPCION AS MEDIO_PAGO, A.MONTO AS MONTO_PAGADO");
                //sql.AppendLine("FROM PAGOS_X_FACTURA_GASTOS A");
                //sql.AppendLine("INNER JOIN CTACTE_GASTOS B ON A.ID_FACTURA=B.NRO_RECIBO_PAGO");
                //sql.AppendLine("INNER JOIN CTACTE_GASTOS C ON B.ID_PROVEEDOR=C.ID_PROVEEDOR AND B.PTO_VTA=C.PTO_VTA");
                //sql.AppendLine("AND B.NRO_CTE=C.NRO_CTE AND C.TIPO_MOVIMIENTO=1");
                //sql.AppendLine("LEFT JOIN FACTURAS_X_OP E ON C.ID=E.ID_FACTURA");
                //sql.AppendLine("INNER JOIN ORDENES_PAGO F ON E.ID_OP=F.ID");
                //sql.AppendLine("INNER JOIN PROVEEDORES G ON B.ID_PROVEEDOR=G.ID");
                //sql.AppendLine("INNER JOIN MEDIOS_PAGO H ON A.ID_PLAN_PAGO=H.ID");
                //sql.AppendLine("WHERE F.ESTADO=2");
                //sql.AppendLine("ORDER BY YEAR(A.FECHA), F.NRO");
                sql.AppendLine("");
                List<VISTA_PAGO_PROVEEDORES> lst = new List<VISTA_PAGO_PROVEEDORES>();
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
        public static List<VISTA_PAGO_PROVEEDORES> read(int anio, int mes)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT YEAR(A.FECHA) AS EJERCICIO, A.NRO AS ORDEN_PEDIDO,");
                sql.AppendLine("A.FECHA AS FECHA_ORDEN, B.RAZON_SOCIAL, A.DEBE AS MONTO_ORIGINAL");
                sql.AppendLine(", A.ID");
                sql.AppendLine("FROM ORDENES_PAGO A");
                sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROV=B.ID");
                sql.AppendLine("WHERE ESTADO=2 AND YEAR(A.FECHA)=@ANIO AND MONTH(A.FECHA)=@MES");
                sql.AppendLine("ORDER BY A.FECHA DESC, A.NRO");
                //sql.AppendLine("SELECT YEAR(F.FECHA) AS EJERCICIO, F.NRO AS ORDEN_PEDIDO, F.FECHA AS FECHA_ORDEN,");
                //sql.AppendLine("G.RAZON_SOCIAL,");
                //sql.AppendLine("RIGHT('0000' + Ltrim(Rtrim(C.PTO_VTA)),4) + '-' +");
                //sql.AppendLine("RIGHT('0000000000' + Ltrim(Rtrim(C.NRO_CTE)),10) AS FACTURA,");
                //sql.AppendLine("C.OBS AS CONCEPTO, C.MONTO_ORIGINAL, A.FECHA AS FECHA_PAGO,");
                //sql.AppendLine("H.DESCRIPCION AS MEDIO_PAGO, A.MONTO AS MONTO_PAGADO");
                //sql.AppendLine("FROM PAGOS_X_FACTURA_GASTOS A");
                //sql.AppendLine("INNER JOIN CTACTE_GASTOS B ON A.ID_FACTURA=B.NRO_RECIBO_PAGO");
                //sql.AppendLine("INNER JOIN CTACTE_GASTOS C ON B.ID_PROVEEDOR=C.ID_PROVEEDOR AND B.PTO_VTA=C.PTO_VTA");
                //sql.AppendLine("AND B.NRO_CTE=C.NRO_CTE AND C.TIPO_MOVIMIENTO=1");
                //sql.AppendLine("LEFT JOIN FACTURAS_X_OP E ON C.ID=E.ID_FACTURA");
                //sql.AppendLine("INNER JOIN ORDENES_PAGO F ON E.ID_OP=F.ID");
                //sql.AppendLine("INNER JOIN PROVEEDORES G ON B.ID_PROVEEDOR=G.ID");
                //sql.AppendLine("INNER JOIN MEDIOS_PAGO H ON A.ID_PLAN_PAGO=H.ID");
                //sql.AppendLine("WHERE F.ESTADO=2 AND YEAR(A.FECHA)=@ANIO AND MONTH(A.FECHA)=@MES");
                //sql.AppendLine("ORDER BY YEAR(A.FECHA), F.NRO");
                List<VISTA_PAGO_PROVEEDORES> lst = new List<VISTA_PAGO_PROVEEDORES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ANIO", anio);
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
        public static VISTA_PAGO_PROVEEDORES getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM VISTA_PAGO_PROVEEDORES WHERE");
                VISTA_PAGO_PROVEEDORES obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<VISTA_PAGO_PROVEEDORES> lst = mapeo(dr);
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

        public static int insert(VISTA_PAGO_PROVEEDORES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO VISTA_PAGO_PROVEEDORES(");
                sql.AppendLine("EJERCICIO");
                sql.AppendLine(", ORDEN_PEDIDO");
                sql.AppendLine(", FECHA_ORDEN");
                sql.AppendLine(", RAZON_SOCIAL");
                sql.AppendLine(", CONCEPTO");
                sql.AppendLine(", MONTO_ORIGINAL");
                sql.AppendLine(", FECHA_PAGO");
                sql.AppendLine(", MEDIO_PAGO");
                sql.AppendLine(", MONTO_PAGADO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@EJERCICIO");
                sql.AppendLine(", @ORDEN_PEDIDO");
                sql.AppendLine(", @FECHA_ORDEN");
                sql.AppendLine(", @RAZON_SOCIAL");
                sql.AppendLine(", @CONCEPTO");
                sql.AppendLine(", @MONTO_ORIGINAL");
                sql.AppendLine(", @FECHA_PAGO");
                sql.AppendLine(", @MEDIO_PAGO");
                sql.AppendLine(", @MONTO_PAGADO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@EJERCICIO", obj.EJERCICIO);
                    cmd.Parameters.AddWithValue("@ORDEN_PEDIDO", obj.ORDEN_PEDIDO);
                    cmd.Parameters.AddWithValue("@FECHA_ORDEN", obj.FECHA_ORDEN);
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", obj.RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("@CONCEPTO", obj.CONCEPTO);
                    cmd.Parameters.AddWithValue("@MONTO_ORIGINAL", obj.MONTO_ORIGINAL);
                    cmd.Parameters.AddWithValue("@FECHA_PAGO", obj.FECHA_PAGO);
                    cmd.Parameters.AddWithValue("@MEDIO_PAGO", obj.MEDIO_PAGO);
                    cmd.Parameters.AddWithValue("@MONTO_PAGADO", obj.MONTO_PAGADO);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(VISTA_PAGO_PROVEEDORES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  VISTA_PAGO_PROVEEDORES SET");
                sql.AppendLine("EJERCICIO=@EJERCICIO");
                sql.AppendLine(", ORDEN_PEDIDO=@ORDEN_PEDIDO");
                sql.AppendLine(", FECHA_ORDEN=@FECHA_ORDEN");
                sql.AppendLine(", RAZON_SOCIAL=@RAZON_SOCIAL");
                sql.AppendLine(", CONCEPTO=@CONCEPTO");
                sql.AppendLine(", MONTO_ORIGINAL=@MONTO_ORIGINAL");
                sql.AppendLine(", FECHA_PAGO=@FECHA_PAGO");
                sql.AppendLine(", MEDIO_PAGO=@MEDIO_PAGO");
                sql.AppendLine(", MONTO_PAGADO=@MONTO_PAGADO");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@EJERCICIO", obj.EJERCICIO);
                    cmd.Parameters.AddWithValue("@ORDEN_PEDIDO", obj.ORDEN_PEDIDO);
                    cmd.Parameters.AddWithValue("@FECHA_ORDEN", obj.FECHA_ORDEN);
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", obj.RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("@CONCEPTO", obj.CONCEPTO);
                    cmd.Parameters.AddWithValue("@MONTO_ORIGINAL", obj.MONTO_ORIGINAL);
                    cmd.Parameters.AddWithValue("@FECHA_PAGO", obj.FECHA_PAGO);
                    cmd.Parameters.AddWithValue("@MEDIO_PAGO", obj.MEDIO_PAGO);
                    cmd.Parameters.AddWithValue("@MONTO_PAGADO", obj.MONTO_PAGADO);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(VISTA_PAGO_PROVEEDORES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  VISTA_PAGO_PROVEEDORES ");
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

