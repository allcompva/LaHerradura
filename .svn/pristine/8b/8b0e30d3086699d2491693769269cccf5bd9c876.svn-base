using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DETALLE_INTERES : DALBase
    {
        public int ANIO { get; set; }
        public int MES { get; set; }
        public DateTime VENCIMIENTO { get; set; }
        public DateTime FECHA_ACTUAL { get; set; }
        public decimal CAPITAL { get; set; }
        public int DIAS_MORA { get; set; }
        public decimal TASA_MENSUAL { get; set; }
        public decimal TASA_DIARIA { get; set; }
        public decimal INTERES { get; set; }
        public string PERIODO_MAQUILLADO { get; set; }

        private static List<DETALLE_INTERES> mapeo(SqlDataReader dr)
        {
            List<DETALLE_INTERES> lst = new List<DETALLE_INTERES>();
            DETALLE_INTERES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new DETALLE_INTERES();
                    if (!dr.IsDBNull(0)) { obj.ANIO = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.MES = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.VENCIMIENTO = dr.GetDateTime(2); }
                    if (!dr.IsDBNull(6)) { obj.CAPITAL = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.TASA_MENSUAL = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.TASA_DIARIA = dr.GetDecimal(8); }
                    if (!dr.IsDBNull(9)) { obj.DIAS_MORA = dr.GetInt32(9); }
                    obj.INTERES = obj.TASA_DIARIA * obj.DIAS_MORA * obj.CAPITAL / 100;
            
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<DETALLE_INTERES> read(DateTime vencimiento, DateTime fec_actual,
            decimal monto)
        {
            try
            {
                List<DETALLE_INTERES> lst = new List<DETALLE_INTERES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CALCULO_INTERES_TV_DETALLE";
                    cmd.Parameters.AddWithValue("@FECHA_VENC", vencimiento);
                    cmd.Parameters.AddWithValue("@FECHA_ACTUAL", fec_actual);
                    cmd.Parameters.AddWithValue("@CAPITAL", monto);
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
