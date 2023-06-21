using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TB_MOVIM_CAJA:DALBase
    {    
        public int ID { get; set; }
        public DateTime? HORA { get; set; }
        public int ID_CTA_INGRESO { get; set; }
        public int ID_CTA_EGRESO { get; set; }
        public int ID_CAJA { get; set; }
        public int ID_USUARIO { get; set; }
        public int ID_RESPONSABLE { get; set; }
        public string DETALLE { get; set; }
        public decimal MONTO { get; set; }
        public int TIPO_MOV { get; set; }
        public int ID_FACTURA { get; set; }
        public int ID_SUCURSAL { get; set; }
        public int ID_PLANILLA { get; set; }

        public TB_MOVIM_CAJA()
        {
            ID = 0;
            HORA = null;
            ID_CTA_INGRESO = 0;
            ID_CTA_EGRESO = 0;
            ID_CAJA = 0;
            ID_USUARIO = 0;
            ID_RESPONSABLE = 0;
            DETALLE = string.Empty;
            MONTO = 0;
            TIPO_MOV = 0;
            ID_FACTURA = 0;
            ID_SUCURSAL = 0;
            ID_PLANILLA = 0;
        }
        public static int insert(TB_MOVIM_CAJA obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO TB_MOVIM_CAJA");
                sql.AppendLine("(HORA,ID_CTA_INGRESO,ID_CTA_EGRESO,ID_CAJA,ID_USUARIO,ID_RESPONSABLE,DETALLE,MONTO,TIPO_MOV,ID_FACTURA,ID_SUCURSAL,ID_PLANILLA)");
                sql.AppendLine("VALUES");
                sql.AppendLine("(@HORA,@ID_CTA_INGRESO,@ID_CTA_EGRESO,@ID_CAJA,@ID_USUARIO,@ID_RESPONSABLE,@DETALLE,@MONTO,@TIPO_MOV,@ID_FACTURA,@ID_SUCURSAL,@ID_PLANILLA)");
                sql.AppendLine("; SELECT SCOPE_IDENTITY()");

                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@HORA", obj.HORA);
                    cmd.Parameters.AddWithValue("@ID_CTA_INGRESO", obj.ID_CTA_INGRESO);
                    cmd.Parameters.AddWithValue("@ID_CTA_EGRESO", obj.ID_CTA_EGRESO);
                    cmd.Parameters.AddWithValue("@ID_CAJA", obj.ID_CAJA);
                    cmd.Parameters.AddWithValue("@ID_USUARIO", obj.ID_USUARIO);
                    cmd.Parameters.AddWithValue("@ID_RESPONSABLE", obj.ID_RESPONSABLE);
                    cmd.Parameters.AddWithValue("@DETALLE", obj.DETALLE);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Parameters.AddWithValue("@TIPO_MOV", obj.TIPO_MOV);
                    cmd.Parameters.AddWithValue("@ID_FACTURA", obj.ID_FACTURA);
                    cmd.Parameters.AddWithValue("@ID_SUCURSAL", obj.ID_SUCURSAL);
                    cmd.Parameters.AddWithValue("@ID_PLANILLA", obj.ID_PLANILLA);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
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
                sql.AppendLine("DELETE TB_MOVIM_CAJA");
                sql.AppendLine("WHERE ID=@ID");


                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
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
        public static List<TB_MOVIM_CAJA> read(int idSucursal)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM TB_MOVIM_CAJA WHERE ID_SUCURSAL=@ID_SUCURSAL");
                TB_MOVIM_CAJA obj = null;
                List<TB_MOVIM_CAJA> lst = new List<TB_MOVIM_CAJA>();
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_SUCURSAL", obj.ID_SUCURSAL);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int HORA = dr.GetOrdinal("HORA");
                        int ID_CTA_INGRESO = dr.GetOrdinal("ID_CTA_INGRESO");
                        int ID_CTA_EGRESO = dr.GetOrdinal("ID_CTA_EGRESO");
                        int ID_CAJA = dr.GetOrdinal("ID_CAJA");
                        int ID_USUARIO = dr.GetOrdinal("ID_USUARIO");
                        int ID_RESPONSABLE = dr.GetOrdinal("ID_RESPONSABLE");
                        int DETALLE = dr.GetOrdinal("DETALLE");
                        int MONTO = dr.GetOrdinal("MONTO");
                        int TIPO_MOV = dr.GetOrdinal("TIPO_MOV");
                        int ID_FACTURA = dr.GetOrdinal("ID_FACTURA");
                        int ID_SUCURSAL = dr.GetOrdinal("ID_SUCURSAL");
                        int ID_PLANILLA = dr.GetOrdinal("ID_PLANILLA");
                        while (dr.Read())
                        {
                            obj = new TB_MOVIM_CAJA();
                            if (!dr.IsDBNull(ID)) obj.ID = dr.GetInt32(ID);
                            if (!dr.IsDBNull(HORA)) obj.HORA = dr.GetDateTime(HORA);
                            if (!dr.IsDBNull(ID_CTA_INGRESO)) obj.ID_CTA_INGRESO = dr.GetInt32(ID_CTA_INGRESO);
                            if (!dr.IsDBNull(ID_CTA_EGRESO)) obj.ID_CTA_EGRESO = dr.GetInt32(ID_CTA_EGRESO);
                            if (!dr.IsDBNull(ID_CAJA)) obj.ID_CAJA = dr.GetInt32(ID_CAJA);
                            if (!dr.IsDBNull(ID_USUARIO)) obj.ID_USUARIO = dr.GetInt32(ID_USUARIO);
                            if (!dr.IsDBNull(ID_RESPONSABLE)) obj.ID_RESPONSABLE = dr.GetInt32(ID_RESPONSABLE);
                            if (!dr.IsDBNull(DETALLE)) obj.DETALLE = dr.GetString(DETALLE);
                            if (!dr.IsDBNull(MONTO)) obj.MONTO = dr.GetDecimal(MONTO);
                            if (!dr.IsDBNull(TIPO_MOV)) obj.TIPO_MOV = dr.GetInt32(TIPO_MOV);
                            if (!dr.IsDBNull(ID_FACTURA)) obj.ID_FACTURA = dr.GetInt32(ID_FACTURA);
                            if (!dr.IsDBNull(ID_SUCURSAL)) obj.ID_SUCURSAL = dr.GetInt32(ID_SUCURSAL);
                            if (!dr.IsDBNull(ID_PLANILLA)) obj.ID_PLANILLA = dr.GetInt32(ID_PLANILLA);
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<TB_MOVIM_CAJA> readByTipoMov(int tipo, int idSucursal)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM TB_MOVIM_CAJA WHERE TIPO_MOV = @TIPO AND ID_SUCURSAL=@ID_SUCURSAL");
                TB_MOVIM_CAJA obj = null;
                List<TB_MOVIM_CAJA> lst = new List<TB_MOVIM_CAJA>();
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@TIPO", tipo);
                    cmd.Parameters.AddWithValue("@ID_SUCURSAL", idSucursal);
                    cmd.CommandText = sql.ToString();

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int HORA = dr.GetOrdinal("HORA");
                        int ID_CTA_INGRESO = dr.GetOrdinal("ID_CTA_INGRESO");
                        int ID_CTA_EGRESO = dr.GetOrdinal("ID_CTA_EGRESO");
                        int ID_CAJA = dr.GetOrdinal("ID_CAJA");
                        int ID_USUARIO = dr.GetOrdinal("ID_USUARIO");
                        int ID_RESPONSABLE = dr.GetOrdinal("ID_RESPONSABLE");
                        int DETALLE = dr.GetOrdinal("DETALLE");
                        int MONTO = dr.GetOrdinal("MONTO");
                        int TIPO_MOV = dr.GetOrdinal("TIPO_MOV");
                        int ID_FACTURA = dr.GetOrdinal("ID_FACTURA");
                        int ID_SUCURSAL = dr.GetOrdinal("ID_SUCURSAL");
                        int ID_PLANILLA = dr.GetOrdinal("ID_PLANILLA");
                        while (dr.Read())
                        {
                            obj = new TB_MOVIM_CAJA();
                            if (!dr.IsDBNull(ID)) obj.ID = dr.GetInt32(ID);
                            if (!dr.IsDBNull(HORA)) obj.HORA = dr.GetDateTime(HORA);
                            if (!dr.IsDBNull(ID_CTA_INGRESO)) obj.ID_CTA_INGRESO = dr.GetInt32(ID_CTA_INGRESO);
                            if (!dr.IsDBNull(ID_CTA_EGRESO)) obj.ID_CTA_EGRESO = dr.GetInt32(ID_CTA_EGRESO);
                            if (!dr.IsDBNull(ID_CAJA)) obj.ID_CAJA = dr.GetInt32(ID_CAJA);
                            if (!dr.IsDBNull(ID_USUARIO)) obj.ID_USUARIO = dr.GetInt32(ID_USUARIO);
                            if (!dr.IsDBNull(ID_RESPONSABLE)) obj.ID_RESPONSABLE = dr.GetInt32(ID_RESPONSABLE);
                            if (!dr.IsDBNull(DETALLE)) obj.DETALLE = dr.GetString(DETALLE);
                            if (!dr.IsDBNull(MONTO)) obj.MONTO = dr.GetDecimal(MONTO);
                            if (!dr.IsDBNull(TIPO_MOV)) obj.TIPO_MOV = dr.GetInt32(TIPO_MOV);
                            if (!dr.IsDBNull(ID_FACTURA)) obj.ID_FACTURA = dr.GetInt32(ID_FACTURA);
                            if (!dr.IsDBNull(ID_SUCURSAL)) obj.ID_SUCURSAL = dr.GetInt32(ID_SUCURSAL);
                            if (!dr.IsDBNull(ID_PLANILLA)) obj.ID_PLANILLA = dr.GetInt32(ID_PLANILLA);
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static TB_MOVIM_CAJA getByPk(int pk)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM TB_MOVIM_CAJA WHERE ID=@ID");
                TB_MOVIM_CAJA obj = null;
                using (SqlConnection conn = GetConnection())
                {
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@ID", pk);
                    cmd.CommandText = sql.ToString();

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int HORA = dr.GetOrdinal("HORA");
                        int ID_CTA_INGRESO = dr.GetOrdinal("ID_CTA_INGRESO");
                        int ID_CTA_EGRESO = dr.GetOrdinal("ID_CTA_EGRESO");
                        int ID_CAJA = dr.GetOrdinal("ID_CAJA");
                        int ID_USUARIO = dr.GetOrdinal("ID_USUARIO");
                        int ID_RESPONSABLE = dr.GetOrdinal("ID_RESPONSABLE");
                        int DETALLE = dr.GetOrdinal("DETALLE");
                        int MONTO = dr.GetOrdinal("MONTO");
                        int TIPO_MOV = dr.GetOrdinal("TIPO_MOV");
                        int ID_FACTURA = dr.GetOrdinal("ID_FACTURA");
                        int ID_PLANILLA = dr.GetOrdinal("ID_PLANILLA");
                        while (dr.Read())
                        {
                            obj = new TB_MOVIM_CAJA();
                            if (!dr.IsDBNull(ID)) obj.ID = dr.GetInt32(ID);
                            if (!dr.IsDBNull(HORA)) obj.HORA = dr.GetDateTime(HORA);
                            if (!dr.IsDBNull(ID_CTA_INGRESO)) obj.ID_CTA_INGRESO = dr.GetInt32(ID_CTA_INGRESO);
                            if (!dr.IsDBNull(ID_CTA_EGRESO)) obj.ID_CTA_EGRESO = dr.GetInt32(ID_CTA_EGRESO);
                            if (!dr.IsDBNull(ID_CAJA)) obj.ID_CAJA = dr.GetInt32(ID_CAJA);
                            if (!dr.IsDBNull(ID_USUARIO)) obj.ID_USUARIO = dr.GetInt32(ID_USUARIO);
                            if (!dr.IsDBNull(ID_RESPONSABLE)) obj.ID_RESPONSABLE = dr.GetInt32(ID_RESPONSABLE);
                            if (!dr.IsDBNull(DETALLE)) obj.DETALLE = dr.GetString(DETALLE);
                            if (!dr.IsDBNull(MONTO)) obj.MONTO = dr.GetDecimal(MONTO);
                            if (!dr.IsDBNull(TIPO_MOV)) obj.TIPO_MOV = dr.GetInt32(TIPO_MOV);
                            if (!dr.IsDBNull(ID_FACTURA)) obj.ID_FACTURA = dr.GetInt32(ID_FACTURA);
                            if (!dr.IsDBNull(ID_PLANILLA)) obj.ID_PLANILLA = dr.GetInt32(ID_PLANILLA);
                        }
                    }
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
