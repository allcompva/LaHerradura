using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class PAGOS_X_FACTURA : DALBase
    {
        public int ID { get; set; }
        public DateTime FECHA { get; set; }
        public int USUARIO { get; set; }
        public Int64 ID_FACTURA { get; set; }
        public int ID_PLAN_PAGO { get; set; }
        public Decimal MONTO { get; set; }
        public int ID_BANCO { get; set; }
        public string NRO_CHEQUE { get; set; }
        public string CUIT_PAGADOR { get; set; }
        public DateTime FECHA_CHEQUE { get; set; }

        public string MEDIO_PAGO { get; set; }
        public string BANCO { get; set; }


        public int ID_TARJETA { get; set; }
        public int CANT_CUOTAS { get; set; }
        public int NRO_CTA { get; set; }

        public PAGOS_X_FACTURA()
        {
            ID = 0;
            FECHA = UTILS.getFechaActual();
            USUARIO = 1;
            ID_FACTURA = 0;
            ID_PLAN_PAGO = 0;
            MONTO = 0;
            ID_BANCO = 0;
            NRO_CHEQUE = string.Empty;
            ID_TARJETA = 0;
            CANT_CUOTAS = 0;
            NRO_CTA = 0;
        }
        public static void insert(PAGOS_X_FACTURA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                if (obj.ID_PLAN_PAGO == 2)
                {
                    sql.AppendLine("INSERT INTO PAGOS_X_FACTURA");
                    sql.AppendLine("(FECHA,USUARIO,ID_FACTURA,ID_PLAN_PAGO,MONTO,");
                    sql.AppendLine("ID_BANCO,NRO_CHEQUE, CUIT_PAGADOR, FECHA_CHEQUE)");
                    sql.AppendLine("VALUES");
                    sql.AppendLine("(@FECHA,@USUARIO,@ID_FACTURA,@ID_PLAN_PAGO,@MONTO,");
                    sql.AppendLine("@ID_BANCO,@NRO_CHEQUE, @CUIT_PAGADOR, @FECHA_CHEQUE)");
                }
                else
                {
                    sql.AppendLine("INSERT INTO PAGOS_X_FACTURA");
                    sql.AppendLine("(FECHA,USUARIO,ID_FACTURA,ID_PLAN_PAGO,MONTO,ID_TARJETA,CANT_CUOTAS)");
                    sql.AppendLine("VALUES");
                    sql.AppendLine("(@FECHA,@USUARIO,@ID_FACTURA,@ID_PLAN_PAGO,@MONTO,@ID_TARJETA,@CANT_CUOTAS)");

                }
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@USUARIO", obj.USUARIO);
                    cmd.Parameters.AddWithValue("@ID_FACTURA", obj.ID_FACTURA);
                    cmd.Parameters.AddWithValue("@ID_PLAN_PAGO", obj.ID_PLAN_PAGO);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    if (obj.ID_PLAN_PAGO == 2)
                    {
                        cmd.Parameters.AddWithValue("@ID_BANCO", obj.ID_BANCO);
                        cmd.Parameters.AddWithValue("@NRO_CHEQUE", obj.NRO_CHEQUE);
                        cmd.Parameters.AddWithValue("@CUIT_PAGADOR", obj.CUIT_PAGADOR);
                        cmd.Parameters.AddWithValue("@FECHA_CHEQUE", obj.FECHA_CHEQUE);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ID_TARJETA", obj.ID_TARJETA);
                        cmd.Parameters.AddWithValue("@CANT_CUOTAS", obj.CANT_CUOTAS);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //

        private static List<PAGOS_X_FACTURA> mapeo(SqlDataReader dr)
        {
            List<PAGOS_X_FACTURA> lst = new List<PAGOS_X_FACTURA>();
            PAGOS_X_FACTURA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new PAGOS_X_FACTURA();
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
                    if (!dr.IsDBNull(10)) { obj.ID_TARJETA = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.CANT_CUOTAS = dr.GetInt32(11); }

                    if (!dr.IsDBNull(12)) { obj.MEDIO_PAGO = dr.GetString(12); }
                    if (!dr.IsDBNull(13)) { obj.BANCO = dr.GetString(13); }

                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PAGOS_X_FACTURA> read(int idFactura)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.*, B.DESCRIPCION, C.DENOMINACION");
                sql.AppendLine("FROM PAGOS_X_FACTURA A");
                sql.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_PLAN_PAGO=B.ID");
                sql.AppendLine("LEFT JOIN BANCOS C ON C.CODIGO=ID_BANCO");
                sql.AppendLine("WHERE ID_FACTURA=@ID_FACTURA");
                //sql.AppendLine("UNION");
                //sql.AppendLine("SELECT 0, GETDATE(), 0, NRO_RECIBO, 7, MONTO, NULL, NULL, NULL, NULL, NULL, NULL, 'BILLETERA VIRTUAL', NULL");
                //sql.AppendLine("FROM MOV_BILLETERA");
                //sql.AppendLine("WHERE NRO_RECIBO = @ID_FACTURA AND TIPO_MOVIMIENTO = 2");

                List<PAGOS_X_FACTURA> lst = new List<PAGOS_X_FACTURA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_FACTURA", idFactura);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    PAGOS_X_FACTURA obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new PAGOS_X_FACTURA();
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
                            if (!dr.IsDBNull(10)) { obj.ID_TARJETA = dr.GetInt32(10); }
                            if (!dr.IsDBNull(11)) { obj.CANT_CUOTAS = dr.GetInt32(11); }

                            if (!dr.IsDBNull(12)) { obj.MEDIO_PAGO = dr.GetString(12); }
                            if (!dr.IsDBNull(13)) { obj.BANCO = dr.GetString(13); }

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
        public static List<PAGOS_X_FACTURA> read()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT DISTINCT A.*, B.DESCRIPCION, C.DENOMINACION, D.NRO_CTA");
                sql.AppendLine("FROM PAGOS_X_FACTURA A");
                sql.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_PLAN_PAGO=B.ID");
                sql.AppendLine("LEFT JOIN BANCOS C ON C.CODIGO=ID_BANCO");
                sql.AppendLine("INNER JOIN CTACTE_EXPENSAS D ON A.ID_FACTURA=D.NRO_RECIBO_PAGO");
                sql.AppendLine("WHERE A.ID NOT IN (SELECT ID_FACTURA FROM TB_MOVIM_CAJA WHERE TIPO_MOV = 1)");
                //sql.AppendLine("UNION");
                //sql.AppendLine("SELECT 0, GETDATE(), 0, NRO_RECIBO, 7, MONTO, NULL, NULL, NULL, NULL, NULL, NULL, 'BILLETERA VIRTUAL', NULL");
                //sql.AppendLine("FROM MOV_BILLETERA");
                //sql.AppendLine("WHERE NRO_RECIBO = @ID_FACTURA AND TIPO_MOVIMIENTO = 2");

                List<PAGOS_X_FACTURA> lst = new List<PAGOS_X_FACTURA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    PAGOS_X_FACTURA obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new PAGOS_X_FACTURA();
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
                            if (!dr.IsDBNull(10)) { obj.ID_TARJETA = dr.GetInt32(10); }
                            if (!dr.IsDBNull(11)) { obj.CANT_CUOTAS = dr.GetInt32(11); }

                            if (!dr.IsDBNull(12)) { obj.MEDIO_PAGO = dr.GetString(12); }
                            if (!dr.IsDBNull(13)) { obj.BANCO = dr.GetString(13); }
                            if (!dr.IsDBNull(14)) { obj.NRO_CTA = dr.GetInt32(14); }
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
        //

    }
}

