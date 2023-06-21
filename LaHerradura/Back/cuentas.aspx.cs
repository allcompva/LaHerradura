using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class cuentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<DAL.INMUEBLES> lst = DAL.INMUEBLES.read();
                gvCtas.DataSource = lst;
                gvCtas.DataBind();

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

                if (lst.Count > 0)
                {
                    gvCtas.UseAccessibleHeader = true;
                    gvCtas.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                                if (item.CUIT.Length > 7)
                                {
                                    p.InnerHtml = string.Format(
                                        "{0}<br> CUIT: {1}-{2}-{3} <span class=\"pull-right badge bg-blue\">{4}</span>",
                                        item.NOMBRE,
                                        item.CUIT.Substring(0, 2),
                                        item.CUIT.Substring(2, 8),
                                        item.CUIT.Substring(10, 1),
                                        item.RELACION);
                                }
                                else
                                {
                                    p.InnerHtml = string.Format(
                                        "{0}<span class=\"pull-right badge bg-blue\">{1}</span>",
                                        item.NOMBRE,
                                        item.RELACION);
                                }
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
                                "{0} <span class=\"pull-right badge bg-yellow\">{1}</span>",
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

        protected void Button1_Click(object sender, EventArgs e)
        {
        }


    }
}