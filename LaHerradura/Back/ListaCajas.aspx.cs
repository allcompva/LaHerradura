using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class ListaCajas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    List<DAL.VISTA_CAJAS> lst = DAL.VISTA_CAJAS.read();
                    StringBuilder html = new StringBuilder();

                    foreach (var item in lst)
                    {
                        html.AppendLine("<tr>");
                        html.AppendLine("<td style=\"display:none;\"></td>");
                        html.AppendLine(string.Format("<td style=\"white-space: nowrap;\">{0:d}&nbsp;<a href=\"Caja.aspx?id={0}\"><span class=\"fa fa-search\"></span></a></td>",
                            item.HORA.ToShortDateString()));
                        html.AppendLine(string.Format("<td style=\"white-space: nowrap;\">{0:c}</td>",
                            item.SALDO_ANTERIOR_EFECTIVO));
                        html.AppendLine(string.Format("<td style=\"white-space: nowrap;\">{0:c}</td>",
                            item.INGRESO_EFECTIVO));
                        html.AppendLine(string.Format("<td style=\"white-space: nowrap;\">{0:c}</td>",
                            item.EGRESO_EFECTIVO));
                        html.AppendLine(string.Format("<td style=\"white-space: nowrap; font-weight: 800;\">{0:c}</td>",
                            item.SALDO_EFECTIVO));

                        html.AppendLine(string.Format("<td style=\"white-space: nowrap;\">{0:c}</td>",
                            item.SALDO_ANTERIOR_CHEQUE));
                        html.AppendLine(string.Format("<td style=\"white-space: nowrap;\">{0:c}</td>",
                            item.INGRESO_CHEQUE));
                        html.AppendLine(string.Format("<td style=\"white-space: nowrap;\">{0:c}</td>",
                            item.EGRESO_CHEQUE));
                        html.AppendLine(string.Format("<td style=\"white-space: nowrap; font-weight: 800;\">{0:c}</td>",
                            item.SALDO_CHEQUE));

                        html.AppendLine(string.Format("<td style=\"white-space: nowrap;\">{0:c}</td>",
                            item.SALDO_ANTERIOR_BANCO));
                        html.AppendLine(string.Format("<td style=\"white-space: nowrap;\">{0:c}</td>",
                            item.INGRESO_BANCO));
                        html.AppendLine(string.Format("<td style=\"white-space: nowrap;\">{0:c}</td>",
                            item.EGRESO_BANCO));
                        html.AppendLine(string.Format("<td style=\"white-space: nowrap; font-weight: 800;\">{0:c}</td>",
                            item.SALDO_BANCO));
                    }

                    tbDatos.InnerHtml = html.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvCajas_PreRender(object sender, EventArgs e)
        {

        }
    }
}