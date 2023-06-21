using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class servicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    fillServ();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void fillServ()
        {
            try
            {
                gvServicios.DataSource = BLL.Servicios.read();
                gvServicios.DataBind();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}