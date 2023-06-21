using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ASIENTOS_PRUEBA : DALBase
    {
        public int ORDEN { get; set; }
        public int NRO_CTA { get; set; }
        public int ID_PLAN_PAGO { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal DEBE { get; set; }
        public decimal HABER { get; set; }

        private static List<ASIENTOS_PRUEBA> mapeo(SqlDataReader dr)
        {
            List<ASIENTOS_PRUEBA> lst = new List<ASIENTOS_PRUEBA>();
            ASIENTOS_PRUEBA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new ASIENTOS_PRUEBA();
                    if (!dr.IsDBNull(0)) { obj.ORDEN = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.ID_PLAN_PAGO = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.DESCRIPCION = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.DEBE = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.HABER = dr.GetDecimal(5); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<ASIENTOS_PRUEBA> read()
        {
            try
            {
                List<ASIENTOS_PRUEBA> lst = new List<ASIENTOS_PRUEBA>();
                using (SqlConnection con = GetConnection())
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("");
                    sql.AppendLine("");
                    sql.AppendLine("");
                    sql.AppendLine("");
                    sql.AppendLine("");
                    sql.AppendLine("");
                    sql.AppendLine("");
                    sql.AppendLine("");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM ASIENTOS WHERE ID >=2853";
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
