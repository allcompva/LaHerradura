using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class MOV_CTA_GASTOS : DALBase
    {
        public int ID_PROVEEDOR { get; set; }
        public string NOMBRE_FANTASIA { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public DateTime FECHA { get; set; }
        public string TIPO_MOVIMIENTO { get; set; }
        public string FACTURA { get; set; }
        public int RECIBO_PAGO { get; set; }
        public decimal DEBE { get; set; }
        public decimal HABER { get; set; }

        public MOV_CTA_GASTOS()
        {
            ID_PROVEEDOR = 0;
            NOMBRE_FANTASIA = string.Empty;
            RAZON_SOCIAL = string.Empty;
            FECHA = UTILS.getFechaActual();
            TIPO_MOVIMIENTO = string.Empty;
            FACTURA = string.Empty;
            RECIBO_PAGO = 0;
            DEBE = 0;
            HABER = 0;
        }

        private static List<MOV_CTA_GASTOS> mapeo(SqlDataReader dr)
        {
            List<MOV_CTA_GASTOS> lst = new List<MOV_CTA_GASTOS>();
            MOV_CTA_GASTOS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new MOV_CTA_GASTOS();
                    if (!dr.IsDBNull(0)) { obj.ID_PROVEEDOR = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NOMBRE_FANTASIA = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.RAZON_SOCIAL = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.FECHA = dr.GetDateTime(3); }
                    if (!dr.IsDBNull(4)) { obj.TIPO_MOVIMIENTO = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.FACTURA = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.RECIBO_PAGO = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.DEBE = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.HABER = dr.GetDecimal(8); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<MOV_CTA_GASTOS> read(int idProveedor)
        {
            try
            {
                List<MOV_CTA_GASTOS> lst = new List<MOV_CTA_GASTOS>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT a.ID_PROVEEDOR, B.NOMBRE_FANTASIA, B.RAZON_SOCIAL,");
                sql.AppendLine("CASE A.TIPO_MOVIMIENTO");
                sql.AppendLine("WHEN 1 THEN FECHA_CAE");
                sql.AppendLine("WHEN 2 THEN FECHA");
                sql.AppendLine("END AS FECHA,");
                sql.AppendLine("CASE A.TIPO_MOVIMIENTO");
                sql.AppendLine("WHEN 1 THEN 'FACTURA'");
                sql.AppendLine("WHEN 2 THEN 'PAGO'");
                sql.AppendLine("END AS TIPO_MOVIMIENTO,");
                sql.AppendLine("RIGHT('0000' + Ltrim(Rtrim(A.PTO_VTA)),4) + '-' +");
                sql.AppendLine("RIGHT('0000000000' + Ltrim(Rtrim(A.NRO_CTE)),10) AS FACTURA,");
                sql.AppendLine("CASE A.TIPO_MOVIMIENTO");
                sql.AppendLine("WHEN 1 THEN '-'");
                sql.AppendLine("WHEN 2 THEN NRO_RECIBO_PAGO");
                sql.AppendLine("END AS RECIBO_PAGO,");
                sql.AppendLine("CASE A.TIPO_MOVIMIENTO");
                sql.AppendLine("WHEN 1 THEN MONTO_ORIGINAL");
                sql.AppendLine("WHEN 2 THEN 0");
                sql.AppendLine("END AS DEBE,");
                sql.AppendLine("CASE A.TIPO_MOVIMIENTO");
                sql.AppendLine("WHEN 1 THEN 0");
                sql.AppendLine("WHEN 2 THEN HABER");
                sql.AppendLine("END AS HABER");
                sql.AppendLine("FROM CTACTE_GASTOS A");
                sql.AppendLine("INNER JOIN PROVEEDORES B ON A.ID_PROVEEDOR=B.ID");
                sql.AppendLine("WHERE A.ID_PROVEEDOR=@ID_PROVEEDOR AND TIPO_MOVIMIENTO <> 10");
                sql.AppendLine("ORDER BY A.PTO_VTA, A.NRO_CTE, TIPO_MOVIMIENTO");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
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

        public static MOV_CTA_GASTOS getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM MOV_CTA_GASTOS WHERE");
                MOV_CTA_GASTOS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<MOV_CTA_GASTOS> lst = mapeo(dr);
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

        public static int insert(MOV_CTA_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO MOV_CTA_GASTOS(");
                sql.AppendLine("ID_PROVEEDOR");
                sql.AppendLine(", NOMBRE_FANTASIA");
                sql.AppendLine(", RAZON_SOCIAL");
                sql.AppendLine(", FECHA");
                sql.AppendLine(", TIPO_MOVIMIENTO");
                sql.AppendLine(", FACTURA");
                sql.AppendLine(", RECIBO_PAGO");
                sql.AppendLine(", DEBE");
                sql.AppendLine(", HABER");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID_PROVEEDOR");
                sql.AppendLine(", @NOMBRE_FANTASIA");
                sql.AppendLine(", @RAZON_SOCIAL");
                sql.AppendLine(", @FECHA");
                sql.AppendLine(", @TIPO_MOVIMIENTO");
                sql.AppendLine(", @FACTURA");
                sql.AppendLine(", @RECIBO_PAGO");
                sql.AppendLine(", @DEBE");
                sql.AppendLine(", @HABER");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", obj.ID_PROVEEDOR);
                    cmd.Parameters.AddWithValue("@NOMBRE_FANTASIA", obj.NOMBRE_FANTASIA);
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", obj.RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", obj.TIPO_MOVIMIENTO);
                    cmd.Parameters.AddWithValue("@FACTURA", obj.FACTURA);
                    cmd.Parameters.AddWithValue("@RECIBO_PAGO", obj.RECIBO_PAGO);
                    cmd.Parameters.AddWithValue("@DEBE", obj.DEBE);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(MOV_CTA_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  MOV_CTA_GASTOS SET");
                sql.AppendLine("ID_PROVEEDOR=@ID_PROVEEDOR");
                sql.AppendLine(", NOMBRE_FANTASIA=@NOMBRE_FANTASIA");
                sql.AppendLine(", RAZON_SOCIAL=@RAZON_SOCIAL");
                sql.AppendLine(", FECHA=@FECHA");
                sql.AppendLine(", TIPO_MOVIMIENTO=@TIPO_MOVIMIENTO");
                sql.AppendLine(", FACTURA=@FACTURA");
                sql.AppendLine(", RECIBO_PAGO=@RECIBO_PAGO");
                sql.AppendLine(", DEBE=@DEBE");
                sql.AppendLine(", HABER=@HABER");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", obj.ID_PROVEEDOR);
                    cmd.Parameters.AddWithValue("@NOMBRE_FANTASIA", obj.NOMBRE_FANTASIA);
                    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", obj.RAZON_SOCIAL);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", obj.TIPO_MOVIMIENTO);
                    cmd.Parameters.AddWithValue("@FACTURA", obj.FACTURA);
                    cmd.Parameters.AddWithValue("@RECIBO_PAGO", obj.RECIBO_PAGO);
                    cmd.Parameters.AddWithValue("@DEBE", obj.DEBE);
                    cmd.Parameters.AddWithValue("@HABER", obj.HABER);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(MOV_CTA_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  MOV_CTA_GASTOS ");
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

