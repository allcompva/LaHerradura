using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LIBRO_MAYOR_ANT : DALBase
    {
        public string N5 { get; set; }
        public string CUENTA { get; set; }
        public decimal DEBE { get; set; }
        public decimal HABER { get; set; }
        public decimal SALDO { get; set; }
        public string DESC_GRUPO { get; set; }
        public decimal SALDO_INICIAL { get; set; }
        public LIBRO_MAYOR_ANT()
        {
            N5 = string.Empty;
            CUENTA = string.Empty;
            DEBE = 0;
            HABER = 0;
            SALDO = 0;
            DESC_GRUPO = string.Empty;
            SALDO_INICIAL = 0;
        }

        private static List<LIBRO_MAYOR_ANT> mapeo(SqlDataReader dr)
        {
            List<LIBRO_MAYOR_ANT> lst = new List<LIBRO_MAYOR_ANT>();
            LIBRO_MAYOR_ANT obj;
            if (dr.HasRows)
            {
                int i = 1;
                while (dr.Read())
                {
                    obj = new LIBRO_MAYOR_ANT();
                    if (!dr.IsDBNull(0)) { obj.N5 = dr.GetString(0); }
                    if (!dr.IsDBNull(1)) { obj.DESC_GRUPO = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.CUENTA = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.DEBE = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.HABER = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.SALDO = dr.GetDecimal(5); }

                    lst.Add(obj);

                }
            }
            return lst;
        }

        public static List<LIBRO_MAYOR_ANT> read(int anio)
        {
            try
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("SELECT B.N5, B.DESC_GRUPO, B.N5 + ' - ' + B.DESC_SUBCUENTA");
                sql.AppendLine("AS CUENTA,  SUM(A.DEBE)");
                sql.AppendLine("AS DEBE, SUM(A.HABER) AS HABER,");
                sql.AppendLine("SUM(DEBE)-SUM(HABER) AS SALDO");
                sql.AppendLine("FROM ASIENTOS_DETALLE A");
                sql.AppendLine("INNER JOIN PLAN_CUENTA B ON A.ID_CUENTA=B.ID");
                
                sql.AppendLine("GROUP BY B.N5, B.DESC_SUBCUENTA, B.DESC_GRUPO");


                List<LIBRO_MAYOR_ANT> lst = new List<LIBRO_MAYOR_ANT>();
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
    }
}
