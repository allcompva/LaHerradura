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
    public partial class AdelantoProveedor : System.Web.UI.Page
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
            int nroAdelanto = Convert.ToInt32(Request.QueryString["nroAdelanto"]);
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "Inline; filename=" +
                "Adelanto_Proveedor_" + nroAdelanto + ".pdf");

            Response.BinaryWrite(strS);
            Response.End();
            Response.Flush();
            Response.Clear();
        }
        private byte[] CreatePDF2()
        {
            Document doc = new Document(PageSize.LETTER, 30, 30, 30, 30);
            int nroAdelanto = Convert.ToInt32(Request.QueryString["nroAdelanto"]);
            int idProv = Convert.ToInt32(Request.QueryString["idProv"]);
            DAL.VISTA_ANTICIPO_PROVEEDOR obj =
                DAL.VISTA_ANTICIPO_PROVEEDOR.getByPk(nroAdelanto);
            DAL.PROVEEDORES objProv =
                DAL.PROVEEDORES.getByPk(idProv);

            string cuitper = string.Empty;

            Paragraph salto = new Paragraph();

            salto.SpacingAfter = 10;
            using (MemoryStream output = new MemoryStream())
            {
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

                clDatos.AddElement(new Phrase("Recibo Adelanto a Porveedores",
                    _encabezado));

                clDatos.AddElement(salto);

                clDatos.AddElement(new Phrase(
                    string.Format("Nro: {0}-{1}",
                    1.ToString().PadLeft(4, Convert.ToChar("0")),
                    obj.NRO_RECIBO_ADELANTO.ToString().PadLeft(8,
                    Convert.ToChar("0"))), _encabezado));
                clDatos.AddElement(salto);
                clDatos.AddElement(new Phrase(string.Format("Fecha: {0}",
                    obj.FECHA.ToShortDateString()
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
                    objProv.NOMBRE_FANTASIA), _standardFont));
                clProp.AddElement(salto);
                clProp.AddElement(new Phrase(string.Format(
                    "Razón Social: {0}",
                    objProv.RAZON_SOCIAL), _standardFont));
                clProp.AddElement(salto);
                DAL.TB_CONDICION_IVA objIva = DAL.TB_CONDICION_IVA.getByPk(
                    objProv.COND_IVA);
                clProp.AddElement(new Phrase(string.Format(
                    "Condición ante I.V.A.: {0}", objIva.DESCRIPCION),
                    _standardFont));

                clProp.AddElement(salto);

                PdfPCell clCta = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f
                };
                clCta.AddElement(new Phrase(string.Format(
                    "C.U.I.T.: {0}-{1}-{2}",
                    objProv.CUIT.Substring(0, 2),
                    objProv.CUIT.Substring(2, 8),
                    objProv.CUIT.Substring(10, 1)), _standardFont));
                clCta.AddElement(salto);


                tblPrpietario.AddCell(clProp);
                tblPrpietario.AddCell(clCta);
                doc.Add(tblPrpietario);
                #endregion


                PdfPTable tblTitPagos = new PdfPTable(1)
                {
                    WidthPercentage = 100,

                };
                PdfPCell clPagosTitulo = new PdfPCell(new Paragraph(
                    "Detalle Adelanto", _encabezado))
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

                PdfPTable tblDetallePagos1 = new PdfPTable(1)
                {
                    WidthPercentage = 100,

                };
                PdfPCell clDetPago1 = new PdfPCell(
                    new Paragraph("", _encabezado))
                {
                    BorderWidth = 0,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 1f,
                    Padding = 20
                };




                PdfPTable tblSubTitPagos = new PdfPTable(1)
                {
                    WidthPercentage = 100,

                };
                PdfPCell clPagosSubTitulo = new PdfPCell(
                    new Paragraph(string.Format(
                        "Fecha: {0}",
                        obj.FECHA.ToShortDateString()), _standardFont2))
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

                PdfPTable tblDetallePagos = new PdfPTable(4)
                {
                    WidthPercentage = 100
                };
                tblDetallePagos.SetWidths(new float[] { 40, 20, 20, 20 });
                PdfPCell clMedioPago = new
                    PdfPCell(new Paragraph(obj.DESCRIPCION,
                    _standardFont))
                {
                    BorderWidth = 0,
                    PaddingLeft = 20,
                    PaddingBottom = 5,
                    PaddingTop = 5,
                    BorderWidthLeft = 1f
                };
                PdfPCell clCheque = new PdfPCell(new Paragraph(string.Format("{0:c}",
                    obj.NRO_CHEQUE), _standardFont))
                {
                    BorderWidth = 0,
                    PaddingLeft = 20,
                    PaddingBottom = 5,
                    PaddingTop = 5
                };
                PdfPCell clBanco = new PdfPCell(new Paragraph(string.Format("{0:c}",
                    obj.BANCO), _standardFont))
                {
                    BorderWidth = 0,
                    PaddingLeft = 20,
                    PaddingBottom = 5,
                    PaddingTop = 5
                };
                PdfPCell clMonto = new PdfPCell(new Paragraph(string.Format("{0:c}",
                    obj.MONTO), _standardFont))
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

                tot += obj.MONTO;
                totGral += obj.MONTO;
                           
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
                PdfPCell clMontoT = new PdfPCell(new
                    Paragraph(string.Format("{0:c}",
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