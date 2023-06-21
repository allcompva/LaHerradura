using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class ASIENTO_PAGO_PROV_DEBE : DALBase
    {
        public int ID { get; set; }
        public int NRO_RECIBO_PAGO { get; set; }
        public decimal HABER { get; set; }
        public int PTO_VTA { get; set; }
        public Int64 NRO_CTE { get; set; }
        public DateTime FECHA { get; set; }
        public int CUENTA_GASTO { get; set; }
        public string N5_DEBE { get; set; }
        public string CUENTA_DEBE { get; set; }
        public string RAZON_SOCIAL { get; set; }

        public ASIENTO_PAGO_PROV_DEBE()
        {
            ID = 0;
            NRO_RECIBO_PAGO = 0;
            HABER = 0;
            PTO_VTA = 0;
            NRO_CTE = 0;
            FECHA = DAL.UTILS.getFechaActual();
            CUENTA_GASTO = 0;
            N5_DEBE = string.Empty;
            CUENTA_DEBE = string.Empty;
            RAZON_SOCIAL = string.Empty;
        }

        private static List<ASIENTO_PAGO_PROV_DEBE> mapeo(SqlDataReader dr)
        {
            List<ASIENTO_PAGO_PROV_DEBE> lst = new List<ASIENTO_PAGO_PROV_DEBE>();
            ASIENTO_PAGO_PROV_DEBE obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new ASIENTO_PAGO_PROV_DEBE();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_RECIBO_PAGO = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.HABER = dr.GetDecimal(2); }
                    if (!dr.IsDBNull(3)) { obj.PTO_VTA = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.NRO_CTE = dr.GetInt64(4); }
                    if (!dr.IsDBNull(5)) { obj.FECHA = dr.GetDateTime(5); }
                    if (!dr.IsDBNull(6)) { obj.CUENTA_GASTO = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.N5_DEBE = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.CUENTA_DEBE = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.RAZON_SOCIAL = dr.GetString(9); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<ASIENTO_PAGO_PROV_DEBE> read(int nroRecibo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID, A.NRO_RECIBO_PAGO, A.HABER, PTO_VTA, A.NRO_CTE,");
                sql.AppendLine("A.FECHA, ");
                sql.AppendLine("D.ID AS CUENTA_GASTO, D.N5 AS N5_DEBE, D.DESC_SUBCUENTA AS CUENTA_DEBE,");
                sql.AppendLine("E.RAZON_SOCIAL");
                sql.AppendLine("FROM CTACTE_GASTOS A");
                sql.AppendLine("INNER JOIN CUENTAS_X_PROVEEDOR B ON A.ID_PROVEEDOR=B.ID_PROV");
                sql.AppendLine("AND A.ID_PLAN_CUENTA=B.ID_CTA_CONTABLE_GASTO");
                sql.AppendLine("INNER JOIN PLAN_CUENTA C ON C.ID=B.ID_CTA_CONTABLE_GASTO");
                sql.AppendLine("INNER JOIN PLAN_CUENTA D ON B.ID_CTA_CONTABLE_PASIVO=D.ID");
                sql.AppendLine("INNER JOIN PROVEEDORES E ON A.ID_PROVEEDOR=E.ID");
                sql.AppendLine("WHERE TIPO_MOVIMIENTO=2 AND NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO");

                List<ASIENTO_PAGO_PROV_DEBE> lst = new List<ASIENTO_PAGO_PROV_DEBE>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", nroRecibo);
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

        public static ASIENTO_PAGO_PROV_DEBE getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM ASIENTO_PAGO_PROV_DEBE WHERE");
                ASIENTO_PAGO_PROV_DEBE obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ASIENTO_PAGO_PROV_DEBE> lst = mapeo(dr);
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

        public static int insert(ASIENTO_PAGO_PROV_DEBE obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO ASIENTO_PAGO_PROV_DEBE(");
                sql.AppendLine("ID");
                sql.AppendLine(", NRO_RECIBO_PAGO");
                sql.AppendLine(", HABER");
                sql.AppendLine(", PTO_VTA");
                sql.AppendLine(", NRO_CTE");
                sql.AppendLine(", FECHA");
                sql.AppendLine(", CUENTA_GASTO");
                sql.AppendLine(", N5_DEBE");
                sql.AppendLine(", CUENTA_DEBE");
                sql.AppendLine(", RAZON_SOCIAL");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID");
                sql.AppendLine(", @NRO_RECIBO_PAGO");
                sql.AppendLine(", @HABER");
                sql.AppendLine(", @PTO_VTA");
                sql.AppendLine(", @NRO_CTE");
                sql.AppendLine(", @FECHA");
                sql.AppendLine(", @CUENTA_GASTO");
                sql.AppendLine(", @N5_DEBE");
                sql.AppendLine(", @CUENTA_DEBE");
                sql.AppendLine(", @RAZON_SOCIAL");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", obj.NRO_RECIBO_PAGO);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@CUENTA_GASTO", obj.CUENTA_GASTO);
                    cmd.Parameters.AddWithValue("@N5_DEBE", obj.N5_DEBE);
                    cmd.Parameters.AddWithValue("@CUENTA_DEBE", obj.CUENTA_DEBE);
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", obj.RAZON_SOCIAL);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(ASIENTO_PAGO_PROV_DEBE obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  ASIENTO_PAGO_PROV_DEBE SET");
                sql.AppendLine("ID=@ID");
                sql.AppendLine(", NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO");
                sql.AppendLine(", HABER=@HABER");
                sql.AppendLine(", PTO_VTA=@PTO_VTA");
                sql.AppendLine(", NRO_CTE=@NRO_CTE");
                sql.AppendLine(", FECHA=@FECHA");
                sql.AppendLine(", CUENTA_GASTO=@CUENTA_GASTO");
                sql.AppendLine(", N5_DEBE=@N5_DEBE");
                sql.AppendLine(", CUENTA_DEBE=@CUENTA_DEBE");
                sql.AppendLine(", RAZON_SOCIAL=@RAZON_SOCIAL");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", obj.NRO_RECIBO_PAGO);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@CUENTA_GASTO", obj.CUENTA_GASTO);
                    cmd.Parameters.AddWithValue("@N5_DEBE", obj.N5_DEBE);
                    cmd.Parameters.AddWithValue("@CUENTA_DEBE", obj.CUENTA_DEBE);
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", obj.RAZON_SOCIAL);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(ASIENTO_PAGO_PROV_DEBE obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  ASIENTO_PAGO_PROV_DEBE ");
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

