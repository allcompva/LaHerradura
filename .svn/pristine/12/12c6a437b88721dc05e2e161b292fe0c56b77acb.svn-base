using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class Persona : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["nrocta"] == null)
                        Response.Redirect("cuentas.aspx");
                    if (Request.QueryString["idPersona"] != null)
                    {
                        int idPersona = Convert.ToInt32(Request.QueryString["idPersona"]);
                        fillPersonas(idPersona);
                        fillTelefonos(idPersona);
                    }
                    else
                        divTelefonos.Visible = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        private void fillTelefonos(int idPersona)
        {
            try
            {
                List<DAL.TELEFONO_PERSONA> lst = DAL.TELEFONO_PERSONA.read(idPersona);
                gvTelefonos.DataSource = lst;
                gvTelefonos.DataBind();
                if (lst.Count > 0)
                {
                    gvTelefonos.UseAccessibleHeader = true;
                    gvTelefonos.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fillPersonas(int idPersona)
        {
            try
            {
                DAL.PERSONAS obj = DAL.PERSONAS.getByPk(idPersona);
                txtApellido.Text = obj.APELLIDO;
                if (obj.NRO_CUIT != string.Empty)
                    txtCuit.Text = obj.NRO_CUIT;
                if (obj.FEC_NAC != null)
                    txtFecNac.Text = string.Format("{0}-{1}-{2}", obj.FEC_NAC.Value.Year,
                        obj.FEC_NAC.Value.Month.ToString().PadLeft(2,Convert.ToChar("0")),
                        obj.FEC_NAC.Value.Day.ToString().PadLeft(2, Convert.ToChar("0")));
                txtNombre.Text = obj.NOMBRE;
                txtNroDoc.Text = obj.NRO_DOC;
                if(obj.SEXO != string.Empty)
                    DDLSexo.SelectedValue = obj.SEXO;
                //if(obj.TIPO_DOC != string.Empty)
                //DDLTipoDoc.SelectedValue = 
                divTelefonos.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect(string.Format("inmueble.aspx?nrocta={0}",
                    Request.QueryString["nrocta"]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.PERSONAS obj;
                if (Request.QueryString["idPersona"] != null)
                    obj = DAL.PERSONAS.getByPk(Convert.ToInt32(
                        Request.QueryString["idPersona"]));
                else
                    obj = new DAL.PERSONAS();

                obj.APELLIDO = txtApellido.Text;
                obj.NOMBRE = txtNombre.Text;
                obj.NRO_DOC = txtNroDoc.Text;
                obj.NRO_CUIT = txtCuit.Text;
                obj.SEXO = DDLSexo.SelectedItem.Value;

                if(txtFecNac.Text != string.Empty)
                    obj.FEC_NAC = Convert.ToDateTime(txtFecNac.Text);

                if (Request.QueryString["idPersona"] != null)
                {
                    DAL.PERSONAS.update(obj);
                    fillPersonas(obj.ID);
                }
                else
                {
                    DAL.PERSONAS.insert(obj);
                    Response.Redirect(string.Format("inmueble.aspx?nrocta={0}",
                        Request.QueryString["nrocta"]));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAceptarTelefono_ServerClick(object sender, EventArgs e)
        {
            try
            {
                DAL.TELEFONO_PERSONA obj = new DAL.TELEFONO_PERSONA();
                if (hIdTelefono.Value == string.Empty)
                    obj = new DAL.TELEFONO_PERSONA();
                else
                    obj = DAL.TELEFONO_PERSONA.getByPk(Convert.ToInt32(hIdTelefono.Value));

                obj.COD_AREA = txtCodArea.Text;
                obj.COD_PAIS = txtCodPais.Text;
                obj.NUMERO = txtNro.Text;

                if (hIdTelefono.Value == string.Empty)
                {
                    obj.ID_PERSONA = Convert.ToInt32(Request.QueryString["idPersona"]);
                    DAL.TELEFONO_PERSONA.insert(obj);
                }
                else
                {
                    DAL.TELEFONO_PERSONA.update(obj);
                }
                fillTelefonos(obj.ID_PERSONA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnEliminarMail_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.TELEFONO_PERSONA.delete(Convert.ToInt32(hIdTelefono.Value));
                fillTelefonos(Convert.ToInt32(Request.QueryString["idPersona"]));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}