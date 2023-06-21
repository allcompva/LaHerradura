using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class PAGOS_X_FACTURA_GASTOS : DALBase
    {
        public int ID { get; set; }
        public DateTime FECHA { get; set; }
        public int USUARIO { get; set; }
        public Int64 ID_FACTURA { get; set; }
        public int ID_PLAN_PAGO { get; set; }
        public decimal MONTO { get; set; }
        public int ID_BANCO { get; set; }
        public string NRO_CHEQUE { get; set; }
        public string CUIT_PAGADOR { get; set; }
        public DateTime FECHA_CHEQUE { get; set; }
        public string MEDIO_PAGO { get; set; }
        public string BANCO { get; set; } 

        public PAGOS_X_FACTURA_GASTOS()
        {
            ID = 0;
            FECHA = UTILS.getFechaActual();
            USUARIO = 0;
            ID_FACTURA = 0;
            ID_PLAN_PAGO = 0;
            MONTO = 0;
            ID_BANCO = 0;
            NRO_CHEQUE = string.Empty;
            CUIT_PAGADOR = string.Empty;
            FECHA_CHEQUE = UTILS.getFechaActual();
        }

        private static List<PAGOS_X_FACTURA_GASTOS> mapeo(SqlDataReader dr)
        {
            List<PAGOS_X_FACTURA_GASTOS> lst = new List<PAGOS_X_FACTURA_GASTOS>();
            PAGOS_X_FACTURA_GASTOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new PAGOS_X_FACTURA_GASTOS();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.FECHA = dr.GetDateTime(1); }
                    if (!dr.IsDBNull(2)) { obj.USUARIO = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.ID_FACTURA = dr.GetInt64(3); }
                    if (!dr.IsDBNull(4)) { obj.ID_PLAN_PAGO = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.MONTO = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.ID_BANCO = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7))
                    {
                        if (dr.GetString(7).Length > 1)
                            obj.NRO_CHEQUE = string.Format("Nro.: {0}",
                            dr.GetString(7));
                    }
                    if (!dr.IsDBNull(8)) { obj.CUIT_PAGADOR = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.FECHA_CHEQUE = dr.GetDateTime(9); }
                    if (!dr.IsDBNull(10)) { obj.MEDIO_PAGO = dr.GetString(10); }
                    if (!dr.IsDBNull(11)) { obj.BANCO = dr.GetString(11); }

                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PAGOS_X_FACTURA_GASTOS> read(int idFactura)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.DESCRIPCION, C.DENOMINACION");
                sql.AppendLine("FROM PAGOS_X_FACTURA_GASTOS A");
                sql.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_PLAN_PAGO=B.ID");
                sql.AppendLine("LEFT JOIN BANCOS C ON C.CODIGO=ID_BANCO");
                sql.AppendLine("WHERE ID_FACTURA=@ID_FACTURA");
                //sql.AppendLine("UNION");
                //sql.AppendLine("SELECT 0, GETDATE(), 0, NRO_RECIBO, 7, MONTO, NULL, NULL, NULL, NULL, 'BILLETERA VIRTUAL', NULL");
                //sql.AppendLine("FROM MOV_BILLETERA_GASTOS");
                //sql.AppendLine("WHERE NRO_RECIBO = @ID_FACTURA AND TIPO_MOVIMIENTO = 2");

                List<PAGOS_X_FACTURA_GASTOS> lst = new List<PAGOS_X_FACTURA_GASTOS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_FACTURA", idFactura);
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
        public static List<PAGOS_X_FACTURA_GASTOS> read()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT DISTINCT A.*, B.DESCRIPCION, C.DENOMINACION, D.OBS");
                sql.AppendLine("FROM PAGOS_X_FACTURA_GASTOS A");
                sql.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_PLAN_PAGO=B.ID");
                sql.AppendLine("LEFT JOIN BANCOS C ON C.CODIGO=ID_BANCO");
                sql.AppendLine("INNER JOIN CTACTE_GASTOS D ON A.ID_FACTURA=D.NRO_RECIBO_PAGO");
                sql.AppendLine("WHERE A.ID NOT IN (SELECT ID_FACTURA FROM TB_MOVIM_CAJA WHERE TIPO_MOV = 2)");

                List<PAGOS_X_FACTURA_GASTOS> lst = new List<PAGOS_X_FACTURA_GASTOS>();
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
        public static PAGOS_X_FACTURA_GASTOS getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM PAGOS_X_FACTURA_GASTOS WHERE");
                sql.AppendLine("ID = @ID");
                PAGOS_X_FACTURA_GASTOS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PAGOS_X_FACTURA_GASTOS> lst = mapeo(dr);
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

        public static int insert(PAGOS_X_FACTURA_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO PAGOS_X_FACTURA_GASTOS(");
                sql.AppendLine("FECHA");
                sql.AppendLine(", USUARIO");
                sql.AppendLine(", ID_FACTURA");
                sql.AppendLine(", ID_PLAN_PAGO");
                sql.AppendLine(", MONTO");
                sql.AppendLine(", ID_BANCO");
                sql.AppendLine(", NRO_CHEQUE");
                sql.AppendLine(", CUIT_PAGADOR");
                sql.AppendLine(", FECHA_CHEQUE");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@FECHA");
                sql.AppendLine(", @USUARIO");
                sql.AppendLine(", @ID_FACTURA");
                sql.AppendLine(", @ID_PLAN_PAGO");
                sql.AppendLine(", @MONTO");
                sql.AppendLine(", @ID_BANCO");
                sql.AppendLine(", @NRO_CHEQUE");
                sql.AppendLine(", @CUIT_PAGADOR");
                sql.AppendLine(", @FECHA_CHEQUE");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@USUARIO", obj.USUARIO);
                    cmd.Parameters.AddWithValue("@ID_FACTURA", obj.ID_FACTURA);
                    cmd.Parameters.AddWithValue("@ID_PLAN_PAGO", obj.ID_PLAN_PAGO);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Parameters.AddWithValue("@ID_BANCO", obj.ID_BANCO);
                    cmd.Parameters.AddWithValue("@NRO_CHEQUE", obj.NRO_CHEQUE);
                    cmd.Parameters.AddWithValue("@CUIT_PAGADOR", obj.CUIT_PAGADOR);
                    cmd.Parameters.AddWithValue("@FECHA_CHEQUE", obj.FECHA_CHEQUE);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(PAGOS_X_FACTURA_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  PAGOS_X_FACTURA_GASTOS SET");
                sql.AppendLine("FECHA=@FECHA");
                sql.AppendLine(", USUARIO=@USUARIO");
                sql.AppendLine(", ID_FACTURA=@ID_FACTURA");
                sql.AppendLine(", ID_PLAN_PAGO=@ID_PLAN_PAGO");
                sql.AppendLine(", MONTO=@MONTO");
                sql.AppendLine(", ID_BANCO=@ID_BANCO");
                sql.AppendLine(", NRO_CHEQUE=@NRO_CHEQUE");
                sql.AppendLine(", CUIT_PAGADOR=@CUIT_PAGADOR");
                sql.AppendLine(", FECHA_CHEQUE=@FECHA_CHEQUE");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@USUARIO", obj.USUARIO);
                    cmd.Parameters.AddWithValue("@ID_FACTURA", obj.ID_FACTURA);
                    cmd.Parameters.AddWithValue("@ID_PLAN_PAGO", obj.ID_PLAN_PAGO);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Parameters.AddWithValue("@ID_BANCO", obj.ID_BANCO);
                    cmd.Parameters.AddWithValue("@NRO_CHEQUE", obj.NRO_CHEQUE);
                    cmd.Parameters.AddWithValue("@CUIT_PAGADOR", obj.CUIT_PAGADOR);
                    cmd.Parameters.AddWithValue("@FECHA_CHEQUE", obj.FECHA_CHEQUE);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(PAGOS_X_FACTURA_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  PAGOS_X_FACTURA_GASTOS ");
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

