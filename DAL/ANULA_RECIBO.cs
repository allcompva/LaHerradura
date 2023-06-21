﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ANULA_RECIBO : DALBase
    {
        public static void cancelaPagoCompletoMovTipo_1(CTACTE_EXPENSAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CTACTE_EXPENSAS");
                sql.AppendLine("SET DEBE=MONTO_ORIGINAL, SALDO=MONTO_ORIGINAL, NRO_RECIBO_PAGO=NULL,");
                sql.AppendLine("PAGADO=0, INTERES_MORA=0, DESC_VENCIMIENTO=0, DIAS_MORA=0,OBS_AJUSTE='',");
                sql.AppendLine("FECHA_ULTIMO_PAGO=VENCIMIENTO, PAGO_A_CTA=0,SALDO_CAPITAL=MONTO_ORIGINAL,");
                sql.AppendLine("SALDO_INTERES=0, CAPITAL_PAGADO=0, AJUSTE_INTERES=0, INTERES_PAGADO=0, ID_MEDIO_PAGO=0");
                sql.AppendLine("WHERE ID=@ID");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void cancelaPagoCompletoMovTipo_1Gastos(CTACTE_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CTACTE_GASTOS");
                sql.AppendLine("SET DEBE=MONTO_ORIGINAL, SALDO=MONTO_ORIGINAL, NRO_RECIBO_PAGO=NULL,");
                sql.AppendLine("PAGADO=0, INTERES_MORA=0, OBS_AJUSTE='',HABER=0,");
                sql.AppendLine("FECHA_ULTIMO_PAGO=VENCIMIENTO, PAGO_A_CTA=0,SALDO_CAPITAL=MONTO_ORIGINAL,");
                sql.AppendLine("SALDO_INTERES=0, CAPITAL_PAGADO=0, AJUSTE_INTERES=0, INTERES_PAGADO=0, ID_MEDIO_PAGO=0");
                sql.AppendLine("WHERE ID=@ID");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID", obj.ID);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void cancelaPagoParcialMovTipo_1(CTACTE_EXPENSAS objMov2, CTACTE_EXPENSAS objMov1, DateTime fecha)
        {
            try
            {
                string sql = @"UPDATE CTACTE_EXPENSAS
                                SET DEBE=@DEBE, 
                                SALDO=@SALDO, 
                                NRO_RECIBO_PAGO=NULL,
                                PAGADO=0, 
                                INTERES_MORA=0, 
                                DESC_VENCIMIENTO=0, 
                                DIAS_MORA=0,
                                OBS_AJUSTE='',
                                FECHA_ULTIMO_PAGO=@FECHA_ULTIMO_PAGO, 
                                PAGO_A_CTA=@PAGO_A_CTA,
                                SALDO_CAPITAL=@SALDO_CAPITAL,
                                SALDO_INTERES=@SALDO_INTERES, 
                                CAPITAL_PAGADO=@CAPITAL_PAGADO, 
                                INTERES_PAGADO=0, 
                                ID_MEDIO_PAGO=0
                                WHERE ID=@ID";

                using (SqlConnection con = GetConnection())
                {
                    decimal DEBE = objMov1.DEBE  + objMov2.HABER;
                    decimal SALDO = objMov1.SALDO + objMov2.HABER;
                    decimal PAGO_A_CTA = objMov1.PAGO_A_CTA - objMov2.HABER;
                    decimal SALDO_CAPITAL = objMov1.SALDO_CAPITAL + objMov2.CAPITAL_PAGADO;
                    decimal SALDO_INTERES = objMov1.SALDO_INTERES + objMov2.INTERES_PAGADO;
                    decimal CAPITAL_PAGADO = objMov1.CAPITAL_PAGADO - objMov2.CAPITAL_PAGADO;
                    decimal INTERES_PAGADO = objMov1.INTERES_PAGADO - objMov2.INTERES_PAGADO;
                    

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@DEBE", DEBE);
                    cmd.Parameters.AddWithValue("@SALDO", SALDO);
                    cmd.Parameters.AddWithValue("@PAGO_A_CTA", PAGO_A_CTA);
                    cmd.Parameters.AddWithValue("@SALDO_CAPITAL", SALDO_CAPITAL);
                    cmd.Parameters.AddWithValue("@SALDO_INTERES", 0);
                    cmd.Parameters.AddWithValue("@CAPITAL_PAGADO", CAPITAL_PAGADO);
                    cmd.Parameters.AddWithValue("@INTERES_PAGADO", INTERES_PAGADO);

                    cmd.Parameters.AddWithValue("@FECHA_ULTIMO_PAGO", fecha);
                    cmd.Parameters.AddWithValue("@ID", objMov1.ID);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void cancelaPagoParcialMovTipo_1Gastos(int idProv,
            int ptoVta, long nroCte, decimal montoACancelar, DateTime fechaPagoAnt)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CTACTE_GASTOS");
                sql.AppendLine("SET DEBE=DEBE+@MONTO_A_CANCELAR,");
                sql.AppendLine("SALDO=SALDO+@MONTO_A_CANCELAR,");
                sql.AppendLine("NRO_RECIBO_PAGO=NULL,");
                sql.AppendLine("PAGADO=0, INTERES_MORA=0, OBS_AJUSTE='',");
                sql.AppendLine("FECHA_ULTIMO_PAGO=@FECHA_PAGO_ANT,");
                sql.AppendLine("PAGO_A_CTA=PAGO_A_CTA-@MONTO_A_CANCELAR,");
                sql.AppendLine("SALDO_CAPITAL=SALDO_CAPITAL+@MONTO_A_CANCELAR,");
                sql.AppendLine("CAPITAL_PAGADO=CAPITAL_PAGADO-@MONTO_A_CANCELAR,");
                sql.AppendLine("ID_MEDIO_PAGO=0");
                sql.AppendLine("WHERE ID_PROVEEDOR=@ID_PROVEEDOR AND");
                sql.AppendLine("PTO_VTA=@PTO_VTA AND NRO_CTE=@NRO_CTE");
                sql.AppendLine("AND TIPO_MOVIMIENTO=1");

                using (SqlConnection con = GetConnection())
                {

                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@MONTO_A_CANCELAR",
                        montoACancelar);
                    cmd.Parameters.AddWithValue("@FECHA_PAGO_ANT", fechaPagoAnt);
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProv);
                    cmd.Parameters.AddWithValue("@PTO_VTA", ptoVta);
                    cmd.Parameters.AddWithValue("@NRO_CTE", nroCte);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void cancelaPagoCompletoMovTipo_2(CTACTE_EXPENSAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CTACTE_EXPENSAS");
                sql.AppendLine("SET TIPO_MOVIMIENTO=10, ID_USUARIO_ANULA=@ID_USUARIO_ANULA, OBS=@OBS");
                sql.AppendLine("WHERE NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO AND TIPO_MOVIMIENTO=2 AND PERIODO=@PERIODO");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", obj.NRO_RECIBO_PAGO);
                    cmd.Parameters.AddWithValue("@ID_USUARIO_ANULA", obj.ID_USUARIO_ANULA);
                    cmd.Parameters.AddWithValue("@OBS", obj.OBS);
                    cmd.Parameters.AddWithValue("@PERIODO", obj.PERIODO);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void cancelaPagoCompletoMovTipo_2Gastos(CTACTE_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE CTACTE_GASTOS");
                sql.AppendLine("SET TIPO_MOVIMIENTO=10, ID_USUARIO_ANULA=@ID_USUARIO_ANULA, OBS=@OBS");
                sql.AppendLine("WHERE NRO_RECIBO_PAGO=@NRO_RECIBO_PAGO AND TIPO_MOVIMIENTO=2");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@NRO_RECIBO_PAGO", obj.NRO_RECIBO_PAGO);
                    cmd.Parameters.AddWithValue("@ID_USUARIO_ANULA", obj.ID_USUARIO_ANULA);
                    cmd.Parameters.AddWithValue("@OBS", obj.OBS);

                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void elimina(CTACTE_EXPENSAS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE PAGOS_X_FACTURA");
                sql.AppendLine("WHERE ID_FACTURA=@ID_FACTURA");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_FACTURA", obj.NRO_RECIBO_PAGO);


                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void eliminaGastos(CTACTE_GASTOS obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE PAGOS_X_FACTURA_GASTOS");
                sql.AppendLine("WHERE ID_FACTURA=@ID_FACTURA");

                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@ID_FACTURA", obj.NRO_RECIBO_PAGO);


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
