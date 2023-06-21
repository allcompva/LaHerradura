using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Carnets
{
    public class AGENDA_GENERAL:DALBase
    {

        public string DIA { get; set; }
        public TimeSpan HORA_INICIO { get; set; }
        public TimeSpan HORA_CIERRE { get; set; }
        public int INTERVALO { get; set; }
        public int TURNOS_SIMULTANEOS { get; set; }
        public int ORDEN { get; set; }
        public int ID_SERVICIO { get; set; }


        public static void update(AGENDA_GENERAL obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE AGENDA_GENERAL");
                sql.AppendLine("SET HORA_INICIO=@HORA_INICIO,");
                sql.AppendLine("HORA_CIERRE=@HORA_CIERRE,INTERVALO=@INTERVALO,");
                sql.AppendLine("TURNOS_SIMULTANEOS=@TURNOS_SIMULTANEOS");
                sql.AppendLine("WHERE DIA=@DIA AND ID_SERVICIO=@ID_SERVICIO");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@HORA_INICIO", obj.HORA_INICIO);
                    cmd.Parameters.AddWithValue("@HORA_CIERRE", obj.HORA_CIERRE);
                    cmd.Parameters.AddWithValue("@INTERVALO", obj.INTERVALO);
                    cmd.Parameters.AddWithValue("@TURNOS_SIMULTANEOS", obj.TURNOS_SIMULTANEOS);
                    cmd.Parameters.AddWithValue("@DIA", obj.DIA);
                    cmd.Parameters.AddWithValue("@ID_SERVICIO", obj.ID_SERVICIO);
                    cmd.Connection.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<AGENDA_GENERAL> read(int ID_SERV)
        {
            try
            {
                List<AGENDA_GENERAL> lst = new List<AGENDA_GENERAL>();
                AGENDA_GENERAL obj;

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM AGENDA_GENERAL WHERE ID_SERVICIO=@ID_SERVICIO ORDER BY ORDEN";
                    cmd.Parameters.AddWithValue("@ID_SERVICIO", ID_SERV);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int HORA_INICIO = dr.GetOrdinal("HORA_INICIO");
                        int HORA_CIERRE = dr.GetOrdinal("HORA_CIERRE");
                        int INTERVALO = dr.GetOrdinal("INTERVALO");
                        int TURNOS_SIMULTANEOS = dr.GetOrdinal("TURNOS_SIMULTANEOS");
                        int DIA = dr.GetOrdinal("DIA");
                        int ID_SERVICIO = dr.GetOrdinal("ID_SERVICIO");
                        while (dr.Read())
                        {
                            obj = new AGENDA_GENERAL();
                            if (!dr.IsDBNull(HORA_INICIO)) { obj.HORA_INICIO = dr.GetTimeSpan(HORA_INICIO); }
                            if (!dr.IsDBNull(HORA_CIERRE)) { obj.HORA_CIERRE = dr.GetTimeSpan(HORA_CIERRE); }
                            if (!dr.IsDBNull(INTERVALO)) { obj.INTERVALO = dr.GetInt32(INTERVALO); }
                            if (!dr.IsDBNull(TURNOS_SIMULTANEOS)) { obj.TURNOS_SIMULTANEOS = dr.GetInt32(TURNOS_SIMULTANEOS); }
                            if (!dr.IsDBNull(DIA)) { obj.DIA = dr.GetString(DIA); }
                            if (!dr.IsDBNull(ID_SERVICIO)) { obj.ID_SERVICIO = dr.GetInt32(ID_SERVICIO); }
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
        public static AGENDA_GENERAL getByDia(string dia, int idServ)
        {
            try
            {
                AGENDA_GENERAL obj = null;

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM AGENDA_GENERAL WHERE DIA = @DIA AND ID_SERVICIO=@ID_SERVICIO";
                    cmd.Parameters.AddWithValue("@DIA", dia);
                    cmd.Parameters.AddWithValue("@ID_SERVICIO", idServ);

                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int HORA_INICIO = dr.GetOrdinal("HORA_INICIO");
                        int HORA_CIERRE = dr.GetOrdinal("HORA_CIERRE");
                        int INTERVALO = dr.GetOrdinal("INTERVALO");
                        int TURNOS_SIMULTANEOS = dr.GetOrdinal("TURNOS_SIMULTANEOS");
                        int DIA = dr.GetOrdinal("DIA");
                        int ID_SERVICIO = dr.GetOrdinal("ID_SERVICIO");
                        while (dr.Read())
                        {
                            obj = new AGENDA_GENERAL();
                            if (!dr.IsDBNull(HORA_INICIO)) { obj.HORA_INICIO = dr.GetTimeSpan(HORA_INICIO); }
                            if (!dr.IsDBNull(HORA_CIERRE)) { obj.HORA_CIERRE = dr.GetTimeSpan(HORA_CIERRE); }
                            if (!dr.IsDBNull(INTERVALO)) { obj.INTERVALO = dr.GetInt32(INTERVALO); }
                            if (!dr.IsDBNull(TURNOS_SIMULTANEOS)) { obj.TURNOS_SIMULTANEOS = dr.GetInt32(TURNOS_SIMULTANEOS); }
                            if (!dr.IsDBNull(DIA)) { obj.DIA = dr.GetString(DIA); }
                            if (!dr.IsDBNull(ID_SERVICIO)) { obj.ID_SERVICIO = dr.GetInt32(ID_SERVICIO); }
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
