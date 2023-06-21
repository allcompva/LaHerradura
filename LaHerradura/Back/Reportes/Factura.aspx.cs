﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = iTextSharp.text.Image;

namespace LaHerradura.Back.Reportes
{
    public partial class Factura1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["ptoVta"] == null)
                    ShowPdf(CreatePDF2());
                else
                    ShowPdf(CreatePDF2Externa());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShowPdf(byte[] strS)
        {
            int nroCta = Convert.ToInt32(Request.QueryString["nrocta"]);
            int periodo = Convert.ToInt32(Request.QueryString["periodo"]);

            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "Inline; filename=" +
                "Expensas_cuenta_" + nroCta + ".pdf");

            Response.BinaryWrite(strS);
            Response.End();
            Response.Flush();
            Response.Clear();
        }
        private byte[] CreatePDF2()
        {
            Document doc = new Document(PageSize.LETTER, 30, 30, 30, 30);
            int nroCta = Convert.ToInt32(Request.QueryString["nrocta"]);
            int periodo = Convert.ToInt32(Request.QueryString["periodo"]);
            int idCta = Convert.ToInt32(Request.QueryString["idcta"]);

            DAL.CTACTE_EXPENSAS objExpensa = DAL.CTACTE_EXPENSAS.getByPk(idCta);
            DAL.INMUEBLES objInm = DAL.INMUEBLES.getByNroCta(nroCta);
            List<DAL.PERSONAS_GRILLA> lstPer = DAL.PERSONAS_GRILLA.getByNroCta(nroCta);
            List<DAL.FACTURAS_X_EXPENSA> lstF = DAL.FACTURAS_X_EXPENSA.read(nroCta,
                periodo);
            DAL.FACTURAS_X_EXPENSA objF = null;
            if (lstF.Count > 0)
                objF = lstF[0];


            string codBarra = string.Empty;
            codBarra = LaHerradura.RapiPago.CodigoBarra.getCodigoBarra(
                                objExpensa.NRO_CTA,
                                objExpensa.PTO_VTA,
                                objExpensa.NRO_CTE,
                                objExpensa.MONTO_ORIGINAL,
                                objExpensa.VENCIMIENTO,
                                0,
                                0,
                                0,
                                0);


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
                /**/
                Image png;
                switch (objExpensa.TIPO_MOVIMIENTO)
                {
                    case 100:
                        //png = Image.GetInstance("https://aclaherradura.com.ar/img/" + "logo2.png");
                        png = Image.GetInstance(Server.MapPath("../../img/" + "logo2.png"));
                        break;
                    case 3:
                        png = Image.GetInstance(Server.MapPath("../../img/" + "logoPlan.png"));
                        //png = Image.GetInstance("https://aclaherradura.com.ar/img/" + "logoPlan.png");
                        break;
                    case 21:
                        png = Image.GetInstance(Server.MapPath("../../img/" + "logoPlan.png"));
                        //png = Image.GetInstance("https://aclaherradura.com.ar/img/" + "logoPlan.png");
                        break;
                    default:
                        png = Image.GetInstance(Server.MapPath("../../img/" + "logoPlan.png"));
                        //png = Image.GetInstance("https://aclaherradura.com.ar/img/" + "logoPlan.png");
                        break;
                }

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

                string nroF = string.Format("{0}-{1}",
                    objExpensa.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                    objExpensa.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));

                switch (objExpensa.TIPO_MOVIMIENTO)
                {
                    case 100:
                        clDatos.AddElement(new Phrase("Factura", _encabezado));
                        break;
                    case 3:
                        clDatos.AddElement(new Phrase("Recibo", _encabezado));
                        break;
                    case 21:
                        clDatos.AddElement(new Phrase("Nota de Débito Interna", _encabezado));
                        break;
                    default:
                        break;
                }



                clDatos.AddElement(salto);

                clDatos.AddElement(new Phrase(
                    string.Format("Nro: {0}", nroF), _encabezado));
                clDatos.AddElement(salto);
                clDatos.AddElement(new Phrase(string.Format("Fecha: {0}/{1}/{2}",
                    objExpensa.FECHA_CAE.Day, objExpensa.FECHA_CAE.Month,
                    objExpensa.FECHA_CAE.Year
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
                string propietarios = string.Empty;
                string cuitPer = string.Empty;
                foreach (var item in lstPer)
                {
                    if (item.RESPONSABLE_FACTURACION)
                    {
                        propietarios += string.Format("{0}, ", item.NOMBRE);
                        cuitPer = item.CUIT;
                    }
                }
                foreach (var item in lstPer)
                {
                    if (item.RELACION == "Inquilino")
                    {
                        propietarios += string.Format("(Inquilinos: {0}), ", item.NOMBRE);
                    }
                }
                clProp.AddElement(new Phrase(string.Format(
                    "Señores: {0} (Manzana: {1} - Lote: {2})", propietarios,
                    objInm.MANZANA, objInm.LOTE), _standardFont));
                clProp.AddElement(salto);
                clProp.AddElement(new Phrase(string.Format("Direccion: {0} N° {1}",
                    objInm.CALLE, objInm.NRO), _standardFont));
                clProp.AddElement(salto);
                clProp.AddElement(new Phrase("I.V.A.: Consumidor Final", _standardFont));

                clProp.AddElement(salto);
                clProp.AddElement(new Phrase(string.Format("Condición de venta: CUENTA CORRIENTE. - Vencimiento: {0}",
                    objF.FECHA_CAE.ToShortDateString()), _standardFont));
                clProp.AddElement(salto);
                PdfPCell clCta = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f
                };
                clCta.AddElement(new Phrase(string.Format("C.U.I.T.: {0}-{1}-{2}",
                    cuitPer.Substring(0, 2), cuitPer.Substring(2, 8), cuitPer.Substring(10, 1)), _standardFont));
                clCta.AddElement(salto);
                clCta.AddElement(new Phrase(string.Format("Nro. de cuenta: {0}", objExpensa.NRO_CTA), _standardFont));
                clCta.AddElement(salto);
                if (objExpensa.TIPO_MOVIMIENTO != 3)
                    clCta.AddElement(new Phrase(string.Format("Periodo: {0}-{1}/{2}",
                        periodo.ToString().Substring(0, 4),
                        periodo.ToString().Substring(4, 2),
                        periodo.ToString().Substring(6, 2)), _encabezado));
                else
                    clCta.AddElement(new Phrase(string.Format("Plan pago {0} - Cuota: {1}",
                        objExpensa.NRO_PLAN_PAGO,
                        objExpensa.NRO_CUOTA), _encabezado));

                clCta.AddElement(salto);

                tblPrpietario.AddCell(clProp);
                tblPrpietario.AddCell(clCta);
                doc.Add(tblPrpietario);
                #endregion
                #region DETALLE_FACTURA
                //DETALLE FACTURA
                PdfPTable tblDetalle = new PdfPTable(5)
                {
                    WidthPercentage = 100,

                };
                tblDetalle.SetWidths(new float[] { 15, 40, 15, 15, 15 });
                PdfPCell clCod = new PdfPCell(new Paragraph("Codigó", _standardFont))
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
                PdfPCell clConcepto = new PdfPCell(new Paragraph("Concepto", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                    BackgroundColor = Color.LIGHT_GRAY
                };
                PdfPCell clCantidad = new PdfPCell(new Paragraph("Cant.", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                    BackgroundColor = Color.LIGHT_GRAY
                };
                PdfPCell clPreUnit = new PdfPCell(
                    new Paragraph("Pre. Unit.", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                    BackgroundColor = Color.LIGHT_GRAY
                };
                //BarcodeInter25
                PdfPCell clSubTotal = new PdfPCell(new Paragraph("Sub Total", _standardFont))
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
                tblDetalle.AddCell(clPreUnit);
                tblDetalle.AddCell(clSubTotal);
                List<DAL.DETALLE_DEUDA> lstFactura = new List<DAL.DETALLE_DEUDA>();

                lstFactura = DAL.DETALLE_DEUDA.read(periodo, nroCta);
                foreach (var item in lstFactura)
                {
                    PdfPCell clCodd = new PdfPCell(new Paragraph(
                        item.ID_CONCEPTO.ToString(), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10
                    };
                    PdfPCell clConceptod = new PdfPCell(
                        new Paragraph(item.OBS, _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        BorderWidthRight = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10,
                    };
                    PdfPCell clCantidadd = new PdfPCell(new Paragraph(
                        item.CANT.ToString(), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        BorderWidthRight = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10
                    };
                    PdfPCell clPreUnitd = new PdfPCell(
                        new Paragraph(string.Format("{0:c}",
                        item.COSTO), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        BorderWidthRight = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10
                    };
                    PdfPCell clSubTotald = new PdfPCell(new Paragraph(
                        string.Format("{0:c}",
                        item.CANT * item.COSTO), _standardFont))
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
                    tblDetalle.AddCell(clPreUnitd);
                    tblDetalle.AddCell(clSubTotald);
                }

                doc.Add(tblDetalle);


                PdfPTable tblTotal = new PdfPTable(2)
                {
                    WidthPercentage = 100,
                };
                tblTotal.SetWidths(new float[] { 20, 80 });
                PdfPCell clT = new PdfPCell(new Paragraph("Total", _encabezado))
                {
                    BorderWidth = 0,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    BorderWidthLeft = 1f,
                    BorderWidthBottom = 1f,
                    PaddingTop = 10
                };
                if (objExpensa.TIPO_MOVIMIENTO != 3)
                {
                    PdfPCell clTot = new PdfPCell(new Paragraph(string.Format(
                        "{0:c}", lstFactura.Sum(f => f.CANT * f.COSTO), _encabezado)))
                    {
                        BorderWidth = 0,
                        PaddingLeft = 10,
                        PaddingRight = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10,
                        BorderWidthBottom = 1f,
                        BorderWidthRight = 1f,
                        HorizontalAlignment = 2
                    };
                    tblTotal.AddCell(clT);
                    tblTotal.AddCell(clTot);
                    doc.Add(tblTotal);
                }
                PdfPTable tblNota = new PdfPTable(1)
                {
                    WidthPercentage = 100,
                };
                #endregion

                #region CODIGO_BARRA
                PdfPTable tblPie = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };
                PdfPCell clPie1 = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 1f,
                    Padding = 10
                };


                clPie1.AddElement(new Phrase(string.Format("Clave Banelco: {0}",
                    nroCta), _encabezado));
                clPie1.AddElement(salto);
                PdfContentByte cb = wri.DirectContent;
                Barcode128 code25 = new Barcode128();
                code25.GenerateChecksum = true;
                code25.Code = codBarra;

                Phrase rapi = new Phrase();


                clPie1.AddElement(new Phrase("Rapipago"));
                clPie1.AddElement(salto);
                clPie1.AddElement(code25.CreateImageWithBarcode(cb, null, null));

                tblPie.AddCell(clPie1);
                PdfPCell clPie2 = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    Padding = 10
                };
                clPie2.AddElement(new Phrase(string.Format("Comp. valido p/ pagar en ent. recaudadora hasta: : {0}",
    objF.FECHA_CAE.ToShortDateString()), _standardFont));
                clPie2.AddElement(salto);

                PdfPTable tbLVencimientos = new PdfPTable(3)
                {
                    WidthPercentage = 100
                };
                PdfPCell clVenc1 = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    BorderWidthLeft = 1f,
                    Padding = 10
                };
                clVenc1.AddElement(new Phrase("Vencimiento:", _standardFont));
                clVenc1.AddElement(salto);

                PdfPCell clVenc2 = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    Padding = 10,
                    HorizontalAlignment = 1
                };

                Paragraph p1 = new Paragraph(
                    objExpensa.VENCIMIENTO.ToShortDateString(), _standardFont);
                p1.Alignment = Element.ALIGN_RIGHT;
                clVenc2.AddElement(p1);
                clVenc2.AddElement(salto);

                PdfPCell clVenc3 = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    Padding = 10,
                    HorizontalAlignment = 1
                };
                Paragraph p4 = new Paragraph(
                    string.Format("{0:c}",
                    objExpensa.MONTO_ORIGINAL), _standardFont);
                p4.Alignment = Element.ALIGN_RIGHT;
                clVenc3.AddElement(p4);
                clVenc3.AddElement(salto);

                tbLVencimientos.AddCell(clVenc1);
                tbLVencimientos.AddCell(clVenc2);
                tbLVencimientos.AddCell(clVenc3);
                clPie2.AddElement(tbLVencimientos);
                tblPie.AddCell(clPie2);

                doc.Add(tblPie);

                #endregion

                #region PIE
                if (objExpensa.TIPO_MOVIMIENTO == 100)
                {
                    PdfPTable tblPie2 = new PdfPTable(3)
                    {
                        WidthPercentage = 100
                    };
                    PdfPCell clPie2_1 = new PdfPCell()
                    {
                        BorderWidth = 0,
                        Padding = 10
                    };
                    clPie2_1.AddElement(new Phrase("COMPROBANTE AUTORIZADO", _standardFont));
                    tblPie2.AddCell(clPie2_1);
                    PdfPCell clPie2_2 = new PdfPCell()
                    {
                        BorderWidth = 0,
                        Padding = 10
                    };
                    clPie2_2.AddElement(new Phrase(string.Format(
                        "C.A.E. N°: {0}", objExpensa.CAE), _standardFont));
                    tblPie2.AddCell(clPie2_2);

                    PdfPCell clPie2_3 = new PdfPCell()
                    {
                        BorderWidth = 0,
                        Padding = 10
                    };
                    clPie2_3.AddElement(new Phrase(string.Format(
                        "Vto. C.A.E.: {0}", objExpensa.VENC_CAE), _standardFont));
                    tblPie2.AddCell(clPie2_3);
                    doc.Add(tblPie2);
                    //CODIGO BARRA AFIP
                    PdfPTable tblPie3 = new PdfPTable(3)
                    {
                        WidthPercentage = 100
                    };
                    PdfPCell clPie3_1 = new PdfPCell()
                    {
                        BorderWidth = 0,
                        Padding = 10
                    };
                    clPie3_1.AddElement(new Phrase("", _standardFont));
                    tblPie3.AddCell(clPie3_1);
                    PdfPCell clPie3_2 = new PdfPCell()
                    {
                        BorderWidth = 0,
                        Padding = 10
                    };

                    string strCadena = LaHerradura.Utils.Utils.ArmoCBarra(objExpensa.NRO_CUIT, 11,
    objExpensa.PTO_VTA, objExpensa.CAE, objExpensa.FECHA_CAE);


                    clPie3_2.AddElement(salto);


                    PdfContentByte cb2 = wri.DirectContent;
                    Barcode128 code252 = new Barcode128();
                    code252.GenerateChecksum = true;
                    code252.Code = strCadena;

                    clPie3_2.AddElement(
                        code252.CreateImageWithBarcode(cb2, null, null));

                    tblPie3.AddCell(clPie3_2);
                    PdfPCell clPie3_3 = new PdfPCell()
                    {
                        BorderWidth = 0,
                        Padding = 10
                    };
                    clPie3_3.AddElement(new Phrase("", _standardFont));
                    tblPie3.AddCell(clPie3_3);

                    doc.Add(tblPie3);

                }
                #endregion
                doc.Close();
                return output.ToArray();
            }

        }
        private byte[] CreatePDF2Externa()
        {
            Document doc = new Document(PageSize.LETTER, 30, 30, 30, 30);
            int ptoVta = Convert.ToInt32(Request.QueryString["ptoVta"]);
            int nroCte = Convert.ToInt32(Request.QueryString["nroCte"]);
            int tipoCte = Convert.ToInt32(Request.QueryString["tipoCte"]);

            DAL.FACTURAS_X_EXPENSA objF = DAL.FACTURAS_X_EXPENSA.getByPk(ptoVta, nroCte, tipoCte);

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
                /**/
                Image png;

                //png = Image.GetInstance("https://aclaherradura.com.ar/img/" + "logo2.png");
                png = Image.GetInstance(Server.MapPath("../../img/" + "logo2.png"));

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

                string nroF = string.Format("{0}-{1}",
                    ptoVta.ToString().PadLeft(4, Convert.ToChar("0")),
                    nroCte.ToString().PadLeft(8, Convert.ToChar("0")));

                switch (tipoCte)
                {
                    case 11:
                        clDatos.AddElement(new Phrase("Factura", _encabezado));
                        break;

                }



                clDatos.AddElement(salto);

                clDatos.AddElement(new Phrase(
                    string.Format("Nro: {0}", nroF), _encabezado));
                clDatos.AddElement(salto);
                clDatos.AddElement(new Phrase(string.Format("Fecha: {0}/{1}/{2}",
                    objF.FECHA_CAE.Day, objF.FECHA_CAE.Month,
                    objF.FECHA_CAE.Year
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
                string propietarios = string.Empty;

                clProp.AddElement(new Phrase(string.Format(
                    "Señore/s: {0}", objF.NOMBRE), _standardFont));
                clProp.AddElement(salto);

                clProp.AddElement(salto);
                clProp.AddElement(new Phrase("I.V.A.: Consumidor Final", _standardFont));

                clProp.AddElement(salto);
                clProp.AddElement(new Phrase(string.Format("Condición de venta: CUENTA CORRIENTE. - Vencimiento: {0}",
                    objF.FECHA_CAE.ToShortDateString()), _standardFont));
                clProp.AddElement(salto);
                PdfPCell clCta = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f
                };
                if (objF.CUIT != "0")
                {
                    if(objF.CUIT.Length ==11)
                        clCta.AddElement(new Phrase(string.Format("C.U.I.T.: {0}-{1}-{2}",
                            objF.CUIT.Substring(0, 2), objF.CUIT.Substring(2, 8), objF.CUIT.Substring(10, 1)), _standardFont));
                    else
                        clCta.AddElement(new Phrase(string.Format("C.U.I.T.: {0}",
                            objF.CUIT), _standardFont));
                }
                else
                    clCta.AddElement(new Phrase(string.Format("C.U.I.T.: -"), _standardFont));

                clCta.AddElement(salto);
                clCta.AddElement(salto);

                clCta.AddElement(new Phrase(string.Format("",""), _encabezado));

                clCta.AddElement(salto);

                tblPrpietario.AddCell(clProp);
                tblPrpietario.AddCell(clCta);
                doc.Add(tblPrpietario);
                #endregion
                #region DETALLE_FACTURA
                //DETALLE FACTURA
                PdfPTable tblDetalle = new PdfPTable(5)
                {
                    WidthPercentage = 100,

                };
                tblDetalle.SetWidths(new float[] { 15, 40, 15, 15, 15 });
                PdfPCell clCod = new PdfPCell(new Paragraph("Codigó", _standardFont))
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
                PdfPCell clConcepto = new PdfPCell(new Paragraph("Concepto", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                    BackgroundColor = Color.LIGHT_GRAY
                };
                PdfPCell clCantidad = new PdfPCell(new Paragraph("Cant.", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                    BackgroundColor = Color.LIGHT_GRAY
                };
                PdfPCell clPreUnit = new PdfPCell(
                    new Paragraph("Pre. Unit.", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                    BackgroundColor = Color.LIGHT_GRAY
                };
                //BarcodeInter25
                PdfPCell clSubTotal = new PdfPCell(new Paragraph("Sub Total", _standardFont))
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
                tblDetalle.AddCell(clPreUnit);
                tblDetalle.AddCell(clSubTotal);

                PdfPCell clCodd = new PdfPCell(new Paragraph(1))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10
                };
                PdfPCell clConceptod = new PdfPCell(
                    new Paragraph(string.Format("{0}",
                    objF.DETALLE), _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                };
                PdfPCell clCantidadd = new PdfPCell(new Paragraph(string.Format("{0}",
                    1), _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10
                };
                PdfPCell clPreUnitd = new PdfPCell(
                    new Paragraph(string.Format("{0:c}",
                    objF.MONTO), _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10
                };
                PdfPCell clSubTotald = new PdfPCell(new Paragraph(
                    string.Format("{0:c}",
                    objF.MONTO), _standardFont))
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
                tblDetalle.AddCell(clPreUnitd);
                tblDetalle.AddCell(clSubTotald);


                doc.Add(tblDetalle);


                PdfPTable tblTotal = new PdfPTable(2)
                {
                    WidthPercentage = 100,
                };
                tblTotal.SetWidths(new float[] { 20, 80 });
                PdfPCell clT = new PdfPCell(new Paragraph("Total", _encabezado))
                {
                    BorderWidth = 0,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    BorderWidthLeft = 1f,
                    BorderWidthBottom = 1f,
                    PaddingTop = 10
                };

                PdfPCell clTot = new PdfPCell(new Paragraph(string.Format(
                    "{0:c}", objF.MONTO)))
                {
                    BorderWidth = 0,
                    PaddingLeft = 10,
                    PaddingRight = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    HorizontalAlignment = 2
                };
                tblTotal.AddCell(clT);
                tblTotal.AddCell(clTot);
                doc.Add(tblTotal);

                PdfPTable tblNota = new PdfPTable(1)
                {
                    WidthPercentage = 100,
                };
                #endregion

                #region CODIGO_BARRA
                PdfPTable tblPie = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };
                PdfPCell clPie1 = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 1f,
                    Padding = 10
                };


                tblPie.AddCell(clPie1);
                PdfPCell clPie2 = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthTop = 1f,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    Padding = 10
                };

                clPie2.AddElement(salto);


                #endregion

                #region PIE
                if (objF.TIPO_COMPROBANTE == 11)
                {
                    PdfPTable tblPie2 = new PdfPTable(3)
                    {
                        WidthPercentage = 100
                    };
                    PdfPCell clPie2_1 = new PdfPCell()
                    {
                        BorderWidth = 0,
                        Padding = 10
                    };
                    clPie2_1.AddElement(new Phrase("COMPROBANTE AUTORIZADO", _standardFont));
                    tblPie2.AddCell(clPie2_1);
                    PdfPCell clPie2_2 = new PdfPCell()
                    {
                        BorderWidth = 0,
                        Padding = 10
                    };
                    clPie2_2.AddElement(new Phrase(string.Format(
                        "C.A.E. N°: {0}", objF.CAE), _standardFont));
                    tblPie2.AddCell(clPie2_2);

                    PdfPCell clPie2_3 = new PdfPCell()
                    {
                        BorderWidth = 0,
                        Padding = 10
                    };
                    clPie2_3.AddElement(new Phrase(string.Format(
                        "Vto. C.A.E.: {0}", objF.VENC_CAE), _standardFont));
                    tblPie2.AddCell(clPie2_3);
                    doc.Add(tblPie2);
                    //CODIGO BARRA AFIP
                    PdfPTable tblPie3 = new PdfPTable(3)
                    {
                        WidthPercentage = 100
                    };
                    PdfPCell clPie3_1 = new PdfPCell()
                    {
                        BorderWidth = 0,
                        Padding = 10
                    };
                    clPie3_1.AddElement(new Phrase("", _standardFont));
                    tblPie3.AddCell(clPie3_1);
                    PdfPCell clPie3_2 = new PdfPCell()
                    {
                        BorderWidth = 0,
                        Padding = 10
                    };

                    string strCadena = LaHerradura.Utils.Utils.ArmoCBarra("00000000000", 11,
    objF.PTO_VTA, objF.CAE, objF.FECHA_CAE);


                    clPie3_2.AddElement(salto);


                    PdfContentByte cb2 = wri.DirectContent;
                    Barcode128 code252 = new Barcode128();
                    code252.GenerateChecksum = true;
                    code252.Code = strCadena;

                    clPie3_2.AddElement(
                        code252.CreateImageWithBarcode(cb2, null, null));

                    tblPie3.AddCell(clPie3_2);
                    PdfPCell clPie3_3 = new PdfPCell()
                    {
                        BorderWidth = 0,
                        Padding = 10
                    };
                    clPie3_3.AddElement(new Phrase("", _standardFont));
                    tblPie3.AddCell(clPie3_3);

                    doc.Add(tblPie3);

                }
                #endregion
                doc.Close();
                return output.ToArray();
            }

        }
        private string getPeriodo(int periodo)
        {
            try
            {
                string periodoMaquillado = string.Empty;
                if (periodo != 20190100)
                {
                    string me, mes = string.Empty;
                    me = periodo.ToString().Substring(4, 2);
                    switch (me)
                    {
                        case "01":
                            mes = "Enero";
                            break;
                        case "02":
                            mes = "Febrero";
                            break;
                        case "03":
                            mes = "Marzo";
                            break;
                        case "04":
                            mes = "Abril";
                            break;
                        case "05":
                            mes = "Mayo";
                            break;
                        case "06":
                            mes = "Junio";
                            break;
                        case "07":
                            mes = "Julio";
                            break;
                        case "08":
                            mes = "Agosto";
                            break;
                        case "09":
                            mes = "Septiembre";
                            break;
                        case "10":
                            mes = "Octubre";
                            break;
                        case "11":
                            mes = "Noviembre";
                            break;
                        case "12":
                            mes = "Diciembre";
                            break;
                        default:
                            break;
                    }
                    if (periodo.ToString().Substring(6, 2) == "00")
                    {
                        periodoMaquillado = string.Format("Expensas Ordinarias mes de {0} de {1}",
                            mes,
                            periodo.ToString().Substring(0, 4));
                    }
                    else
                    {
                        periodoMaquillado =
                        string.Format("Expensas Extraordinarias mes de {0} de {1}",
                            mes,
                            periodo.ToString().Substring(0, 4));
                    }
                }
                else
                {
                    periodoMaquillado = "Saldo (capital) a Sept. 2019";
                }
                return periodoMaquillado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}