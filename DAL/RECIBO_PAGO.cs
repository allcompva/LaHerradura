using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class RECIBO_PAGO : DALBase
    {
        public int PTO_VTA { get; set; }
        public Int64 NRO_CTE { get; set; }
        public string DETALLE { get; set; }
        public decimal MONTO { get; set; }
        public string FACTURA { get; set; }
        public int TIPO_COMPROBANTE { get; set; }
        public string TIPO_COMP { get; set; }
        public Int64 PERIODO { get; set; }
        public string PER { get; set; }
        public int ID { get; set; }
        public int NRO_CTA { get; set; }
        public string LNK { get; set; }


        public RECIBO_PAGO()
        {
            PTO_VTA = 0;
            NRO_CTE = 0;
            DETALLE = string.Empty;
            MONTO = 0;
            FACTURA = string.Empty;
            TIPO_COMP = string.Empty;
        }

        private static List<RECIBO_PAGO> mapeo(SqlDataReader dr)
        {
            List<RECIBO_PAGO> lst = new List<RECIBO_PAGO>();
            RECIBO_PAGO obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new RECIBO_PAGO();
                    if (!dr.IsDBNull(0)) { obj.PTO_VTA = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.NRO_CTE = dr.GetInt64(1); }
                    if (!dr.IsDBNull(2)) { obj.DETALLE = dr.GetString(2); }
                    if (!dr.IsDBNull(3)) { obj.MONTO = dr.GetDecimal(3); }
                    if (!dr.IsDBNull(4)) { obj.TIPO_COMPROBANTE = dr.GetInt32(4); }
                    if (!dr.IsDBNull(5)) { obj.PERIODO = dr.GetInt32(5); }
                    if (!dr.IsDBNull(6)) { obj.ID = dr.GetInt32(6); }
                    if (!dr.IsDBNull(7)) { obj.NRO_CTA = dr.GetInt32(7); }

                    obj.FACTURA = string.Format("{0}-{1}",
                        obj.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                        obj.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                    if (obj.TIPO_COMPROBANTE == 11)
                        obj.TIPO_COMP = "FACTURA";
                    if (obj.TIPO_COMPROBANTE == 13)
                    {
                        obj.TIPO_COMP = "NOTA DE CREDITO";
                        obj.MONTO = obj.MONTO - obj.MONTO - obj.MONTO;
                    }
                    obj.PER = string.Format("{0}-{1}/{2}",
                        obj.PERIODO.ToString().Substring(0, 4),
                        obj.PERIODO.ToString().Substring(4, 2),
                        obj.PERIODO.ToString().Substring(6, 2));

                    if (obj.TIPO_COMPROBANTE == 11)
                        //CAMBIO CRYSTALREPORTS
                        //                    obj.LNK =
                        //"http://200.89.178.11/Back/Reportes/Print.aspx?op=factura&nrocta=" + obj.NRO_CTA +
                        //"&periodo=" + obj.PERIODO + "&idcta=" + obj.ID;

                        obj.LNK =
    "http://200.89.178.11/Back/Reportes/Reports.aspx?&nrocta=" + 
    obj.NRO_CTA + "&periodo=" + obj.PERIODO + "&idcta=" + obj.ID;

                    if (obj.TIPO_COMPROBANTE == 13)
                    {
                        //HACER
                        obj.LNK =
    "http://200.89.178.11/Back/Reportes/Print.aspx?op=comprobante&nrocta=" + obj.NRO_CTA + "&periodo=" + obj.PERIODO +
    "&idcta=" + obj.ID + "&ptoVta=" + obj.PTO_VTA + "&nroCte=" + obj.NRO_CTE + "&tipo=13";
                    }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<RECIBO_PAGO> read(int nroComprobante)
        {
            try
            {
                List<RECIBO_PAGO> lst = new List<RECIBO_PAGO>();
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT PTO_VTA, NRO_CTE, DETALLE, MONTO, TIPO_COMPROBANTE, PERIODO, ID_CTACTE, NRO_CTA");
                sql.AppendLine("FROM FACTURAS_X_EXPENSA");
                sql.AppendLine("WHERE ID_CTACTE IN (SELECT ID FROM CTACTE_EXPENSAS");
                sql.AppendLine("WHERE NRO_RECIBO_PAGO = @NRO_RECIBO_PAGO)");
                sql.AppendLine("ORDER BY PERIODO ASC, TIPO_COMPROBANTE ASC, NRO_CTE ASC ");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", nroComprobante);
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

        public static string getFormaPago(int nroComprobante)
        {
            try
            {
                string formaPago = string.Empty;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT DISTINCT B.DESCRIPCION");
                sql.AppendLine("FROM CTACTE_EXPENSAS A");
                sql.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_MEDIO_PAGO=B.ID");
                sql.AppendLine("WHERE NRO_RECIBO_PAGO = @NRO_RECIBO_PAGO AND ID_MEDIO_PAGO IS NOT NULL");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", nroComprobante);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        if (!dr.IsDBNull(0)) { formaPago = dr.GetString(0); }
                    }
                }
                return formaPago;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
