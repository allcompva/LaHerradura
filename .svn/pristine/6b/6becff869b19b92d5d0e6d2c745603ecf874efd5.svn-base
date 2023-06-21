using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PortalServicios.BackEnd
{
    public partial class CarnetAddTurno2 : System.Web.UI.Page
    {
        //OK
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //HtmlGenericControl divMenu = (HtmlGenericControl)this.Master.FindControl("divMenu");
                //divMenu.Visible = false;
                if (!IsPostBack)
                {
                    Calendar1.SelectedDate = LaHerradura.Utils.Utils.getFechaActual().AddDays(1);
                    DAL.INMUEBLES obj = BLL.INMUEBLES.getByNroCta(
                        Convert.ToInt32(Request.QueryString["id"]));
                    hNroCta.Value = obj.NRO_CTA.ToString();
                    DAL.SERVICIOS objServ = BLL.Servicios.getByPk(
                        Convert.ToInt32(Request.QueryString["serv"]));

                    fill(obj, objServ);
                    UpdatePanel1.Update();
                }
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                msjOk.InnerText = ex.Message;
            }

        }
        //OK
        private void fill(DAL.INMUEBLES obj, DAL.SERVICIOS objServ)
        {
            try
            {
                hTitulo.InnerHtml = string.Format(
                    "{0} {1} <small style=\"font-size:16px;\">{2}</small>",
                    obj.CALLE, obj.NRO, objServ.DESCRIPCION);

            }
            catch (Exception ex)
            {
                divError.Visible = true;
                msjOk.InnerText = ex.Message;
            }

        }
        //OK
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                lblFechaTurno.Text = string.Empty;
                lblHoraTurno.Text = string.Empty;
                modalTurno.Visible = false;

                lblMensaje.Font.Bold = true;
                DateTime fecha = Convert.ToDateTime(Calendar1.SelectedDate.ToShortDateString());
                if (fecha < Convert.ToDateTime(LaHerradura.Utils.Utils.getFechaActual().ToShortDateString()))
                {
                    lblMensaje.Text = 
                        "No pueden otorgarse turnos para fechas anteriores a la fecha actual";
                    lstHorarios.Visible = false;
                    return;
                }
                lblDia.Text = string.Empty;
                lblHorario.Text = string.Empty;
                lstHorarios.SelectedIndex = -1;

                DAL.Carnets.DIAS_NO_LABORALES objDiaNoLaboral = 
                    BLL.Carnets.DIAS_NO_LABORALES.getByFecha(fecha);

                if (objDiaNoLaboral != null)
                {
                    lstHorarios.DataSource = null;
                    lstHorarios.DataBind();
                    lstHorarios.Visible = false;
                    lblMensaje.Font.Bold = true;
                    lblMensaje.Text = string.Format("Sin atención al publico: {0}", 
                        objDiaNoLaboral.MOTIVO);
                }
                else
                {
                    lblMensaje.Text = string.Empty;
                    lstHorarios.Visible = true;
                    DAL.Carnets.AGENDA_ESPECIAL objAgendaEspecial = 
                        DAL.Carnets.AGENDA_ESPECIAL.getByFecha(fecha);
                    int i = 0;
                    if (objAgendaEspecial == null)
                    {
                        CultureInfo ci = new CultureInfo("Es-Es");
                        string dia = ci.DateTimeFormat.GetDayName(fecha.DayOfWeek);
                        DAL.Carnets.AGENDA_GENERAL objAgenda = 
                            BLL.Carnets.AGENDA_GENERAL.getByDia(dia.ToUpper(), 
                            Convert.ToInt32(Request.QueryString["serv"]));
                        if (objAgenda == null)
                        {
                            lblMensaje.Text = string.Format(
                                "Los días {0} no hay atención al publico", dia);
                            lstHorarios.DataSource = null;
                            lstHorarios.DataBind();
                            lstHorarios.Visible = false;
                            return;
                        }
                        List<DAL.Servicios.GrillaTurnos> lst = new List<DAL.Servicios.GrillaTurnos>();

                        TimeSpan hora = objAgenda.HORA_INICIO;
                        for (hora = objAgenda.HORA_INICIO; hora < objAgenda.HORA_CIERRE;
                            hora = hora.Add(new TimeSpan(0, objAgenda.INTERVALO, 0)))
                        {
                            i++;
                            List<DAL.Carnets.TURNOS> lstT = BLL.Carnets.TURNOS.getByFechaHora(
        Convert.ToDateTime(fecha.ToShortDateString()), hora, Convert.ToInt32(Request.QueryString["serv"]));
                            DAL.Servicios.GrillaTurnos obj = new DAL.Servicios.GrillaTurnos();
                            if (fecha.ToShortDateString() != fec.ToShortDateString())
                            {

                                if (lstT.Count() < objAgenda.TURNOS_SIMULTANEOS)
                                {
                                    obj.hora = hora.ToString();
                                    lst.Add(obj);
                                }
                            }
                            else
                            {
                                if (hora > new TimeSpan(fec.Hour, fec.Minute, 0))
                                {
                                    if (lstT.Count() < objAgenda.TURNOS_SIMULTANEOS)
                                    {
                                        obj.hora = hora.ToString();
                                        lst.Add(obj);
                                    }
                                }
                            }
                        }
                        lstHorarios.Visible = true;
                        lblMensaje.Text = string.Empty;
                        lstHorarios.DataTextField = "hora";
                        lstHorarios.DataSource = lst;
                        lstHorarios.DataBind();
                        hTurnosDisp.Value = lst.Count.ToString();
                    }
                    hCantTurnos.Value = i.ToString();
                }
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                msjOk.InnerText = ex.Message;
            }

        }
        //OK
        protected void lstHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblDia.Text = Calendar1.SelectedDate.ToLongDateString();
                lblHorario.Text = lstHorarios.SelectedItem.Text;
                lblFechaTurno.Text = Calendar1.SelectedDate.ToLongDateString();
                lblHoraTurno.Text = lstHorarios.SelectedItem.Text;
                modalTurno.Visible = true;
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                msjOk.InnerText = ex.Message;
            }

        }
        //OK
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DAL.Carnets.TURNOS obj = new DAL.Carnets.TURNOS();
                obj.nro_cta = Convert.ToInt32(hNroCta.Value);
                obj.estado = 0;
                obj.fecha = Convert.ToDateTime(Calendar1.SelectedDate.ToShortDateString());
                obj.fecha_solicitud = LaHerradura.Utils.Utils.getFechaActual();
                obj.id_servicio = Convert.ToInt32(Request.QueryString["serv"]);
                DateTime h = Convert.ToDateTime(lstHorarios.SelectedItem.Text);
                TimeSpan ho = new TimeSpan(h.Hour, h.Minute, 0);
                obj.hora = ho;
                obj.web = false;
                if (Request.QueryString["REPROGRAMAR"] == null)
                    BLL.Carnets.TURNOS.insert(obj, string.Empty);
                else
                {
                    int id = Convert.ToInt32(Request.QueryString["REPROGRAMAR"]);
                    int usu = Convert.ToInt32(Request.Cookies["UserVecino"]["Id"]);
                    //using (TransactionScope scope = new TransactionScope())
                    //{
                        DAL.Carnets.TURNOS.updateEstado(id, DAL.Carnets.TURNOS.est.cancelado, usu);
                        DAL.Carnets.TURNOS objT = DAL.Carnets.TURNOS.getByPk(id);
                        StringBuilder texto = new StringBuilder();
                        texto.AppendFormat(
                            "<div><p>Su turno del <strong>{0} a las {1}</strong> ha sido <strong>REPROGRAMADO</strong></p>",
                            objT.fecha.ToShortDateString(), objT.hora);
                    texto.AppendLine("<p><br><strong>Nuevo Turno</strong></p></div>");
                        BLL.Carnets.TURNOS.insert(obj, texto.ToString());
                        //scope.Complete();
                    //}

                }
                Response.Redirect("BackCarnets.aspx");
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                msjOk.InnerText = ex.Message;
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            try
            {
                CalendarDay dia = e.Day;
                if (Convert.ToDateTime(dia.Date.ToShortDateString()) < Convert.ToDateTime(LaHerradura.Utils.Utils.getFechaActual().ToShortDateString()))
                    e.Cell.BackColor = System.Drawing.Color.LightGray;
                else
                {
                    CultureInfo ci = new CultureInfo("Es-Es");
                    string dia_ = ci.DateTimeFormat.GetDayName(dia.Date.DayOfWeek);

                    DAL.Carnets.AGENDA_GENERAL objAgenda = 
                        BLL.Carnets.AGENDA_GENERAL.getByDia(dia_.ToUpper(), 
                        Convert.ToInt32(Request.QueryString["serv"]));
                    List<DAL.Servicios.GrillaTurnos> lst = new List<DAL.Servicios.GrillaTurnos>();
                    if (objAgenda == null)
                        return;
                    TimeSpan hora = objAgenda.HORA_INICIO;
                    int i = 0;
                    for (hora = objAgenda.HORA_INICIO; hora < objAgenda.HORA_CIERRE;
        hora = hora.Add(new TimeSpan(0, objAgenda.INTERVALO, 0)))
                    {
                        i++;
                    }
                    decimal turnosDia = i * objAgenda.TURNOS_SIMULTANEOS;
                    List<DAL.Carnets.TURNOS> lstT = BLL.Carnets.TURNOS.getByFecha(dia.Date, 
                        Convert.ToInt32(Request.QueryString["serv"]));
                    decimal turnosDisp = turnosDia - lstT.Count;

                    if (turnosDisp == 0)
                        e.Cell.BackColor = System.Drawing.Color.FromName("#dd4b39");
                    else
                    {
                        decimal porcentajeDisponibilidad = 0;


                        porcentajeDisponibilidad = turnosDisp * 100 / turnosDia;
                        if (porcentajeDisponibilidad > 70)
                            e.Cell.BackColor = System.Drawing.Color.FromName("#00a65a");
                        else
                            e.Cell.BackColor = System.Drawing.Color.FromName("#f39c12");
                    }
                }
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                msjOk.InnerText = ex.Message;
            }

        }


        protected void btnVolver_ServerClick(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("BackCarnets.aspx");
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                msjOk.InnerText = ex.Message;
            }

        }
    }
}