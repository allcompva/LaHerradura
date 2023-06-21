using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ASIENTOS_GRILLA : DALBase
    {
        public int ID { get; set; }
        public int NRO { get; set; }
        public DateTime FECHA { get; set; }
        public string DESCRIPCION { get; set; }
        public string CUENTA { get; set; }
        public decimal DEBE { get; set; }
        public decimal HABER { get; set; }
        public string _NRO { get; set; }
        public string _FECHA { get; set; }
        public decimal TOTAL_DEBE { get; set; }
        public decimal TOTAL_HABER { get; set; }
        public int TIPO { get; set; }
        
        private static List<ASIENTOS_GRILLA> mapeo(SqlDataReader dr)
        {
            List<ASIENTOS_GRILLA> lst = new List<ASIENTOS_GRILLA>();
            ASIENTOS_GRILLA obj;
            if (dr.HasRows)
            {
                int i = 1;
                while (dr.Read())
                {
                    obj = new ASIENTOS_GRILLA();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.FECHA = dr.GetDateTime(2); }
                    if (!dr.IsDBNull(3)) { obj.DESCRIPCION = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.CUENTA = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.DEBE = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.HABER = dr.GetDecimal(6); }
                    if (!dr.IsDBNull(7)) { obj.TOTAL_DEBE = dr.GetDecimal(7); }
                    if (!dr.IsDBNull(8)) { obj.TOTAL_HABER = dr.GetDecimal(8); }
                    if (!dr.IsDBNull(9)) { obj.TIPO = dr.GetInt32(9); }

                    obj._NRO = i.ToString();
                    if (obj.DEBE == 0)
                    {
                        obj.DESCRIPCION = string.Empty;
                        obj._NRO = string.Empty;
                    }
                    else
                    {
                        obj._NRO = i.ToString();
                        i++;
                    }
                    obj._FECHA = obj.FECHA.ToShortDateString();
                    lst.Add(obj);

                }
            }
            return lst;
        }
        private static List<ASIENTOS_GRILLA> mapeo2(SqlDataReader dr)
        {
            List<ASIENTOS_GRILLA> lst = new List<ASIENTOS_GRILLA>();
            ASIENTOS_GRILLA obj;
            if (dr.HasRows)
            {
                int i = 1;
                while (dr.Read())
                {
                    obj = new ASIENTOS_GRILLA();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO = dr.GetInt32(1); }
                    if (!dr.IsDBNull(2)) { obj.FECHA = dr.GetDateTime(2); }
                    if (!dr.IsDBNull(3)) { obj.DESCRIPCION = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.CUENTA = dr.GetString(4); }
                    if (!dr.IsDBNull(5)) { obj.DEBE = dr.GetDecimal(5); }
                    if (!dr.IsDBNull(6)) { obj.HABER = dr.GetDecimal(6); }

                    obj._FECHA = obj.FECHA.ToShortDateString();
                    lst.Add(obj);

                }
            }
            return lst;
        }
        public static List<ASIENTOS_GRILLA> read(DateTime fechaInicio,
            DateTime fechaFin)
        {
            try
            {
                StringBuilder sql = new StringBuilder();

                //sql.AppendLine("SELECT DISTINCT A.ID, A.NRO, A.FECHA,");
                //sql.AppendLine("A.DESCRIPCION,");
                //sql.AppendLine("C.N5 + ' - ' + C.DESC_SUBCUENTA, B.DEBE, B.HABER,");
                //sql.AppendLine("(SELECT SUM(DEBE) FROM ASIENTOS_DETALLE D WHERE A.ID=D.ID_ASIENTO),");
                //sql.AppendLine("(SELECT SUM(HABER) FROM ASIENTOS_DETALLE D WHERE A.ID=D.ID_ASIENTO)");
                //sql.AppendLine("FROM ASIENTOS A");
                //sql.AppendLine("INNER JOIN ASIENTOS_DETALLE B ON A.ID=B.ID_ASIENTO");
                //sql.AppendLine("INNER JOIN PLAN_CUENTA C ON B.ID_CUENTA=C.ID");
                //sql.AppendLine("WHERE A.FECHA BETWEEN @FECHA_INICIO AND @FECHA_FIN");
                //sql.AppendLine("ORDER BY FECHA, A.ID, DEBE DESC");

                sql.AppendLine("SELECT A.ID_ASIENTO, C.NRO, C.FECHA,");
                sql.AppendLine("C.DESCRIPCION,");
                sql.AppendLine("CASE  WHEN A.HABER > 0 THEN");
                sql.AppendLine("'____________' + B.N5 + ' - ' + B.DESC_SUBCUENTA");
                sql.AppendLine("WHEN A.HABER = 0 THEN '' + B.N5 + ' - ' + B.DESC_SUBCUENTA");
                sql.AppendLine("END, A.DEBE, A.HABER,");
                sql.AppendLine("(SELECT SUM(DEBE) FROM ASIENTOS_DETALLE D WHERE A.ID_ASIENTO=D.ID_ASIENTO),");
                sql.AppendLine("(SELECT SUM(HABER) FROM ASIENTOS_DETALLE D WHERE A.ID_ASIENTO=D.ID_ASIENTO)");
                sql.AppendLine(", C.TIPO");
                sql.AppendLine("FROM ASIENTOS_DETALLE A");
                sql.AppendLine("INNER JOIN PLAN_CUENTA B ON A.ID_CUENTA=B.ID");
                sql.AppendLine("INNER JOIN ASIENTOS C ON A.ID_ASIENTO=C.ID");
                sql.AppendLine("WHERE c.FECHA BETWEEN @FECHA_INICIO AND @FECHA_FIN");
                sql.AppendLine("ORDER BY FECHA, A.ID_ASIENTO, A.DEBE DESC, A.HABER DESC");



                List<ASIENTOS_GRILLA> lst = new List<ASIENTOS_GRILLA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", fechaInicio);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fechaFin);
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
        public static List<ASIENTOS_GRILLA> read(string N5, DateTime desde, 
            DateTime hasta)
        {
            try
            {
                StringBuilder sql = new StringBuilder();

                sql.AppendLine("SELECT DISTINCT A.ID, A.NRO, A.FECHA,");
                sql.AppendLine("A.DESCRIPCION,");
                sql.AppendLine("C.N5 + ' - ' + C.DESC_SUBCUENTA, B.DEBE, B.HABER");
                sql.AppendLine("FROM ASIENTOS A");
                sql.AppendLine("INNER JOIN ASIENTOS_DETALLE B ON A.ID=B.ID_ASIENTO");
                sql.AppendLine("INNER JOIN PLAN_CUENTA C ON B.ID_CUENTA=C.ID");
                sql.AppendLine("WHERE C.N5 = '1.1.01.01.001' AND FECHA BETWEEN @FECHA_DESDE AND @FECHA_HASTA");
                sql.AppendLine("ORDER BY A.NRO");

                List<ASIENTOS_GRILLA> lst = new List<ASIENTOS_GRILLA>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@N5", N5);
                    cmd.Parameters.AddWithValue("@FECHA_DESDE", desde);
                    cmd.Parameters.AddWithValue("@FECHA_HASTA", hasta);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo2(dr);
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
