using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class INMUEBLES : DALBase
    {
        public int NRO_CTA { get; set; }
        public int ID { get; set; }
        public int MANZANA { get; set; }
        public int LOTE { get; set; }
        public string CALLE { get; set; }
        public string NRO { get; set; }
        public bool CON_DEUDA { get; set; }
        public decimal SALDO { get; set; }
        public int CIR { get; set; }
        public int SEC { get; set; }
        public int MAN { get; set; }
        public int PAR { get; set; }
        public int P_H { get; set; }
        public string NRO_CTA_RP { get; set; }
        public bool DEBITO_AUTOMATICO { get; set; }
        public string CBU { get; set; }

        public string BANCO { get; set; }
        public string SUCURSAL { get; set; }
        public string TIPO_COBIS { get; set; }
        public string CUENTA_BANCO { get; set; }
        public string IDENTIFICACION { get; set; }



        public INMUEBLES()
        {
            NRO_CTA = 0;
            ID = 0;
            MANZANA = 0;
            LOTE = 0;
            CALLE = string.Empty;
            NRO = string.Empty;
            CON_DEUDA = false;
            SALDO = 0;
            CIR = 0;
            SEC = 0;
            MAN = 0;
            PAR = 0;
            P_H = 0;
            NRO_CTA_RP = string.Empty;
            DEBITO_AUTOMATICO = false;
            CBU = string.Empty;
        }

        private static List<INMUEBLES> mapeo(SqlDataReader dr)
        {
            List<INMUEBLES> lst = new List<INMUEBLES>();
            INMUEBLES obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new INMUEBLES();
                    if (!dr.IsDBNull(0)) { obj.NRO_CTA = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.ID = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.MANZANA = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.LOTE = dr.GetInt32(3); }
                    if (!dr.IsDBNull(4)) { obj.CALLE = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.NRO = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.CON_DEUDA = dr.GetBoolean(6); }
                    if (!dr.IsDBNull(7)) { obj.SALDO = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.CIR = dr.GetInt32(8); }
                    if (!dr.IsDBNull(9)) { obj.SEC = dr.GetInt32(9); }
                    if (!dr.IsDBNull(10)) { obj.MAN = dr.GetInt32(10); }
                    if (!dr.IsDBNull(11)) { obj.PAR = dr.GetInt32(11); }
                    if (!dr.IsDBNull(12)) { obj.P_H = dr.GetInt32(12); }
                    if (!dr.IsDBNull(13)) { obj.NRO_CTA_RP = dr.GetString(13); }
                    if (!dr.IsDBNull(14)) { obj.DEBITO_AUTOMATICO = dr.GetBoolean(14); }
                    if (!dr.IsDBNull(15)) { obj.CBU = dr.GetString(15); }
                    if (!dr.IsDBNull(16)) { obj.BANCO = dr.GetString(16); }
                    if (!dr.IsDBNull(17)) { obj.SUCURSAL = dr.GetString(17); }
                    if (!dr.IsDBNull(18)) { obj.TIPO_COBIS = dr.GetString(18); }
                    if (!dr.IsDBNull(19)) { obj.CUENTA_BANCO = dr.GetString(19); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<INMUEBLES> read()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *,");
                sql.AppendLine("(SELECT SUM(SALDO_CAPITAL+INTERES_MORA) FROM CTACTE_EXPENSAS B");
                sql.AppendLine("WHERE A.NRO_CTA=B.NRO_CTA AND CAE IS NOT NULL");
                sql.AppendLine("AND PAGADO=0 AND ((TIPO_MOVIMIENTO IN (1,100) AND (NRO_PLAN_PAGO = 0 OR NRO_PLAN_PAGO IS NULL))");
                sql.AppendLine("OR (TIPO_MOVIMIENTO = 3)))");
                sql.AppendLine("FROM INMUEBLES A"); 
                List<INMUEBLES> lst = new List<INMUEBLES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    INMUEBLES obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new INMUEBLES();
                            if (!dr.IsDBNull(0)) { obj.NRO_CTA = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.ID = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.MANZANA = dr.GetInt32(2); }
                            if (!dr.IsDBNull(3)) { obj.LOTE = dr.GetInt32(3); }
                            if (!dr.IsDBNull(4)) { obj.CALLE = dr.GetString(4); }
                            if (!dr.IsDBNull(5)) { obj.NRO = dr.GetString(5); }
                            if (!dr.IsDBNull(6)) { obj.CON_DEUDA = dr.GetBoolean(6); }
                            if (!dr.IsDBNull(7)) { obj.SALDO = dr.GetDecimal(7); }
                            if (!dr.IsDBNull(8)) { obj.CIR = dr.GetInt32(8); }
                            if (!dr.IsDBNull(9)) { obj.SEC = dr.GetInt32(9); }
                            if (!dr.IsDBNull(10)) { obj.MAN = dr.GetInt32(10); }
                            if (!dr.IsDBNull(11)) { obj.PAR = dr.GetInt32(11); }
                            if (!dr.IsDBNull(12)) { obj.P_H = dr.GetInt32(12); }
                            if (!dr.IsDBNull(13)) { obj.NRO_CTA_RP = dr.GetString(13); }
                            if (!dr.IsDBNull(21)) { obj.SALDO = dr.GetDecimal(21); }
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
        public static List<INMUEBLES> getDeudaMora()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID, A.NRO_CTA, MANZANA, LOTE, CALLE, NRO,");
                sql.AppendLine("SUM(B.SALDO_CAPITAL+B.INTERES_MORA) AS SALDO");
                sql.AppendLine("FROM CTACTE_EXPENSAS B");
                sql.AppendLine("INNER JOIN INMUEBLES A ON A.NRO_CTA = B.NRO_CTA");
                sql.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS C ON B.PERIODO=C.PERIODO");
                sql.AppendLine("WHERE A.NRO_CTA=B.NRO_CTA AND CAE IS NOT NULL");
                sql.AppendLine("AND PAGADO=0 AND C.VENCIMIENTO_3 <= GETDATE() AND");
                sql.AppendLine("((TIPO_MOVIMIENTO IN (1,100) AND (NRO_PLAN_PAGO = 0 OR NRO_PLAN_PAGO IS NULL))");
                sql.AppendLine("OR (TIPO_MOVIMIENTO = 3))");
                sql.AppendLine("GROUP BY A.NRO_CTA, A.ID, MANZANA, LOTE, CALLE, NRO");
                sql.AppendLine("HAVING SUM(B.SALDO) > 0");


                List<INMUEBLES> lst = new List<INMUEBLES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    INMUEBLES obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new INMUEBLES();
                            if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.MAN = dr.GetInt32(2); }
                            if (!dr.IsDBNull(3)) { obj.LOTE = dr.GetInt32(3); }
                            if (!dr.IsDBNull(4)) { obj.CALLE = dr.GetString(4); }
                            if (!dr.IsDBNull(5)) { obj.NRO = dr.GetString(5); }
                            if (!dr.IsDBNull(6)) { obj.SALDO = dr.GetDecimal(6); }

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
        public static List<INMUEBLES> getDeuda()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID, A.NRO_CTA, MANZANA, LOTE, CALLE, NRO, SUM(B.SALDO_CAPITAL + B.INTERES_MORA) AS SALDO");
                sql.AppendLine("FROM CTACTE_EXPENSAS B");
                sql.AppendLine("INNER JOIN INMUEBLES A ON A.NRO_CTA = B.NRO_CTA");
                sql.AppendLine("WHERE A.NRO_CTA=B.NRO_CTA AND CAE IS NOT NULL");
                sql.AppendLine("AND PAGADO=0 AND ((TIPO_MOVIMIENTO IN(1,100) AND (NRO_PLAN_PAGO = 0 OR NRO_PLAN_PAGO IS NULL))");
                sql.AppendLine("OR (TIPO_MOVIMIENTO = 3))");
                sql.AppendLine("GROUP BY A.NRO_CTA, A.ID, MANZANA, LOTE, CALLE, NRO");
                sql.AppendLine("HAVING SUM(B.SALDO) > 0");

                List<INMUEBLES> lst = new List<INMUEBLES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    INMUEBLES obj;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new INMUEBLES();
                            if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.NRO_CTA = dr.GetInt32(1); }
                            if (!dr.IsDBNull(2)) { obj.MAN = dr.GetInt32(2); }
                            if (!dr.IsDBNull(3)) { obj.LOTE = dr.GetInt32(3); }
                            if (!dr.IsDBNull(4)) { obj.CALLE = dr.GetString(4); }
                            if (!dr.IsDBNull(5)) { obj.NRO = dr.GetString(5); }
                            if (!dr.IsDBNull(6)) { obj.SALDO = dr.GetDecimal(6); }

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
        public static List<INMUEBLES> getExcuidas(int idConcepto, int periodo, bool excluida)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM INMUEBLES");
                if(excluida)
                    sql.AppendLine("WHERE NRO_CTA IN");
                else
                    sql.AppendLine("WHERE NRO_CTA NOT IN");
                sql.AppendLine("(SELECT NRO_CTA FROM EXCLUSION_CONCEPTO WHERE");
                sql.AppendLine("ID_CONCEPTO = @ID_CONCEPTO AND PERIODO=@PERIODO)");

                List<INMUEBLES> lst = new List<INMUEBLES>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_CONCEPTO", idConcepto);
                    cmd.Parameters.AddWithValue("@PERIODO", periodo);
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
        public static List<INMUEBLES> getDebitos()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM INMUEBLES");
                sql.AppendLine("WHERE DEBITO_AUTOMATICO = 1");


                List<INMUEBLES> lst = new List<INMUEBLES>();
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
        
        public static INMUEBLES getByNroCta(int NRO_CTA)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM INMUEBLES WHERE");
                sql.AppendLine("NRO_CTA = @NRO_CTA");
                INMUEBLES obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", NRO_CTA);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<INMUEBLES> lst = mapeo(dr);
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

        public static int insert(INMUEBLES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO INMUEBLES(");
                sql.AppendLine("NRO_CTA");
                sql.AppendLine(", ID");
                sql.AppendLine(", MANZANA");
                sql.AppendLine(", LOTE");
                sql.AppendLine(", CALLE");
                sql.AppendLine(", NRO");
                sql.AppendLine(", CON_DEUDA");
                sql.AppendLine(", SALDO");
                sql.AppendLine(", CIR");
                sql.AppendLine(", SEC");
                sql.AppendLine(", MAN");
                sql.AppendLine(", PAR");
                sql.AppendLine(", P_H");
                sql.AppendLine(", NRO_CTA_RP");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@NRO_CTA");
                sql.AppendLine(", @ID");
                sql.AppendLine(", @MANZANA");
                sql.AppendLine(", @LOTE");
                sql.AppendLine(", @CALLE");
                sql.AppendLine(", @NRO");
                sql.AppendLine(", @CON_DEUDA");
                sql.AppendLine(", @SALDO");
                sql.AppendLine(", @CIR");
                sql.AppendLine(", @SEC");
                sql.AppendLine(", @MAN");
                sql.AppendLine(", @PAR");
                sql.AppendLine(", @P_H");
                sql.AppendLine(", @NRO_CTA_RP");
                sql.AppendLine(")");
                sql.AppendLine("SELECT SCOPE_IDENTITY()");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@ID", obj.ID);
                    cmd.Parameters.AddWithValue("@MANZANA", obj.MANZANA);
                    cmd.Parameters.AddWithValue("@LOTE", obj.LOTE);
                    cmd.Parameters.AddWithValue("@CALLE", obj.CALLE);
                    cmd.Parameters.AddWithValue("@NRO", obj.NRO);
                    cmd.Parameters.AddWithValue("@CON_DEUDA", obj.CON_DEUDA);
                    cmd.Parameters.AddWithValue("@SALDO", obj.SALDO);
                    cmd.Parameters.AddWithValue("@CIR", obj.CIR);
                    cmd.Parameters.AddWithValue("@SEC", obj.SEC);
                    cmd.Parameters.AddWithValue("@MAN", obj.MAN);
                    cmd.Parameters.AddWithValue("@PAR", obj.PAR);
                    cmd.Parameters.AddWithValue("@P_H", obj.P_H);
                    cmd.Parameters.AddWithValue("@NRO_CTA_RP", obj.NRO_CTA_RP);
                    cmd.Connection.Open();
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(INMUEBLES obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  INMUEBLES SET");
                sql.AppendLine("MANZANA=@MANZANA");
                sql.AppendLine(", LOTE=@LOTE");
                sql.AppendLine(", CALLE=@CALLE");
                sql.AppendLine(", NRO=@NRO");
                sql.AppendLine(", CIR=@CIR");
                sql.AppendLine(", SEC=@SEC");
                sql.AppendLine(", MAN=@MAN");
                sql.AppendLine(", PAR=@PAR");
                sql.AppendLine(", P_H=@P_H");
                sql.AppendLine(", NRO_CTA_RP=@NRO_CTA_RP");
                sql.AppendLine("WHERE");
                sql.AppendLine("NRO_CTA=@NRO_CTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", obj.NRO_CTA);
                    cmd.Parameters.AddWithValue("@MANZANA", obj.MANZANA);
                    cmd.Parameters.AddWithValue("@LOTE", obj.LOTE);
                    cmd.Parameters.AddWithValue("@CALLE", obj.CALLE);
                    cmd.Parameters.AddWithValue("@NRO", obj.NRO);
                    cmd.Parameters.AddWithValue("@CIR", obj.CIR);
                    cmd.Parameters.AddWithValue("@SEC", obj.SEC);
                    cmd.Parameters.AddWithValue("@MAN", obj.MAN);
                    cmd.Parameters.AddWithValue("@PAR", obj.PAR);
                    cmd.Parameters.AddWithValue("@P_H", obj.P_H);
                    cmd.Parameters.AddWithValue("@NRO_CTA_RP", obj.NRO_CTA_RP);
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
                sql.AppendLine("DELETE  INMUEBLES ");
                sql.AppendLine("WHERE");
                sql.AppendLine("NRO_CTA=@NRO_CTA");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", id);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void bajaDebito(int nroCta)
        {
            try
            {
                string sql = @"UPDATE  INMUEBLES
                              set debito_automatico=0
                              WHERE
                              NRO_CTA=@NRO_CTA";
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_CTA", nroCta);
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

