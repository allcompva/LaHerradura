using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class PERSONAS_X_INMUEBLES : DALBase
    {
        public int ID_PERSONA { get; set; }
        public int NRO_CTA { get; set; }
        public string RELACION { get; set; }
        public DateTime FECHA_DESDE { get; set; }
        public DateTime FECHA_HASTA { get; set; }
        public bool ACTIVO { get; set; }
        public bool RESPONSABLE_FACTURACION { get; set; }
        public decimal PORC_EXP_ORDINARIA { get; set; }
        public string CUIT { get; set; }

        public PERSONAS_X_INMUEBLES()
        {
            ID_PERSONA = 0;
            NRO_CTA = 0;
            RELACION = string.Empty;
            FECHA_DESDE = UTILS.getFechaActual();
            FECHA_HASTA = UTILS.getFechaActual();
            ACTIVO = false;
            RESPONSABLE_FACTURACION = false;
            PORC_EXP_ORDINARIA = 0;
            CUIT = string.Empty;
        }

        private static List<PERSONAS_X_INMUEBLES> mapeo(SqlDataReader dr)
        {
            List<PERSONAS_X_INMUEBLES> lst = new List<PERSONAS_X_INMUEBLES>();
            PERSONAS_X_INMUEBLES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new PERSONAS_X_INMUEBLES();
                    if (!dr.IsDBNull(0)) { obj.ID_PERSONA = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.RELACION = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.FECHA_DESDE = dr.GetDateTime(3); }
                    if (!dr.IsDBNull(4)) { obj.FECHA_HASTA = dr.GetDateTime(4); }
                    if (!dr.IsDBNull(5)) { obj.ACTIVO = dr.GetBoolean(5); }
                    if (!dr.IsDBNull(6)) { obj.RESPONSABLE_FACTURACION = dr.GetBoolean(6); }
                    if (!dr.IsDBNull(7)) { obj.PORC_EXP_ORDINARIA = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.CUIT = dr.GetString(8); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PERSONAS_X_INMUEBLES> read()
        {
            try
            {
                List<PERSONAS_X_INMUEBLES> lst = new List<PERSONAS_X_INMUEBLES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM PERSONAS_X_INMUEBLES";
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

        public static PERSONAS_X_INMUEBLES getByPk(
        int ID_PERSONA, int NRO_CTA)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM PERSONAS_X_INMUEBLES WHERE");
                sql.AppendLine("ID_PERSONA = @ID_PERSONA");
                sql.AppendLine("AND NRO_CTA = @NRO_CTA");
                PERSONAS_X_INMUEBLES obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PERSONA", ID_PERSONA);
                    cmd.Parameters.AddWithValue("@NRO_CTA", NRO_CTA);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PERSONAS_X_INMUEBLES> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static PERSONAS_X_INMUEBLES getByNroCta(int NRO_CTA)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM PERSONAS_X_INMUEBLES WHERE");
                sql.AppendLine("NRO_CTA = @NRO_CTA AND RESPONSABLE_FACTURACION = 1");
                PERSONAS_X_INMUEBLES obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", NRO_CTA);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PERSONAS_X_INMUEBLES> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void insert(PERSONAS_X_INMUEBLES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO PERSONAS_X_INMUEBLES(");
                sql.AppendLine("ID_PERSONA");
                sql.AppendLine(", NRO_CTA");
                sql.AppendLine(", RELACION");
                sql.AppendLine(", FECHA_DESDE");
                sql.AppendLine(", FECHA_HASTA");
                sql.AppendLine(", ACTIVO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@ID_PERSONA");
                sql.AppendLine(", @NRO_CTA");
                sql.AppendLine(", @RELACION");
                sql.AppendLine(", @FECHA_DESDE");
                sql.AppendLine(", @FECHA_HASTA");
                sql.AppendLine(", @ACTIVO");
                sql.AppendLine(")");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PERSONA", obj.ID_PERSONA);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@RELACION", obj.RELACION);
                    cmd.Parameters.AddWithValue("@FECHA_DESDE", obj.FECHA_DESDE);
                    cmd.Parameters.AddWithValue("@FECHA_HASTA", obj.FECHA_HASTA);
                    cmd.Parameters.AddWithValue("@ACTIVO", obj.ACTIVO);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(PERSONAS_X_INMUEBLES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  PERSONAS_X_INMUEBLES SET");
                sql.AppendLine("RELACION=@RELACION");
                sql.AppendLine(", FECHA_DESDE=@FECHA_DESDE");
                sql.AppendLine(", FECHA_HASTA=@FECHA_HASTA");
                sql.AppendLine(", ACTIVO=@ACTIVO");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID_PERSONA=@ID_PERSONA");
                sql.AppendLine("AND NRO_CTA=@NRO_CTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PERSONA", obj.ID_PERSONA);
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@RELACION", obj.RELACION);
                    cmd.Parameters.AddWithValue("@FECHA_DESDE", obj.FECHA_DESDE);
                    cmd.Parameters.AddWithValue("@FECHA_HASTA", obj.FECHA_HASTA);
                    cmd.Parameters.AddWithValue("@ACTIVO", obj.ACTIVO);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void updateResponsable(int idPersona, int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE PERSONAS_X_INMUEBLES SET");
                sql.AppendLine("RESPONSABLE_FACTURACION=1");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID_PERSONA=@ID_PERSONA");
                sql.AppendLine("AND NRO_CTA=@NRO_CTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PERSONA", idPersona);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void updateResponsable(int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE PERSONAS_X_INMUEBLES SET");
                sql.AppendLine("RESPONSABLE_FACTURACION=0");
                sql.AppendLine("WHERE");
                sql.AppendLine("NRO_CTA=@NRO_CTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int idPersona, int nroCta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  PERSONAS_X_INMUEBLES ");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID_PERSONA=@ID_PERSONA");
                sql.AppendLine("AND NRO_CTA=@NRO_CTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PERSONA", idPersona);
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

