using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class ConceptosExpensa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

            liConfig.Attributes.Add("class", "active");
            divMensajeOk.Visible = false;
            divMensajeError.Visible = false;
            try
            {
                if (!IsPostBack)
                {
                    fillConceptos();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            DAL.USUARIOS obj =
    DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
            if (obj.ROL == 3)
            {
                Response.Redirect("Home.aspx");
            }
        }

        private void fillConceptos()
        {
            try
            {
                List<DAL.CONCEPTOS_EXPENSA> lst = BLL.CONCEPTOS_EXPENSA.read();
                gvConceptos.DataSource = lst;
                gvConceptos.DataBind();
                if (lst.Count > 0)
                {
                    gvConceptos.UseAccessibleHeader = true;
                    gvConceptos.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        protected void gvConceptos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "activar")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    BLL.CONCEPTOS_EXPENSA.activaDesactiva(id, true);

                }
                if (e.CommandName == "desactivar")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    BLL.CONCEPTOS_EXPENSA.activaDesactiva(id, false);
                }
                if (e.CommandName == "borrar")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    bool control = BLL.CONCEPTOS_EXPENSA.delete(id);
                    if (control)
                    {
                        txtMensaje.InnerHtml = "El concepto ha sido borrado con exito";
                        divMensajeOk.Visible = true;
                    }
                    else
                    {
                        txtMensajeError.InnerHtml = "El concepto no puede eliminarse porque ha sido utilizado en una o mas liquidaciones";
                        divMensajeError.Visible = true;
                    }
                }
                
                fillConceptos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvConceptos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.CONCEPTOS_EXPENSA obj = (DAL.CONCEPTOS_EXPENSA)e.Row.DataItem;
                    LinkButton btnActivar = (LinkButton)e.Row.FindControl("btnActivar");
                    LinkButton btnDesactivar = (LinkButton)e.Row.FindControl("btnDesactivar");
                    Label lblSuma = (Label)e.Row.FindControl("lblSuma");
                    Label lblTipo = (Label)e.Row.FindControl("lblTipo");

                    if (obj.ACTIVOS)
                    {
                        btnActivar.Visible = false;
                        btnDesactivar.Visible = true;
                    }
                    else
                    {
                        btnActivar.Visible = true;
                        btnDesactivar.Visible = false;
                        e.Row.BackColor = System.Drawing.Color.FromName("#d73925");
                        e.Row.ForeColor = System.Drawing.Color.White;
                    }

                    if (obj.SUMA)
                        lblSuma.Text = "Cargo";
                    else
                        lblSuma.Text = "Descuento";

                    if (obj.TIPO == 0)
                        lblTipo.Text = "Individual";
                    else
                        lblTipo.Text = "Masivo";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAceptar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                decimal monto;
                bool control = decimal.TryParse(txtMonto.Text, out monto);
                if (!control)
                {
                    txtMensajeError.InnerHtml = 
                        "El monto ingresado no tiene el formato correcto. El campo monto solo permite números";
                    divMensajeError.Visible = true;
                    return;
                }
                if (monto <= 0)
                {
                    txtMensajeError.InnerHtml =
                        "El monto ingresado no puede ser menor o igual a cero";
                    divMensajeError.Visible = true;
                    return;
                }
                DAL.CONCEPTOS_EXPENSA obj;
                if (hId.Value == string.Empty)
                    obj = new DAL.CONCEPTOS_EXPENSA();
                else
                    obj = BLL.CONCEPTOS_EXPENSA.getByPk(int.Parse(hId.Value));

                obj.DESCRIPCION = txtDescripcion.Text;
                obj.ACTIVOS = true;
                switch (DDLSuma.SelectedItem.Value)
                {
                    case "0":
                        obj.SUMA = false;
                        break;
                    case "1":
                        obj.SUMA = true;
                        break;
                    default:
                        break;
                }
                switch (DDLForma.SelectedItem.Value)
                {
                    case "0":
                        obj.MONTO = Convert.ToDecimal(txtMonto.Text);
                        obj.PORCENTAJE = 0;
                        break;
                    case "1":
                        obj.PORCENTAJE = Convert.ToDecimal(txtMonto.Text);
                        obj.MONTO = 0;
                        break;
                    default:
                        break;
                }
                
                obj.TIPO = Convert.ToInt32(DDLTipo.SelectedItem.Value);

                if (hId.Value == string.Empty)
                {
                    BLL.CONCEPTOS_EXPENSA.insert(obj);
                    txtMensaje.InnerHtml = "El concepto ha sido creado con exito";
                    divMensajeOk.Visible = true;
                }
                else
                {
                    BLL.CONCEPTOS_EXPENSA.update(obj);
                    txtMensaje.InnerHtml = "El concepto ha sido modificado con exito";
                    divMensajeOk.Visible = true;
                }
                fillConceptos();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}