using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class CTACTE_GASTOS : DALBase
    {
        public int ID { get; set; }
        public int ID_PROVEEDOR { get; set; }
        public int TIPO_MOVIMIENTO { get; set; }
        public decimal MONTO_ORIGINAL { get; set; }
        public decimal RECARGO { get; set; }
        public decimal DEBE { get; set; }
        public decimal HABER { get; set; }
        public decimal SALDO { get; set; }
        public int PTO_VTA { get; set; }
        public Int64 NRO_CTE { get; set; }
        public Int64 CAE { get; set; }
        public DateTime FECHA_CAE { get; set; }
        public DateTime VENC_CAE { get; set; }
        public DateTime FECHA { get; set; }
        public bool PAGADO { get; set; }
        public decimal DESCUENTO { get; set; }
        public decimal COSTO_FINANCIERO { get; set; }
        public DateTime VENCIMIENTO { get; set; }
        public int ID_MEDIO_PAGO { get; set; }
        public decimal INTERES_MORA { get; set; }
        public int NRO_RECIBO_PAGO { get; set; }
        public int DIAS_MORA { get; set; }
        public int NRO_RECIBO_PAYPERTIC { get; set; }
        public DateTime FECHA_ULTIMO_PAGO { get; set; }
        public decimal PAGO_A_CTA { get; set; }
        public decimal SALDO_CAPITAL { get; set; }
        public decimal SALDO_INTERES { get; set; }
        public decimal AJUSTE_INTERES { get; set; }
        public string OBS_AJUSTE { get; set; }
        public decimal CAPITAL_PAGADO { get; set; }
        public decimal INTERES_PAGADO { get; set; }
        public int NRO_PLAN_PAGO { get; set; }
        public int ESTADO { get; set; }
        public int NRO_CUOTA { get; set; }
        public int ID_USUARIO_PAGA { get; set; }
        public int ID_USUARIO_ANULA { get; set; }
        public string OBS { get; set; }
        public int ID_USUARIO_CARGA { get; set; }
        public int ID_PLAN_CUENTA { get; set; }
        public DateTime FECHA_CARGA { get; set; }
        public int TIPO_GASTO { get; set; }

        public string PROVEEDOR { get; set; }
        public string FACTURA { get; set; }

        public bool PAGO_TOTAL { get; set; }
        public decimal MONTO_PAGADO { get; set; }
        public CTACTE_GASTOS()
        {
            ID = 0;
            ID_PROVEEDOR = 0;
            TIPO_MOVIMIENTO = 0;
            MONTO_ORIGINAL = 0;
            RECARGO = 0;
            DEBE = 0;
            HABER = 0;
            SALDO = 0;
            PTO_VTA = 0;
            NRO_CTE = 0;
            CAE = 0;
            FECHA_CAE = UTILS.getFechaActual();
            VENC_CAE = UTILS.getFechaActual();
            FECHA = UTILS.getFechaActual();
            PAGADO = false;
            DESCUENTO = 0;
            COSTO_FINANCIERO = 0;
            VENCIMIENTO = UTILS.getFechaActual();
            ID_MEDIO_PAGO = 0;
            INTERES_MORA = 0;
            NRO_RECIBO_PAGO = 0;
            DIAS_MORA = 0;
            NRO_RECIBO_PAYPERTIC = 0;
            FECHA_ULTIMO_PAGO = UTILS.getFechaActual();
            PAGO_A_CTA = 0;
            SALDO_CAPITAL = 0;
            SALDO_INTERES = 0;
            AJUSTE_INTERES = 0;
            OBS_AJUSTE = string.Empty;
            CAPITAL_PAGADO = 0;
            INTERES_PAGADO = 0;
            NRO_PLAN_PAGO = 0;
            ESTADO = 0;
            NRO_CUOTA = 0;
            ID_USUARIO_PAGA = 0;
            ID_USUARIO_ANULA = 0;
            OBS = string.Empty;
            ID_USUARIO_CARGA = 0;
            ID_PLAN_CUENTA = 0;
            FECHA_CARGA = UTILS.getFechaActual();
            TIPO_GASTO = 0;
        }

        private static List<CTACTE_GASTOS> mapeo(SqlDataReader dr, int op)
        {
            List<CTACTE_GASTOS> lst = new List<CTACTE_GASTOS>();
            CTACTE_GASTOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new CTACTE_GASTOS();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.ID_PROVEEDOR = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.TIPO_MOVIMIENTO = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.MONTO_ORIGINAL = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.RECARGO = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.DEBE = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.HABER = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.SALDO = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.PTO_VTA = dr.GetInt32(8); }
                    if (!dr.IsDBNull(9)) { obj.NRO_CTE = dr.GetInt64(9); }
                    if (!dr.IsDBNull(10)) { obj.CAE = dr.GetInt64(10); }
                    if (!dr.IsDBNull(11)) { obj.FECHA_CAE = dr.GetDateTime(11); }
                    if (!dr.IsDBNull(12)) { obj.VENC_CAE = dr.GetDateTime(12); }
                    if (!dr.IsDBNull(13)) { obj.FECHA = dr.GetDateTime(13); }
                    if (!dr.IsDBNull(14)) { obj.PAGADO = dr.GetBoolean(14); }
                    if (!dr.IsDBNull(15)) { obj.DESCUENTO = dr.GetDecimal(15); }
                    if (!dr.IsDBNull(16)) { obj.COSTO_FINANCIERO = dr.GetDecimal(16); }
                    if (!dr.IsDBNull(17)) { obj.VENCIMIENTO = dr.GetDateTime(17); }
                    if (!dr.IsDBNull(18)) { obj.ID_MEDIO_PAGO = dr.GetInt32(18); }
                    if (!dr.IsDBNull(19)) { obj.INTERES_MORA = dr.GetDecimal(19); }
                    if (!dr.IsDBNull(20)) { obj.NRO_RECIBO_PAGO = dr.GetInt32(20); }
                    if (!dr.IsDBNull(21)) { obj.DIAS_MORA = dr.GetInt32(21); }
                    if (!dr.IsDBNull(22)) { obj.NRO_RECIBO_PAYPERTIC = dr.GetInt32(22); }
                    if (!dr.IsDBNull(23)) { obj.FECHA_ULTIMO_PAGO = dr.GetDateTime(23); }
                    if (!dr.IsDBNull(24)) { obj.PAGO_A_CTA = dr.GetDecimal(24); }
                    if (!dr.IsDBNull(25)) { obj.SALDO_CAPITAL = dr.GetDecimal(25); }
                    if (!dr.IsDBNull(26)) { obj.SALDO_INTERES = dr.GetDecimal(26); }
                    if (!dr.IsDBNull(27)) { obj.AJUSTE_INTERES = dr.GetDecimal(27); }
                    if (!dr.IsDBNull(28)) { obj.OBS_AJUSTE = dr.GetString(28); }
                    if (!dr.IsDBNull(29)) { obj.CAPITAL_PAGADO = dr.GetDecimal(29); }
                    if (!dr.IsDBNull(30)) { obj.INTERES_PAGADO = dr.GetDecimal(30); }
                    if (!dr.IsDBNull(31)) { obj.NRO_PLAN_PAGO = dr.GetInt32(31); }
                    if (!dr.IsDBNull(32)) { obj.ESTADO = dr.GetInt32(32); }
                    if (!dr.IsDBNull(33)) { obj.NRO_CUOTA = dr.GetInt32(33); }
                    if (!dr.IsDBNull(34)) { obj.ID_USUARIO_PAGA = dr.GetInt32(34); }
                    if (!dr.IsDBNull(35)) { obj.ID_USUARIO_ANULA = dr.GetInt32(35); }
                    if (!dr.IsDBNull(36)) { obj.OBS = dr.GetString(36); }
                    if (!dr.IsDBNull(37)) { obj.ID_USUARIO_CARGA = dr.GetInt32(37); }
                    if (!dr.IsDBNull(38)) { obj.ID_PLAN_CUENTA = dr.GetInt32(38); }
                    if (!dr.IsDBNull(39)) { obj.FECHA_CARGA = dr.GetDateTime(39); }
                    if (!dr.IsDBNull(40)) { obj.TIPO_GASTO = dr.GetInt32(40); }
                    if (op == 1)
                        if (!dr.IsDBNull(41)) { obj.PROVEEDOR = dr.GetString(41); }


                    obj.FACTURA = string.Format("{0}-{1}",
                        obj.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                        obj.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<CTACTE_GASTOS> getByRecibo(int nroRecibo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.NOMBRE_FANTASIA FROM CTACTE_GASTOS A");
                sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROVEEDOR=B.ID");
                sql.AppendLine("WHERE TIPO_MOVIMIENTO = 2 AND A.NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO");

                List<CTACTE_GASTOS> lst = new List<CTACTE_GASTOS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", nroRecibo);
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr, 1);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_GASTOS> read(int idProv)
        {
            try
            {
                List<CTACTE_GASTOS> lst = new List<CTACTE_GASTOS>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.NOMBRE_FANTASIA FROM CTACTE_GASTOS A");
                sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROVEEDOR=B.ID");
                sql.AppendLine("WHERE ID_PROVEEDOR=@ID_PROVEEDOR AND");
                sql.AppendLine("TIPO_MOVIMIENTO = 1");
                sql.AppendLine("ORDER BY A.PTO_VTA, A.NRO_CTE DESC, TIPO_MOVIMIENTO ASC");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProv);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr, 0);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<int> readRecibos()
        {
            try
            {
                List<int> lst = new List<int>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT DISTINCT NRO_RECIBO_PAGO");
                sql.AppendLine("FROM CTACTE_GASTOS");
                sql.AppendLine("WHERE TIPO_MOVIMIENTO=2 AND NRO_RECIBO_PAGO NOT IN");
                sql.AppendLine("(SELECT REFERENCIA FROM ASIENTOS WHERE TIPO=4)");
                sql.AppendLine("ORDER BY NRO_RECIBO_PAGO");
               
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            lst.Add(dr.GetInt32(0));
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
        public static List<CTACTE_GASTOS> readDeuda(int idProv)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.NOMBRE_FANTASIA FROM CTACTE_GASTOS A");
                sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROVEEDOR=B.ID");
                sql.AppendLine("WHERE PAGADO = 0 AND A.ID_PROVEEDOR=@ID_PROVEEDOR");
                sql.AppendLine("AND A.ID NOT IN (SELECT ID_FACTURA FROM FACTURAS_X_OP");
                sql.AppendLine("A INNER JOIN ORDENES_PAGO B ON A.ID_OP=B.ID AND ESTADO <> 4)");

                List<CTACTE_GASTOS> lst = new List<CTACTE_GASTOS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProv);
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr, 1);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_GASTOS> readDeuda(int idProv, int ptoVta, 
            long nroCte)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.NOMBRE_FANTASIA FROM CTACTE_GASTOS A");
                sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROVEEDOR=B.ID");
                sql.AppendLine("WHERE A.ID_PROVEEDOR=@ID_PROVEEDOR");
                sql.AppendLine("AND PTO_VTA=@PTO_VTA AND NRO_CTE=@NRO_CTE");
                sql.AppendLine("ORDER BY A.FECHA");
                List<CTACTE_GASTOS> lst = new List<CTACTE_GASTOS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProv);
                    cmd.Parameters.AddWithValue("@PTO_VTA", ptoVta);
                    cmd.Parameters.AddWithValue("@NRO_CTE", nroCte);
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr, 1);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int getPagos(int idProv, int ptoVta,
            long nroCte)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT COUNT(*) FROM CTACTE_GASTOS");
                sql.AppendLine("WHERE ID_PROVEEDOR=@ID_PROVEEDOR AND TIPO_MOVIMIENTO = 2");
                sql.AppendLine("AND PTO_VTA=@PTO_VTA AND NRO_CTE=@NRO_CTE");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProv);
                    cmd.Parameters.AddWithValue("@PTO_VTA", ptoVta);
                    cmd.Parameters.AddWithValue("@NRO_CTE", nroCte);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<CTACTE_GASTOS> readPagos(int idProv, int ptoVta,
            long nroCte)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.NOMBRE_FANTASIA FROM CTACTE_GASTOS A");
                sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROVEEDOR=B.ID");
                sql.AppendLine("WHERE A.ID_PROVEEDOR=@ID_PROVEEDOR AND TIPO_MOVIMIENTO=2");
                sql.AppendLine("AND PTO_VTA=@PTO_VTA AND NRO_CTE=@NRO_CTE");
                List<CTACTE_GASTOS> lst = new List<CTACTE_GASTOS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProv);
                    cmd.Parameters.AddWithValue("@PTO_VTA", ptoVta);
                    cmd.Parameters.AddWithValue("@NRO_CTE", nroCte);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr, 1);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CTACTE_GASTOS getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CTACTE_GASTOS WHERE");
                sql.AppendLine("ID = @ID");
                CTACTE_GASTOS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CTACTE_GASTOS> lst = mapeo(dr, 0);
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
        public static CTACTE_GASTOS getByPk(int idProv, int ptoVta, int nroCte)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM CTACTE_GASTOS WHERE");
                sql.AppendLine("ID_PROVEEDOR = @ID_PROVEEDOR AND");
                sql.AppendLine("PTO_VTA =@PTO_VTA AND NRO_CTE=@NRO_CTE AND TIPO_MOVIMIENTO <> 10");
                CTACTE_GASTOS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProv);
                    cmd.Parameters.AddWithValue("@PTO_VTA", ptoVta);
                    cmd.Parameters.AddWithValue("@NRO_CTE", nroCte);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CTACTE_GASTOS> lst = mapeo(dr, 0);
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
        public static int insert(CTACTE_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO CTACTE_GASTOS(");
                sql.AppendLine("ID_PROVEEDOR");
                sql.AppendLine(", TIPO_MOVIMIENTO");
                sql.AppendLine(", MONTO_ORIGINAL");
                sql.AppendLine(", DEBE");
                sql.AppendLine(", SALDO");
                sql.AppendLine(", PTO_VTA");
                sql.AppendLine(", NRO_CTE");
                sql.AppendLine(", CAE");
                sql.AppendLine(", FECHA_CAE");
                sql.AppendLine(", FECHA");
                sql.AppendLine(", PAGADO");
                sql.AppendLine(", SALDO_CAPITAL");
                sql.AppendLine(", SALDO_INTERES");
                sql.AppendLine(", ESTADO");
                sql.AppendLine(", OBS");
                sql.AppendLine(", ID_USUARIO_CARGA");
                sql.AppendLine(", ID_PLAN_CUENTA");
                sql.AppendLine(", FECHA_CARGA");
                sql.AppendLine(", TIPO_GASTO)");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID_PROVEEDOR");
                sql.AppendLine(", @TIPO_MOVIMIENTO");
                sql.AppendLine(", @MONTO_ORIGINAL");
                sql.AppendLine(", @DEBE");
                sql.AppendLine(", @SALDO");
                sql.AppendLine(", @PTO_VTA");
                sql.AppendLine(", @NRO_CTE");
                sql.AppendLine(", @CAE");
                sql.AppendLine(", @FECHA_CAE");
                sql.AppendLine(", @FECHA");
                sql.AppendLine(", @PAGADO");
                sql.AppendLine(", @SALDO_CAPITAL");
                sql.AppendLine(", @SALDO_INTERES");
                sql.AppendLine(", @ESTADO");
                sql.AppendLine(", @OBS");
                sql.AppendLine(", @ID_USUARIO_CARGA");
                sql.AppendLine(", @ID_PLAN_CUENTA");
                sql.AppendLine(", @FECHA_CARGA");
                sql.AppendLine(", @TIPO_GASTO)");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", obj.ID_PROVEEDOR);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", obj.TIPO_MOVIMIENTO);
                    cmd.Parameters.AddWithValue("@MONTO_ORIGINAL", obj.MONTO_ORIGINAL);
                    cmd.Parameters.AddWithValue("@DEBE", obj.DEBE);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@CAE", obj.CAE);
                    cmd.Parameters.AddWithValue("@FECHA_CAE", obj.FECHA_CAE);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@PAGADO", obj.PAGADO);
                    cmd.Parameters.AddWithValue("@SALDO_CAPITAL", obj.SALDO_CAPITAL);
                    cmd.Parameters.AddWithValue("@SALDO_INTERES", obj.SALDO_INTERES);
                    cmd.Parameters.AddWithValue("@ESTADO", obj.ESTADO);
                    cmd.Parameters.AddWithValue("@OBS", obj.OBS);
                    cmd.Parameters.AddWithValue("@ID_USUARIO_CARGA", obj.ID_USUARIO_CARGA);
                    cmd.Parameters.AddWithValue("@ID_PLAN_CUENTA", obj.ID_PLAN_CUENTA);
                    cmd.Parameters.AddWithValue("@FECHA_CARGA", obj.FECHA_CARGA);
                    cmd.Parameters.AddWithValue("@TIPO_GASTO", obj.TIPO_GASTO);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(CTACTE_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  CTACTE_GASTOS SET");
                sql.AppendLine("ID_PROVEEDOR=@ID_PROVEEDOR");
                sql.AppendLine(", TIPO_MOVIMIENTO=@TIPO_MOVIMIENTO");
                sql.AppendLine(", MONTO_ORIGINAL=@MONTO_ORIGINAL");
                sql.AppendLine(", RECARGO=@RECARGO");
                sql.AppendLine(", DEBE=@DEBE");
                sql.AppendLine(", HABER=@HABER");
                sql.AppendLine(", SALDO=@SALDO");
                sql.AppendLine(", PTO_VTA=@PTO_VTA");
                sql.AppendLine(", NRO_CTE=@NRO_CTE");
                sql.AppendLine(", CAE=@CAE");
                sql.AppendLine(", FECHA_CAE=@FECHA_CAE");
                sql.AppendLine(", VENC_CAE=@VENC_CAE");
                sql.AppendLine(", FECHA=@FECHA");
                sql.AppendLine(", PAGADO=@PAGADO");
                sql.AppendLine(", DESCUENTO=@DESCUENTO");
                sql.AppendLine(", COSTO_FINANCIERO=@COSTO_FINANCIERO");
                sql.AppendLine(", VENCIMIENTO=@VENCIMIENTO");
                sql.AppendLine(", ID_MEDIO_PAGO=@ID_MEDIO_PAGO");
                sql.AppendLine(", INTERES_MORA=@INTERES_MORA");
                sql.AppendLine(", NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO");
                sql.AppendLine(", DIAS_MORA=@DIAS_MORA");
                sql.AppendLine(", NRO_RECIBO_PAYPERTIC=@NRO_RECIBO_PAYPERTIC");
                sql.AppendLine(", FECHA_ULTIMO_PAGO=@FECHA_ULTIMO_PAGO");
                sql.AppendLine(", PAGO_A_CTA=@PAGO_A_CTA");
                sql.AppendLine(", SALDO_CAPITAL=@SALDO_CAPITAL");
                sql.AppendLine(", SALDO_INTERES=@SALDO_INTERES");
                sql.AppendLine(", AJUSTE_INTERES=@AJUSTE_INTERES");
                sql.AppendLine(", OBS_AJUSTE=@OBS_AJUSTE");
                sql.AppendLine(", CAPITAL_PAGADO=@CAPITAL_PAGADO");
                sql.AppendLine(", INTERES_PAGADO=@INTERES_PAGADO");
                sql.AppendLine(", NRO_PLAN_PAGO=@NRO_PLAN_PAGO");
                sql.AppendLine(", ESTADO=@ESTADO");
                sql.AppendLine(", NRO_CUOTA=@NRO_CUOTA");
                sql.AppendLine(", ID_USUARIO_PAGA=@ID_USUARIO_PAGA");
                sql.AppendLine(", ID_USUARIO_ANULA=@ID_USUARIO_ANULA");
                sql.AppendLine(", OBS=@OBS");
                sql.AppendLine(", ID_USUARIO_CARGA=@ID_USUARIO_CARGA");
                sql.AppendLine(", ID_PLAN_CUENTA=@ID_PLAN_CUENTA");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", obj.ID_PROVEEDOR);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", obj.TIPO_MOVIMIENTO);
                    cmd.Parameters.AddWithValue("@MONTO_ORIGINAL", obj.MONTO_ORIGINAL);
                    cmd.Parameters.AddWithValue("@RECARGO", obj.RECARGO);
                    cmd.Parameters.AddWithValue("@DEBE", obj.DEBE);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@CAE", obj.CAE);
                    cmd.Parameters.AddWithValue("@FECHA_CAE", obj.FECHA_CAE);
                    cmd.Parameters.AddWithValue("@VENC_CAE", obj.VENC_CAE);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@PAGADO", obj.PAGADO);
                    cmd.Parameters.AddWithValue("@DESCUENTO", obj.DESCUENTO);
                    cmd.Parameters.AddWithValue("@COSTO_FINANCIERO", obj.COSTO_FINANCIERO);
                    cmd.Parameters.AddWithValue("@VENCIMIENTO", obj.VENCIMIENTO);
                    cmd.Parameters.AddWithValue("@ID_MEDIO_PAGO", obj.ID_MEDIO_PAGO);
                    cmd.Parameters.AddWithValue("@INTERES_MORA", obj.INTERES_MORA);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", obj.NRO_RECIBO_PAGO);
                    cmd.Parameters.AddWithValue("@DIAS_MORA", obj.DIAS_MORA);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAYPERTIC", obj.NRO_RECIBO_PAYPERTIC);
                    cmd.Parameters.AddWithValue("@FECHA_ULTIMO_PAGO", obj.FECHA_ULTIMO_PAGO);
                    cmd.Parameters.AddWithValue("@PAGO_A_CTA", obj.PAGO_A_CTA);
                    cmd.Parameters.AddWithValue("@SALDO_CAPITAL", obj.SALDO_CAPITAL);
                    cmd.Parameters.AddWithValue("@SALDO_INTERES", obj.SALDO_INTERES);
                    cmd.Parameters.AddWithValue("@AJUSTE_INTERES", obj.AJUSTE_INTERES);
                    cmd.Parameters.AddWithValue("@OBS_AJUSTE", obj.OBS_AJUSTE);
                    cmd.Parameters.AddWithValue("@CAPITAL_PAGADO", obj.CAPITAL_PAGADO);
                    cmd.Parameters.AddWithValue("@INTERES_PAGADO", obj.INTERES_PAGADO);
                    cmd.Parameters.AddWithValue("@NRO_PLAN_PAGO", obj.NRO_PLAN_PAGO);
                    cmd.Parameters.AddWithValue("@ESTADO", obj.ESTADO);
                    cmd.Parameters.AddWithValue("@NRO_CUOTA", obj.NRO_CUOTA);
                    cmd.Parameters.AddWithValue("@ID_USUARIO_PAGA", obj.ID_USUARIO_PAGA);
                    cmd.Parameters.AddWithValue("@ID_USUARIO_ANULA", obj.ID_USUARIO_ANULA);
                    cmd.Parameters.AddWithValue("@OBS", obj.OBS);
                    cmd.Parameters.AddWithValue("@ID_USUARIO_CARGA", obj.ID_USUARIO_CARGA);
                    cmd.Parameters.AddWithValue("@ID_PLAN_CUENTA", obj.ID_PLAN_CUENTA);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setDescuento(CTACTE_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  CTACTE_GASTOS SET");
                sql.AppendLine("DEBE=@DEBE");
                sql.AppendLine(", SALDO=@SALDO");
                sql.AppendLine(", DESCUENTO=@DESCUENTO");
                sql.AppendLine(", OBS=@OBS");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Parameters.AddWithValue("@DEBE", obj.DEBE);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
                    cmd.Parameters.AddWithValue("@DESCUENTO", obj.DESCUENTO);
                    cmd.Parameters.AddWithValue("@OBS", obj.OBS);
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
        public static void delete(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  CTACTE_GASTOS ");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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
        public static int getMaxNroRecibo()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT ISNULL(MAX(NRO_RECIBO_PAGO),0)FROM CTACTE_GASTOS");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void asientoPagoCtaMov1(CTACTE_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CTACTE_GASTOS");
                sql.AppendLine("SET FECHA_ULTIMO_PAGO=@FECHA_ULTIMO_PAGO, PAGADO=@PAGADO, PAGO_A_CTA=@PAGO_A_CTA,");
                sql.AppendLine("SALDO_CAPITAL=@SALDO_CAPITAL, SALDO_INTERES=@SALDO_INTERES,");
                sql.AppendLine("CAPITAL_PAGADO=@CAPITAL_PAGADO,HABER=@HABER,");
                sql.AppendLine("SALDO=@SALDO, NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO, ID_MEDIO_PAGO=@ID_MEDIO_PAGO");
                sql.AppendLine("WHERE ID=@ID");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@FECHA_ULTIMO_PAGO", obj.FECHA_ULTIMO_PAGO);
                    cmd.Parameters.AddWithValue("@PAGO_A_CTA", obj.PAGO_A_CTA);
                    cmd.Parameters.AddWithValue("@PAGADO", obj.PAGADO);
                    cmd.Parameters.AddWithValue("@SALDO_CAPITAL", obj.SALDO_CAPITAL);
                    cmd.Parameters.AddWithValue("@SALDO_INTERES", obj.SALDO_INTERES);
                    cmd.Parameters.AddWithValue("@CAPITAL_PAGADO", obj.CAPITAL_PAGADO);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", obj.NRO_RECIBO_PAGO);
                    cmd.Parameters.AddWithValue("@ID_MEDIO_PAGO", obj.ID_MEDIO_PAGO);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
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

        public static void asientoPago(CTACTE_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT CTACTE_GASTOS");
                sql.AppendLine("(FECHA,CAPITAL_PAGADO,HABER,ID_PROVEEDOR,");
                sql.AppendLine("NRO_RECIBO_PAGO, SALDO_CAPITAL, VENCIMIENTO,");
                sql.AppendLine("TIPO_MOVIMIENTO, ID_MEDIO_PAGO, NRO_PLAN_PAGO,");
                sql.AppendLine("NRO_CUOTA,ID_USUARIO_PAGA,PTO_VTA,NRO_CTE,ID_PLAN_CUENTA)");
                sql.AppendLine("VALUES");
                sql.AppendLine("(@FECHA,@CAPITAL_PAGADO,@HABER,@ID_PROVEEDOR,");
                sql.AppendLine("@NRO_RECIBO_PAGO, @SALDO_CAPITAL, @VENCIMIENTO,");
                sql.AppendLine("2, @ID_MEDIO_PAGO, @NRO_PLAN_PAGO,");
                sql.AppendLine("@NRO_CUOTA,@ID_USUARIO_PAGA,@PTO_VTA,@NRO_CTE,@ID_PLAN_CUENTA)");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@CAPITAL_PAGADO", obj.CAPITAL_PAGADO);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", obj.ID_PROVEEDOR);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", obj.NRO_RECIBO_PAGO);
                    cmd.Parameters.AddWithValue("@SALDO_CAPITAL", obj.SALDO_CAPITAL);
                    cmd.Parameters.AddWithValue("@VENCIMIENTO", obj.VENCIMIENTO);
                    cmd.Parameters.AddWithValue("@ID_MEDIO_PAGO", obj.ID_MEDIO_PAGO);
                    cmd.Parameters.AddWithValue("@NRO_PLAN_PAGO", obj.NRO_PLAN_PAGO);
                    cmd.Parameters.AddWithValue("@NRO_CUOTA", obj.NRO_CUOTA);
                    cmd.Parameters.AddWithValue("@ID_USUARIO_PAGA", obj.ID_USUARIO_PAGA);
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@ID_PLAN_CUENTA", obj.ID_PLAN_CUENTA);
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

