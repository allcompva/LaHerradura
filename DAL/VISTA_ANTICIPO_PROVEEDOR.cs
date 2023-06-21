using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL
{
    public class VISTA_ANTICIPO_PROVEEDOR : DALBase
    {
        public int ID { get; set; }
        public DateTime FECHA { get; set; }
        public int NRO_RECIBO_ADELANTO { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal MONTO { get; set; }
        public string NRO_CHEQUE { get; set; }
        public string BANCO { get; set; }
        public int ID_PROVEEDOR { get; set; }

        public VISTA_ANTICIPO_PROVEEDOR()
        {
            ID = 0;
            FECHA = UTILS.getFechaActual();
            NRO_RECIBO_ADELANTO = 0;
            DESCRIPCION = string.Empty;
            MONTO = 0;
            NRO_CHEQUE = string.Empty;
            BANCO = string.Empty;
            ID_PROVEEDOR = 0;
        }

        private static List<VISTA_ANTICIPO_PROVEEDOR> mapeo(SqlDataReader dr)
        {
            List<VISTA_ANTICIPO_PROVEEDOR> lst = new List<VISTA_ANTICIPO_PROVEEDOR>();
            VISTA_ANTICIPO_PROVEEDOR obj;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    obj = new VISTA_ANTICIPO_PROVEEDOR();
                    if (!dr.IsDBNull(0)) { obj.ID = dr.GetInt32(0); }
                    if (!dr.IsDBNull(1)) { obj.FECHA = dr.GetDateTime(1); }
                    if (!dr.IsDBNull(2)) { obj.NRO_RECIBO_ADELANTO = dr.GetInt32(2); }
                    if (!dr.IsDBNull(3)) { obj.DESCRIPCION = dr.GetString(3); }
                    if (!dr.IsDBNull(4)) { obj.MONTO = dr.GetDecimal(4); }
                    if (!dr.IsDBNull(5)) { obj.NRO_CHEQUE = dr.GetString(5); }
                    if (!dr.IsDBNull(6)) { obj.BANCO = dr.GetString(6); }
                    if (!dr.IsDBNull(7)) { obj.ID_PROVEEDOR = dr.GetInt32(7); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<VISTA_ANTICIPO_PROVEEDOR> read(int idProveedor)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID, A.FECHA, A.NRO_RECIBO_ADELANTO");
                sql.AppendLine(", B.DESCRIPCION, A.MONTO");
                sql.AppendLine(", A. NRO_CHEQUE, C.DENOMINACION AS BANCO, A.ID_PROVEEDOR");
                sql.AppendLine("FROM MOV_BILLETERA_GASTOS A");
                sql.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_MEDIO_PAGO=B.ID");
                sql.AppendLine("LEFT JOIN BANCOS C ON A.ID_BANCO=C.CODIGO");
                sql.AppendLine("WHERE ID_PROVEEDOR=@ID_PROVEEDOR AND ISNULL(NRO_RECIBO_ADELANTO,0) <> 0");
                sql.AppendLine("AND ANULADO = 0 AND NOT EXISTS");
                sql.AppendLine("(SELECT *FROM MOV_BILLETERA_GASTOS WHERE ID >");
                sql.AppendLine("A.ID AND ID_PROVEEDOR=@ID_PROVEEDOR AND TIPO_MOVIMIENTO=2)");

                List<VISTA_ANTICIPO_PROVEEDOR> lst = new List<VISTA_ANTICIPO_PROVEEDOR>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
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

        public static VISTA_ANTICIPO_PROVEEDOR getByPk(
        int id)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT A.ID, A.FECHA, A.NRO_RECIBO_ADELANTO,");
                sql.AppendLine("B.DESCRIPCION, A.MONTO");
                sql.AppendLine(", A. NRO_CHEQUE, C.DENOMINACION AS BANCO, A.ID_PROVEEDOR");
                sql.AppendLine("FROM MOV_BILLETERA_GASTOS A");
                sql.AppendLine("INNER JOIN MEDIOS_PAGO B ON A.ID_MEDIO_PAGO=B.ID");
                sql.AppendLine("LEFT JOIN BANCOS C ON A.ID_BANCO=C.CODIGO");
                sql.AppendLine("WHERE A.ID=@ID");
                VISTA_ANTICIPO_PROVEEDOR obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<VISTA_ANTICIPO_PROVEEDOR> lst = mapeo(dr);
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

