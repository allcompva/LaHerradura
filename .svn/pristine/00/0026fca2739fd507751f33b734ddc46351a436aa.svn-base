using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    fillGrillaUsuarios();
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
        private void fillGrillaUsuarios()
        {
            try
            {
                List<DAL.USUARIOS> lst = DAL.USUARIOS.read();
                gvUsuarios.DataSource = lst;
                gvUsuarios.DataBind();
                if (lst.Count > 0)
                {
                    gvUsuarios.UseAccessibleHeader = true;
                    gvUsuarios.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnAceptarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.USUARIOS obj;
                if (hIdUsuario.Value == string.Empty)
                    obj = new DAL.USUARIOS();
                else
                    obj = DAL.USUARIOS.getByPk(int.Parse(hIdUsuario.Value));

                obj.ACTIVO = true;
                obj.APELLIDO = txtApellido.Text;
                obj.CEL = txtTelefono.Text;
                obj.MAIL = txtMail.Text;
                obj.NOMBRE = txtNombre.Text;
                if (hIdUsuario.Value == string.Empty)
                    obj.PASS = txtPass.Text;
                obj.ROL = int.Parse(DDLRol.SelectedItem.Value);
                obj.USUARIO = txtUsuario.Text;
                if (hIdUsuario.Value == string.Empty)
                    DAL.USUARIOS.insert(obj);
                else
                    DAL.USUARIOS.update(obj);

                fillGrillaUsuarios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAceptarCambioPass_Click(object sender, EventArgs e)
        {

        }

        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.USUARIOS obj = (DAL.USUARIOS)e.Row.DataItem;
                    LinkButton btnActivar = (LinkButton)e.Row.FindControl("btnActivar");
                    LinkButton btnDesactivar = (LinkButton)e.Row.FindControl("btnDesactivar");
                    LinkButton btnEliminar = (LinkButton)e.Row.FindControl("btnEliminar");
                    if (obj.ACTIVO)
                    {
                        btnActivar.Visible = false;
                        btnDesactivar.Visible = true;
                    }
                    else
                    {
                        btnActivar.Visible = true;
                        btnDesactivar.Visible = false;
                    }
                    if (obj.ID == 1)
                    {
                        btnActivar.Visible = false;
                        btnDesactivar.Visible = false;
                        btnEliminar.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "eliminar")
                {
                    DAL.USUARIOS.delete(int.Parse(e.CommandArgument.ToString()));
                    fillGrillaUsuarios();
                }
                if (e.CommandName == "activar")
                {
                    DAL.USUARIOS.activaDesactiva(
                        int.Parse(e.CommandArgument.ToString()), true);
                    fillGrillaUsuarios();
                }
                if (e.CommandName == "desactivar")
                {
                    DAL.USUARIOS.activaDesactiva(
                        int.Parse(e.CommandArgument.ToString()), false);
                    fillGrillaUsuarios();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnClearPass_Click(object sender, EventArgs e)
        {

        }

        protected void btnClearPass_Click1(object sender, EventArgs e)
        {
            try
            {
                DAL.USUARIOS.ClearPass(int.Parse(hIdUsuario.Value), txtConfirmNewPass.Text);
                fillGrillaUsuarios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}