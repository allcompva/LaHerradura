﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false;
                divOk.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnIngresar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                DAL.USUARIOS obj = DAL.USUARIOS.validUser(txtMail.Value,
                    txtPass.Value);
                if (obj != null)
                {
                    if (obj.ACTIVO)
                    {
                        this.Response.Cookies.Add(new HttpCookie("UserLh")
                        {
                            ["Id"] = obj.ID.ToString(),
                            ["Rol"] = obj.ROL.ToString(),
                            Expires = LaHerradura.Utils.Utils.getFechaActual().AddDays(1.0)
                        });
                        Response.Redirect("Back/Home.aspx");
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.InnerHtml = "Su usuario esta deshabilitado";
                    }
                }
                else
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Usuario o clave invalidos";
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.InnerHtml = ex.Message;
            }
        }

        protected void btnAceptarCambioPass_ServerClick(object sender, EventArgs e)
        {
            try
            {
                DAL.USUARIOS obj = DAL.USUARIOS.getByUser(txtUsuarioRecupero.Text);
                if (obj == null)
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "El usuario ingresado no es valido";
                }
                else
                {
                    divOk.Visible = true;
                    Back.mail.cambioPass(obj.MAIL, string.Format("{0}, {1}", obj.APELLIDO, obj.NOMBRE),
                        obj.USUARIO, obj.ID);
                    lblOk.InnerHtml = string.Format(
                        "Se ha enviado un correo a {0}. Siga las instrucciones para reestablecer su clave",
                        obj.MAIL);
                }
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.InnerHtml = ex.Message;
            }
        }
    }
}