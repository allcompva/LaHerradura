using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Carnets
{
    public class REQUISITOS : DALBase
    {
        public int ID { get; set; }
        public string TITULO { get; set; }
        public string RESENIA { get; set; }
        public string _REQUISITOS { get; set; }
        public int TIPO { get; set; }
        public string CLASE { get; set; }
        public string COLOR { get; set; }
        public bool ACTIVO { get; set; }

        public REQUISITOS()
        {
            ID = 0;
            TITULO = string.Empty;
            RESENIA = string.Empty;
            _REQUISITOS = string.Empty;
            TIPO = 0;
            CLASE = string.Empty;
            COLOR = string.Empty;
            ACTIVO = true;
        }
        public static void insert(REQUISITOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO REQUISITOS");
                sql.AppendLine("(TITULO,RESENIA,REQUISITOS,TIPO,CLASE,COLOR,ACTIVO)");
                sql.AppendLine("VALUES");
                sql.AppendLine("(@TITULO,@RESENIA,@REQUISITOS,@TIPO,@CLASE,@COLOR,1)");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Parameters.AddWithValue("@TITULO", obj.TITULO);
                    cmd.Parameters.AddWithValue("@RESENIA", obj.RESENIA);
                    cmd.Parameters.AddWithValue("@REQUISITOS", obj._REQUISITOS);
                    cmd.Parameters.AddWithValue("@TIPO", obj.TIPO);
                    cmd.Parameters.AddWithValue("@CLASE", obj.CLASE);
                    cmd.Parameters.AddWithValue("@COLOR", obj.COLOR);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void update(REQUISITOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE REQUISITOS");
                sql.AppendLine("SET TITULO=@TITULO,RESENIA=@RESENIA,REQUISITOS=@REQUISITOS,");
                sql.AppendLine("TIPO=@TIPO,CLASE=@CLASE,COLOR=@COLOR");
                sql.AppendLine("WHERE ID=@ID");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Parameters.AddWithValue("@TITULO", obj.TITULO);
                    cmd.Parameters.AddWithValue("@RESENIA", obj.RESENIA);
                    cmd.Parameters.AddWithValue("@REQUISITOS", obj._REQUISITOS);
                    cmd.Parameters.AddWithValue("@TIPO", obj.TIPO);
                    cmd.Parameters.AddWithValue("@CLASE", obj.CLASE);
                    cmd.Parameters.AddWithValue("@COLOR", obj.COLOR);
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
        public static void activaDesactiva(int id, bool opcion)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE REQUISITOS");
                sql.AppendLine("SET ACTIVO=@ACTIVO");
                sql.AppendLine("WHERE ID=@ID");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();

                    cmd.Parameters.AddWithValue("@ACTIVO", opcion);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE REQUISITOS");
                sql.AppendLine("WHERE ID=@ID");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<REQUISITOS> read()
        {
            try
            {
                List<REQUISITOS> lst = new List<REQUISITOS>();
                REQUISITOS obj;

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM REQUISITOS";
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int TITULO = dr.GetOrdinal("TITULO");
                        int RESENIA = dr.GetOrdinal("RESENIA");
                        int _REQUISITOS = dr.GetOrdinal("REQUISITOS");
                        int TIPO = dr.GetOrdinal("TIPO");
                        int CLASE = dr.GetOrdinal("CLASE");
                        int COLOR = dr.GetOrdinal("COLOR");
                        int ACTIVO = dr.GetOrdinal("ACTIVO");
                        while (dr.Read())
                        {
                            obj = new REQUISITOS();
                            if (!dr.IsDBNull(ID)) { obj.ID = dr.GetInt32(ID); }
                            if (!dr.IsDBNull(TITULO)) { obj.TITULO = dr.GetString(TITULO); }
                            if (!dr.IsDBNull(RESENIA)) { obj.RESENIA = dr.GetString(RESENIA); }
                            if (!dr.IsDBNull(_REQUISITOS)) { obj._REQUISITOS = dr.GetString(_REQUISITOS); }
                            if (!dr.IsDBNull(TIPO)) { obj.TIPO = dr.GetInt32(TIPO); }
                            if (!dr.IsDBNull(CLASE)) { obj.CLASE = dr.GetString(CLASE); }
                            if (!dr.IsDBNull(COLOR)) { obj.COLOR = dr.GetString(COLOR); }
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
        public static REQUISITOS getByPk(int pk)
        {
            try
            {
                REQUISITOS obj = null;

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM REQUISITOS WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", pk);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int TITULO = dr.GetOrdinal("TITULO");
                        int RESENIA = dr.GetOrdinal("RESENIA");
                        int _REQUISITOS = dr.GetOrdinal("REQUISITOS");
                        int TIPO = dr.GetOrdinal("TIPO");
                        int CLASE = dr.GetOrdinal("CLASE");
                        int COLOR = dr.GetOrdinal("COLOR");
                        int ACTIVO = dr.GetOrdinal("ACTIVO");
                        while (dr.Read())
                        {
                            obj = new REQUISITOS();
                            if (!dr.IsDBNull(ID)) { obj.ID = dr.GetInt32(ID); }
                            if (!dr.IsDBNull(TITULO)) { obj.TITULO = dr.GetString(TITULO); }
                            if (!dr.IsDBNull(RESENIA)) { obj.RESENIA = dr.GetString(RESENIA); }
                            if (!dr.IsDBNull(_REQUISITOS)) { obj._REQUISITOS = dr.GetString(_REQUISITOS); }
                            if (!dr.IsDBNull(TIPO)) { obj.TIPO = dr.GetInt32(TIPO); }
                            if (!dr.IsDBNull(CLASE)) { obj.CLASE = dr.GetString(CLASE); }
                            if (!dr.IsDBNull(COLOR)) { obj.COLOR = dr.GetString(COLOR); }
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
    }
}
