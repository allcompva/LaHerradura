﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura
{
    public partial class LogIn : System.Web.UI.Page
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
                DAL.PERSONAS obj = DAL.PERSONAS.validUser(txtMail.Value,
                    txtPass.Value);
                if (obj != null)
                {
                    if (obj.ESTADO == 0 && txtPass.Value != "@adminva")
                    {
                        divLogIEstadar.Visible = false;
                        divPrimerIgreso.Visible = true;
                    }
                    else
                    {
                        this.Response.Cookies.Add(new HttpCookie("UserVecinoLh")
                        {
                            ["Id"] = obj.ID.ToString(),
                            Expires = LaHerradura.Utils.Utils.getFechaActual().AddDays(1.0)
                        });
                        Response.Redirect("Secure/Pago.aspx");
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
                lblError.InnerHtml = "Usuario o clave invalidos";
            }
        }

        protected void btnAceptarCambioPass_ServerClick(object sender, EventArgs e)
        {
            try
            {
                DAL.PERSONAS obj = DAL.PERSONAS.getByPk(txtUsuarioRecupero.Text);
                if (obj == null)
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "El usuario ingresado no es valido";
                }
                else
                {
                    divOk.Visible = true;
                    Back.mail.cambioPassVecino(obj.MAIL, string.Format("{0}, {1}", obj.APELLIDO, obj.NOMBRE),
                        obj.NRO_CUIT, obj.ID);
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

        protected void btnCacelar_ServerClick(object sender, EventArgs e)
        {
            txtMail.Value = string.Empty;
            txtNewPass.Value = string.Empty;
            txtNewPass2.Value = string.Empty;
            txtOldPass.Value = string.Empty;
            txtPass.Value = string.Empty;
            txtUsuarioRecupero.Text = string.Empty;
            divLogIEstadar.Visible = true;
            divPrimerIgreso.Visible = false;
        }

        protected void btnCambioPass_ServerClick(object sender, EventArgs e)
        {
            try
            {
                DAL.PERSONAS obj = DAL.PERSONAS.validUser(txtMail.Value,
    txtOldPass.Value);
                if (obj != null)
                {
                    this.Response.Cookies.Add(new HttpCookie("UserVecinoLh")
                    {
                        ["Id"] = obj.ID.ToString(),
                        Expires = LaHerradura.Utils.Utils.getFechaActual().AddDays(1.0)
                    });
                    DAL.PERSONAS.cambioPass2(txtOldPass.Value, txtNewPass2.Value,
                        obj.ID, txtMal.Value);
                    Response.Redirect("Secure/Pago.aspx");
                }
                else
                {
                    lblError.Visible = true;
                    lblError.InnerHtml = "Usuario o clave invalidos";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void Button1_ServerClick(object sender, EventArgs e)
        {
            try
            {
                List<DAL.PERSONAS> lst = DAL.PERSONAS.read();
                foreach (var item in lst)
                {
                    if (item.NRO_CUIT != string.Empty)
                    {
                        DAL.PERSONAS.BlanqueoPass(item.ID, item.NRO_CUIT);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}