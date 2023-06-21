using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class PAGOS_CON_CUENTA_TABLA : DALBase
    {
        public int ID { get; set; }
        public DateTime FECHA { get; set; }
        public int USUARIO { get; set; }
        public Int64 ID_FACTURA { get; set; }
        public int ID_PLAN_PAGO { get; set; }
        public decimal MONTO { get; set; }
        public int ID_BANCO { get; set; }
        public string NRO_CHEQUE { get; set; }
        public string CUIT_PAGADOR { get; set; }
        public DateTime FECHA_CHEQUE { get; set; }
        public int ID_TARJETA { get; set; }
        public int CANT_CUOTAS { get; set; }
        public int NRO_CTA { get; set; }

        public PAGOS_CON_CUENTA_TABLA()
        {
            ID = 0;
            FECHA = UTILS.getFechaActual();
            USUARIO = 0;
            ID_FACTURA = 0;
            ID_PLAN_PAGO = 0;
            MONTO = 0;
            ID_BANCO = 0;
            NRO_CHEQUE = string.Empty;
            CUIT_PAGADOR = string.Empty;
            FECHA_CHEQUE = UTILS.getFechaActual();
            ID_TARJETA = 0;
            CANT_CUOTAS = 0;
            NRO_CTA = 0;
        }

        private static List<PAGOS_CON_CUENTA_TABLA> mapeo(SqlDataReader dr)
        {
            List<PAGOS_CON_CUENTA_TABLA> lst = new List<PAGOS_CON_CUENTA_TABLA>();
            PAGOS_CON_CUENTA_TABLA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new PAGOS_CON_CUENTA_TABLA();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.FECHA = dr.GetDateTime(1); }
                    if (!dr.IsDBNull(2)) { obj.USUARIO = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.ID_FACTURA = dr.GetInt64(3); }
                    if (!dr.IsDBNull(4)) { obj.ID_PLAN_PAGO = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.MONTO = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.ID_BANCO = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.NRO_CHEQUE = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.CUIT_PAGADOR = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.FECHA_CHEQUE = dr.GetDateTime(9); }
                    if (!dr.IsDBNull(10)) { obj.ID_TARJETA = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.CANT_CUOTAS = dr.GetInt32(11); }
                    if (!dr.IsDBNull(12)) { obj.NRO_CTA = dr.GetInt32(12); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PAGOS_CON_CUENTA_TABLA> read()
        {
            try
            {
                List<PAGOS_CON_CUENTA_TABLA> lst = new List<PAGOS_CON_CUENTA_TABLA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM PAGOS_CON_CUENTA";
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

        public static PAGOS_CON_CUENTA_TABLA getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM PAGOS_CON_CUENTA WHERE");
                PAGOS_CON_CUENTA_TABLA obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PAGOS_CON_CUENTA_TABLA> lst = mapeo(dr);
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

