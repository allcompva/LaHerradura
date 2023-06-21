using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalServicios.BackEnd
{
    public partial class CarnetConfig : System.Web.UI.Page
    {
        //OK
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["idServ"] != null)
                {
                    fillAgenda(Convert.ToInt32(Request.QueryString["idServ"]));
                }
            }
        }
        //OK
        private void fillAgenda(int idServ)
        {
            gvHorarios.DataSource = BLL.Carnets.AGENDA_GENERAL.read(idServ);
            gvHorarios.DataBind();
        }
        //OK
        protected void btnConfigurarHorarios_ServerClick(object sender, EventArgs e)
        {
            divHorarios.Visible = true;
            divOpciones.Visible = false;
        }
        //OK
        protected void btnCancelarHorarios_Click(object sender, EventArgs e)
        {
            divHorarios.Visible = false;
            divOpciones.Visible = true;
        }
        //OK
        protected void btnGuardarHorarios_Click(object sender, EventArgs e)
        {

        }
        //OK
        protected void gvHorarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvHorarios.Rows[index];
            TextBox txtHoraInicio = (TextBox)row.FindControl("txtHoraInicio");
            TextBox txtHoraCierre = (TextBox)row.FindControl("txtHoraCierre");
            TextBox txtHoraIntervalo = (TextBox)row.FindControl("txtHoraIntervalo");
            TextBox txtHoraTurnosSimultaneos = (TextBox)row.FindControl("txtHoraTurnosSimultaneos");
            string DIA = gvHorarios.DataKeys[index].Value.ToString();
            DAL.Carnets.AGENDA_GENERAL obj =
                BLL.Carnets.AGENDA_GENERAL.getByDia(DIA, Convert.ToInt32(Request.QueryString["idServ"]));

            DateTime horainicio = Convert.ToDateTime(txtHoraInicio.Text);
            obj.HORA_INICIO = new TimeSpan(horainicio.Hour, horainicio.Minute, 0);

            DateTime horacierre = Convert.ToDateTime(txtHoraCierre.Text);
            obj.HORA_CIERRE = new TimeSpan(horacierre.Hour, horacierre.Minute, 0);

            obj.INTERVALO = Convert.ToInt32(txtHoraIntervalo.Text);
            obj.TURNOS_SIMULTANEOS = Convert.ToInt32(txtHoraTurnosSimultaneos.Text);
            BLL.Carnets.AGENDA_GENERAL.update(obj);
            fillAgenda(Convert.ToInt32(Request.QueryString["idServ"]));
        }
    }
}