using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Proveedores
{
    public partial class Proveedores_contactos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idEmpresa"] == null)
                Response.Redirect("Proveedores.aspx");
            divOk.Visible = false;
            divError.Visible = false;
            txtOk.InnerHtml = string.Empty;
            txtError.InnerHtml = string.Empty;
            if (!IsPostBack)
            {
                int idEmpresa = Convert.ToInt32(Request.QueryString["idEmpresa"]);
                lblEmpresa.InnerText = DAL.PROVEEDORES.getByPk(idEmpresa).NOMBRE_FANTASIA;
                fillClientes(idEmpresa);
            }
        }
        private void clean()
        {
            try
            {
                txtApellido.Text = string.Empty;
                txtArea.Text = string.Empty;
                txtCel.Text = string.Empty;
                txtInterno.Text = string.Empty;
                txtMail.Text = string.Empty;
                txtNombre.Text = string.Empty;
                txtTelefono.Text = string.Empty;
            }
            catch (Exception ex)
            {
                txtError.InnerText = ex.Message;
                divError.Visible = true;
            }
        }
        private void fillClientes(int idEmpresa)
        {
            try
            {
                gvContactos.DataSource = DAL.CONTACTOS.read(idEmpresa);
                gvContactos.DataBind();

            }
            catch (Exception ex)
            {
                txtError.InnerText = ex.Message;
                divError.Visible = true;
            }
        }
        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            clean();
            hID.Value = string.Empty;
        }

        protected void gvContactos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvContactos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "editar")
                {
                    hID.Value = ID.ToString();
                    DAL.CONTACTOS obj = DAL.CONTACTOS.getByPk(ID);
                    txtApellido.Text = obj.APELLIDO;
                    txtArea.Text = obj.AREA;
                    txtCel.Text = obj.CELULAR;
                    txtInterno.Text = obj.INTERNO;
                    txtMail.Text = obj.MAIL;
                    txtNombre.Text = obj.NOMBRE;
                    txtTelefono.Text = obj.TELEFONO;
                    DDLSexo.SelectedValue = obj.SEXO.ToString();

                }
                if (e.CommandName == "eliminar")
                {
                    DAL.CONTACTOS.delete(ID);
                    fillClientes(Convert.ToInt32(Request.QueryString["idEmpresa"]));
                    divOk.Visible = true;
                    txtOk.InnerHtml = "El contacto se ha eliminado con exito";
                }

            }
            catch (Exception ex)
            {
                txtError.InnerText = ex.Message;
                divError.Visible = true;
            }
        }

        protected void btnCancelarModal_Click(object sender, EventArgs e)
        {
            clean();
        }

        protected void btnCrearCliente_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.CONTACTOS obj = new DAL.CONTACTOS();
                obj.ACTIVO = true;
                obj.APELLIDO = txtApellido.Text.Trim().ToUpper();
                if (txtArea.Text != string.Empty)
                    obj.AREA = txtArea.Text.Trim().ToUpper();
                else
                    obj.AREA = string.Empty;
                if (txtCel.Text != string.Empty)
                    obj.CELULAR = txtCel.Text.Trim().ToUpper();
                else
                    obj.CELULAR = string.Empty;
                obj.FECHA_ALTA = LaHerradura.Utils.Utils.getFechaActual();
                obj.USUARIO_ALTA = Convert.ToInt32(Request.Cookies["UserLh"]["Id"]);

                obj.ID_EMPRESA = Convert.ToInt32(Request.QueryString["idEmpresa"]);
                if (txtInterno.Text != string.Empty)
                    obj.INTERNO = txtInterno.Text.Trim().ToUpper();
                else
                    obj.INTERNO = string.Empty;
                if (txtMail.Text != string.Empty)
                    obj.MAIL = txtMail.Text.Trim().ToUpper();
                else
                    obj.MAIL = string.Empty;
                obj.NOMBRE = txtNombre.Text.Trim().ToUpper();
                obj.SEXO = DDLSexo.SelectedItem.Value.ToString();
                if (txtTelefono.Text != string.Empty)
                    obj.TELEFONO = txtTelefono.Text.Trim().ToUpper();
                else
                    obj.TELEFONO = string.Empty;

                if (hID.Value == string.Empty)
                {
                    DAL.CONTACTOS.insert(obj);
                    divOk.Visible = true;
                    txtOk.InnerHtml = "El contacto se ha creado con exito";
                }

                else
                {
                    obj.ID = Convert.ToInt32(hID.Value);
                    DAL.CONTACTOS.update(obj);
                    divOk.Visible = true;
                    txtOk.InnerHtml = "El contacto se ha modificado con exito";
                }
                fillClientes(Convert.ToInt32(Request.QueryString["idEmpresa"]));
            }
            catch (Exception ex)
            {
                txtError.InnerText = ex.Message;
                divError.Visible = true;
            }
        }
    }
}