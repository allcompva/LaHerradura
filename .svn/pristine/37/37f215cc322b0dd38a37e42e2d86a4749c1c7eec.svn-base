using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class FACTURAS_A_INSERTAR : DALBase
    {
        public int PTO_VTA { get; set; }
        public int NRO_CTE { get; set; }
        public string CAE { get; set; }
        public DateTime FECHA_CAE { get; set; }
        public DateTime VENC_CAE { get; set; }
        public string CUIT { get; set; }
        public decimal MONTO { get; set; }
        public int ID { get; set; }

        public FACTURAS_A_INSERTAR()
        {
            PTO_VTA = 0;
            NRO_CTE = 0;
            CAE = string.Empty;
            FECHA_CAE = UTILS.getFechaActual();
            VENC_CAE = UTILS.getFechaActual();
            CUIT = string.Empty;
            MONTO = 0;
            ID = 0;
        }

        private static List<FACTURAS_A_INSERTAR> mapeo(SqlDataReader dr)
        {
            List<FACTURAS_A_INSERTAR> lst = new List<FACTURAS_A_INSERTAR>();
            FACTURAS_A_INSERTAR obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new FACTURAS_A_INSERTAR();
                    if (!dr.IsDBNull(0)) { obj.PTO_VTA = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTE = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.CAE = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.FECHA_CAE = dr.GetDateTime(3); }
                    if (!dr.IsDBNull(4)) { obj.VENC_CAE = dr.GetDateTime(4); }
                    if (!dr.IsDBNull(5)) { obj.CUIT = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.MONTO = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.ID = dr.GetInt32(7); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<FACTURAS_A_INSERTAR> read()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.PTO_VTA, A.NRO_CTE, A.CAE, A.FECHA_CAE, A.VENC_CAE, A.CUIT, A.MONTO, C.ID");
                sql.AppendLine("FROM FACTURAS_A_INSERTAR A");
                sql.AppendLine("INNER JOIN PERSONAS_X_INMUEBLES B ON A.CUIT=B.CUIT");
                sql.AppendLine("INNER JOIN CTACTE_EXPENSAS C ON B.NRO_CTA=C.NRO_CTA AND PERIODO=20210100 AND TIPO_MOVIMIENTO=1");

                List<FACTURAS_A_INSERTAR> lst = new List<FACTURAS_A_INSERTAR>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
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

        public static FACTURAS_A_INSERTAR getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM FACTURAS_A_INSERTAR WHERE");
                FACTURAS_A_INSERTAR obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<FACTURAS_A_INSERTAR> lst = mapeo(dr);
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

        public static void insert(FACTURAS_A_INSERTAR obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO FACTURAS_A_INSERTAR(");
                sql.AppendLine("PTO_VTA");
                sql.AppendLine(", NRO_CTE");
                sql.AppendLine(", CAE");
                sql.AppendLine(", FECHA_CAE");
                sql.AppendLine(", VENC_CAE");
                sql.AppendLine(", CUIT");
                sql.AppendLine(", MONTO");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@PTO_VTA");
                sql.AppendLine(", @NRO_CTE");
                sql.AppendLine(", @CAE");
                sql.AppendLine(", @FECHA_CAE");
                sql.AppendLine(", @VENC_CAE");
                sql.AppendLine(", @CUIT");
                sql.AppendLine(", @MONTO");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@CAE", obj.CAE);
                    cmd.Parameters.AddWithValue("@FECHA_CAE", obj.FECHA_CAE);
                    cmd.Parameters.AddWithValue("@VENC_CAE", obj.VENC_CAE);
                    cmd.Parameters.AddWithValue("@CUIT", obj.CUIT);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(FACTURAS_A_INSERTAR obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  FACTURAS_A_INSERTAR SET");
                sql.AppendLine("PTO_VTA=@PTO_VTA");
                sql.AppendLine(", NRO_CTE=@NRO_CTE");
                sql.AppendLine(", CAE=@CAE");
                sql.AppendLine(", FECHA_CAE=@FECHA_CAE");
                sql.AppendLine(", VENC_CAE=@VENC_CAE");
                sql.AppendLine(", CUIT=@CUIT");
                sql.AppendLine(", MONTO=@MONTO");
                sql.AppendLine("WHERE");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@PTO_VTA", obj.PTO_VTA);
                    cmd.Parameters.AddWithValue("@NRO_CTE", obj.NRO_CTE);
                    cmd.Parameters.AddWithValue("@CAE", obj.CAE);
                    cmd.Parameters.AddWithValue("@FECHA_CAE", obj.FECHA_CAE);
                    cmd.Parameters.AddWithValue("@VENC_CAE", obj.VENC_CAE);
                    cmd.Parameters.AddWithValue("@CUIT", obj.CUIT);
                    cmd.Parameters.AddWithValue("@MONTO", obj.MONTO);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(FACTURAS_A_INSERTAR obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  FACTURAS_A_INSERTAR ");
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

