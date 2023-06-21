using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TB_MEDIOS_PAGO:DALBase
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public int DIAS_ACREDITACION { get; set; }
        public bool ACTIVA { get; set; }
        public string IMAGEN { get; set; }
        public bool POR_DEFECTO { get; set; }
        public bool CUPON { get; set; }

        public TB_MEDIOS_PAGO()
        {
            ID = 0;
            NOMBRE = string.Empty;
            DIAS_ACREDITACION = 0;
            ACTIVA = true;
            IMAGEN = string.Empty;
            POR_DEFECTO = false;
            CUPON = true;
        }

        public static List<TB_MEDIOS_PAGO> read()
        {
            try
            {
                List<TB_MEDIOS_PAGO> lst = new List<TB_MEDIOS_PAGO>();
                TB_MEDIOS_PAGO obj;

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        "SELECT *FROM TB_MEDIOS_PAGO WHERE ACTIVA = 1 ORDER BY POR_DEFECTO DESC, NOMBRE";
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int NOMBRE = dr.GetOrdinal("NOMBRE");
                        int DIAS_ACREDITACION = dr.GetOrdinal("DIAS_ACREDITACION");
                        int ACTIVA = dr.GetOrdinal("ACTIVA");
                        int IMAGEN = dr.GetOrdinal("IMAGEN");
                        int POR_DEFECTO = dr.GetOrdinal("POR_DEFECTO");
                        int CUPON = dr.GetOrdinal("CUPON");

                        while (dr.Read())
                        {
                            obj = new TB_MEDIOS_PAGO();
                            if (!dr.IsDBNull(ID)) { obj.ID = dr.GetInt32(ID); }
                            if (!dr.IsDBNull(NOMBRE)) { obj.NOMBRE = dr.GetString(NOMBRE); }
                            if (!dr.IsDBNull(DIAS_ACREDITACION)) { obj.DIAS_ACREDITACION = dr.GetInt32(DIAS_ACREDITACION); }
                            if (!dr.IsDBNull(ACTIVA)) { obj.ACTIVA = dr.GetBoolean(ACTIVA); }
                            if (!dr.IsDBNull(IMAGEN)) { obj.IMAGEN = dr.GetString(IMAGEN); }
                            if (!dr.IsDBNull(POR_DEFECTO)) { obj.POR_DEFECTO = dr.GetBoolean(POR_DEFECTO); }
                            if (!dr.IsDBNull(CUPON)) { obj.CUPON = dr.GetBoolean(CUPON); }
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

        public static TB_MEDIOS_PAGO getByPk(int pk)
        {
            try
            {
                TB_MEDIOS_PAGO obj = null;

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM TB_MEDIOS_PAGO WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", pk);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int NOMBRE = dr.GetOrdinal("NOMBRE");
                        int DIAS_ACREDITACION = dr.GetOrdinal("DIAS_ACREDITACION");
                        int ACTIVA = dr.GetOrdinal("ACTIVA");
                        int IMAGEN = dr.GetOrdinal("IMAGEN");
                        int POR_DEFECTO = dr.GetOrdinal("POR_DEFECTO");
                        int CUPON = dr.GetOrdinal("CUPON");

                        while (dr.Read())
                        {
                            obj = new TB_MEDIOS_PAGO();
                            if (!dr.IsDBNull(ID)) { obj.ID = dr.GetInt32(ID); }
                            if (!dr.IsDBNull(NOMBRE)) { obj.NOMBRE = dr.GetString(NOMBRE); }
                            if (!dr.IsDBNull(DIAS_ACREDITACION)) { obj.DIAS_ACREDITACION = dr.GetInt32(DIAS_ACREDITACION); }
                            if (!dr.IsDBNull(ACTIVA)) { obj.ACTIVA = dr.GetBoolean(ACTIVA); }
                            if (!dr.IsDBNull(IMAGEN)) { obj.IMAGEN = dr.GetString(IMAGEN); }
                            if (!dr.IsDBNull(POR_DEFECTO)) { obj.POR_DEFECTO = dr.GetBoolean(POR_DEFECTO); }
                            if (!dr.IsDBNull(CUPON)) { obj.CUPON = dr.GetBoolean(CUPON); }
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
