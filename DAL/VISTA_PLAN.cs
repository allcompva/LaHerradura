using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class VISTA_PLAN : DALBase
    {
        public int ID { get; set; }
        public int CUENTA { get; set; }
        public string RESPONSABLE { get; set; }
        public DateTime FECHA_PLAN { get; set; }
        public string SIST_AMORTIZACION { get; set; }
        public decimal MONTO_A_FINANCIAR { get; set; }
        public decimal TNA { get; set; }
        public int CUOTAS { get; set; }
        public decimal INTERES { get; set; }
        public decimal SALDO { get; set; }
        public DateTime PRIMERA_CUOTA { get; set; }
        public int CUOTAS_PAGAS { get; set; }
        public int CUOTAS_ADEUDADAS { get; set; }
        public int CUOTAS_VENCIDAS { get; set; }
        public int ESTADO { get; set; }
        public decimal MONTO_PAGADO { get; set; }

        public VISTA_PLAN()
        {
            ID = 0;
            CUENTA = 0;
            RESPONSABLE = string.Empty;
            FECHA_PLAN = UTILS.getFechaActual();
            SIST_AMORTIZACION = string.Empty;
            MONTO_A_FINANCIAR = 0;
            TNA = 0;
            CUOTAS = 0;
            INTERES = 0;
            SALDO = 0;
            PRIMERA_CUOTA = UTILS.getFechaActual();
            CUOTAS_PAGAS = 0;
            CUOTAS_ADEUDADAS = 0;
            CUOTAS_VENCIDAS = 0;
            ESTADO = 0;
            MONTO_PAGADO = 0;
        }

        private static List<VISTA_PLAN> mapeo(SqlDataReader dr)
        {
            List<VISTA_PLAN> lst = new List<VISTA_PLAN>();
            VISTA_PLAN obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new VISTA_PLAN();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.CUENTA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.RESPONSABLE = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.FECHA_PLAN = dr.GetDateTime(3); }
                    if (!dr.IsDBNull(4)) { obj.SIST_AMORTIZACION = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.MONTO_A_FINANCIAR = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.TNA = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.CUOTAS = dr.GetInt32(7); }
                    if (!dr.IsDBNull(8)) { obj.INTERES = dr.GetDecimal(8); }
                    if (!dr.IsDBNull(9)) { obj.SALDO = dr.GetDecimal(9); }
                    if (!dr.IsDBNull(10)) { obj.PRIMERA_CUOTA = dr.GetDateTime(10); }
                    if (!dr.IsDBNull(11)) { obj.CUOTAS_PAGAS = dr.GetInt32(11); }
                    if (!dr.IsDBNull(12)) { obj.CUOTAS_ADEUDADAS = dr.GetInt32(12); }
                    if (!dr.IsDBNull(13)) { obj.CUOTAS_VENCIDAS = dr.GetInt32(13); }
                    if (!dr.IsDBNull(14)) { obj.ESTADO = dr.GetInt32(14); }
                    if (!dr.IsDBNull(15)) { obj.MONTO_PAGADO = dr.GetDecimal(15); }
                    obj.TNA = obj.TNA / 100;
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<VISTA_PLAN> read(int estado)
        {
            try
            {
                List<VISTA_PLAN> lst = new List<VISTA_PLAN>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM VISTA_PLAN WHERE ESTADO = @ESTADO";
                    cmd.Parameters.AddWithValue("@ESTADO", estado);
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

        public static List<VISTA_PLAN> read_PendientePago()
        {
            try
            {
                List<VISTA_PLAN> lst = new List<VISTA_PLAN>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM VISTA_PLAN WHERE (SALDO - MONTO_PAGADO) > 1";
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

        public static List<VISTA_PLAN> read_FinalizadoPago()
        {
            try
            {
                List<VISTA_PLAN> lst = new List<VISTA_PLAN>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM VISTA_PLAN WHERE (SALDO - MONTO_PAGADO) < 1";
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

        public static VISTA_PLAN getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM VISTA_PLAN WHERE");
                VISTA_PLAN obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<VISTA_PLAN> lst = mapeo(dr);
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

    }
}

