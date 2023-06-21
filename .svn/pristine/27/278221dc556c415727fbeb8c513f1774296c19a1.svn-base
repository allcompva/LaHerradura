using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace LaHerradura
{
    public class CTA_CTE_GASTOS
    {
        public static void asientaPago(List<DAL.CTACTE_GASTOS> lst,
    List<DAL.PAGOS_X_FACTURA_GASTOS> lstPagos, DateTime fechaPago,
    int idOp, int idUsuario)
        {
            try
            {
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                using (TransactionScope scope = new TransactionScope())
                {
                    int nroRecibo = DAL.CTACTE_GASTOS.getMaxNroRecibo() + 1;
                    foreach (var item in lst)
                    {
                        if (item.PAGO_TOTAL)
                        {
                            asientaPagoCompleto(item, nroRecibo, fechaPago);
                            DAL.ORDENES_PAGO.pagoOrden(idOp, item.MONTO_PAGADO);
                        }
                        else
                        {
                            asientaPagoCta(item, fechaPago, nroRecibo);
                            DAL.ORDENES_PAGO.pagoCuentaOrden(idOp, item.MONTO_PAGADO, item.SALDO-item.MONTO_PAGADO);
                        }
                    }
                    foreach (var item in lstPagos)
                    {
                        item.ID_FACTURA = nroRecibo;
                        item.FECHA = lst[0].FECHA;
                        
                        if (item.ID_PLAN_PAGO == 7)
                        {
                            int idProv = lst[0].ID_PROVEEDOR;
                            decimal monto = item.MONTO;

                            DAL.MOV_BILLETERA_GASTOS obj = new DAL.MOV_BILLETERA_GASTOS();
                            obj.FECHA = fec;
                            obj.FECHA_CARGA = fec;
                            obj.ID_PROVEEDOR = idProv;
                            obj.MONTO = monto;

                            obj.NRO_RECIBO = nroRecibo;
                            obj.TIPO_MOVIMIENTO = 2;
                            obj.FECHA_CARGA = fec;
                            obj.ID_USUARIO_CARGA = Convert.ToInt32(idUsuario);
                            DAL.MOV_BILLETERA_GASTOS.insert(obj);
                            DAL.BILLETERA_GASTOS.setSaldo(idProv, monto - (monto * 2));
                        }
                        DAL.PAGOS_X_FACTURA_GASTOS.insert(item);
                        if (item.ID_PLAN_PAGO != 7)
                        {
                            DAL.PROVEEDORES objProv =
                                DAL.PROVEEDORES.getByPk(lst[0].ID_PROVEEDOR);
                            //MOVIMIENTO DE CAJA
                            DAL.TB_MOVIM_CAJA objMovim = new DAL.TB_MOVIM_CAJA();
                            objMovim.DETALLE = string.Format(
                                "Pago a {0} - Recibio Nro.: {1}",
                                objProv.RAZON_SOCIAL, nroRecibo);
                            objMovim.ID_FACTURA = nroRecibo;
                            objMovim.HORA = item.FECHA;
                            objMovim.ID_CAJA = 1;
                            //objMovim.ID_PLANILLA = objPlanilla.ID;
                            objMovim.ID_PLANILLA = 0;
                            switch (item.ID_PLAN_PAGO)
                            {
                                case 1:
                                    objMovim.ID_CTA_INGRESO = 1;
                                    objMovim.ID_CTA_EGRESO = 1;
                                    break;
                                case 2:
                                    objMovim.ID_CTA_INGRESO = 2;
                                    objMovim.ID_CTA_EGRESO = 2;
                                    break;
                                default:
                                    objMovim.ID_CTA_INGRESO = 7;
                                    objMovim.ID_CTA_EGRESO = 7;
                                    break;
                            }

                            objMovim.ID_RESPONSABLE = item.USUARIO;
                            objMovim.ID_USUARIO = item.USUARIO;
                            objMovim.MONTO = item.MONTO;
                            objMovim.ID_FACTURA = item.ID;
                            objMovim.TIPO_MOV = 2;
                            objMovim.ID_SUCURSAL = 1;
                            DAL.TB_MOVIM_CAJA.insert(objMovim);
                        }
                    }
                    if (lstPagos.Sum(p => p.MONTO) > lst.Sum(p => p.MONTO_PAGADO))
                    {
                        int idProv = lst[0].ID_PROVEEDOR;
                        decimal monto =
                            lstPagos.Sum(p => p.MONTO) - lst.Sum(p => p.MONTO_PAGADO);
                        DAL.MOV_BILLETERA_GASTOS obj = new DAL.MOV_BILLETERA_GASTOS();
                        obj.FECHA = fec;
                        obj.FECHA_CARGA = fec;
                        obj.ID_MEDIO_PAGO = lst[0].ID_MEDIO_PAGO;
                        if (obj.ID_MEDIO_PAGO == 2)
                        {
                            obj.FECHA_CHEQUE = lstPagos[0].FECHA_CHEQUE;
                            obj.ID_BANCO = lstPagos[0].ID_BANCO;
                            obj.NRO_CHEQUE = lstPagos[0].NRO_CHEQUE;
                            obj.CUIT_PAGADOR = lstPagos[0].CUIT_PAGADOR;
                        }
                        obj.MONTO =
                            lstPagos.Sum(p => p.MONTO) - lst.Sum(p => p.MONTO_PAGADO);
                        obj.ID_PROVEEDOR = lst[0].ID_PROVEEDOR;
                        obj.NRO_RECIBO = nroRecibo;
                        obj.TIPO_MOVIMIENTO = 1;
                        obj.ID_USUARIO_CARGA = Convert.ToInt32(idUsuario);
                        DAL.MOV_BILLETERA_GASTOS.insert(obj);
                        DAL.BILLETERA_GASTOS.setSaldo(idProv, monto);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void asientaPagoCompleto(DAL.CTACTE_GASTOS obj, int nroRecibo, DateTime fechaPago)
        {
            try
            {
                decimal porc_pago = obj.MONTO_PAGADO / obj.SALDO;
                decimal capital_pagado = obj.SALDO_CAPITAL * porc_pago;
                decimal interes_pagado = obj.INTERES_MORA * porc_pago;
                decimal saldo_capital = obj.SALDO_CAPITAL - capital_pagado;
                decimal saldo_interes = obj.SALDO_INTERES - interes_pagado;

                DAL.CTACTE_GASTOS objMov2 = new DAL.CTACTE_GASTOS();
                objMov2.FECHA = fechaPago;
                objMov2.CAPITAL_PAGADO = obj.SALDO_CAPITAL;
                objMov2.HABER = obj.MONTO_PAGADO;
                objMov2.INTERES_MORA = obj.INTERES_MORA;
                objMov2.INTERES_PAGADO = obj.SALDO_INTERES;
                objMov2.ID_PROVEEDOR = obj.ID_PROVEEDOR;
                objMov2.NRO_RECIBO_PAGO = nroRecibo;
                objMov2.FACTURA = obj.FACTURA;
                objMov2.SALDO_CAPITAL = 0;
                objMov2.SALDO_INTERES = 0;
                objMov2.ID_MEDIO_PAGO = obj.ID_MEDIO_PAGO;
                objMov2.VENCIMIENTO = obj.VENCIMIENTO;
                objMov2.ID_MEDIO_PAGO = obj.ID_MEDIO_PAGO;
                objMov2.TIPO_MOVIMIENTO = 2;
                objMov2.NRO_CUOTA = obj.NRO_CUOTA;
                objMov2.NRO_PLAN_PAGO = obj.NRO_PLAN_PAGO;
                objMov2.ID_USUARIO_PAGA = obj.ID_USUARIO_PAGA;
                objMov2.PTO_VTA = obj.PTO_VTA;
                objMov2.NRO_CTE = obj.NRO_CTE;
                objMov2.ID_PLAN_CUENTA = obj.ID_PLAN_CUENTA;
                DAL.CTACTE_GASTOS.asientoPago(objMov2);

                DAL.CTACTE_GASTOS objMov1 = new DAL.CTACTE_GASTOS();
                objMov1.ID = obj.ID;
                obj.NRO_RECIBO_PAGO = nroRecibo;
                objMov1.PAGADO = true;
                objMov1.FECHA_ULTIMO_PAGO = fechaPago;
                objMov1.CAPITAL_PAGADO = obj.CAPITAL_PAGADO + capital_pagado;
                objMov1.INTERES_PAGADO = obj.INTERES_PAGADO + interes_pagado;
                objMov1.SALDO_CAPITAL = 0;
                objMov1.SALDO_INTERES = 0;
                objMov1.INTERES_MORA = 0;
                objMov1.SALDO = 0;
                objMov1.HABER = objMov1.HABER + capital_pagado + interes_pagado;
                objMov1.ID_MEDIO_PAGO = obj.ID_MEDIO_PAGO;
                objMov1.PAGO_A_CTA = obj.PAGO_A_CTA + obj.MONTO_PAGADO;
                objMov1.ID_MEDIO_PAGO = obj.ID_MEDIO_PAGO;
                DAL.CTACTE_GASTOS.asientoPagoCtaMov1(objMov1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void asientaPagoCta(DAL.CTACTE_GASTOS obj,
            DateTime fechaPago, int nroRecibo)
        {
            try
            {

                decimal porc_pago = obj.MONTO_PAGADO / obj.SALDO;
                decimal capital_pagado = obj.SALDO_CAPITAL * porc_pago;
                decimal interes_pagado = obj.INTERES_MORA * porc_pago;
                decimal saldo_capital = obj.SALDO_CAPITAL - capital_pagado;
                decimal saldo_interes = obj.SALDO_INTERES - interes_pagado;

                DAL.CTACTE_GASTOS objMov2 = new DAL.CTACTE_GASTOS();
                objMov2.FECHA = fechaPago;
                objMov2.CAPITAL_PAGADO = capital_pagado;
                objMov2.HABER = obj.MONTO_PAGADO;
                objMov2.INTERES_MORA = obj.INTERES_MORA;
                objMov2.INTERES_PAGADO = interes_pagado;
                objMov2.ID_PROVEEDOR = obj.ID_PROVEEDOR;
                objMov2.NRO_RECIBO_PAGO = nroRecibo;
                objMov2.FACTURA = obj.FACTURA;
                objMov2.SALDO_CAPITAL = saldo_capital;
                objMov2.ID_MEDIO_PAGO = obj.ID_MEDIO_PAGO;
                objMov2.SALDO_INTERES = saldo_interes;
                objMov2.VENCIMIENTO = obj.VENCIMIENTO;
                objMov2.TIPO_MOVIMIENTO = 2;
                objMov2.NRO_CUOTA = obj.NRO_CUOTA;
                objMov2.NRO_PLAN_PAGO = obj.NRO_PLAN_PAGO;
                objMov2.ID_USUARIO_PAGA = obj.ID_USUARIO_PAGA;
                objMov2.PTO_VTA = obj.PTO_VTA;
                objMov2.NRO_CTE = obj.NRO_CTE;
                objMov2.ID_PLAN_CUENTA = obj.ID_PLAN_CUENTA;
                DAL.CTACTE_GASTOS.asientoPago(objMov2);

                DAL.CTACTE_GASTOS objMov1 = new DAL.CTACTE_GASTOS();
                objMov1.ID = obj.ID;
                obj.NRO_RECIBO_PAGO = nroRecibo;
                objMov1.PAGADO = false;
                objMov1.FECHA_ULTIMO_PAGO = fechaPago;
                objMov1.CAPITAL_PAGADO = obj.CAPITAL_PAGADO + capital_pagado;
                objMov1.INTERES_PAGADO = obj.INTERES_PAGADO + interes_pagado;
                objMov1.SALDO_CAPITAL = saldo_capital;
                objMov1.SALDO_INTERES = saldo_interes;
                objMov1.INTERES_MORA = 0;
                objMov1.HABER = obj.PAGO_A_CTA + obj.MONTO_PAGADO;
                objMov1.SALDO = saldo_capital + saldo_interes;
                objMov1.PAGO_A_CTA = obj.PAGO_A_CTA + obj.MONTO_PAGADO;
                objMov1.ID_MEDIO_PAGO = obj.ID_MEDIO_PAGO;
                DAL.CTACTE_GASTOS.asientoPagoCtaMov1(objMov1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}