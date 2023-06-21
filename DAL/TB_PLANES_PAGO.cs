using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class TB_PLANES_PAGO:DALBase
    {
        public int ID { get; set; }
        public int ID_TARJETA { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal MONTO_MINIMO { get; set; }
        public decimal COSTO_PLAN { get; set; }
        public decimal RECARGO_CLIENTE { get; set; }
        public bool ACTIVO { get; set; }

        public TB_PLANES_PAGO()
        {
            ID = 0;
            ID_TARJETA = 0;
            DESCRIPCION = string.Empty;
            MONTO_MINIMO = 0;
            COSTO_PLAN = 0;
            RECARGO_CLIENTE = 0;
            ACTIVO = true;
        }

        public static List<TB_PLANES_PAGO> read(int idTarjeta)
        {
            try
            {
                List<TB_PLANES_PAGO> lst = new List<TB_PLANES_PAGO>();
                TB_PLANES_PAGO obj;

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        "SELECT *FROM TB_PLANES_PAGO WHERE ID_TARJETA = @ID";
                    cmd.Parameters.AddWithValue("@ID", idTarjeta);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int ID_TARJETA = dr.GetOrdinal("ID_TARJETA");
                        int DESCRIPCION = dr.GetOrdinal("DESCRIPCION");
                        int MONTO_MINIMO = dr.GetOrdinal("MONTO_MINIMO");
                        int COSTO_PLAN = dr.GetOrdinal("COSTO_PLAN");
                        int RECARGO_CLIENTE = dr.GetOrdinal("RECARGO_CLIENTE");
                        int ACTIVO = dr.GetOrdinal("ACTIVO");

                        while (dr.Read())
                        {
                            obj = new TB_PLANES_PAGO();
                            if (!dr.IsDBNull(ID)) { obj.ID = dr.GetInt32(ID); }
                            if (!dr.IsDBNull(ID_TARJETA)) { obj.ID_TARJETA = dr.GetInt32(ID_TARJETA); }
                            if (!dr.IsDBNull(DESCRIPCION)) { obj.DESCRIPCION = dr.GetString(DESCRIPCION); }
                            if (!dr.IsDBNull(MONTO_MINIMO)) { obj.MONTO_MINIMO = dr.GetDecimal(MONTO_MINIMO); }
                            if (!dr.IsDBNull(COSTO_PLAN)) { obj.COSTO_PLAN = dr.GetDecimal(COSTO_PLAN); }
                            if (!dr.IsDBNull(RECARGO_CLIENTE)) { obj.RECARGO_CLIENTE = dr.GetDecimal(RECARGO_CLIENTE); }
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

        public static TB_PLANES_PAGO getByPk(int id)
        {
            try
            {
                TB_PLANES_PAGO obj = null;

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText =
                        "SELECT *FROM TB_PLANES_PAGO WHERE ID = @ID";
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int ID_TARJETA = dr.GetOrdinal("ID_TARJETA");
                        int DESCRIPCION = dr.GetOrdinal("DESCRIPCION");
                        int MONTO_MINIMO = dr.GetOrdinal("MONTO_MINIMO");
                        int COSTO_PLAN = dr.GetOrdinal("COSTO_PLAN");
                        int RECARGO_CLIENTE = dr.GetOrdinal("RECARGO_CLIENTE");
                        int ACTIVO = dr.GetOrdinal("ACTIVO");

                        while (dr.Read())
                        {
                            obj = new TB_PLANES_PAGO();
                            if (!dr.IsDBNull(ID)) { obj.ID = dr.GetInt32(ID); }
                            if (!dr.IsDBNull(ID_TARJETA)) { obj.ID_TARJETA = dr.GetInt32(ID_TARJETA); }
                            if (!dr.IsDBNull(DESCRIPCION)) { obj.DESCRIPCION = dr.GetString(DESCRIPCION); }
                            if (!dr.IsDBNull(MONTO_MINIMO)) { obj.MONTO_MINIMO = dr.GetDecimal(MONTO_MINIMO); }
                            if (!dr.IsDBNull(COSTO_PLAN)) { obj.COSTO_PLAN = dr.GetDecimal(COSTO_PLAN); }
                            if (!dr.IsDBNull(RECARGO_CLIENTE)) { obj.RECARGO_CLIENTE = dr.GetDecimal(RECARGO_CLIENTE); }
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
