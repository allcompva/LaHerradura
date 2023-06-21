using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class IVA_VENTAS : DALBase
    {
        public DateTime FECHA_CAE { get; set; }
        public int TIPO_COMPROBANTE { get; set; }
        public string PTO_VTA { get; set; }
        public string NRO_CTE { get; set; }
        public int NRO_CTA { get; set; }
        public string DETALLE { get; set; }
        public decimal MONTO { get; set; }

        public IVA_VENTAS()
        {
            FECHA_CAE = UTILS.getFechaActual();
            TIPO_COMPROBANTE = 0;
            PTO_VTA = string.Empty;
            NRO_CTE = string.Empty;
            NRO_CTA = 0;
            DETALLE = string.Empty;
            MONTO = 0;
        }

        private static List<IVA_VENTAS> mapeo(SqlDataReader dr)
        {
            List<IVA_VENTAS> lst = new List<IVA_VENTAS>();
            IVA_VENTAS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new IVA_VENTAS();
                    if (!dr.IsDBNull(0)) { obj.FECHA_CAE = dr.GetDateTime(0); }
                    if (!dr.IsDBNull(1)) { obj.TIPO_COMPROBANTE = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.PTO_VTA = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.NRO_CTE = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.NRO_CTA = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.DETALLE = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.MONTO = dr.GetDecimal(6); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<IVA_VENTAS> read(int anio, int mes)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.FECHA_CAE, A.TIPO_COMPROBANTE,");
                sql.AppendLine("RIGHT('0000'+CAST(A.PTO_VTA AS VARCHAR(4)),4) AS PTO_VTA,");
                sql.AppendLine("RIGHT('00000000'+CAST(A.NRO_CTE AS VARCHAR(8)),8) AS NRO_CTE,");
                sql.AppendLine("A.NRO_CTA, A.DETALLE, A.MONTO");
                sql.AppendLine("FROM FACTURAS_X_EXPENSA A");
                sql.AppendLine("WHERE MONTH(FECHA_CAE)=@MES AND YEAR(FECHA_CAE)=@ANIO");
                sql.AppendLine("AND TIPO_COMPROBANTE IN (11,12,13)");
                sql.AppendLine("ORDER BY FECHA_CAE");

                List<IVA_VENTAS> lst = new List<IVA_VENTAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ANIO", anio);
                    cmd.Parameters.AddWithValue("@MES", mes);
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

        public static IVA_VENTAS getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM IVA_VENTAS WHERE");
                IVA_VENTAS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<IVA_VENTAS> lst = mapeo(dr);
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

        public static int insert(IVA_VENTAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO IVA_VENTAS(");
                sql.AppendLine("FECHA_CAE");
                sql.AppendLine(", TIPO_COMPROBANTE");
                sql.AppendLine(", PTO_VTA");
                sql.AppendLine(", NRO_CTE");
                sql.AppendLine(", NRO_CTA");
                sql.AppendLine(", DETALLE");
                sql.AppendLine(", MONTO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@FECHA_CAE");
                sql.AppendLine(", @TIPO_COMPROBANTE");
                sql.AppendLine(", @PTO_VTA");
                sql.AppendLine(", @NRO_CTE");
                sql.AppendLine(", @NRO_CTA");
                sql.AppendLine(", @DETALLE");
                sql.AppendLine(", @MONTO");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@FECHA_CAE", obj.FECHA_CAE);
                    cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE", obj.TIPO_COMPROBANTE);
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@DETALLE", obj.DETALLE);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(IVA_VENTAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  IVA_VENTAS SET");
                sql.AppendLine("FECHA_CAE=@FECHA_CAE");
                sql.AppendLine(", TIPO_COMPROBANTE=@TIPO_COMPROBANTE");
                sql.AppendLine(", PTO_VTA=@PTO_VTA");
                sql.AppendLine(", NRO_CTE=@NRO_CTE");
                sql.AppendLine(", NRO_CTA=@NRO_CTA");
                sql.AppendLine(", DETALLE=@DETALLE");
                sql.AppendLine(", MONTO=@MONTO");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@FECHA_CAE", obj.FECHA_CAE);
                    cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE", obj.TIPO_COMPROBANTE);
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@DETALLE", obj.DETALLE);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(IVA_VENTAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  IVA_VENTAS ");
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

