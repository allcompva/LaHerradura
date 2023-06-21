using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CUENTA_COMBO:DALBase
    {
        public int ID { get; set; }
        public int NRO_CTA { get; set; }
        public string PROPIETARIO { get; set; }
        public string MOSTRAR { get; set; }
        public string CUIT { get; set; }
        public CUENTA_COMBO()
        {
            ID = 0;
            NRO_CTA = 0;
            PROPIETARIO = string.Empty;
        }
        private static List<CUENTA_COMBO> mapeo(SqlDataReader dr)
        {
            List<CUENTA_COMBO> lst = new List<CUENTA_COMBO>();
            CUENTA_COMBO obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new CUENTA_COMBO();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.PROPIETARIO = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.CUIT = dr.GetString(3); }
                    obj.MOSTRAR = string.Format("Cuenta {0} - {1}",
                        obj.NRO_CTA, obj.PROPIETARIO);
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<CUENTA_COMBO> read()
        {
            try
            {
                List<CUENTA_COMBO> lst = new List<CUENTA_COMBO>();
                using (SqlConnection con = GetConnection())
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("SELECT A.ID, A.NRO_CTA, C.APELLIDO + ', ' + C.NOMBRE, C.NRO_CUIT");
                    sql.AppendLine("FROM INMUEBLES A");
                    sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON A.NRO_CTA=B.NRO_CTA AND B.RESPONSABLE_FACTURACION=1");
                    sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA=C.ID");
                    sql.AppendLine("ORDER BY A.NRO_CTA");
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
        public static CUENTA_COMBO getByNroCta(int nroCta)
        {
            try
            {
                CUENTA_COMBO obj = null;
                using (SqlConnection con = GetConnection())
                {
                    StringBuilder sql = new StringBuilder();
                    sql.AppendLine("SELECT A.ID, A.NRO_CTA, C.APELLIDO + ', ' + C.NOMBRE, C.NRO_CUIT");
                    sql.AppendLine("FROM INMUEBLES A");
                    sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON A.NRO_CTA=B.NRO_CTA AND B.RESPONSABLE_FACTURACION=1");
                    sql.AppendLine("INNER JOIN PERSONAS C ON B.ID_PERSONA=C.ID");
                    sql.AppendLine("WHERE A.NRO_CTA=@NRO_CTA");
                    sql.AppendLine("ORDER BY A.NRO_CTA");
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<CUENTA_COMBO> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
