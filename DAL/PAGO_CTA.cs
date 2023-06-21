using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class PAGO_CTA:DALBase
    {
        public DateTime FECHA { get; set; }
        public decimal HABER { get; set; }
        public decimal PORCENTAJE_CUBIERTO { get; set; }
        public decimal CAPITAL_CUBIERTO { get; set; }
        public decimal INTERES_CUBIERTO { get; set; }

        public PAGO_CTA()
        {
            FECHA = UTILS.getFechaActual();
            HABER = 0;
            PORCENTAJE_CUBIERTO = 0;
            CAPITAL_CUBIERTO = 0;
            INTERES_CUBIERTO = 0;
        }

        private static List<PAGO_CTA> mapeo(SqlDataReader dr)
        {
            List<PAGO_CTA> lst = new List<PAGO_CTA>();
            PAGO_CTA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new PAGO_CTA();
                    if (!dr.IsDBNull(0)) { obj.FECHA = dr.GetDateTime(0); }
                    if (!dr.IsDBNull(1)) { obj.HABER = dr.GetDecimal(1); }
                    if (!dr.IsDBNull(2)) { obj.PORCENTAJE_CUBIERTO = dr.GetDecimal(2); }
                    if (!dr.IsDBNull(3)) { obj.CAPITAL_CUBIERTO = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.INTERES_CUBIERTO = dr.GetDecimal(4); }
                    
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PAGO_CTA> read(int periodo, int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT FECHA, HABER, ");
                sql.AppendLine("HABER / (MONTO_ORIGINAL + INTERES_MORA),");
                sql.AppendLine("MONTO_ORIGINAL * (HABER / (MONTO_ORIGINAL + INTERES_MORA)),");
                sql.AppendLine("INTERES_MORA * (HABER / (MONTO_ORIGINAL + INTERES_MORA))");
                sql.AppendLine("FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE PERIODO = @PERIODO AND TIPO_MOVIMIENTO = 2 AND NRO_CTA = @NRO_CTA");
                List<PAGO_CTA> lst = new List<PAGO_CTA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
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
    }
}
