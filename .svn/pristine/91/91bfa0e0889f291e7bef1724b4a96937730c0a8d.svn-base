using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Secure
{
    public partial class Pago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
                scriptManager.RegisterPostBackControl(this.btnLibreDeuda);

                divErrorBilletera.Visible = false;

                if (Request.Cookies["UserVecinoLh"] == null)
                    Response.Redirect("../index.aspx");

                int id = Convert.ToInt32(Request.Cookies["UserVecinoLh"]["Id"]);

                DAL.PERSONAS persona = DAL.PERSONAS.getByPk(id);

                int nroCta = persona.NRO_CTA;
                DateTime fec = Utils.Utils.getFechaActual();

                if (!IsPostBack)
                {
                    string anio = fec.Year.ToString();
                    string mes =
                        fec.Month.ToString().PadLeft(2, Convert.ToChar("0"));
                    string dia =
                        fec.Month.ToString().PadLeft(2, Convert.ToChar("0"));


                    hNroCta.Value = nroCta.ToString();
                    fill(nroCta);

                    fillCta(nroCta, 0);
                    HtmlGenericControl liInmuebles =
    this.Master.FindControl("liInmuebles") as HtmlGenericControl;
                    HtmlGenericControl liExpensas =
                        this.Master.FindControl("liExpensas") as HtmlGenericControl;
                    HtmlGenericControl liConfig =
                        this.Master.FindControl("liConfig") as HtmlGenericControl;

                    DAL.BILLETERA objBilletera = DAL.BILLETERA.getByPk(nroCta);
                    if (objBilletera.SALDO == 0)
                    {
                        divSaldoBilletera.Visible = false;
                    }
                    else
                    {
                        divSaldoBilletera.Visible = true;
                        if (Convert.ToDecimal(lblDeudaPagar.Text) < objBilletera.SALDO)
                        {
                            txtMontoBilleteraEditable.Text = objBilletera.SALDO.ToString();
                            hMontoOriginalBilletera.Value = objBilletera.SALDO.ToString();
                        }
                        else
                        {
                            txtMontoBilleteraEditable.Text = lblDeudaPagar.Text;
                            hMontoOriginalBilletera.Value = lblDeudaPagar.Text;
                        }
                        //addValorBilletera();
                    }

                }

                List<DAL.INFORME_TRANSACCIONES> lst = DAL.INFORME_TRANSACCIONES.getRecibo(nroCta);
                gvComprobantes.DataSource = lst;
                gvComprobantes.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fe_a_b2(int periodo, int nroCta)
        {

        }

        protected void btnFacturar_Click(object sender, EventArgs e)
        {

        }
        private void fill(int nroCta)
        {
            try
            {
                DAL.INMUEBLES obj = BLL.INMUEBLES.getByNroCta(nroCta);


                lblDireccion.InnerHtml = string.Format("{0} n° {1} - Manzana: {2} Lote: {3}",
                                    obj.CALLE, obj.NRO, obj.MANZANA, obj.LOTE);
                lblCta.InnerHtml = string.Format("Cuenta N°: {0}", obj.NRO_CTA);

                List<DAL.PERSONAS_GRILLA> lstP = new List<DAL.PERSONAS_GRILLA>();
                lstP = DAL.PERSONAS_GRILLA.getByNroCta(
                                        obj.NRO_CTA);

                List<DAL.PERSONAS_GRILLA> lstProp = lstP.FindAll(p => p.RELACION == "Propietario");
                List<DAL.PERSONAS_GRILLA> lstInq = lstP.FindAll(p => p.RELACION == "Inquilino");

                string pro = "Propietario/s: ";

                foreach (var item in lstProp)
                {
                    pro += string.Format("{0} ", item.NOMBRE);
                }
                if (lstInq.Count > 0)
                {
                    pro += " - Inquilinos: ";
                    foreach (var item in lstInq)
                    {
                        pro += string.Format("{0} ", item.NOMBRE);
                    }
                }
                lblCatastrales.InnerHtml += pro;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void fillCta(int nrocta, int opcion)
        {
            try
            {
                List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();
                lst = DAL.CTACTE_EXPENSAS.readCtaDeuda2(nrocta);

                gvCtaCte.DataSource = lst;
                gvCtaCte.DataBind();
                if (lst.Count > 0)
                {
                    btnLibreDeuda.Visible = false;
                    gvCtaCte.UseAccessibleHeader = true;
                    gvCtaCte.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                else
                    btnLibreDeuda.Visible = true;

                //divAsiento.Visible = false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            decimal deuda = 0;
            decimal deudaOriginal = 0;
            decimal intereses = 0;
            decimal descPagoTermino = 0;
            int select = 0;
            List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();
            DAL.CTACTE_EXPENSAS obj;
            for (int i = 0; i < gvCtaCte.Rows.Count; i++)
            {
                GridViewRow row = gvCtaCte.Rows[i];
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                bool isChecked = chk.Checked;
                if (isChecked)
                {
                    select++;
                    obj = DAL.CTACTE_EXPENSAS.getByPk(int.Parse(row.Cells[0].Text));
                    intereses += obj.INTERES_MORA;
                    deudaOriginal += obj.MONTO_ORIGINAL;
                    descPagoTermino += obj.DESC_VENCIMIENTO;
                    deuda += obj.SALDO;

                    lst.Add(obj);
                }
            }

            lblDeudaPagar.Text = (deuda - descPagoTermino).ToString();
            lblCantSelecionados.Text = select.ToString();
            lblDesc.Text = descPagoTermino.ToString();
            lblInteresMora.Text = intereses.ToString();
            lblMontoOriginal.Text = deudaOriginal.ToString();
            gvConfirmoPago.DataSource = lst;
            gvConfirmoPago.DataBind();
            UpdatePanel1.Update();
            //if (lst.Count == 0)
            //    divAsiento.Visible = false;
            //else
            //    divAsiento.Visible = true;
        }

        protected void gvCtaCte_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblTipoMov = (Label)e.Row.FindControl("lblTipoMov");

                    DAL.CTACTE_EXPENSAS obj = (DAL.CTACTE_EXPENSAS)e.Row.DataItem;

                    HtmlGenericControl divDet = (HtmlGenericControl)e.Row.FindControl("divDet");
                    //if (obj.PERIODO < 20200400)
                    divDet.Visible = false;

                    CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                    HtmlGenericControl lblCheck = (HtmlGenericControl)e.Row.FindControl("lblCheck");
                    //if (obj.PERIODO == 20190100)
                    //{
                    //    lblCheck.Visible = false;
                    //    chkSelect.Visible = false;
                    //}
                    //if (obj.PERIODO == 20191212)
                    //{
                    //    lblCheck.Visible = false;
                    //    chkSelect.Visible = false;
                    //}
                    if (obj.ESTADO == 0)
                    {
                        lblCheck.Visible = false;
                        chkSelect.Visible = false;
                    }
                    int rowIndex = 0;
                    if (obj.NRO_RECIBO_PAYPERTIC != 0)
                    {
                        DAL.PAGOS_PAYPERTIC objPay = DAL.PAGOS_PAYPERTIC.getByPk(
                            obj.NRO_RECIBO_PAYPERTIC);
                        HtmlGenericControl divPeriodo2 = (HtmlGenericControl)e.Row.FindControl("divPeriodo2");

                        if (objPay.ESTADO == "approved")
                        {
                            rowIndex = e.Row.RowIndex;
                            e.Row.Visible = false;
                        }
                        else
                        {
                            if (objPay.HASH_TRANSACCION != string.Empty)
                            {
                                PayPerTic.Notificaciones.Noti consulta =
                                PayPerTic.SolicitudPago.SolicitudPago.CosultaPago(
                                objPay.HASH_TRANSACCION);
                                if (consulta == null)
                                {
                                    divPeriodo2.InnerHtml += "<strong style=\"color:red;\">Hubo un intento de pago previo y no pudimos procesar la consulta. Intente de nuevo mas tarde</strong>";
                                    chkSelect.Visible = false;
                                    lblCheck.Visible = false;
                                    return;
                                }
                                switch (consulta.status)
                                {
                                    case "approved":

                                        rowIndex = e.Row.RowIndex;
                                        e.Row.Visible = false;
                                        break;
                                    case "overdue":
                                        DAL.PAGOS_PAYPERTIC.updateDEN(
                                            int.Parse(consulta.external_transaction_id), consulta.status);
                                        DAL.CTACTE_EXPENSAS.setPayPerTic(obj.ID, 0);
                                        break;
                                    case "rejected":
                                        DAL.PAGOS_PAYPERTIC.updateDEN(
                                            int.Parse(consulta.external_transaction_id), consulta.status);
                                        DAL.CTACTE_EXPENSAS.setPayPerTic(obj.ID, 0);
                                        break;
                                    case "cancelled":
                                        DAL.PAGOS_PAYPERTIC.updateDEN(
                                            int.Parse(consulta.external_transaction_id), consulta.status);
                                        DAL.CTACTE_EXPENSAS.setPayPerTic(obj.ID, 0);
                                        break;
                                    case "refunded":
                                        DAL.PAGOS_PAYPERTIC.updateDEN(
                                            int.Parse(consulta.external_transaction_id), consulta.status);
                                        DAL.CTACTE_EXPENSAS.setPayPerTic(obj.ID, 0);
                                        break;
                                    default:
                                        chkSelect.Visible = false;
                                        divPeriodo2.InnerHtml += "<strong style=\"color:red;\"> Tiene una solicitud de pago pendiente, complete la solicitud o intente nuevamente en 10 minútos</strong>";
                                        lblCheck.Visible = false;
                                        break;
                                }
                            }
                            else
                            {
                                DAL.PAGOS_PAYPERTIC.updateDEN(
                                            obj.NRO_RECIBO_PAYPERTIC, "SIN HASH");
                                DAL.CTACTE_EXPENSAS.setPayPerTic(obj.ID, 0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        private List<DAL.CTACTE_EXPENSAS> leerGrilla()
        {
            List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();
            for (int i = 0; i < gvConfirmoPago.Rows.Count; i++)
            {
                GridViewRow row = gvConfirmoPago.Rows[i];
                int id = Convert.ToInt32(gvConfirmoPago.DataKeys[i].Values["ID"]);
                DAL.CTACTE_EXPENSAS obj = DAL.CTACTE_EXPENSAS.getByPk(id);

                lst.Add(obj);
            }
            //txtTot.Text = tot.ToString();
            return lst;
        }
        protected void btnPagar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //try
            //{
            //btnPagar.Visible = false;
            //string url = PayPerTic.SolicitudPago.SolicitudPago.pago(leerGrilla(),
            //Convert.ToInt32(Request.Cookies["UserVecinoLh"]["Id"]));
            //fillCta(int.Parse(hNroCta.Value), 0);
            //string _open = "window.open('" + url + "', '_blank');";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

            DateTime timeUtc = DateTime.UtcNow;

            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            Console.WriteLine("The date and time are {0} {1}.",
                              cstTime,
                              cstZone.IsDaylightSavingTime(cstTime) ?
                                      cstZone.DaylightName : cstZone.StandardName);

            string url =

                    PayPerTic.SolicitudPago.SolicitudPago.pago(leerGrilla(),
                    Convert.ToInt32(Request.Cookies["UserVecinoLh"]["Id"]));

            //lblDireccion.InnerHtml = url;
            Response.Redirect(url);
            //}
            //catch (Exception ex)
            //{

            //    txtTotDetalle.InnerText = ex.Message;
            //}


            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        protected void btnLibreDeuda_ServerClick(object sender, EventArgs e)
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
            DateTime timeUtc = DateTime.UtcNow;
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            DateTime FechaActual = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

            int nroCta = Convert.ToInt32(hNroCta.Value);
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition",
                "attachment; filename=" + "Libre deuda cta " + nroCta + " " +
                FechaActual.ToShortDateString() + ".pdf");

            Response.BinaryWrite(strS);
            Response.End();
            Response.Flush();
            Response.Clear();
        }
        private byte[] CreatePDF2()
        {
            int nroCta = Convert.ToInt32(hNroCta.Value);
            Document doc = new Document(PageSize.LETTER, 50, 50, 50, 50);

            Paragraph salto = new Paragraph();

            salto.SpacingAfter = 10;
            using (MemoryStream output = new MemoryStream())
            {
                PdfWriter wri = PdfWriter.GetInstance(doc, output);
                doc.Open();
                iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 10,
                    iTextSharp.text.Font.NORMAL, Color.BLACK);
                iTextSharp.text.Font _encabezado = new iTextSharp.text.Font(iTextSharp.text.Font.HELVETICA, 12,
                    iTextSharp.text.Font.BOLD, Color.BLACK);


                iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(
                    Server.MapPath("../img/" + "logo.png"));

                //ENCABEZADO
                PdfPTable tblEncabezado = new PdfPTable(2)
                {
                    WidthPercentage = 100
                };
                PdfPCell clLogo = new PdfPCell()
                {
                    Image = png,
                    BorderWidth = 0
                };
                PdfPCell clLogo2 = new PdfPCell(new Paragraph("", _standardFont))
                {
                    BorderWidth = 0,
                };
                tblEncabezado.AddCell(clLogo);
                tblEncabezado.AddCell(clLogo2);

                doc.Add(tblEncabezado);
                doc.Add(salto);
                doc.Add(salto);
                //PROPIETARIO - CUENTA
                PdfPTable tblVAllende = new PdfPTable(1)
                {
                    WidthPercentage = 100

                };
                string mes = string.Empty;
                switch (Utils.Utils.getFechaActual().Month)
                {
                    case 1:
                        mes = "Enero";
                        break;
                    case 2:
                        mes = "Febrero";
                        break;
                    case 3:
                        mes = "Marzo";
                        break;
                    case 4:
                        mes = "Abril";
                        break;
                    case 5:
                        mes = "Mayo";
                        break;
                    case 6:
                        mes = "Junio";
                        break;
                    case 7:
                        mes = "Julio";
                        break;
                    case 8:
                        mes = "Agosto";
                        break;
                    case 9:
                        mes = "Septiembre";
                        break;
                    case 10:
                        mes = "Octubre";
                        break;
                    case 11:
                        mes = "Noviembre";
                        break;
                    case 12:
                        mes = "Diciembre";
                        break;
                    default:
                        break;
                }
                DateTime fec = Utils.Utils.getFechaActual();
                PdfPCell clProp = new PdfPCell(new Paragraph(string.Format(
                    "Villa Allende, {0} de {1} de {2}",
                    fec.Day, mes, fec.Year), _standardFont))
                {
                    BorderWidth = 0,
                    HorizontalAlignment = 2
                };
                tblVAllende.AddCell(clProp);
                doc.Add(tblVAllende);

                PdfPTable tblTexto = new PdfPTable(1)
                {
                    WidthPercentage = 100
                };

                PdfPCell clTexto1 = new PdfPCell(new Paragraph("Por la presente:", _standardFont))
                {
                    BorderWidth = 0,
                };
                tblTexto.AddCell(clTexto1);
                doc.Add(salto);
                doc.Add(salto);
                doc.Add(salto);
                doc.Add(salto);
                doc.Add(tblTexto);
                PdfPTable tblTexto2 = new PdfPTable(1)
                {
                    WidthPercentage = 100
                };
                string propietarios = string.Empty;
                string cuitPer = string.Empty;
                List<DAL.PERSONAS_GRILLA> lstPer = DAL.PERSONAS_GRILLA.getByNroCta(nroCta);
                DAL.INMUEBLES objInm = DAL.INMUEBLES.getByNroCta(nroCta);
                foreach (var item in lstPer)
                {
                    if (item.RESPONSABLE_FACTURACION)
                    {
                        propietarios += string.Format("Propietario/s: {0}, ", item.NOMBRE);
                    }
                }
                foreach (var item in lstPer)
                {
                    if (item.RELACION == "Inquilino")
                    {
                        propietarios += string.Format("(Inquilinos: {0}), ", item.NOMBRE);
                    }
                }
                doc.Add(salto);
                Paragraph p1 = new Paragraph(25, string.Format(
                    "                La ASOCIACION CIVIL LA HERRADURA certifica que el/los {0} con Domicilio en {1} {2} - Manzana: {3} Lote: {4}, no adeuda expensas al día de la fecha.",
                    propietarios, objInm.CALLE, objInm.NRO, objInm.MANZANA, objInm.LOTE), _standardFont)
                {
                    SpacingAfter = 25
                };

                PdfPCell clTexto2 = new PdfPCell(p1)
                {
                    BorderWidth = 0
                };

                clTexto2.SetLeading(2, 2);
                tblTexto2.AddCell(clTexto2);
                doc.Add(tblTexto2);

                PdfPTable tblTexto3 = new PdfPTable(1)
                {
                    WidthPercentage = 100
                };
                Paragraph p2 = new Paragraph(25, "Se expide el siguiente certificado para ser presentado a quien corresponda.", _standardFont)
                {
                    SpacingAfter = 25
                };

                PdfPCell clTexto3 = new PdfPCell(p2)
                {
                    BorderWidth = 0
                };

                clTexto3.SetLeading(2, 2);
                tblTexto3.AddCell(clTexto3);

                doc.Add(tblTexto3);

                PdfPTable tblTexto4 = new PdfPTable(1)
                {
                    WidthPercentage = 100
                };
                Paragraph p4 = new Paragraph(25, "Atentamente,", _standardFont)
                {
                    SpacingAfter = 25
                };

                PdfPCell clTexto4 = new PdfPCell(p4)
                {
                    BorderWidth = 0
                };

                clTexto4.SetLeading(2, 2);
                tblTexto4.AddCell(clTexto4);

                doc.Add(tblTexto4);

                PdfPTable tblTexto5 = new PdfPTable(1)
                {
                    WidthPercentage = 100
                };
                Paragraph p5 = new Paragraph(25, "                La Administración", _standardFont)
                {
                    SpacingAfter = 25
                };

                PdfPCell clTexto5 = new PdfPCell(p5)
                {
                    BorderWidth = 0
                };

                clTexto5.SetLeading(2, 2);
                tblTexto5.AddCell(clTexto5);

                doc.Add(tblTexto5);

                doc.Close();
                return output.ToArray();
            }
        }

        private PdfPCell addRow(float interlineado, string texto, Font fuente)
        {
            try
            {
                PdfPCell tabla = new PdfPCell();

                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvComprobantes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.INFORME_TRANSACCIONES obj = (DAL.INFORME_TRANSACCIONES)e.Row.DataItem;
                    List<DAL.CTACTE_EXPENSAS> lst = DAL.CTACTE_EXPENSAS.getByRecibo2(Convert.ToInt32(
                        obj.NRO_RECIBO_PAGO));

                    HtmlGenericControl divComprobantes = (HtmlGenericControl)e.Row.FindControl("divComprobantes");

                    HtmlGenericControl box = new HtmlGenericControl();
                    box.TagName = "div";
                    box.Attributes.Add("class", "info-box");

                    HtmlGenericControl spanImage = new HtmlGenericControl();
                    spanImage.TagName = "span";
                    spanImage.Attributes.Add("class", "info-box-icon bg-green");
                    spanImage.InnerHtml = "<i style=\"color:red; font-size:48px;\" class=\"fa fa-file-pdf-o\"></i>";

                    HtmlAnchor a = new HtmlAnchor();
                    a.HRef = string.Format("../Back/Reportes/Recibo.aspx?nroRecibo={0}", obj.NRO_RECIBO_PAGO);
                    a.Target = "_BLANK";

                    a.Controls.Add(spanImage);
                    box.Controls.Add(a);

                    HtmlGenericControl html = new HtmlGenericControl();
                    html.TagName = "div";
                    html.Attributes.Add("class", "info-box-content");

                    HtmlGenericControl spanText = new HtmlGenericControl();
                    spanText.TagName = "span";
                    spanText.Attributes.Add("class", "info-box-text");
                    spanText.InnerHtml = string.Format(
                        "<strong>Recibo Nro: {0}</strong><br><small style=\"white-space: pre-wrap;\">(",
                        obj.NRO_RECIBO_PAGO);

                    foreach (var item in lst)
                    {
                        spanText.InnerHtml += string.Format("{0} - ",
                            item.PERIODOMAQUILLADO);
                    }

                    html.Controls.Add(spanText);
                    spanText.InnerHtml = spanText.InnerHtml.Remove(spanText.InnerHtml.Length - 2, 2);
                    spanText.InnerHtml += ")</small>";
                    HtmlGenericControl spanMonto = new HtmlGenericControl();
                    spanMonto.TagName = "span";
                    spanMonto.Attributes.Add("class", "info-box-number");
                    spanMonto.InnerHtml = string.Format("{0:c}", obj.MONTO);
                    html.Controls.Add(spanMonto);

                    box.Controls.Add(html);

                    divComprobantes.Controls.Add(box);
                    /*


            <div class="info-box-content">
              <span class="">Recibo Nro: 716 <br><small>(Expensas ordinarias mes de junio de 2020)</small></span>
              <span class="">$11.150</span>
            </div>
            <!-- /.info-box-content -->
          </div>    
                 */
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtMontoBilleteraEditable_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal monto = Convert.ToDecimal(txtMontoBilleteraEditable.Text);
                decimal maximo = Convert.ToDecimal(hMontoOriginalBilletera.Value);
                if (monto > maximo)
                {
                    divErrorBilletera.Visible = true;
                    lblMsgErrorBilletera.InnerHtml = string.Format("El monto ingresado es mayor al monto disponible para utilizar ({0:c})",
                        hMontoOriginalBilletera.Value);
                    txtMontoBilleteraEditable.Text = maximo.ToString();
                }
                else
                {
                    //removeValorBilletera();
                    txtMontoBilleteraEditable.Text = monto.ToString();
                    //addValorBilletera();
                    chkSelect.Enabled = true;
                    txtMontoBilleteraEditable.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                lblMsgErrorBilletera.InnerHtml = ex.Message;
                divErrorBilletera.Visible = true;
            }
        }

        protected void chkSelect_CheckedChanged1(object sender, EventArgs e)
        {
            try
            {
                if (chkSelect.Checked)
                {
                    //addValorBilletera();
                    //txtMontoBilleteraEditable.Enabled = true;
                }
                else
                {
                    //removeValorBilletera();
                    //txtMontoBilleteraEditable.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblMsgErrorBilletera.InnerHtml = ex.Message;
                divErrorBilletera.Visible = true;
            }
        }

    }
}