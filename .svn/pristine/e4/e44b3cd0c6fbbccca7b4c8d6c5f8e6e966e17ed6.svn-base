using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Detalle_Conceptos : DALBase
    {
        public int NRO_CTA { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal CANT { get; set; }
        public decimal COSTO { get; set; }
        public decimal TOTAL { get; set; }

        public Detalle_Conceptos()
        {
            NRO_CTA = 0;
            DESCRIPCION = string.Empty;
            CANT = 0;
            COSTO = 0;
            TOTAL = 0;
        }
        private static List<Detalle_Conceptos> mapeo(SqlDataReader dr)
        {
            List<Detalle_Conceptos> lst = new List<Detalle_Conceptos>();
            Detalle_Conceptos obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new Detalle_Conceptos();
                    if (!dr.IsDBNull(0)) { obj.NRO_CTA = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.DESCRIPCION = dr.GetString(1); }
                    if (!dr.IsDBNull(2)) { obj.CANT = dr.GetDecimal(2); }
                    if (!dr.IsDBNull(3)) { obj.COSTO = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.TOTAL = dr.GetDecimal(4); }
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<Detalle_Conceptos> read(int periodo)
        {
            try
            {
                StringBuilder SQL = new StringBuilder();
                SQL.AppendLine("SELECT A.NRO_CTA, B.DESCRIPCION, A.CANT, A.COSTO, A.COSTO * A.CANT AS TOTAL");
                SQL.AppendLine("FROM CONCEPTOS_X_INMUEBLE A");
                SQL.AppendLine("INNER JOIN CONCEPTOS_EXPENSA B ON A.ID_CONCEPTO = B.ID");
                SQL.AppendLine("WHERE PERIODO = @PERIODO");
                SQL.AppendLine("ORDER BY B.DESCRIPCION, A.NRO_CTA");

                List<Detalle_Conceptos> lst = new List<Detalle_Conceptos>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
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
