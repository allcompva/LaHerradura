using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace LaHerradura.Back.Reportes
{
    public partial class ordenPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ShowPdf(CreatePDF2());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShowPdf(byte[] strS)
        {
            int nroOP = Convert.ToInt32(Request.QueryString["nroOP"]);

            List<DAL.FACTURAS_X_OP> lstFOP = DAL.FACTURAS_X_OP.getByOrdenPago(nroOP);
            List<DAL.CTACTE_GASTOS> lstCta = new List<DAL.CTACTE_GASTOS>();
            foreach (var item in lstFOP)
            {
                DAL.CTACTE_GASTOS obj = DAL.CTACTE_GASTOS.getByPk(item.ID_FACTURA);
                lstCta.Add(obj);
            }

            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "Inline; filename=" +
                "Orden_Pago_proveedor_" + lstCta[0].ID_PROVEEDOR + ".pdf");

            Response.BinaryWrite(strS);
            Response.End();
            Response.Flush();
            Response.Clear();
        }
        private byte[] CreatePDF2()
        {
            Document doc = new Document(PageSize.LETTER, 30, 30, 30, 30);
            int nroOP = Convert.ToInt32(Request.QueryString["nroOP"]);
            DAL.ORDENES_PAGO objOP = DAL.ORDENES_PAGO.getByPk(nroOP);
            List<DAL.FACTURAS_X_OP> lstFOP = DAL.FACTURAS_X_OP.getByOrdenPago(nroOP);
            List<DAL.CTACTE_GASTOS> lstCta = new List<DAL.CTACTE_GASTOS>();
            List<int> lstRecibos = new List<int>();
            foreach (var item in lstFOP)
            {
                DAL.CTACTE_GASTOS obj = DAL.CTACTE_GASTOS.getByPk(item.ID_FACTURA);
                lstCta.Add(obj);

                List<DAL.CTACTE_GASTOS> lstCtaPago =
DAL.CTACTE_GASTOS.readDeuda(obj.ID_PROVEEDOR, obj.PTO_VTA, obj.NRO_CTE).FindAll(
    o => o.TIPO_MOVIMIENTO == 2);
                lstRecibos.AddRange(
    lstCtaPago.Select(r => r.NRO_RECIBO_PAGO).Distinct().ToList());
            }

            lstRecibos = lstRecibos.Distinct().ToList();

            DAL.PROVEEDORES objPer =
                DAL.PROVEEDORES.getByPk(lstCta[0].ID_PROVEEDOR);

            string cuitper = string.Empty;

            Paragraph salto = new Paragraph();

            salto.SpacingAfter = 10;
            using (MemoryStream output = new MemoryStream())
            {
                List<DAL.CTACTE_GASTOS> lstCtaPagos =
                    lstCta.FindAll(c => c.TIPO_MOVIMIENTO == 2).OrderBy(l => l.NRO_RECIBO_PAGO).ToList();

                PdfWriter wri = PdfWriter.GetInstance(doc, output);
                doc.Open();
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 8,
                    iTextSharp.text.Font.NORMAL, Color.BLACK);
                iTextSharp.text.Font _encabezado = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12,
                    iTextSharp.text.Font.BOLD, Color.BLACK);
                iTextSharp.text.Font _standardFont2 = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 10,
                    iTextSharp.text.Font.NORMAL, Color.BLACK);
                /**/
                //Image png = Image.GetInstance(Server.MapPath("../../img/" + "logoPlan.png"));
                //Image png = Image.GetInstance("https://aclaherradura.com.ar/img/" + "logoPlan.png");
                Image png = Image.GetInstance(Server.MapPath("../../img/" + "logoPlan.png"));
                #region ENCABEZADO
                //ENCABEZADO
                PdfPTable tblEncabezado = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };
                PdfPCell clLogo = new PdfPCell()
                {
                    Image = png,
                    BorderWidth = 0,
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f
                };

                tblEncabezado.AddCell(clLogo);

                PdfPCell clDatos = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f
                };

                clDatos.AddElement(new Phrase("Orden de pago", _encabezado));

                clDatos.AddElement(salto);

                clDatos.AddElement(new Phrase(
                    string.Format("Nro: {0}-{1}",
                    objOP.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                    objOP.NRO.ToString().PadLeft(8, Convert.ToChar("0"))), _encabezado));
                clDatos.AddElement(salto);
                clDatos.AddElement(new Phrase(string.Format("Fecha: {0}", objOP.FECHA.ToShortDateString()
                    , _standardFont)));

                clDatos.AddElement(salto);


                tblEncabezado.AddCell(clDatos);

                doc.Add(tblEncabezado);
                #endregion
                #region PROPIETARIO
                //PROPIETARIO - CUENTA
                PdfPTable tblPrpietario = new PdfPTable(2)
                {
                    WidthPercentage = 100

                };
                PdfPCell clProp = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    PaddingLeft = 10
                };

                clProp.AddElement(new Phrase(string.Format(
                    "Proveedor: {0}",
                    objPer.NOMBRE_FANTASIA), _standardFont));
                clProp.AddElement(salto);
                clProp.AddElement(new Phrase(string.Format("Razón Social: {0}",
                    objPer.RAZON_SOCIAL), _standardFont));
                clProp.AddElement(salto);
                DAL.TB_CONDICION_IVA objIva = DAL.TB_CONDICION_IVA.getByPk(
                    objPer.COND_IVA);
                clProp.AddElement(new Phrase(string.Format(
                    "Condición ante I.V.A.: {0}", objIva.DESCRIPCION), _standardFont));

                clProp.AddElement(salto);

                PdfPCell clCta = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f
                };
                clCta.AddElement(new Phrase(string.Format("C.U.I.T.: {0}-{1}-{2}",
                    objPer.CUIT.Substring(0, 2), objPer.CUIT.Substring(2, 8),
                    objPer.CUIT.Substring(10, 1)), _standardFont));
                clCta.AddElement(salto);


                tblPrpietario.AddCell(clProp);
                tblPrpietario.AddCell(clCta);
                doc.Add(tblPrpietario);
                #endregion

                //DETALLE FACTURA



                PdfPTable tbLiquidacion = new PdfPTable(1)
                {
                    WidthPercentage = 100,

                };
                //tbLiquidacion.SetWidths(new float[] { 45, 55 });
                //PdfPCell clTexto = new PdfPCell()
                //{
                //    BorderWidth = 0,
                //    BorderWidthLeft = 1f,
                //    Padding = 20
                //};
                //clTexto.AddElement(new Paragraph(
                //        "Recibimos la suma de $ " +
                //        lstPagos.Sum(p => p.MONTO)
                //        , _standardFont2));
                //clTexto.AddElement(new Paragraph(
                //    "En concepto de cancelación total/parcial de comprobantes descriptos en tabla de liquidación",
                //    _standardFont2));
                PdfPCell clLiquidacion = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthRight = 1f,
                    BorderWidthLeft = 1f,
                    Padding = 10,
                };
                PdfPTable tblDetalle = new PdfPTable(3)
                {
                    WidthPercentage = 100,

                };
                //tbLiquidacion.AddCell(clTexto);
                PdfPTable tblTitDetalle = new PdfPTable(1)
                {
                    WidthPercentage = 100,

                };
                PdfPCell clDetTitulo = new PdfPCell(new Paragraph("Detalle de comprobantes aplicados", _encabezado))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    PaddingBottom = 10,
                    PaddingTop = 10
                };
                tblTitDetalle.AddCell(clDetTitulo);
                clLiquidacion.AddElement(tblTitDetalle);

                tblDetalle.SetWidths(new float[] { 25, 50, 25 });
                PdfPCell clCod = new PdfPCell(new Paragraph("Fecha", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                    BackgroundColor = Color.LIGHT_GRAY
                };
                PdfPCell clConcepto = new PdfPCell(new Paragraph("Comprobante", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                    BackgroundColor = Color.LIGHT_GRAY
                };
                PdfPCell clCantidad = new PdfPCell(new Paragraph("Importe", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                    BackgroundColor = Color.LIGHT_GRAY
                };
                tblDetalle.AddCell(clCod);
                tblDetalle.AddCell(clConcepto);
                tblDetalle.AddCell(clCantidad);
                //           List<DAL.CTACTE_GASTOS> lst =
                //DAL.CTACTE_GASTOS.getByRecibo(nroRecibo);

                foreach (var item in lstCta)
                {
                    PdfPCell clCodd = new PdfPCell(new Paragraph(
                        item.FECHA.ToShortDateString(), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10
                    };
                    PdfPCell clConceptod = new PdfPCell(new Paragraph(
                        string.Format("{0}",
                        item.FACTURA), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        BorderWidthRight = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10,
                    };
                    PdfPCell clCantidadd = new PdfPCell(new Paragraph(
                        string.Format("{0:c}",
                        item.DEBE), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        BorderWidthRight = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10
                    };

                    tblDetalle.AddCell(clCodd);
                    tblDetalle.AddCell(clConceptod);
                    tblDetalle.AddCell(clCantidadd);

                }

                PdfPCell clCoddT = new PdfPCell(new Paragraph(
                        "TOTAL", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10
                };
                PdfPCell clConceptodT = new PdfPCell(new Paragraph(
                    ""))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                };
                PdfPCell clCantidaddT = new PdfPCell(new Paragraph(
                    string.Format("{0:c}",
                    lstCta.Sum(c => c.DEBE)), _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10
                };



                tblDetalle.AddCell(clCoddT);
                tblDetalle.AddCell(clConceptodT);
                tblDetalle.AddCell(clCantidaddT);

                clLiquidacion.AddElement(tblDetalle);
                tbLiquidacion.AddCell(clLiquidacion);
                doc.Add(tbLiquidacion);

                PdfPTable tblTitPagos = new PdfPTable(1)
                {
                    WidthPercentage = 100,

                };
                PdfPCell clPagosTitulo = new PdfPCell(new Paragraph("Detalle de medios de pago", _encabezado))
                {
                    BorderWidth = 0,
                    PaddingLeft = 20,
                    PaddingBottom = 5,
                    PaddingTop = 5,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 1f
                };
                tblTitPagos.AddCell(clPagosTitulo);
                doc.Add(tblTitPagos);
                decimal totGral = 0;
                foreach (var item in lstRecibos)
                {
                    PdfPTable tblDetallePagos1 = new PdfPTable(1)
                    {
                        WidthPercentage = 100,

                    };
                    PdfPCell clDetPago1 = new PdfPCell(new Paragraph("", _encabezado))
                    {
                        BorderWidth = 0,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 1f,
                        Padding = 20
                    };


                    List<DAL.PAGOS_X_FACTURA_GASTOS> lstPagos =
        DAL.PAGOS_X_FACTURA_GASTOS.read(item);

                    PdfPTable tblSubTitPagos = new PdfPTable(1)
                    {
                        WidthPercentage = 100,

                    };
                    PdfPCell clPagosSubTitulo = new PdfPCell(
                        new Paragraph(string.Format(
                            "Fecha: {0}",
                            lstPagos[0].FECHA.ToShortDateString()), _standardFont2))
                    {
                        BorderWidth = 0,
                        PaddingLeft = 20,
                        PaddingBottom = 5,
                        PaddingTop = 5,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 1f,
                    };
                    tblSubTitPagos.AddCell(clPagosSubTitulo);
                    doc.Add(tblSubTitPagos);

                    decimal tot = 0;
                    foreach (var item2 in lstPagos)
                    {
                        PdfPTable tblDetallePagos = new PdfPTable(4)
                        {
                            WidthPercentage = 100
                        };
                        tblDetallePagos.SetWidths(new float[] { 40, 20, 20, 20 });
                        PdfPCell clMedioPago = new
                            PdfPCell(new Paragraph(item2.MEDIO_PAGO.ToString(),
                            _standardFont))
                        {
                            BorderWidth = 0,
                            PaddingLeft = 20,
                            PaddingBottom = 5,
                            PaddingTop = 5,
                            BorderWidthLeft = 1f
                        };
                        PdfPCell clCheque = new PdfPCell(new Paragraph(string.Format("{0:c}",
                            item2.NRO_CHEQUE), _standardFont))
                        {
                            BorderWidth = 0,
                            PaddingLeft = 20,
                            PaddingBottom = 5,
                            PaddingTop = 5
                        };
                        PdfPCell clBanco = new PdfPCell(new Paragraph(string.Format("{0:c}",
                            item2.BANCO), _standardFont))
                        {
                            BorderWidth = 0,
                            PaddingLeft = 20,
                            PaddingBottom = 5,
                            PaddingTop = 5
                        };
                        PdfPCell clMonto = new PdfPCell(new Paragraph(string.Format("{0:c}",
                            item2.MONTO), _standardFont))
                        {
                            BorderWidth = 0,
                            PaddingLeft = 20,
                            PaddingBottom = 5,
                            PaddingTop = 5,
                            BorderWidthRight = 1f
                        };
                        tblDetallePagos.AddCell(clMedioPago);
                        tblDetallePagos.AddCell(clBanco);
                        tblDetallePagos.AddCell(clCheque);
                        tblDetallePagos.AddCell(clMonto);
                        clDetPago1.AddElement(tblDetallePagos);
                        tblDetallePagos.AddCell(clDetPago1);
                        doc.Add(tblDetallePagos);

                        tot += item2.MONTO;
                        totGral += item2.MONTO;
                    }

                    PdfPCell clMedioPagoTo = new PdfPCell(new Paragraph(
                            "Sub total", _standardFont2))
                    {
                        BorderWidth = 0,
                        BorderWidthTop = 0,
                        BorderWidthLeft = 1f,
                        PaddingLeft = 20,
                        PaddingBottom = 15,
                        PaddingTop = 5
                    };
                    PdfPCell clChequeTo = new PdfPCell(new Paragraph(
                        "", _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthTop = 0,
                        PaddingLeft = 20,
                        PaddingBottom = 15,
                        PaddingTop = 5
                    };
                    PdfPCell clBancoTo = new PdfPCell(new Paragraph(
                        "", _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthTop = 0,
                        PaddingLeft = 20,
                        PaddingBottom = 15,
                        PaddingTop = 5
                    };

                    //PdfPCell clMontoT = new PdfPCell(new Paragraph(string.Format("{0:c}",
                    //    lstPagos.Sum(p => p.MONTO)), _standardFont))
                    PdfPCell clMontoTo = new PdfPCell(new Paragraph(string.Format("{0:c}",
                        tot), _standardFont2))
                    {
                        BorderWidth = 0,
                        BorderWidthTop = 0,
                        BorderWidthRight = 1f,
                        PaddingLeft = 20,
                        PaddingBottom = 15,
                        PaddingTop = 5
                    };
                    PdfPTable tblDetallePagosTo = new PdfPTable(4)
                    {
                        WidthPercentage = 100
                    };
                    tblDetallePagosTo.SetWidths(new float[] { 40, 20, 20, 20 });

                    tblDetallePagosTo.AddCell(clMedioPagoTo);
                    tblDetallePagosTo.AddCell(clChequeTo);
                    tblDetallePagosTo.AddCell(clBancoTo);
                    tblDetallePagosTo.AddCell(clMontoTo);
                    doc.Add(tblDetallePagosTo);
                }

                PdfPCell clMedioPagoT = new PdfPCell(new Paragraph(
                            "TOTAL", _standardFont2))
                {
                    BorderWidth = 0,
                    BorderWidthTop = 0,
                    BorderWidthLeft = 1f,
                    PaddingLeft = 20,
                    PaddingBottom = 5,
                    PaddingTop = 20
                };
                PdfPCell clChequeT = new PdfPCell(new Paragraph(
                    "", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthTop = 0,
                    PaddingLeft = 20,
                    PaddingBottom = 5,
                    PaddingTop = 20
                };
                PdfPCell clBancoT = new PdfPCell(new Paragraph(
                    "", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthTop = 0,
                    PaddingLeft = 20,
                    PaddingBottom = 5,
                    PaddingTop = 20
                };

                //PdfPCell clMontoT = new PdfPCell(new Paragraph(string.Format("{0:c}",
                //    lstPagos.Sum(p => p.MONTO)), _standardFont))
                PdfPCell clMontoT = new PdfPCell(new Paragraph(string.Format("{0:c}",
                    totGral), _encabezado))
                {
                    BorderWidth = 0,
                    BorderWidthTop = 0,
                    BorderWidthRight = 1f,
                    PaddingLeft = 20,
                    PaddingBottom = 5,
                    PaddingTop = 20
                };
                PdfPTable tblDetallePagosT = new PdfPTable(4)
                {
                    WidthPercentage = 100
                };
                tblDetallePagosT.SetWidths(new float[] { 40, 20, 20, 20 });

                tblDetallePagosT.AddCell(clMedioPagoT);
                tblDetallePagosT.AddCell(clChequeT);
                tblDetallePagosT.AddCell(clBancoT);
                tblDetallePagosT.AddCell(clMontoT);
                doc.Add(tblDetallePagosT);

                decimal debe = lstCta.Sum(c => c.DEBE);
                decimal saldo = debe - totGral;
                PdfPCell clMedioPagoS;
                if (saldo < 0)
                {
                    clMedioPagoS = new PdfPCell(new Paragraph(
                            "SALDO A FAVOR DE LA HERRADURA", _standardFont2))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        BorderWidthTop = 0,
                        BorderWidthLeft = 1f,
                        PaddingLeft = 20,
                        PaddingBottom = 15,
                        PaddingTop = 20
                    };
                    saldo = saldo * -1;
                }
                else
                {
                    clMedioPagoS = new PdfPCell(new Paragraph(
                                                "SALDO", _standardFont2))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        BorderWidthTop = 0,
                        BorderWidthLeft = 1f,
                        PaddingLeft = 20,
                        PaddingBottom = 15,
                        PaddingTop = 20
                    };
                }

                PdfPCell clChequeS = new PdfPCell(new Paragraph(
                    "", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthTop = 0,
                    PaddingLeft = 20,
                    PaddingBottom = 15,
                    PaddingTop = 20
                };
                PdfPCell clBancoS = new PdfPCell(new Paragraph(
                    "", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthTop = 0,
                    PaddingLeft = 20,
                    PaddingBottom = 15,
                    PaddingTop = 20
                };

                //PdfPCell clMontoT = new PdfPCell(new Paragraph(string.Format("{0:c}",
                //    lstPagos.Sum(p => p.MONTO)), _standardFont))
                PdfPCell clMontoS = new PdfPCell(new Paragraph(string.Format("{0:c}",
                    saldo), _encabezado))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthTop = 0,
                    BorderWidthRight = 1f,
                    PaddingLeft = 20,
                    PaddingBottom = 15,
                    PaddingTop = 20
                };
                PdfPTable tblDetallePagosS = new PdfPTable(4)
                {
                    WidthPercentage = 100
                };
                tblDetallePagosS.SetWidths(new float[] { 40, 20, 20, 20 });

                tblDetallePagosS.AddCell(clMedioPagoS);
                tblDetallePagosS.AddCell(clChequeS);
                tblDetallePagosS.AddCell(clBancoS);
                tblDetallePagosS.AddCell(clMontoS);
                doc.Add(tblDetallePagosS);

                if (lstRecibos.Count > 1)
                {
                    DAL.MOV_BILLETERA_GASTOS objMov =
    DAL.MOV_BILLETERA_GASTOS.getByNroRecibo(lstRecibos.Max());

                    if (objMov != null)
                    {
                        PdfPTable tblTotal = new PdfPTable(2)
                        {
                            WidthPercentage = 100,
                        };
                        tblTotal.SetWidths(new float[] { 80, 20 });
                        PdfPCell clT = new PdfPCell(new Paragraph("Saldo a favor a cuenta corriente", _encabezado))
                        {
                            BorderWidth = 0,
                            PaddingLeft = 20,
                            PaddingBottom = 10,
                            PaddingRight = 20,
                            BorderWidthLeft = 1f,
                            PaddingTop = 10
                        };
                        PdfPCell clTot = new PdfPCell(new Paragraph(string.Format(
                            "{0:c}", objMov.MONTO, _encabezado)))
                        {
                            BorderWidth = 0,
                            PaddingLeft = 10,
                            PaddingRight = 20,
                            PaddingBottom = 10,
                            PaddingTop = 10,
                            BorderWidthRight = 1f,
                            HorizontalAlignment = 2
                        };
                        tblTotal.AddCell(clT);
                        tblTotal.AddCell(clTot);
                        doc.Add(tblTotal);
                    }
                }
                PdfPTable tblConforme = new PdfPTable(4)
                {
                    WidthPercentage = 100,
                };
                PdfPCell clConforme1 = new PdfPCell(new Paragraph(
                    "Recibi conforme: ", _standardFont2))
                {
                    BorderWidth = 0,
                    BorderWidthLeft = 1f,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                    PaddingLeft = 20
                };
                PdfPCell clConforme2 = new PdfPCell(new Paragraph(""))
                {
                    BorderWidth = 0,
                    PaddingTop = 10,
                };
                PdfPCell clConforme3 = new PdfPCell(new Paragraph(""))
                {
                    BorderWidth = 0,
                    PaddingTop = 10,
                };
                PdfPCell clConforme4 = new PdfPCell(new Paragraph(
                    "", _encabezado))
                {
                    BorderWidth = 0,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                    BorderWidthRight = 1f
                };

                PdfPCell clConforme5 = new PdfPCell()
                {
                    BorderWidth = 0,
                    PaddingTop = 10,
                    BorderWidthLeft = 1f
                };
                PdfPCell clConforme6 = new PdfPCell(new Paragraph(""))
                {
                    BorderWidth = 0,
                    PaddingTop = 10
                };
                Paragraph p2 = new Paragraph("--------------------------------", _standardFont);
                p2.Alignment = Element.ALIGN_CENTER;
                clConforme6.AddElement(p2);
                PdfPCell clConforme7 = new PdfPCell(new Paragraph(""))
                {
                    BorderWidth = 0,
                    PaddingTop = 10
                };
                Paragraph p3 = new Paragraph("--------------------------------", _standardFont);
                p3.Alignment = Element.ALIGN_CENTER;
                clConforme7.AddElement(p3);

                PdfPCell clConforme8 = new PdfPCell(new Paragraph(
                    "", _encabezado))
                {
                    BorderWidth = 0,
                    PaddingTop = 10,
                    BorderWidthRight = 1f
                };

                Paragraph p4 = new Paragraph("--------------------------------",
                    _standardFont);
                p4.Alignment = Element.ALIGN_CENTER;
                clConforme8.AddElement(p4);

                PdfPCell clConforme9 = new PdfPCell(new Paragraph(""))
                {
                    BorderWidth = 0,
                    PaddingTop = 10,
                    PaddingBottom = 30,
                    BorderWidthLeft = 1f,
                    BorderWidthBottom = 1f
                };
                PdfPCell clConforme10 = new PdfPCell()
                {
                    BorderWidth = 0,
                    PaddingTop = 10,
                    PaddingBottom = 30,
                    BorderWidthBottom = 1f
                };
                Paragraph p1 = new Paragraph("Firma", _standardFont);
                p1.Alignment = Element.ALIGN_CENTER;
                clConforme10.AddElement(p1);
                PdfPCell clConforme11 = new PdfPCell()
                {
                    BorderWidth = 0,
                    PaddingTop = 10,
                    PaddingBottom = 30,
                    BorderWidthBottom = 1f
                };
                Paragraph p5 = new Paragraph("Aclaración", _standardFont);
                p5.Alignment = Element.ALIGN_CENTER;
                clConforme11.AddElement(p5);

                PdfPCell clConforme12 = new PdfPCell()
                {
                    BorderWidth = 0,
                    PaddingTop = 10,
                    PaddingBottom = 30,
                    BorderWidthRight = 1f,
                    BorderWidthBottom = 1f
                };
                Paragraph p6 = new Paragraph("DNI", _standardFont);
                p6.Alignment = Element.ALIGN_CENTER;
                clConforme12.AddElement(p6);

                tblConforme.AddCell(clConforme1);
                tblConforme.AddCell(clConforme2);
                tblConforme.AddCell(clConforme3);
                tblConforme.AddCell(clConforme4);
                tblConforme.AddCell(clConforme5);
                tblConforme.AddCell(clConforme6);
                tblConforme.AddCell(clConforme7);
                tblConforme.AddCell(clConforme8);
                tblConforme.AddCell(clConforme9);
                tblConforme.AddCell(clConforme10);
                tblConforme.AddCell(clConforme11);
                tblConforme.AddCell(clConforme12);
                doc.Add(tblConforme);
                doc.Close();
                return output.ToArray();
            }

        }
    }
}