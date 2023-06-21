using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class MOV_BILLETERA_GASTOS : DALBase
    {
        public int ID { get; set; }
        public int ID_PROVEEDOR { get; set; }
        public DateTime FECHA { get; set; }
        public int NRO_RECIBO { get; set; }
        public decimal MONTO { get; set; }
        public int TIPO_MOVIMIENTO { get; set; }
        public int NRO_RECIBO_ADELANTO { get; set; }
        public int ID_MEDIO_PAGO { get; set; }
        public int ID_BANCO { get; set; }
        public string NRO_CHEQUE { get; set; }
        public string CUIT_PAGADOR { get; set; }
        public DateTime? FECHA_CHEQUE { get; set; }
        public int ANULADO { get; set; }
        public int ID_USUARIO_CARGA { get; set; }
        public DateTime? FECHA_CARGA { get; set; }
        public int ID_USUARIO_ANULA { get; set; }
        public DateTime? FECHA_ANULA { get; set; }


        public MOV_BILLETERA_GASTOS()
        {
            ID = 0;
            ID_PROVEEDOR = 0;
            FECHA = UTILS.getFechaActual();
            NRO_RECIBO = 0;
            MONTO = 0;
            TIPO_MOVIMIENTO = 0;
            NRO_RECIBO_ADELANTO = 0;
            ID_MEDIO_PAGO = 0;
            ID_BANCO = 0;
            NRO_CHEQUE = string.Empty;
            CUIT_PAGADOR = string.Empty;
            FECHA_CHEQUE = null;
            ANULADO = 0;

            ID_USUARIO_CARGA = 0;
            ID_USUARIO_ANULA = 0;
            FECHA_ANULA = null;
            FECHA_CARGA = null;
        }

        private static List<MOV_BILLETERA_GASTOS> mapeo(SqlDataReader dr)
        {
            List<MOV_BILLETERA_GASTOS> lst = new List<MOV_BILLETERA_GASTOS>();
            MOV_BILLETERA_GASTOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new MOV_BILLETERA_GASTOS();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.ID_PROVEEDOR = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.FECHA = dr.GetDateTime(2); }
                    if (!dr.IsDBNull(3)) { obj.NRO_RECIBO = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.MONTO = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.TIPO_MOVIMIENTO = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.NRO_RECIBO_ADELANTO = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.ID_MEDIO_PAGO = dr.GetInt32(7); }

                    if (!dr.IsDBNull(8)) { obj.ID_BANCO = dr.GetInt32(8); }
                    if (!dr.IsDBNull(9)) { obj.NRO_CHEQUE = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.CUIT_PAGADOR = dr.GetString(10); }
                    if (!dr.IsDBNull(11)) { obj.FECHA_CHEQUE = dr.GetDateTime(11); }

                    if (!dr.IsDBNull(12)) { obj.ANULADO = dr.GetInt32(12); }
                    if (!dr.IsDBNull(13)) { obj.ID_USUARIO_CARGA = dr.GetInt32(13); }
                    if (!dr.IsDBNull(14)) { obj.FECHA_CARGA = dr.GetDateTime(14); }
                    if (!dr.IsDBNull(15)) { obj.ID_USUARIO_ANULA = dr.GetInt32(15); }
                    if (!dr.IsDBNull(16)) { obj.FECHA_ANULA = dr.GetDateTime(16); }

                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<MOV_BILLETERA_GASTOS> read()
        {
            try
            {
                List<MOV_BILLETERA_GASTOS> lst = new List<MOV_BILLETERA_GASTOS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM MOV_BILLETERA_GASTOS WHERE ANULADO=0";
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
        public static int getUltimoRecibo()
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT ISNULL(MAX(NRO_RECIBO_ADELANTO),0) FROM MOV_BILLETERA_GASTOS";
                    cmd.Connection.Open();

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static MOV_BILLETERA_GASTOS getByNroRecibo(int nroRecibo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM MOV_BILLETERA_GASTOS WHERE NRO_RECIBO = @NRO_RECIBO AND TIPO_MOVIMIENTO = 1");
                MOV_BILLETERA_GASTOS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_RECIBO", nroRecibo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<MOV_BILLETERA_GASTOS> lst = mapeo(dr);
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
        public static MOV_BILLETERA_GASTOS getByNroReciboAdelanto(int nroRecibo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM MOV_BILLETERA_GASTOS WHERE NRO_RECIBO_ADELANTO = @NRO_RECIBO_ADELANTO AND TIPO_MOVIMIENTO = 1");
                MOV_BILLETERA_GASTOS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_ADELANTO", nroRecibo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<MOV_BILLETERA_GASTOS> lst = mapeo(dr);
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
        public static MOV_BILLETERA_GASTOS getByNroRecibo2(int nroRecibo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM MOV_BILLETERA_GASTOS WHERE NRO_RECIBO = @NRO_RECIBO AND TIPO_MOVIMIENTO = 2");
                MOV_BILLETERA_GASTOS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_RECIBO", nroRecibo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<MOV_BILLETERA_GASTOS> lst = mapeo(dr);
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
        public static MOV_BILLETERA_GASTOS getByNroReciboAdelanto2(int nroRecibo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM MOV_BILLETERA_GASTOS WHERE NRO_RECIBO_ADELANTO = @NRO_RECIBO_ADELANTO AND TIPO_MOVIMIENTO = 2");
                MOV_BILLETERA_GASTOS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_ADELANTO", nroRecibo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<MOV_BILLETERA_GASTOS> lst = mapeo(dr);
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
        public static MOV_BILLETERA_GASTOS getByNroProvFecha(int idProv, DateTime fecha)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.* FROM MOV_BILLETERA_GASTOS A");
                sql.AppendLine("INNER JOIN CTACTE_GASTOS B ON A.NRO_RECIBO = B.NRO_RECIBO_PAGO");
                sql.AppendLine("AND B.TIPO_MOVIMIENTO = 2");
                sql.AppendLine("WHERE A.ID_PROVEEDOR = @ID_PROVEEDOR");
                sql.AppendLine("AND A.TIPO_MOVIMIENTO = 2");
                sql.AppendLine("AND A.FECHA > @FECHA AND ANULADO=0");
                MOV_BILLETERA_GASTOS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProv);
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<MOV_BILLETERA_GASTOS> lst = mapeo(dr);
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
        public static MOV_BILLETERA_GASTOS getByPk(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT * FROM MOV_BILLETERA_GASTOS");
                sql.AppendLine("WHERE ID = @ID");
                MOV_BILLETERA_GASTOS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<MOV_BILLETERA_GASTOS> lst = mapeo(dr);
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
        public static void insert(MOV_BILLETERA_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO MOV_BILLETERA_GASTOS(");
                sql.AppendLine("ID_PROVEEDOR");
                sql.AppendLine(", FECHA");
                sql.AppendLine(", NRO_RECIBO");
                sql.AppendLine(", MONTO");
                sql.AppendLine(", TIPO_MOVIMIENTO");
                sql.AppendLine(", NRO_RECIBO_ADELANTO");
                sql.AppendLine(", ID_MEDIO_PAGO");
                sql.AppendLine(", ID_USUARIO_CARGA");
                sql.AppendLine(", FECHA_CARGA");
                if (obj.ID_MEDIO_PAGO == 2)
                {
                    sql.AppendLine(", ID_BANCO");
                    sql.AppendLine(", NRO_CHEQUE");
                    sql.AppendLine(", CUIT_PAGADOR");
                    sql.AppendLine(", FECHA_CHEQUE");
                }

                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID_PROVEEDOR");
                sql.AppendLine(", @FECHA");
                sql.AppendLine(", @NRO_RECIBO");
                sql.AppendLine(", @MONTO");
                sql.AppendLine(", @TIPO_MOVIMIENTO");
                sql.AppendLine(", @NRO_RECIBO_ADELANTO");
                sql.AppendLine(", @ID_MEDIO_PAGO");
                sql.AppendLine(", @ID_USUARIO_CARGA");
                sql.AppendLine(", @FECHA_CARGA");

                if (obj.ID_MEDIO_PAGO == 2)
                {
                    sql.AppendLine(", @ID_BANCO");
                    sql.AppendLine(", @NRO_CHEQUE");
                    sql.AppendLine(", @CUIT_PAGADOR");
                    sql.AppendLine(", @FECHA_CHEQUE");
                }

                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", obj.ID_PROVEEDOR);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO", obj.NRO_RECIBO);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", obj.TIPO_MOVIMIENTO);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_ADELANTO", obj.NRO_RECIBO_ADELANTO);
                    cmd.Parameters.AddWithValue("@ID_MEDIO_PAGO", obj.ID_MEDIO_PAGO);
                    cmd.Parameters.AddWithValue("@ID_USUARIO_CARGA", obj.ID_USUARIO_CARGA);
                    cmd.Parameters.AddWithValue("@FECHA_CARGA", obj.FECHA_CARGA);
                    if (obj.ID_MEDIO_PAGO == 2)
                    {
                        cmd.Parameters.AddWithValue("@ID_BANCO", obj.ID_BANCO);
                        cmd.Parameters.AddWithValue("@NRO_CHEQUE", obj.NRO_CHEQUE);
                        cmd.Parameters.AddWithValue("@CUIT_PAGADOR", obj.CUIT_PAGADOR);
                        cmd.Parameters.AddWithValue("@FECHA_CHEQUE", obj.FECHA_CHEQUE);
                    }
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void anular(int id, int idUsuarioAnula, DateTime fechaAnula)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  MOV_BILLETERA_GASTOS ");
                sql.AppendLine("SET ANULADO=1, ID_USUARIO_ANULA=@ID_USUARIO_ANULA, ");
                sql.AppendLine("FECHA_ANULA=@FECHA_ANULA WHERE ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@ID_USUARIO_ANULA", idUsuarioAnula);
                    cmd.Parameters.AddWithValue("@FECHA_ANULA", fechaAnula);
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
                sql.AppendLine("DELETE  MOV_BILLETERA_GASTOS ");
                sql.AppendLine("WHERE ID=@ID");
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

    }
}

