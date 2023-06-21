using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DEUDA_ATRASADA:DALBase
    {
        public int PERIODO { get; set; }
        public decimal MONTO_ORIGINAL { get; set; }
        public string _PERIODO { get; set; }

        public DEUDA_ATRASADA()
        {
            PERIODO = 0;
            MONTO_ORIGINAL = 0;
            _PERIODO = string.Empty;
        }

        private static List<DEUDA_ATRASADA> mapeo(SqlDataReader dr)
        {
            List<DEUDA_ATRASADA> lst = new List<DEUDA_ATRASADA>();
            DEUDA_ATRASADA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new DEUDA_ATRASADA();
                    if (!dr.IsDBNull(0)) { obj.PERIODO = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.MONTO_ORIGINAL = dr.GetDecimal(1); }
                    if (obj.PERIODO != 20190100)
                    {
                        if (obj.PERIODO.ToString().Substring(6, 2) == "00")
                            obj._PERIODO = string.Format("{0}-{1} Ordinaria",
                                obj.PERIODO.ToString().Substring(0, 4),
                                obj.PERIODO.ToString().Substring(4, 2));
                        else
                            obj._PERIODO = string.Format("{0}-{1} Extraordinaria",
                                obj.PERIODO.ToString().Substring(0, 4),
                                obj.PERIODO.ToString().Substring(4, 2));
                    }
                    else
                    {
                        obj._PERIODO = "Saldo (capital) a Sept. 2019";
                    }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<DEUDA_ATRASADA> read(int nroCta, int periodo)
        {
            try
            {
                List<DEUDA_ATRASADA> lst = new List<DEUDA_ATRASADA>();
                string sql = @"SELECT PERIODO, MONTO_ORIGINAL 
                               FROM CTACTE_EXPENSAS
                               WHERE NRO_CTA = @NRO_CTA AND PERIODO < @PERIODO AND
                               PAGADO = 0 AND NRO_PLAN_PAGO IS NULL";

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
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
    }
}
