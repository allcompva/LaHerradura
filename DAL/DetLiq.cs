using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DetLiq : DALBase

    {
        public string DETALLE { get; set; } = string.Empty;
        public decimal CANTCTAS { get; set; } = 0;
        public decimal TOTAL { get; set; } = 0;
        public decimal CANTHS { get; set; } = 0;

        //public DetLiq()
        //{
        //    DETALLE = string.Empty;
        //    CANTCTAS = 0;
        //    TOTAL = 0;
        //    CANTHS = 0;
        //}

        private static List<DetLiq> mapeo(SqlDataReader dr)
        {
            List<DetLiq> lst = new List<DetLiq>();
            DetLiq obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new DetLiq();
                    if (!dr.IsDBNull(0))
                        obj.DETALLE = dr.GetString(0);
                    if (!dr.IsDBNull(1))
                        obj.CANTCTAS = dr.GetDecimal(1);
                    if (!dr.IsDBNull(2))
                        obj.TOTAL = dr.GetDecimal(2);
                    if (!dr.IsDBNull(3))
                        obj.CANTHS = dr.GetDecimal(3);
                    lst.Add(obj);
                }
            }
            return lst;
        }
        public static List<DetLiq> getTot(int periodo)
        {
            //try
            //{        
            DetLiq obj = null;
            List<DetLiq> lst = new List<DetLiq>();

            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"
                            SELECT 'FACTURACION EXPENSAS', CONVERT(decimal(16, 2),COUNT(*)), SUM(A.MONTO_ORIGINAL), CONVERT(decimal(16, 2),1) AS ORDEN
                            FROM CTACTE_EXPENSAS A
                            WHERE TIPO_MOVIMIENTO = 1 AND PERIODO=@PERIODO
                            UNION
                            SELECT 'FACTURACION INTERESES POR MORA', CONVERT(decimal(16, 2),COUNT(*)), SUM(A.INTERES_PAGADO), CONVERT(decimal(16, 2),2) AS ORDEN
                            FROM CTACTE_EXPENSAS A
                            WHERE TIPO_MOVIMIENTO = 2 AND PERIODO=@PERIODO AND INTERES_MORA > 0
                            UNION
                            SELECT 'NOTAS DE CREDITO EMITIDAS', CONVERT(decimal(16, 2),COUNT(*)), SUM(A.DESC_VENCIMIENTO), CONVERT(decimal(16, 2),3) AS ORDEN
                            FROM CTACTE_EXPENSAS A
                            WHERE TIPO_MOVIMIENTO = 1 AND PERIODO = @PERIODO AND PAGADO = 1 AND DESC_VENCIMIENTO > 0
                            AND ID IN (SELECT ID_CTACTE FROM FACTURAS_X_EXPENSA WHERE TIPO_COMPROBANTE = 13)
                            UNION
                            SELECT 'MONTO COBRADO', 
                                    (SELECT CONVERT(decimal(16, 2), COUNT(*)) 
                                    FROM CTACTE_EXPENSAS A
                                    WHERE TIPO_MOVIMIENTO = 1 AND 
                                    PERIODO=@PERIODO AND PAGADO=1), 
                                    SUM(A.HABER), 
                                    CONVERT(decimal(16, 2), 4) AS ORDEN FROM CTACTE_EXPENSAS A
                            WHERE TIPO_MOVIMIENTO = 2 AND PERIODO=@PERIODO AND ISNULL(NRO_PLAN_PAGO,0) = 0
                            UNION
                            SELECT 'NOTAS DE CREDITO A EMITIR', CONVERT(decimal(16, 2),COUNT(*)), SUM(A.DESC_VENCIMIENTO), CONVERT(decimal(16, 2),5) AS ORDEN
                            FROM CTACTE_EXPENSAS A
                            WHERE TIPO_MOVIMIENTO = 1 AND PERIODO=@PERIODO AND DESC_VENCIMIENTO > 0 AND PAGADO = 0
                            UNION
                            SELECT 'INTERESES POR MORA A FACTURAR', CONVERT(decimal(16, 2),COUNT(*)), SUM(A.INTERES_MORA), CONVERT(decimal(16, 2),6) AS ORDEN
                            FROM CTACTE_EXPENSAS A
                            WHERE TIPO_MOVIMIENTO = 1 AND PERIODO=@PERIODO AND INTERES_MORA > 0 AND PAGADO = 0
                            ORDER BY ORDEN";
                cmd.Parameters.AddWithValue("@PERIODO", periodo);

                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                lst = mapeo(dr);
                obj = new DetLiq();
                obj.CANTCTAS = lst[0].CANTCTAS - lst[3].CANTCTAS;
                obj.CANTHS = 7;
                obj.DETALLE = "A COBRAR (Sin interes)";
                obj.TOTAL = lst[0].TOTAL + lst[1].TOTAL - lst[2].TOTAL -
                    lst[3].TOTAL - lst[4].TOTAL; //+ lst[5].TOTAL;
                lst.Add(obj);

                obj = new DetLiq();
                obj.CANTCTAS = lst[0].CANTCTAS - lst[3].CANTCTAS;
                obj.CANTHS = 7;
                obj.DETALLE = "TOTAL A COBRAR";
                obj.TOTAL = lst[0].TOTAL + lst[1].TOTAL - lst[2].TOTAL -
                    lst[3].TOTAL - lst[4].TOTAL + lst[5].TOTAL;
                lst.Add(obj);
                return lst;
            }
        }
        //catch (Exception ex)
        //{
        //    throw ex;
        //}

        public static List<DetLiq> getTotGral(int anio)
        {
            try
            {
                DetLiq obj = null;
                List<DetLiq> lst = new List<DetLiq>();
                StringBuilder SQL = new StringBuilder();

                //SQL.AppendLine("SELECT 'FACTURACION EXPENSAS', COUNT(*), SUM(A.MONTO_ORIGINAL), 1 AS ORDEN");
                //SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                //SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 1 AND SUBSTRING(CONVERT(VARCHAR,PERIODO), 1, 4)=@PERIODO");
                //SQL.AppendLine("UNION");
                //SQL.AppendLine("SELECT 'FACTURACION INTERESES POR MORA', COUNT(*), SUM(A.INTERES_MORA), 2 AS ORDEN");
                //SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                //SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 2 AND SUBSTRING(CONVERT(VARCHAR,PERIODO), 1, 4)=@PERIODO AND INTERES_MORA > 0");
                //SQL.AppendLine("UNION");
                //SQL.AppendLine("SELECT 'NOTAS DE CREDITO EMITIDAS', COUNT(*), SUM(A.DESC_VENCIMIENTO), 3 AS ORDEN");
                //SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                //SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 2 AND SUBSTRING(CONVERT(VARCHAR,PERIODO), 1, 4)=@PERIODO AND DESC_VENCIMIENTO > 0");
                //SQL.AppendLine("UNION");
                //SQL.AppendLine("SELECT 'MONTO COBRADO', COUNT(*), SUM(A.HABER), 4 AS ORDEN");
                //SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                //SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 2 AND SUBSTRING(CONVERT(VARCHAR,PERIODO), 1, 4)=@PERIODO");
                //SQL.AppendLine("UNION");
                //SQL.AppendLine("SELECT 'NOTAS DE CREDITO A EMITIR', COUNT(*), SUM(A.DESC_VENCIMIENTO), 5 AS ORDEN");
                //SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                //SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 1 AND SUBSTRING(CONVERT(VARCHAR,PERIODO), 1, 4)=@PERIODO AND DESC_VENCIMIENTO > 0 AND PAGADO = 0");
                //SQL.AppendLine("UNION");
                //SQL.AppendLine("SELECT 'INTERESES POR MORA A FACTURAR', COUNT(*), SUM(A.INTERES_MORA), 6 AS ORDEN");
                //SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                //SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 1 AND SUBSTRING(CONVERT(VARCHAR,PERIODO), 1, 4)=@PERIODO AND INTERES_MORA > 0 AND PAGADO = 0");
                //SQL.AppendLine("ORDER BY ORDEN");

                SQL.AppendLine("SELECT 'FACTURACION EXPENSAS', CONVERT(decimal(16, 2),COUNT(*)), SUM(A.MONTO_ORIGINAL), 1 AS ORDEN");
                SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 1 ");
                SQL.AppendLine("UNION");
                SQL.AppendLine("SELECT 'FACTURACION INTERESES POR MORA', COUNT(*), SUM(A.INTERES_MORA), 2 AS ORDEN");
                SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 2 AND INTERES_MORA > 0");
                SQL.AppendLine("UNION");
                SQL.AppendLine("SELECT 'NOTAS DE CREDITO EMITIDAS', COUNT(*), SUM(A.DESC_VENCIMIENTO), 3 AS ORDEN");
                SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 2 AND DESC_VENCIMIENTO > 0");
                SQL.AppendLine("UNION");
                SQL.AppendLine("SELECT 'MONTO COBRADO', COUNT(*), SUM(A.HABER), 4 AS ORDEN");
                SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 2 ");
                SQL.AppendLine("UNION");
                //SQL.AppendLine("SELECT 'NOTAS DE CREDITO A EMITIR', COUNT(*), SUM(A.DESC_VENCIMIENTO), 5 AS ORDEN");
                //SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                //SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 1 AND DESC_VENCIMIENTO > 0 AND PAGADO = 0");
                //SQL.AppendLine("UNION");
                SQL.AppendLine("SELECT 'INTERESES POR MORA A FACTURAR', CONVERT(decimal(16, 2),COUNT(*)), SUM(A.INTERES_MORA), 6 AS ORDEN");
                SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 1 AND INTERES_MORA > 0 AND PAGADO = 0");
                SQL.AppendLine("ORDER BY ORDEN");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", anio);

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    obj = new DetLiq();
                    obj.CANTCTAS = lst[0].CANTCTAS - lst[3].CANTCTAS;
                    obj.CANTHS = 7;
                    obj.DETALLE = "SALDO A COBRAR";
                    obj.TOTAL = lst[0].TOTAL + lst[1].TOTAL - lst[2].TOTAL - lst[3].TOTAL + lst[4].TOTAL;
                    lst.Add(obj);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<DetLiq> getDetalle(int periodo)
        {
            try
            {
                List<DetLiq> lst = new List<DetLiq>();
                StringBuilder SQL = new StringBuilder();
                SQL.AppendLine("SELECT B.DESCRIPCION, SUM(A.CANT), SUM(A.CANT*A.COSTO), CONVERT(decimal(16, 2), 0)");
                SQL.AppendLine("FROM DETALLE_DEUDA A");
                SQL.AppendLine("INNER JOIN CONCEPTOS_EXPENSA B ON A.ID_CONCEPTO = B.ID");
                SQL.AppendLine("WHERE PERIODO = @PERIODO");
                SQL.AppendLine("GROUP BY B.DESCRIPCION, b.ID");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
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
        public static List<DetLiq> getDetalleSin(int periodo)
        {
            try
            {
                List<DetLiq> lst = new List<DetLiq>();
                StringBuilder SQL = new StringBuilder();
                SQL.AppendLine("SELECT B.DESCRIPCION, CONVERT(decimal(16, 2), COUNT(*)), SUM(A.CANT*A.COSTO),");
                SQL.AppendLine("ISNULL ((SELECT SUM(C.CANT) FROM CONCEPTOS_X_INMUEBLE C");
                SQL.AppendLine("WHERE C.ID_CONCEPTO = A.ID_CONCEPTO), 1)");
                SQL.AppendLine("FROM DETALLE_DEUDA A");
                SQL.AppendLine("INNER JOIN CONCEPTOS_EXPENSA B ON A.ID_CONCEPTO = B.ID AND B.ID <> 1");
                SQL.AppendLine("WHERE PERIODO = @PERIODO");
                SQL.AppendLine("GROUP BY B.DESCRIPCION, A.NRO_ORDEN, A.ID_CONCEPTO");
                SQL.AppendLine("ORDER BY A.NRO_ORDEN");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
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
        public static List<DetLiq> getDetalleAnio(int anio)
        {
            try
            {
                List<DetLiq> lst = new List<DetLiq>();
                StringBuilder SQL = new StringBuilder();
                SQL.AppendLine("SELECT B.DESCRIPCION, CONVERT(decimal(16, 2), COUNT(*)), SUM(A.CANT*A.COSTO),");
                SQL.AppendLine("ISNULL ((SELECT SUM(C.CANT) FROM CONCEPTOS_X_INMUEBLE C");
                SQL.AppendLine("WHERE C.ID_CONCEPTO = A.ID_CONCEPTO), 1)");
                SQL.AppendLine("FROM DETALLE_DEUDA A");
                SQL.AppendLine("INNER JOIN CONCEPTOS_EXPENSA B ON A.ID_CONCEPTO = B.ID");
                SQL.AppendLine("WHERE SUBSTRING(CONVERT(VARCHAR,a.PERIODO), 1, 4) = @PERIODO");
                SQL.AppendLine("GROUP BY B.DESCRIPCION, A.NRO_ORDEN, A.ID_CONCEPTO");
                SQL.AppendLine("ORDER BY A.NRO_ORDEN");


                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", anio);
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
        public static List<DetLiq> getDetalleAnioSin(int anio)
        {
            try
            {
                List<DetLiq> lst = new List<DetLiq>();
                StringBuilder SQL = new StringBuilder();
                SQL.AppendLine("SELECT B.DESCRIPCION, CONVERT(decimal(16, 2), COUNT(*)), SUM(A.CANT*A.COSTO),");
                SQL.AppendLine("ISNULL ((SELECT SUM(C.CANT) FROM CONCEPTOS_X_INMUEBLE C");
                SQL.AppendLine("WHERE C.ID_CONCEPTO = A.ID_CONCEPTO), 1)");
                SQL.AppendLine("FROM DETALLE_DEUDA A");
                SQL.AppendLine("INNER JOIN CONCEPTOS_EXPENSA B ON A.ID_CONCEPTO = B.ID AND B.ID <> 1");
                SQL.AppendLine("WHERE SUBSTRING(CONVERT(VARCHAR,a.PERIODO), 1, 4) = @PERIODO");
                SQL.AppendLine("GROUP BY B.DESCRIPCION, A.NRO_ORDEN, A.ID_CONCEPTO");
                SQL.AppendLine("ORDER BY A.NRO_ORDEN");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", anio);
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
        public static List<DetLiq> getMedios(int periodo)
        {
            try
            {
                List<DetLiq> lst = new List<DetLiq>();
                StringBuilder SQL = new StringBuilder();
                SQL.AppendLine("SELECT B.DESCRIPCION, CONVERT(decimal(16, 2), COUNT(*)), SUM(A.HABER), CONVERT(decimal(16, 2), 1)");
                SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                SQL.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_MEDIO_PAGO=B.ID");
                SQL.AppendLine("WHERE A.TIPO_MOVIMIENTO = 2 AND a.PERIODO = @PERIODO");
                SQL.AppendLine("GROUP BY B.DESCRIPCION");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
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
        public static List<DetLiq> getMediosPagoAnual(int anio)
        {
            try
            {
                List<DetLiq> lst = new List<DetLiq>();
                StringBuilder SQL = new StringBuilder();
                SQL.AppendLine("SELECT B.DESCRIPCION, CONVERT(decimal(16, 2), COUNT(*)), SUM(A.HABER), CONVERT(decimal(16, 2), 1)");
                SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                SQL.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_MEDIO_PAGO=B.ID");
                SQL.AppendLine("WHERE A.TIPO_MOVIMIENTO = 2 AND SUBSTRING(CONVERT(VARCHAR,a.PERIODO), 1, 4) = @PERIODO");
                SQL.AppendLine("GROUP BY B.DESCRIPCION");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", anio);
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
        public static List<DetLiq> getMediosPago(int periodo)
        {
            try
            {
                List<DetLiq> lst = new List<DetLiq>();
                StringBuilder SQL = new StringBuilder();
                SQL.AppendLine("SELECT B.DESCRIPCION, CONVERT(decimal(16, 2), COUNT(*)), SUM(A.HABER), CONVERT(decimal(16, 2), 1)");
                SQL.AppendLine("FROM CTACTE_EXPENSAS A");
                SQL.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_MEDIO_PAGO=B.ID");
                SQL.AppendLine("WHERE A.TIPO_MOVIMIENTO = 2 AND a.PERIODO = @PERIODO");
                SQL.AppendLine("GROUP BY B.DESCRIPCION");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
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
        public static List<DetLiq> getVencimientos(int anio)
        {
            try
            {
                List<DetLiq> lst = new List<DetLiq>();
                StringBuilder SQL = new StringBuilder();
                SQL.AppendLine("SELECT 'ADEUDADAS', CONVERT(decimal(16, 2), COUNT(*)), SUM(DEBE), CONVERT(decimal(16, 2), 1) FROM CTACTE_EXPENSAS A");
                SQL.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS B ON A.PERIODO = B.PERIODO ");
                SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 1 AND PAGADO = 0 AND A.PERIODO = @PERIODO");
                SQL.AppendLine("UNION");
                SQL.AppendLine("SELECT 'PRIMER VENCIMIENTO', CONVERT(decimal(16, 2), COUNT(*)), SUM(DEBE), CONVERT(decimal(16, 2), 1) FROM CTACTE_EXPENSAS A");
                SQL.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS B ON A.PERIODO = B.PERIODO AND A.VENCIMIENTO = B.VENCIMIENTO_1");
                SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 1 AND PAGADO = 1 AND A.PERIODO = @PERIODO");
                SQL.AppendLine("UNION");
                SQL.AppendLine("SELECT 'SEGUNDO VENCIMIENTO', CONVERT(decimal(16, 2), COUNT(*)), SUM(DEBE), CONVERT(decimal(16, 2), 1) FROM CTACTE_EXPENSAS A");
                SQL.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS B ON A.PERIODO = B.PERIODO AND A.VENCIMIENTO = B.VENCIMIENTO_2");
                SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 1 AND PAGADO = 1 AND A.PERIODO = @PERIODO");
                SQL.AppendLine("UNION");
                SQL.AppendLine("SELECT 'TEERCER VENCIMIENTO', CONVERT(decimal(16, 2), COUNT(*)), SUM(DEBE), CONVERT(decimal(16, 2), 1) FROM CTACTE_EXPENSAS A");
                SQL.AppendLine("INNER JOIN LIQUIDACION_EXPENSAS B ON A.PERIODO = B.PERIODO AND A.VENCIMIENTO = B.VENCIMIENTO_3");
                SQL.AppendLine("WHERE TIPO_MOVIMIENTO = 1 AND PAGADO = 1 AND A.PERIODO = @PERIODO");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
                    cmd.Parameters.AddWithValue("@PERIODO", anio);
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
    }
}
