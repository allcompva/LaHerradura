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
    public partial class reciboGasto : System.Web.UI.Page
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
            int nroRecibo = Convert.ToInt32(Request.QueryString["nroRecibo"]);
            DateTime fecha = Convert.ToDateTime(Request.QueryString["fecha"]);

            List<DAL.CTACTE_GASTOS> lstCta =
    DAL.CTACTE_GASTOS.getByRecibo(nroRecibo);

            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "Inline; filename=" +
                "Recibo_Pago_proveedor_" + lstCta[0].ID_PROVEEDOR + ".pdf");

            Response.BinaryWrite(strS);
            Response.End();
            Response.Flush();
            Response.Clear();
        }
        private byte[] CreatePDF2()
        {
            Document doc = new Document(PageSize.LETTER, 30, 30, 30, 30);
            int nroRecibo = Convert.ToInt32(Request.QueryString["nroRecibo"]);
            DateTime fecha = Convert.ToDateTime(Request.QueryString["fecha"]);

            List<DAL.CTACTE_GASTOS> lstCta =
    DAL.CTACTE_GASTOS.getByRecibo(nroRecibo);


            DAL.PROVEEDORES objPer =
                DAL.PROVEEDORES.getByPk(lstCta[0].ID_PROVEEDOR);

            string cuitper = string.Empty;

            Paragraph salto = new Paragraph();

            salto.SpacingAfter = 10;
            using (MemoryStream output = new MemoryStream())
            {
                List<DAL.PAGOS_X_FACTURA_GASTOS> lstPagos =
    DAL.PAGOS_X_FACTURA_GASTOS.read(nroRecibo);
                PdfWriter wri = PdfWriter.GetInstance(doc, output);
                doc.Open();
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 8,
                    iTextSharp.text.Font.NORMAL, Color.BLACK);
                iTextSharp.text.Font _encabezado = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12,
                    iTextSharp.text.Font.BOLD, Color.BLACK);
                iTextSharp.text.Font _standardFont2 = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 10,
                    iTextSharp.text.Font.NORMAL, Color.BLACK);
                /**/
                Image png = Image.GetInstance(Server.MapPath("../../img/" + "logoPlan.png"));
                //Image png = Image.GetInstance("https://aclaherradura.com.ar/img/" + "logoPlan.png");
                
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

                string nroF = nroRecibo.ToString();

                clDatos.AddElement(new Phrase("Recibo de pago", _encabezado));

                clDatos.AddElement(salto);

                clDatos.AddElement(new Phrase(
                    string.Format("Nro: {0}", nroF), _encabezado));
                clDatos.AddElement(salto);
                clDatos.AddElement(new Phrase(string.Format("Fecha: {0}", LaHerradura.Utils.Utils.getFechaActual().ToShortDateString()
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



                PdfPTable tbLiquidacion = new PdfPTable(2)
                {
                    WidthPercentage = 100,

                };
                tbLiquidacion.SetWidths(new float[] { 45, 55 });
                PdfPCell clTexto = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthLeft = 1f,
                    Padding = 20
                };
                clTexto.AddElement(new Paragraph(
                        "Recibimos la suma de $ " +
                        lstPagos.Sum(p => p.MONTO)
                        , _standardFont2));
                clTexto.AddElement(new Paragraph(
                    "En concepto de cancelación total/parcial de comprobantes descriptos en tabla de liquidación",
                    _standardFont2));
                PdfPCell clLiquidacion = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthRight = 1f,
                    Padding = 10,
                };
                PdfPTable tblDetalle = new PdfPTable(3)
                {
                    WidthPercentage = 100,

                };
                tbLiquidacion.AddCell(clTexto);
                PdfPTable tblTitDetalle = new PdfPTable(1)
                {
                    WidthPercentage = 100,

                };
                PdfPCell clDetTitulo = new PdfPCell(new Paragraph("Liquidación", _encabezado))
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
                List<DAL.CTACTE_GASTOS> lst =
     DAL.CTACTE_GASTOS.getByRecibo(nroRecibo);

                foreach (var item in lst)
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
                        item.HABER), _standardFont))
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
                    lst.Sum(c => c.HABER)), _standardFont))
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
                PdfPCell clPagosTitulo = new PdfPCell(new Paragraph("Forma de pago", _encabezado))
                {
                    BorderWidth = 0,
                    PaddingLeft = 20,
                    PaddingBottom = 5,
                    PaddingTop = 5,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 1f,
                };
                tblTitPagos.AddCell(clPagosTitulo);
                doc.Add(tblTitPagos);
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

                PdfPTable tblDetallePagos = new PdfPTable(4)
                {
                    WidthPercentage = 100
                    

                };

                tblDetallePagos.SetWidths(new float[] { 40, 20, 20, 20 });
                foreach (var item in lstPagos)
                {
                    PdfPCell clMedioPago = new PdfPCell(new Paragraph(item.MEDIO_PAGO.ToString(), _standardFont))
                    {
                        BorderWidth = 0f,
                        BorderWidthTop = 1f,
                        BorderWidthLeft = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10
                    };
                    PdfPCell clCheque = new PdfPCell(new Paragraph(string.Format("{0:c}",
                        item.NRO_CHEQUE), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthTop = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10,
                    };
                    PdfPCell clBanco = new PdfPCell(new Paragraph(string.Format("{0:c}",
                        item.BANCO), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthTop = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10
                    };

                    PdfPCell clMonto = new PdfPCell(new Paragraph(string.Format("{0:c}",
                        item.MONTO), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthTop = 1f,
                        BorderWidthRight = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10
                    };

                    tblDetallePagos.AddCell(clMedioPago);
                    tblDetallePagos.AddCell(clBanco);
                    tblDetallePagos.AddCell(clCheque);
                    tblDetallePagos.AddCell(clMonto);
                }
                DAL.MOV_BILLETERA_GASTOS objMov =
                    DAL.MOV_BILLETERA_GASTOS.getByNroRecibo(nroRecibo);


                PdfPCell clMedioPagoT = new PdfPCell(new Paragraph(
                    "TOTAL", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthTop = 1f,
                    BorderWidthLeft = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10
                };
                PdfPCell clChequeT = new PdfPCell(new Paragraph(
                    "", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthTop = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                };
                PdfPCell clBancoT = new PdfPCell(new Paragraph(
                    "", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthTop = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10
                };

                PdfPCell clMontoT = new PdfPCell(new Paragraph(string.Format("{0:c}",
                    lstPagos.Sum(p => p.MONTO)), _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthTop = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10
                };

                tblDetallePagos.AddCell(clMedioPagoT);
                tblDetallePagos.AddCell(clChequeT);
                tblDetallePagos.AddCell(clBancoT);
                tblDetallePagos.AddCell(clMontoT);

                clDetPago1.AddElement(tblDetallePagos);
                tblDetallePagos1.AddCell(clDetPago1);
                doc.Add(tblDetallePagos1);

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