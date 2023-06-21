using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class FACTURAS_X_EXPENSA : DALBase
    {
        public int PTO_VTA { get; set; }
        public Int64 NRO_CTE { get; set; }
        public Int64 CAE { get; set; }
        public DateTime FECHA_CAE { get; set; }
        public DateTime VENC_CAE { get; set; }
        public int NRO_CTA { get; set; }
        public int PERIODO { get; set; }
        public bool PAGADO { get; set; }
        public int ID_CTACTE { get; set; }
        public int TIPO_COMPROBANTE { get; set; }
        public decimal MONTO { get; set; }
        public string DETALLE { get; set; }
        public int ID_COMPROBANTE { get; set; }
        public string CUIT { get; set; }
        public string NOMBRE { get; set; }
        public int ID_CTA_DEBE { get; set; }
        public int ID_CTA_HABER { get; set; }

        public FACTURAS_X_EXPENSA()
        {
            PTO_VTA = 0;
            NRO_CTE = 0;
            CAE = 0;
            FECHA_CAE = UTILS.getFechaActual();
            VENC_CAE = UTILS.getFechaActual();
            NRO_CTA = 0;
            PERIODO = 0;
            PAGADO = false;
            ID_CTACTE = 0;
            TIPO_COMPROBANTE = 0;
            MONTO = 0;
            DETALLE = string.Empty;
            ID_COMPROBANTE = 0;
            CUIT = string.Empty;
            NOMBRE = string.Empty;
            ID_CTA_DEBE = 0;
            ID_CTA_HABER = 0;
        }

        private static List<FACTURAS_X_EXPENSA> mapeo(SqlDataReader dr)
        {
            List<FACTURAS_X_EXPENSA> lst = new List<FACTURAS_X_EXPENSA>();
            FACTURAS_X_EXPENSA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new FACTURAS_X_EXPENSA();
                    if (!dr.IsDBNull(0)) { obj.PTO_VTA = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTE = dr.GetInt64(1); }
                    if (!dr.IsDBNull(2)) { obj.CAE = dr.GetInt64(2); }
                    if (!dr.IsDBNull(3)) { obj.FECHA_CAE = dr.GetDateTime(3); }
                    if (!dr.IsDBNull(4)) { obj.VENC_CAE = dr.GetDateTime(4); }
                    if (!dr.IsDBNull(5)) { obj.NRO_CTA = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.PERIODO = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.PAGADO = dr.GetBoolean(7); }
                    if (!dr.IsDBNull(8)) { obj.ID_CTACTE = dr.GetInt32(8); }
                    if (!dr.IsDBNull(9)) { obj.TIPO_COMPROBANTE = dr.GetInt32(9); }
                    if (!dr.IsDBNull(10)) { obj.MONTO = dr.GetDecimal(10); }
                    if (!dr.IsDBNull(11)) { obj.DETALLE = dr.GetString(11); }
                    if (!dr.IsDBNull(12)) { obj.ID_COMPROBANTE = dr.GetInt32(12); }
                    if (!dr.IsDBNull(13)) { obj.CUIT = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.NOMBRE = dr.GetString(14); }
                    if (!dr.IsDBNull(15)) { obj.ID_CTA_DEBE = dr.GetInt32(15); }
                    if (!dr.IsDBNull(16)) { obj.ID_CTA_HABER = dr.GetInt32(16); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<FACTURAS_X_EXPENSA> read()
        {
            try
            {
                List<FACTURAS_X_EXPENSA> lst = new List<FACTURAS_X_EXPENSA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM FACTURAS_X_EXPENSA";
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
        public static List<FACTURAS_X_EXPENSA> readNoPropietario()
        {
            try
            {
                List<FACTURAS_X_EXPENSA> lst = new List<FACTURAS_X_EXPENSA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM FACTURAS_X_EXPENSA WHERE NRO_CTA=0";
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
        public static List<FACTURAS_X_EXPENSA> read(int nroCta, int periodo)
        {
            try
            {
                List<FACTURAS_X_EXPENSA> lst = new List<FACTURAS_X_EXPENSA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM FACTURAS_X_EXPENSA WHERE NRO_CTA=@NRO_CTA AND PERIODO=@PERIODO";
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
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
        public static List<FACTURAS_X_EXPENSA> readNotasCredito()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM FACTURAS_X_EXPENSA");
                sql.AppendLine("WHERE ID_CTACTE NOT IN (");
                sql.AppendLine("SELECT REFERENCIA");
                sql.AppendLine("FROM ASIENTOS WHERE TIPO = 2");
                sql.AppendLine(") AND TIPO_COMPROBANTE = 13");
                List<FACTURAS_X_EXPENSA> lst = new List<FACTURAS_X_EXPENSA>();
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
        public static List<FACTURAS_X_EXPENSA> readNC(int nroCta, int periodo)
        {
            try
            {
                List<FACTURAS_X_EXPENSA> lst = new List<FACTURAS_X_EXPENSA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM FACTURAS_X_EXPENSA WHERE NRO_CTA=@NRO_CTA AND PERIODO=@PERIODO AND TIPO_COMPROBANTE=13";
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
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

        public static Int64 getMaxNotaDebitoInterna()
        {
            try
            {
                List<FACTURAS_X_EXPENSA> lst = new List<FACTURAS_X_EXPENSA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT ISNULL(MAX(NRO_CTE), 0) FROM FACTURAS_X_EXPENSA WHERE TIPO_COMPROBANTE=21";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Int64 nroCte = 0;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (!dr.IsDBNull(0)) { nroCte = dr.GetInt64(0); }
                        }
                    }
                    return nroCte;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Int64 getMaxNotaCreditoInterna()
        {
            try
            {
                List<FACTURAS_X_EXPENSA> lst = new List<FACTURAS_X_EXPENSA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT ISNULL(MAX(NRO_CTE), 0) FROM FACTURAS_X_EXPENSA WHERE TIPO_COMPROBANTE=31";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Int64 nroCte = 0;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (!dr.IsDBNull(0)) { nroCte = dr.GetInt64(0); }
                        }
                    }
                    return nroCte;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static FACTURAS_X_EXPENSA getByPk(int ptoVta, Int64 nroCte, int tipoCbt)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM FACTURAS_X_EXPENSA WHERE");
                sql.AppendLine("PTO_VTA =@PTO_VTA AND NRO_CTE=@NRO_CTE");
                sql.AppendLine("AND TIPO_COMPROBANTE=@TIPO_COMPROBANTE");
                FACTURAS_X_EXPENSA obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PTO_VTA", ptoVta);
                    cmd.Parameters.AddWithValue("@NRO_CTE", nroCte);
                    cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE", tipoCbt);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<FACTURAS_X_EXPENSA> lst = mapeo(dr);
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

        public static void insert(FACTURAS_X_EXPENSA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO FACTURAS_X_EXPENSA(");
                sql.AppendLine("PTO_VTA");
                sql.AppendLine(", NRO_CTE");
                sql.AppendLine(", CAE");
                sql.AppendLine(", FECHA_CAE");
                sql.AppendLine(", VENC_CAE");
                sql.AppendLine(", NRO_CTA");
                sql.AppendLine(", PERIODO");
                sql.AppendLine(", PAGADO");
                sql.AppendLine(", ID_CTACTE");
                sql.AppendLine(", TIPO_COMPROBANTE");
                sql.AppendLine(", MONTO");
                sql.AppendLine(", DETALLE");
                sql.AppendLine(", ID_COMPROBANTE");
                sql.AppendLine(", CUIT");
                sql.AppendLine(", NOMBRE");
                sql.AppendLine(", ID_CTA_DEBE");
                sql.AppendLine(", ID_CTA_HABER");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@PTO_VTA");
                sql.AppendLine(", @NRO_CTE");
                sql.AppendLine(", @CAE");
                sql.AppendLine(", @FECHA_CAE");
                sql.AppendLine(", @VENC_CAE");
                sql.AppendLine(", @NRO_CTA");
                sql.AppendLine(", @PERIODO");
                sql.AppendLine(", @PAGADO");
                sql.AppendLine(", @ID_CTACTE");
                sql.AppendLine(", @TIPO_COMPROBANTE");
                sql.AppendLine(", @MONTO");
                sql.AppendLine(", @DETALLE");
                sql.AppendLine(", @ID_COMPROBANTE");
                sql.AppendLine(", @CUIT");
                sql.AppendLine(", @NOMBRE");
                sql.AppendLine(", @ID_CTA_DEBE");
                sql.AppendLine(", @ID_CTA_HABER");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@CAE", obj.CAE);
                    cmd.Parameters.AddWithValue("@FECHA_CAE", obj.FECHA_CAE);
                    cmd.Parameters.AddWithValue("@VENC_CAE", obj.VENC_CAE);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@PERIODO", obj.PERIODO);
                    cmd.Parameters.AddWithValue("@PAGADO", obj.PAGADO);
                    cmd.Parameters.AddWithValue("@ID_CTACTE", obj.ID_CTACTE);
                    cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE", obj.TIPO_COMPROBANTE);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Parameters.AddWithValue("@DETALLE", obj.DETALLE);
                    cmd.Parameters.AddWithValue("@ID_COMPROBANTE", obj.ID_COMPROBANTE);
                    cmd.Parameters.AddWithValue("@CUIT", obj.CUIT);
                    cmd.Parameters.AddWithValue("@NOMBRE", obj.NOMBRE);
                    cmd.Parameters.AddWithValue("@ID_CTA_DEBE", obj.ID_CTA_DEBE);
                    cmd.Parameters.AddWithValue("@ID_CTA_HABER", obj.ID_CTA_HABER);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(FACTURAS_X_EXPENSA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  FACTURAS_X_EXPENSA SET");
                sql.AppendLine("PTO_VTA=@PTO_VTA");
                sql.AppendLine(", NRO_CTE=@NRO_CTE");
                sql.AppendLine(", CAE=@CAE");
                sql.AppendLine(", FECHA_CAE=@FECHA_CAE");
                sql.AppendLine(", VENC_CAE=@VENC_CAE");
                sql.AppendLine(", NRO_CTA=@NRO_CTA");
                sql.AppendLine(", PERIODO=@PERIODO");
                sql.AppendLine(", PAGADO=@PAGADO");
                sql.AppendLine(", ID_CTACTE=@ID_CTACTE");
                sql.AppendLine(", TIPO_COMPROBANTE=@TIPO_COMPROBANTE");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@CAE", obj.CAE);
                    cmd.Parameters.AddWithValue("@FECHA_CAE", obj.FECHA_CAE);
                    cmd.Parameters.AddWithValue("@VENC_CAE", obj.VENC_CAE);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@PERIODO", obj.PERIODO);
                    cmd.Parameters.AddWithValue("@PAGADO", obj.PAGADO);
                    cmd.Parameters.AddWithValue("@ID_CTACTE", obj.ID_CTACTE);
                    cmd.Parameters.AddWithValue("@TIPO_COMPROBANTE", obj.TIPO_COMPROBANTE);
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

