using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PERSONAS_GRILLA:DALBase
    {
        public int ID { get; set; }
        public int NRO_CTA { get; set; }
        public string NOMBRE { get; set; }
        public string RELACION { get; set; }
        public bool RESPONSABLE_FACTURACION { get; set; }
        public string CUIT { get; set; }

        public PERSONAS_GRILLA()
        {
            ID = 0;
            NRO_CTA = 0;
            NOMBRE = string.Empty;
            RELACION = string.Empty;
            RESPONSABLE_FACTURACION = false;
        }
        private static List<PERSONAS_GRILLA> mapeo(SqlDataReader dr)
        {
            List<PERSONAS_GRILLA> lst = new List<PERSONAS_GRILLA>();
            PERSONAS_GRILLA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new PERSONAS_GRILLA();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.NOMBRE = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.RELACION = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.RESPONSABLE_FACTURACION = dr.GetBoolean(4); }
                    if (!dr.IsDBNull(5)) { obj.CUIT = dr.GetString(5); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PERSONAS_GRILLA> getByNroCta(int nroCta)
        {
            try
            {
                List<PERSONAS_GRILLA> lst = new List<PERSONAS_GRILLA>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT");
                sql.AppendLine("A.ID, B.NRO_CTA, A.APELLIDO + ' ' + A.NOMBRE AS NOMBRE,");
                sql.AppendLine("B.RELACION, RESPONSABLE_FACTURACION, A.NRO_CUIT");
                sql.AppendLine("FROM PERSONAS A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON A.ID = B.ID_PERSONA");
                sql.AppendLine("WHERE B.NRO_CTA = @NRO_CTA");
                sql.AppendLine("ORDER BY RELACION DESC");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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
