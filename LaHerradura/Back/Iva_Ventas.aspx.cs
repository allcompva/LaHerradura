﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class Iva_Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                    DDLAnio.SelectedValue = fec.Year.ToString();
                    DDLMes.SelectedValue = fec.Month.ToString();
                    fillLibro(int.Parse(DDLAnio.SelectedItem.Value),
                        int.Parse(DDLMes.SelectedItem.Value));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void fillLibro(int anio, int mes)
        {
            try
            {
                List<DAL.IVA_VENTAS> lst = DAL.IVA_VENTAS.read(anio, mes);
                gvIvaVentas.DataSource = lst;
                gvIvaVentas.DataBind();

                List<DAL.IVA_VENTAS> lstFacturas = lst.FindAll(f => f.TIPO_COMPROBANTE == 11);
                List<DAL.IVA_VENTAS> lstNC = lst.FindAll(f => f.TIPO_COMPROBANTE == 13);

                lblFacturas.InnerHtml = lstFacturas.Count.ToString();
                txtTotalFacturas.Text = string.Format("{0:c}", lstFacturas.Sum(f => f.MONTO));

                lblNC.InnerHtml = lstNC.Count.ToString();
                txtTotalNC.Text = string.Format("{0:c}", lstNC.Sum(f => f.MONTO));

                if (lst.Count > 0)
                {
                    gvIvaVentas.UseAccessibleHeader = true;
                    gvIvaVentas.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillLibro(int.Parse(DDLAnio.SelectedItem.Value),
    int.Parse(DDLMes.SelectedItem.Value));
        }

        protected void DDLMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillLibro(int.Parse(DDLAnio.SelectedItem.Value),
    int.Parse(DDLMes.SelectedItem.Value));
        }
    }
}