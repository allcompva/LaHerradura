using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class PLANILLA_CAJA : DALBase
    {
        public int ID { get; set; }
        public int ID_CAJA { get; set; }
        public DateTime FECHA { get; set; }
        public DateTime FECHA_APERTURA { get; set; }
        public DateTime FECHA_CIERRE { get; set; }
        public int USUARIO_ABRE { get; set; }
        public int USUARIO_CIERRA { get; set; }
        public decimal SALDO_ANTERIOR_EFVO { get; set; }
        public decimal SALDO_ANTERIOR_CHEQUES { get; set; }
        public decimal SALDO_ANTERIOR_BANCO { get; set; }
        public decimal INGRESOS_EFVO { get; set; }
        public decimal INGRESOS_CHEQUES { get; set; }
        public decimal INGRESOS_BANCO { get; set; }
        public decimal EGRESOS_EFVO { get; set; }
        public decimal EGRESOS_CHEQUES { get; set; }
        public decimal EGRESOS_BANCO { get; set; }
        public decimal SALDO_EFVO { get; set; }
        public decimal SALDO_CHEQUES { get; set; }
        public decimal SALDO_BANCO { get; set; }
        public int ESTADO { get; set; }
        public string OBS_ABRE { get; set; }
        public string OBS_CIERRE { get; set; }

        public PLANILLA_CAJA()
        {
            ID = 0;
            ID_CAJA = 0;
            FECHA = UTILS.getFechaActual();
            FECHA_APERTURA = UTILS.getFechaActual();
            FECHA_CIERRE = UTILS.getFechaActual();
            USUARIO_ABRE = 0;
            USUARIO_CIERRA = 0;
            SALDO_ANTERIOR_EFVO = 0;
            SALDO_ANTERIOR_CHEQUES = 0;
            SALDO_ANTERIOR_BANCO = 0;
            INGRESOS_EFVO = 0;
            INGRESOS_CHEQUES = 0;
            INGRESOS_BANCO = 0;
            EGRESOS_EFVO = 0;
            EGRESOS_CHEQUES = 0;
            EGRESOS_BANCO = 0;
            SALDO_EFVO = 0;
            SALDO_CHEQUES = 0;
            SALDO_BANCO = 0;
            ESTADO = 0;
            OBS_ABRE = string.Empty;
            OBS_CIERRE = string.Empty;
        }

        private static List<PLANILLA_CAJA> mapeo(SqlDataReader dr)
        {
            List<PLANILLA_CAJA> lst = new List<PLANILLA_CAJA>();
            PLANILLA_CAJA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new PLANILLA_CAJA();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.ID_CAJA = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.FECHA = dr.GetDateTime(2); }
                    if (!dr.IsDBNull(3)) { obj.FECHA_APERTURA = dr.GetDateTime(3); }
                    if (!dr.IsDBNull(4)) { obj.FECHA_CIERRE = dr.GetDateTime(4); }
                    if (!dr.IsDBNull(5)) { obj.USUARIO_ABRE = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.USUARIO_CIERRA = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.SALDO_ANTERIOR_EFVO = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.SALDO_ANTERIOR_CHEQUES = dr.GetDecimal(8); }
                    if (!dr.IsDBNull(9)) { obj.SALDO_ANTERIOR_BANCO = dr.GetDecimal(9); }
                    if (!dr.IsDBNull(10)) { obj.INGRESOS_EFVO = dr.GetDecimal(10); }
                    if (!dr.IsDBNull(11)) { obj.INGRESOS_CHEQUES = dr.GetDecimal(11); }
                    if (!dr.IsDBNull(12)) { obj.INGRESOS_BANCO = dr.GetDecimal(12); }
                    if (!dr.IsDBNull(13)) { obj.EGRESOS_EFVO = dr.GetDecimal(13); }
                    if (!dr.IsDBNull(14)) { obj.EGRESOS_CHEQUES = dr.GetDecimal(14); }
                    if (!dr.IsDBNull(15)) { obj.EGRESOS_BANCO = dr.GetDecimal(15); }
                    if (!dr.IsDBNull(16)) { obj.SALDO_EFVO = dr.GetDecimal(16); }
                    if (!dr.IsDBNull(17)) { obj.SALDO_CHEQUES = dr.GetDecimal(17); }
                    if (!dr.IsDBNull(18)) { obj.SALDO_BANCO = dr.GetDecimal(18); }
                    if (!dr.IsDBNull(19)) { obj.ESTADO = dr.GetInt32(19); }
                    if (!dr.IsDBNull(20)) { obj.OBS_ABRE = dr.GetString(20); }
                    if (!dr.IsDBNull(21)) { obj.OBS_CIERRE = dr.GetString(21); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PLANILLA_CAJA> read()
        {
            try
            {
                List<PLANILLA_CAJA> lst = new List<PLANILLA_CAJA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM PLANILLA_CAJA";
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

        public static PLANILLA_CAJA getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM PLANILLA_CAJA WHERE");
                sql.AppendLine("ID = @ID");
                PLANILLA_CAJA obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PLANILLA_CAJA> lst = mapeo(dr);
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
        public static PLANILLA_CAJA getMax()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM PLANILLA_CAJA WHERE");
                sql.AppendLine(
                    "ID = (SELECT MAX(ID) FROM PLANILLA_CAJA WHERE ESTADO = 1)");
                PLANILLA_CAJA obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PLANILLA_CAJA> lst = mapeo(dr);
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
        public static PLANILLA_CAJA getByEstado(
        int estado)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM PLANILLA_CAJA WHERE");
                sql.AppendLine("ESTADO = @ESTADO");
                PLANILLA_CAJA obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ESTADO", estado);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PLANILLA_CAJA> lst = mapeo(dr);
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
        public static void insert(PLANILLA_CAJA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO PLANILLA_CAJA(ID,");
                sql.AppendLine("ID_CAJA");
                sql.AppendLine(", FECHA");
                sql.AppendLine(", FECHA_APERTURA");
                sql.AppendLine(", FECHA_CIERRE");
                sql.AppendLine(", USUARIO_ABRE");
                sql.AppendLine(", USUARIO_CIERRA");
                sql.AppendLine(", SALDO_ANTERIOR_EFVO");
                sql.AppendLine(", SALDO_ANTERIOR_CHEQUES");
                sql.AppendLine(", SALDO_ANTERIOR_BANCO");
                sql.AppendLine(", INGRESOS_EFVO");
                sql.AppendLine(", INGRESOS_CHEQUES");
                sql.AppendLine(", INGRESOS_BANCO");
                sql.AppendLine(", EGRESOS_EFVO");
                sql.AppendLine(", EGRESOS_CHEQUES");
                sql.AppendLine(", EGRESOS_BANCO");
                sql.AppendLine(", SALDO_EFVO");
                sql.AppendLine(", SALDO_CHEQUES");
                sql.AppendLine(", SALDO_BANCO");
                sql.AppendLine(", ESTADO");
                sql.AppendLine(", OBS_ABRE");
                sql.AppendLine(", OBS_CIERRE");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(@ID,");
                sql.AppendLine("@ID_CAJA");
                sql.AppendLine(", @FECHA");
                sql.AppendLine(", @FECHA_APERTURA");
                sql.AppendLine(", @FECHA_CIERRE");
                sql.AppendLine(", @USUARIO_ABRE");
                sql.AppendLine(", @USUARIO_CIERRA");
                sql.AppendLine(", @SALDO_ANTERIOR_EFVO");
                sql.AppendLine(", @SALDO_ANTERIOR_CHEQUES");
                sql.AppendLine(", @SALDO_ANTERIOR_BANCO");
                sql.AppendLine(", @INGRESOS_EFVO");
                sql.AppendLine(", @INGRESOS_CHEQUES");
                sql.AppendLine(", @INGRESOS_BANCO");
                sql.AppendLine(", @EGRESOS_EFVO");
                sql.AppendLine(", @EGRESOS_CHEQUES");
                sql.AppendLine(", @EGRESOS_BANCO");
                sql.AppendLine(", @SALDO_EFVO");
                sql.AppendLine(", @SALDO_CHEQUES");
                sql.AppendLine(", @SALDO_BANCO");
                sql.AppendLine(", @ESTADO");
                sql.AppendLine(", @OBS_ABRE");
                sql.AppendLine(", @OBS_CIERRE");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@ID_CAJA", obj.ID_CAJA);
                    cmd.Parameters.AddWithValue("@FECHA", obj.FECHA);
                    cmd.Parameters.AddWithValue("@FECHA_APERTURA", obj.FECHA_APERTURA);
                    cmd.Parameters.AddWithValue("@FECHA_CIERRE", obj.FECHA_CIERRE);
                    cmd.Parameters.AddWithValue("@USUARIO_ABRE", obj.USUARIO_ABRE);
                    cmd.Parameters.AddWithValue("@USUARIO_CIERRA", obj.USUARIO_CIERRA);
                    cmd.Parameters.AddWithValue("@SALDO_ANTERIOR_EFVO", obj.SALDO_ANTERIOR_EFVO);
                    cmd.Parameters.AddWithValue("@SALDO_ANTERIOR_CHEQUES", obj.SALDO_ANTERIOR_CHEQUES);
                    cmd.Parameters.AddWithValue("@SALDO_ANTERIOR_BANCO", obj.SALDO_ANTERIOR_BANCO);
                    cmd.Parameters.AddWithValue("@INGRESOS_EFVO", obj.INGRESOS_EFVO);
                    cmd.Parameters.AddWithValue("@INGRESOS_CHEQUES", obj.INGRESOS_CHEQUES);
                    cmd.Parameters.AddWithValue("@INGRESOS_BANCO", obj.INGRESOS_BANCO);
                    cmd.Parameters.AddWithValue("@EGRESOS_EFVO", obj.EGRESOS_EFVO);
                    cmd.Parameters.AddWithValue("@EGRESOS_CHEQUES", obj.EGRESOS_CHEQUES);
                    cmd.Parameters.AddWithValue("@EGRESOS_BANCO", obj.EGRESOS_BANCO);
                    cmd.Parameters.AddWithValue("@SALDO_EFVO", obj.SALDO_EFVO);
                    cmd.Parameters.AddWithValue("@SALDO_CHEQUES", obj.SALDO_CHEQUES);
                    cmd.Parameters.AddWithValue("@SALDO_BANCO", obj.SALDO_BANCO);
                    cmd.Parameters.AddWithValue("@ESTADO", obj.ESTADO);
                    cmd.Parameters.AddWithValue("@OBS_ABRE", obj.OBS_ABRE);
                    cmd.Parameters.AddWithValue("@OBS_CIERRE", obj.OBS_CIERRE);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(PLANILLA_CAJA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  PLANILLA_CAJA SET");
                sql.AppendLine("EGRESOS_EFVO=@EGRESOS_EFVO");
                sql.AppendLine(", EGRESOS_CHEQUES=@EGRESOS_CHEQUES");
                sql.AppendLine(", EGRESOS_BANCO=@EGRESOS_BANCO");
                sql.AppendLine(", ESTADO=@ESTADO");
                sql.AppendLine(", FECHA_CIERRE=@FECHA_CIERRE");
                sql.AppendLine(", INGRESOS_EFVO=@INGRESOS_EFVO");
                sql.AppendLine(", INGRESOS_CHEQUES=@INGRESOS_CHEQUES");
                sql.AppendLine(", INGRESOS_BANCO=@INGRESOS_BANCO");
                sql.AppendLine(", OBS_CIERRE=@OBS_CIERRE");
                sql.AppendLine(", SALDO_EFVO=@SALDO_EFVO");
                sql.AppendLine(", SALDO_CHEQUES=@SALDO_CHEQUES");
                sql.AppendLine(", SALDO_BANCO=@SALDO_BANCO");
                sql.AppendLine(", USUARIO_CIERRA=@USUARIO_CIERRA");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@EGRESOS_EFVO", obj.EGRESOS_EFVO);
                    cmd.Parameters.AddWithValue("@EGRESOS_CHEQUES", obj.EGRESOS_CHEQUES);
                    cmd.Parameters.AddWithValue("@EGRESOS_BANCO", obj.EGRESOS_BANCO);
                    cmd.Parameters.AddWithValue("@ESTADO", obj.ESTADO);
                    cmd.Parameters.AddWithValue("@FECHA_CIERRE", obj.FECHA_CIERRE);
                    cmd.Parameters.AddWithValue("@INGRESOS_EFVO", obj.INGRESOS_EFVO);
                    cmd.Parameters.AddWithValue("@INGRESOS_CHEQUES", obj.INGRESOS_CHEQUES);
                    cmd.Parameters.AddWithValue("@INGRESOS_BANCO", obj.INGRESOS_BANCO);
                    cmd.Parameters.AddWithValue("@OBS_CIERRE", obj.OBS_CIERRE);
                    cmd.Parameters.AddWithValue("@SALDO_EFVO", obj.SALDO_EFVO);
                    cmd.Parameters.AddWithValue("@SALDO_CHEQUES", obj.SALDO_CHEQUES);
                    cmd.Parameters.AddWithValue("@SALDO_BANCO", obj.SALDO_BANCO);
                    cmd.Parameters.AddWithValue("@USUARIO_CIERRA", obj.USUARIO_CIERRA);
                    cmd.Parameters.AddWithValue("@ID", obj.ID);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(PLANILLA_CAJA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  PLANILLA_CAJA ");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
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

