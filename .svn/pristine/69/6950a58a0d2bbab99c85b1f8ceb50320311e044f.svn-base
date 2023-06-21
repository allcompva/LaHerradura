using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura
{
    public partial class CambioPassVecino : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
                Response.Redirect("index.aspx");
            divError.Visible = false;
            divOk.Visible = false;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.PERSONAS.BlanqueoPass(
                    Convert.ToInt32(Request.QueryString["id"]), txtPass2.Text);
                divCambioPass.Visible = false;
                divOk.Visible = true;
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                msgError.InnerHtml = ex.Message;
            }
        }
    }
}