using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class inmueble : System.Web.UI.Page
    {
        private void generaDeuda(int periodo, int nroCta, decimal deuda, DateTime fecha)
        {
            try
            {
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                int idCta = 0;
                using (TransactionScope scope = new TransactionScope())
                {
                    List<DAL.DETALLE_DEUDA> lstDetalle = new List<DAL.DETALLE_DEUDA>();
                    DAL.LIQUIDACION_EXPENSAS liq = DAL.LIQUIDACION_EXPENSAS.getByPk(periodo);
                    decimal totGeneral = 0;

                    int orden = 1;
                    //INSERT DETALLE_DEUDA CONCEPTOS MASIVOS
                    List<DAL.CONCEPTOS_X_LIQUIDACION> lstMasivos =
                        DAL.CONCEPTOS_X_LIQUIDACION.read(periodo, nroCta);
                    foreach (var item2 in lstMasivos)
                    {
                        DAL.DETALLE_DEUDA obj = new DAL.DETALLE_DEUDA();
                        obj.CANT = item2.CANT;
                        obj.COSTO = deuda;
                        obj.DEBE = item2.CANT * deuda;
                        obj.FECHA = fecha;
                        obj.FECHA_CARGA = fec;
                        obj.HABER = 0;
                        obj.ID_CONCEPTO = item2.ID_CONCEPTO;
                        obj.MASIVO = true;
                        obj.NRO_CTA = nroCta;
                        obj.NRO_ORDEN = orden;
                        orden++;
                        obj.OBS = item2.OBS;
                        obj.PERIODO = periodo;
                        obj.SALDO = deuda;
                        obj.SUBTOTAL = deuda;
                        obj.USUARIO_CARGA = item2.USUARIO_CARGA;
                        obj.MONTO_ORIGINAL = deuda;
                        lstDetalle.Add(obj);
                    }

                    decimal tot = lstDetalle.Sum(t => t.SUBTOTAL);
                    totGeneral = totGeneral + tot;
                    DAL.CTACTE_EXPENSAS objMaestro = new DAL.CTACTE_EXPENSAS();
                    objMaestro.HABER = 0;
                    objMaestro.MONTO_ORIGINAL = deuda;
                    objMaestro.NRO_CTA = nroCta;
                    objMaestro.PERIODO = periodo;
                    objMaestro.TIPO_MOVIMIENTO = 1;
                    objMaestro.RECARGO_VENCIMIENTO = 0;
                    objMaestro.DESC_VENCIMIENTO = 0;
                    objMaestro.SALDO = deuda;
                    objMaestro.DEBE = deuda;
                    objMaestro.SALDO_CAPITAL = deuda;
                    objMaestro.FECHA_ULTIMO_PAGO = fecha;
                    objMaestro.VENCIMIENTO = fecha;
                    objMaestro.INTERES_MORA = 0;
                    objMaestro.FECHA = fecha;
                    objMaestro.FECHA_CAE = fecha;
                    idCta = DAL.CTACTE_EXPENSAS.insert(objMaestro);
                    foreach (var det in lstDetalle)
                    {
                        DAL.DETALLE_DEUDA.insert(det);
                    }
                    lstDetalle.Clear();


                    DAL.CTACTE_EXPENSAS objCta = DAL.CTACTE_EXPENSAS.getByPk2(idCta);
                    objCta.CAE = 111111111111111;
                    objCta.NRO_CTE = 1000;
                    objCta.PTO_VTA = 8;
                    int anio = fec.Year;
                    int mes = fec.Month;
                    int dia = fec.Day;
                    objCta.FECHA_CAE = fecha;
                    objCta.VENC_CAE = fecha;

                    DAL.LIQUIDACION_EXPENSAS objLiq = DAL.LIQUIDACION_EXPENSAS.getByPk(periodo);
                    TimeSpan diasMora2 = objLiq.VENCIMIENTO_2 - objLiq.VENCIMIENTO_1;
                    TimeSpan diasMora3 = objLiq.VENCIMIENTO_3 - objLiq.VENCIMIENTO_1;

                    string codBarra = LaHerradura.RapiPago.CodigoBarra.getCodigoBarra(
                        objCta.NRO_CTA,
                        objCta.PTO_VTA,
                        objCta.NRO_CTE,
                        objCta.MONTO_ORIGINAL - objLiq.MONTO_3 + objLiq.MONTO_1,
                        objLiq.VENCIMIENTO_1,
                        objLiq.MONTO_2 - objLiq.MONTO_1,
                        diasMora2.Days,
                        objLiq.MONTO_3 - objLiq.MONTO_1,
                        diasMora3.Days);

                    objCta.COD_BARRA_RAPIPAGO = codBarra;

                    DAL.FACTURAS_X_EXPENSA factu = new DAL.FACTURAS_X_EXPENSA();
                    factu.CAE = objCta.CAE;
                    factu.FECHA_CAE = objCta.FECHA_CAE;
                    factu.ID_CTACTE = objCta.ID;
                    factu.NRO_CTA = objCta.NRO_CTA;
                    factu.NRO_CTE = objCta.NRO_CTE;
                    factu.PERIODO = objCta.PERIODO;
                    factu.PTO_VTA = objCta.PTO_VTA;
                    factu.VENC_CAE = objCta.VENC_CAE;
                    factu.TIPO_COMPROBANTE = 11;
                    factu.MONTO = deuda;
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

                    DAL.CTACTE_EXPENSAS.setAFIP(objCta);
                    DAL.FACTURAS_X_EXPENSA.insert(factu);
                    DAL.CTACTE_EXPENSAS.recalculo(fecha, periodo, nroCta, idCta);
                    DAL.CTACTE_EXPENSAS.recalculo(fec, periodo, nroCta, idCta);
                    scope.Complete();
                }

                fillCta(nroCta, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                if (Request.QueryString["nrocta"] == null)
                    Response.Redirect("cuentas.aspx");
                int nroCta = Convert.ToInt32(Request.QueryString["nrocta"]);
                if (!IsPostBack)
                {
                    string anio = fec.Year.ToString();
                    string mes =
                        fec.Month.ToString().PadLeft(2, Convert.ToChar("0"));
                    string dia =
                        fec.Month.ToString().PadLeft(2, Convert.ToChar("0"));

                    //txtFechaCheque.Text = string.Format("{0}-{1}-{2}",
                    //    anio, mes, dia);
                    txtFecPag.Value = fec.ToShortDateString();



                    List<DAL.LIQUIDACION_EXPENSAS> lstLiq =
                        DAL.LIQUIDACION_EXPENSAS.getPeriodosNoFacturados(nroCta);
                    if (lstLiq.Count > 0)
                    {
                        DDLPeriodosDeuda.DataValueField = "PERIODO";
                        DDLPeriodosDeuda.DataTextField = "PERIODO_MAQUILLADO";

                        List<DAL.LIQUIDACION_EXPENSAS> lstLiqDeuda = lstLiq;

                        DDLPeriodosDeuda.DataSource = lstLiqDeuda;
                        DDLPeriodosDeuda.DataBind();

                        DDLPeriodosDeuda_SelectedIndexChanged(null, null);
                    }

                    List<DAL.BANCOS> lstBancos = DAL.BANCOS.read();
                    DDLBancos.DataValueField = "CODIGO";
                    DDLBancos.DataTextField = "DENOMINACION";
                    DDLBancos.DataSource = lstBancos;
                    DDLBancos.DataBind();
                    hIdCta.Value = nroCta.ToString();
                    fill(nroCta);
                    fillConceptosAsignar();
                    fillConceptosAsignados();
                    fillMails(nroCta);
                    fillPersonas();
                    fillCta(nroCta, 0);
                    HtmlGenericControl liInmuebles =
    this.Master.FindControl("liInmuebles") as HtmlGenericControl;
                    HtmlGenericControl liExpensas =
                        this.Master.FindControl("liExpensas") as HtmlGenericControl;
                    HtmlGenericControl liConfig =
                        this.Master.FindControl("liConfig") as HtmlGenericControl;

                    //DDLMedioPago.DataTextField = "DESCRIPCION";
                    //DDLMedioPago.DataValueField = "ID";
                    //DDLMedioPago.DataSource = DAL.MEDIOS_PAGO.readManual();
                    //DDLMedioPago.DataBind();

                    //DDLBanco.DataValueField = "CODIGO";
                    //DDLBanco.DataTextField = "DENOMINACION";
                    //DDLBanco.DataSource = DAL.BANCOS.read();
                    //DDLBanco.DataBind();
                }
                if (DAL.CTACTE_EXPENSAS.libreDeuda(nroCta))
                    btnLibreDeuda.Visible = false;
                else
                    btnLibreDeuda.Visible = true;

                DAL.BILLETERA objBilletera = DAL.BILLETERA.getByPk(nroCta);

                if (objBilletera.SALDO == 0)
                {
                    divBilletera.Visible = false;
                }
                else
                {
                    divBilletera.Visible = true;
                    lblMontoBilletera.InnerHtml =
                        string.Format("{0:c}", objBilletera.SALDO);
                }
                DAL.USUARIOS obj =
    DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                if (obj.ROL == 3)
                {
                    btnCargar.Visible = false;
                    btnLibre.Visible = false;
                    btnNotaCredito.Visible = false;
                    btnNotaDebito.Visible = false;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void fillMails(int cta)
        {
            try
            {
                List<DAL.MAIL_X_CTAS> lst = DAL.MAIL_X_CTAS.getByCta(cta);
                ulMails.Controls.Clear();
                foreach (var item in lst)
                {
                    HtmlGenericControl li = new HtmlGenericControl();
                    li.TagName = "li";
                    HtmlGenericControl h3 = new HtmlGenericControl();
                    h3.TagName = "h3";
                    h3.Style.Add("padding", "0");
                    h3.Style.Add("font-size", "15px");

                    HtmlGenericControl divH = new HtmlGenericControl();
                    divH.TagName = "div";
                    divH.Attributes.Add("class", "box-header");
                    divH.Style.Add("padding", "0px");

                    h3.InnerHtml = item.MAIL;

                    divH.Controls.Add(h3);
                    HtmlGenericControl div = new HtmlGenericControl();
                    div.TagName = "div";
                    div.Attributes.Add("class", "box-tools pull-right");
                    HtmlAnchor aEdit = new HtmlAnchor();
                    aEdit.HRef = "#";
                    aEdit.Attributes.Add("onclick", string.Format(
                        "abrirModalMail('{0}', '{1}')", item.ID, item.MAIL));
                    aEdit.InnerHtml = "<i class=\"fa fa-edit\" style=\"font-size: 15px;\"></i>";
                    aEdit.Attributes.Add("class", "btn btn-box-tool");

                    HtmlAnchor aDelete = new HtmlAnchor();
                    aDelete.HRef = "#";
                    aDelete.Attributes.Add("onclick", string.Format(
                        "abrirModalEliminaMail('{0}', '{1}')", item.ID, item.MAIL));
                    aDelete.InnerHtml = "<i class=\"fa fa-remove\" style=\"font-size: 15px; color:#f76e6e;\"></i>";
                    aDelete.Attributes.Add("class", "btn btn-box-tool");

                    div.Controls.Add(aEdit);
                    div.Controls.Add(aDelete);
                    divH.Controls.Add(div);
                    li.Controls.Add(divH);

                    ulMails.Controls.Add(li);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void fillConceptosAsignar()
        {
            try
            {
                List<DAL.CONCEPTOS_EXPENSA> lst = BLL.CONCEPTOS_EXPENSA.readActivos(0);
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
                throw ex;
            }

        }
        private void fillPersonas()
        {
            try
            {
                List<DAL.PERSONAS> lst = DAL.PERSONAS.read();
                gvPersonasSeleccionar.DataSource = lst;
                gvPersonasSeleccionar.DataBind();
                if (lst.Count > 0)
                {
                    gvPersonasSeleccionar.UseAccessibleHeader = true;
                    gvPersonasSeleccionar.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void fillConceptosAsignados()
        {
            try
            {
                List<DAL.CONCEPTOS_X_INMUEBLE> lst =
                    DAL.CONCEPTOS_X_INMUEBLE.readSinImputar(
                        Convert.ToInt32(Request.QueryString["nrocta"]));
                gvConceptos.DataSource = lst;
                gvConceptos.DataBind();
                if (lst.Count > 0)
                {
                    gvConceptos.UseAccessibleHeader = true;
                    gvConceptos.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void fill(int nroCta)
        {
            try
            {
                DAL.INMUEBLES obj = BLL.INMUEBLES.getByNroCta(nroCta);

                if (obj.DEBITO_AUTOMATICO)
                {
                    divBajaDebito.Visible = true;
                    divAltaDebito.Visible = false;
                    DDLBancos.SelectedValue = obj.BANCO.PadLeft(
                        5, Convert.ToChar("0"));

                    if (obj.BANCO == "285")
                    {
                        divMacro.Visible = true;
                        txtCBU.Text = obj.CBU;
                        txtCuenta.Text = obj.CUENTA_BANCO;
                        txtSucursal.Text = obj.SUCURSAL;
                        switch (obj.TIPO_COBIS)
                        {
                            case "3":
                                DDLTipoCuenta.SelectedValue = "3";
                                break;
                            case "4":
                                DDLTipoCuenta.SelectedValue = "4";
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        divMacro.Visible = false;
                        txtCBU.Text = obj.CBU;
                    }
                }

                hMan.Value = obj.MANZANA.ToString();
                hLot.Value = obj.LOTE.ToString();
                hDir.Value = obj.CALLE;
                hNro.Value = obj.NRO;

                hCir.Value = obj.CIR.ToString();
                hSec.Value = obj.SEC.ToString();
                hManz.Value = obj.MAN.ToString();
                hPar.Value = obj.PAR.ToString();
                HPh.Value = obj.P_H.ToString();
                hNroRentas.Value = obj.NRO_CTA_RP;


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

                List<DAL.PERSONAS_GRILLA> lst = DAL.PERSONAS_GRILLA.getByNroCta(obj.NRO_CTA);

                lblPropietarios.Controls.Clear();
                foreach (var item in lst)
                {
                    HtmlGenericControl li = new HtmlGenericControl();
                    li.TagName = "li";
                    HtmlGenericControl h3 = new HtmlGenericControl();
                    h3.TagName = "h3";
                    h3.Style.Add("padding", "0");
                    h3.Style.Add("font-size", "15px");
                    if (item.RELACION == "Propietario")
                    {
                        HtmlGenericControl divH = new HtmlGenericControl();
                        divH.TagName = "div";
                        divH.Attributes.Add("class", "box-header");
                        divH.Style.Add("padding", "0px");
                        if (item.RESPONSABLE_FACTURACION)
                            h3.InnerHtml = string.Format(
                                "<span class=\"fa fa-key\" style=\"font-size:12px;\"></span>&nbsp; Propietario: {0}",
                                item.NOMBRE, item.RELACION);
                        else
                            h3.InnerHtml = string.Format(
                            "<a href=\"#\" onclick=\"abrirModalResponsable('{0}')\"><span class=\"fa fa-key\" style=\"font-size:12px; color:lightgray;\"></span></a>&nbsp; Propietario: {1}",
                            item.ID, item.NOMBRE);

                        divH.Controls.Add(h3);
                        HtmlGenericControl div = new HtmlGenericControl();
                        div.TagName = "div";
                        div.Attributes.Add("class", "box-tools pull-right");
                        HtmlAnchor aEdit = new HtmlAnchor();
                        aEdit.HRef = string.Format(
                            "Persona.aspx?idPersona={0}&nroCta={1}", item.ID,
                            item.NRO_CTA);
                        aEdit.InnerHtml = "<i class=\"fa fa-edit\" style=\"font-size: 15px;\"></i>";
                        aEdit.Attributes.Add("class", "btn btn-box-tool");

                        HtmlAnchor aPass = new HtmlAnchor();
                        aPass.HRef = string.Format(
                            "CambioPass.aspx?idPersona={0}&nroCta={1}", item.ID,
                            item.NRO_CTA);
                        aPass.InnerHtml = "<i class=\"fa fa-key\" style=\"font-size: 15px;\"></i>";
                        aPass.Attributes.Add("class", "btn btn-box-tool");

                        HtmlAnchor aDelete = new HtmlAnchor();
                        if (!item.RESPONSABLE_FACTURACION)
                        {

                            aDelete.HRef = "#";
                            aDelete.Attributes.Add("onclick",
    string.Format("abrirModalEliminaVinculo({0},'{1}: {2}')", item.ID, item.RELACION,
    item.NOMBRE));
                            aDelete.InnerHtml = "<i class=\"fa fa-remove\" style=\"font-size: 15px; color:#f76e6e;\"></i>";
                            aDelete.Attributes.Add("class", "btn btn-box-tool");
                        }

                        div.Controls.Add(aPass);
                        div.Controls.Add(aEdit);
                        if (!item.RESPONSABLE_FACTURACION)
                            div.Controls.Add(aDelete);
                        divH.Controls.Add(div);

                        HtmlGenericControl divTel = new HtmlGenericControl();
                        List<DAL.TELEFONO_PERSONA> lstTel = DAL.TELEFONO_PERSONA.read(item.ID);
                        HtmlGenericControl spanTel = new HtmlGenericControl();
                        foreach (var itemTel in lstTel)
                        {
                            spanTel = new HtmlGenericControl();
                            spanTel.TagName = "span";
                            spanTel.Attributes.Add("class", "fa fa-phone");
                            spanTel.Style.Add("font-size", "12px");
                            spanTel.InnerHtml = string.Format("&nbsp;+{0} {1}-{2}",
                                itemTel.COD_PAIS, itemTel.COD_AREA, itemTel.NUMERO);
                            divH.Controls.Add(spanTel);
                        }

                        /*
                         <span class="" style=":">351 6117120</span>
                         */
                        li.Controls.Add(divH);
                    }
                    else
                    {

                        HtmlGenericControl divH = new HtmlGenericControl();
                        divH.TagName = "div";
                        divH.Attributes.Add("class", "box-header");
                        divH.Style.Add("padding", "0px");
                        if (item.RESPONSABLE_FACTURACION)
                            h3.InnerHtml = string.Format(
                                "<span class=\"fa fa-key\" style=\"font-size:12px;\"></span>&nbsp; Inquilino: {0}",
                                item.NOMBRE, item.RELACION);
                        else
                            h3.InnerHtml = string.Format(
                            "<a href=\"#\" onclick=\"abrirModalResponsable('{0}')\"><span class=\"fa fa-key\" style=\"font-size:12px; color:lightgray;\"></span></a>&nbsp; Inquilino: {1}",
                            item.ID, item.NOMBRE);
                        divH.Controls.Add(h3);
                        HtmlGenericControl div = new HtmlGenericControl();
                        div.TagName = "div";
                        div.Attributes.Add("class", "box-tools pull-right");
                        HtmlAnchor aEdit = new HtmlAnchor();
                        aEdit.HRef = string.Format(
                            "Persona.aspx?idPersona={0}&nroCta={1}", item.ID,
                            item.NRO_CTA);
                        aEdit.InnerHtml = "<i class=\"fa fa-edit\" style=\"font-size: 15px;\"></i>";
                        aEdit.Attributes.Add("class", "btn btn-box-tool");

                        HtmlAnchor aPass = new HtmlAnchor();
                        aPass.HRef = string.Format(
                            "CambioPass.aspx?idPersona={0}&nroCta={1}", item.ID,
                            item.NRO_CTA);
                        aPass.InnerHtml = "<i class=\"fa fa-key\" style=\"font-size: 15px;\"></i>";
                        aPass.Attributes.Add("class", "btn btn-box-tool");

                        HtmlAnchor aDelete = new HtmlAnchor();
                        if (!item.RESPONSABLE_FACTURACION)
                        {

                            aDelete.HRef = "#";
                            aDelete.Attributes.Add("onclick",
    string.Format("abrirModalEliminaVinculo({0},'{1}: {2}')", item.ID, item.RELACION,
    item.NOMBRE));
                            aDelete.InnerHtml = "<i class=\"fa fa-remove\" style=\"font-size: 15px; color:#f76e6e;\"></i>";
                            aDelete.Attributes.Add("class", "btn btn-box-tool");
                        }

                        div.Controls.Add(aPass);
                        div.Controls.Add(aEdit);

                        if (!item.RESPONSABLE_FACTURACION)
                            div.Controls.Add(aDelete);

                        divH.Controls.Add(div);

                        HtmlGenericControl divTel = new HtmlGenericControl();
                        List<DAL.TELEFONO_PERSONA> lstTel = DAL.TELEFONO_PERSONA.read(item.ID);
                        HtmlGenericControl spanTel = new HtmlGenericControl();
                        foreach (var itemTel in lstTel)
                        {
                            spanTel = new HtmlGenericControl();
                            spanTel.TagName = "span";
                            spanTel.Attributes.Add("class", "fa fa-phone");
                            spanTel.Style.Add("font-size", "12px");
                            spanTel.InnerHtml = string.Format("&nbsp;+{0} {1}-{2}",
                                itemTel.COD_PAIS, itemTel.COD_AREA, itemTel.NUMERO);
                            divH.Controls.Add(spanTel);
                        }

                        li.Controls.Add(divH);

                    }
                    lblPropietarios.Controls.Add(li);
                }
                //<li style="font-size: 18px;"></li>
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
                lst = DAL.CTACTE_EXPENSAS.readCtaDeuda(nrocta);
                txtSaldo.Text = string.Format("{0:c}", lst.Sum(d => d.SALDO));

                switch (opcion)
                {
                    case 0:
                        gvCtaTotal.DataSource = null;
                        gvCtaTotal.DataBind();
                        gvExport.DataSource = null;
                        gvExport.DataBind();
                        gvMovCtaCte.DataSource = null;
                        gvMovCtaCte.DataBind();
                        gvCtaCte.DataSource = lst;
                        gvCtaCte.DataBind();
                        if (lst.Count > 0)
                        {
                            gvCtaCte.UseAccessibleHeader = true;
                            gvCtaCte.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                        break;
                    case 1:
                        lst = DAL.CTACTE_EXPENSAS.readCta(nrocta);
                        gvCtaCte.DataSource = null;
                        gvCtaCte.DataBind();
                        gvExport.DataSource = null;
                        gvExport.DataBind();
                        gvMovCtaCte.DataSource = null;
                        gvMovCtaCte.DataBind();
                        gvCtaTotal.DataSource = lst;
                        gvCtaTotal.DataBind();
                        if (lst.Count > 0)
                        {
                            gvCtaTotal.UseAccessibleHeader = true;
                            gvCtaTotal.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                        break;

                    case 2:
                        gvCtaTotal.DataSource = null;
                        gvCtaTotal.DataBind();
                        gvExport.DataSource = lst;
                        gvExport.DataBind();
                        gvCtaCte.DataSource = null;
                        gvCtaCte.DataBind();
                        gvMovCtaCte.DataSource = null;
                        gvMovCtaCte.DataBind();
                        if (lst.Count > 0)
                        {
                            gvExport.UseAccessibleHeader = true;
                            gvExport.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                        break;
                    case 3:
                        gvCtaTotal.DataSource = null;
                        gvCtaTotal.DataBind();
                        gvExport.DataSource = null;
                        gvExport.DataBind();
                        gvCtaCte.DataSource = null;
                        gvCtaCte.DataBind();
                        List<DAL.MOVIMIENTO_CTACTE> lst2 = DAL.MOVIMIENTO_CTACTE.read(nrocta);
                        gvMovCtaCte.DataSource = lst2;
                            
                        gvMovCtaCte.DataBind();
                        if (lst2.Count > 0)
                        {
                            gvMovCtaCte.UseAccessibleHeader = true;
                            gvMovCtaCte.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                        break;
                    default:
                        break;
                }
                if (opcion == 0)
                {

                }
                else
                {


                }
                divAsiento.Visible = false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void gvConceptos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "borrar")
                {
                    DAL.CONCEPTOS_X_INMUEBLE.delete(Convert.ToInt32(e.CommandArgument));
                    fillConceptosAsignados();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvConceptos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

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
                throw ex;
            }
        }

        protected void btnAceptarConcepto_ServerClick(object sender, EventArgs e)
        {
            try
            {
                var culturaArgentina = CultureInfo.GetCultureInfo("es-AR");


                DAL.CONCEPTOS_X_INMUEBLE obj = new DAL.CONCEPTOS_X_INMUEBLE();
                DAL.CONCEPTOS_EXPENSA oConcepto = BLL.CONCEPTOS_EXPENSA.getByPk(
                    int.Parse(hIdServicio.Value));
                obj.CANT = Convert.ToDecimal(txtCantConcept.Value.Replace(".", ","),
                    culturaArgentina);

                obj.COSTO = oConcepto.MONTO;
                obj.FECHA = Convert.ToDateTime(txtFecha.Value);
                obj.FECHA_CARGA = LaHerradura.Utils.Utils.getFechaActual();
                obj.ID_CONCEPTO = int.Parse(hIdServicio.Value);
                obj.MASIVO = false;
                obj.NRO_CTA = Convert.ToInt32(Request.QueryString["nrocta"]);
                obj.OBS = txtObsConcepto.Text;
                obj.PERIODO = 0;
                obj.SUBTOTAL = obj.CANT * obj.COSTO;
                obj.NRO_ORDEN = DAL.CONCEPTOS_X_INMUEBLE.getMaxOrden(obj.NRO_CTA, 0) + 1;
                obj.USUARIO_CARGA = Convert.ToInt32(Request.Cookies["UserLh"]["Id"]);
                DAL.CONCEPTOS_X_INMUEBLE.insert(obj);
                fillConceptosAsignados();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAcptarMailCta_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.MAIL_X_CTAS obj;
                if (hIdMail.Value == string.Empty)
                    obj = new DAL.MAIL_X_CTAS();
                else
                    obj = DAL.MAIL_X_CTAS.getByPk(int.Parse(hIdMail.Value));

                obj.MAIL = txtMailCta.Text;
                obj.NRO_CTA = Convert.ToInt32(Request.QueryString["nrocta"].ToString());

                if (hIdMail.Value == string.Empty)
                    DAL.MAIL_X_CTAS.insert(obj);
                else
                    DAL.MAIL_X_CTAS.update(obj);

                int nroCta = Convert.ToInt32(Request.QueryString["nrocta"].ToString());
                fill(nroCta);
                fillConceptosAsignar();
                fillConceptosAsignados();
                fillMails(nroCta);
                fillPersonas();
                fillCta(nroCta, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEliminarMail_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.MAIL_X_CTAS.delete(int.Parse(hIdEliminaMail.Value));
                fillMails(Convert.ToInt32(Request.QueryString["nrocta"]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAceptarCatastral_ServerClick(object sender, EventArgs e)
        {
            try
            {
                DAL.INMUEBLES obj = DAL.INMUEBLES.getByNroCta(Convert.ToInt32(Request.QueryString["nrocta"]));
                obj.CALLE = txtCalleCambiar.Text;
                obj.CIR = int.Parse(txtCIR.Text);
                obj.LOTE = int.Parse(txtLoteCambiar.Text);
                obj.MAN = int.Parse(txtMAN.Text);
                obj.MANZANA = int.Parse(txtManzanaCambiar.Text);
                obj.NRO = txtNroCambiar.Text;
                obj.NRO_CTA_RP = txtNRP.Text;
                obj.PAR = int.Parse(txtPAR.Text);
                obj.P_H = int.Parse(txtPH.Text);
                obj.SEC = int.Parse(txtSEC.Text);
                DAL.INMUEBLES.update(obj);
                fill(obj.NRO_CTA);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnAceptarCambioResponsabilidad_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int nroCta = Convert.ToInt32(Request.QueryString["nrocta"]);
                BLL.PERSONAS_X_INMUEBLES.updateResponsable(int.Parse(hIdPersona.Value), nroCta);
                fill(nroCta);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void gvPersonasSeleccionar_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvPersonasSeleccionar_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnAceptarAgregarPersona_ServerClick(object sender, EventArgs e)
        {
            try
            {
                DAL.PERSONAS_X_INMUEBLES obj = new DAL.PERSONAS_X_INMUEBLES();
                obj.ACTIVO = true;
                obj.ID_PERSONA = Convert.ToInt32(hIdPersona.Value);
                obj.NRO_CTA = Convert.ToInt32(Request.QueryString["nrocta"]);
                obj.RELACION = DDLRol.SelectedItem.Value;
                obj.RESPONSABLE_FACTURACION = false;
                DAL.PERSONAS_X_INMUEBLES.insert(obj);
                fill(obj.NRO_CTA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEliminaVinculo_Click(object sender, EventArgs e)
        {
            try
            {
                int nroCta = Convert.ToInt32(Request.QueryString["nrocta"]);
                DAL.PERSONAS_X_INMUEBLES.delete(Convert.ToInt32(hIdPersonaElimina.Value),
                    nroCta);
                fill(nroCta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvCtaCte_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblTipoMov = (Label)e.Row.FindControl("lblTipoMov");
                    DAL.CTACTE_EXPENSAS obj = (DAL.CTACTE_EXPENSAS)e.Row.DataItem;
                    Label lblPeriodo = (Label)e.Row.FindControl("lblPeriodo");
                    LinkButton btnQuitarDeuda =
                        (LinkButton)e.Row.FindControl("btnQuitarDeuda");
                    HtmlGenericControl divVerDetalle = (HtmlGenericControl)
                        e.Row.FindControl("divVerDetalle");
                    HtmlGenericControl divCheckPago = (HtmlGenericControl)e.Row.FindControl("divCheckPago");

                    CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");

                    if (obj.PERIODO < 20200400)
                    {
                        divVerDetalle.Visible = false;
                        btnQuitarDeuda.Visible = true;
                    }
                    else
                    {
                        divVerDetalle.Visible = true;
                        btnQuitarDeuda.Visible = false;
                    }
                    if (obj.PERIODO != 20190100)
                    {
                        if (obj.PERIODO.ToString().Substring(6, 2) == "00")
                            lblPeriodo.Text = string.Format("{0}-{1} Ordinaria",
                                obj.PERIODO.ToString().Substring(0, 4),
                                obj.PERIODO.ToString().Substring(4, 2));
                        else
                            lblPeriodo.Text = string.Format("{0}-{1} Extraordinaria",
                                obj.PERIODO.ToString().Substring(0, 4),
                                obj.PERIODO.ToString().Substring(4, 2));
                    }
                    else
                    {
                        lblPeriodo.Text = "Saldo (capital) a Sept. 2019";
                    }
                    if (obj.PERIODO == 20191212)
                    {
                        lblPeriodo.Text = "Saldo a Diciembre de 2019";
                    }
                    if (obj.TIPO_MOVIMIENTO == 100)
                    {
                        DAL.FACTURAS_X_EXPENSA objFactu =
                            DAL.FACTURAS_X_EXPENSA.getByPk(obj.PTO_VTA,
                            obj.NRO_CTE, 11);
                        lblPeriodo.Text = string.Format(
                            "Factura {0}-{1} - {2}",
                            obj.PTO_VTA.ToString().PadLeft(
                                4, Convert.ToChar("0")),
                            obj.NRO_CTE.ToString().PadLeft(
                                8, Convert.ToChar("0")),
                            objFactu.DETALLE);


                    }
                    if (obj.TIPO_MOVIMIENTO == 21)
                    {
                        lblPeriodo.Text = string.Format(
                            "Nota de Débito Interna {0}-{1}",
                            obj.PTO_VTA.ToString().PadLeft(
                                4, Convert.ToChar("0")),
                            obj.NRO_CTE.ToString().PadLeft(
                                8, Convert.ToChar("0")));
                    }
                    if (obj.TIPO_MOVIMIENTO == 12)
                    {
                        lblPeriodo.Text = string.Format(
                            "Nota de Débito Fiscal {0}-{1}",
                            obj.PTO_VTA.ToString().PadLeft(
                                4, Convert.ToChar("0")),
                            obj.NRO_CTE.ToString().PadLeft(
                                8, Convert.ToChar("0")));
                    }
                    List<DAL.DETALLE_DEUDA> lst = new List<DAL.DETALLE_DEUDA>();
                    GridView gvDetails = (GridView)e.Row.FindControl("gvDetails");
                    switch (obj.TIPO_MOVIMIENTO)
                    {
                        case 1:
                            lst = DAL.DETALLE_DEUDA.read(obj.PERIODO,
                                obj.NRO_CTA);
                            gvDetails.DataSource = lst;
                            gvDetails.DataBind();
                            break;
                        case 3:
                            lblPeriodo.Text = string.Format("Plan de pago Nro: {0} - Cuota {1}",
                                obj.NRO_PLAN_PAGO, obj.NRO_CUOTA);
                            lst = DAL.DETALLE_DEUDA.readPlan(
                                obj.PERIODO, obj.NRO_CTA, obj.NRO_PLAN_PAGO,
                                obj.NRO_CUOTA);
                            gvDetails.DataSource = lst;
                            gvDetails.DataBind();
                            break;
                        case 100:
                            //lst = DAL.DETALLE_DEUDA.getByIdCta(obj.ID);
                            //gvDetails.DataSource = lst;
                            //gvDetails.DataBind();
                            break;
                        //case 21:
                        //    lst = DAL.DETALLE_DEUDA.getByIdCta(obj.ID);
                        //    gvDetails.DataSource = lst;
                        //    gvDetails.DataBind();
                        //    break;
                        //case 12:
                        //    lst = DAL.DETALLE_DEUDA.getByIdCta(obj.ID);
                        //    gvDetails.DataSource = lst;
                        //    gvDetails.DataBind();
                        //    break;
                        default:
                            break;


                    }
                    //if (obj.TIPO_MOVIMIENTO == 1)
                    //    lblTipoMov.Text = "DEUDA";
                    //else
                    //    lblTipoMov.Text = "PAGO";

                    /*<span><%# Eval("PAGO_CUENTA") %></span>
                      <a href="#" class="pull-right"  onclick="abreModalPagoCta()">
                      <span class="fa fa-search-plus"></span>
                      </a>*/
                    HtmlGenericControl lblPagoCta = (HtmlGenericControl)
                        e.Row.FindControl("lblPagoCta");
                    if (obj.PAGO_A_CTA != 0)
                    {
                        lblPagoCta.Visible = true;

                        lblPagoCta.InnerHtml = string.Format(
"<span>{0:c}</span><a href=\"#\" class=\"pull-right\" onclick=\"abreDetallePagoCta('{1}','{2}','{3}')\"><span class=\"fa fa-search-plus\"></span></a>",
   obj.PAGO_A_CTA, obj.NRO_CTA, obj.PERIODO, obj.ID);

                        chkSelect.Text = (obj.SALDO_CAPITAL + obj.INTERES_MORA).ToString();
                    }
                    else
                    {
                        lblPagoCta.Visible = false;
                        chkSelect.Text = obj.SALDO.ToString();
                    }

                    HtmlGenericControl lblInteresMora = (HtmlGenericControl)
    e.Row.FindControl("lblInteresMora");
                    if (obj.INTERES_MORA != 0)
                    {
                        lblInteresMora.Visible = true;
                        if (obj.PAGO_A_CTA == 0)
                        {
                            lblInteresMora.InnerHtml =
                                string.Format(
       "<span>{0:c}</span><a href=\"#\" class=\"pull-right\" onclick=\"abreDetalleInteres('{1}','{2}','{3}','{4}','{5}')\"><span class=\"fa fa-search-plus\"></span></a>",
                                obj.INTERES_MORA, obj.VENCIMIENTO, obj.MONTO_ORIGINAL,
                                obj.NRO_CTA, obj.PERIODO, 0);
                        }
                        else
                        {
                            lblInteresMora.InnerHtml =
                            string.Format(
   "<span>{0:c}</span><a href=\"#\" class=\"pull-right\" onclick=\"abreDetalleInteres('{1}','{2}','{3}','{4}','{5}')\"><span class=\"fa fa-search-plus\"></span></a>",
                            obj.INTERES_MORA, obj.FECHA_ULTIMO_PAGO, obj.SALDO_CAPITAL,
                            obj.NRO_CTA, obj.PERIODO, obj.SALDO_INTERES);
                        }
                        //List<DAL.DETALLE_INTERES> lstDetInteres = DAL.DETALLE_INTERES.read(
                        //    obj.VENCIMIENTO, , obj.SALDO);
                        //gvDetalleInteres.DataSource = lstDetInteres;
                        //gvDetalleInteres.DataBind();
                    }
                    DAL.USUARIOS objUsu =
DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));

                    //else
                    //{
                    //    divCheckPago.Visible = true;

                    //}
                    ImageButton imgWebActiva = (ImageButton)e.Row.FindControl("imgWebActiva");
                    ImageButton imgWebBloquea = (ImageButton)e.Row.FindControl("imgWebBloquea");
                    if (obj.ESTADO == 1)
                    {
                        imgWebActiva.Visible = true;
                        imgWebActiva.Style.Add("width", "30px");
                        imgWebBloquea.Visible = false;
                    }
                    else
                    {
                        imgWebBloquea.Visible = true;
                        imgWebBloquea.Style.Add("width", "30px");
                        imgWebActiva.Visible = false;
                    }
                    if (objUsu.ROL == 3)
                    {
                        chkSelect.Enabled = false;
                        btnQuitarDeuda.Visible = false;
                        btnQuitarDeuda.Visible = false;
                        imgWebBloquea.Visible = false;
                        imgWebActiva.Visible = false;
                        HtmlGenericControl btnNC = (HtmlGenericControl)
                            e.Row.FindControl("btnNC");
                        btnNC.Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [WebMethod]
        public static string addDetPagoCta(string cta, string periodo, string id)
        {
            List<DAL.PAGO_CTA> lst = DAL.PAGO_CTA.read(int.Parse(periodo), int.Parse(cta));
            DAL.CTACTE_EXPENSAS obj = DAL.CTACTE_EXPENSAS.getByPk(int.Parse(id));
            StringBuilder html = new StringBuilder();
            html.AppendLine("<div class=\"row\">");
            html.AppendLine("<div class=\"col-md-4\" style=\"border-right: solid 1px #bbbbbb;\">");
            html.AppendLine("<h4>Estado cuenta</h4>");
            html.AppendLine("<ul class=\"nav nav-stacked\">");
            html.AppendLine(string.Format(
                "<li><a href=\"#\">Vencimiento<span class=\"pull-right\">{0:d}</span></a></li>",
                obj.VENCIMIENTO));
            html.AppendLine(string.Format(
                "<li><a href=\"#\">Monto original<span class=\"pull-right\">{0:c}</span></a></li>",
                obj.MONTO_ORIGINAL));
            html.AppendLine(string.Format(
                "<li><a href=\"#\">Saldo capital<span class=\"pull-right\">{0:c}</span></a></li>",
                obj.SALDO_CAPITAL));
            html.AppendLine(string.Format(
                "<li><a href=\"#\">Saldo interes<span class=\"pull-right\">{0:c}</span></a></li>",
                obj.SALDO_INTERES));
            html.AppendLine(string.Format(
                "<li><a href=\"#\">Interes sobre saldo<span class=\"pull-right\">{0:c}</span></a></li>",
                 obj.INTERES_MORA - obj.SALDO_INTERES));
            html.AppendLine(string.Format(
                "<li><a href=\"#\">Total<span class=\"pull-right\">{0:c}</span></a></li>",
                obj.SALDO));
            html.AppendLine("</ul></div><div class=\"col-md-8\">");
            html.AppendLine("<h4>Pagos a cuenta</h4>");
            html.AppendLine("<table class=\"table table-bordered\">");
            html.AppendLine("<tbody>");
            html.AppendLine("<tr style=\"background:cadetblue; color:white;\"></tr>");
            html.AppendLine("<th>Fecha pago</th>");
            html.AppendLine("<th>Monto pagado</th>");
            html.AppendLine("<th>% Cubierto</th>");
            html.AppendLine("<th>Capital pagado</th>");
            html.AppendLine("<th>Interes pagado</th>");
            html.AppendLine("");
            html.AppendLine("");

            foreach (var item in lst)
            {
                html.AppendLine("<tr>");
                html.AppendLine(string.Format("<td>{0:d}</td>", item.FECHA));
                html.AppendLine(string.Format("<td>{0:c}</td>", item.HABER));
                html.AppendLine(string.Format("<td>{0:P}</td>", item.PORCENTAJE_CUBIERTO));
                html.AppendLine(string.Format("<td>{0:C}</td>", item.CAPITAL_CUBIERTO));
                html.AppendLine(string.Format("<td>{0:C}</td>", item.INTERES_CUBIERTO));
                html.AppendLine("</tr>");
            }
            html.AppendLine("</div></tbody></table>");


            return html.ToString();


        }
        [WebMethod]
        public static string addDetInteres(string fechaVenc, string monto,
            string cta, string periodo, string pagoCta)
        {
            DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
            List<DAL.DETALLE_INTERES> lstDetInteres = new List<DAL.DETALLE_INTERES>();

            lstDetInteres = DAL.DETALLE_INTERES.read(
            Convert.ToDateTime(fechaVenc), fec, Convert.ToDecimal(monto));

            StringBuilder html = new StringBuilder();
            html.AppendLine(string.Format(
                "<h4 style=\"font-weight: 600;\">Cuenta: {0} - Periodo: {1}</h4>",
                cta,
                DAL.UTILS.getNombrePeriodo(int.Parse(periodo), int.Parse(cta))));
            html.AppendLine("<hr/>");
            html.Append(string.Format("<p><strong>Monto Original : {0:c} | Intereses entre {1} - {2}</strong></p>",
                monto, Convert.ToDateTime(fechaVenc).ToShortDateString(),
                fec.ToShortDateString()));
            html.AppendLine("<br/><table class=\"table table-bordered\">");
            html.AppendLine("<tbody>");
            html.AppendLine("<tr style=\"background:cadetblue; color:white;\"><th>Año</th><th>Mes</th><th>Tasa mensual</th><th>Tasa diaria</th><th>Dias mora</th><th>Interes</th></tr>");
            foreach (var item in lstDetInteres)
            {
                html.AppendLine("<tr>");
                html.AppendLine(string.Format("<td>{0}</td>", item.ANIO));
                html.AppendLine(string.Format("<td>{0}</td>", item.MES));
                html.AppendLine(string.Format("<td>{0}</td>", item.TASA_MENSUAL));
                html.AppendLine(string.Format("<td>{0}</td>", item.TASA_DIARIA));
                html.AppendLine(string.Format("<td>{0}</td>", item.DIAS_MORA));
                html.AppendLine(string.Format("<td>{0:c}</td>", item.INTERES));
                html.AppendLine("</tr>");
            }
            if (pagoCta != "0")
            {
                html.AppendLine("<tr><td colspan=\"5\">Saldo Interes <small>(Pago a cuenta)</small></td>");
                html.AppendLine(string.Format("<td><strong>{0:c}</strong></td></tr>",
                    Convert.ToDecimal(pagoCta)));
            }
            html.AppendLine("<tr style=\"background:cadetblue; color:white;\"><td colspan=\"5\"><strong>Total</strong></td>");
            html.AppendLine(string.Format("<td>{0:c}</td></tr>",
                lstDetInteres.Sum(t => t.INTERES) + Convert.ToDecimal(pagoCta)));
            html.AppendLine("</tbody></table>");

            return html.ToString();

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
                    if (obj.PAGO_A_CTA > 0)
                    {
                        deudaOriginal += obj.SALDO_CAPITAL;// + obj.INTERES_MORA;
                    }
                    else
                    {
                        deudaOriginal += obj.MONTO_ORIGINAL;
                    }
                    descPagoTermino += obj.DESC_VENCIMIENTO;
                    lst.Add(obj);
                }
            }
            deuda = deudaOriginal - descPagoTermino + intereses;
            lblDeudaPagar.Text = deuda.ToString();
            lblCantSelecionados.Text = select.ToString();
            lblDesc.Text = descPagoTermino.ToString();
            lblInteresMora.Text = intereses.ToString();
            lblMontoOriginal.Text = deudaOriginal.ToString();
            gvConfirmoPago.DataSource = lst;
            gvConfirmoPago.DataBind();
            txtTotDetalle.InnerHtml = deuda.ToString();

            if (lst.Count == 0)
                divAsiento.Visible = false;
            else
                divAsiento.Visible = true;

            if (lst.Exists(c => c.TIPO_MOVIMIENTO == 3))
                btnPlanPago.Visible = false;
            else
                btnPlanPago.Visible = true;
        }

        protected void DDLFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillCta(Convert.ToInt32(Request.QueryString["nrocta"]),
                    DDLFiltro.SelectedIndex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //protected void btnAcentarPago_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();
        //        DAL.CTACTE_EXPENSAS obj;
        //        for (int i = 0; i < gvConfirmoPago.Rows.Count; i++)
        //        {
        //            GridViewRow row = gvConfirmoPago.Rows[i];
        //            obj = DAL.CTACTE_EXPENSAS.getByPk(int.Parse(row.Cells[0].Text));
        //            obj.ID_MEDIO_PAGO = Convert.ToInt32(DDLMedioPago.SelectedItem.Value);
        //            obj.FECHA = ;
        //            obj.SALDO = decimal.Parse(txtMontoVal.Text);
        //            lst.Add(obj);
        //        }

        //        //CTA_CTE.asientaPago(lst, Server.MapPath("certificado.pfx"),
        //        //    leerGrilla());
        //        Response.Redirect(string.Format("inmueble.aspx?nrocta={0}", Request.QueryString["nrocta"]));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected void gvCtaTotal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.CTACTE_EXPENSAS obj = (DAL.CTACTE_EXPENSAS)e.Row.DataItem;

                    HtmlGenericControl divAnchorRecibo = (HtmlGenericControl)
                        e.Row.FindControl("divAnchorRecibo");
                    DAL.USUARIOS objUsu =
DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                    HtmlGenericControl lblCta = (HtmlGenericControl)
    e.Row.FindControl("lblCta");
                    lblCta.InnerHtml = BLL.CTACTE_EXPENSAS.detalle(obj.NRO_CTA,
                        obj.PERIODO, obj.TIPO_MOVIMIENTO, objUsu.ROL);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void linkProductos_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton b = (LinkButton)sender;
                int nroRecibo = int.Parse(b.CommandArgument);
                List<DAL.CTACTE_EXPENSAS> lst = DAL.CTACTE_EXPENSAS.getByRecibo(nroRecibo);

                //Back.mail.reciboPago("allcompva@gmail.com", "Martin Velez",
                //    lst[0].FECHA, lst.Sum(h => h.HABER), nroRecibo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCambioFecha_ServerClick(object sender, EventArgs e)
        {
            try
            {
                List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();
                DAL.CTACTE_EXPENSAS obj;
                for (int i = 0; i < gvConfirmoPago.Rows.Count; i++)
                {
                    GridViewRow row = gvConfirmoPago.Rows[i];
                    obj = DAL.CTACTE_EXPENSAS.getByPk(int.Parse(row.Cells[0].Text));
                    //obj.ID_MEDIO_PAGO = Convert.ToInt32(DDLMedioPago.SelectedItem.Value);
                    obj.FECHA = LaHerradura.Utils.Utils.getFechaActual();
                    lst.Add(obj);
                }


                List<int> lstIdCta = new List<int>();
                foreach (var item in lst)
                {
                    lstIdCta.Add(item.ID);
                }

                string js = JsonConvert.SerializeObject(lstIdCta);
                Response.Redirect(string.Format(
                    "Recalculo.aspx?nrocta={0}&lst={1}",
                    Request.QueryString["nrocta"],
                    js));
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void gvCtaTotal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "btnMailRecibo")
                {
                    int nroRecibo = Convert.ToInt32(e.CommandArgument);
                    List<DAL.CTACTE_EXPENSAS> lst = DAL.CTACTE_EXPENSAS.getByRecibo(nroRecibo);

                    if (lst.Count > 0)
                    {
                        List<DAL.PERSONAS_GRILLA> lstPer = DAL.PERSONAS_GRILLA.getByNroCta(lst[0].NRO_CTA);
                        string propietarios = string.Empty;
                        foreach (var item in lstPer)
                        {
                            if (item.RESPONSABLE_FACTURACION)
                            {
                                propietarios += string.Format("{0}, ", item.NOMBRE);
                            }
                        }
                        List<string> lstMail = new List<string>();
                        List<DAL.MAIL_X_CTAS> ls = DAL.MAIL_X_CTAS.getByCta(lst[0].NRO_CTA);
                        foreach (var item2 in ls)
                        {
                            lstMail.Add(item2.MAIL);
                        }
                        DAL.CTACTE_EXPENSAS obj = lst.Find(c => c.TIPO_MOVIMIENTO == 2);
                        mail.reciboPago(lstMail, propietarios,
                            obj.FECHA, lst.Sum(h => h.HABER), nroRecibo);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
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
                    DAL.DETALLE_DEUDA obj = (DAL.DETALLE_DEUDA)e.Row.DataItem;

                    cant = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CANT"));
                    preunit = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "COSTO"));
                    total += cant * preunit;
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    e.Row.Cells[3].Text = "Total:";
                    e.Row.Cells[4].Text = total.ToString("c");
                    e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Right;
                    e.Row.Font.Bold = true;
                    total = 0;
                }
            }
            catch (Exception ex)
            {
                //divErrorEx.Visible = true;
                //msgError.InnerHtml = ex.Message;
            }
        }

        protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        //protected void DDLMedioPago_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (DDLMedioPago.SelectedIndex == 1)
        //            divCheque.Visible = true;
        //        else
        //            divCheque.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected void gvValores_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnCargarDeuda_Click(object sender, EventArgs e)
        {
            try
            {
                generaDeuda(Convert.ToInt32(DDLPeriodosDeuda.SelectedItem.Value),
                    Convert.ToInt32(Request.QueryString["nrocta"]), Convert.ToDecimal(
                        txtDeuda.Text), Convert.ToDateTime(txtFechaUltimoPago.Text));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvCtaCte_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "quitaDeuda")
                {
                    DAL.CTACTE_EXPENSAS obj = DAL.CTACTE_EXPENSAS.getByPk(
                        int.Parse(e.CommandArgument.ToString()));
                    BLL.CTACTE_EXPENSAS.quitaDeuda(obj.NRO_CTA, obj.PERIODO);
                    fillCta(obj.NRO_CTA, 0);
                }

                if (e.CommandName == "webActiva")
                {
                    DAL.CTACTE_EXPENSAS.activaDesactivaWeb(
                        int.Parse(e.CommandArgument.ToString()), 0);
                    fillCta(Convert.ToInt32(Request.QueryString["nrocta"]), 0);
                }
                if (e.CommandName == "webBloquea")
                {
                    DAL.CTACTE_EXPENSAS.activaDesactivaWeb(
                        int.Parse(e.CommandArgument.ToString()), 1);
                    fillCta(Convert.ToInt32(Request.QueryString["nrocta"]), 0);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLPeriodosDeuda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DAL.LIQUIDACION_EXPENSAS obj = DAL.LIQUIDACION_EXPENSAS.getByPk(
                    Convert.ToInt32(DDLPeriodosDeuda.SelectedItem.Value));
                txtDeuda.Text = obj.MONTO_3.ToString();
                string anio = obj.VENCIMIENTO_3.Year.ToString();
                string mes = obj.VENCIMIENTO_3.Month.ToString().PadLeft(
                    2, Convert.ToChar("0"));
                string dia = obj.VENCIMIENTO_3.Day.ToString().PadLeft(
                    2, Convert.ToChar("0"));
                txtFechaUltimoPago.Text = string.Format("{0}-{1}-{2}",
                    anio, mes, dia);
                //uPanlelCargaDeuda.Update();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnPlanPago_ServerClick(object sender, EventArgs e)
        {
            try
            {
                List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();
                DAL.CTACTE_EXPENSAS obj;
                for (int i = 0; i < gvConfirmoPago.Rows.Count; i++)
                {
                    GridViewRow row = gvConfirmoPago.Rows[i];
                    obj = DAL.CTACTE_EXPENSAS.getByPk(int.Parse(row.Cells[0].Text));
                    //obj.ID_MEDIO_PAGO = Convert.ToInt32(DDLMedioPago.SelectedItem.Value);
                    obj.FECHA = LaHerradura.Utils.Utils.getFechaActual();
                    lst.Add(obj);
                }
                Session["CTAS"] = lst;
                decimal monto = lst.Sum(p => p.SALDO);
                decimal tasa = Convert.ToDecimal(txtTasa.Text);
                int cuotas = int.Parse(DDLCuotas.SelectedItem.Value);
                DateTime fecha = Convert.ToDateTime(txtFechaCupta.Text);
                int sistema = int.Parse(DDLAmortiza.SelectedItem.Value);
                int nroCta = Convert.ToInt32(Request.QueryString["nrocta"]);
                /*
                                 if (Request.QueryString["monto"] == null)
                    return;
                if (Request.QueryString["tasa"] == null)
                    return;
                if (Request.QueryString["cuotas"] == null)
                    return;
                if (Request.QueryString["fecha"] == null)
                    return;
                if (Request.QueryString["sistema"] == null)
                 */

                List<int> lstIdCta = new List<int>();
                foreach (var item in lst)
                {
                    lstIdCta.Add(item.ID);
                }

                string js = JsonConvert.SerializeObject(lstIdCta);

                Response.Redirect(string.Format(
                    "../Secure/PlanesPago.aspx?monto={0}&tasa={1}&cuotas={2}&fecha={3}&sistema={4}&nroCta={5}&lst={6}",
                    monto, tasa, cuotas, fecha, sistema, nroCta, js));
            }
            catch (Exception ex)
            {
                throw;
            }
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
            int nroCta = Convert.ToInt32(Request.QueryString["nrocta"]);
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition",
                "attachment; filename=" + "Libre deuda cta " + nroCta + " " +
                LaHerradura.Utils.Utils.getFechaActual().ToShortDateString() + ".pdf");

            Response.BinaryWrite(strS);
            Response.End();
            Response.Flush();
            Response.Clear();
        }
        private byte[] CreatePDF2()
        {
            int nroCta = Convert.ToInt32(Request.QueryString["nrocta"]);
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
                switch (LaHerradura.Utils.Utils.getFechaActual().Month)
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
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
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

        protected void btnAceptarCancelaDeuda_Click(object sender, EventArgs e)
        {
            try
            {
                string obs = txtObsAnulaComprobante.Text;
                int idUsuario = Convert.ToInt32(Request.Cookies["UserLh"]["Id"]);
                int nroRecibo = int.Parse(hNroRecibo.Value);

                int nro = BLL.ANULA_RECIBO.anulaPago(nroRecibo, obs, idUsuario);
                if (nro == 0)
                    Response.Redirect(string.Format("inmueble.aspx?nrocta={0}", Request.QueryString["nrocta"]));
                else
                {
                    divError.Visible = true;
                    txtError.InnerHtml = string.Format(
                        "El recibo {0} no puede anularse. Debe anular previamente el recibo Nro.: {1}",
                        nroRecibo, nro);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvExport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblTipoMov = (Label)e.Row.FindControl("lblTipoMov");
                    DAL.CTACTE_EXPENSAS obj = (DAL.CTACTE_EXPENSAS)e.Row.DataItem;
                    Label lblPeriodo = (Label)e.Row.FindControl("lblPeriodo");

                    if (obj.PERIODO != 20190100)
                    {
                        if (obj.PERIODO.ToString().Substring(6, 2) == "00")
                            lblPeriodo.Text = string.Format("{0}-{1} Ordinaria",
                                obj.PERIODO.ToString().Substring(0, 4),
                                obj.PERIODO.ToString().Substring(4, 2));
                        else
                            lblPeriodo.Text = string.Format("{0}-{1} Extraordinaria",
                                obj.PERIODO.ToString().Substring(0, 4),
                                obj.PERIODO.ToString().Substring(4, 2));
                    }
                    else
                    {
                        lblPeriodo.Text = "Saldo (capital) a Sept. 2019";
                    }
                    if (obj.TIPO_MOVIMIENTO == 100)
                    {
                        lblPeriodo.Text = string.Format(
                            "Factura {0}-{1}",
                            obj.PTO_VTA.ToString().PadLeft(
                                4, Convert.ToChar("0")),
                            obj.NRO_CTE.ToString().PadLeft(
                                8, Convert.ToChar("0")));
                    }
                    if (obj.TIPO_MOVIMIENTO == 3)
                    {
                        lblPeriodo.Text = string.Format("Plan de pago Nro: {0} - Cuota {1}",
                            obj.NRO_PLAN_PAGO, obj.NRO_CUOTA);
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected void gvMovCtaCte_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.MOVIMIENTO_CTACTE obj =
                        (DAL.MOVIMIENTO_CTACTE)e.Row.DataItem;
                    if (obj.SALDO < 0)
                        e.Row.Cells[5].ForeColor = System.Drawing.Color.Red;
                    else
                        e.Row.Cells[5].ForeColor = System.Drawing.Color.Green;
                    if (obj.DEBE > 0)
                        e.Row.Cells[3].ForeColor = System.Drawing.Color.Red;
                    if (obj.HABER > 0)
                        e.Row.Cells[4].ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void facturar_a_propietario()
        {
            try
            {
                int PtoVta = 21;
                int nroCta = Convert.ToInt32(Request.QueryString["nrocta"]);
                DAL.CUENTA_COMBO objProp = DAL.CUENTA_COMBO.getByNroCta(nroCta);

                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();

                DAL.FACTURAS_X_EXPENSA obj = new DAL.FACTURAS_X_EXPENSA();
                obj.PTO_VTA = PtoVta;
                obj.CUIT = objProp.CUIT;
                obj.DETALLE = txtDescNotaDebito.Text;

                obj.MONTO = decimal.Parse(txtMontoNotaDebito.Text);
                obj.NOMBRE = objProp.PROPIETARIO;
                obj.NRO_CTA = nroCta;
                obj.PAGADO = false;
                obj.TIPO_COMPROBANTE = 21;

                obj.PERIODO = int.Parse(string.Format("{0}{1}21",
                    fec.Year,
                    fec.Month.ToString().PadLeft(
                        2, Convert.ToChar("0"))));

                while (DAL.CTACTE_EXPENSAS.getByPeriodo2(obj.PERIODO,
                    obj.NRO_CTA))
                    obj.PERIODO = obj.PERIODO + 1;

                int idCta = BLL.CTACTE_EXPENSAS.factura(obj,
                     Convert.ToInt32(Request.Cookies["UserLh"]["Id"]), 21);

                obj.ID_CTACTE = idCta;


                DAL.CTACTE_EXPENSAS objCta = new DAL.CTACTE_EXPENSAS();
                objCta.TIPO_MOVIMIENTO = 21;
                objCta.ID = idCta;
                objCta.NRO_CTA = nroCta;
                //objCta.CAE = Convert.ToInt64(cae.FeDetResp[0].CAE);
                objCta.CAE = 11111111111111;
                obj.CAE = objCta.CAE;
                //objCta.NRO_CTE = cae.FeDetResp[0].CbteDesde;
                objCta.NRO_CTE = DAL.FACTURAS_X_EXPENSA.getMaxNotaDebitoInterna() + 1;//obj.PERIODO;
                obj.NRO_CTE = objCta.NRO_CTE;
                objCta.PTO_VTA = PtoVta;
                //int anio = Convert.ToInt32(cae.FeDetResp[0].CbteFch.Substring(0, 4));
                //int mes = Convert.ToInt32(cae.FeDetResp[0].CbteFch.Substring(4, 2));
                //int dia = Convert.ToInt32(cae.FeDetResp[0].CbteFch.Substring(6, 2));
                //objCta.FECHA_CAE = new DateTime(anio, mes, dia);
                objCta.FECHA_CAE = fec;
                obj.FECHA_CAE = objCta.FECHA_CAE;
                //anio = Convert.ToInt32(cae.FeDetResp[0].CAEFchVto.Substring(0, 4));
                //mes = Convert.ToInt32(cae.FeDetResp[0].CAEFchVto.Substring(4, 2));
                //dia = Convert.ToInt32(cae.FeDetResp[0].CAEFchVto.Substring(6, 2));
                //objCta.VENC_CAE = new DateTime(anio, mes, dia);
                objCta.VENC_CAE = fec;
                obj.VENC_CAE = objCta.VENC_CAE;
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
                DAL.CTACTE_EXPENSAS.setAFIP(objCta);
                DAL.FACTURAS_X_EXPENSA.insert(factu);

                Response.Redirect(string.Format(
                    "inmueble.aspx?nrocta={0}", objCta.NRO_CTA));

            }
            catch (Exception ex)
            {

            }
        }
        private void notaCreditoInterna()
        {
            try
            {
                int PtoVta = 31;
                int nroCta = Convert.ToInt32(Request.QueryString["nrocta"]);
                DAL.CUENTA_COMBO objProp = DAL.CUENTA_COMBO.getByNroCta(nroCta);

                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();

                DAL.FACTURAS_X_EXPENSA obj = new DAL.FACTURAS_X_EXPENSA();
                obj.PTO_VTA = PtoVta;
                obj.CUIT = objProp.CUIT;
                obj.DETALLE = txtDescNotaCredito.Text;

                obj.MONTO = decimal.Parse(txtMontoNotaCredito.Text);
                obj.NOMBRE = objProp.PROPIETARIO;
                obj.NRO_CTA = nroCta;
                obj.PAGADO = false;
                obj.TIPO_COMPROBANTE = 31;

                obj.PERIODO = int.Parse(string.Format("{0}{1}31",
                    fec.Year,
                    fec.Month.ToString().PadLeft(
                        2, Convert.ToChar("0"))));

                while (DAL.CTACTE_EXPENSAS.getByPeriodo3(obj.PERIODO,
                    obj.NRO_CTA))
                    obj.PERIODO = obj.PERIODO + 1;

                //int idCta = BLL.CTACTE_EXPENSAS.factura(obj,
                //     Convert.ToInt32(Request.Cookies["UserLh"]["Id"]), 21);

                int idCta = int.Parse(hIdCta.Value);
                obj.ID_CTACTE = idCta;

                obj.CAE = 11111111111111;

                obj.NRO_CTE = DAL.FACTURAS_X_EXPENSA.getMaxNotaCreditoInterna() + 1;
                obj.PTO_VTA = PtoVta;
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
                factu.TIPO_COMPROBANTE = 31;
                factu.MONTO = obj.MONTO;

                factu.DETALLE = obj.DETALLE;

                DAL.FACTURAS_X_EXPENSA.insert(factu);

                decimal monto = obj.MONTO;
                DAL.MOV_BILLETERA objBilletera = new DAL.MOV_BILLETERA();
                objBilletera.FECHA = fec;
                DAL.PERSONAS_X_INMUEBLES objPer =
                    DAL.PERSONAS_X_INMUEBLES.getByNroCta(nroCta);
                objBilletera.ID_PERSONA = objPer.ID_PERSONA;
                objBilletera.MONTO = obj.MONTO;
                objBilletera.NRO_CTA = nroCta;
                objBilletera.NRO_NOTA_CREDITO = obj.NRO_CTE;
                objBilletera.PTO_VTA_NOTA_CREDITO = obj.PTO_VTA;
                objBilletera.TIPO_MOVIMIENTO = 1;
                DAL.MOV_BILLETERA.insert(objBilletera);
                DAL.BILLETERA.setSaldo(nroCta, monto);

                Response.Redirect(string.Format(
                    "inmueble.aspx?nrocta={0}", obj.NRO_CTA));

            }
            catch (Exception ex)
            {

            }
        }
        protected void btnAceptarNotaDebito_ServerClick(object sender, EventArgs e)
        {
            facturar_a_propietario();
        }

        protected void btnAceptarNotaCredito_ServerClick(object sender, EventArgs e)
        {
            notaCreditoInterna();
        }

        protected void btnEmitirNCFiscal_Click(object sender, EventArgs e)
        {
            try
            {
                List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();

                DAL.CTACTE_EXPENSAS obj =
                    DAL.CTACTE_EXPENSAS.getByPk(int.Parse(hIdCta.Value));

                decimal importe = 0;
                if (txtMonto.Text.Contains(".")) // si tiene un punto la caja de texto, usa configuracion regional
                {
                    importe = Convert.ToDecimal(txtMonto.Text,
                        System.Globalization.CultureInfo.InvariantCulture);

                }
                else // aca quiere decir que puso una coma y lo reemplaza por un punto
                {

                    string coma = txtMonto.Text;
                    coma.Replace(',', '.');
                    importe = Convert.ToDecimal(coma);
                }

                obj.DESCUENTO = importe;
                lst.Add(obj);

                //
                DateTime fec = Convert.ToDateTime(txtFechaNC.Text);
                string fecha = string.Format("{0}{1}{2}", fec.Year,
                fec.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                fec.Day.ToString().PadLeft(2, Convert.ToChar("0")));
                if (obj.SALDO == importe)
                    NOTAS_CREDITO.EmitoNotasCreditoNoMasiva(lst,
                        Server.MapPath("certificado.pfx"), fecha,
                        txtDescripcionNCFiscal.Text, true);
                else
                    NOTAS_CREDITO.EmitoNotasCreditoNoMasiva(lst,
                        Server.MapPath("certificado.pfx"), fecha,
                        txtDescripcionNCFiscal.Text, false);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLBancos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDLBancos.SelectedValue == "00285")
                {

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAltaDebito_Click(object sender, EventArgs e)
        {
            try
            {
                divOk.Visible = true;
                msjOk.InnerHtml = "El Alta del Débito Automático no esta Implementada!";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBajaDebito_Click(object sender, EventArgs e)
        {
            try
            {
                divOk.Visible = true;
                msjOk.InnerHtml = "La Baja del Débito no esta Implementada!";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            int nroCta = Convert.ToInt32(Request.QueryString["nrocta"]);
            Response.Redirect(string.Format(
                "inmueble.aspx?nrocta={0}", nroCta));
        }
    }
}
