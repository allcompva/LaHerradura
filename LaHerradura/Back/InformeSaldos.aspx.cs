﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class InformeSaldos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                    txtFechaCorte.Text = string.Format("{0}-{1}-{2}",
                        fec.Year,
                        fec.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                        fec.Day.ToString().PadLeft(2, Convert.ToChar("0")));
                    fillSaldos(Convert.ToDateTime(txtFechaCorte.Text));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fillSaldos(DateTime fechaCorte)
        {
            try
            {
                List<DAL.VISTA_SALDOS> lst =
                    DAL.VISTA_SALDOS.read(fechaCorte);
                gvSaldos.DataSource = lst;
                gvSaldos.DataBind();
                if (lst.Count > 0)
                {
                    gvSaldos.UseAccessibleHeader = true;
                    gvSaldos.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void gvSaldos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnFechaCorte_Click(object sender, EventArgs e)
        {
            try
            {
                fillSaldos(Convert.ToDateTime(txtFechaCorte.Text));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}