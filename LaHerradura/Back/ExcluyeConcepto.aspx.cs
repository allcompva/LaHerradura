using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class ExcluyeConcepto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
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

                if (Request.QueryString["idConcepto"] == null)
                    Response.Redirect("expensas.aspx");
                if (Request.QueryString["periodo"] == null)
                    Response.Redirect("expensas.aspx");
                if (!IsPostBack)
                {
                    fillCtas(Convert.ToInt32(Request.QueryString["idConcepto"]),
                        Convert.ToInt32(Request.QueryString["periodo"]));
                    DAL.CONCEPTOS_EXPENSA obj = DAL.CONCEPTOS_EXPENSA.getByPk(
                        Convert.ToInt32(Request.QueryString["idConcepto"]));
                    lblConcepto.InnerHtml = string.Format("Exclusión de cuentas de: <strong>{0}</strong>",
                        obj.DESCRIPCION);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void fillCtas(int idConcepto, int periodo)
        {
            List<DAL.INMUEBLES> lstInm = DAL.INMUEBLES.getExcuidas(idConcepto, periodo, false);
            gvCtas.DataSource = lstInm;
            gvCtas.DataBind();

            if (lstInm.Count > 0)
            {
                gvCtas.UseAccessibleHeader = true;
                gvCtas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }

            List<DAL.INMUEBLES> lstInmExc = DAL.INMUEBLES.getExcuidas(idConcepto, periodo, true);
            gvCtasExcluidas.DataSource = lstInmExc;
            gvCtasExcluidas.DataBind();

            if (lstInmExc.Count > 0)
            {
                gvCtasExcluidas.UseAccessibleHeader = true;
                gvCtasExcluidas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        protected void btnActualiza_Click(object sender, EventArgs e)
        {

        }

        protected void gvCtas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.INMUEBLES obj = (DAL.INMUEBLES)e.Row.DataItem;
                    HtmlGenericControl ulResponsables =
                        (HtmlGenericControl)e.Row.FindControl("ulResponsables");

                    List<DAL.PERSONAS_GRILLA> lst = DAL.PERSONAS_GRILLA.getByNroCta(
                        obj.NRO_CTA);
                    foreach (var item in lst)
                    {
                        HtmlGenericControl li = new HtmlGenericControl();
                        li.TagName = "li";
                        HtmlGenericControl p = new HtmlGenericControl();
                        p.TagName = "p";
                        p.Style.Add("padding", "0");

                        p.InnerHtml = string.Format(item.NOMBRE);
                        li.Controls.Add(p);

                        ulResponsables.Controls.Add(li);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvCtas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "excluir")
                {
                    int concepto = Convert.ToInt32(Request.QueryString["idConcepto"]);
                    int periodo = Convert.ToInt32(Request.QueryString["periodo"]);
                    int nro_cta = Convert.ToInt32(e.CommandArgument);
                    DAL.EXCLUSION_CONCEPTO obj = new DAL.EXCLUSION_CONCEPTO();
                    obj.ID_CONCEPTO = concepto;
                    obj.NRO_CTA = nro_cta;
                    obj.PERIODO = periodo;
                    DAL.EXCLUSION_CONCEPTO.insert(obj);
                    fillCtas(concepto, periodo);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void gvCtasExcluidas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "incluir")
                {
                    int concepto = Convert.ToInt32(Request.QueryString["idConcepto"]);
                    int periodo = Convert.ToInt32(Request.QueryString["periodo"]);
                    int nro_cta = Convert.ToInt32(e.CommandArgument);
                    DAL.EXCLUSION_CONCEPTO obj = new DAL.EXCLUSION_CONCEPTO();
                    obj.ID_CONCEPTO = concepto;
                    obj.NRO_CTA = nro_cta;
                    obj.PERIODO = periodo;
                    DAL.EXCLUSION_CONCEPTO.delete(obj);
                    fillCtas(concepto, periodo);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}