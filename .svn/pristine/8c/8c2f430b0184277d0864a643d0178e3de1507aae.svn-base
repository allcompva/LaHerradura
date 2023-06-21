using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class InfMora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                liInmuebles.Attributes.Add("class", "active");

                List<DAL.INMUEBLES> lst = DAL.INMUEBLES.getDeudaMora();
                gvCtas.DataSource = lst;
                gvCtas.DataBind();
                if (lst.Count > 0)
                {
                    gvCtas.UseAccessibleHeader = true;
                    gvCtas.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                lblDeuda.InnerHtml = string.Format("{0:c}",
                    lst.Sum(d => d.SALDO));
                lblCantCta.InnerHtml = lst.Count.ToString();
                lblDeudaPeriodo.InnerHtml = string.Format("{0:c}",
                    lst.Sum(d => d.SALDO));
                lblCantCtaPeriodo.InnerHtml = lst.Count.ToString();
                lblDeudaTotal.InnerHtml = string.Format("{0:c}",
                    lst.Sum(d => d.SALDO));
                lblCantCtaTotal.InnerHtml = lst.Count.ToString();

                List<DAL.INFORME_PERIODOS> lstInfPeriodos = 
                    DAL.INFORME_PERIODOS.readMora();
                gvPeriodos.DataSource = lstInfPeriodos;
                gvPeriodos.DataBind();

                if (lstInfPeriodos.Count > 0)
                {
                    gvPeriodos.UseAccessibleHeader = true;
                    gvPeriodos.HeaderRow.TableSection = TableRowSection.TableHeader;
                }


                gvT.DataSource = lst;
                gvT.DataBind();

                if (lst.Count > 0)
                {
                    gvT.UseAccessibleHeader = true;
                    gvT.HeaderRow.TableSection = TableRowSection.TableHeader;
                }

                List<DAL.INFORME_PERIODOS> lstDet = 
                    DAL.INFORME_PERIODOS.readPeriodosMora();
                gvTotExport.DataSource = lstDet;
                gvTotExport.DataBind();

                if (lstDet.Count > 0)
                {
                    gvTotExport.UseAccessibleHeader = true;
                    gvTotExport.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
        }

        protected void gvCtas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.INMUEBLES obj = new DAL.INMUEBLES();
                    try
                    {
                        obj = (DAL.INMUEBLES)e.Row.DataItem;
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = "Error 1 " + ex.Message;
                    }

                    HtmlGenericControl ulResponsables =
                        (HtmlGenericControl)e.Row.FindControl("ulResponsables");


                    HtmlGenericControl ulMails =
                    (HtmlGenericControl)e.Row.FindControl("ulMails");
                    if (obj == null)
                        return;

                    List<DAL.PERSONAS_GRILLA> lst = new List<DAL.PERSONAS_GRILLA>();
                    try
                    {
                        lst = DAL.PERSONAS_GRILLA.getByNroCta(
                                                obj.NRO_CTA);
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = "Error 2 " + ex.Message;
                    }


                    List<DAL.MAIL_X_CTAS> lstMail = DAL.MAIL_X_CTAS.getByCta(obj.NRO_CTA);

                    foreach (var item in lst)
                    {
                        HtmlGenericControl li = new HtmlGenericControl();
                        li.TagName = "li";
                        HtmlGenericControl p = new HtmlGenericControl();
                        p.TagName = "p";
                        p.Style.Add("padding", "0");
                        if (item.RELACION == "Propietario")
                        {
                            try
                            {
                                p.InnerHtml = string.Format(
                                    "{0}<small class=\"pull-right\">{1}</small>",
                                    item.NOMBRE,
                                    item.RELACION);

                                li.Controls.Add(p);
                            }
                            catch (Exception ex)
                            {
                                lblError.Text = "Error 3 " + ex.Message;
                            }

                        }
                        else
                        {
                            p.InnerHtml = string.Format(
                                "{0} <small class=\"pull-right\">{1}</small>",
                                item.NOMBRE, item.RELACION);
                            li.Controls.Add(p);
                        }
                        if (ulResponsables != null)
                            ulResponsables.Controls.Add(li);
                    }

                    foreach (var item in lstMail)
                    {
                        HtmlGenericControl li = new HtmlGenericControl();
                        li.TagName = "li";
                        HtmlGenericControl p = new HtmlGenericControl();
                        p.TagName = "p";
                        p.Style.Add("padding", "0");

                        p.InnerHtml = item.MAIL;
                        li.Controls.Add(p);
                        if (ulMails != null)
                            ulMails.Controls.Add(li);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvPeriodos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvTotal_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvT_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.INMUEBLES obj = new DAL.INMUEBLES();
                    try
                    {
                        obj = (DAL.INMUEBLES)e.Row.DataItem;
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = "Error 1 " + ex.Message;
                    }

                    HtmlGenericControl ulResponsables =
                        (HtmlGenericControl)e.Row.FindControl("ulResponsables");


                    HtmlGenericControl ulMails =
                    (HtmlGenericControl)e.Row.FindControl("ulMails");
                    if (obj == null)
                        return;

                    List<DAL.PERSONAS_GRILLA> lst = new List<DAL.PERSONAS_GRILLA>();
                    try
                    {
                        lst = DAL.PERSONAS_GRILLA.getByNroCta(
                                                obj.NRO_CTA);
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = "Error 2 " + ex.Message;
                    }


                    List<DAL.MAIL_X_CTAS> lstMail = DAL.MAIL_X_CTAS.getByCta(obj.NRO_CTA);

                    foreach (var item in lst)
                    {
                        HtmlGenericControl li = new HtmlGenericControl();
                        li.TagName = "li";
                        HtmlGenericControl p = new HtmlGenericControl();
                        p.TagName = "p";
                        p.Style.Add("padding", "0");
                        if (item.RELACION == "Propietario")
                        {
                            try
                            {
                                p.InnerHtml = string.Format(
                                    "{0}<small class=\"pull-right\">{1}</small>",
                                    item.NOMBRE,
                                    item.RELACION);

                                li.Controls.Add(p);
                            }
                            catch (Exception ex)
                            {
                                lblError.Text = "Error 3 " + ex.Message;
                            }

                        }
                        else
                        {
                            p.InnerHtml = string.Format(
                                "{0} <small class=\"pull-right\">{1}</small>",
                                item.NOMBRE, item.RELACION);
                            li.Controls.Add(p);
                        }
                        if (ulResponsables != null)
                            ulResponsables.Controls.Add(li);
                    }

                    foreach (var item in lstMail)
                    {
                        HtmlGenericControl li = new HtmlGenericControl();
                        li.TagName = "li";
                        HtmlGenericControl p = new HtmlGenericControl();
                        p.TagName = "p";
                        p.Style.Add("padding", "0");

                        p.InnerHtml = item.MAIL;
                        li.Controls.Add(p);
                        if (ulMails != null)
                            ulMails.Controls.Add(li);
                    }
                    List<DAL.INFORME_PERIODOS> lstInfTotal = DAL.INFORME_PERIODOS.readPeriodosMora(obj.NRO_CTA);
                    GridView gvTotal = (GridView)e.Row.FindControl("gvTotal");
                    gvTotal.DataSource = lstInfTotal;
                    gvTotal.DataBind();


                    if (lstInfTotal.Count > 0)
                    {
                        gvTotal.UseAccessibleHeader = true;
                        gvTotal.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvTotExport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.INFORME_PERIODOS obj = new DAL.INFORME_PERIODOS();
                    try
                    {
                        obj = (DAL.INFORME_PERIODOS)e.Row.DataItem;
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = "Error 1 " + ex.Message;
                    }

                    HtmlGenericControl ulResponsables =
                        (HtmlGenericControl)e.Row.FindControl("ulResponsables");

                    if (obj == null)
                        return;

                    List<DAL.PERSONAS_GRILLA> lst = new List<DAL.PERSONAS_GRILLA>();
                    try
                    {
                        lst = DAL.PERSONAS_GRILLA.getByNroCta(
                                                obj.NRO_CTA);
                    }
                    catch (Exception ex)
                    {
                        lblError.Text = "Error 2 " + ex.Message;
                    }

                    foreach (var item in lst)
                    {
                        HtmlGenericControl li = new HtmlGenericControl();
                        li.TagName = "li";
                        HtmlGenericControl p = new HtmlGenericControl();
                        p.TagName = "p";
                        p.Style.Add("padding", "0");
                        if (item.RELACION == "Propietario")
                        {
                            try
                            {
                                p.InnerHtml = string.Format(
                                    "{0}<small class=\"pull-right\">{1}</small>",
                                    item.NOMBRE,
                                    item.RELACION);

                                li.Controls.Add(p);
                            }
                            catch (Exception ex)
                            {
                                lblError.Text = "Error 3 " + ex.Message;
                            }

                        }
                        else
                        {
                            p.InnerHtml = string.Format(
                                "{0} <small class=\"pull-right\">{1}</small>",
                                item.NOMBRE, item.RELACION);
                            li.Controls.Add(p);
                        }
                        if (ulResponsables != null)
                            ulResponsables.Controls.Add(li);
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<DAL.INMUEBLES> lst = DAL.INMUEBLES.getDeuda();
            lst.RemoveAll(d => d.NRO_CTA == 90);
            lst.RemoveAll(d => d.NRO_CTA == 113);

            foreach (var item in lst)
            {
                List<string> lstMail = new List<string>();
                List<DAL.MAIL_X_CTAS> ls = DAL.MAIL_X_CTAS.getByCta(item.NRO_CTA);
                foreach (var item2 in ls)
                {
                    lstMail.Add(item2.MAIL);
                    //lstMail.Add("allcompva@gmail.com");
                    //lstMail.Add("cornetpablo@gmail.com ");
                }

                //mail.envioMailDeuda(
                //    lstMail,
                //    item.NRO_CTA);

            }
        }
    }
}