using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class InfDeudaPeriodo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<DAL.INF_DEUDA_PERIODO> lst = DAL.INF_DEUDA_PERIODO.read(
                    Convert.ToInt32(Request.QueryString["periodo"]));

                gvCtas.DataSource = lst;
                gvCtas.DataBind();
                if (lst.Count > 0)
                {
                    gvCtas.UseAccessibleHeader = true;
                    gvCtas.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}