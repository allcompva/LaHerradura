using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class EmitoComprobantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int periodo = Convert.ToInt32(
                    string.Format("{0}{1}{2}",
                    DDLAnio.SelectedItem.Value,
                    DDLMes.SelectedItem.Value,"00"));
                List<DAL.CTACTE_EXPENSAS> lst = DAL.CTACTE_EXPENSAS.Read_NC_aEmitir(periodo);
                gvCtas.DataSource = lst;
                gvCtas.DataBind();
                if (lst.Count > 0)
                {
                    gvCtas.UseAccessibleHeader = true;
                    gvCtas.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                DAL.USUARIOS obj =
    DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                if (obj.ROL == 3)
                {
                    Response.Redirect("Home.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLAnio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DDLMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvCtas_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnEmitirNC_Click(object sender, EventArgs e)
        {
            try
            {
                List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();
                if (hIdCta.Value == string.Empty)
                {
                    int periodo = Convert.ToInt32(
                    string.Format("{0}{1}{2}",
                    DDLAnio.SelectedItem.Value,
                    DDLMes.SelectedItem.Value, "00"));
                    lst = DAL.CTACTE_EXPENSAS.Read_NC_aEmitir(periodo);
                }
                else
                {
                    DAL.CTACTE_EXPENSAS obj = DAL.CTACTE_EXPENSAS.getByPk(int.Parse(hIdCta.Value));
                    lst.Add(obj);
                }
                //
                DateTime fec = Convert.ToDateTime(txtFecha.Text);
                string fecha = string.Format("{0}{1}{2}", fec.Year,
                fec.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                fec.Day.ToString().PadLeft(2, Convert.ToChar("0")));

                NOTAS_CREDITO.EmitoNotasCredito(lst, 
                    Server.MapPath("certificado.pfx"), fecha);
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

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}