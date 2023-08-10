using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class InfPlanes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    List<DAL.VISTA_PLAN> lstActivos = DAL.VISTA_PLAN.read_PendientePago();
                    gvPlanesActivos.DataSource = lstActivos;
                    gvPlanesActivos.DataBind();

                    if (lstActivos.Count > 0)
                    {
                        gvPlanesActivos.UseAccessibleHeader = true;
                        gvPlanesActivos.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    List<DAL.VISTA_PLAN> lstFinalizados = DAL.VISTA_PLAN.read_FinalizadoPago();
                    gvPlanesFinalizados.DataSource = lstFinalizados;
                    gvPlanesFinalizados.DataBind();

                    if (lstFinalizados.Count > 0)
                    {
                        gvPlanesFinalizados.UseAccessibleHeader = true;
                        gvPlanesFinalizados.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvPlanesActivos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvPlanesFinalizados_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}