using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Proveedores
{
    public partial class InfDeuda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<DAL.INF_GASTOS> lst = DAL.INF_GASTOS.read();
                gvCtas.DataSource = lst;
                gvCtas.DataBind();
                if (lst.Count > 0)
                {
                    gvCtas.UseAccessibleHeader = true;
                    gvCtas.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                List<DAL.INF_GASTOS> lstResumen = DAL.INF_GASTOS.readResumen();
                gvResumen.DataSource = lstResumen;
                gvResumen.DataBind();
                if (lstResumen.Count > 0)
                {
                    gvResumen.UseAccessibleHeader = true;
                    gvResumen.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                lblDeuda.InnerHtml = string.Format("{0:c}",
    lst.Sum(d => d.SALDO));
                lblCantCta.InnerHtml = lst.Count.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvCtas_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


        protected void gvResumen_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}