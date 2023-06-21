﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class InformeGastos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    List<DAL.VISTA_FACTURAS> lst = fillFacturas(0);
                    gvFacturas.DataSource = lst;
                    gvFacturas.DataBind();
                    if (lst.Count > 0)
                    {
                        gvFacturas.UseAccessibleHeader = true;
                        gvFacturas.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<DAL.VISTA_FACTURAS> fillFacturas(int opcion)
        {
            List<DAL.VISTA_FACTURAS> lst = new List<DAL.VISTA_FACTURAS>();
            switch (opcion)
            {
                case 0:
                    lst = DAL.VISTA_FACTURAS.read();                    
                    break;
                case 1:
                    lst = DAL.VISTA_FACTURAS.read(
                        int.Parse(DDLAnio.SelectedItem.Value),
                        int.Parse(DDLMes.SelectedItem.Value));
                    break;               
                default:
                    break;
            }
            switch (DDLFiltro.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    lst = lst.FindAll(l => l.CUENTA_PASIVO ==
                    DDLCuenta.SelectedItem.Text);
                    break;
                case 2:
                    lst = lst.FindAll(l => l.CUENTA_GASTO ==
                    DDLCuenta.SelectedItem.Text);
                    break;
            }
            txtTotal.Text = string.Format("{0:c}", lst.Sum(l => l.MONTO));
            return lst;

        }
        protected void gvFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    HtmlGenericControl divFecha = (HtmlGenericControl)
                        e.Row.FindControl("divFecha");
                    DAL.VISTA_FACTURAS obj = (DAL.VISTA_FACTURAS)e.Row.DataItem;
                    //divFecha.InnerHtml = string.Format(
                    //    "<span style='display: none;'>{0}{1}{2}</span>{3}",
                    //    obj.FECHA.Year,
                    //    obj.FECHA.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                    //    obj.FECHA.Day.ToString().PadLeft(2, Convert.ToChar("0")),
                    //    obj.FECHA.ToShortDateString());
                    divFecha.InnerHtml = obj.FECHA.ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLFiltroFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDLFiltroFecha.SelectedIndex == 0)
                {
                    divAnio.Visible = false;
                    divMes.Visible = false;
                    List<DAL.VISTA_FACTURAS> lst = fillFacturas(0);
                    gvFacturas.DataSource = lst;
                    gvFacturas.DataBind();
                    if (lst.Count > 0)
                    {
                        gvFacturas.UseAccessibleHeader = true;
                        gvFacturas.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                else
                {
                    divAnio.Visible = true;
                    divMes.Visible = true;
                    List<DAL.VISTA_FACTURAS> lst = fillFacturas(1);
                    gvFacturas.DataSource = lst;
                    gvFacturas.DataBind();
                    if (lst.Count > 0)
                    {
                        gvFacturas.UseAccessibleHeader = true;
                        gvFacturas.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                divAnio.Visible = true;
                divMes.Visible = true;
                List<DAL.VISTA_FACTURAS> lst = fillFacturas(1);
                gvFacturas.DataSource = lst;
                gvFacturas.DataBind();
                if (lst.Count > 0)
                {
                    gvFacturas.UseAccessibleHeader = true;
                    gvFacturas.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<DAL.VISTA_FACTURAS> lst = fillFacturas(1);
                gvFacturas.DataSource = lst;
                gvFacturas.DataBind();
                if (lst.Count > 0)
                {
                    gvFacturas.UseAccessibleHeader = true;
                    gvFacturas.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<DAL.VISTA_FACTURAS> lst = new List<DAL.VISTA_FACTURAS>();
                switch (DDLFiltro.SelectedIndex)
                {
                    case 0:
                        divCuenta.Visible = false;
                        break;
                    case 1:
                        divCuenta.Visible = true;
                        DDLCuenta.DataTextField = "DESC_SUBCUENTA";
                        DDLCuenta.DataValueField = "ID";
                        DDLCuenta.DataSource = DAL.PLAN_CUENTA.read(2, 1);
                        DDLCuenta.DataBind();
                        break;
                    case 2:
                        divCuenta.Visible = true;
                        DDLCuenta.DataTextField = "DESC_SUBCUENTA";
                        DDLCuenta.DataValueField = "ID";
                        DDLCuenta.DataSource = DAL.PLAN_CUENTA.read(4, 2);
                        DDLCuenta.DataBind();
                        break;
                    default:
                        break;
                }
                if (DDLFiltroFecha.SelectedIndex == 0)
                {
                    divAnio.Visible = false;
                    divMes.Visible = false;
                    lst = fillFacturas(0);
                    gvFacturas.DataSource = lst;
                    gvFacturas.DataBind();
                    if (lst.Count > 0)
                    {
                        gvFacturas.UseAccessibleHeader = true;
                        gvFacturas.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                else
                {
                    divAnio.Visible = true;
                    divMes.Visible = true;
                    lst = fillFacturas(1);
                    gvFacturas.DataSource = lst;
                    gvFacturas.DataBind();
                    if (lst.Count > 0)
                    {
                        gvFacturas.UseAccessibleHeader = true;
                        gvFacturas.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<DAL.VISTA_FACTURAS> lst = new List<DAL.VISTA_FACTURAS>();
                if (DDLFiltroFecha.SelectedIndex == 0)
                {
                    divAnio.Visible = false;
                    divMes.Visible = false;
                    lst = fillFacturas(0);
                    gvFacturas.DataSource = lst;
                    gvFacturas.DataBind();
                    if (lst.Count > 0)
                    {
                        gvFacturas.UseAccessibleHeader = true;
                        gvFacturas.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                }
                else
                {
                    divAnio.Visible = true;
                    divMes.Visible = true;
                    lst = fillFacturas(1);
                    gvFacturas.DataSource = lst;
                    gvFacturas.DataBind();
                    if (lst.Count > 0)
                    {
                        gvFacturas.UseAccessibleHeader = true;
                        gvFacturas.HeaderRow.TableSection = TableRowSection.TableHeader;
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