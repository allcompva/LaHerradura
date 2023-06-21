using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ComprobantesAsociados:DALBase
    {
        public int ID { get; set; }
        public int NRO_CTA { get; set; }
        public int PERIODO { get; set; }
        public int PTO_VTA { get; set; }
        public Int64 NRO_CTE { get; set; }
        public int TIPO_COMPROBANTE { get; set; }
        public string DETALLE { get; set; }
        public decimal MONTO_ORIGINAL { get; set; }
        public string FACTURA { get; set; }

        public ComprobantesAsociados()
        {
            ID = 0;
            NRO_CTA = 0;
            PERIODO = 0;
            PTO_VTA = 0;
            NRO_CTE = 0;
            TIPO_COMPROBANTE = 0;
            DETALLE = string.Empty;
            MONTO_ORIGINAL = 0;
        }
        private static List<ComprobantesAsociados> mapeo(SqlDataReader dr)
        {
            List<ComprobantesAsociados> lst = new List<ComprobantesAsociados>();
            ComprobantesAsociados obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new ComprobantesAsociados();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.PERIODO = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.PTO_VTA = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.NRO_CTE = dr.GetInt64(4); }
                    if (!dr.IsDBNull(5)) { obj.TIPO_COMPROBANTE = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.DETALLE = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.MONTO_ORIGINAL = dr.GetDecimal(7); }                  

                    obj.FACTURA = string.Format("Factura: {0}-{1} - {2} - {3:c}",
                        obj.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                        obj.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")),
                        obj.DETALLE, obj.MONTO_ORIGINAL);
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<ComprobantesAsociados> getByCta(int nroCta)
        {
            try
            {
                List<ComprobantesAsociados> lst = new List<ComprobantesAsociados>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.CommandText =
                        @"
                        SELECT 
                            ID, 
                            A.NRO_CTA, 
                            A.PERIODO, 
                            A.PTO_VTA, 
                            A.NRO_CTE, 
                            B.TIPO_COMPROBANTE, 
                            B.DETALLE, 
                            MONTO_ORIGINAL 
                        FROM CTACTE_EXPENSAS A
                        INNER JOIN FACTURAS_X_EXPENSA B ON 
                            A.PTO_VTA=B.PTO_VTA AND A.NRO_CTE=B.NRO_CTE AND TIPO_COMPROBANTE=11
                        WHERE 
                            TIPO_MOVIMIENTO=100 AND A.NRO_CTA = @NRO_CTA";
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
