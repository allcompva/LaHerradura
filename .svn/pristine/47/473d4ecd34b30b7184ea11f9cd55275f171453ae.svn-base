using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Carnets
{
    public class USUARIOS_CARNETS:DALBase
    {
        public int ID_USUARIO { get; set; }
        public string NOMBRE_COMPLETO { get; set; }
        public string NOMBRE { get; set; }
        public string NOMBRE_OFICINA { get; set; }
        public int PERMISO { get; set; }
        public bool ACTIVO { get; set; }

        public USUARIOS_CARNETS()
        {
            ID_USUARIO = 0;
            NOMBRE_COMPLETO = string.Empty;
            NOMBRE = string.Empty;
            NOMBRE_OFICINA = string.Empty;
            PERMISO = 0;
            ACTIVO = true;
        }
        public static void insert(USUARIOS_CARNETS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO USUARIO_PERMISOS");
                sql.AppendLine("(ID_USUARIO,PERMISO,ACTIVO)");
                sql.AppendLine("VALUES");
                sql.AppendLine("(@ID_USUARIO,@PERMISO,@ACTIVO)");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_USUARIO", obj.ID_USUARIO);
                    cmd.Parameters.AddWithValue("@PERMISO", obj.PERMISO);
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
        public static void activaDesactiva(int pk, bool activa)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE USUARIO_PERMISOS");
                sql.AppendLine("SET ACTIVO = @ACTIVO");
                sql.AppendLine("WHERE ID_USUARIO = @ID_USUARIO");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ACTIVO", activa);
                    cmd.Parameters.AddWithValue("@ID_USUARIO", pk);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();


                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void updatePermiso(int pk, int permiso)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE USUARIO_PERMISOS");
                sql.AppendLine("SET PERMISO = @PERMISO");
                sql.AppendLine("WHERE ID_USUARIO = @ID_USUARIO");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PERMISO", permiso);
                    cmd.Parameters.AddWithValue("@ID_USUARIO", pk);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<USUARIOS_CARNETS> read()
        {
            try
            {
                List<USUARIOS_CARNETS> lst = new List<USUARIOS_CARNETS>();
                USUARIOS_CARNETS obj;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID_USUARIO, B.NOMBRE_COMPLETO, B.NOMBRE, C.NOMBRE_OFICINA, A.PERMISO, A.ACTIVO");
                sql.AppendLine("FROM TURNOS_CARNETS.DBO.USUARIO_PERMISOS A");
                sql.AppendLine("INNER JOIN SIIMVA.DBO.USUARIOS_V2 B ON A.ID_USUARIO = B.COD_USUARIO");
                sql.AppendLine("INNER JOIN SIIMVA.DBO.OFICINAS C ON C.CODIGO_OFICINA = B.COD_OFICINA");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int ID_USUARIO = dr.GetOrdinal("ID_USUARIO");
                        int NOMBRE_COMPLETO = dr.GetOrdinal("NOMBRE_COMPLETO");
                        int NOMBRE = dr.GetOrdinal("NOMBRE");
                        int NOMBRE_OFICINA = dr.GetOrdinal("NOMBRE_OFICINA");
                        int PERMISO = dr.GetOrdinal("PERMISO");
                        int ACTIVO = dr.GetOrdinal("ACTIVO");

                        while (dr.Read())
                        {
                            obj = new USUARIOS_CARNETS();
                            if (!dr.IsDBNull(ID_USUARIO)) { obj.ID_USUARIO = dr.GetInt32(ID_USUARIO); }
                            if (!dr.IsDBNull(NOMBRE_COMPLETO)) { obj.NOMBRE_COMPLETO = dr.GetString(NOMBRE_COMPLETO); }
                            if (!dr.IsDBNull(NOMBRE)) { obj.NOMBRE = dr.GetString(NOMBRE); }
                            if (!dr.IsDBNull(NOMBRE_OFICINA)) { obj.NOMBRE_OFICINA = dr.GetString(NOMBRE_OFICINA); }
                            if (!dr.IsDBNull(PERMISO)) { obj.PERMISO = dr.GetInt32(PERMISO); }
                            if (!dr.IsDBNull(ACTIVO)) { obj.ACTIVO = dr.GetBoolean(ACTIVO); }
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
        public static USUARIOS_CARNETS getByPk(int pk)
        {
            try
            {
                USUARIOS_CARNETS obj = null;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID_USUARIO, B.NOMBRE_COMPLETO, B.NOMBRE, C.NOMBRE_OFICINA, A.PERMISO, A.ACTIVO");
                sql.AppendLine("FROM TURNOS_CARNETS.DBO.USUARIO_PERMISOS A");
                sql.AppendLine("INNER JOIN SIIMVA.DBO.USUARIOS_V2 B ON A.ID_USUARIO = B.COD_USUARIO");
                sql.AppendLine("INNER JOIN SIIMVA.DBO.OFICINAS C ON C.CODIGO_OFICINA = B.COD_OFICINA");
                sql.AppendLine("WHERE A.ID_USUARIO = @id");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@id", pk);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int ID_USUARIO = dr.GetOrdinal("ID_USUARIO");
                        int NOMBRE_COMPLETO = dr.GetOrdinal("NOMBRE_COMPLETO");
                        int NOMBRE = dr.GetOrdinal("NOMBRE");
                        int NOMBRE_OFICINA = dr.GetOrdinal("NOMBRE_OFICINA");
                        int PERMISO = dr.GetOrdinal("PERMISO");
                        int ACTIVO = dr.GetOrdinal("ACTIVO");

                        while (dr.Read())
                        {
                            obj = new USUARIOS_CARNETS();
                            if (!dr.IsDBNull(ID_USUARIO)) { obj.ID_USUARIO = dr.GetInt32(ID_USUARIO); }
                            if (!dr.IsDBNull(NOMBRE_COMPLETO)) { obj.NOMBRE_COMPLETO = dr.GetString(NOMBRE_COMPLETO); }
                            if (!dr.IsDBNull(NOMBRE)) { obj.NOMBRE = dr.GetString(NOMBRE); }
                            if (!dr.IsDBNull(NOMBRE_OFICINA)) { obj.NOMBRE_OFICINA = dr.GetString(NOMBRE_OFICINA); }
                            if (!dr.IsDBNull(PERMISO)) { obj.PERMISO = dr.GetInt32(PERMISO); }
                            if (!dr.IsDBNull(ACTIVO)) { obj.ACTIVO = dr.GetBoolean(ACTIVO); }
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
        public static List<USUARIOS_CARNETS> readDisponibles()
        {
            try
            {
                List<USUARIOS_CARNETS> lst = new List<USUARIOS_CARNETS>();
                USUARIOS_CARNETS obj;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.COD_USUARIO, A.NOMBRE_COMPLETO, A.NOMBRE, C.NOMBRE_OFICINA");
                sql.AppendLine("FROM SIIMVA.DBO.USUARIOS_V2 A");
                sql.AppendLine("INNER JOIN SIIMVA.DBO.OFICINAS C ON C.CODIGO_OFICINA = A.COD_OFICINA");
                sql.AppendLine("WHERE A.COD_USUARIO NOT IN(SELECT ID_USUARIO FROM TURNOS_CARNETS.DBO.USUARIO_PERMISOS)");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int ID_USUARIO = dr.GetOrdinal("COD_USUARIO");
                        int NOMBRE_COMPLETO = dr.GetOrdinal("NOMBRE_COMPLETO");
                        int NOMBRE = dr.GetOrdinal("NOMBRE");
                        int NOMBRE_OFICINA = dr.GetOrdinal("NOMBRE_OFICINA");

                        while (dr.Read())
                        {
                            obj = new USUARIOS_CARNETS();
                            if (!dr.IsDBNull(ID_USUARIO)) { obj.ID_USUARIO = dr.GetInt32(ID_USUARIO); }
                            if (!dr.IsDBNull(NOMBRE_COMPLETO)) { obj.NOMBRE_COMPLETO = dr.GetString(NOMBRE_COMPLETO); }
                            if (!dr.IsDBNull(NOMBRE)) { obj.NOMBRE = dr.GetString(NOMBRE); }
                            if (!dr.IsDBNull(NOMBRE_OFICINA)) { obj.NOMBRE_OFICINA = dr.GetString(NOMBRE_OFICINA); }
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
    }
}
