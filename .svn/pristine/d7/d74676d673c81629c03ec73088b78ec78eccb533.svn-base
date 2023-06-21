using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class DetalleLiquidacion : System.Web.UI.Page
    {
        [WebMethod]
        public static List<object> GetChartData()
        {
            List<DAL.LIQUIDACION_EXPENSAS> lstLiq = DAL.LIQUIDACION_EXPENSAS.read();
            lstLiq = lstLiq.OrderBy(l => l.PERIODO).ToList();
            List<object> chartData = new List<object>();
            foreach (var item in lstLiq)
            {

                List<DAL.DetLiq> lst = DAL.DetLiq.getTot(item.PERIODO);
                Decimal totalCtas = lst[0].CANTCTAS;
                Decimal pagas = lst[3].CANTCTAS;
                Decimal adeudadas = totalCtas - pagas;
                chartData.Add(new object[] { string.Format("{0}-{1}/{2}",
                    item.PERIODO.ToString().Substring(0,4),
                    item.PERIODO.ToString().Substring(4,2),
                    item.PERIODO.ToString().Substring(6,2)), adeudadas,  pagas });
            }


            return chartData;
        }
        [WebMethod]
        public static List<object> GetChartDataVencimientos(string periodo)
        {
            List<object> chartData = new List<object>();
            List<DAL.DetLiq> lst = DAL.DetLiq.getVencimientos(Convert.ToInt32(periodo));
            foreach (var item2 in lst)
            {
                chartData.Add(new object[] { item2.DETALLE, item2.CANTCTAS });
            }
            return chartData;
        }
        [WebMethod]
        public static List<object> GetChartDataConceptos(string periodo)
        {
            List<DAL.DetLiq> lst = DAL.DetLiq.getDetalle(Convert.ToInt32(periodo));
            List<object> chartData = new List<object>();
            decimal total = lst.Sum(d => d.TOTAL);
            foreach (var item in lst)
            {
                chartData.Add(new object[] { item.DETALLE, item.TOTAL });
            }


            return chartData;
        }
        [WebMethod]
        public static List<object> GetChartDataConceptosSinExpensa(string periodo)
        {
            List<DAL.DetLiq> lst = DAL.DetLiq.getDetalleSin(Convert.ToInt32(periodo));
            List<object> chartData = new List<object>();
            decimal total = lst.Sum(d => d.TOTAL);
            foreach (var item in lst)
            {
                chartData.Add(new object[] { item.DETALLE, item.TOTAL });
            }


            return chartData;
        }
        [WebMethod]
        public static List<object> drawChartMediosPago(string periodo)
        {
            List<DAL.DetLiq> lst = DAL.DetLiq.getMediosPago(Convert.ToInt32(periodo));
            List<object> chartData = new List<object>();
            decimal total = lst.Sum(d => d.TOTAL);
            foreach (var item in lst)
            {
                chartData.Add(new object[] { item.DETALLE, item.TOTAL });
            }


            return chartData;
        }
        protected void Page_Load(object sender, EventArgs e)
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
                if (Request.QueryString["periodo"] == null)
                    Response.Redirect("expensas.aspx");
                fill(Convert.ToInt32(Request.QueryString["periodo"]));
                hPeriodo.Value = Request.QueryString["periodo"].ToString();
            }
        }
        private void fill(int periodo)
        {
            DAL.LIQUIDACION_EXPENSAS obj = DAL.LIQUIDACION_EXPENSAS.getByPk(periodo);

            lblPeriodo.InnerHtml = string.Format("Resumen Liquidacion Periodo: {0} - {1} / {2}",
                periodo.ToString().Substring(0, 4),
                periodo.ToString().Substring(4, 2),
                periodo.ToString().Substring(6, 2));
            switch (obj.ESTADO)
            {
                case 0:
                    lblEstado.InnerHtml = "Estado: Generado(sin liquidar)";
                    break;
                case 1:
                    lblEstado.InnerHtml = "Estado: Liquidado (sin facturar)";
                    break;
                case 2:
                    lblEstado.InnerHtml = "Estado: Facturado";
                    break;
                default:
                    break;
            }

            List<DAL.DetLiq> objTotFacturado = DAL.DetLiq.getTot(periodo);
            gvResumen1.DataSource = objTotFacturado;
            gvResumen1.DataBind();

            gvResumen.DataSource = DAL.DetLiq.getDetalle(periodo);
            gvResumen.DataBind();

            gvDetalleConceptos.DataSource = DAL.Detalle_Conceptos.read(periodo);
            gvDetalleConceptos.DataBind();

            List<DAL.CTACTE_EXPENSAS> lst = DAL.CTACTE_EXPENSAS.read(periodo);
            gvCuentas.DataSource = lst;
            gvCuentas.DataBind();
            if (lst.Count > 0)
            {
                gvCuentas.UseAccessibleHeader = true;
                gvCuentas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void gvResumen_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvCuentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl divAnchorRecibo = (HtmlGenericControl)
    e.Row.FindControl("divAnchorRecibo");
                    DAL.CTACTE_EXPENSAS obj = (DAL.CTACTE_EXPENSAS)e.Row.DataItem;
                    Label lblFact = (Label)e.Row.FindControl("lblFact");
                    if (obj.PTO_VTA != 0)
                    {
                        lblFact.Text = string.Format("{0}-{1}",
                            obj.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                            obj.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                    }
                    HtmlAnchor comprobante = new HtmlAnchor();

                    HtmlGenericControl li = new HtmlGenericControl();
                    comprobante.Target = "_BLANK";
                    if (obj.TIPO_MOVIMIENTO == 1)
                    {
                        List<DAL.FACTURAS_X_EXPENSA> lstFacturas = DAL.FACTURAS_X_EXPENSA.read(
                            obj.NRO_CTA, obj.PERIODO);
                        HtmlGenericControl divBtnGroup = new HtmlGenericControl();
                        divBtnGroup.TagName = "div";
                        divBtnGroup.Attributes.Add("class", "btn-group");
                        HtmlGenericControl buttonBars = new HtmlGenericControl();
                        buttonBars.TagName = "button";
                        buttonBars.Attributes.Add("class", "btn btn-info dropdown-toggle");
                        buttonBars.Attributes.Add("data-toggle", "dropdown");
                        buttonBars.InnerHtml = "<span class=\"fa fa-bars\"></span>";
                        divBtnGroup.Controls.Add(buttonBars);
                        HtmlGenericControl ul = new HtmlGenericControl();
                        ul.TagName = "ul";
                        ul.Attributes.Add("class", "dropdown-menu");
                        foreach (var item in lstFacturas)
                        {
                            li = new HtmlGenericControl();
                            comprobante = new HtmlAnchor();
                            comprobante.Target = "_BLANK";
                            li.TagName = "li";
                            if (item.NRO_CTE == obj.NRO_CTE && item.TIPO_COMPROBANTE == 11)
                            {
                                //CAMBIO CRYSTALREPORTS
                                //                                comprobante.InnerHtml =
                                //    "<span class=\"fa fa-money\" style=\"text-align:center; font-size:14px;\"> Factura Expensas</span>";
                                //                                comprobante.HRef = string.Format(
                                //"Reportes/Print.aspx?op=factura&nrocta={0}&periodo={1}&idcta={2}",
                                //obj.NRO_CTA, obj.PERIODO, obj.ID);

                                comprobante.InnerHtml =
                                    "<span class=\"fa fa-money\" style=\"text-align:center; font-size:14px;\"> Factura Expensas</span>";
                                comprobante.HRef = string.Format(
"Reportes/Reports.aspx?&nrocta={0}&periodo={1}&idcta={2}",
obj.NRO_CTA, obj.PERIODO, obj.ID);

                                li.Controls.Add(comprobante);
                                ul.Controls.Add(li);
                            }
                            else
                            {
                                if (item.TIPO_COMPROBANTE == 11)
                                {
                                    //
                                    //                                comprobante.InnerHtml =
                                    //    "<span class=\"fa fa-money\" style=\"text-align:center; font-size:14px;\"> Intereses Mora</span>";
                                    //                                comprobante.HRef = string.Format(
                                    //"Reportes/Print.aspx?op=comprobante&nrocta={0}&periodo={1}&idcta={2}&ptoVta={3}&nroCte={4}&tipo=11",
                                    //obj.NRO_CTA, obj.PERIODO, obj.ID, item.PTO_VTA, item.NRO_CTE);
                                    //                                li.Controls.Add(comprobante);
                                    //                                ul.Controls.Add(li);
                                    //hacer
                                    comprobante.InnerHtml =
"<span class=\"fa fa-money\" style=\"text-align:center; font-size:14px;\"> Intereses Mora</span>";
                                    comprobante.HRef = string.Format(
    "Reportes/Print.aspx?op=comprobante&nrocta={0}&periodo={1}&idcta={2}&ptoVta={3}&nroCte={4}&tipo=11",
    obj.NRO_CTA, obj.PERIODO, obj.ID, item.PTO_VTA, item.NRO_CTE);
                                    li.Controls.Add(comprobante);
                                    ul.Controls.Add(li);

                                }
                                else
                                {
                                    comprobante.InnerHtml =
        "<span class=\"fa fa-money\" style=\"text-align:center; font-size:14px;\"> Nota de credito</span>";
                                    comprobante.HRef = string.Format(
    "Reportes/Print.aspx?op=comprobante&nrocta={0}&periodo={1}&idcta={2}&ptoVta={3}&nroCte={4}&tipo=13",
    obj.NRO_CTA, obj.PERIODO, obj.ID, item.PTO_VTA, item.NRO_CTE);
                                    li.Controls.Add(comprobante);
                                    ul.Controls.Add(li);
                                }
                            }

                        }
                        li = new HtmlGenericControl();
                        comprobante = new HtmlAnchor();
                        comprobante.Target = "_BLANK";
                        li.TagName = "li";
                        comprobante.InnerHtml =
"<span class=\"fa fa-search\" style=\"text-align:center; font-size:14px;\"> Detalle cuenta</span>";
                        comprobante.HRef = string.Format(
"inmueble.aspx?nrocta={0}", obj.NRO_CTA);

                        li.Controls.Add(comprobante);
                        ul.Controls.Add(li);
                        divBtnGroup.Controls.Add(ul);
                        /*
                            <a href="inmueble.aspx?nrocta=<%#Eval("NRO_CTA")%>">
                               <span class="fa fa-edit">Ver Cuenta
                               </span>
                            </a> 
                        */
                        divAnchorRecibo.Controls.Add(divBtnGroup);
                    }
                    if (obj.TIPO_MOVIMIENTO == 2)
                    {
                        List<DAL.FACTURAS_X_EXPENSA> lstFacturas = DAL.FACTURAS_X_EXPENSA.read(
                            obj.NRO_CTA, obj.PERIODO);
                        HtmlGenericControl divBtnGroup = new HtmlGenericControl();
                        divBtnGroup.TagName = "div";
                        divBtnGroup.Attributes.Add("class", "btn-group");
                        HtmlGenericControl buttonBars = new HtmlGenericControl();
                        buttonBars.TagName = "button";
                        buttonBars.Attributes.Add("class", "btn btn-info dropdown-toggle");
                        buttonBars.Attributes.Add("data-toggle", "dropdown");
                        buttonBars.InnerHtml = "<span class=\"fa fa-bars\"></span>";
                        divBtnGroup.Controls.Add(buttonBars);
                        HtmlGenericControl ul = new HtmlGenericControl();
                        ul.TagName = "ul";
                        ul.Attributes.Add("class", "dropdown-menu");

                        li = new HtmlGenericControl();
                        comprobante = new HtmlAnchor();
                        comprobante.Target = "_BLANK";
                        li.TagName = "li";
                        //CRYSTALREPORTS
                        //                    comprobante.InnerHtml =
                        //                        "<span class=\"fa fa-download\" style=\"text-align:center; font-size:14px;\"> Comprobante pago</span>";
                        //                    comprobante.HRef = string.Format(
                        //"Reportes/Print.aspx?op=recibo&nroRecibo={0}&fecha={1}", obj.NRO_RECIBO_PAGO,
                        //obj.FECHA);
                        comprobante.InnerHtml =
                        "<span class=\"fa fa-download\" style=\"text-align:center; font-size:14px;\"> Comprobante pago</span>";
                        comprobante.HRef = string.Format(
    "Reportes/Recibo.aspx?nroRecibo={0}", obj.NRO_RECIBO_PAGO);
                        li.Controls.Add(comprobante);
                        ul.Controls.Add(li);
                        divBtnGroup.Controls.Add(ul);
                        divAnchorRecibo.Controls.Add(divBtnGroup);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void geDetalleConceptos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
       
        }
    }
}