using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace LaHerradura.Back.Reportes
{
    public partial class Recibo1 : System.Web.UI.Page
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
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "Inline; filename=" + "Recibo_Pago.pdf");

            Response.BinaryWrite(strS);
            Response.End();
            Response.Flush();
            Response.Clear();
        }
        private byte[] CreatePDF2()
        {
            Document doc = new Document(PageSize.LETTER, 30, 30, 30, 30);
            int nroRecibo = Convert.ToInt32(Request.QueryString["nroRecibo"]);
            List<DAL.PAGOS_X_FACTURA> lstPagos = DAL.PAGOS_X_FACTURA.read(nroRecibo);
            //DateTime fecha = Convert.ToDateTime(Request.QueryString["fecha"]);

            List<DAL.CTACTE_EXPENSAS> lstCta =
    DAL.CTACTE_EXPENSAS.getByRecibo2(nroRecibo);


            List<DAL.PERSONAS_GRILLA> lstPer = DAL.PERSONAS_GRILLA.getByNroCta(lstCta[0].NRO_CTA);
            DAL.INMUEBLES objInm = DAL.INMUEBLES.getByNroCta(lstCta[0].NRO_CTA);
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
                /**/
                Image png = Image.GetInstance(Server.MapPath("../../img/" + "logoPlan.png"));

                //Image png = Image.GetInstance("https://aclaherradura.com.ar/img/LogoPlan.png");


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
                clDatos.AddElement(new Phrase(string.Format("Fecha: {0}/{1}/{2}",
                    lstPagos[0].FECHA.Day, lstPagos[0].FECHA.Month, lstPagos[0].FECHA.Year
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

                PdfPCell clCta = new PdfPCell()
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f
                };
                clCta.AddElement(new Phrase(string.Format("C.U.I.T.: {0}-{1}-{2}",
                    cuitPer.Substring(0, 2), cuitPer.Substring(2, 8), cuitPer.Substring(10, 1)), _standardFont));
                clCta.AddElement(salto);
                clCta.AddElement(new Phrase(string.Format("Nro. de cuenta: {0}", lstCta[0].NRO_CTA), _standardFont));
                clCta.AddElement(salto);

                tblPrpietario.AddCell(clProp);
                tblPrpietario.AddCell(clCta);
                doc.Add(tblPrpietario);
                #endregion

                //DETALLE FACTURA
                PdfPTable tblTitDetalle = new PdfPTable(1)
                {
                    WidthPercentage = 100,

                };
                PdfPCell clDetTitulo = new PdfPCell(new Paragraph("Comprobantes cancelados", _encabezado))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10
                };
                tblTitDetalle.AddCell(clDetTitulo);
                doc.Add(tblTitDetalle);
                PdfPTable tblDetalle = new PdfPTable(3)
                {
                    WidthPercentage = 100,

                };

                tblDetalle.SetWidths(new float[] { 70, 15, 15 });
                PdfPCell clCod = new PdfPCell(new Paragraph("Periodo", _standardFont))
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
                PdfPCell clConcepto = new PdfPCell(new Paragraph("Pagado", _standardFont))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10,
                    BackgroundColor = Color.LIGHT_GRAY
                };
                PdfPCell clCantidad = new PdfPCell(new Paragraph("Saldo", _standardFont))
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



                foreach (var item in lstCta)
                {
                    PdfPCell clCodd = new PdfPCell(new Paragraph(item.PERIODOMAQUILLADO.ToString(), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10
                    };
                    PdfPCell clConceptod = new PdfPCell(new Paragraph(string.Format("{0:c}",
                        item.HABER), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        BorderWidthRight = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10,
                    };
                    PdfPCell clCantidadd = new PdfPCell(new Paragraph(string.Format("{0:c}",
                        item.SALDO), _standardFont))
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

                doc.Add(tblDetalle);

                PdfPTable tblTitPagos = new PdfPTable(1)
                {
                    WidthPercentage = 100,

                };

                if (lstCta[0].NRO_PLAN_PAGO != 0)
                {
                    PdfPTable tblDetPlan = new PdfPTable(1)
                    {
                        WidthPercentage = 100,

                    };
                    List<DAL.CTACTE_EXPENSAS> lstPeriodosIncluidos =
DAL.CTACTE_EXPENSAS.readCtasPlan(lstCta[0].NRO_PLAN_PAGO, 1);
                    lstPeriodosIncluidos.AddRange(
                        DAL.CTACTE_EXPENSAS.readCtasPlan(
                            lstCta[0].NRO_PLAN_PAGO, 100));
                    StringBuilder detPlan = new StringBuilder();
                    detPlan.AppendLine("El plan de pago incluye total o parcialmente: ");
                    foreach (var item in lstPeriodosIncluidos)
                    {
                        if (item.TIPO_MOVIMIENTO != 100)
                            detPlan.AppendLine(
                                string.Format("{0} ", getPeriodo(item.PERIODO)));
                        else
                        {
                            DAL.FACTURAS_X_EXPENSA objF =
                                DAL.FACTURAS_X_EXPENSA.getByPk(
                                    item.PTO_VTA,
                                    item.NRO_CTE, 11);
                            detPlan.AppendLine(
                                string.Format("{0} ", objF.DETALLE));
                        }
                    }

                    PdfPCell clDetPlan = new PdfPCell(new Paragraph("" + detPlan.ToString(),
                        _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        BorderWidthLeft = 1f,
                        BorderWidthRight = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10
                    };
                    tblDetPlan.AddCell(clDetPlan);
                    doc.Add(tblDetPlan);


                }

                PdfPCell clPagosTitulo = new PdfPCell(new Paragraph("Forma de pago", _encabezado))
                {
                    BorderWidth = 0,
                    BorderWidthBottom = 1f,
                    BorderWidthLeft = 1f,
                    BorderWidthRight = 1f,
                    PaddingLeft = 10,
                    PaddingBottom = 10,
                    PaddingTop = 10
                };
                tblTitPagos.AddCell(clPagosTitulo);
                doc.Add(tblTitPagos);

                PdfPTable tblDetallePagos = new PdfPTable(4)
                {
                    WidthPercentage = 100,

                };

                tblDetallePagos.SetWidths(new float[] { 55, 15, 15, 15 });
                foreach (var item in lstPagos)
                {
                    PdfPCell clMedioPago = new PdfPCell(new Paragraph(item.MEDIO_PAGO.ToString(), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        BorderWidthLeft = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10
                    };
                    PdfPCell clCheque = new PdfPCell(new Paragraph(string.Format("{0:c}",
                        item.NRO_CHEQUE), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10,
                    };
                    PdfPCell clBanco = new PdfPCell(new Paragraph(string.Format("{0:c}",
                        item.BANCO), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10
                    };

                    PdfPCell clMonto = new PdfPCell(new Paragraph(string.Format("{0:c}",
                        item.MONTO), _standardFont))
                    {
                        BorderWidth = 0,
                        BorderWidthBottom = 1f,
                        BorderWidthRight = 1f,
                        PaddingLeft = 10,
                        PaddingBottom = 10,
                        PaddingTop = 10
                    };

                    tblDetallePagos.AddCell(clMedioPago);
                    tblDetallePagos.AddCell(clCheque);
                    tblDetallePagos.AddCell(clBanco);
                    tblDetallePagos.AddCell(clMonto);
                }

                doc.Add(tblDetallePagos);
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
                    "{0:c}", lstPagos.Sum(f => f.MONTO), _encabezado)))
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