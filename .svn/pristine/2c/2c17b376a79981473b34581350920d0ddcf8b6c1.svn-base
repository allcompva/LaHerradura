using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Banelco:DALBase
    {
        public int NRO_CTA { get; set; }
        public DateTime VENC1 { get; set; }
        public DateTime VENC2 { get; set; }
        public DateTime VENC3 { get; set; }
        public decimal MONTO1 { get; set; }
        public decimal MONTO2 { get; set; }
        public decimal MONTO3 { get; set; }
        public int PTO_VTA { get; set; }
        public Int64 NRO_CTE { get; set; }
        public Banelco()
        {

        }

        public static List<Banelco> read(int periodo)
        {
            try
            {
                List<Banelco> lst = new List<Banelco>();
                Banelco obj;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.NRO_CTA, B.VENCIMIENTO_1, B.VENCIMIENTO_2, B.VENCIMIENTO_3,");
                sql.AppendLine("A.MONTO_ORIGINAL - B.MONTO_3 + B.MONTO_1 AS MONTO_1,");
                sql.AppendLine("A.MONTO_ORIGINAL - B.MONTO_3 + B.MONTO_2 AS MONTO_2,");
                sql.AppendLine("A.MONTO_ORIGINAL AS MONTO_3, A.PTO_VTA, A.NRO_CTE");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS B ON A.PERIODO=B.PERIODO");
                sql.AppendLine("WHERE A.PERIODO=@PERIODO AND TIPO_MOVIMIENTO = 1");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new Banelco();
                            if (!dr.IsDBNull(0)) { obj.NRO_CTA = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.VENC1 = dr.GetDateTime(1); }
                            if (!dr.IsDBNull(2)) { obj.VENC2 = dr.GetDateTime(2); }
                            if (!dr.IsDBNull(3)) { obj.VENC3 = dr.GetDateTime(3); }
                            if (!dr.IsDBNull(4)) { obj.MONTO1 = dr.GetDecimal(4); }
                            if (!dr.IsDBNull(5)) { obj.MONTO2 = dr.GetDecimal(5); }
                            if (!dr.IsDBNull(6)) { obj.MONTO3 = dr.GetDecimal(6); }
                            if (!dr.IsDBNull(7)) { obj.PTO_VTA = dr.GetInt32(7); }
                            if (!dr.IsDBNull(8)) { obj.NRO_CTE = dr.GetInt64(8); }
                            lst.Add(obj);
                        }
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
