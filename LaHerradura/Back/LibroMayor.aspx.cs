using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class LibroMayor : System.Web.UI.Page
    {
        decimal saldoAntDebe = 0;
        decimal saldoAntHaber = 0;
        decimal sumaDebe = 0;
        decimal sumaHaber = 0;
        decimal saldoDebe = 0;
        decimal saldoHaber = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            if (!IsPostBack)
            {
                txtFechaInicio.Text = string.Format("{0}-{1}-{2}",
                    int.Parse(DDLEjercicio.SelectedItem.Value),
                    "01", "01");
                txtFechaFin.Text = string.Format("{0}-{1}-{2}",
                    int.Parse(DDLEjercicio.SelectedItem.Value),
                    "12", "31");
                fillAsientos(1);
            }
        }
        private void fillAsientos(int filtro)
        {
            try
            {
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                DateTime fechaInicio = Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                    fec.Year, fec.Month, 1));
                DateTime fechaFin = Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                    fec.Year, fec.Month,
                    DateTime.DaysInMonth(fec.Year, fec.Month)));

                List<DAL.LIBRO_MAYOR> lst = new List<DAL.LIBRO_MAYOR>();

                switch (filtro)
                {
                    case 1:
                        fechaInicio = Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                            int.Parse(DDLEjercicio.SelectedItem.Value), 1, 1));
                        fechaFin = Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                            int.Parse(DDLEjercicio.SelectedItem.Value), 12, 31));
                        lst = DAL.LIBRO_MAYOR.read(fechaInicio, fechaFin);
                        break;
                    case 2:
                        fechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
                        fechaFin = Convert.ToDateTime(txtFechaFin.Text);

                        if (fechaInicio.Year !=
                            int.Parse(DDLEjercicio.SelectedItem.Value))
                        {
                            divError.Visible = true;
                            lblError.InnerHtml = "El año de la fecha de inicio no puede ser diferente al año del ejercicio";
                            return;
                        }
                        if (fechaFin.Year !=
                            int.Parse(DDLEjercicio.SelectedItem.Value))
                        {
                            divError.Visible = true;
                            lblError.InnerHtml = "El año de la fecha de inicio no puede ser diferente al año del ejercicio";
                            return;
                        }
                        lst = DAL.LIBRO_MAYOR.read(fechaInicio, fechaFin);
                        break;
                    default:
                        break;
                }
                //lst.RemoveAll(l => l.DEBE == 0 && l.HABER == 0 &
                //    l.SALDO_ANTERIOR_DEBE == 0 & l.SALDO_ANTERIOR_HABER == 0 &
                //    l.SALDO_DEBE == 0 & l.SALDO_HABER == 0);
                gvBalance.DataSource = lst;
                gvBalance.DataBind();
                if (lst.Count > 0)
                {
                    gvBalance.UseAccessibleHeader = true;
                    gvBalance.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                txtFechaInicio.Text = string.Format("{0}-{1}-{2}",
                    fechaInicio.Year,
                    fechaInicio.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                    fechaInicio.Day.ToString().PadLeft(2, Convert.ToChar("0")));
                txtFechaFin.Text = string.Format("{0}-{1}-{2}",
                    fechaFin.Year,
                    fechaFin.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                    fechaFin.Day.ToString().PadLeft(2, Convert.ToChar("0")));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        protected void gvBalance_DataBound(object sender, EventArgs e)
        {

        }

        protected void gvBalance_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.LIBRO_MAYOR obj = (DAL.LIBRO_MAYOR)e.Row.DataItem;
                    //saldoAntDebe += obj.SALDO_ANTERIOR_DEBE;
                    //saldoAntHaber += obj.SALDO_ANTERIOR_HABER;
                    //sumaDebe += obj.DEBE;
                    //sumaHaber += obj.HABER;
                    //saldoDebe += obj.SALDO_DEBE;
                    //saldoHaber += obj.SALDO_HABER;

                    //HtmlGenericControl pCuenta = (HtmlGenericControl)
                    //    e.Row.FindControl("pCuenta");
                    //HtmlGenericControl pDebe = (HtmlGenericControl)
                    //    e.Row.FindControl("pDebe");
                    //HtmlGenericControl pHaber = (HtmlGenericControl)
                    //    e.Row.FindControl("pHaber");
                    //HtmlGenericControl pSaldo = (HtmlGenericControl)
                    //    e.Row.FindControl("pSaldo");

                    if (obj.NRO_ASIENTO == 0)
                    {
                        e.Row.Cells[0].Style.Add("border", "2px solid");
                        e.Row.Cells[0].Style.Add("font-weight", "800");
                        e.Row.Cells[1].Style.Add("border", "2px solid");
                        e.Row.Cells[1].Style.Add("font-weight", "800");
                        e.Row.Cells[2].Style.Add("border", "2px solid");
                        e.Row.Cells[2].Style.Add("font-weight", "800");
                        e.Row.Cells[3].Style.Add("border", "2px solid");
                        e.Row.Cells[3].Style.Add("font-weight", "800");
                    }
                        //    pCuenta.InnerHtml = string.Format("<strong>{0}</strong>",
                        //        obj.CUENTA);
                        //    pDebe.InnerHtml = string.Format("<strong>{0}</strong>",
                        //        obj.DEBE);
                        //    pHaber.InnerHtml = string.Format("<strong>{0}</strong>",
                        //        obj.HABER);
                        //    pSaldo.InnerHtml = string.Format("<strong>{0}</strong>",
                        //        obj.SALDO);
                        //}
                        //else
                        //{
                        //    pCuenta.InnerHtml = string.Format(
                        //        "<span style=\"padding-left:25px;\">Ref.: {0} - {1}</span>",
                        //        obj.NRO_ASIENTO, obj.DESCRIPCION);
                        //    pDebe.InnerHtml = string.Format("<span>{0}</span>",
                        //        obj.DEBE);
                        //    pHaber.InnerHtml = string.Format("<span>{0}</span>",
                        //        obj.HABER);
                        //    pSaldo.InnerHtml = string.Format("<span>{0}</span>",
                        //        obj.SALDO);
                        //}
                        //lblSaldoAntDebe.InnerHtml = string.Format("{0:c}", saldoAntDebe);
                        //lblSaldoAntHaber.InnerHtml = string.Format("{0:c}", saldoAntHaber);
                        //lblSumaDebe.InnerHtml = string.Format("{0:c}", sumaDebe);
                        //lblSumaHaber.InnerHtml = string.Format("{0:c}", sumaHaber);
                        //lblSaldoDebe.InnerHtml = string.Format("{0:c}", saldoDebe);
                        //lblSaldoHaber.InnerHtml = string.Format("{0:c}", saldoHaber);
                    }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                fillAsientos(2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}