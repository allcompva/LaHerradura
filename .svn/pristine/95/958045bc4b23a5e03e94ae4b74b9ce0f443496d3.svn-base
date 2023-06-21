using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class VISTA_CAJAS : DALBase
    {
        public DateTime HORA { get; set; }
        public decimal SALDO_ANTERIOR_EFECTIVO { get; set; }
        public decimal SALDO_ANTERIOR_BANCO { get; set; }
        public decimal SALDO_ANTERIOR_CHEQUE { get; set; }
        public decimal INGRESO_EFECTIVO { get; set; }
        public decimal INGRESO_BANCO { get; set; }
        public decimal INGRESO_CHEQUE { get; set; }
        public decimal EGRESO_EFECTIVO { get; set; }
        public decimal EGRESO_BANCO { get; set; }
        public decimal EGRESO_CHEQUE { get; set; }
        public decimal SALDO_EFECTIVO { get; set; }
        public decimal SALDO_BANCO { get; set; }
        public decimal SALDO_CHEQUE { get; set; }

        public VISTA_CAJAS()
        {
            HORA = UTILS.getFechaActual();
            SALDO_ANTERIOR_EFECTIVO = 0;
            SALDO_ANTERIOR_BANCO = 0;
            SALDO_ANTERIOR_CHEQUE = 0;
            INGRESO_EFECTIVO = 0;
            INGRESO_BANCO = 0;
            INGRESO_CHEQUE = 0;
            EGRESO_EFECTIVO = 0;
            EGRESO_BANCO = 0;
            EGRESO_CHEQUE = 0;
            SALDO_EFECTIVO = 0;
            SALDO_BANCO = 0;
            SALDO_CHEQUE = 0;
        }

        private static List<VISTA_CAJAS> mapeo(SqlDataReader dr)
        {
            List<VISTA_CAJAS> lst = new List<VISTA_CAJAS>();
            VISTA_CAJAS obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new VISTA_CAJAS();
                    if (!dr.IsDBNull(0)) { obj.HORA = dr.GetDateTime(0); }
                    if (!dr.IsDBNull(1)) { obj.SALDO_ANTERIOR_EFECTIVO = dr.GetDecimal(1); }
                    if (!dr.IsDBNull(2)) { obj.SALDO_ANTERIOR_BANCO = dr.GetDecimal(2); }
                    if (!dr.IsDBNull(3)) { obj.SALDO_ANTERIOR_CHEQUE = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.INGRESO_EFECTIVO = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.INGRESO_BANCO = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.INGRESO_CHEQUE = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.EGRESO_EFECTIVO = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.EGRESO_BANCO = dr.GetDecimal(8); }
                    if (!dr.IsDBNull(9)) { obj.EGRESO_CHEQUE = dr.GetDecimal(9); }
                    if (!dr.IsDBNull(10)) { obj.SALDO_EFECTIVO = dr.GetDecimal(10); }
                    if (!dr.IsDBNull(11)) { obj.SALDO_BANCO = dr.GetDecimal(11); }
                    if (!dr.IsDBNull(12)) { obj.SALDO_CHEQUE = dr.GetDecimal(12); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<VISTA_CAJAS> read()
        {
            try
            {
                List<VISTA_CAJAS> lst = new List<VISTA_CAJAS>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT DISTINCT A.HORA,");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) - ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2)");
                sql.AppendLine("AS 'SALDO ANTERIOR EFECTIVO',");

                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) -");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2)");
                sql.AppendLine("AS 'SALDO ANTERIOR BANCO',");

                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) -");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2)");
                sql.AppendLine("AS 'SALDO ANTERIOR CHEQUE',");

                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) AS 'INGRESO EFECTIVO',");

                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) AS 'INGRESO BANCO',");

                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) AS 'INGRESO CHEQUE',");

                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) AS 'EGRESO EFECTIVO',");

                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) AS 'EGRESO BANCO',");

                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) AS 'EGRESO CHEQUE',");

                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) - ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) + ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) -");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) AS 'SALDO EFECTIVO',");

                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) - ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) + ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) -");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) AS 'SALDO BANCO',");

                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) - ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) + ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) -");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) AS 'SALDO CHEQUE'");

                sql.AppendLine("FROM TB_MOVIM_CAJA A");
                sql.AppendLine("GROUP BY HORA");
                sql.AppendLine("ORDER BY HORA DESC");

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
        public static VISTA_CAJAS getByFecha(DateTime fecha)
        {
            try
            {
                VISTA_CAJAS obj = null;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.HORA,");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) - ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2)");
                sql.AppendLine("AS 'SALDO ANTERIOR EFECTIVO',");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) - ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2)");
                sql.AppendLine("AS 'SALDO ANTERIOR BANCO',");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) - ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2)");
                sql.AppendLine("AS 'SALDO ANTERIOR CHEQUE',");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) AS 'INGRESO EFECTIVO',");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) AS 'INGRESO BANCO',");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) AS 'INGRESO CHEQUE',");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) AS 'EGRESO EFECTIVO',");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) AS 'EGRESO BANCO',");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) AS 'EGRESO CHEQUE',");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) - ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) + ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) -");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 1 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) AS 'SALDO EFECTIVO',");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) - ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) + ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) -");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 7 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) AS 'SALDO BANCO',");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) - ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA < A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) + ");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 1) -");
                sql.AppendLine("(SELECT ISNULL(SUM(MONTO), 0)");
                sql.AppendLine("FROM TB_MOVIM_CAJA WHERE ID_CTA_INGRESO = 2 AND HORA = A.HORA");
                sql.AppendLine("AND TIPO_MOV = 2) AS 'SALDO CHEQUE'");
                sql.AppendLine("FROM TB_MOVIM_CAJA A WHERE HORA=@HORA");
                sql.AppendLine("GROUP BY HORA");
                sql.AppendLine("ORDER BY HORA DESC");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@HORA", fecha);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<VISTA_CAJAS> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static VISTA_CAJAS getByPk(
        )
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM VISTA_CAJAS WHERE");
                VISTA_CAJAS obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<VISTA_CAJAS> lst = mapeo(dr);
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




    }
}

