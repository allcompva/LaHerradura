﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Secure
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            int desde = 7777;//int.Parse(txtCompDesde.Text);
            int hasta = 7786;//int.Parse(txtCompHasta.Text);


            //for (int i = desde; i < hasta; i++)
            //{
            FEProd.FECompConsultaResponse comprobante =
        AFIPHomo.FE_AFIP.ConsultaComprobante(int.Parse(DDLTipoComp.SelectedItem.Value), 2,
            int.Parse(txtNroComprobante.Text), Server.MapPath("certificado.pfx"));
            //    FEProd.FECompConsultaResponse comprobante =
            //AFIPHomo.FE_AFIP.ConsultaComprobante(11, 2,
            //    desde, Server.MapPath("certificado.pfx"));
            StringBuilder html = new StringBuilder();
            if (comprobante.ResultGet != null)
            {
                //        DAL.CTACTE_EXPENSAS obj = DAL.CTACTE_EXPENSAS.read(20221200, comprobante.ResultGet.DocNro.ToString());
                //        obj.CAE = Convert.ToInt64(comprobante.ResultGet.CodAutorizacion);
                //        obj.NRO_CTE = comprobante.ResultGet.CbteDesde;
                //        obj.PTO_VTA = comprobante.ResultGet.PtoVta;

                //        int anio = Convert.ToInt32(comprobante.ResultGet.CbteFch.Substring(0, 4));
                //        int mes = Convert.ToInt32(comprobante.ResultGet.CbteFch.Substring(4, 2));
                //        int dia = Convert.ToInt32(comprobante.ResultGet.CbteFch.Substring(6, 2));
                //        obj.FECHA_CAE = new DateTime(anio, mes, dia);
                //        anio = Convert.ToInt32(comprobante.ResultGet.FchVto.Substring(0, 4));
                //        mes = Convert.ToInt32(comprobante.ResultGet.FchVto.Substring(4, 2));
                //        dia = Convert.ToInt32(comprobante.ResultGet.FchVto.Substring(6, 2));
                //        obj.VENC_CAE = new DateTime(anio, mes, dia);

                DAL.LIQUIDACION_EXPENSAS objLiq = DAL.LIQUIDACION_EXPENSAS.getByPk(20221100);
                TimeSpan diasMora2 = objLiq.VENCIMIENTO_2 - objLiq.VENCIMIENTO_1;
                TimeSpan diasMora3 = objLiq.VENCIMIENTO_3 - objLiq.VENCIMIENTO_1;

                //        string codBarra = LaHerradura.RapiPago.CodigoBarra.getCodigoBarra(
                //            obj.NRO_CTA,
                //            obj.PTO_VTA,
                //            obj.NRO_CTE,
                //            obj.MONTO_ORIGINAL - objLiq.MONTO_3 + objLiq.MONTO_1,
                //            objLiq.VENCIMIENTO_1,
                //            objLiq.MONTO_2 - objLiq.MONTO_1,
                //            diasMora2.Days,
                //            objLiq.MONTO_3 - objLiq.MONTO_1,
                //            diasMora3.Days);

                //        obj.COD_BARRA_RAPIPAGO = codBarra;

                //        DAL.FACTURAS_X_EXPENSA factu = new DAL.FACTURAS_X_EXPENSA();
                //        factu.CAE = obj.CAE;
                //        factu.FECHA_CAE = obj.FECHA_CAE;
                //        factu.ID_CTACTE = obj.ID;
                //        factu.NRO_CTA = obj.NRO_CTA;
                //        factu.NRO_CTE = obj.NRO_CTE;
                //        factu.PERIODO = obj.PERIODO;
                //        factu.PTO_VTA = obj.PTO_VTA;
                //        factu.VENC_CAE = obj.VENC_CAE;
                //        factu.TIPO_COMPROBANTE = 11;
                //        factu.MONTO = obj.MONTO_ORIGINAL;
                //        string me = string.Empty;
                //        switch (mes)
                //        {
                //            case 1:
                //                me = "Enero";
                //                break;
                //            case 2:
                //                me = "Febrero";
                //                break;
                //            case 3:
                //                me = "Marzo";
                //                break;
                //            case 4:
                //                me = "Abril";
                //                break;
                //            case 5:
                //                me = "Mayo";
                //                break;
                //            case 6:
                //                me = "Junio";
                //                break;
                //            case 7:
                //                me = "Julio";
                //                break;
                //            case 8:
                //                me = "Agosto";
                //                break;
                //            case 9:
                //                me = "Septiembre";
                //                break;
                //            case 10:
                //                me = "Octubre";
                //                break;
                //            case 11:
                //                me = "Noviembre";
                //                break;
                //            case 12:
                //                me = "Diciembre";
                //                break;

                //            default:
                //                break;
                //        }
                //        factu.DETALLE = string.Format("Expensas ordinarias mes de {0} de {1}",
                //            me, anio);
                //        using (TransactionScope scope = new TransactionScope())
                //        {
                //            DAL.LIQUIDACION_EXPENSAS.updateLiquida(20221200, 2);
                //            DAL.CTACTE_EXPENSAS.setAFIP(obj);
                //            DAL.FACTURAS_X_EXPENSA.insert(factu);
                //            scope.Complete();
                //        }

                html.AppendLine(string.Format("Comprobante nro: {0}-{1}<br>",
                comprobante.ResultGet.PtoVta.ToString().PadLeft(4, Convert.ToChar("0")),
                comprobante.ResultGet.CbteDesde.ToString().PadLeft(8, Convert.ToChar("0"))));
                html.AppendLine(string.Format("CAE: {0}<br>", comprobante.ResultGet.CodAutorizacion));
                html.AppendLine(string.Format("Monto: {0:c}<br>", comprobante.ResultGet.ImpTotal));
                html.AppendLine(string.Format("Fecha: {0}<br>", comprobante.ResultGet.CbteFch));
                if (int.Parse(DDLTipoComp.SelectedItem.Value) != 11)
                    html.AppendLine(string.Format("Comprobante asociado: {0}-{1}<br>",
                        comprobante.ResultGet.CbtesAsoc[0].PtoVta.ToString().PadLeft(4, Convert.ToChar("0")),
                        comprobante.ResultGet.CbtesAsoc[0].Nro.ToString().PadLeft(8, Convert.ToChar("0"))));
                html.AppendLine(string.Format("Fecha: {0}<br>", comprobante.ResultGet.DocNro));

                DAL.FACTURAS_X_EXPENSA factu = new DAL.FACTURAS_X_EXPENSA();
                factu.CAE = Convert.ToInt64(comprobante.ResultGet.CodAutorizacion);

                factu.FECHA_CAE = new DateTime(int.Parse(comprobante.ResultGet.CbteFch.Substring(0, 4)),
                    int.Parse(comprobante.ResultGet.CbteFch.Substring(4, 2)),
                    int.Parse(comprobante.ResultGet.CbteFch.Substring(6, 2)));

                DAL.CTACTE_EXPENSAS item = DAL.CTACTE_EXPENSAS.Read_NC_aEmitirManual(2, 7660)[0];
                factu.ID_CTACTE = item.ID;
                factu.NRO_CTA = item.NRO_CTA;
                factu.NRO_CTE = comprobante.ResultGet.CbteDesde;
                factu.PERIODO = item.PERIODO;
                factu.PTO_VTA = item.PTO_VTA;
                factu.VENC_CAE = new DateTime(int.Parse(comprobante.ResultGet.FchVto.Substring(0, 4)),
                    int.Parse(comprobante.ResultGet.FchVto.Substring(4, 2)),
                    int.Parse(comprobante.ResultGet.FchVto.Substring(6, 2)));
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
            else
            {
                html.AppendLine("El comprobante consultado no existe");
            }
            desde++;
            //}
            divComprobante.InnerHtml = html.ToString();
        }

        protected void btnInsertarFacturas_Click(object sender, EventArgs e)
        {
            try
            {
                //            FEProd.FECompConsultaResponse comprobante =
                //        AFIPHomo.FE_AFIP.ConsultaComprobante(int.Parse(DDLTipoComp.SelectedItem.Value), 2,
                //            int.Parse(txtNroComprobante.Text), Server.MapPath("certificado.pfx"));
                //            StringBuilder html = new StringBuilder();
                //            if (comprobante.ResultGet != null)
                //            {
                //                DAL.FACTURAS_X_EXPENSA factu = new
                //DAL.FACTURAS_X_EXPENSA();
                //                factu.CUIT = "30709450952";
                //                factu.NOMBRE = "Aledjo S.A";
                //                factu.CAE = Int64.Parse(comprobante.ResultGet.CodAutorizacion);
                //                factu.FECHA_CAE = Convert.ToDateTime("02/02/2021");
                //                factu.ID_CTACTE = 0;
                //                factu.NRO_CTA = 0;
                //                factu.NRO_CTE = comprobante.ResultGet.CbteDesde;
                //                factu.PERIODO = 0;
                //                factu.PTO_VTA = comprobante.ResultGet.PtoVta;
                //                factu.VENC_CAE = Convert.ToDateTime("02/02/2021");
                //                factu.TIPO_COMPROBANTE = 11;
                //                factu.MONTO = Convert.ToDecimal(comprobante.ResultGet.ImpTotal);

                //                factu.DETALLE = "Caño usado de aluminio ex barreras de ingreso.";

                //                DAL.FACTURAS_X_EXPENSA.insert(factu);

                //                Response.Redirect("Facturacion.aspx");

                //                html.AppendLine(string.Format("Comprobante nro: {0}-{1}<br>",
                //                    comprobante.ResultGet.PtoVta.ToString().PadLeft(4, Convert.ToChar("0")),
                //                    comprobante.ResultGet.CbteDesde.ToString().PadLeft(8, Convert.ToChar("0"))));
                //                html.AppendLine(string.Format("CAE: {0}<br>", comprobante.ResultGet.CodAutorizacion));
                //                html.AppendLine(string.Format("Monto: {0:c}<br>", comprobante.ResultGet.ImpTotal));
                //                html.AppendLine(string.Format("Fecha: {0}<br>", comprobante.ResultGet.CbteFch));
                //                if (int.Parse(DDLTipoComp.SelectedItem.Value) != 11)
                //                    html.AppendLine(string.Format("Comprobante asociado: {0}-{1}<br>",
                //                        comprobante.ResultGet.CbtesAsoc[0].PtoVta.ToString().PadLeft(4, Convert.ToChar("0")),
                //                        comprobante.ResultGet.CbtesAsoc[0].Nro.ToString().PadLeft(8, Convert.ToChar("0"))));
                //                html.AppendLine(string.Format("Fecha: {0}<br>", comprobante.ResultGet.DocNro));

                //            }



                //int desde = int.Parse(txtCompDesde.Text);
                //int hasta = int.Parse(txtCompHasta.Text);


                //for (int i = desde; i < hasta; i++)
                //{
                //    FEProd.FECompConsultaResponse comprobante =
                //        AFIPHomo.FE_AFIP.ConsultaComprobante(int.Parse(DDLTipoComp.SelectedItem.Value), 2,
                //        i, Server.MapPath("certificado.pfx"));

                //    DAL.FACTURAS_A_INSERTAR obj = new DAL.FACTURAS_A_INSERTAR();
                //    obj.CAE = comprobante.ResultGet.CodAutorizacion;
                //    obj.CUIT = comprobante.ResultGet.DocNro.ToString();
                //    obj.FECHA_CAE = Convert.ToDateTime("31/12/2020");
                //    obj.MONTO = Convert.ToDecimal(comprobante.ResultGet.ImpTotal);
                //    obj.NRO_CTE = Convert.ToInt32(comprobante.ResultGet.CbteDesde);
                //    obj.PTO_VTA = 2;
                //    obj.VENC_CAE = obj.FECHA_CAE;
                //    DAL.FACTURAS_A_INSERTAR.insert(obj);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //List<DAL.FACTURAS_A_INSERTAR> lst = DAL.FACTURAS_A_INSERTAR.read();
            //foreach (var item in lst)
            //{
            //    DAL.CTACTE_EXPENSAS obj = DAL.CTACTE_EXPENSAS.getByPk(item.ID);
            //    obj.CAE = Convert.ToInt64(item.CAE);
            //    obj.NRO_CTE = item.NRO_CTE;
            //    obj.PTO_VTA = item.PTO_VTA;

            //    obj.FECHA_CAE = item.FECHA_CAE;

            //    obj.VENC_CAE = item.VENC_CAE;

            //    DAL.LIQUIDACION_EXPENSAS objLiq = DAL.LIQUIDACION_EXPENSAS.getByPk(obj.PERIODO);
            //    TimeSpan diasMora2 = objLiq.VENCIMIENTO_2 - objLiq.VENCIMIENTO_1;
            //    TimeSpan diasMora3 = objLiq.VENCIMIENTO_3 - objLiq.VENCIMIENTO_1;

            //    string codBarra = LaHerradura.RapiPago.CodigoBarra.getCodigoBarra(
            //        obj.NRO_CTA,
            //        obj.PTO_VTA,
            //        obj.NRO_CTE,
            //        obj.MONTO_ORIGINAL - objLiq.MONTO_3 + objLiq.MONTO_1,
            //        objLiq.VENCIMIENTO_1,
            //        objLiq.MONTO_2 - objLiq.MONTO_1,
            //        diasMora2.Days,
            //        objLiq.MONTO_3 - objLiq.MONTO_1,
            //        diasMora3.Days);

            //    obj.COD_BARRA_RAPIPAGO = codBarra;

            //    DAL.FACTURAS_X_EXPENSA factu = new DAL.FACTURAS_X_EXPENSA();
            //    factu.CAE = obj.CAE;
            //    factu.FECHA_CAE = obj.FECHA_CAE;
            //    factu.ID_CTACTE = obj.ID;
            //    factu.NRO_CTA = obj.NRO_CTA;
            //    factu.NRO_CTE = obj.NRO_CTE;
            //    factu.PERIODO = obj.PERIODO;
            //    factu.PTO_VTA = obj.PTO_VTA;
            //    factu.VENC_CAE = obj.VENC_CAE;
            //    factu.TIPO_COMPROBANTE = 11;
            //    factu.MONTO = obj.MONTO_ORIGINAL;
            //    string me = string.Empty;
            //    switch (item.FECHA_CAE.Month)
            //    {
            //        case 1:
            //            me = "Enero";
            //            break;
            //        case 2:
            //            me = "Febrero";
            //            break;
            //        case 3:
            //            me = "Marzo";
            //            break;
            //        case 4:
            //            me = "Abril";
            //            break;
            //        case 5:
            //            me = "Mayo";
            //            break;
            //        case 6:
            //            me = "Junio";
            //            break;
            //        case 7:
            //            me = "Julio";
            //            break;
            //        case 8:
            //            me = "Agosto";
            //            break;
            //        case 9:
            //            me = "Septiembre";
            //            break;
            //        case 10:
            //            me = "Octubre";
            //            break;
            //        case 11:
            //            me = "Noviembre";
            //            break;
            //        case 12:
            //            me = "Diciembre";
            //            break;

            //        default:
            //            break;
            //    }
            //    factu.DETALLE = string.Format("Expensas ordinarias mes de Enero de 2021",
            //        me, item.FECHA_CAE.Year);
            //    using (TransactionScope scope = new TransactionScope())
            //    {
            //        DAL.LIQUIDACION_EXPENSAS.updateLiquida(obj.PERIODO, 2);
            //        DAL.CTACTE_EXPENSAS.setAFIP(obj);
            //        DAL.FACTURAS_X_EXPENSA.insert(factu);
            //        scope.Complete();
            //    }
            //}
        }
    }
}