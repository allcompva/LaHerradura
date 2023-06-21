using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PRUEBA_NOTIFICACION : DALBase
    {
        public int NRO_CEDULON { get; set; }
        public int CANT_IMPUTACION { get; set; }
        public string JS { get; set; }
        public DateTime FECHA { get; set; }

        public PRUEBA_NOTIFICACION()
        {
            NRO_CEDULON = 0;
            CANT_IMPUTACION = 0;
            JS = string.Empty;
        }

        private static List<PRUEBA_NOTIFICACION> mapeo(SqlDataReader dr)
        {
            List<PRUEBA_NOTIFICACION> lst = new List<PRUEBA_NOTIFICACION>();
            PRUEBA_NOTIFICACION obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new PRUEBA_NOTIFICACION();
                    if (!dr.IsDBNull(0)) { obj.NRO_CEDULON = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.CANT_IMPUTACION = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.JS = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.FECHA = dr.GetDateTime(3); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PRUEBA_NOTIFICACION> read()
        {
            try
            {
                List<PRUEBA_NOTIFICACION> lst = new List<PRUEBA_NOTIFICACION>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM PRUEBA_NOTIFICACION";
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

        public static int getMax()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT ISNULL(MAX(CANT_IMPUTACION),0) FROM PRUEBA_NOTIFICACION");
                PRUEBA_NOTIFICACION obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void insert(PRUEBA_NOTIFICACION obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO PRUEBA_NOTIFICACION(");
                sql.AppendLine("NRO_CEDULON");
                sql.AppendLine(", CANT_IMPUTACION");
                sql.AppendLine(", JS");
                sql.AppendLine(", FECHA");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@NRO_CEDULON");
                sql.AppendLine(", @CANT_IMPUTACION");
                sql.AppendLine(", @JS");
                sql.AppendLine(", @FECHA");
                sql.AppendLine(")");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CEDULON", obj.NRO_CEDULON);
                    cmd.Parameters.AddWithValue("@CANT_IMPUTACION", obj.CANT_IMPUTACION);
                    cmd.Parameters.AddWithValue("@JS", obj.JS);
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

        public static void update(PRUEBA_NOTIFICACION obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  PRUEBA_NOTIFICACION SET");
                sql.AppendLine("NRO_CEDULON=@NRO_CEDULON");
                sql.AppendLine(", CANT_IMPUTACION=@CANT_IMPUTACION");
                sql.AppendLine(", JS=@JS");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CEDULON", obj.NRO_CEDULON);
                    cmd.Parameters.AddWithValue("@CANT_IMPUTACION", obj.CANT_IMPUTACION);
                    cmd.Parameters.AddWithValue("@JS", obj.JS);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(PRUEBA_NOTIFICACION obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  PRUEBA_NOTIFICACION ");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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
