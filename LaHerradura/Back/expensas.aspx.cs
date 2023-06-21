﻿using LaHerradura.FEProd;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class index : System.Web.UI.Page
    {
        //CARGA PAGINA
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divErrorEx.Visible = false;
                HtmlGenericControl liInmuebles =
                    this.Master.FindControl("liInmuebles") as HtmlGenericControl;
                HtmlGenericControl liExpensas =
                    this.Master.FindControl("liExpensas") as HtmlGenericControl;
                HtmlGenericControl liConfig =
                    this.Master.FindControl("liConfig") as HtmlGenericControl;

                liInmuebles.Attributes.Remove("class");
                liExpensas.Attributes.Remove("class");
                liConfig.Attributes.Remove("class");

                liExpensas.Attributes.Add("class", "active");

                if (!IsPostBack)
                {
                    fillLiquidaciones();
                    fillConceptosAsignar();
                }

                DAL.USUARIOS obj =
DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));

                if (obj.ROL == 3)
                {
                    divAcciones.Visible = false;

                }
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }
        //CARGA LA GRILLA DE CONCEPTOS MASIVOS QUE PUEDEN AGREGARSE A LA EXPENSA
        private void fillConceptosAsignar()
        {
            try
            {
                List<DAL.CONCEPTOS_EXPENSA> lst = BLL.CONCEPTOS_EXPENSA.readActivos(1);
                gvConseptosAsignar.DataSource = lst;
                gvConseptosAsignar.DataBind();
                if (lst.Count > 0)
                {
                    gvConseptosAsignar.UseAccessibleHeader = true;
                    gvConseptosAsignar.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }

        }
        //CARGA LA GRILLA DE LIQUIDACIONES DE EXPENSAS
        private void fillLiquidaciones()
        {
            try
            {
                List<DAL.LIQUIDACION_EXPENSAS> lst = BLL.LIQUIDACION_EXPENSAS.read();
                gvLiquidaciones.DataSource = lst;
                gvLiquidaciones.DataBind();
                if (lst.Count > 0)
                {
                    hPeriodo.Value = (lst[lst.Count - 1].PERIODO + 1).ToString();
                    hMonto1.Value = lst[lst.Count - 1].MONTO_1.ToString();
                    hMonto2.Value = lst[lst.Count - 1].MONTO_2.ToString();
                    hMonto3.Value = lst[lst.Count - 1].MONTO_3.ToString();

                    hVenc1.Value = string.Format("{0}-{1}-{2}",
                        lst[lst.Count - 1].VENCIMIENTO_1.Year,
                        (lst[lst.Count - 1].VENCIMIENTO_1.Month + 1).ToString().PadLeft(
                            2, Convert.ToChar("0")),
                            (lst[lst.Count - 1].VENCIMIENTO_1.Day.ToString().PadLeft(
                            2, Convert.ToChar("0"))));

                    hVenc2.Value = string.Format("{0}-{1}-{2}",
                        lst[lst.Count - 1].VENCIMIENTO_2.Year,
                        (lst[lst.Count - 1].VENCIMIENTO_2.Month + 1).ToString().PadLeft(
                            2, Convert.ToChar("0")),
                            (lst[lst.Count - 1].VENCIMIENTO_2.Day.ToString().PadLeft(
                            2, Convert.ToChar("0"))));

                    hVenc3.Value = string.Format("{0}-{1}-{2}",
                        lst[lst.Count - 1].VENCIMIENTO_3.Year,
                        (lst[lst.Count - 1].VENCIMIENTO_3.Month + 1).ToString().PadLeft(
                            2, Convert.ToChar("0")),
                            (lst[lst.Count - 1].VENCIMIENTO_3.Day.ToString().PadLeft(
                            2, Convert.ToChar("0"))));

                    hAlicuota.Value = lst[lst.Count - 1].ALICUOTA_INTERES.ToString();
                }
                else
                {
                    hPeriodo.Value = (LaHerradura.Utils.Utils.getFechaActual().Year.ToString() + "0100").ToString();
                }
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }

        protected void gvLiquidaciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl periodo = (HtmlGenericControl)e.Row.FindControl("periodo");
                    DAL.LIQUIDACION_EXPENSAS obj = (DAL.LIQUIDACION_EXPENSAS)e.Row.DataItem;

                    HtmlGenericControl btnVer = (HtmlGenericControl)e.Row.FindControl("btnVer");
                    HtmlGenericControl btnEditar = (HtmlGenericControl)e.Row.FindControl("btnEditar");
                    HtmlGenericControl btnCargarConcepto = (HtmlGenericControl)e.Row.FindControl("btnCargarConcepto");
                    LinkButton btnLiquidar = (LinkButton)e.Row.FindControl("btnLiquidar");
                    LinkButton btnBorrar = (LinkButton)e.Row.FindControl("btnBorrar");
                    HtmlGenericControl divFactura = (HtmlGenericControl)e.Row.FindControl("divFactura");
                    //LinkButton btnFacturar = (LinkButton)e.Row.FindControl("btnFacturar");
                    LinkButton btnEnviarMail = (LinkButton)e.Row.FindControl("btnEnviarMail");
                    LinkButton btnBorrarDetalle = (LinkButton)e.Row.FindControl("btnBorrarDetalle");
                    LinkButton btnBanelco = (LinkButton)e.Row.FindControl("btnBanelco");
                    HtmlGenericControl btnDetalle = (HtmlGenericControl)e.Row.FindControl("btnDetalle");
                    HtmlGenericControl btnVerDet = (HtmlGenericControl)e.Row.FindControl("btnVerDet");
                    LinkButton btnCodBarra = (LinkButton)e.Row.FindControl("btnCodBarra");
                    switch (obj.ESTADO)
                    {
                        case 0:
                            btnVer.Visible = true;
                            btnEditar.Visible = true;
                            btnCargarConcepto.Visible = true;
                            btnLiquidar.Visible = true;
                            btnBorrar.Visible = true;
                            divFactura.Visible = false;
                            //btnFacturar.Visible = false;
                            btnEnviarMail.Visible = false;
                            btnBorrarDetalle.Visible = false;
                            btnDetalle.Visible = false;
                            btnBanelco.Visible = false;
                            break;
                        case 1:
                            btnVer.Visible = true;
                            btnEditar.Visible = false;
                            btnCargarConcepto.Visible = false;
                            btnLiquidar.Visible = false;
                            btnBorrar.Visible = false;
                            divFactura.Visible = true;
                            //btnFacturar.Visible = true;
                            btnEnviarMail.Visible = false;
                            btnBorrarDetalle.Visible = true;
                            btnDetalle.Visible = true;
                            btnBanelco.Visible = false;
                            break;
                        case 2:
                            btnVer.Visible = true;
                            btnEditar.Visible = false;
                            btnCargarConcepto.Visible = false;
                            btnLiquidar.Visible = false;
                            btnBorrar.Visible = false;
                            divFactura.Visible = false;
                            //btnFacturar.Visible = false;
                            btnEnviarMail.Visible = true;
                            btnBorrarDetalle.Visible = false;
                            btnDetalle.Visible = true;
                            btnBanelco.Visible = true;
                            break;
                        default:
                            break;
                    }
                    if (periodo != null)
                    {
                        if (obj.PERIODO != 20190100)
                        {
                            if (obj.PERIODO.ToString().Substring(6, 2) == "00")
                                periodo.InnerHtml = string.Format("{0}-{1} Ordinaria",
                                    obj.PERIODO.ToString().Substring(0, 4),
                                    obj.PERIODO.ToString().Substring(4, 2));
                            else
                            {
                                periodo.InnerHtml = string.Format("{0}-{1} Extraordinaria",
                                    obj.PERIODO.ToString().Substring(0, 4),
                                    obj.PERIODO.ToString().Substring(4, 2));
                            }
                        }
                        else
                        {
                            periodo.InnerHtml = "Saldo (capital) a Sept. 2019";
                        }

                    }
                    if (obj.PERIODO < 20200400)
                    {
                        btnVer.Visible = false;
                        btnEditar.Visible = false;
                        btnCargarConcepto.Visible = false;
                        btnLiquidar.Visible = false;
                        btnBorrar.Visible = false;
                        divFactura.Visible = false;
                        //btnFacturar.Visible = false;
                        btnEnviarMail.Visible = false;
                        btnBorrarDetalle.Visible = false;
                        btnDetalle.Visible = true;
                        btnBanelco.Visible = false;
                        btnVerDet.Visible = false;
                        btnCodBarra.Visible = false;
                    }
                    List<DAL.CONCEPTOS_X_LIQUIDACION> lst = DAL.CONCEPTOS_X_LIQUIDACION.read(obj.PERIODO);

                    GridView gvDetails = (GridView)e.Row.FindControl("gvDetails");
                    gvDetails.DataSource = lst;
                    gvDetails.DataBind();

                    DAL.USUARIOS objUsu = DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));

                    HtmlGenericControl ulBotonesAdmin = (HtmlGenericControl)
                        e.Row.FindControl("ulBotonesAdmin");
                    HtmlGenericControl ulBotonesEstudio = (HtmlGenericControl)
                        e.Row.FindControl("ulBotonesEstudio");

                    if (objUsu.ROL == 3)
                    {
                        ulBotonesAdmin.Visible = false;
                        ulBotonesEstudio.Visible = true;
                    }
                    else
                    {
                        ulBotonesAdmin.Visible = true;
                        ulBotonesEstudio.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }
        //CREA O MODIFICA UNA EXXPENSA
        protected void btnAceptarExpensa_ServerClick(object sender, EventArgs e)
        {
            try
            {
                DAL.LIQUIDACION_EXPENSAS obj;
                if (hAccion.Value == "edita")
                {
                    obj = BLL.LIQUIDACION_EXPENSAS.getByPk(int.Parse(hPeriodo.Value));
                    obj.ALICUOTA_INTERES = Convert.ToDecimal(txtAlic.Text);
                    obj.MONTO_1 = Convert.ToDecimal(txtMonto1.Text);
                    obj.MONTO_2 = Convert.ToDecimal(txtMonto2.Text);
                    obj.MONTO_3 = Convert.ToDecimal(txtMonto3.Text);
                    obj.VENCIMIENTO_1 = Convert.ToDateTime(txtVenc1.Text);
                    obj.VENCIMIENTO_2 = Convert.ToDateTime(txtVenc2.Text);
                    obj.VENCIMIENTO_3 = Convert.ToDateTime(txtVenc3.Text);
                    DAL.LIQUIDACION_EXPENSAS.update(obj,
                        int.Parse(txtAnio.Text + DDLMes.SelectedItem.Value +
                        DDLTipoExpesa.SelectedItem.Value));

                    DAL.CONCEPTOS_X_LIQUIDACION.update(obj.PERIODO,
    obj.MONTO_3, 1);                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
                    fillLiquidaciones();
                }
                if (hAccion.Value == "crea")
                {
                    obj = new DAL.LIQUIDACION_EXPENSAS();
                    obj.ALICUOTA_INTERES = Convert.ToDecimal(txtAlic.Text);
                    obj.MONTO_1 = Convert.ToDecimal(txtMonto1.Text);
                    obj.MONTO_2 = Convert.ToDecimal(txtMonto2.Text);
                    obj.MONTO_3 = Convert.ToDecimal(txtMonto3.Text);
                    obj.VENCIMIENTO_1 = Convert.ToDateTime(txtVenc1.Text);
                    obj.VENCIMIENTO_2 = Convert.ToDateTime(txtVenc2.Text);
                    obj.VENCIMIENTO_3 = Convert.ToDateTime(txtVenc3.Text);
                    obj.PERIODO = int.Parse(txtAnio.Text + DDLMes.SelectedItem.Value +
                        DDLTipoExpesa.SelectedItem.Value);
                    obj.ESTADO = 0;
                    obj.USUARIO_GENERA = Convert.ToInt32(Request.Cookies["UserLh"]["Id"]);
                    BLL.LIQUIDACION_EXPENSAS.insert(obj);

                    fillLiquidaciones();
                }
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }

        protected void gvConseptosAsignar_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvConseptosAsignar_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblSuma = (Label)e.Row.FindControl("lblSuma");
                    Label lblMonto = (Label)e.Row.FindControl("lblMonto");
                    DAL.CONCEPTOS_EXPENSA obj = (DAL.CONCEPTOS_EXPENSA)e.Row.DataItem;
                    if (obj.SUMA)
                        lblSuma.Text = "Cargo";
                    else
                        lblSuma.Text = "Descuento";
                    if (obj.MONTO != 0)
                        lblMonto.Text = string.Format("$ {0}", obj.MONTO);
                    else
                        lblMonto.Text = (string.Format("{0} %", obj.PORCENTAJE));

                }

            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }

        protected void btnAceptarConcepto_ServerClick(object sender, EventArgs e)
        {
            try
            {
                //BLL.CONCEPTOS_EXPENSA.insertMasivo(int.Parse(hIdServicio.Value),
                //    int.Parse(txtCantConcept.Value), Convert.ToDateTime(
                //        txtFecha.Value), txtObsConcepto.Text, int.Parse(hPeriodoModal.Value), 1);

                DAL.CONCEPTOS_EXPENSA objC = DAL.CONCEPTOS_EXPENSA.getByPk(int.Parse(hIdServicio.Value));
                DAL.CONCEPTOS_X_LIQUIDACION obj = new DAL.CONCEPTOS_X_LIQUIDACION();
                obj.CANT = int.Parse(txtCantConcept.Value);
                obj.FECHA_CARGA = LaHerradura.Utils.Utils.getFechaActual();
                obj.ID_CONCEPTO = int.Parse(hIdServicio.Value);
                obj.MONTO = objC.MONTO;
                obj.NRO_ORDEN = DAL.CONCEPTOS_X_LIQUIDACION.getMaxOrden(int.Parse(hPeriodoModal.Value)) + 1;
                obj.OBS = txtObsConcepto.Text;
                obj.PERIODO = int.Parse(hPeriodoModal.Value);
                obj.USUARIO_CARGA = Convert.ToInt32(Request.Cookies["UserLh"]["Id"]);
                DAL.CONCEPTOS_X_LIQUIDACION.insert(obj);
                fillLiquidaciones();
                //fillConceptosAsignados();
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }
        decimal total = 0;
        decimal cant = 0;
        decimal preunit = 0;
        protected void gvDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl btnEliminar =
                        (HtmlGenericControl)e.Row.FindControl("btnEliminar");
                    DAL.CONCEPTOS_X_LIQUIDACION obj =
                        (DAL.CONCEPTOS_X_LIQUIDACION)e.Row.DataItem;
                    DAL.LIQUIDACION_EXPENSAS objLiq =
                        DAL.LIQUIDACION_EXPENSAS.getByPk(obj.PERIODO);



                    if (objLiq.ESTADO == 0)
                    {
                        if (obj.ID_CONCEPTO == 1)
                            btnEliminar.Visible = false;
                        else
                            btnEliminar.Visible = true;
                    }
                    else
                        btnEliminar.Visible = false;

                    cant = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CANT"));
                    preunit = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "MONTO"));
                    total += cant * preunit;
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[4].Text = "Total:";
                    e.Row.Cells[5].Text = total.ToString("c");
                    e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Font.Bold = true;
                    total = 0;
                }
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }

        }

        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "eliminar")
                {
                    GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                    GridView gv = (GridView)gvRow.NamingContainer;
                    int rowIndex = gvRow.RowIndex;
                    int PERIODO = Convert.ToInt32(gv.DataKeys[gvRow.RowIndex].Values["PERIODO"]);
                    int ID_CONCEPTO = Convert.ToInt32(gv.DataKeys[gvRow.RowIndex].Values["ID_CONCEPTO"]);
                    DAL.CONCEPTOS_X_LIQUIDACION.delete(PERIODO, ID_CONCEPTO);
                    fillLiquidaciones();
                }
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }

        }

        protected void btnEliminarConcepto_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.EXCLUSION_CONCEPTO.delete(int.Parse(hPeriodoElimina.Value), int.Parse(hConceptoElimina.Value));
                DAL.CONCEPTOS_X_LIQUIDACION.delete(int.Parse(hPeriodoElimina.Value), int.Parse(hConceptoElimina.Value));

            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }

        protected void gvLiquidaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                if (e.CommandName == "borrar")
                {
                    DAL.LIQUIDACION_EXPENSAS.delete(Convert.ToInt32(e.CommandArgument));
                }
                if (e.CommandName == "liquidar")
                {
                    BLL.CTACTE_EXPENSAS.liquida(Convert.ToInt32(e.CommandArgument));
                }
                if (e.CommandName == "borrarDetalle")
                {
                    BLL.LIQUIDACION_EXPENSAS.delete(Convert.ToInt32(e.CommandArgument));
                }
                if (e.CommandName == "facturar")
                {
                    Service fe = new Service();

                    fe_a_b2(Convert.ToInt32(e.CommandArgument),
                        Convert.ToDateTime(txtFechaFactura.Text));
                }
                if (e.CommandName == "banelco")
                {
                    string fileName = string.Format("fac3120.{0}{1}{2}",
                    fec.Day.ToString().PadLeft(2, Convert.ToChar("0")),
                    fec.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                    fec.Year.ToString().Substring(2, 2));

                    if (File.Exists(Server.MapPath(".") + "/" + fileName))
                        File.Delete(Server.MapPath(".") + "/" + fileName);

                    StreamWriter arch =
                        new StreamWriter(Server.MapPath(".") + "/" + fileName, true);

                    arch.Write(LaHerradura.Banelco.ArchivoFacturacion.crear(
                        Convert.ToInt32(e.CommandArgument)));
                    arch.Close();

                    DescargarDocumento(fileName);
                }
                if (e.CommandName == "macro")
                {
                    string fileName = string.Format("macro.{0}{1}{2}",
                    fec.Day.ToString().PadLeft(2, Convert.ToChar("0")),
                    fec.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                    fec.Year.ToString().Substring(2, 2));

                    if (File.Exists(Server.MapPath(".") + "/" + fileName))
                        File.Delete(Server.MapPath(".") + "/" + fileName);

                    StreamWriter arch =
                        new StreamWriter(Server.MapPath(".") + "/" + fileName, true);

                    arch.WriteLine(LaHerradura.Macro.ArchivoFacturacion.crear(
                        Convert.ToInt32(e.CommandArgument), fec));
                    arch.Close();

                    DescargarDocumento(fileName);
                }
                if (e.CommandName == "codBarra")
                {
                    List<DAL.CTACTE_EXPENSAS> lst = DAL.CTACTE_EXPENSAS.read(Convert.ToInt32(e.CommandArgument));
                    DAL.LIQUIDACION_EXPENSAS obj = DAL.LIQUIDACION_EXPENSAS.getByPk(Convert.ToInt32(e.CommandArgument));
                    TimeSpan diasMora2 = obj.VENCIMIENTO_2 - obj.VENCIMIENTO_1;
                    TimeSpan diasMora3 = obj.VENCIMIENTO_3 - obj.VENCIMIENTO_1;
                    foreach (var item in lst)
                    {
                        if (item.PTO_VTA != 0)
                        {
                            string codBarra = LaHerradura.RapiPago.CodigoBarra.getCodigoBarra(
                                item.NRO_CTA,
                                item.PTO_VTA,
                                item.NRO_CTE,
                                item.MONTO_ORIGINAL - obj.MONTO_3 + obj.MONTO_1,
                                obj.VENCIMIENTO_1,
                                obj.MONTO_2 - obj.MONTO_1,
                                diasMora2.Days,
                                obj.MONTO_3 - obj.MONTO_1,
                                diasMora3.Days);
                            DAL.CTACTE_EXPENSAS.setCodBarra(item.ID, codBarra);
                        }
                    }
                }
                if (e.CommandName == "enviarMail")
                {
                    List<DAL.CTACTE_EXPENSAS> lst = DAL.CTACTE_EXPENSAS.read(
                        Convert.ToInt32(e.CommandArgument));
                    foreach (var item in lst)
                    {
                        List<string> lstMail = new List<string>();
                        List<DAL.MAIL_X_CTAS> ls = DAL.MAIL_X_CTAS.getByCta(item.NRO_CTA);
                        foreach (var item2 in ls)
                        {
                            lstMail.Add(item2.MAIL);
                        }

                        mail.envioExpensas(
                            lstMail,
                            item.NOMBRE,
                            Convert.ToInt32(e.CommandArgument),
                            item.NRO_CTA, item.ID);

                    }
                }

                if (e.CommandName == "enviarMailnoEnviados")
                {
                    List<DAL.CTACTE_EXPENSAS> lst = DAL.CTACTE_EXPENSAS.readCtas_email_no_enviados(
                        Convert.ToInt32(e.CommandArgument));
                    foreach (var item in lst)
                    {
                        List<string> lstMail = new List<string>();
                        List<DAL.MAIL_X_CTAS> ls = DAL.MAIL_X_CTAS.getByCta(item.NRO_CTA);
                        foreach (var item2 in ls)
                        {
                            lstMail.Add(item2.MAIL);
                        }
                    
                        mail.envioExpensas(
                            lstMail,
                            item.NOMBRE,
                            Convert.ToInt32(e.CommandArgument),
                            item.NRO_CTA, item.ID);

                    }
                }



                fillLiquidaciones();
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }

        private void DescargarDocumento(String fileNme)
        {
            try
            {
                String prueba;
                fileNme = Server.MapPath("/" + fileNme);
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                prueba = Path.GetFileName(fileNme).ToString();
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + prueba);

                HttpContext.Current.Response.WriteFile(prueba);
                HttpContext.Current.Response.End();


            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }

        private void fe_a_b2(int periodo, DateTime fecha)
        {
            try
            {
                List<DAL.CTACTE_EXPENSAS> lst = DAL.CTACTE_EXPENSAS.read(periodo);
                int PtoVta = int.Parse(
                    System.Configuration.ConfigurationManager.AppSettings["PtoVta"].ToString());
                FEProd.FECAEResponse cae = null;

                cae = AFIPHomo.FE_AFIP.AutorizaCAE_C(PtoVta, 2, lst, 11, 
                    Server.MapPath("certificado.pfx"), fecha);
                for (int i = 0; i < cae.FeDetResp.Length; i++)
                {
                    if (cae != null)
                    {
                        if (cae.FeDetResp[i].Resultado == "A")
                        {
                            DAL.CTACTE_EXPENSAS obj = lst[i];
                            obj.CAE = Convert.ToInt64(cae.FeDetResp[i].CAE);
                            obj.NRO_CTE = cae.FeDetResp[i].CbteDesde;
                            obj.PTO_VTA = PtoVta;
                            int anio = Convert.ToInt32(cae.FeDetResp[i].CbteFch.Substring(0, 4));
                            int mes = Convert.ToInt32(cae.FeDetResp[i].CbteFch.Substring(4, 2));
                            int dia = Convert.ToInt32(cae.FeDetResp[i].CbteFch.Substring(6, 2));
                            obj.FECHA_CAE = new DateTime(anio, mes, dia);
                            anio = Convert.ToInt32(cae.FeDetResp[i].CAEFchVto.Substring(0, 4));
                            mes = Convert.ToInt32(cae.FeDetResp[i].CAEFchVto.Substring(4, 2));
                            dia = Convert.ToInt32(cae.FeDetResp[i].CAEFchVto.Substring(6, 2));
                            obj.VENC_CAE = new DateTime(anio, mes, dia);

                            DAL.LIQUIDACION_EXPENSAS objLiq = DAL.LIQUIDACION_EXPENSAS.getByPk(periodo);
                            TimeSpan diasMora2 = objLiq.VENCIMIENTO_2 - objLiq.VENCIMIENTO_1;
                            TimeSpan diasMora3 = objLiq.VENCIMIENTO_3 - objLiq.VENCIMIENTO_1;

                            string codBarra = LaHerradura.RapiPago.CodigoBarra.getCodigoBarra(
                                obj.NRO_CTA,
                                obj.PTO_VTA,
                                obj.NRO_CTE,
                                obj.MONTO_ORIGINAL - objLiq.MONTO_3 + objLiq.MONTO_1,
                                objLiq.VENCIMIENTO_1,
                                objLiq.MONTO_2 - objLiq.MONTO_1,
                                diasMora2.Days,
                                objLiq.MONTO_3 - objLiq.MONTO_1,
                                diasMora3.Days);

                            obj.COD_BARRA_RAPIPAGO = codBarra;

                            DAL.FACTURAS_X_EXPENSA factu = new DAL.FACTURAS_X_EXPENSA();
                            factu.CAE = obj.CAE;
                            factu.FECHA_CAE = obj.FECHA_CAE;
                            factu.ID_CTACTE = obj.ID;
                            factu.NRO_CTA = obj.NRO_CTA;
                            factu.NRO_CTE = obj.NRO_CTE;
                            factu.PERIODO = obj.PERIODO;
                            factu.PTO_VTA = obj.PTO_VTA;
                            factu.VENC_CAE = obj.VENC_CAE;
                            factu.TIPO_COMPROBANTE = 11;
                            factu.MONTO = obj.MONTO_ORIGINAL;
                            string me = string.Empty;
                            switch (mes)
                            {
                                case 1:
                                    me = "Enero";
                                    break;
                                case 2:
                                    me = "Febrero";
                                    break;
                                case 3:
                                    me = "Marzo";
                                    break;
                                case 4:
                                    me = "Abril";
                                    break;
                                case 5:
                                    me = "Mayo";
                                    break;
                                case 6:
                                    me = "Junio";
                                    break;
                                case 7:
                                    me = "Julio";
                                    break;
                                case 8:
                                    me = "Agosto";
                                    break;
                                case 9:
                                    me = "Septiembre";
                                    break;
                                case 10:
                                    me = "Octubre";
                                    break;
                                case 11:
                                    me = "Noviembre";
                                    break;
                                case 12:
                                    me = "Diciembre";
                                    break;

                                default:
                                    break;
                            }
                            factu.DETALLE = string.Format("Expensas ordinarias mes de {0} de {1}",
                                me, anio);
                            using (TransactionScope scope = new TransactionScope())
                            {
                                DAL.LIQUIDACION_EXPENSAS.updateLiquida(periodo, 2);
                                DAL.CTACTE_EXPENSAS.setAFIP(obj);
                                DAL.FACTURAS_X_EXPENSA.insert(factu);
                                scope.Complete();
                            }
                        }
                        else
                        {
                            HtmlGenericControl ul = new HtmlGenericControl();
                            ul.TagName = "ul";
                            if (cae.FeDetResp[i].Observaciones != null)
                            {
                                foreach (var itemError in cae.FeDetResp[i].Observaciones)
                                {
                                    HtmlGenericControl li = new HtmlGenericControl();
                                    li.TagName = "li";
                                    li.InnerHtml = itemError.Msg;
                                    ul.Controls.Add(li);
                                }
                            }
                            txtError.Controls.Add(ul);
                            divError.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }


        }

        protected string uploadFile(FileUpload fU, string entidad)
        {
            string ret = "nodisponible.png";
            try
            {

                string path = Server.MapPath(entidad + "/");

                if (fU.HasFile)
                {
                    try
                    {
                        string nombreImagen = fU.FileName;

                        fU.PostedFile.SaveAs(path
                            + nombreImagen);

                        ret = nombreImagen;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBanelco_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreArchivo = uploadFile(fUploadBanelco, "Banelco");
                string path = Server.MapPath("Banelco/");
                string[] lines = System.IO.File.ReadAllLines(string.Format("{0}{1}",
                    path, nombreArchivo));

                List<Banelco.Detalle> lst = new List<Banelco.Detalle>();

                for (int i = 1; i < lines.Length - 1; i++)
                {
                    lst.Add(Banelco.Detalle.crea(lines[i]));
                }

                gvBanelco.DataSource = lst;
                gvBanelco.DataBind();
                divBanelco.Visible = true;
                divLiquidaciones.Visible = false;
                divRapiPago.Visible = false;
                divMacro.Visible = false;
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }

        protected void gvBanelco_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl aConsulta = (HtmlGenericControl)e.Row.FindControl("aConsulta");
                    Banelco.Detalle obj = (Banelco.Detalle)e.Row.DataItem;
                    DAL.CTACTE_EXPENSAS objCta = DAL.CTACTE_EXPENSAS.getByComp(obj.IdFactura);
                    Label lblCanalPago = (Label)e.Row.FindControl("lblCanalPago");
                    if (objCta == null)
                    {
                        e.Row.BackColor = System.Drawing.Color.FromName("#f8d7da");
                        e.Row.ForeColor = System.Drawing.Color.FromName("#721c24");
                        e.Row.BorderColor = System.Drawing.Color.FromName("#f5c6cb");
                        aConsulta.Visible = false;
                    }
                    else
                    {
                        if (objCta.PAGADO)
                        {
                            e.Row.BackColor = System.Drawing.Color.FromName("#fff3cd");
                            e.Row.ForeColor = System.Drawing.Color.FromName("#856404");
                            e.Row.BorderColor = System.Drawing.Color.FromName("#ffeeba");
                            aConsulta.Visible = true;
                        }
                        else
                        {
                            e.Row.BackColor = System.Drawing.Color.FromName("#d4edda");
                            e.Row.ForeColor = System.Drawing.Color.FromName("#155724");
                            e.Row.BorderColor = System.Drawing.Color.FromName("#c3e6cb");
                            aConsulta.Visible = false;
                        }
                    }
                    switch (obj.CanalPago.Trim())
                    {
                        case "PC":
                            lblCanalPago.Text = "Pagomiscuentas";
                            break;
                        case "HB":
                            lblCanalPago.Text = "Home Banking";
                            break;
                        case "S1":
                            lblCanalPago.Text = "ATM";
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }

        protected void btnAceptarBanelco_Click(object sender, EventArgs e)
        {
            try
            {
                List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();
                DAL.CTACTE_EXPENSAS obj;
                for (int i = 0; i < gvBanelco.Rows.Count; i++)
                {
                    GridViewRow row = gvBanelco.Rows[i];
                    string nroComp = row.Cells[1].Text;
                    DAL.CTACTE_EXPENSAS objCta = DAL.CTACTE_EXPENSAS.getByComp(nroComp);
                    if (objCta != null)
                    {
                        if (!objCta.PAGADO)
                        {
                            objCta.ID_MEDIO_PAGO = 3;
                            objCta.HABER = Convert.ToDecimal(row.Cells[4].Text.Replace("$", ""));
                            objCta.SALDO = Convert.ToDecimal(row.Cells[4].Text.Replace("$", ""));
                            objCta.FECHA = Convert.ToDateTime(row.Cells[3].Text);
                            if (objCta.FECHA.ToShortDateString() != LaHerradura.Utils.Utils.getFechaActual().ToShortDateString())
                            {
                                DAL.CTACTE_EXPENSAS.recalculo(objCta.FECHA, objCta.PERIODO, objCta.NRO_CTA,
                                    objCta.ID);
                                objCta = DAL.CTACTE_EXPENSAS.getByComp(nroComp);
                                objCta.ID_MEDIO_PAGO = 3;
                                objCta.HABER = Convert.ToDecimal(row.Cells[4].Text.Replace("$", ""));
                                objCta.SALDO = Convert.ToDecimal(row.Cells[4].Text.Replace("$", ""));
                                objCta.FECHA = Convert.ToDateTime(row.Cells[3].Text);
                            }
                            lst.Add(objCta);
                        }
                    }
                }
                if (lst.Count > 0)
                {
                    CTA_CTE.asientaPagoMaivo(lst, Server.MapPath("certificado.pfx"));
                    Response.Redirect("expensas.aspx");
                    divBanelco.Visible = false;
                    divRapiPago.Visible = false;
                    divLiquidaciones.Visible = true;
                    divMacro.Visible = false;
                }
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }

        }

        protected void btnCancelarBanelco_Click(object sender, EventArgs e)
        {
            try
            {
                gvBanelco.DataSource = null;
                gvBanelco.DataBind();
                divBanelco.Visible = false;
                divRapiPago.Visible = false;
                divLiquidaciones.Visible = true;
                divMacro.Visible = false;
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }

        protected void btnRapiPago_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreArchivo = uploadFile(fUploadRapiPago, "RapiPago");
                string path = Server.MapPath("RapiPago/");
                string[] lines = System.IO.File.ReadAllLines(string.Format("{0}{1}",
                    path, nombreArchivo));

                List<RapiPago.Detalle> lst = new List<RapiPago.Detalle>();

                for (int i = 1; i < lines.Length - 1; i++)
                {
                    lst.Add(RapiPago.Detalle.crea(lines[i]));
                }
                gvRapiPago.DataSource = lst;
                gvRapiPago.DataBind();
                divRapiPago.Visible = true;
                divLiquidaciones.Visible = false;
                divBanelco.Visible = false;
                divMacro.Visible = false;
                //Columnas grilla |Nro. Cuenta |Factura |Vencimiento |Importe cobrado |Cod. Barra
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }

        protected void gvRapiPago_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl aConsulta = (HtmlGenericControl)e.Row.FindControl("aConsulta");
                    RapiPago.Detalle obj = (RapiPago.Detalle)e.Row.DataItem;
                    DAL.CTACTE_EXPENSAS objCta = DAL.CTACTE_EXPENSAS.getByComp(obj.factura);
                    if (objCta == null)
                    {
                        e.Row.BackColor = System.Drawing.Color.FromName("#f8d7da");
                        e.Row.ForeColor = System.Drawing.Color.FromName("#721c24");
                        e.Row.BorderColor = System.Drawing.Color.FromName("#f5c6cb");
                        aConsulta.Visible = false;
                    }
                    else
                    {
                        if (objCta.PAGADO)
                        {
                            e.Row.BackColor = System.Drawing.Color.FromName("#fff3cd");
                            e.Row.ForeColor = System.Drawing.Color.FromName("#856404");
                            e.Row.BorderColor = System.Drawing.Color.FromName("#ffeeba");
                            aConsulta.Visible = true;
                        }
                        else
                        {
                            e.Row.BackColor = System.Drawing.Color.FromName("#d4edda");
                            e.Row.ForeColor = System.Drawing.Color.FromName("#155724");
                            e.Row.BorderColor = System.Drawing.Color.FromName("#c3e6cb");
                            aConsulta.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }

        protected void btnAceptarRapiPago_Click(object sender, EventArgs e)
        {
            try
            {
                List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();
                DAL.CTACTE_EXPENSAS obj;
                for (int i = 0; i < gvRapiPago.Rows.Count; i++)
                {
                    GridViewRow row = gvRapiPago.Rows[i];
                    string nroComp = row.Cells[1].Text;
                    DAL.CTACTE_EXPENSAS objCta = DAL.CTACTE_EXPENSAS.getByComp(nroComp);
                    if (objCta != null)
                    {
                        if (!objCta.PAGADO)
                        {
                            objCta.ID_MEDIO_PAGO = 4;
                            objCta.HABER = Convert.ToDecimal(row.Cells[3].Text.Replace("$", ""));
                            objCta.SALDO = Convert.ToDecimal(row.Cells[3].Text.Replace("$", ""));
                            objCta.FECHA = Convert.ToDateTime(row.Cells[2].Text);
                            if (objCta.FECHA.ToShortDateString() != LaHerradura.Utils.Utils.getFechaActual().ToShortDateString())
                            {
                                DAL.CTACTE_EXPENSAS.recalculo(objCta.FECHA, objCta.PERIODO, objCta.NRO_CTA,
                                    objCta.ID);
                                objCta = DAL.CTACTE_EXPENSAS.getByComp(nroComp);
                                objCta.ID_MEDIO_PAGO = 4;
                                objCta.HABER = Convert.ToDecimal(row.Cells[3].Text.Replace("$", ""));
                                objCta.SALDO = Convert.ToDecimal(row.Cells[3].Text.Replace("$", ""));
                                objCta.FECHA = Convert.ToDateTime(row.Cells[2].Text);
                            }

                            lst.Add(objCta);
                        }
                    }
                }
                if (lst.Count > 0)
                {
                    CTA_CTE.asientaPagoMaivo(lst, Server.MapPath("certificado.pfx"));
                    Response.Redirect("expensas.aspx");
                    divBanelco.Visible = false;
                    divRapiPago.Visible = false;
                    divLiquidaciones.Visible = true;
                    divMacro.Visible = false;
                }
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }


        }

        protected void btnCancelarRapiPago_Click(object sender, EventArgs e)
        {
            try
            {
                gvBanelco.DataSource = null;
                gvBanelco.DataBind();
                divBanelco.Visible = false;
                divRapiPago.Visible = false;
                divLiquidaciones.Visible = true;
                divMacro.Visible = false;
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }

        protected void btnAceptarLeyenda_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.LIQUIDACION_EXPENSAS.setNota(int.Parse(hPeriodo.Value),
                    txtLeyenda.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAceptarMacro_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreArchivo = uploadFile(fUpMacro, "Macro");
                string path = Server.MapPath("Macro/");
                string[] lines = System.IO.File.ReadAllLines(string.Format("{0}{1}",
                    path, nombreArchivo));

                List<Macro.Detalle> lst = new List<Macro.Detalle>();

                for (int i = 1; i < lines.Length - 1; i++)
                {
                    lst.Add(Macro.Detalle.crea(lines[i]));
                }

                gvMacro.DataSource = lst;
                gvMacro.DataBind();
                divBanelco.Visible = false;
                divLiquidaciones.Visible = false;
                divRapiPago.Visible = false;
                divMacro.Visible = true;
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }

        protected void gvMacro_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Macro.Detalle obj = (Macro.Detalle)e.Row.DataItem;
                    DAL.CTACTE_EXPENSAS objCta = 
                        DAL.CTACTE_EXPENSAS.getByComp(obj.Identificacion_del_debito);
                    Label lblBanco = (Label)e.Row.FindControl("lblBanco");
                    Label lblMotivoRechazo = (Label)e.Row.FindControl("lblMotivoRechazo");
                    HtmlGenericControl aConsulta = (HtmlGenericControl)e.Row.FindControl("aConsulta");
                    DAL.BANCOS objBanco = 
                        DAL.BANCOS.getByPk(
                            obj.Codigo_de_banco_del_adherente);
                    lblBanco.Text = objBanco.DENOMINACION;
                    if (objCta == null)
                    {
                        e.Row.BackColor = System.Drawing.Color.FromName("#f8d7da");
                        e.Row.ForeColor = System.Drawing.Color.FromName("#721c24");
                        e.Row.BorderColor = System.Drawing.Color.FromName("#f5c6cb");
                        aConsulta.Visible = false;
                    }
                    else
                    {
                        if (objCta.PAGADO)
                        {
                            e.Row.BackColor = System.Drawing.Color.FromName("#fff3cd");
                            e.Row.ForeColor = System.Drawing.Color.FromName("#856404");
                            e.Row.BorderColor = System.Drawing.Color.FromName("#ffeeba");
                            aConsulta.Visible = true;
                        }
                        else
                        {
                            e.Row.BackColor = System.Drawing.Color.FromName("#d4edda");
                            e.Row.ForeColor = System.Drawing.Color.FromName("#155724");
                            e.Row.BorderColor = System.Drawing.Color.FromName("#c3e6cb");
                            aConsulta.Visible = false;
                        }
                    }
                    switch (obj.codigo_de_motivo_o_rechazo.Trim())
                    {
                        case "R02":
                            lblMotivoRechazo.Text = "CUENTA CERRADA / BLOQUEADA / INMOVILIZADA";
                            break;
                        case "R03":
                            lblMotivoRechazo.Text = "CUENTA INEXISTENTE";
                            break;
                        case "R04":
                            lblMotivoRechazo.Text = "NUMERO DE CUENTA INVALIDO";
                            break;
                        case "R08":
                            lblMotivoRechazo.Text = "ORDEN DE NO PAGAR";
                            break;
                        case "R10":
                            lblMotivoRechazo.Text = "FONDOS INSUFICIENTES";
                            break;
                        case "R14":
                            lblMotivoRechazo.Text = "IDENTIFICACION DEL CLIENTE EN LA EMPRESA ERRONEA";
                            break;
                        case "R15":
                            lblMotivoRechazo.Text = "BAJA DEL SERVICIO";
                            break;
                        case "R17":
                            lblMotivoRechazo.Text = "ERROR DE FORMATO";
                            break;
                        case "R19":
                            lblMotivoRechazo.Text = "IMPORTE ERRONEO";
                            break;
                        case "R20":
                            lblMotivoRechazo.Text = "MONEDA DISTINTA A LA CUENTA DE DEBITO";
                            break;
                        case "R23":
                            lblMotivoRechazo.Text = "SUCURSAL NO HABILITADA";
                            break;
                        case "R24":
                            lblMotivoRechazo.Text = "TRANSACCION DUPLICADA";
                            break;
                        case "R26":
                            lblMotivoRechazo.Text = "ERROR POR CAMPO MANDATORIO";
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //IMPUTAR DEBITOS MACRO
        protected void btnAceptaMacro_Click(object sender, EventArgs e)
        {
            try
            {
                List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();
                DAL.CTACTE_EXPENSAS obj;
                for (int i = 0; i < gvMacro.Rows.Count; i++)
                {
                    GridViewRow row = gvMacro.Rows[i];
                    string nroComp = row.Cells[3].Text;
                    DAL.CTACTE_EXPENSAS objCta = DAL.CTACTE_EXPENSAS.getByComp(nroComp);
                    Label lblMotivoRechazo = (Label)row.FindControl("lblMotivoRechazo");
                    if (objCta != null)
                    {
                        if (!objCta.PAGADO)
                        {
                            if (lblMotivoRechazo.Text == string.Empty)
                            {
                                objCta.ID_MEDIO_PAGO = 6;
                                objCta.HABER = Convert.ToDecimal(row.Cells[5].Text.Replace("$", ""));
                                objCta.SALDO = Convert.ToDecimal(row.Cells[5].Text.Replace("$", ""));
                                objCta.FECHA = Convert.ToDateTime(row.Cells[4].Text);
                                if (objCta.FECHA.ToShortDateString() != LaHerradura.Utils.Utils.getFechaActual().ToShortDateString())
                                {
                                    DAL.CTACTE_EXPENSAS.recalculo(objCta.FECHA, objCta.PERIODO, objCta.NRO_CTA,
                                        objCta.ID);
                                    objCta = DAL.CTACTE_EXPENSAS.getByComp(nroComp);
                                    objCta.ID_MEDIO_PAGO = 6;
                                    objCta.HABER = Convert.ToDecimal(row.Cells[5].Text.Replace("$", ""));
                                    objCta.SALDO = Convert.ToDecimal(row.Cells[5].Text.Replace("$", ""));
                                    objCta.FECHA = Convert.ToDateTime(row.Cells[4].Text);
                                }
                                lst.Add(objCta);
                            }
                        }
                    }
                }
                if (lst.Count > 0)
                {
                    CTA_CTE.asientaPagoMaivo(lst, Server.MapPath("certificado.pfx"));
                    Response.Redirect("expensas.aspx");
                    divBanelco.Visible = false;
                    divRapiPago.Visible = false;
                    divLiquidaciones.Visible = true;
                    divMacro.Visible = false;
                }
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }

        }

        protected void btnCancelarMacro_Click(object sender, EventArgs e)
        {
            try
            {
                gvMacro.DataSource = null;
                gvMacro.DataBind();
                divBanelco.Visible = false;
                divRapiPago.Visible = false;
                divLiquidaciones.Visible = true;
                divMacro.Visible = false;
            }
            catch (Exception ex)
            {
                divErrorEx.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }

        protected void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
                fe_a_b2(int.Parse(hPeriodo.Value), 
                    Convert.ToDateTime(txtFechaFactura.Text));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCrearMacro_Click(object sender, EventArgs e)
        {
            try
            {
                string mes = string.Empty;

                switch (Convert.ToDateTime(txtFechaMacro.Text).Month)
                {
                    case 1:
                        mes = "ENE";
                        break;
                    case 2:
                        mes = "FEB";
                        break;
                    case 3:
                        mes = "MAR";
                        break;
                    case 4:
                        mes = "ABR";
                        break;
                    case 5:
                        mes = "MAY";
                        break;
                    case 6:
                        mes = "JUN";
                        break;
                    case 7:
                        mes = "JUL";
                        break;
                    case 8:
                        mes = "AGO";
                        break;
                    case 9:
                        mes = "SEP";
                        break;
                    case 10:
                        mes = "OCT";
                        break;
                    case 11:
                        mes = "NOV";
                        break;
                    case 12:
                        mes = "DIC";
                        break;
                    default:
                        break;
                }
                string fileName = string.Format("CDA5334 {0} {1}.DEB",
                    Convert.ToDateTime(txtFechaMacro.Text).Day.ToString().PadLeft(2, Convert.ToChar("0")),
                    mes);

                if (File.Exists(Server.MapPath(".") + "/" + fileName))
                    File.Delete(Server.MapPath(".") + "/" + fileName);

                StreamWriter arch =
                    new StreamWriter(Server.MapPath(".") + "/" + fileName, true);

                arch.Write(LaHerradura.Macro.ArchivoFacturacion.crear(
                    Convert.ToInt32(hPeriodo.Value), Convert.ToDateTime(txtFechaMacro.Text)));
                arch.Close();

                DescargarDocumento(fileName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}