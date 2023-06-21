﻿using LaHerradura.FEProd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaHerradura.AFIPHomo;
namespace LaHerradura
{
    public class NOTAS_CREDITO
    {
        public static void EmitoNotasCredito(List<DAL.CTACTE_EXPENSAS> lst,
            string path, string fecha)
        {
            try
            {
                foreach (var item in lst)
                {
                    DAL.LIQUIDACION_EXPENSAS objLiq =
                        DAL.LIQUIDACION_EXPENSAS.getByPk(item.PERIODO);
                    DAL.PERSONAS_X_INMUEBLES objP = DAL.PERSONAS_X_INMUEBLES.getByNroCta(
    item.NRO_CTA);
                    FEProd.CbteAsoc cbteAsoc = new FEProd.CbteAsoc();
                    cbteAsoc.Nro = item.NRO_CTE;
                    cbteAsoc.PtoVta = item.PTO_VTA;
                    cbteAsoc.Tipo = 11;
                    FECAEResponse cae = null;

                    cae = FE_AFIP.AutorizaCAENotaCredito_C(item.PTO_VTA, 2, 1,
                        Convert.ToInt64(objP.CUIT), Convert.ToInt64(
                            item.DESC_VENCIMIENTO), 13, path, cbteAsoc, fecha);

                    if (cae != null)
                    {
                        if (cae.FeDetResp[0].Resultado == "A")
                        {
                            DAL.FACTURAS_X_EXPENSA factu = new DAL.FACTURAS_X_EXPENSA();
                            factu.CAE = Convert.ToInt64(cae.FeDetResp[0].CAE);

                            factu.FECHA_CAE = new DateTime(int.Parse(cae.FeDetResp[0].CbteFch.Substring(0, 4)),
                                int.Parse(cae.FeDetResp[0].CbteFch.Substring(4, 2)),
                                int.Parse(cae.FeDetResp[0].CbteFch.Substring(6, 2)));
                            factu.ID_CTACTE = item.ID;
                            factu.NRO_CTA = item.NRO_CTA;
                            factu.NRO_CTE = cae.FeDetResp[0].CbteDesde;
                            factu.PERIODO = item.PERIODO;
                            factu.PTO_VTA = item.PTO_VTA;
                            factu.VENC_CAE = new DateTime(int.Parse(cae.FeDetResp[0].CAEFchVto.Substring(0, 4)),
                                int.Parse(cae.FeDetResp[0].CAEFchVto.Substring(4, 2)),
                                int.Parse(cae.FeDetResp[0].CAEFchVto.Substring(6, 2)));
                            factu.TIPO_COMPROBANTE = 13;
                            factu.MONTO = item.DESC_VENCIMIENTO;
                            string venc = string.Empty;
                            if (item.VENCIMIENTO.ToShortDateString() ==
                                objLiq.VENCIMIENTO_1.ToShortDateString())
                            {
                                venc = "Primer vencimiento";
                            }
                            if (item.VENCIMIENTO.ToShortDateString() ==
                                objLiq.VENCIMIENTO_2.ToShortDateString())
                            {
                                venc = "Segundo vencimiento";
                            }
                            factu.DETALLE = string.Format(
                                "Descuento pago en termino {0} expensa periodo {1}-{2}/{3} Factura {4}-{5}",
                                venc, item.PERIODO.ToString().Substring(0, 4),
                                item.PERIODO.ToString().Substring(4, 2),
                                item.PERIODO.ToString().Substring(6, 2),
                                item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));

                            factu.ID_COMPROBANTE = item.NRO_RECIBO_PAGO;
                            DAL.FACTURAS_X_EXPENSA.insert(factu);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void EmitoNotasCreditoNoMasiva(List<DAL.CTACTE_EXPENSAS> lst,
                    string path, string fecha, string descripcion, bool pagado)
        {
            try
            {
                foreach (var item in lst)
                {
                    DAL.PERSONAS_X_INMUEBLES objP = 
                        DAL.PERSONAS_X_INMUEBLES.getByNroCta(
                        item.NRO_CTA);

                    FECAEResponse cae = null;

                    if (item.PTO_VTA <= 2)
                    {
                        FEProd.CbteAsoc cbteAsoc = new FEProd.CbteAsoc();
                        cbteAsoc.Nro = item.NRO_CTE;
                        cbteAsoc.PtoVta = item.PTO_VTA;
                        cbteAsoc.Tipo = 11;


                        cae = FE_AFIP.AutorizaCAENotaCredito_C(item.PTO_VTA, 2, 1,
                            Convert.ToInt64(objP.CUIT), Convert.ToInt64(
                                item.DESCUENTO), 13, path, cbteAsoc, fecha);
                    }
                    else
                        cae = FE_AFIP.AutorizaCAENotaCredito_C(item.PTO_VTA, 2, 1,
        Convert.ToInt64(objP.CUIT), Convert.ToInt64(
            item.DESCUENTO), 13, path, null, fecha);

                    if (cae != null)
                    {
                        if (cae.FeDetResp[0].Resultado == "A")
                        {
                            DAL.FACTURAS_X_EXPENSA factu = new
                                DAL.FACTURAS_X_EXPENSA();
                            factu.CAE = Convert.ToInt64(cae.FeDetResp[0].CAE);

                            factu.FECHA_CAE = new DateTime(int.Parse(
                                cae.FeDetResp[0].CbteFch.Substring(0, 4)),
                                int.Parse(cae.FeDetResp[0].CbteFch.Substring(4, 2)),
                                int.Parse(cae.FeDetResp[0].CbteFch.Substring(6, 2)));
                            factu.ID_CTACTE = item.ID;
                            factu.NRO_CTA = item.NRO_CTA;
                            factu.NRO_CTE = cae.FeDetResp[0].CbteDesde;
                            factu.PERIODO = item.PERIODO;
                            factu.PTO_VTA = 2;
                            factu.VENC_CAE = new DateTime(int.Parse(
                                cae.FeDetResp[0].CAEFchVto.Substring(0, 4)),
                                int.Parse(cae.FeDetResp[0].CAEFchVto.Substring(4, 2)),
                                int.Parse(cae.FeDetResp[0].CAEFchVto.Substring(6, 2)));
                            factu.TIPO_COMPROBANTE = 13;
                            factu.MONTO = item.DESCUENTO;

                            factu.DETALLE = string.Format(
                                "{0} - Expensa periodo {1}-{2}/{3} Factura {4}-{5}",
                                descripcion, item.PERIODO.ToString().Substring(0, 4),
                                item.PERIODO.ToString().Substring(4, 2),
                                item.PERIODO.ToString().Substring(6, 2),
                                item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));

                            factu.ID_COMPROBANTE = item.NRO_RECIBO_PAGO;
                            DAL.FACTURAS_X_EXPENSA.insert(factu);
                            DAL.CTACTE_EXPENSAS.DescuentoNCFiscal(
                                item.ID, item.DESCUENTO, pagado);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void EmitoNotasCreditoInterna(int nroCta,
            string path, string fecha, string detalle, decimal monto,
            int idUsuario)
        {
            try
            {
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                int PtoVta = 31;
                DAL.CUENTA_COMBO objProp = DAL.CUENTA_COMBO.getByNroCta(nroCta);

                DAL.FACTURAS_X_EXPENSA obj = new DAL.FACTURAS_X_EXPENSA();
                obj.PTO_VTA = PtoVta;
                obj.CUIT = objProp.CUIT;
                obj.DETALLE = detalle;

                obj.MONTO = monto;
                obj.NOMBRE = objProp.PROPIETARIO;
                obj.NRO_CTA = nroCta;
                obj.PAGADO = false;
                obj.TIPO_COMPROBANTE = 31;

                obj.PERIODO = int.Parse(string.Format("{0}{1}31",
                    fec.Year,
                    fec.Month.ToString().PadLeft(
                        2, Convert.ToChar("0"))));

                while (DAL.CTACTE_EXPENSAS.getByPeriodo2(obj.PERIODO,
                    obj.NRO_CTA))
                    obj.PERIODO = obj.PERIODO + 1;

                int idCta = BLL.CTACTE_EXPENSAS.factura(obj, idUsuario, 31);
                obj.ID_CTACTE = idCta;


                obj.CAE = 11111111111;

                obj.NRO_CTE = DAL.FACTURAS_X_EXPENSA.getMaxNotaCreditoInterna() + 1;
                obj.FECHA_CAE = fec;

                obj.VENC_CAE = fec;
                DAL.FACTURAS_X_EXPENSA factu = new
                    DAL.FACTURAS_X_EXPENSA();
                factu.CUIT = obj.CUIT;
                factu.NOMBRE = obj.NOMBRE;
                factu.CAE = obj.CAE;
                factu.FECHA_CAE = obj.FECHA_CAE;
                factu.ID_CTACTE = idCta;
                factu.NRO_CTA = obj.NRO_CTA;
                factu.NRO_CTE = obj.NRO_CTE;
                factu.PERIODO = obj.PERIODO;
                factu.PTO_VTA = obj.PTO_VTA;
                factu.VENC_CAE = obj.VENC_CAE;
                factu.TIPO_COMPROBANTE = 21;
                factu.MONTO = obj.MONTO;

                factu.DETALLE = obj.DETALLE;
                DAL.FACTURAS_X_EXPENSA.insert(factu);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}