using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Carnets
{
    public class AGENDA_ESPECIAL : DALBase
    {
        public DateTime FECHA { get; set; }
        public TimeSpan HORA_INICIO { get; set; }
        public TimeSpan HORA_CIERRE { get; set; }
        public int INTERVALO { get; set; }
        public int TURNOS_SIMULTANEOS { get; set; }
        public int ORDEN { get; set; }

        public static void update(AGENDA_ESPECIAL obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE AGENDA_ESPECIAL");
                sql.AppendLine("SET HORA_INICIO=@HORA_INICIO,");
                sql.AppendLine("HORA_CIERRE=@HORA_CIERRE,INTERVALO=@INTERVALO,");
                sql.AppendLine("TURNOS_SIMULTANEOS=@TURNOS_SIMULTANEOS");
                sql.AppendLine("WHERE FECHA=@FECHA");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@HORA_INICIO", obj.HORA_INICIO);
                    cmd.Parameters.AddWithValue("@HORA_CIERRE", obj.HORA_CIERRE);
                    cmd.Parameters.AddWithValue("@INTERVALO", obj.INTERVALO);
                    cmd.Parameters.AddWithValue("@TURNOS_SIMULTANEOS", obj.TURNOS_SIMULTANEOS);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Connection.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void insert(AGENDA_ESPECIAL obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO AGENDA_ESPECIAL");
                sql.AppendLine("(FECHA,HORA_INICIO,HORA_CIERRE,INTERVALO,TURNOS_SIMULTANEOS)");
                sql.AppendLine("VALUES");
                sql.AppendLine("(@FECHA,@HORA_INICIO,@HORA_CIERRE,@INTERVALO,@TURNOS_SIMULTANEOS)");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@HORA_INICIO", obj.HORA_INICIO);
                    cmd.Parameters.AddWithValue("@HORA_CIERRE", obj.HORA_CIERRE);
                    cmd.Parameters.AddWithValue("@INTERVALO", obj.INTERVALO);
                    cmd.Parameters.AddWithValue("@TURNOS_SIMULTANEOS", obj.TURNOS_SIMULTANEOS);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Connection.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<AGENDA_ESPECIAL> read()
        {
            try
            {
                List<AGENDA_ESPECIAL> lst = new List<AGENDA_ESPECIAL>();
                AGENDA_ESPECIAL obj;

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM AGENDA_ESPECIAL ORDER BY ORDEN";
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int HORA_INICIO = dr.GetOrdinal("HORA_INICIO");
                        int HORA_CIERRE = dr.GetOrdinal("HORA_CIERRE");
                        int INTERVALO = dr.GetOrdinal("INTERVALO");
                        int TURNOS_SIMULTANEOS = dr.GetOrdinal("TURNOS_SIMULTANEOS");
                        int FECHA = dr.GetOrdinal("FECHA");
                        while (dr.Read())
                        {
                            obj = new AGENDA_ESPECIAL();
                            if (!dr.IsDBNull(HORA_INICIO)) { obj.HORA_INICIO = dr.GetTimeSpan(HORA_INICIO); }
                            if (!dr.IsDBNull(HORA_CIERRE)) { obj.HORA_CIERRE = dr.GetTimeSpan(HORA_CIERRE); }
                            if (!dr.IsDBNull(INTERVALO)) { obj.INTERVALO = dr.GetInt32(INTERVALO); }
                            if (!dr.IsDBNull(TURNOS_SIMULTANEOS)) { obj.TURNOS_SIMULTANEOS = dr.GetInt32(TURNOS_SIMULTANEOS); }
                            if (!dr.IsDBNull(FECHA)) { obj.FECHA = dr.GetDateTime(FECHA); }
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

        public static AGENDA_ESPECIAL getByFecha(DateTime fecha)
        {
            try
            {
                AGENDA_ESPECIAL obj = null;

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM AGENDA_ESPECIAL WHERE FECHA=@FECHA ORDER BY ORDEN";
                    cmd.Parameters.AddWithValue("@FECHA", fecha);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int HORA_INICIO = dr.GetOrdinal("HORA_INICIO");
                        int HORA_CIERRE = dr.GetOrdinal("HORA_CIERRE");
                        int INTERVALO = dr.GetOrdinal("INTERVALO");
                        int TURNOS_SIMULTANEOS = dr.GetOrdinal("TURNOS_SIMULTANEOS");
                        int FECHA = dr.GetOrdinal("FECHA");
                        while (dr.Read())
                        {
                            obj = new AGENDA_ESPECIAL();
                            if (!dr.IsDBNull(HORA_INICIO)) { obj.HORA_INICIO = dr.GetTimeSpan(HORA_INICIO); }
                            if (!dr.IsDBNull(HORA_CIERRE)) { obj.HORA_CIERRE = dr.GetTimeSpan(HORA_CIERRE); }
                            if (!dr.IsDBNull(INTERVALO)) { obj.INTERVALO = dr.GetInt32(INTERVALO); }
                            if (!dr.IsDBNull(TURNOS_SIMULTANEOS)) { obj.TURNOS_SIMULTANEOS = dr.GetInt32(TURNOS_SIMULTANEOS); }
                            if (!dr.IsDBNull(FECHA)) { obj.FECHA = dr.GetDateTime(FECHA); }
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
