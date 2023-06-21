using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MOVIM_CAJA_GRILLA : DALBase
    {
        public int ID { get; set; }
        public DateTime HORA { get; set; }
        public string CUENTA { get; set; }
        public string CUENTA_EGRESO { get; set; }
        public string USUARIO_CARGA { get; set; }
        public string RESPONSABLE { get; set; }
        public string DETALLE { get; set; }
        public decimal MONTO { get; set; }
        public int ID_CTA_EGRESO { get; set; }
        public int ID_PLANILLA { get; set; }
        public MOVIM_CAJA_GRILLA()
        {
            HORA = UTILS.getFechaActual();
            CUENTA = string.Empty;
            CUENTA_EGRESO = string.Empty;
            USUARIO_CARGA = string.Empty;
            RESPONSABLE = string.Empty;
            DETALLE = string.Empty;
            MONTO = 0;
            ID = 0;
            ID_CTA_EGRESO = 0;
            ID_PLANILLA = 0;
        }
        public static MOVIM_CAJA_GRILLA getByPk(int ID)
        {
            try
            {
                MOVIM_CAJA_GRILLA obj = null;

                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT");
                sql.AppendLine("A.HORA,");
                sql.AppendLine("B.DESCRIPCION 'CUENTA',");
                sql.AppendLine("C.DESCRIPCION 'CUENTA_EGRESO',");
                sql.AppendLine("U1.NOMBRE 'USUARIO_CARGA',");
                sql.AppendLine("U2.NOMBRE 'RESPONSABLE',");
                sql.AppendLine("DETALLE,");
                sql.AppendLine("MONTO,A.ID,A.ID_CTA_EGRESO");
                sql.AppendLine("FROM TB_MOVIM_CAJA A");
                sql.AppendLine("INNER JOIN TB_CTA_INGRESO B ON A.ID_CTA_INGRESO = B.ID");
                sql.AppendLine("INNER JOIN TB_CTA_EGRESOS C ON A.ID_CTA_EGRESO = C.ID");
                sql.AppendLine("INNER JOIN USUARIOS U1 ON A.ID_USUARIO = U1.ID");
                sql.AppendLine("INNER JOIN USUARIOS U2 ON A.ID_RESPONSABLE = U2.ID");
                sql.AppendLine("WHERE A.ID = @ID");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", ID);

                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int ID_ = dr.GetOrdinal("ID");
                        int HORA = dr.GetOrdinal("HORA");
                        int CUENTA = dr.GetOrdinal("CUENTA");
                        int CUENTA_EGRESO = dr.GetOrdinal("CUENTA_EGRESO");
                        int USUARIO_CARGA = dr.GetOrdinal("USUARIO_CARGA");
                        int RESPONSABLE = dr.GetOrdinal("RESPONSABLE");
                        int DETALLE = dr.GetOrdinal("DETALLE");
                        int MONTO = dr.GetOrdinal("MONTO");
                        int ID_CTA_EGRESO = dr.GetOrdinal("ID_CTA_EGRESO");
                        int ID_PLANILLA = dr.GetOrdinal("ID_PLANILLA");
                        while (dr.Read())
                        {
                            obj = new MOVIM_CAJA_GRILLA();
                            if (!dr.IsDBNull(HORA)) obj.HORA = dr.GetDateTime(HORA);
                            if (!dr.IsDBNull(CUENTA)) obj.CUENTA = dr.GetString(CUENTA);
                            if (!dr.IsDBNull(CUENTA_EGRESO)) obj.CUENTA_EGRESO = dr.GetString(CUENTA_EGRESO);
                            if (!dr.IsDBNull(USUARIO_CARGA)) obj.USUARIO_CARGA = dr.GetString(USUARIO_CARGA);
                            if (!dr.IsDBNull(RESPONSABLE)) obj.RESPONSABLE = dr.GetString(RESPONSABLE);
                            if (!dr.IsDBNull(DETALLE)) obj.DETALLE = dr.GetString(DETALLE);
                            if (!dr.IsDBNull(MONTO)) obj.MONTO = dr.GetDecimal(MONTO);
                            if (!dr.IsDBNull(ID_)) obj.ID = dr.GetInt32(ID_);
                            if (!dr.IsDBNull(ID_CTA_EGRESO)) obj.ID_CTA_EGRESO = dr.GetInt32(ID_CTA_EGRESO);
                            if (!dr.IsDBNull(ID_PLANILLA)) obj.ID_PLANILLA = dr.GetInt32(ID_PLANILLA);
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
        public static List<MOVIM_CAJA_GRILLA> read(DateTime FECHA, int TIPO_MOV, int ID_SUCURSAL)
        {
            try
            {
                MOVIM_CAJA_GRILLA obj = null;
                List<MOVIM_CAJA_GRILLA> lst = new List<MOVIM_CAJA_GRILLA>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT");
                sql.AppendLine("A.HORA,");
                sql.AppendLine("B.DESC_SUBCUENTA 'CUENTA',");
                sql.AppendLine("B.DESC_SUBCUENTA 'CUENTA_EGRESO',");
                sql.AppendLine("U1.NOMBRE 'USUARIO_CARGA',");
                sql.AppendLine("U2.NOMBRE 'RESPONSABLE',");
                sql.AppendLine("DETALLE,");
                sql.AppendLine("MONTO,A.ID, A.ID_CTA_EGRESO");
                sql.AppendLine("FROM TB_MOVIM_CAJA A");
                sql.AppendLine("INNER JOIN PLAN_CUENTA B ON A.ID_CTA_INGRESO=B.ID");
                sql.AppendLine("FULL JOIN USUARIOS U1 ON A.ID_USUARIO = U1.ID");
                sql.AppendLine("FULL JOIN USUARIOS U2 ON A.ID_RESPONSABLE = U2.ID");
                sql.AppendLine("WHERE YEAR(A.HORA) = @ANIO AND MONTH(A.HORA) = @MES AND DAY(A.HORA) = @DIA AND TIPO_MOV = @TIPO_MOV AND ID_SUCURSAL=@ID_SUCURSAL");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ANIO", FECHA.Year);
                    cmd.Parameters.AddWithValue("@MES", FECHA.Month);
                    cmd.Parameters.AddWithValue("@DIA", FECHA.Day);
                    cmd.Parameters.AddWithValue("@TIPO_MOV", TIPO_MOV);
                    cmd.Parameters.AddWithValue("@ID_SUCURSAL", ID_SUCURSAL);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int HORA = dr.GetOrdinal("HORA");
                        int CUENTA = dr.GetOrdinal("CUENTA");
                        int CUENTA_EGRESO = dr.GetOrdinal("CUENTA_EGRESO");
                        int USUARIO_CARGA = dr.GetOrdinal("USUARIO_CARGA");
                        int RESPONSABLE = dr.GetOrdinal("RESPONSABLE");
                        int DETALLE = dr.GetOrdinal("DETALLE");
                        int MONTO = dr.GetOrdinal("MONTO");
                        int ID_CTA_EGRESO = dr.GetOrdinal("ID_CTA_EGRESO");
                        //int ID_PLANILLA = dr.GetOrdinal("ID_PLANILLA");
                        while (dr.Read())
                        {
                            obj = new MOVIM_CAJA_GRILLA();
                            if (!dr.IsDBNull(HORA)) obj.HORA = dr.GetDateTime(HORA);
                            if (!dr.IsDBNull(CUENTA)) obj.CUENTA = dr.GetString(CUENTA);
                            if (!dr.IsDBNull(CUENTA_EGRESO)) obj.CUENTA_EGRESO = dr.GetString(CUENTA_EGRESO);
                            if (!dr.IsDBNull(USUARIO_CARGA)) obj.USUARIO_CARGA = dr.GetString(USUARIO_CARGA);
                            if (!dr.IsDBNull(RESPONSABLE)) obj.RESPONSABLE = dr.GetString(RESPONSABLE);
                            if (!dr.IsDBNull(DETALLE)) obj.DETALLE = dr.GetString(DETALLE);
                            if (!dr.IsDBNull(MONTO)) obj.MONTO = dr.GetDecimal(MONTO);
                            if (!dr.IsDBNull(ID)) obj.ID = dr.GetInt32(ID);
                            if (!dr.IsDBNull(ID_CTA_EGRESO)) obj.ID_CTA_EGRESO = dr.GetInt32(ID_CTA_EGRESO);
                            //if (!dr.IsDBNull(ID_PLANILLA)) obj.ID_PLANILLA = dr.GetInt32(ID_PLANILLA);
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
        public static List<MOVIM_CAJA_GRILLA> getByPlanilla(int idPlanilla, int tipoMov)
        {
            try
            {
                MOVIM_CAJA_GRILLA obj = null;
                List<MOVIM_CAJA_GRILLA> lst = new List<MOVIM_CAJA_GRILLA>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT");
                sql.AppendLine("A.HORA,");
                sql.AppendLine("B.DESCRIPCION 'CUENTA',");
                sql.AppendLine("C.DESCRIPCION 'CUENTA_EGRESO',");
                sql.AppendLine("U1.NOMBRE 'USUARIO_CARGA',");
                sql.AppendLine("U2.NOMBRE 'RESPONSABLE',");
                sql.AppendLine("DETALLE,");
                sql.AppendLine("MONTO,A.ID, A.ID_CTA_EGRESO, A.ID_PLANILLA");
                sql.AppendLine("FROM TB_MOVIM_CAJA A");
                sql.AppendLine("INNER JOIN TB_CTA_INGRESO B ON A.ID_CTA_INGRESO = B.ID");
                sql.AppendLine("INNER JOIN TB_CTA_EGRESOS C ON A.ID_CTA_EGRESO = C.ID");
                sql.AppendLine("INNER JOIN USUARIOS U1 ON A.ID_USUARIO = U1.ID");
                sql.AppendLine("INNER JOIN USUARIOS U2 ON A.ID_RESPONSABLE = U2.ID");
                sql.AppendLine("WHERE ID_PLANILLA=@ID_PLANILLA AND TIPO_MOV = @TIPO_MOV");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PLANILLA", idPlanilla);
                    cmd.Parameters.AddWithValue("@TIPO_MOV", tipoMov);
                    cmd.Connection.Open();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int ID = dr.GetOrdinal("ID");
                        int HORA = dr.GetOrdinal("HORA");
                        int CUENTA = dr.GetOrdinal("CUENTA");
                        int CUENTA_EGRESO = dr.GetOrdinal("CUENTA_EGRESO");
                        int USUARIO_CARGA = dr.GetOrdinal("USUARIO_CARGA");
                        int RESPONSABLE = dr.GetOrdinal("RESPONSABLE");
                        int DETALLE = dr.GetOrdinal("DETALLE");
                        int MONTO = dr.GetOrdinal("MONTO");
                        int ID_CTA_EGRESO = dr.GetOrdinal("ID_CTA_EGRESO");
                        int ID_PLANILLA = dr.GetOrdinal("ID_PLANILLA");
                        while (dr.Read())
                        {
                            obj = new MOVIM_CAJA_GRILLA();
                            if (!dr.IsDBNull(HORA)) obj.HORA = dr.GetDateTime(HORA);
                            if (!dr.IsDBNull(CUENTA)) obj.CUENTA = dr.GetString(CUENTA);
                            if (!dr.IsDBNull(CUENTA_EGRESO)) obj.CUENTA_EGRESO = dr.GetString(CUENTA_EGRESO);
                            if (!dr.IsDBNull(USUARIO_CARGA)) obj.USUARIO_CARGA = dr.GetString(USUARIO_CARGA);
                            if (!dr.IsDBNull(RESPONSABLE)) obj.RESPONSABLE = dr.GetString(RESPONSABLE);
                            if (!dr.IsDBNull(DETALLE)) obj.DETALLE = dr.GetString(DETALLE);
                            if (!dr.IsDBNull(MONTO)) obj.MONTO = dr.GetDecimal(MONTO);
                            if (!dr.IsDBNull(ID)) obj.ID = dr.GetInt32(ID);
                            if (!dr.IsDBNull(ID_CTA_EGRESO)) obj.ID_CTA_EGRESO = dr.GetInt32(ID_CTA_EGRESO);
                            if (!dr.IsDBNull(ID_PLANILLA)) obj.ID_PLANILLA = dr.GetInt32(ID_PLANILLA);
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
