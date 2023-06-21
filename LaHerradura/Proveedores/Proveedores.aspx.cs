﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Proveedores
{
    public partial class Proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divOk.Visible = false;
            txtError.InnerHtml = string.Empty;
            txtOk.InnerHtml = string.Empty;
            if (!IsPostBack)
            {
                fillClientes();
                fillPais();
                fillProvincia(13);
                fillCondicionIVA();
            }
            DAL.USUARIOS obj =
    DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
            if (obj.ROL == 3)
            {
                divAddProv.Visible = false;
            }
        }
        private void fillPlan()
        {
            try
            {
                DDLGastos.DataTextField = "DESC_SUBCUENTA";
                DDLGastos.DataValueField = "ID";
                DDLGastos.DataSource = DAL.PLAN_CUENTA.read(4, 2);
                DDLGastos.DataBind();
                DDLPasivo.DataTextField = "DESC_SUBCUENTA";
                DDLPasivo.DataValueField = "ID";
                DDLPasivo.DataSource = DAL.PLAN_CUENTA.read(2, 1);
                DDLPasivo.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fillCuentasAsignadas()
        {
            try
            {
                gvAsignacionCuentas.DataSource = DAL.CUENTAS_X_PROVEEDOR.read(int.Parse(hIdProv.Value));
                gvAsignacionCuentas.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fillClientes()
        {
            try
            {
                List<DAL.PROVEEDORES> lst = DAL.PROVEEDORES.read();
                gvProveedores.DataSource = lst;
                gvProveedores.DataBind();

                if (lst.Count > 0)
                {
                    gvProveedores.UseAccessibleHeader = true;
                    gvProveedores.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                txtError.InnerText = ex.Message;
                divError.Visible = true;
            }
        }
        private void fillCondicionIVA()
        {
            try
            {
                DDLIva.DataTextField = "DESCRIPCION";
                DDLIva.DataValueField = "id";
                DDLIva.DataSource = DAL.TB_CONDICION_IVA.read();
                DDLIva.DataBind();
            }
            catch (Exception ex)
            {
                txtError.InnerText = ex.Message;
                divError.Visible = true;
            }
        }
        private void fillProvincia(int idPais)
        {
            try
            {
                List<DAL.provincias> lst = DAL.provincias.read(idPais);
                if (lst.Count != 0)
                {
                    DDLProvincia.Visible = true;
                    DDLProvincia.DataSource = lst;
                    DDLProvincia.DataTextField = "provincia";
                    DDLProvincia.DataValueField = "id_provincia";
                    DDLProvincia.DataBind();
                    uPanelModal.Update();
                }
                else { DDLProvincia.Visible = false; }
            }
            catch (Exception ex)
            {
                txtError.InnerText = ex.Message;
                divError.Visible = true;
            }
        }
        private void fillPais()
        {
            try
            {
                DDLPais.DataTextField = "nombre";
                DDLPais.DataValueField = "id";
                DDLPais.DataSource = DAL.paises.read();
                DDLPais.DataBind();
                DDLPais.SelectedValue = "13";
            }
            catch (Exception ex)
            {
                txtError.InnerText = ex.Message;
                divError.Visible = true;
            }
        }
        private void clean()
        {
            try
            {
                txtBarrio.Text = string.Empty;
                txtCalle.Text = string.Empty;
                txtCP.Text = string.Empty;
                txtCUIT.Text = string.Empty;
                txtIngBrutos.Text = string.Empty;
                txtLocalidad.Text = string.Empty;
                txtMail.Text = string.Empty;
                txtNombreFantasia.Text = string.Empty;
                txtNro.Text = string.Empty;
                txtRazonSocial.Text = string.Empty;
                txtTelefono.Text = string.Empty;
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
            DAL.PROVEEDORES obj = new DAL.PROVEEDORES();
            obj.ACTIVO = true;
            if (txtBarrio.Text != string.Empty)
                obj.BARRIO = txtBarrio.Text.Trim().ToUpper();
            else
                obj.BARRIO = string.Empty;
            if (txtCalle.Text != string.Empty)
                obj.CALLE = txtCalle.Text.Trim().ToUpper();
            else
                obj.CALLE = string.Empty;
            obj.COND_IVA = Convert.ToInt32(DDLIva.SelectedItem.Value);
            if (txtCP.Text != string.Empty)
                obj.CP = txtCP.Text.Trim().ToUpper();
            else
                obj.CP = string.Empty;

            if (txtCUIT.Text.Trim().ToUpper().Length != 11)
            {
                txtError.InnerHtml = "El CUIT debe tener 11 dígitos";
                divError.Visible = true;
                return;
            }
            obj.CUIT = txtCUIT.Text.Trim().ToUpper();
            obj.FECHA_ALTA = LaHerradura.Utils.Utils.getFechaActual();
            if (txtIngBrutos.Text != string.Empty)
                obj.ING_BRUTOS = txtIngBrutos.Text.Trim().ToUpper();
            else
                obj.ING_BRUTOS = string.Empty;
            if (txtLocalidad.Text != string.Empty)
                obj.LOCALIDAD = txtLocalidad.Text.Trim().ToUpper();
            else
                obj.LOCALIDAD = string.Empty;
            obj.MAIL = txtMail.Text;
            if (txtNombreFantasia.Text != string.Empty)
                obj.NOMBRE_FANTASIA = txtNombreFantasia.Text;
            else
                obj.NOMBRE_FANTASIA = string.Empty;
            if (txtNro.Text != string.Empty)
                obj.NRO = txtNro.Text.Trim().ToUpper();
            else
                obj.NRO = string.Empty;
            obj.PAIS = Convert.ToInt32(DDLPais.SelectedItem.Value);
            obj.PROVINCIA = Convert.ToInt32(DDLProvincia.SelectedItem.Value);
            obj.RAZON_SOCIAL = txtRazonSocial.Text.Trim().ToUpper();
            if (txtTelefono.Text != string.Empty)
                obj.TEL = txtTelefono.Text.Trim().ToUpper();
            else
                obj.TEL = string.Empty;
            obj.USUARIO_ALTA = Convert.ToInt32(Request.Cookies["UserLh"]["Id"]);
            if (txtWeb.Text != string.Empty)
                obj.WEB = txtWeb.Text;
            else
                obj.WEB = string.Empty;

            if (hID.Value == string.Empty)
            {
                DAL.PROVEEDORES objControl = DAL.PROVEEDORES.getByCuit(obj.CUIT);
                if (objControl == null)
                {
                    DAL.PROVEEDORES.insert(obj);
                    txtOk.InnerHtml = "El proveedor se creo con exito.";
                    divOk.Visible = true;
                }

                else
                {
                    txtError.InnerHtml = "El CUIT ingresado para el proveedor ya existe en la base de datos";
                    divError.Visible = true;
                    return;
                }
            }

            else
            {
                obj.ID = Convert.ToInt32(hID.Value);
                DAL.PROVEEDORES.update(obj);
                txtOk.InnerHtml = "Los datos de actualizaron con exito.";
                divOk.Visible = true;
            }
            fillClientes();
        }

        protected void gvProveedores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Literal txtCondIva = (Literal)e.Row.FindControl("txtCondIva");
                    Literal txtProvincia = (Literal)e.Row.FindControl("txtProvincia");
                    Literal ltlPais = (Literal)e.Row.FindControl("ltlPais");
                    DAL.PROVEEDORES obj = (DAL.PROVEEDORES)e.Row.DataItem;
                    DAL.TB_CONDICION_IVA objIva = DAL.TB_CONDICION_IVA.getByPk(obj.COND_IVA);
                    DAL.provincias objProv = DAL.provincias.getByPk(obj.PROVINCIA);
                    DAL.paises objPais = DAL.paises.getByPk(obj.PAIS);
                    txtCondIva.Text = string.Format("{0} - CUIT: {1}",
                        objIva.DESCRIPCION, obj.CUIT);
                    txtProvincia.Text = objProv.provincia;
                    ltlPais.Text = objPais.nombre;

                    DAL.USUARIOS objUsu =
    DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                    if (objUsu.ROL == 3)
                    {
                        HtmlGenericControl mnuAcciones =
                             (HtmlGenericControl)e.Row.FindControl("mnuAcciones");
                        mnuAcciones.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                txtError.InnerText = ex.Message;
                divError.Visible = true;
            }
        }

        protected void gvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "editar")
                {
                    hID.Value = ID.ToString();
                    DAL.PROVEEDORES obj = DAL.PROVEEDORES.getByPk(ID);
                    txtBarrio.Text = obj.BARRIO;
                    txtCalle.Text = obj.CALLE;
                    txtCP.Text = obj.CP;
                    txtCUIT.Text = obj.CUIT;
                    txtIngBrutos.Text = obj.ING_BRUTOS;
                    txtLocalidad.Text = obj.LOCALIDAD;
                    txtMail.Text = obj.MAIL;
                    txtNombreFantasia.Text = obj.NOMBRE_FANTASIA;
                    txtNro.Text = obj.NRO;
                    txtRazonSocial.Text = obj.RAZON_SOCIAL;
                    txtTelefono.Text = obj.TEL;
                    txtWeb.Text = obj.WEB;

                    DDLIva.SelectedValue = obj.COND_IVA.ToString();
                    DDLPais.SelectedValue = obj.PAIS.ToString();
                    DDLProvincia.SelectedValue = obj.PROVINCIA.ToString();

                    uPanelModal.Update();
                    //lbtnNuevo_ModalPopupExtender.Show();
                }
                if (e.CommandName == "eliminar")
                {
                    DAL.PROVEEDORES.delete(ID);
                    divOk.Visible = true;
                    txtOk.InnerHtml = "El proveedor se elimino con exito";
                    fillClientes();
                }
                if (e.CommandName == "contactos")
                {
                    Response.Redirect(string.Format("Proveedores_contactos.aspx?idEmpresa={0}", e.CommandArgument));
                }
                if (e.CommandName == "contabilidad")
                {
                    divContabilidad.Visible = true;
                    divListado.Visible = false;
                    divAddProv.Visible = false;
                    hIdProv.Value = ID.ToString();
                    DAL.PROVEEDORES objProv = DAL.PROVEEDORES.getByPk(ID);
                    lblTitProv.InnerHtml = string.Format("Razon Social: {0} - Nombre Fantasia: {1}",
                        objProv.RAZON_SOCIAL, objProv.NOMBRE_FANTASIA);
                    fillPlan();
                    fillCuentasAsignadas();
                }
                fillClientes();
            }
            catch (Exception ex)
            {
                txtError.InnerText = ex.Message;
                divError.Visible = true;
            }
        }


        protected void DDLPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillProvincia(Convert.ToInt32(DDLPais.SelectedItem.Value));
            }
            catch (Exception ex)
            {
                txtError.InnerText = ex.Message;
                divError.Visible = true;
            }
        }

        protected void btnAddCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                int idProv = int.Parse(hIdProv.Value);
                int ctaPasivo = Convert.ToInt32(DDLPasivo.SelectedItem.Value);
                int ctaGasto = Convert.ToInt32(DDLGastos.SelectedItem.Value);
                DAL.CUENTAS_X_PROVEEDOR obj = new DAL.CUENTAS_X_PROVEEDOR();
                obj.ID_CTA_CONTABLE_GASTO = ctaGasto;
                obj.ID_CTA_CONTABLE_PASIVO = ctaPasivo;
                obj.ID_PROV = idProv;
                DAL.CUENTAS_X_PROVEEDOR.insert(obj);
                fillCuentasAsignadas();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvAsignacionCuentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "eliminar")
                {
                    int rowIndex = Convert.ToInt32(e.CommandArgument);
                    int idProv = Convert.ToInt32(gvAsignacionCuentas.DataKeys[rowIndex].Values["ID_PROV"]);
                    int idCtaPasivo =
                        Convert.ToInt32(gvAsignacionCuentas.DataKeys[rowIndex].Values["ID_CTA_CONTABLE_PASIVO"]);
                    int idCtaGasto =
                        Convert.ToInt32(gvAsignacionCuentas.DataKeys[rowIndex].Values["ID_CTA_CONTABLE_GASTO"]);
                    DAL.CUENTAS_X_PROVEEDOR.delete(idProv, idCtaPasivo, idCtaGasto);
                    fillCuentasAsignadas();
                    fillPlan();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            divContabilidad.Visible = false;
            divListado.Visible = true;
            hIdProv.Value = string.Empty;
            divAddProv.Visible = true;
            fillClientes();
        }
    }
}