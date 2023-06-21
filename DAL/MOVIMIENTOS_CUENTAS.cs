using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MOVIMIENTOS_CUENTAS : DALBase
    {

        public int ID_TIPO_CUENTA { get; set; }
        public string TIPO_CUENTA { get; set; }
        public int ID_GRUPO_CUENTA { get; set; }
        public string GRUPO_CUENTA { get; set; }
        public int ID_CUENTA { get; set; }
        public string CUENTA { get; set; }
        public int ID_TIPO_MOVIMIENTO { get; set; }
        public string TIPO_MOVIMIENTO { get; set; }
        public int ID_CAJA { get; set; }
        public int NRO_COMPROBANTE { get; set; }
        public int ANIO { get; set; }
        public string CONCEPTO { get; set; }
        public bool CONCILIADO { get; set; }
        public bool PENDIENTE { get; set; }
        public bool CANCELADO { get; set; }
        public int ID_PLANILLA { get; set; }
        public DateTime FECHA_MOVIMIENTO { get; set; }
        public DateTime FECHA_ACREDITACION { get; set; }
        public decimal IMPORTE { get; set; }
        public bool INGRESO { get; set; }
        public bool BANCARIO { get; set; }
        public int ID_EMPRESA { get; set; }

        public MOVIMIENTOS_CUENTAS()
        {
            ID_TIPO_CUENTA = 0;
            TIPO_CUENTA = string.Empty;
            ID_GRUPO_CUENTA = 0;
            GRUPO_CUENTA = string.Empty;
            ID_CUENTA = 0;
            CUENTA = string.Empty;
            ID_TIPO_MOVIMIENTO = 0;
            TIPO_MOVIMIENTO = string.Empty;
            ID_CAJA = 0;
            NRO_COMPROBANTE = 0;
            ANIO = 0;
            CONCEPTO = string.Empty;
            CONCILIADO = false;
            PENDIENTE = false;
            CANCELADO = false;
            ID_PLANILLA = 0;
            FECHA_MOVIMIENTO = DateTime.Today;
            FECHA_ACREDITACION = DateTime.Today;
            IMPORTE = 0;
            INGRESO = false;
            BANCARIO = false;
            ID_EMPRESA = 0;
        }

        public static List<DAL.MOVIMIENTOS_CUENTAS> read()
        {
            try
            {
                StringBuilder strSQL = new StringBuilder();

                strSQL.AppendLine("set dateformat dmy;");
                strSQL.AppendLine("SELECT a.id_tipo_cuenta, a.id_grupo_cuenta, a.id_cuenta, a.id_tipo_movimiento, ");
                strSQL.AppendLine("b.DESCRIPCION as tipo_cuenta,");
                strSQL.AppendLine("c.DESCRIPCION as grupo_cuenta,");
                strSQL.AppendLine("d.DESCRIPCION as cuenta,");
                strSQL.AppendLine("e.des_tipo_movimiento as tipo_movimiento,");
                strSQL.AppendLine("a.fecha_movimiento, a.fecha_acreditacion,");
                strSQL.AppendLine("a.nro_comprobante,");
                strSQL.AppendLine("a.anio,");
                strSQL.AppendLine("a.importe, a.concepto,");
                strSQL.AppendLine("a.conciliado, a.id_empresa ");
                strSQL.AppendLine("FROM MOVIMIENTOS_CUENTAS a ");
                strSQL.AppendLine("join PLAN_CUENTAS d on ");
                strSQL.AppendLine("a.id_tipo_cuenta = d.ID_TIPO_CUENTA AND ");
                strSQL.AppendLine("a.id_grupo_cuenta = d.ID_GRUPO_CUENTA AND ");
                strSQL.AppendLine("a.id_cuenta = d.ID_CUENTA AND ");
                strSQL.AppendLine("a.anio = d.ANIO ");
                strSQL.AppendLine("join TIPO_CUENTA b on ");
                strSQL.AppendLine("a.id_tipo_cuenta=b.ID_TIPO_CUENTA ");
                strSQL.AppendLine("join GRUPO_CUENTAS c on ");
                strSQL.AppendLine("a.id_grupo_cuenta = c.ID_GRUPO_CUENTA ");
                strSQL.AppendLine("join TIPOS_MOVIMIENTOS_CUENTAS e on ");
                strSQL.AppendLine("a.id_tipo_movimiento=e.id_tipo_movimiento");
                //List<DAL.MOVIMIENTOS_CUENTAS> lst = new List<MOVIMIENTOS_CUENTAS>();
                strSQL.AppendLine("order by a.fecha_movimiento desc");
                using (SqlConnection cn = GetConnection())
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    return mapeo(dr);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private static List<MOVIMIENTOS_CUENTAS> mapeo(SqlDataReader dr)
        {
            List<MOVIMIENTOS_CUENTAS> lst = new List<MOVIMIENTOS_CUENTAS>();
            MOVIMIENTOS_CUENTAS obj;
            if (dr.HasRows)
            {
                int ID_TIPO_CUENTA = dr.GetOrdinal("ID_TIPO_CUENTA");
                int TIPO_CUENTA = dr.GetOrdinal("TIPO_CUENTA");
                int ID_GRUPO_CUENTA = dr.GetOrdinal("ID_GRUPO_CUENTA");
                int GRUPO_CUENTA = dr.GetOrdinal("GRUPO_CUENTA");
                int ID_CUENTA = dr.GetOrdinal("ID_CUENTA");
                int CUENTA = dr.GetOrdinal("CUENTA");
                int ID_TIPO_MOVIMIENTO = dr.GetOrdinal("ID_TIPO_MOVIMIENTO");
                int TIPO_MOVIMIENTO = dr.GetOrdinal("TIPO_MOVIMIENTO");
                int NRO_COMPROBANTE = dr.GetOrdinal("NRO_COMPROBANTE");
                int ANIO = dr.GetOrdinal("ANIO");
                int CONCEPTO = dr.GetOrdinal("CONCEPTO");
                int CONCILIADO = dr.GetOrdinal("CONCILIADO");
                int FECHA_MOVIMIENTO = dr.GetOrdinal("FECHA_MOVIMIENTO");
                int FECHA_ACREDITACION = dr.GetOrdinal("FECHA_ACREDITACION");
                int IMPORTE = dr.GetOrdinal("IMPORTE");
                //INGRESO = false;
                //BANCARIO = false;
                //ID_EMPRESA = 0;
                while (dr.Read())
                {
                    obj = new MOVIMIENTOS_CUENTAS();

                    if (!dr.IsDBNull(ID_TIPO_CUENTA)) { obj.ID_TIPO_CUENTA = dr.GetInt32(ID_TIPO_CUENTA); }
                    if (!dr.IsDBNull(TIPO_CUENTA)) { obj.TIPO_CUENTA = dr.GetString(TIPO_CUENTA); }
                    if (!dr.IsDBNull(ID_GRUPO_CUENTA)) { obj.ID_GRUPO_CUENTA = dr.GetInt32(ID_GRUPO_CUENTA); }
                    if (!dr.IsDBNull(GRUPO_CUENTA)) { obj.GRUPO_CUENTA = dr.GetString(GRUPO_CUENTA); }
                    if (!dr.IsDBNull(ID_CUENTA)) { obj.ID_CUENTA = dr.GetInt32(ID_CUENTA); }
                    if (!dr.IsDBNull(CUENTA)) { obj.CUENTA = dr.GetString(CUENTA); }
                    if (!dr.IsDBNull(ID_TIPO_MOVIMIENTO)) { obj.ID_TIPO_MOVIMIENTO = dr.GetInt32(ID_TIPO_MOVIMIENTO); }
                    if (!dr.IsDBNull(TIPO_MOVIMIENTO)) { obj.TIPO_MOVIMIENTO = dr.GetString(TIPO_MOVIMIENTO); }
                    if (!dr.IsDBNull(NRO_COMPROBANTE)) { obj.NRO_COMPROBANTE = dr.GetInt32(NRO_COMPROBANTE); }
                    if (!dr.IsDBNull(ANIO)) { obj.ANIO = dr.GetInt16(ANIO); }
                    if (!dr.IsDBNull(CONCEPTO)) { obj.CONCEPTO = dr.GetString(CONCEPTO); }
                    if (!dr.IsDBNull(CONCILIADO)) { obj.CONCILIADO = dr.GetBoolean(CONCILIADO); }
                    if (!dr.IsDBNull(FECHA_MOVIMIENTO)) { obj.FECHA_MOVIMIENTO = dr.GetDateTime(FECHA_MOVIMIENTO); }
                    if (!dr.IsDBNull(IMPORTE)) { obj.IMPORTE = dr.GetDecimal(IMPORTE); }
                    lst.Add(obj);
                }
                dr.Close();
            }
            return lst;
        }
        public static void Insert(DAL.MOVIMIENTOS_CUENTAS obj, SqlConnection cn, SqlTransaction trx, int usuario)
        {
            SqlCommand cmd;
            SqlCommand cmd1;
            StringBuilder strSQL = new StringBuilder();
            try
            {

                if (obj.NRO_COMPROBANTE == 0)
                {
                    string SQL = @"SELECT isnull(max(NRO_COMPROBANTE),0) FROM MOVIMIENTOS_CUENTAS a
                                   WHERE  a.ID_TIPO_CUENTA = @id_tipo_cuenta AND a.ID_GRUPO_CUENTA = @id_grupo_cuenta
                                   AND a.ID_CUENTA = @id_cuenta AND a.ID_TIPO_MOVIMIENTO = @id_tipo_movimiento
                                   AND a.id_empresa=@id_empresa";
                    //SQL.AppendLine("AND nro_liquidacion=@nro_liquidacion");
                    cmd1 = new SqlCommand();
                    cmd1.Parameters.AddWithValue("@id_tipo_cuenta", obj.ID_TIPO_CUENTA);
                    cmd1.Parameters.AddWithValue("@id_grupo_cuenta", obj.ID_GRUPO_CUENTA);
                    cmd1.Parameters.AddWithValue("@id_cuenta", obj.ID_CUENTA);
                    cmd1.Parameters.AddWithValue("@id_tipo_movimiento", obj.ID_TIPO_MOVIMIENTO);
                    cmd1.Parameters.AddWithValue("@id_empresa", obj.ID_EMPRESA);
                    cmd1.Connection = cn;
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Transaction = trx;
                    cmd1.CommandText = SQL.ToString();
                    obj.NRO_COMPROBANTE = Convert.ToInt32(cmd1.ExecuteScalar()) + 1;
                }

                strSQL.AppendLine("insert into MOVIMIENTOS_CUENTAS");
                strSQL.AppendLine("(id_tipo_cuenta, id_grupo_cuenta, id_cuenta, id_tipo_movimiento, id_caja, nro_comprobante, anio,fecha_movimiento, concepto,");
                strSQL.AppendLine("importe, conciliado, pendiente, cancelado, id_planilla, usuario_alta, interno, id_empresa)");
                strSQL.AppendLine("VALUES");
                strSQL.AppendLine("(@id_tipo_cuenta, @id_grupo_cuenta, @id_cuenta, @id_tipo_movimiento, @id_caja, @nro_comprobante,  @anio, @fecha_movimiento, @concepto,");
                strSQL.AppendLine("@importe, @conciliado, @pendiente, @cancelado, @id_planilla, @usuario_alta, @interno, @id_empresa)");

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Parameters.AddWithValue("@id_tipo_cuenta", obj.ID_TIPO_CUENTA);
                cmd.Parameters.AddWithValue("@id_grupo_cuenta", obj.ID_GRUPO_CUENTA);
                cmd.Parameters.AddWithValue("@id_cuenta", obj.ID_CUENTA);
                cmd.Parameters.AddWithValue("@id_tipo_movimiento", obj.ID_TIPO_MOVIMIENTO);
                cmd.Parameters.AddWithValue("@id_caja", obj.ID_CAJA);
                cmd.Parameters.AddWithValue("@nro_comprobante", obj.NRO_COMPROBANTE);
                cmd.Parameters.AddWithValue("@anio", obj.ANIO);
                cmd.Parameters.AddWithValue("@fecha_movimiento", obj.FECHA_MOVIMIENTO);
                cmd.Parameters.AddWithValue("@concepto", obj.CONCEPTO);
                cmd.Parameters.AddWithValue("@importe", obj.IMPORTE);
                cmd.Parameters.AddWithValue("@conciliado", obj.CONCILIADO);
                cmd.Parameters.AddWithValue("@pendiente", obj.PENDIENTE);
                cmd.Parameters.AddWithValue("@cancelado", obj.CANCELADO);
                cmd.Parameters.AddWithValue("@id_planilla", 0);
                cmd.Parameters.AddWithValue("@usuario_alta", usuario);
                cmd.Parameters.AddWithValue("@interno", 0);
                cmd.Parameters.AddWithValue("@id_empresa",0);

                cmd.Connection = cn;
                cmd.Transaction = trx;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                cmd = null;
                cmd1 = null;
                strSQL = null;
            }

        }

        //private static List<PAGOS_X_FACTURA> GetPagos_x_Factura(DateTime fecha_desde, DateTime fecha_hasta, SqlConnection cn, SqlTransaction trx)
        //{
        //    StringBuilder strSQL = new StringBuilder();
        //    List<PAGOS_X_FACTURA> lst = new List<PAGOS_X_FACTURA>();
        //    PAGOS_X_FACTURA obj = new PAGOS_X_FACTURA();
        //    try
        //    {
        //        //
        //        //strSQL.AppendLine("a.ID_PLAN_PAGO, c.id_tipo_pago, sum(a.MONTO) as monto ");
        //        strSQL.AppendLine("set dateformat dmy;");
        //        strSQL.AppendLine("SELECT ");
        //        strSQL.AppendLine("c.id_tipo_pago, sum(a.MONTO) as monto, count(*) cantidad ");
        //        strSQL.AppendLine("FROM PAGOS_X_FACTURA a ");
        //        strSQL.AppendLine("join TB_PLANES_PAGO b on ");
        //        strSQL.AppendLine("a.ID_PLAN_PAGO = b.ID ");
        //        strSQL.AppendLine("join TB_MEDIOS_PAGO c on ");
        //        strSQL.AppendLine("a.ID_PLAN_PAGO = c.ID ");
        //        strSQL.AppendLine("WHERE ");
        //        strSQL.AppendLine("(a.id_planilla is null or a.id_planilla = 0) ");
        //        strSQL.AppendLine("AND (a.FECHA between dateadd(Mi, -2, @desde) AND dateadd(Mi, 2, @hasta))");
        //        //strSQL.AppendLine("GROUP BY a.ID_PLAN_PAGO, c.id_tipo_pago ");
        //        strSQL.AppendLine("GROUP BY c.id_tipo_pago ");
        //        //
        //        //using (SqlConnection con = GetConnection())
        //        //{
        //        SqlCommand cmd = cn.CreateCommand();
        //        cmd.Transaction = trx;
        //        cmd.Parameters.AddWithValue("@desde", fecha_desde);
        //        cmd.Parameters.AddWithValue("@hasta", fecha_hasta);
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = strSQL.ToString();
        //        //cmd.Connection.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            int monto = dr.GetOrdinal("monto");
        //            //Uso este campo para determinar el tipo de pago
        //            int id_tipo_pago = dr.GetOrdinal("id_tipo_pago");
        //            //int id_tarjeta = dr.GetOrdinal("id_tarjeta");
        //            //int id_planilla = dr.GetOrdinal("id_planilla");

        //            while (dr.Read())
        //            {
        //                obj = new PAGOS_X_FACTURA();
        //                //if (!dr.IsDBNull(id_plan_pago)) { obj.ID_PLAN_PAGO = dr.GetInt32(id_plan_pago); }
        //                if (!dr.IsDBNull(id_tipo_pago)) { obj.ID_TIPO_PAGO = dr.GetInt32(id_tipo_pago); }
        //                if (!dr.IsDBNull(monto)) { obj.MONTO = dr.GetDecimal(monto); }
        //                lst.Add(obj);
        //                //obj = new PAGOS_X_FACTURA();
        //            }
        //        }
        //        dr.Close();
        //        return lst;
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("GetPagos_x_Factura", ex);
        //    }
        //}


        //Solo trae los movimientos que no tengan id de caja)
        //Queda claro que la caja debe estar cerrada antes
        //para continuar generando comandas.
        //private static List<PAGOS_X_FACTURA> GetPagos_x_FacturaSinFechas(DateTime fecha_desde, DateTime fecha_hasta, SqlConnection cn, SqlTransaction trx)
        //{
        //    StringBuilder strSQL = new StringBuilder();
        //    List<PAGOS_X_FACTURA> lst = new List<PAGOS_X_FACTURA>();
        //    PAGOS_X_FACTURA obj = new PAGOS_X_FACTURA();
        //    try
        //    {
        //        //
        //        //strSQL.AppendLine("a.ID_PLAN_PAGO, c.id_tipo_pago, sum(a.MONTO) as monto ");
        //        strSQL.AppendLine("SELECT ");
        //        strSQL.AppendLine("c.id_tipo_pago, sum(a.MONTO) as monto, count(*) cantidad ");
        //        strSQL.AppendLine("FROM PAGOS_X_FACTURA a ");
        //        strSQL.AppendLine("join TB_PLANES_PAGO b on ");
        //        strSQL.AppendLine("a.ID_PLAN_PAGO = b.ID ");
        //        strSQL.AppendLine("join TB_MEDIOS_PAGO c on ");
        //        strSQL.AppendLine("a.ID_PLAN_PAGO = c.ID ");
        //        strSQL.AppendLine("WHERE ");
        //        strSQL.AppendLine("(a.id_planilla is null or a.id_planilla = 0) ");
        //        //strSQL.AppendLine("AND (a.FECHA between @desde AND @hasta)");
        //        //strSQL.AppendLine("GROUP BY a.ID_PLAN_PAGO, c.id_tipo_pago ");
        //        strSQL.AppendLine("GROUP BY c.id_tipo_pago ");
        //        //
        //        //using (SqlConnection con = GetConnection())
        //        //{
        //        SqlCommand cmd = cn.CreateCommand();
        //        cmd.Transaction = trx;
        //        cmd.Parameters.AddWithValue("@desde", fecha_desde);
        //        cmd.Parameters.AddWithValue("@hasta", fecha_hasta);
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = strSQL.ToString();
        //        //cmd.Connection.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.HasRows)
        //        {
        //            //int id = dr.GetOrdinal("id");
        //            //int fecha = dr.GetOrdinal("fecha");
        //            //int usuario = dr.GetOrdinal("usuario");
        //            //int id_factura = dr.GetOrdinal("id_factura");
        //            //int id_plan_pago = dr.GetOrdinal("id_plan_pago");
        //            //int descripcion = dr.GetOrdinal("descripcion");
        //            int monto = dr.GetOrdinal("monto");
        //            //Uso este campo para determinar el tipo de pago
        //            int id_tipo_pago = dr.GetOrdinal("id_tipo_pago");
        //            //int id_tarjeta = dr.GetOrdinal("id_tarjeta");
        //            //int id_planilla = dr.GetOrdinal("id_planilla");

        //            while (dr.Read())
        //            {
        //                obj = new PAGOS_X_FACTURA();
        //                //if (!dr.IsDBNull(id_plan_pago)) { obj.ID_PLAN_PAGO = dr.GetInt32(id_plan_pago); }
        //                if (!dr.IsDBNull(id_tipo_pago)) { obj.ID_TIPO_PAGO = dr.GetInt32(id_tipo_pago); }
        //                if (!dr.IsDBNull(monto)) { obj.MONTO = dr.GetDecimal(monto); }
        //                lst.Add(obj);
        //                //obj = new PAGOS_X_FACTURA();
        //            }
        //        }
        //        dr.Close();
        //        return lst;
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("GetPagos_x_FacturaSinFechas", ex);
        //    }
        //}
        //private static List<PAGOS_X_FACTURA> GetPagos_x_FacturaScope(DateTime fecha_desde, DateTime fecha_hasta)
        //{
        //    StringBuilder strSQL = new StringBuilder();
        //    List<PAGOS_X_FACTURA> lst = new List<PAGOS_X_FACTURA>();
        //    PAGOS_X_FACTURA obj = new PAGOS_X_FACTURA();
        //    try
        //    {
        //        //
        //        strSQL.AppendLine("set dateformat dmy;");
        //        strSQL.AppendLine("SELECT ");
        //        //strSQL.AppendLine("a.ID_PLAN_PAGO, c.id_tipo_pago, sum(a.MONTO) as monto ");
        //        strSQL.AppendLine("c.id_tipo_pago, sum(a.MONTO) as monto ");
        //        strSQL.AppendLine("FROM PAGOS_X_FACTURA a ");
        //        strSQL.AppendLine("join TB_PLANES_PAGO b on ");
        //        strSQL.AppendLine("a.ID_PLAN_PAGO = b.ID ");
        //        strSQL.AppendLine("join TB_MEDIOS_PAGO c on ");
        //        strSQL.AppendLine("a.ID_PLAN_PAGO = c.ID ");
        //        strSQL.AppendLine("WHERE ");
        //        strSQL.AppendLine("(a.id_planilla is null or a.id_planilla = 0) ");
        //        strSQL.AppendLine("AND (a.FECHA between dateadd(Mi, -2, @desde) AND dateadd(Mi, 2, @hasta))");
        //        //strSQL.AppendLine("GROUP BY a.ID_PLAN_PAGO, c.id_tipo_pago ");
        //        strSQL.AppendLine("GROUP BY c.id_tipo_pago ");
        //        //
        //        using (SqlConnection con = GetConnection())
        //        {
        //            SqlCommand cmd = con.CreateCommand();
        //            cmd.Parameters.AddWithValue("@desde", fecha_desde);
        //            cmd.Parameters.AddWithValue("@hasta", fecha_hasta);
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = strSQL.ToString();
        //            cmd.Connection.Open();
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            if (dr.HasRows)
        //            {
        //                //int id = dr.GetOrdinal("id");
        //                //int fecha = dr.GetOrdinal("fecha");
        //                //int usuario = dr.GetOrdinal("usuario");
        //                //int id_factura = dr.GetOrdinal("id_factura");
        //                //int id_plan_pago = dr.GetOrdinal("id_plan_pago");
        //                //int descripcion = dr.GetOrdinal("descripcion");
        //                int monto = dr.GetOrdinal("monto");
        //                //Uso este campo para determinar el tipo de pago
        //                int id_tipo_pago = dr.GetOrdinal("id_tipo_pago");
        //                //int id_tarjeta = dr.GetOrdinal("id_tarjeta");
        //                //int id_planilla = dr.GetOrdinal("id_planilla");

        //                while (dr.Read())
        //                {
        //                    obj = new PAGOS_X_FACTURA();
        //                    //if (!dr.IsDBNull(id_plan_pago)) { obj.ID_PLAN_PAGO = dr.GetInt32(id_plan_pago); }
        //                    if (!dr.IsDBNull(id_tipo_pago)) { obj.ID_TIPO_PAGO = dr.GetInt32(id_tipo_pago); }
        //                    if (!dr.IsDBNull(monto)) { obj.MONTO = dr.GetDecimal(monto); }
        //                    lst.Add(obj);
        //                    //obj = new PAGOS_X_FACTURA();
        //                }
        //            }
        //            dr.Close();
        //            return lst;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //Solo trae los movimientos que no tengan id de caja)
        //Queda claro que la caja debe estar cerrada antes
        //para continuar generando comandas.

        //private static List<PAGOS_X_FACTURA> GetPagos_x_FacturaSinFechasScope(DateTime fecha_desde, DateTime fecha_hasta)
        //{
        //    StringBuilder strSQL = new StringBuilder();
        //    List<PAGOS_X_FACTURA> lst = new List<PAGOS_X_FACTURA>();
        //    PAGOS_X_FACTURA obj = new PAGOS_X_FACTURA();
        //    try
        //    {
        //        //
        //        strSQL.AppendLine("SELECT ");
        //        //strSQL.AppendLine("a.ID_PLAN_PAGO, c.id_tipo_pago, sum(a.MONTO) as monto ");
        //        strSQL.AppendLine("c.id_tipo_pago, sum(a.MONTO) as monto ");
        //        strSQL.AppendLine("FROM PAGOS_X_FACTURA a ");
        //        strSQL.AppendLine("join TB_PLANES_PAGO b on ");
        //        strSQL.AppendLine("a.ID_PLAN_PAGO = b.ID ");
        //        strSQL.AppendLine("join TB_MEDIOS_PAGO c on ");
        //        strSQL.AppendLine("a.ID_PLAN_PAGO = c.ID ");
        //        strSQL.AppendLine("WHERE ");
        //        strSQL.AppendLine("(a.id_planilla is null or a.id_planilla = 0) ");
        //        //strSQL.AppendLine("AND (a.FECHA between @desde AND @hasta)");
        //        //strSQL.AppendLine("GROUP BY a.ID_PLAN_PAGO, c.id_tipo_pago ");
        //        strSQL.AppendLine("GROUP BY c.id_tipo_pago ");
        //        //
        //        using (SqlConnection con = GetConnection())
        //        {
        //            SqlCommand cmd = con.CreateCommand();
        //            cmd.Parameters.AddWithValue("@desde", fecha_desde);
        //            cmd.Parameters.AddWithValue("@hasta", fecha_hasta);
        //            cmd.CommandType = CommandType.Text;
        //            cmd.CommandText = strSQL.ToString();
        //            cmd.Connection.Open();
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            if (dr.HasRows)
        //            {
        //                //int id = dr.GetOrdinal("id");
        //                //int fecha = dr.GetOrdinal("fecha");
        //                //int usuario = dr.GetOrdinal("usuario");
        //                //int id_factura = dr.GetOrdinal("id_factura");
        //                //int id_plan_pago = dr.GetOrdinal("id_plan_pago");
        //                //int descripcion = dr.GetOrdinal("descripcion");
        //                int monto = dr.GetOrdinal("monto");
        //                //Uso este campo para determinar el tipo de pago
        //                int id_tipo_pago = dr.GetOrdinal("id_tipo_pago");
        //                //int id_tarjeta = dr.GetOrdinal("id_tarjeta");
        //                //int id_planilla = dr.GetOrdinal("id_planilla");

        //                while (dr.Read())
        //                {
        //                    obj = new PAGOS_X_FACTURA();
        //                    //if (!dr.IsDBNull(id_plan_pago)) { obj.ID_PLAN_PAGO = dr.GetInt32(id_plan_pago); }
        //                    if (!dr.IsDBNull(id_tipo_pago)) { obj.ID_TIPO_PAGO = dr.GetInt32(id_tipo_pago); }
        //                    if (!dr.IsDBNull(monto)) { obj.MONTO = dr.GetDecimal(monto); }
        //                    lst.Add(obj);
        //                    obj = new PAGOS_X_FACTURA();
        //                }
        //            }
        //            dr.Close();
        //            return lst;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("GetPagos_x_FacturaSinFechasScope", ex);
        //    }
        //}

        public static void InsertPagosToMovCta(DateTime fecha_desde, DateTime fecha_hasta, ref DAL.PLANILLA_CAJA_GRAL oPC,
            SqlConnection cn, SqlTransaction trx)
        {
            try
            {
                int id_tipo_cuenta_caja = int.Parse(ConfigurationManager.AppSettings["id_tipo_cuenta_caja"]);
                int id_grupo_cuenta_caja = int.Parse(ConfigurationManager.AppSettings["id_grupo_cuenta_caja"]);
                int id_cuenta_caja = int.Parse(ConfigurationManager.AppSettings["id_cuenta_caja"]);
                int id_tipo_mov_caja = int.Parse(ConfigurationManager.AppSettings["id_tipo_mov_caja"]);
                //
                int id_tipo_cuenta_bco = int.Parse(ConfigurationManager.AppSettings["id_tipo_cuenta_bco"]);
                int id_grupo_cuenta_bco = int.Parse(ConfigurationManager.AppSettings["id_grupo_cuenta_bco"]);
                int id_cuenta_bco = int.Parse(ConfigurationManager.AppSettings["id_cuenta_bco"]);
                int id_tipo_mov_bco = int.Parse(ConfigurationManager.AppSettings["id_tipo_mov_bco"]);
                //
                List<PAGOS_X_FACTURA> lstPagos;
                //
                int nro_comprobante = 0;
                int id_planilla = oPC.ID;
                int id_empresa = oPC.ID_EMPRESA;
                int id_caja = oPC.ID_CAJA;
                //
                decimal total_efectivo = 0;
                decimal total_debito = 0;
                decimal total_credito = 0;


                lstPagos = new List<PAGOS_X_FACTURA>();
                //lstPagos = GetPagos_x_Factura(fecha_desde, fecha_hasta, cn, trx);
                //
                foreach (var item in lstPagos)
                {
                    //****MUY IMPORTANTE****************************************************
                    //ID_TIPO_PAGO el valor de este campo
                    //me dice si es:
                    // si es = 1 Efectivo
                    // si es = 2 T.Debito
                    // si es = 3 T.Credito
                    //**********************************************************************
                    //switch (item.ID_TIPO_PAGO)
                    //{
                    //    case 1:
                    //        nro_comprobante = Calculo_Nro_comprobante(id_tipo_cuenta_caja, id_grupo_cuenta_caja, id_cuenta_caja, id_tipo_mov_caja, cn, trx);
                    //        InsertMovimiento_Cuenta(item, id_caja, id_tipo_cuenta_caja, id_grupo_cuenta_caja, id_cuenta_caja, id_tipo_mov_caja,
                    //            nro_comprobante, oPC.ID_PLANILLA, "CIERRE Caja en EFECTIVO ", cn, trx);
                    //        total_efectivo = total_efectivo + item.MONTO;
                    //        break;
                    //    case 2:
                    //        nro_comprobante = Calculo_Nro_comprobante(id_tipo_cuenta_bco, id_grupo_cuenta_bco, id_cuenta_bco, id_tipo_mov_bco, cn, trx);
                    //        InsertMovimiento_Cuenta(item, id_caja, id_tipo_cuenta_bco, id_grupo_cuenta_bco, id_cuenta_bco, id_tipo_mov_bco,
                    //            nro_comprobante, oPC.ID_PLANILLA, "CIERRE Caja DEBITOS ", cn, trx);
                    //        total_debito = total_debito + item.MONTO;
                    //        break;
                    //    case 3:
                    //        nro_comprobante = Calculo_Nro_comprobante(id_tipo_cuenta_bco, id_grupo_cuenta_bco, id_cuenta_bco, id_tipo_mov_bco, cn, trx);
                    //        InsertMovimiento_Cuenta(item, id_caja, id_tipo_cuenta_bco, id_grupo_cuenta_bco, id_cuenta_bco, id_tipo_mov_bco,
                    //            nro_comprobante, oPC.ID_PLANILLA, "CIERRE Caja CREDITO ", cn, trx);
                    //        total_credito = total_credito + item.MONTO;
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
                oPC.INGRESOS_EFVO = total_efectivo;
                oPC.INGRESOS_BANCO = total_debito + total_credito;
                oPC.INGRESOS_CHEQUES = total_debito;
                oPC.MONTO_FIJO = total_credito;
                //oPC.INGRESOS = oPC.INGRESOS + total_efectivo + oPC.BANCO;
                Actualizar_Pagos_x_Factura(lstPagos, oPC.ID, oPC.ID_EMPRESA, fecha_desde, fecha_hasta, cn, trx);
            }
            catch (SqlException e)
            {
                throw new ApplicationException("InsertPagosToMovCta", e);
            }
        }

        //public static void InsertPagosToMovCtaScope(DateTime fecha_desde, DateTime fecha_hasta, ref DAL.PLANILLA_CAJA oPC)
        //{
        //    try
        //    {
        //        int id_tipo_cuenta_caja = int.Parse(ConfigurationManager.AppSettings["id_tipo_cuenta_caja"]);
        //        int id_grupo_cuenta_caja = int.Parse(ConfigurationManager.AppSettings["id_grupo_cuenta_caja"]);
        //        int id_cuenta_caja = int.Parse(ConfigurationManager.AppSettings["id_cuenta_caja"]);
        //        int id_tipo_mov_caja = int.Parse(ConfigurationManager.AppSettings["id_tipo_mov_caja"]);
        //        //
        //        int id_tipo_cuenta_bco = int.Parse(ConfigurationManager.AppSettings["id_tipo_cuenta_bco"]);
        //        int id_grupo_cuenta_bco = int.Parse(ConfigurationManager.AppSettings["id_grupo_cuenta_bco"]);
        //        int id_cuenta_bco = int.Parse(ConfigurationManager.AppSettings["id_cuenta_bco"]);
        //        int id_tipo_mov_bco = int.Parse(ConfigurationManager.AppSettings["id_tipo_mov_bco"]);
        //        //
        //        List<PAGOS_X_FACTURA> lstPagos;
        //        //
        //        int nro_comprobante = 0;
        //        int id_planilla = oPC.ID_PLANILLA;
        //        int id_caja = oPC.ID_CAJA;
        //        //
        //        decimal total_efectivo = 0;
        //        decimal total_debito = 0;
        //        decimal total_credito = 0;


        //        lstPagos = new List<PAGOS_X_FACTURA>();
        //        lstPagos = GetPagos_x_FacturaScope(fecha_desde, fecha_hasta);
        //        //
        //        foreach (var item in lstPagos)
        //        {
        //            //****MUY IMPORTANTE****************************************************
        //            //ID_TIPO_PAGO el valor de este campo
        //            //me dice si es:
        //            // si es = 1 Efectivo
        //            // si es = 2 T.Debito
        //            // si es = 3 T.Credito
        //            //**********************************************************************
        //            switch (item.ID_TIPO_PAGO)
        //            {
        //                case 1:
        //                    nro_comprobante = Calculo_Nro_comprobanteScope(id_tipo_cuenta_caja, id_grupo_cuenta_caja, id_cuenta_caja, id_tipo_mov_caja);
        //                    InsertMovimiento_CuentaScope(item, id_caja, id_tipo_cuenta_caja, id_grupo_cuenta_caja, id_cuenta_caja, id_tipo_mov_caja,
        //                        nro_comprobante, oPC.ID_PLANILLA, "CIERRE Caja en EFECTIVO ");
        //                    total_efectivo = total_efectivo + item.MONTO;
        //                    break;
        //                case 2:
        //                    nro_comprobante = Calculo_Nro_comprobanteScope(id_tipo_cuenta_bco, id_grupo_cuenta_bco, id_cuenta_bco, id_tipo_mov_bco);
        //                    InsertMovimiento_CuentaScope(item, id_caja, id_tipo_cuenta_bco, id_grupo_cuenta_bco, id_cuenta_bco, id_tipo_mov_bco,
        //                        nro_comprobante, oPC.ID_PLANILLA, "CIERRE Caja DEBITOS ");
        //                    total_debito = total_debito + item.MONTO;
        //                    break;
        //                case 3:
        //                    nro_comprobante = Calculo_Nro_comprobanteScope(id_tipo_cuenta_bco, id_grupo_cuenta_bco, id_cuenta_bco, id_tipo_mov_bco);
        //                    InsertMovimiento_CuentaScope(item, id_caja, id_tipo_cuenta_bco, id_grupo_cuenta_bco, id_cuenta_bco, id_tipo_mov_bco,
        //                        nro_comprobante, oPC.ID_PLANILLA, "CIERRE Caja CREDITO ");
        //                    total_credito = total_credito + item.MONTO;
        //                    break;
        //                default:
        //                    break;
        //            }
        //        }
        //        oPC.EFECTIVO = total_efectivo;
        //        oPC.BANCO = total_debito + total_credito;
        //        oPC.DEBITOS = total_debito;
        //        oPC.CREDITOS = total_credito;
        //        oPC.INGRESOS = oPC.INGRESOS + total_efectivo + oPC.BANCO;
        //        Actualizar_Pagos_x_FacturaScope(lstPagos, oPC.ID_PLANILLA, fecha_desde, fecha_hasta);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new ApplicationException("InsertPagosToMovCtaScope", e);
        //    }
        //}
        private static void Actualizar_Pagos_x_Factura(List<PAGOS_X_FACTURA> lst, int id_planilla, int id_empresa, DateTime fecha_desde, DateTime fecha_hasta,
            SqlConnection cn, SqlTransaction trx)
        {
            try
            {
                string strSQL = @"UPDATE Pagos_x_Factura
                                  SETt id_planilla=@id_planilla 
                                  WHERE (id_planilla is null or id_planilla=0) 
                                  AND id_empresa=@id_empresa
                                  AND (FECHA between dateadd(Mi, -2, @desde) AND dateadd(Mi, 2, @hasta))";
                SqlCommand cmd;
                cmd = cn.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Parameters.AddWithValue("@id", id_planilla);
                cmd.Parameters.AddWithValue("@id_empresa", id_empresa);
                cmd.Parameters.AddWithValue("@desde", fecha_desde);
                cmd.Parameters.AddWithValue("@hasta", fecha_hasta);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private static void Actualizar_Pagos_x_FacturaScope(List<PAGOS_X_FACTURA> lst, int id_planilla, int id_empresa, DateTime fecha_desde, DateTime fecha_hasta)
        {
            try
            {
                string strSQL = @"UPDATE Pagos_x_Factura
                                  SETt id_planilla=@id_planilla 
                                  WHERE (id_planilla is null or id_planilla=0) 
                                  AND id_empresa=@id_empresa
                                  AND (FECHA between dateadd(Mi, -2, @desde) AND dateadd(Mi, 2, @hasta))";
                SqlCommand cmd;
                using (SqlConnection con = GetConnection())
                {
                    cmd = con.CreateCommand();
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@id", id_planilla);
                    cmd.Parameters.AddWithValue("@id_empresa", id_empresa);
                    cmd.Parameters.AddWithValue("@desde", fecha_desde);
                    cmd.Parameters.AddWithValue("@hasta", fecha_hasta);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void Update_Movimiento_Cuentas(DateTime desde, DateTime hasta, PLANILLA_CAJA_GRAL oPC, SqlConnection cn, SqlTransaction trx)
        {
            string strSQL = @"UPDATE MOVIMIENTOS_CUENTAS
                              SET conciliado=0, pendiente=1, id_planilla=null
                              WHERE id_planilla = @id_planilla
                              and id_empresa=@id_empresa
                              and id_caja=@id_caja
                              and cancelado=0 and interno = 0";
            try
            {
                //using (SqlConnection con = GetConnection())
                //{
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", oPC.ID);
                cmd.Parameters.AddWithValue("@id_caja", oPC.ID_CAJA);
                cmd.Parameters.AddWithValue("@id_empresa", oPC.ID_EMPRESA);
                cmd.CommandText = strSQL.ToString();
                //cmd.Connection.Open();
                cmd.Transaction = trx;
                cmd.ExecuteNonQuery();
                //}

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void Update_Movimiento_CuentasScope(DateTime desde, DateTime hasta, PLANILLA_CAJA_GRAL oPC)
        {
            string strSQL = @"UPDATE MOVIMIENTOS_CUENTAS
                              SET conciliado=0, pendiente=1, id_planilla=null
                              WHERE id_planilla = @id_planilla
                              and id_empresa=@id_empresa
                              and id_caja=@id_caja
                              and cancelado=0 and interno = 0";
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", oPC.ID);
                    cmd.Parameters.AddWithValue("@id_caja", oPC.ID_CAJA);
                    cmd.Parameters.AddWithValue("@id_empresa", oPC.ID_EMPRESA);
                    cmd.CommandText = strSQL.ToString();
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private static void InsertMovimiento_Cuenta(PAGOS_X_FACTURA item, int id_caja, int id_tipo_cuenta, int id_grupo_cuenta, int id_cuenta, int id_tipo_mov,
          int nro_comprobante, int id_planilla, int id_empresa, string concepto, SqlConnection cn, SqlTransaction trx)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.AppendLine("set dateformat dmy;");
                strSQL.AppendLine("insert into MOVIMIENTOS_CUENTAS");
                strSQL.AppendLine("(id_tipo_cuenta, id_grupo_cuenta, id_cuenta, id_tipo_movimiento, id_caja, nro_comprobante, anio,fecha_movimiento, concepto,");
                strSQL.AppendLine("importe, conciliado, pendiente, cancelado, id_planilla, usuario_alta, interno, id_empresa)");
                strSQL.AppendLine("VALUES");
                strSQL.AppendLine("(@id_tipo_cuenta, @id_grupo_cuenta, @id_cuenta, @id_tipo_movimiento, @id_caja, @nro_comprobante, @anio, @fecha_movimiento, @concepto,");
                strSQL.AppendLine("@importe, @conciliado, @pendiente, @cancelado, @id_planilla, @usuario_alta, @interno, @id_empresa)");
                SqlCommand cmd;
                //using (SqlConnection con = GetConnection())
                //{
                cmd = cn.CreateCommand();
                //cmd.Connection.Open();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                cmd.Parameters.AddWithValue("@id_tipo_cuenta", id_tipo_cuenta);
                cmd.Parameters.AddWithValue("@id_grupo_cuenta", id_grupo_cuenta);
                cmd.Parameters.AddWithValue("@id_cuenta", id_cuenta);
                cmd.Parameters.AddWithValue("@id_tipo_movimiento", id_tipo_mov);
                cmd.Parameters.AddWithValue("@id_caja", id_caja);
                cmd.Parameters.AddWithValue("@nro_comprobante", nro_comprobante);
                cmd.Parameters.AddWithValue("@anio", DateTime.Today.Year);
                cmd.Parameters.AddWithValue("@fecha_movimiento", DateTime.Now);
                cmd.Parameters.AddWithValue("@concepto", concepto + item.MONTO.ToString());
                cmd.Parameters.AddWithValue("@importe", item.MONTO);
                cmd.Parameters.AddWithValue("@conciliado", true);
                cmd.Parameters.AddWithValue("@pendiente", false);
                cmd.Parameters.AddWithValue("@cancelado", false);
                cmd.Parameters.AddWithValue("@id_planilla", id_planilla);
                cmd.Parameters.AddWithValue("@usuario_alta", item.USUARIO);
                cmd.Parameters.AddWithValue("@interno", 1);
                cmd.Parameters.AddWithValue("@id_empresa", id_empresa);
                cmd.ExecuteNonQuery();
                //}
            }
            catch (Exception ex)
            {
                throw new ApplicationException("InsertMovimiento_Cuenta", ex);
            }
        }
        private static void InsertMovimiento_CuentaScope(PAGOS_X_FACTURA item, int id_caja, int id_tipo_cuenta, int id_grupo_cuenta, int id_cuenta, int id_tipo_mov,
          int nro_comprobante, int id_planilla, int id_empresa, string concepto)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder();
                strSQL.AppendLine("set dateformat dmy;");
                strSQL.AppendLine("insert into MOVIMIENTOS_CUENTAS");
                strSQL.AppendLine("(id_tipo_cuenta, id_grupo_cuenta, id_cuenta, id_tipo_movimiento, id_caja, nro_comprobante, anio,fecha_movimiento, concepto,");
                strSQL.AppendLine("importe, conciliado, pendiente, cancelado, id_planilla, usuario_alta, interno, id_empresa)");
                strSQL.AppendLine("VALUES");
                strSQL.AppendLine("(@id_tipo_cuenta, @id_grupo_cuenta, @id_cuenta, @id_tipo_movimiento, @id_caja, @nro_comprobante,  @anio, @fecha_movimiento, @concepto,");
                strSQL.AppendLine("@importe, @conciliado, @pendiente, @cancelado, @id_planilla, @usuario_alta, @interno, @id_empresa)");
                SqlCommand cmd;
                using (SqlConnection con = GetConnection())
                {
                    cmd = con.CreateCommand();
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Parameters.AddWithValue("@id_tipo_cuenta", id_tipo_cuenta);
                    cmd.Parameters.AddWithValue("@id_grupo_cuenta", id_grupo_cuenta);
                    cmd.Parameters.AddWithValue("@id_cuenta", id_cuenta);
                    cmd.Parameters.AddWithValue("@id_tipo_movimiento", id_tipo_mov);
                    cmd.Parameters.AddWithValue("@id_caja", id_caja);
                    cmd.Parameters.AddWithValue("@nro_comprobante", nro_comprobante);
                    cmd.Parameters.AddWithValue("@anio", DateTime.Today.Year);
                    cmd.Parameters.AddWithValue("@fecha_movimiento", DateTime.Now);
                    cmd.Parameters.AddWithValue("@concepto", concepto + item.MONTO.ToString());
                    cmd.Parameters.AddWithValue("@importe", item.MONTO);
                    cmd.Parameters.AddWithValue("@conciliado", true);
                    cmd.Parameters.AddWithValue("@pendiente", false);
                    cmd.Parameters.AddWithValue("@cancelado", false);
                    cmd.Parameters.AddWithValue("@id_planilla", id_planilla);
                    cmd.Parameters.AddWithValue("@usuario_alta", item.USUARIO);
                    cmd.Parameters.AddWithValue("@interno", 1);
                    cmd.Parameters.AddWithValue("@id_empresa", id_empresa);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static int Calculo_Nro_comprobante(int id_tipo_cuenta, int id_grupo_cuenta, int id_cuenta, int id_tipo_mov, int id_empresa,
          SqlConnection cn, SqlTransaction trx)
        {
            int nro_comprobante = 0;
            string SQL = @"SELECT isnull(max(NRO_COMPROBANTE),0) FROM MOVIMIENTOS_CUENTAS a
                           WHERE  a.ID_TIPO_CUENTA = @id_tipo_cuenta AND a.ID_GRUPO_CUENTA = @id_grupo_cuenta
                           AND a.ID_CUENTA = @id_cuenta 
                           AND a.ID_TIPO_MOVIMIENTO = @id_tipo_movimiento
                           AND a.ID_EMPRESA=@id_empresa";
            try
            {
                SqlCommand cmd;
                cmd = cn.CreateCommand();
                cmd.Transaction = trx;
                cmd.Parameters.AddWithValue("@id_tipo_cuenta", id_tipo_cuenta);
                cmd.Parameters.AddWithValue("@id_grupo_cuenta", id_grupo_cuenta);
                cmd.Parameters.AddWithValue("@id_cuenta", id_cuenta);
                cmd.Parameters.AddWithValue("@id_tipo_movimiento", id_tipo_mov);
                cmd.Parameters.AddWithValue("@id_empresa", id_empresa);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL.ToString();
                nro_comprobante = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("ERROR Calculo_Nro_comprobante", ex);
            }
            return nro_comprobante;
        }
        private static int Calculo_Nro_comprobanteScope(int id_tipo_cuenta, int id_grupo_cuenta, int id_cuenta, int id_tipo_mov, int id_empresa)
        {
            int nro_comprobante = 0;
            string SQL = @"SELECT isnull(max(NRO_COMPROBANTE),0) FROM MOVIMIENTOS_CUENTAS a
                           WHERE  a.ID_TIPO_CUENTA = @id_tipo_cuenta AND a.ID_GRUPO_CUENTA = @id_grupo_cuenta
                           AND a.ID_CUENTA = @id_cuenta 
                           AND a.ID_TIPO_MOVIMIENTO = @id_tipo_movimiento
                           AND a.ID_EMPRESA=@id_empresa";
            try
            {
                SqlCommand cmd;
                using (SqlConnection con = GetConnection())
                {
                    cmd = con.CreateCommand();
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@id_tipo_cuenta", id_tipo_cuenta);
                    cmd.Parameters.AddWithValue("@id_grupo_cuenta", id_grupo_cuenta);
                    cmd.Parameters.AddWithValue("@id_cuenta", id_cuenta);
                    cmd.Parameters.AddWithValue("@id_tipo_movimiento", id_tipo_mov);
                    cmd.Parameters.AddWithValue("@id_empresa", id_empresa);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL.ToString();
                    nro_comprobante = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error Calculo_Nro_comprobanteScope", ex);
            }
            return nro_comprobante;
        }
        public static void Actualiza_Id_planilla(List<MOVIMIENTOS_CUENTAS> lstMovimientos, SqlConnection cn, SqlTransaction trx)
        {
            try
            {
                StringBuilder strSQL = new StringBuilder();
                //using (SqlConnection con = GetConnection())
                //{
                SqlCommand cmd = cn.CreateCommand();
                //
                strSQL.AppendLine("UPDATE MOVIMIENTOS_CUENTAS");
                strSQL.AppendLine(" set id_planilla=@id_planilla, conciliado=@conciliado, pendiente=@pendiente");
                strSQL.AppendLine("WHERE id_tipo_cuenta=@id_tipo_cuenta AND ");
                strSQL.AppendLine("id_grupo_cuenta=@id_grupo_cuenta AND ");
                strSQL.AppendLine("id_cuenta=@id_cuenta AND ");
                strSQL.AppendLine("id_tipo_movimiento=@id_tipo_movimiento AND ");
                strSQL.AppendLine("nro_comprobante=@nro_comprobante AND");
                strSQL.AppendLine("id_empresa=@id_empresa ");
                //
                cmd.Parameters.AddWithValue("@id_planilla", 0);
                cmd.Parameters.AddWithValue("@id_tipo_cuenta", 0);
                cmd.Parameters.AddWithValue("@id_grupo_cuenta", 0);
                cmd.Parameters.AddWithValue("@id_cuenta", 0);
                cmd.Parameters.AddWithValue("@id_tipo_movimiento", 0);
                cmd.Parameters.AddWithValue("@nro_comprobante", 0);
                cmd.Parameters.AddWithValue("@conciliado", true);
                cmd.Parameters.AddWithValue("@pendiente", false);
                cmd.Parameters.AddWithValue("@id_empresa", 0);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();
                //cmd.Connection.Open();
                cmd.Transaction = trx;
                foreach (var item in lstMovimientos)
                {
                    cmd.Parameters["@id_planilla"].Value = item.ID_PLANILLA;
                    cmd.Parameters["@id_tipo_cuenta"].Value = item.ID_TIPO_CUENTA;
                    cmd.Parameters["@id_grupo_cuenta"].Value = item.ID_GRUPO_CUENTA;
                    cmd.Parameters["@id_cuenta"].Value = item.ID_CUENTA;
                    cmd.Parameters["@id_tipo_movimiento"].Value = item.ID_TIPO_MOVIMIENTO;
                    cmd.Parameters["@nro_comprobante"].Value = item.NRO_COMPROBANTE;
                    cmd.Parameters["@conciliado"].Value = true;
                    cmd.Parameters["@pendiente"].Value = false;
                    cmd.Parameters["@id_empresa"].Value = item.ID_EMPRESA;
                    cmd.ExecuteNonQuery();
                }
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static void Actualiza_Id_planillaScope(List<MOVIMIENTOS_CUENTAS> lstMovimientos)
        {
            try
            {
                string strSQL = @"UPDATE MOVIMIENTOS_CUENTAS
                                  set id_planilla=@id_planilla, conciliado=@conciliado, pendiente=@pendiente
                                  WHERE id_tipo_cuenta=@id_tipo_cuenta AND
                                  id_grupo_cuenta=@id_grupo_cuenta AND
                                  id_cuenta=@id_cuenta AND
                                  id_tipo_movimiento=@id_tipo_movimiento AND
                                  nro_comprobante=@nro_comprobante AND 
                                  id_empresa=@id_empresa";
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    //
                    cmd.Parameters.AddWithValue("@id_planilla", 0);
                    cmd.Parameters.AddWithValue("@id_tipo_cuenta", 0);
                    cmd.Parameters.AddWithValue("@id_grupo_cuenta", 0);
                    cmd.Parameters.AddWithValue("@id_cuenta", 0);
                    cmd.Parameters.AddWithValue("@id_tipo_movimiento", 0);
                    cmd.Parameters.AddWithValue("@nro_comprobante", 0);
                    cmd.Parameters.AddWithValue("@conciliado", true);
                    cmd.Parameters.AddWithValue("@pendiente", false);
                    cmd.Parameters.AddWithValue("@id_empresa", 0);

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();
                    cmd.Connection.Open();
                    foreach (var item in lstMovimientos)
                    {
                        cmd.Parameters["@id_planilla"].Value = item.ID_PLANILLA;
                        cmd.Parameters["@id_tipo_cuenta"].Value = item.ID_TIPO_CUENTA;
                        cmd.Parameters["@id_grupo_cuenta"].Value = item.ID_GRUPO_CUENTA;
                        cmd.Parameters["@id_cuenta"].Value = item.ID_CUENTA;
                        cmd.Parameters["@id_tipo_movimiento"].Value = item.ID_TIPO_MOVIMIENTO;
                        cmd.Parameters["@nro_comprobante"].Value = item.NRO_COMPROBANTE;
                        cmd.Parameters["@conciliado"].Value = true;
                        cmd.Parameters["@pendiente"].Value = false;
                        cmd.Parameters["@id_empresa"].Value = item.ID_EMPRESA;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static MOVIMIENTOS_CUENTAS getByPk(int id_tipo_cuenta, int id_grupo_cuenta, int id_cuenta, int id_tipo_movimiento, int id_empresa, int nro_comprobante)
        {
            try
            {
                MOVIMIENTOS_CUENTAS obj = null;

                StringBuilder strSQL = new StringBuilder();

                strSQL.AppendLine("SELECT a.id_tipo_cuenta, a.id_grupo_cuenta, a.id_cuenta, a.id_tipo_movimiento, ");
                strSQL.AppendLine("b.DESCRIPCION as tipo_cuenta,");
                strSQL.AppendLine("c.DESCRIPCION as grupo_cuenta,");
                strSQL.AppendLine("d.DESCRIPCION as cuenta,");
                strSQL.AppendLine("e.des_tipo_movimiento as tipo_movimiento,");
                strSQL.AppendLine("a.fecha_movimiento, a.fecha_acreditacion,");
                strSQL.AppendLine("a.nro_comprobante,");
                strSQL.AppendLine("a.id_caja,");
                strSQL.AppendLine("a.anio,");
                strSQL.AppendLine("a.importe, a.concepto,");
                strSQL.AppendLine("a.conciliado, a.pendiente, a.cancelado, a.id_planilla, a.id_empresa ");
                strSQL.AppendLine("FROM MOVIMIENTOS_CUENTAS a ");
                strSQL.AppendLine("join PLAN_CUENTAS d on ");
                strSQL.AppendLine("a.id_tipo_cuenta = d.ID_TIPO_CUENTA AND ");
                strSQL.AppendLine("a.id_grupo_cuenta = d.ID_GRUPO_CUENTA AND ");
                strSQL.AppendLine("a.id_cuenta = d.ID_CUENTA AND ");
                strSQL.AppendLine("a.anio = d.ANIO ");
                strSQL.AppendLine("join TIPO_CUENTA b on ");
                strSQL.AppendLine("a.id_tipo_cuenta=b.ID_TIPO_CUENTA ");
                strSQL.AppendLine("join GRUPO_CUENTAS c on ");
                strSQL.AppendLine("a.id_grupo_cuenta = c.ID_GRUPO_CUENTA ");
                strSQL.AppendLine("join TIPOS_MOVIMIENTOS_CUENTAS e on ");
                strSQL.AppendLine("a.id_tipo_movimiento=e.id_tipo_movimiento ");
                strSQL.AppendLine("WHERE a.id_tipo_cuenta=@id_tipo_cuenta AND ");
                strSQL.AppendLine("a.id_grupo_cuenta=@id_grupo_cuenta AND ");
                strSQL.AppendLine("a.id_cuenta=@id_cuenta AND ");
                strSQL.AppendLine("a.id_tipo_movimiento=@id_tipo_movimiento AND ");
                strSQL.AppendLine("a.nro_comprobante=@nro_comprobante ");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.Parameters.AddWithValue("@id_tipo_cuenta", id_tipo_cuenta);
                    cmd.Parameters.AddWithValue("@id_grupo_cuenta", id_grupo_cuenta);
                    cmd.Parameters.AddWithValue("@id_cuenta", id_cuenta);
                    cmd.Parameters.AddWithValue("@id_tipo_movimiento", id_tipo_movimiento);
                    cmd.Parameters.AddWithValue("@nro_comprobante", nro_comprobante);

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();

                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int ID_TIPO_CUENTA = dr.GetOrdinal("ID_TIPO_CUENTA");
                        int TIPO_CUENTA = dr.GetOrdinal("TIPO_CUENTA");
                        int ID_GRUPO_CUENTA = dr.GetOrdinal("ID_GRUPO_CUENTA");
                        int GRUPO_CUENTA = dr.GetOrdinal("GRUPO_CUENTA");
                        int ID_CUENTA = dr.GetOrdinal("ID_CUENTA");
                        int CUENTA = dr.GetOrdinal("CUENTA");
                        int ID_TIPO_MOVIMIENTO = dr.GetOrdinal("ID_TIPO_MOVIMIENTO");
                        int TIPO_MOVIMIENTO = dr.GetOrdinal("TIPO_MOVIMIENTO");
                        int ID_CAJA = dr.GetOrdinal("ID_CAJA");
                        int NRO_COMPROBANTE = dr.GetOrdinal("NRO_COMPROBANTE");
                        int ANIO = dr.GetOrdinal("ANIO");
                        int CONCEPTO = dr.GetOrdinal("CONCEPTO");
                        int CONCILIADO = dr.GetOrdinal("CONCILIADO");
                        int CANCELADO = dr.GetOrdinal("CANCELADO");
                        int PENDIENTE = dr.GetOrdinal("PENDIENTE");
                        int FECHA_MOVIMIENTO = dr.GetOrdinal("FECHA_MOVIMIENTO");
                        int FECHA_ACREDITACION = dr.GetOrdinal("FECHA_ACREDITACION");
                        int IMPORTE = dr.GetOrdinal("IMPORTE");
                        int ID_PLANILLA = dr.GetOrdinal("ID_PLANILLA");

                        while (dr.Read())
                        {
                            obj = new MOVIMIENTOS_CUENTAS();

                            if (!dr.IsDBNull(ID_TIPO_CUENTA)) { obj.ID_TIPO_CUENTA = dr.GetInt32(ID_TIPO_CUENTA); }
                            if (!dr.IsDBNull(TIPO_CUENTA)) { obj.TIPO_CUENTA = dr.GetString(TIPO_CUENTA); }
                            if (!dr.IsDBNull(ID_GRUPO_CUENTA)) { obj.ID_GRUPO_CUENTA = dr.GetInt32(ID_GRUPO_CUENTA); }
                            if (!dr.IsDBNull(GRUPO_CUENTA)) { obj.GRUPO_CUENTA = dr.GetString(GRUPO_CUENTA); }
                            if (!dr.IsDBNull(ID_CUENTA)) { obj.ID_CUENTA = dr.GetInt32(ID_CUENTA); }
                            if (!dr.IsDBNull(CUENTA)) { obj.CUENTA = dr.GetString(CUENTA); }
                            if (!dr.IsDBNull(ID_TIPO_MOVIMIENTO)) { obj.ID_TIPO_MOVIMIENTO = dr.GetInt32(ID_TIPO_MOVIMIENTO); }
                            if (!dr.IsDBNull(ID_CAJA)) { obj.ID_CAJA = dr.GetInt32(ID_CAJA); }
                            if (!dr.IsDBNull(TIPO_MOVIMIENTO)) { obj.TIPO_MOVIMIENTO = dr.GetString(TIPO_MOVIMIENTO); }
                            if (!dr.IsDBNull(NRO_COMPROBANTE)) { obj.NRO_COMPROBANTE = dr.GetInt32(NRO_COMPROBANTE); }
                            if (!dr.IsDBNull(ANIO)) { obj.ANIO = dr.GetInt16(ANIO); }
                            if (!dr.IsDBNull(CONCEPTO)) { obj.CONCEPTO = dr.GetString(CONCEPTO); }
                            if (!dr.IsDBNull(CONCILIADO)) { obj.CONCILIADO = dr.GetBoolean(CONCILIADO); }
                            if (!dr.IsDBNull(CANCELADO)) { obj.CANCELADO = dr.GetBoolean(CANCELADO); }
                            if (!dr.IsDBNull(PENDIENTE)) { obj.PENDIENTE = dr.GetBoolean(PENDIENTE); }
                            if (!dr.IsDBNull(FECHA_MOVIMIENTO)) { obj.FECHA_MOVIMIENTO = dr.GetDateTime(FECHA_MOVIMIENTO); }
                            if (!dr.IsDBNull(IMPORTE)) { obj.IMPORTE = dr.GetDecimal(IMPORTE); }
                            if (!dr.IsDBNull(ID_PLANILLA)) { obj.ID_PLANILLA = dr.GetInt32(ID_PLANILLA); }
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
        public static List<MOVIMIENTOS_CUENTAS> GetLstMovimientos(DateTime desde, DateTime hasta, SqlConnection cn, SqlTransaction trx)
        {

            List<MOVIMIENTOS_CUENTAS> lst = new List<MOVIMIENTOS_CUENTAS>();
            MOVIMIENTOS_CUENTAS eMov;//= new Entities.Liquidacion();
            StringBuilder strSQL = new StringBuilder();
            SqlCommand cmd = null;

            strSQL.AppendLine("set dateformat dmy;");
            strSQL.AppendLine("select a.id_tipo_cuenta, a.id_grupo_cuenta, a.id_cuenta, ");
            strSQL.AppendLine("a.id_tipo_movimiento, a.id_caja, a.nro_comprobante, a.importe,");
            strSQL.AppendLine("b.ingreso, b.bancario, a.id_planilla");
            strSQL.AppendLine("from MOVIMIENTOS_CUENTAS a (nolock)");
            strSQL.AppendLine("join TIPOS_MOVIMIENTOS_CUENTAS b on");
            strSQL.AppendLine("a.id_tipo_movimiento = b.id_tipo_movimiento");
            strSQL.AppendLine("where ");
            strSQL.AppendLine("a.conciliado = 0 and ");
            strSQL.AppendLine("a.cancelado = 0 and ");
            strSQL.AppendLine("(a.interno is null or a.interno=0) and ");
            strSQL.AppendLine("(a.id_planilla is null or a.id_planilla=0) ");
            strSQL.AppendLine(" and a.fecha_movimiento between dateadd(Mi, -1, @desde) AND dateadd(Mi, 1, @hasta)");

            try
            {
                //using (SqlConnection con = GetConnection())
                //{
                cmd = cn.CreateCommand();
                //cmd.Connection.Open();
                cmd.Transaction = trx;
                cmd.Parameters.AddWithValue("@desde", desde);
                cmd.Parameters.AddWithValue("@hasta", hasta);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL.ToString();

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    int id_tipo_cuenta = dr.GetOrdinal("id_tipo_cuenta");
                    int id_grupo_cuenta = dr.GetOrdinal("id_grupo_cuenta");
                    int id_cuenta = dr.GetOrdinal("id_cuenta");
                    int id_tipo_movimiento = dr.GetOrdinal("id_tipo_movimiento");
                    int importe = dr.GetOrdinal("importe");
                    int id_caja = dr.GetOrdinal("id_caja");
                    int nro_comprobante = dr.GetOrdinal("nro_comprobante");
                    int ingreso = dr.GetOrdinal("ingreso");
                    int bancario = dr.GetOrdinal("bancario");
                    int nro_planilla = dr.GetOrdinal("id_planilla");
                    while (dr.Read())
                    {
                        eMov = new MOVIMIENTOS_CUENTAS();

                        if (!dr.IsDBNull(id_tipo_cuenta)) eMov.ID_TIPO_CUENTA = dr.GetInt32(id_tipo_cuenta);
                        if (!dr.IsDBNull(id_grupo_cuenta)) eMov.ID_GRUPO_CUENTA = dr.GetInt32(id_grupo_cuenta);
                        if (!dr.IsDBNull(id_cuenta)) eMov.ID_CUENTA = dr.GetInt32(id_cuenta);
                        if (!dr.IsDBNull(id_tipo_movimiento)) eMov.ID_TIPO_MOVIMIENTO = dr.GetInt32(id_tipo_movimiento);
                        if (!dr.IsDBNull(id_caja)) eMov.ID_CAJA = dr.GetInt32(id_caja);
                        if (!dr.IsDBNull(nro_comprobante)) eMov.NRO_COMPROBANTE = dr.GetInt32(nro_comprobante);
                        if (!dr.IsDBNull(importe)) eMov.IMPORTE = dr.GetDecimal(importe);
                        if (!dr.IsDBNull(ingreso)) eMov.INGRESO = dr.GetBoolean(ingreso);
                        if (!dr.IsDBNull(bancario)) eMov.BANCARIO = dr.GetBoolean(bancario);
                        lst.Add(eMov);
                    }
                }
                dr.Close();
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw e;
            }
            finally
            { cmd = null; }
            return lst;
        }
        public static List<MOVIMIENTOS_CUENTAS> GetLstMovimientosScope(DateTime desde, DateTime hasta)
        {
            List<MOVIMIENTOS_CUENTAS> lst = new List<MOVIMIENTOS_CUENTAS>();
            MOVIMIENTOS_CUENTAS eMov;//= new Entities.Liquidacion();
            StringBuilder strSQL = new StringBuilder();
            SqlCommand cmd = null;
            strSQL.AppendLine("set dateformat dmy;");
            strSQL.AppendLine("select a.id_tipo_cuenta, a.id_grupo_cuenta, a.id_cuenta, ");
            strSQL.AppendLine("a.id_tipo_movimiento, a.id_caja, a.nro_comprobante, a.importe,");
            strSQL.AppendLine("b.ingreso, b.bancario, a.id_planilla");
            strSQL.AppendLine("from MOVIMIENTOS_CUENTAS a (nolock)");
            strSQL.AppendLine("join TIPOS_MOVIMIENTOS_CUENTAS b on");
            strSQL.AppendLine("a.id_tipo_movimiento = b.id_tipo_movimiento");
            strSQL.AppendLine("where ");
            strSQL.AppendLine("a.conciliado = 0 and ");
            strSQL.AppendLine("a.cancelado = 0 and ");
            strSQL.AppendLine("(a.interno is null or a.interno=0) and ");
            strSQL.AppendLine("(a.id_planilla is null or a.id_planilla=0) ");
            strSQL.AppendLine(" and a.fecha_movimiento between dateadd(Mi, -1, @desde) AND dateadd(Mi, 1, @hasta)");

            try
            {
                using (SqlConnection con = GetConnection())
                {
                    cmd = con.CreateCommand();
                    cmd.Connection.Open();
                    cmd.Parameters.AddWithValue("@desde", desde);
                    cmd.Parameters.AddWithValue("@hasta", hasta);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strSQL.ToString();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        int id_tipo_cuenta = dr.GetOrdinal("id_tipo_cuenta");
                        int id_grupo_cuenta = dr.GetOrdinal("id_grupo_cuenta");
                        int id_cuenta = dr.GetOrdinal("id_cuenta");
                        int id_tipo_movimiento = dr.GetOrdinal("id_tipo_movimiento");
                        int importe = dr.GetOrdinal("importe");
                        int id_caja = dr.GetOrdinal("id_caja");
                        int nro_comprobante = dr.GetOrdinal("nro_comprobante");
                        int ingreso = dr.GetOrdinal("ingreso");
                        int bancario = dr.GetOrdinal("bancario");
                        int nro_planilla = dr.GetOrdinal("id_planilla");
                        while (dr.Read())
                        {
                            eMov = new MOVIMIENTOS_CUENTAS();

                            if (!dr.IsDBNull(id_tipo_cuenta)) eMov.ID_TIPO_CUENTA = dr.GetInt32(id_tipo_cuenta);
                            if (!dr.IsDBNull(id_grupo_cuenta)) eMov.ID_GRUPO_CUENTA = dr.GetInt32(id_grupo_cuenta);
                            if (!dr.IsDBNull(id_cuenta)) eMov.ID_CUENTA = dr.GetInt32(id_cuenta);
                            if (!dr.IsDBNull(id_tipo_movimiento)) eMov.ID_TIPO_MOVIMIENTO = dr.GetInt32(id_tipo_movimiento);
                            if (!dr.IsDBNull(id_caja)) eMov.ID_CAJA = dr.GetInt32(id_caja);
                            if (!dr.IsDBNull(nro_comprobante)) eMov.NRO_COMPROBANTE = dr.GetInt32(nro_comprobante);
                            if (!dr.IsDBNull(importe)) eMov.IMPORTE = dr.GetDecimal(importe);
                            if (!dr.IsDBNull(ingreso)) eMov.INGRESO = dr.GetBoolean(ingreso);
                            if (!dr.IsDBNull(bancario)) eMov.BANCARIO = dr.GetBoolean(bancario);
                            lst.Add(eMov);
                        }
                    }
                    dr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in query!" + e.ToString());
                throw e;
            }
            finally
            { cmd = null; }
            return lst;
        }
        //public static void Delete_Movimiento_Cuentas(DateTime desde, DateTime hasta, PLANILLA_CAJA oPC, SqlConnection cn, SqlTransaction trx)
        //{

        //    StringBuilder strSQL = new StringBuilder();
        //    try
        //    {
        //        strSQL.AppendLine("delete from MOVIMIENTOS_CUENTAS");
        //        strSQL.AppendLine("where id_planilla = @id_planilla");
        //        strSQL.AppendLine("and id_caja = @id_caja");
        //        strSQL.AppendLine("and interno = 1");
        //        //using (SqlConnection con = GetConnection())
        //        //                {
        //        SqlCommand cmd = cn.CreateCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Parameters.AddWithValue("@id_planilla", oPC.ID_PLANILLA);
        //        cmd.Parameters.AddWithValue("@id_caja", oPC.ID_CAJA);
        //        cmd.CommandText = strSQL.ToString();
        //        //cmd.Connection.Open();
        //        cmd.Transaction = trx;
        //        cmd.ExecuteNonQuery();
        //        //}

        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        //public static void Delete_Movimiento_CuentasScope(DateTime desde, DateTime hasta, PLANILLA_CAJA oPC)
        //{

        //    StringBuilder strSQL = new StringBuilder();
        //    try
        //    {
        //        strSQL.AppendLine("delete from MOVIMIENTOS_CUENTAS");
        //        strSQL.AppendLine("where id_planilla = @id_planilla");
        //        strSQL.AppendLine("and id_caja = @id_caja");
        //        strSQL.AppendLine("and interno = 1");
        //        using (SqlConnection con = GetConnection())
        //        {
        //            SqlCommand cmd = con.CreateCommand();
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("@id_planilla", oPC.ID_PLANILLA);
        //            cmd.Parameters.AddWithValue("@id_caja", oPC.ID_CAJA);
        //            cmd.CommandText = strSQL.ToString();
        //            cmd.Connection.Open();
        //            cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        public static void Delete_Movimiento(MOVIMIENTOS_CUENTAS oMC, SqlConnection cn, SqlTransaction trx)
        {
            StringBuilder strSQL = new StringBuilder();
            try
            {
                strSQL.AppendLine("delete from MOVIMIENTOS_CUENTAS");
                strSQL.AppendLine("where id_tipo_cuenta = @id_tipo_cuenta");
                strSQL.AppendLine("and id_grupo_cuenta = @id_grupo_cuenta");
                strSQL.AppendLine("and id_cuenta = @id_cuenta");
                strSQL.AppendLine("and id_tipo_movimiento = @id_tipo_movimiento");
                strSQL.AppendLine("and nro_comprobante = @nro_comprobante");
                strSQL.AppendLine("and id_caja = @id_caja");
                strSQL.AppendLine("and interno = 0");

                //using (SqlConnection con = GetConnection())
                //{
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id_tipo_cuenta", oMC.ID_TIPO_CUENTA);
                cmd.Parameters.AddWithValue("@id_grupo_cuenta", oMC.ID_GRUPO_CUENTA);
                cmd.Parameters.AddWithValue("@id_cuenta", oMC.ID_CUENTA);
                cmd.Parameters.AddWithValue("@id_tipo_movimiento", oMC.ID_TIPO_MOVIMIENTO);
                cmd.Parameters.AddWithValue("@nro_comprobante", oMC.NRO_COMPROBANTE);
                cmd.Parameters.AddWithValue("@id_caja", oMC.ID_CAJA);
                cmd.CommandText = strSQL.ToString();
                //cmd.Connection.Open();
                cmd.Transaction = trx;
                cmd.ExecuteNonQuery();
                //}

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





    }
}
