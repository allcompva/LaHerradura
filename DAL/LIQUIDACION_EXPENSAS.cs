using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DAL
{
    public class LIQUIDACION_EXPENSAS : DALBase
    {
        public int PERIODO { get; set; }
        public DateTime VENCIMIENTO_1 { get; set; }
        public decimal MONTO_1 { get; set; }
        public DateTime VENCIMIENTO_2 { get; set; }
        public decimal MONTO_2 { get; set; }
        public DateTime VENCIMIENTO_3 { get; set; }
        public decimal MONTO_3 { get; set; }
        public decimal ALICUOTA_INTERES { get; set; }
        public int CANT_CTAS_CTES { get; set; }
        public decimal TOTAL_LIQUIDADO { get; set; }
        public int USUARIO_GENERA { get; set; }
        public DateTime FECHA_GENERA { get; set; }
        public int USUARIO_LIQUIDA { get; set; }
        public DateTime FECHA_LIQUIDA { get; set; }
        public int USUARIO_FACTURA { get; set; }
        public DateTime FECHA_FACTURA { get; set; }
        public int ESTADO { get; set; }

        public string venc1_corto { get; set; }
        public string venc2_corto { get; set; }
        public string venc3_corto { get; set; }

        public string NOTA_FACTURA { get; set; }
        public string PERIODO_MAQUILLADO { get; set; }

        public LIQUIDACION_EXPENSAS()
        {
            DateTime fec = UTILS.getFechaActual();
            PERIODO = 0;
            VENCIMIENTO_1 = fec;
            MONTO_1 = 0;
            VENCIMIENTO_2 = fec;
            MONTO_2 = 0;
            VENCIMIENTO_3 = fec;
            MONTO_3 = 0;
            ALICUOTA_INTERES = 0;
            CANT_CTAS_CTES = 0;
            TOTAL_LIQUIDADO = 0;
            USUARIO_GENERA = 0;
            FECHA_GENERA = fec;
            USUARIO_LIQUIDA = 0;
            FECHA_LIQUIDA = fec;
            USUARIO_FACTURA = 0;
            FECHA_FACTURA = fec;
            ESTADO = 0;
            NOTA_FACTURA = string.Empty;
        }

        private static List<LIQUIDACION_EXPENSAS> mapeo(SqlDataReader dr)
        {
            List<LIQUIDACION_EXPENSAS> lst = new List<LIQUIDACION_EXPENSAS>();
            LIQUIDACION_EXPENSAS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new LIQUIDACION_EXPENSAS();
                    if (!dr.IsDBNull(0)) { obj.PERIODO = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.VENCIMIENTO_1 = dr.GetDateTime(1); }
                    if (!dr.IsDBNull(2)) { obj.MONTO_1 = dr.GetDecimal(2); }
                    if (!dr.IsDBNull(3)) { obj.VENCIMIENTO_2 = dr.GetDateTime(3); }
                    if (!dr.IsDBNull(4)) { obj.MONTO_2 = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.VENCIMIENTO_3 = dr.GetDateTime(5); }
                    if (!dr.IsDBNull(6)) { obj.MONTO_3 = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.ALICUOTA_INTERES = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.CANT_CTAS_CTES = dr.GetInt32(8); }
                    if (!dr.IsDBNull(9)) { obj.TOTAL_LIQUIDADO = dr.GetDecimal(9); }
                    if (!dr.IsDBNull(10)) { obj.USUARIO_GENERA = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.FECHA_GENERA = dr.GetDateTime(11); }
                    if (!dr.IsDBNull(12)) { obj.USUARIO_LIQUIDA = dr.GetInt32(12); }
                    if (!dr.IsDBNull(13)) { obj.FECHA_LIQUIDA = dr.GetDateTime(13); }
                    if (!dr.IsDBNull(14)) { obj.USUARIO_FACTURA = dr.GetInt32(14); }
                    if (!dr.IsDBNull(15)) { obj.FECHA_FACTURA = dr.GetDateTime(15); }
                    if (!dr.IsDBNull(16)) { obj.ESTADO = dr.GetInt32(16); }
                    if (!dr.IsDBNull(17)) { obj.NOTA_FACTURA = dr.GetString(17); }
                    obj.venc1_corto = obj.VENCIMIENTO_1.ToShortDateString();
                    obj.venc2_corto = obj.VENCIMIENTO_2.ToShortDateString();
                    obj.venc3_corto = obj.VENCIMIENTO_3.ToShortDateString();
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<LIQUIDACION_EXPENSAS> getPeriodosNoFacturados(
            int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT PERIODO, VENCIMIENTO_3 FROM LIQUIDACION_EXPENSAS");
                sql.AppendLine("WHERE PERIODO NOT IN (");
                sql.AppendLine("SELECT PERIODO FROM CTACTE_EXPENSAS WHERE");
                sql.AppendLine("NRO_CTA = @NRO_CTA AND TIPO_MOVIMIENTO = 1)");

                List<LIQUIDACION_EXPENSAS> lst = new List<LIQUIDACION_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            LIQUIDACION_EXPENSAS obj = new LIQUIDACION_EXPENSAS();
                            if (!dr.IsDBNull(0))
                            {
                                obj.PERIODO = dr.GetInt32(0);
                                obj.VENCIMIENTO_3 = dr.GetDateTime(1);
                                obj.PERIODO_MAQUILLADO = 
                                    UTILS.getNombrePeriodo(obj.PERIODO, nroCta);
                                lst.Add(obj);
                            }                            
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

        public static List<LIQUIDACION_EXPENSAS> read()
        {
            try
            {
                List<LIQUIDACION_EXPENSAS> lst = new List<LIQUIDACION_EXPENSAS>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM LIQUIDACION_EXPENSAS ORDER BY PERIODO DESC";
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

        public static LIQUIDACION_EXPENSAS getByPk(
        int PERIODO)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM LIQUIDACION_EXPENSAS WHERE");
                sql.AppendLine("PERIODO = @PERIODO");
                LIQUIDACION_EXPENSAS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", PERIODO);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<LIQUIDACION_EXPENSAS> lst = mapeo(dr);
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

        public static void insert(LIQUIDACION_EXPENSAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO LIQUIDACION_EXPENSAS(");
                sql.AppendLine("PERIODO");
                sql.AppendLine(", VENCIMIENTO_1");
                sql.AppendLine(", MONTO_1");
                sql.AppendLine(", VENCIMIENTO_2");
                sql.AppendLine(", MONTO_2");
                sql.AppendLine(", VENCIMIENTO_3");
                sql.AppendLine(", MONTO_3");
                sql.AppendLine(", ALICUOTA_INTERES");
                sql.AppendLine(", CANT_CTAS_CTES");
                sql.AppendLine(", TOTAL_LIQUIDADO");
                sql.AppendLine(", USUARIO_GENERA");
                sql.AppendLine(", FECHA_GENERA");
                sql.AppendLine(", ESTADO");
                sql.AppendLine(", NOTA_FACTURA");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@PERIODO");
                sql.AppendLine(", @VENCIMIENTO_1");
                sql.AppendLine(", @MONTO_1");
                sql.AppendLine(", @VENCIMIENTO_2");
                sql.AppendLine(", @MONTO_2");
                sql.AppendLine(", @VENCIMIENTO_3");
                sql.AppendLine(", @MONTO_3");
                sql.AppendLine(", @ALICUOTA_INTERES");
                sql.AppendLine(", @CANT_CTAS_CTES");
                sql.AppendLine(", @TOTAL_LIQUIDADO");
                sql.AppendLine(", @USUARIO_GENERA");
                sql.AppendLine(", @FECHA_GENERA");
                sql.AppendLine(", @ESTADO");
                sql.AppendLine(", @NOTA_FACTURA");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", obj.PERIODO);
                    cmd.Parameters.AddWithValue("@VENCIMIENTO_1", obj.VENCIMIENTO_1);
                    cmd.Parameters.AddWithValue("@MONTO_1", obj.MONTO_1);
                    cmd.Parameters.AddWithValue("@VENCIMIENTO_2", obj.VENCIMIENTO_2);
                    cmd.Parameters.AddWithValue("@MONTO_2", obj.MONTO_2);
                    cmd.Parameters.AddWithValue("@VENCIMIENTO_3", obj.VENCIMIENTO_3);
                    cmd.Parameters.AddWithValue("@MONTO_3", obj.MONTO_3);
                    cmd.Parameters.AddWithValue("@ALICUOTA_INTERES", obj.ALICUOTA_INTERES);
                    cmd.Parameters.AddWithValue("@CANT_CTAS_CTES", obj.CANT_CTAS_CTES);
                    cmd.Parameters.AddWithValue("@TOTAL_LIQUIDADO", obj.TOTAL_LIQUIDADO);
                    cmd.Parameters.AddWithValue("@USUARIO_GENERA", obj.USUARIO_GENERA);
                    cmd.Parameters.AddWithValue("@FECHA_GENERA", obj.FECHA_GENERA);
                    cmd.Parameters.AddWithValue("@ESTADO", obj.ESTADO);
                    cmd.Parameters.AddWithValue("@NOTA_FACTURA", obj.NOTA_FACTURA);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(LIQUIDACION_EXPENSAS obj, int periodoNuevo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  LIQUIDACION_EXPENSAS SET");
                sql.AppendLine("VENCIMIENTO_1=@VENCIMIENTO_1");
                sql.AppendLine(", MONTO_1=@MONTO_1");
                sql.AppendLine(", VENCIMIENTO_2=@VENCIMIENTO_2");
                sql.AppendLine(", MONTO_2=@MONTO_2");
                sql.AppendLine(", VENCIMIENTO_3=@VENCIMIENTO_3");
                sql.AppendLine(", MONTO_3=@MONTO_3");
                sql.AppendLine(", ALICUOTA_INTERES=@ALICUOTA_INTERES");
                sql.AppendLine(", PERIODO=@PERIODO_NUEVO");
                sql.AppendLine(", NOTA_FACTURA=@NOTA_FACTURA");
                sql.AppendLine("WHERE");
                sql.AppendLine("PERIODO=@PERIODO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO_NUEVO", periodoNuevo);
                    cmd.Parameters.AddWithValue("@PERIODO", obj.PERIODO);
                    cmd.Parameters.AddWithValue("@VENCIMIENTO_1", obj.VENCIMIENTO_1);
                    cmd.Parameters.AddWithValue("@MONTO_1", obj.MONTO_1);
                    cmd.Parameters.AddWithValue("@VENCIMIENTO_2", obj.VENCIMIENTO_2);
                    cmd.Parameters.AddWithValue("@MONTO_2", obj.MONTO_2);
                    cmd.Parameters.AddWithValue("@VENCIMIENTO_3", obj.VENCIMIENTO_3);
                    cmd.Parameters.AddWithValue("@MONTO_3", obj.MONTO_3);
                    cmd.Parameters.AddWithValue("@ALICUOTA_INTERES", obj.ALICUOTA_INTERES);
                    cmd.Parameters.AddWithValue("@NOTA_FACTURA", obj.NOTA_FACTURA);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void updateLiquida(int periodo, int estado, int cantCtas, decimal tot, int usuario)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  LIQUIDACION_EXPENSAS SET");
                sql.AppendLine("ESTADO=@ESTADO");
                sql.AppendLine(", CANT_CTAS_CTES=@CANT_CTAS_CTES");
                sql.AppendLine(", TOTAL_LIQUIDADO=@TOTAL_LIQUIDADO");
                sql.AppendLine(", USUARIO_LIQUIDA=@USUARIO_LIQUIDA");
                sql.AppendLine(", FECHA_LIQUIDA=@FECHA_LIQUIDA");
                sql.AppendLine("WHERE");
                sql.AppendLine("PERIODO=@PERIODO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ESTADO", estado);
                    cmd.Parameters.AddWithValue("@CANT_CTAS_CTES", cantCtas);
                    cmd.Parameters.AddWithValue("@TOTAL_LIQUIDADO", tot);
                    cmd.Parameters.AddWithValue("@USUARIO_LIQUIDA", usuario);
                    cmd.Parameters.AddWithValue("@FECHA_LIQUIDA", UTILS.getFechaActual());
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);


                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void updateLiquida(int periodo, int estado)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE LIQUIDACION_EXPENSAS SET");
                sql.AppendLine("ESTADO=@ESTADO");
                sql.AppendLine("WHERE");
                sql.AppendLine("PERIODO=@PERIODO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ESTADO", estado);
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);


                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void updateLiquida(int periodo)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  LIQUIDACION_EXPENSAS SET");
                sql.AppendLine("ESTADO=0");
                sql.AppendLine(", CANT_CTAS_CTES=NULL");
                sql.AppendLine(", TOTAL_LIQUIDADO=NULL");
                sql.AppendLine(", USUARIO_LIQUIDA=NULL");
                sql.AppendLine(", FECHA_LIQUIDA=NULL");
                sql.AppendLine("WHERE");
                sql.AppendLine("PERIODO=@PERIODO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Parameters.AddWithValue("@PERIODO", periodo);


                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void setNota(int periodo, string nota)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  LIQUIDACION_EXPENSAS SET");
                sql.AppendLine("NOTA_FACTURA=@NOTA_FACTURA");
                sql.AppendLine("WHERE");
                sql.AppendLine("PERIODO=@PERIODO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NOTA_FACTURA", nota);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(int periodo)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.CONCEPTOS_X_LIQUIDACION.delete(periodo, 1);
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("DELETE  LIQUIDACION_EXPENSAS ");
                    sql.AppendLine("WHERE");
                    sql.AppendLine("PERIODO=@PERIODO");
                    using (SqlConnection con = GetConnection())
                    {
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = sql.ToString();
                        cmd.Parameters.AddWithValue("@PERIODO", periodo);
                        cmd.Connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

