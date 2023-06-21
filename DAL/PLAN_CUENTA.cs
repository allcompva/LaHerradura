using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class PLAN_CUENTA : DALBase
    {
        public int ID { get; set; }
        public int EJERCICIO { get; set; }
        public int ELEMENTO { get; set; }
        public string DESC_ELEMENTO { get; set; }
        public int GRUPO { get; set; }
        public string DESC_GRUPO { get; set; }
        public int CUENTA { get; set; }
        public string DESC_CUENTA { get; set; }
        public string SUB_CUENTA { get; set; }
        public string DESC_SUBCUENTA { get; set; }
        public int AUXILIAR { get; set; }
        public string DESC_AUXILIAR { get; set; }
        public string NRO_AGRUPACION { get; set; }
        public string DESC_AGRUPACION { get; set; }
        public string N5 { get; set; }

        public string NOMBRE_COMBO { get; set; }

        public PLAN_CUENTA()
        {
            ID = 0;
            EJERCICIO = 0;
            ELEMENTO = 0;
            DESC_ELEMENTO = string.Empty;
            GRUPO = 0;
            DESC_GRUPO = string.Empty;
            CUENTA = 0;
            DESC_CUENTA = string.Empty;
            SUB_CUENTA = string.Empty;
            DESC_SUBCUENTA = string.Empty;
            AUXILIAR = 0;
            DESC_AUXILIAR = string.Empty;
            NRO_AGRUPACION = string.Empty;
            DESC_AGRUPACION = string.Empty;
            N5 = string.Empty;
            NOMBRE_COMBO = string.Empty;
        }

        private static List<PLAN_CUENTA> mapeo(SqlDataReader dr)
        {
            List<PLAN_CUENTA> lst = new List<PLAN_CUENTA>();
            PLAN_CUENTA obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new PLAN_CUENTA();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.EJERCICIO = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.ELEMENTO = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.DESC_ELEMENTO = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.GRUPO = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.DESC_GRUPO = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.CUENTA = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.DESC_CUENTA = dr.GetString(7); }
                    if (!dr.IsDBNull(8)) { obj.SUB_CUENTA = dr.GetString(8); }
                    if (!dr.IsDBNull(9)) { obj.DESC_SUBCUENTA = dr.GetString(9); }
                    if (!dr.IsDBNull(10)) { obj.AUXILIAR = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.DESC_AUXILIAR = dr.GetString(11); }
                    if (!dr.IsDBNull(12)) { obj.NRO_AGRUPACION = dr.GetString(12); }
                    if (!dr.IsDBNull(13)) { obj.DESC_AGRUPACION = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.N5 = dr.GetString(14); }
                    obj.NOMBRE_COMBO = string.Format("{0}-{1}",
                        obj.N5, obj.DESC_SUBCUENTA);
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<PLAN_CUENTA> read()
        {
            try
            {
                List<PLAN_CUENTA> lst = new List<PLAN_CUENTA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM PLAN_CUENTA ORDER BY DESC_SUBCUENTA ASC";
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
        public static List<PLAN_CUENTA> read(int elemento, int grupo)
        {
            try
            {
                List<PLAN_CUENTA> lst = new List<PLAN_CUENTA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM PLAN_CUENTA WHERE ELEMENTO=@ELEMENTO AND GRUPO=@GRUPO ORDER BY DESC_SUBCUENTA ASC";
                    cmd.Parameters.AddWithValue("@ELEMENTO", elemento);
                    cmd.Parameters.AddWithValue("@GRUPO", grupo);
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

        public static PLAN_CUENTA getByPk(
        int ID)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM PLAN_CUENTA WHERE");
                sql.AppendLine("ID = @ID ORDER BY DESC_SUBCUENTA ASC");
                PLAN_CUENTA obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<PLAN_CUENTA> lst = mapeo(dr);
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

        public static int insert(PLAN_CUENTA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO PLAN_CUENTA(");
                sql.AppendLine("EJERCICIO");
                sql.AppendLine(", ELEMENTO");
                sql.AppendLine(", DESC_ELEMENTO");
                sql.AppendLine(", GRUPO");
                sql.AppendLine(", DESC_GRUPO");
                sql.AppendLine(", CUENTA");
                sql.AppendLine(", DESC_CUENTA");
                sql.AppendLine(", SUB_CUENTA");
                sql.AppendLine(", DESC_SUBCUENTA");
                sql.AppendLine(", AUXILIAR");
                sql.AppendLine(", DESC_AUXILIAR");
                sql.AppendLine(", NRO_AGRUPACION");
                sql.AppendLine(", DESC_AGRUPACION");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@EJERCICIO");
                sql.AppendLine(", @ELEMENTO");
                sql.AppendLine(", @DESC_ELEMENTO");
                sql.AppendLine(", @GRUPO");
                sql.AppendLine(", @DESC_GRUPO");
                sql.AppendLine(", @CUENTA");
                sql.AppendLine(", @DESC_CUENTA");
                sql.AppendLine(", @SUB_CUENTA");
                sql.AppendLine(", @DESC_SUBCUENTA");
                sql.AppendLine(", @AUXILIAR");
                sql.AppendLine(", @DESC_AUXILIAR");
                sql.AppendLine(", @NRO_AGRUPACION");
                sql.AppendLine(", @DESC_AGRUPACION");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@EJERCICIO", obj.EJERCICIO);
                    cmd.Parameters.AddWithValue("@ELEMENTO", obj.ELEMENTO);
                    cmd.Parameters.AddWithValue("@DESC_ELEMENTO", obj.DESC_ELEMENTO);
                    cmd.Parameters.AddWithValue("@GRUPO", obj.GRUPO);
                    cmd.Parameters.AddWithValue("@DESC_GRUPO", obj.DESC_GRUPO);
                    cmd.Parameters.AddWithValue("@CUENTA", obj.CUENTA);
                    cmd.Parameters.AddWithValue("@DESC_CUENTA", obj.DESC_CUENTA);
                    cmd.Parameters.AddWithValue("@SUB_CUENTA", obj.SUB_CUENTA);
                    cmd.Parameters.AddWithValue("@DESC_SUBCUENTA", obj.DESC_SUBCUENTA);
                    cmd.Parameters.AddWithValue("@AUXILIAR", obj.AUXILIAR);
                    cmd.Parameters.AddWithValue("@DESC_AUXILIAR", obj.DESC_AUXILIAR);
                    cmd.Parameters.AddWithValue("@NRO_AGRUPACION", obj.NRO_AGRUPACION);
                    cmd.Parameters.AddWithValue("@DESC_AGRUPACION", obj.DESC_AGRUPACION);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(PLAN_CUENTA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  PLAN_CUENTA SET");
                sql.AppendLine("EJERCICIO=@EJERCICIO");
                sql.AppendLine(", ELEMENTO=@ELEMENTO");
                sql.AppendLine(", DESC_ELEMENTO=@DESC_ELEMENTO");
                sql.AppendLine(", GRUPO=@GRUPO");
                sql.AppendLine(", DESC_GRUPO=@DESC_GRUPO");
                sql.AppendLine(", CUENTA=@CUENTA");
                sql.AppendLine(", DESC_CUENTA=@DESC_CUENTA");
                sql.AppendLine(", SUB_CUENTA=@SUB_CUENTA");
                sql.AppendLine(", DESC_SUBCUENTA=@DESC_SUBCUENTA");
                sql.AppendLine(", AUXILIAR=@AUXILIAR");
                sql.AppendLine(", DESC_AUXILIAR=@DESC_AUXILIAR");
                sql.AppendLine(", NRO_AGRUPACION=@NRO_AGRUPACION");
                sql.AppendLine(", DESC_AGRUPACION=@DESC_AGRUPACION");
                sql.AppendLine("WHERE");
                sql.AppendLine("ID=@ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@EJERCICIO", obj.EJERCICIO);
                    cmd.Parameters.AddWithValue("@ELEMENTO", obj.ELEMENTO);
                    cmd.Parameters.AddWithValue("@DESC_ELEMENTO", obj.DESC_ELEMENTO);
                    cmd.Parameters.AddWithValue("@GRUPO", obj.GRUPO);
                    cmd.Parameters.AddWithValue("@DESC_GRUPO", obj.DESC_GRUPO);
                    cmd.Parameters.AddWithValue("@CUENTA", obj.CUENTA);
                    cmd.Parameters.AddWithValue("@DESC_CUENTA", obj.DESC_CUENTA);
                    cmd.Parameters.AddWithValue("@SUB_CUENTA", obj.SUB_CUENTA);
                    cmd.Parameters.AddWithValue("@DESC_SUBCUENTA", obj.DESC_SUBCUENTA);
                    cmd.Parameters.AddWithValue("@AUXILIAR", obj.AUXILIAR);
                    cmd.Parameters.AddWithValue("@DESC_AUXILIAR", obj.DESC_AUXILIAR);
                    cmd.Parameters.AddWithValue("@NRO_AGRUPACION", obj.NRO_AGRUPACION);
                    cmd.Parameters.AddWithValue("@DESC_AGRUPACION", obj.DESC_AGRUPACION);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(PLAN_CUENTA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  PLAN_CUENTA ");
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

