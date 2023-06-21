using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class ASIENTO_PROV : DALBase
    {
        public int ID { get; set; }
        public decimal MONTO_ORIGINAL { get; set; }
        public int PTO_VTA { get; set; }
        public Int64 NRO_CTE { get; set; }
        public DateTime FECHA { get; set; }
        public DateTime FECHA_CAE { get; set; }
        public DateTime FECHA_CARGA { get; set; }
        public bool PAGADO { get; set; }
        public int CUENTA_PASIVO { get; set; }
        public string N5_DEBE { get; set; }
        public string CUENTA_DEBE { get; set; }
        public int CUENTA_GASTO { get; set; }
        public string N5_HABER { get; set; }
        public string CUENTA_HABER { get; set; }
        public string OBS { get; set; }
        public string PROVEEDOR { get; set; }

        public ASIENTO_PROV()
        {
            DateTime fec = UTILS.getFechaActual();
            ID = 0;
            MONTO_ORIGINAL = 0;
            PTO_VTA = 0;
            NRO_CTE = 0;
            FECHA = fec;
            FECHA_CAE = fec;
            FECHA_CARGA = fec;
            PAGADO = false;
            CUENTA_PASIVO = 0;
            N5_DEBE = string.Empty;
            CUENTA_DEBE = string.Empty;
            CUENTA_GASTO = 0;
            N5_HABER = string.Empty;
            CUENTA_HABER = string.Empty;
            OBS = string.Empty;
            PROVEEDOR = string.Empty;
        }

        private static List<ASIENTO_PROV> mapeo(SqlDataReader dr)
        {
            List<ASIENTO_PROV> lst = new List<ASIENTO_PROV>();
            ASIENTO_PROV obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new ASIENTO_PROV();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.MONTO_ORIGINAL = dr.GetDecimal(1); }
                    if (!dr.IsDBNull(2)) { obj.PTO_VTA = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.NRO_CTE = dr.GetInt64(3); }
                    if (!dr.IsDBNull(4)) { obj.FECHA = dr.GetDateTime(4); }
                    if (!dr.IsDBNull(5)) { obj.FECHA_CAE = dr.GetDateTime(5); }
                    if (!dr.IsDBNull(6)) { obj.FECHA_CARGA = dr.GetDateTime(6); }
                    if (!dr.IsDBNull(7)) { obj.PAGADO = dr.GetBoolean(7); }
                    if (!dr.IsDBNull(8)) { obj.CUENTA_PASIVO = dr.GetInt32(8); }
                    if (!dr.IsDBNull(9)) { obj.N5_DEBE = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.CUENTA_DEBE = dr.GetString(10); }
                    if (!dr.IsDBNull(11)) { obj.CUENTA_GASTO = dr.GetInt32(11); }
                    if (!dr.IsDBNull(12)) { obj.N5_HABER = dr.GetString(12); }
                    if (!dr.IsDBNull(13)) { obj.CUENTA_HABER = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.OBS = dr.GetString(14); }
                    if (!dr.IsDBNull(15)) { obj.PROVEEDOR = dr.GetString(15); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<ASIENTO_PROV> read()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID, A.MONTO_ORIGINAL, PTO_VTA, A.NRO_CTE,");
                sql.AppendLine("A.FECHA, A.FECHA_CAE, A.FECHA_CARGA, A.PAGADO,");
                sql.AppendLine("D.ID AS CUENTA_PASIVO, D.N5 AS N5_DEBE,");
                sql.AppendLine("D.DESC_SUBCUENTA AS CUENTA_DEBE,");
                sql.AppendLine("C.ID AS CUENTA_GASTO, C.N5 AS N5_HABER,");
                sql.AppendLine("C.DESC_SUBCUENTA AS CUENTA_HABER, A.OBS, E.RAZON_SOCIAL");
                sql.AppendLine("FROM CTACTE_GASTOS A");
                sql.AppendLine("INNER JOIN CUENTAS_X_PROVEEDOR B ON");
                sql.AppendLine("A.ID_PROVEEDOR=B.ID_PROV");
                sql.AppendLine("AND A.ID_PLAN_CUENTA=B.ID_CTA_CONTABLE_GASTO");
                sql.AppendLine("INNER JOIN PLAN_CUENTA C ON");
                sql.AppendLine("C.ID=B.ID_CTA_CONTABLE_GASTO");
                sql.AppendLine("INNER JOIN PLAN_CUENTA D ON");
                sql.AppendLine("B.ID_CTA_CONTABLE_PASIVO=D.ID");
                sql.AppendLine("INNER JOIN PROVEEDORES E ON A.ID_PROVEEDOR=E.ID");
                sql.AppendLine("WHERE TIPO_MOVIMIENTO=1 AND A.ID NOT IN (");
                sql.AppendLine("SELECT REFERENCIA FROM ASIENTOS WHERE TIPO=3)");
                List<ASIENTO_PROV> lst = new List<ASIENTO_PROV>();
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

        public static ASIENTO_PROV getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM ASIENTO_PROV WHERE");
                ASIENTO_PROV obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<ASIENTO_PROV> lst = mapeo(dr);
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

        public static int insert(ASIENTO_PROV obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO ASIENTO_PROV(");
                sql.AppendLine("ID");
                sql.AppendLine(", MONTO_ORIGINAL");
                sql.AppendLine(", PTO_VTA");
                sql.AppendLine(", NRO_CTE");
                sql.AppendLine(", FECHA");
                sql.AppendLine(", FECHA_CAE");
                sql.AppendLine(", FECHA_CARGA");
                sql.AppendLine(", PAGADO");
                sql.AppendLine(", CUENTA_PASIVO");
                sql.AppendLine(", N5_DEBE");
                sql.AppendLine(", CUENTA_DEBE");
                sql.AppendLine(", CUENTA_GASTO");
                sql.AppendLine(", N5_HABER");
                sql.AppendLine(", CUENTA_HABER");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID");
                sql.AppendLine(", @MONTO_ORIGINAL");
                sql.AppendLine(", @PTO_VTA");
                sql.AppendLine(", @NRO_CTE");
                sql.AppendLine(", @FECHA");
                sql.AppendLine(", @FECHA_CAE");
                sql.AppendLine(", @FECHA_CARGA");
                sql.AppendLine(", @PAGADO");
                sql.AppendLine(", @CUENTA_PASIVO");
                sql.AppendLine(", @N5_DEBE");
                sql.AppendLine(", @CUENTA_DEBE");
                sql.AppendLine(", @CUENTA_GASTO");
                sql.AppendLine(", @N5_HABER");
                sql.AppendLine(", @CUENTA_HABER");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@MONTO_ORIGINAL", obj.MONTO_ORIGINAL);
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@FECHA_CAE", obj.FECHA_CAE);
                    cmd.Parameters.AddWithValue("@FECHA_CARGA", obj.FECHA_CARGA);
                    cmd.Parameters.AddWithValue("@PAGADO", obj.PAGADO);
                    cmd.Parameters.AddWithValue("@CUENTA_PASIVO", obj.CUENTA_PASIVO);
                    cmd.Parameters.AddWithValue("@N5_DEBE", obj.N5_DEBE);
                    cmd.Parameters.AddWithValue("@CUENTA_DEBE", obj.CUENTA_DEBE);
                    cmd.Parameters.AddWithValue("@CUENTA_GASTO", obj.CUENTA_GASTO);
                    cmd.Parameters.AddWithValue("@N5_HABER", obj.N5_HABER);
                    cmd.Parameters.AddWithValue("@CUENTA_HABER", obj.CUENTA_HABER);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(ASIENTO_PROV obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  ASIENTO_PROV SET");
                sql.AppendLine("ID=@ID");
                sql.AppendLine(", MONTO_ORIGINAL=@MONTO_ORIGINAL");
                sql.AppendLine(", PTO_VTA=@PTO_VTA");
                sql.AppendLine(", NRO_CTE=@NRO_CTE");
                sql.AppendLine(", FECHA=@FECHA");
                sql.AppendLine(", FECHA_CAE=@FECHA_CAE");
                sql.AppendLine(", FECHA_CARGA=@FECHA_CARGA");
                sql.AppendLine(", PAGADO=@PAGADO");
                sql.AppendLine(", CUENTA_PASIVO=@CUENTA_PASIVO");
                sql.AppendLine(", N5_DEBE=@N5_DEBE");
                sql.AppendLine(", CUENTA_DEBE=@CUENTA_DEBE");
                sql.AppendLine(", CUENTA_GASTO=@CUENTA_GASTO");
                sql.AppendLine(", N5_HABER=@N5_HABER");
                sql.AppendLine(", CUENTA_HABER=@CUENTA_HABER");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@MONTO_ORIGINAL", obj.MONTO_ORIGINAL);
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@FECHA_CAE", obj.FECHA_CAE);
                    cmd.Parameters.AddWithValue("@FECHA_CARGA", obj.FECHA_CARGA);
                    cmd.Parameters.AddWithValue("@PAGADO", obj.PAGADO);
                    cmd.Parameters.AddWithValue("@CUENTA_PASIVO", obj.CUENTA_PASIVO);
                    cmd.Parameters.AddWithValue("@N5_DEBE", obj.N5_DEBE);
                    cmd.Parameters.AddWithValue("@CUENTA_DEBE", obj.CUENTA_DEBE);
                    cmd.Parameters.AddWithValue("@CUENTA_GASTO", obj.CUENTA_GASTO);
                    cmd.Parameters.AddWithValue("@N5_HABER", obj.N5_HABER);
                    cmd.Parameters.AddWithValue("@CUENTA_HABER", obj.CUENTA_HABER);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(ASIENTO_PROV obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  ASIENTO_PROV ");
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

