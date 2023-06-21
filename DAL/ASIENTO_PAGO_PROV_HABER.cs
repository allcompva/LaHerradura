using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class ASIENTO_PAGO_PROV_HABER : DALBase
    {
        public int ID { get; set; }
        public decimal MONTO { get; set; }
        public int ID_PLAN_PAGO { get; set; }
        public string DESCRIPCION { get; set; }
        public int ID_PLAN_CUENTA { get; set; }
        public Int64 ID_FACTURA { get; set; }
        public string DESC_SUBCUENTA { get; set; }
        public string N5 { get; set; }
        public string DENOMINACION { get; set; }
        public string NRO_CHEQUE { get; set; }

        public ASIENTO_PAGO_PROV_HABER()
        {
            ID = 0;
            MONTO = 0;
            ID_PLAN_PAGO = 0;
            DESCRIPCION = string.Empty;
            ID_PLAN_CUENTA = 0;
            ID_FACTURA = 0;
            DESC_SUBCUENTA = string.Empty;
            N5 = string.Empty;
            DENOMINACION = string.Empty;
            NRO_CHEQUE = string.Empty;
        }

        private static List<ASIENTO_PAGO_PROV_HABER> mapeo(SqlDataReader dr)
        {
            List<ASIENTO_PAGO_PROV_HABER> lst = new List<ASIENTO_PAGO_PROV_HABER>();
            ASIENTO_PAGO_PROV_HABER obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new ASIENTO_PAGO_PROV_HABER();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.MONTO = dr.GetDecimal(1); }
                    if (!dr.IsDBNull(2)) { obj.ID_PLAN_PAGO = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.DESCRIPCION = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.ID_PLAN_CUENTA = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.ID_FACTURA = dr.GetInt64(5); }
                    if (!dr.IsDBNull(6)) { obj.DESC_SUBCUENTA = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.N5 = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.DENOMINACION = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.NRO_CHEQUE = dr.GetString(9); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<ASIENTO_PAGO_PROV_HABER> read(int idRecibo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID, A.MONTO, A.ID_PLAN_PAGO, B.DESCRIPCION,");
                sql.AppendLine("B.ID_PLAN_CUENTA, A.ID_FACTURA, C.DESC_SUBCUENTA, C.N5,");
                sql.AppendLine("D.DENOMINACION, A.NRO_CHEQUE");
                sql.AppendLine("FROM PAGOS_X_FACTURA_GASTOS A");
                sql.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_PLAN_PAGO=B.ID");
                sql.AppendLine("INNER JOIN PLAN_CUENTA C ON B.ID_PLAN_CUENTA=C.ID");
                sql.AppendLine("FULL JOIN BANCOS D ON A.ID_BANCO=D.CODIGO");
                sql.AppendLine("WHERE ID_FACTURA = @ID_FACTURA");

                List<ASIENTO_PAGO_PROV_HABER> lst = new List<ASIENTO_PAGO_PROV_HABER>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_FACTURA", idRecibo);
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

        public static ASIENTO_PAGO_PROV_HABER getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM ASIENTO_PAGO_PROV_HABER WHERE");
                ASIENTO_PAGO_PROV_HABER obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ASIENTO_PAGO_PROV_HABER> lst = mapeo(dr);
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

        public static int insert(ASIENTO_PAGO_PROV_HABER obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO ASIENTO_PAGO_PROV_HABER(");
                sql.AppendLine("ID");
                sql.AppendLine(", MONTO");
                sql.AppendLine(", ID_PLAN_PAGO");
                sql.AppendLine(", DESCRIPCION");
                sql.AppendLine(", ID_PLAN_CUENTA");
                sql.AppendLine(", ID_FACTURA");
                sql.AppendLine(", DESC_SUBCUENTA");
                sql.AppendLine(", N5");
                sql.AppendLine(", DENOMINACION");
                sql.AppendLine(", NRO_CHEQUE");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID");
                sql.AppendLine(", @MONTO");
                sql.AppendLine(", @ID_PLAN_PAGO");
                sql.AppendLine(", @DESCRIPCION");
                sql.AppendLine(", @ID_PLAN_CUENTA");
                sql.AppendLine(", @ID_FACTURA");
                sql.AppendLine(", @DESC_SUBCUENTA");
                sql.AppendLine(", @N5");
                sql.AppendLine(", @DENOMINACION");
                sql.AppendLine(", @NRO_CHEQUE");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Parameters.AddWithValue("@ID_PLAN_PAGO", obj.ID_PLAN_PAGO);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@ID_PLAN_CUENTA", obj.ID_PLAN_CUENTA);
                    cmd.Parameters.AddWithValue("@ID_FACTURA", obj.ID_FACTURA);
                    cmd.Parameters.AddWithValue("@DESC_SUBCUENTA", obj.DESC_SUBCUENTA);
                    cmd.Parameters.AddWithValue("@N5", obj.N5);
                    cmd.Parameters.AddWithValue("@DENOMINACION", obj.DENOMINACION);
                    cmd.Parameters.AddWithValue("@NRO_CHEQUE", obj.NRO_CHEQUE);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(ASIENTO_PAGO_PROV_HABER obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  ASIENTO_PAGO_PROV_HABER SET");
                sql.AppendLine("ID=@ID");
                sql.AppendLine(", MONTO=@MONTO");
                sql.AppendLine(", ID_PLAN_PAGO=@ID_PLAN_PAGO");
                sql.AppendLine(", DESCRIPCION=@DESCRIPCION");
                sql.AppendLine(", ID_PLAN_CUENTA=@ID_PLAN_CUENTA");
                sql.AppendLine(", ID_FACTURA=@ID_FACTURA");
                sql.AppendLine(", DESC_SUBCUENTA=@DESC_SUBCUENTA");
                sql.AppendLine(", N5=@N5");
                sql.AppendLine(", DENOMINACION=@DENOMINACION");
                sql.AppendLine(", NRO_CHEQUE=@NRO_CHEQUE");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Parameters.AddWithValue("@ID_PLAN_PAGO", obj.ID_PLAN_PAGO);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", obj.DESCRIPCION);
                    cmd.Parameters.AddWithValue("@ID_PLAN_CUENTA", obj.ID_PLAN_CUENTA);
                    cmd.Parameters.AddWithValue("@ID_FACTURA", obj.ID_FACTURA);
                    cmd.Parameters.AddWithValue("@DESC_SUBCUENTA", obj.DESC_SUBCUENTA);
                    cmd.Parameters.AddWithValue("@N5", obj.N5);
                    cmd.Parameters.AddWithValue("@DENOMINACION", obj.DENOMINACION);
                    cmd.Parameters.AddWithValue("@NRO_CHEQUE", obj.NRO_CHEQUE);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(ASIENTO_PAGO_PROV_HABER obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  ASIENTO_PAGO_PROV_HABER ");
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

