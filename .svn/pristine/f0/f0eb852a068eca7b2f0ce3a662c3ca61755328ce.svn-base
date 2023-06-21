using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class apertura_caja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divError.Visible = false;
                lblMsj.InnerHtml = string.Empty;
                DAL.PLANILLA_CAJA objPlanilla = DAL.PLANILLA_CAJA.getByEstado(0);
                if (objPlanilla == null)
                {
                    if (!IsPostBack)
                    {
                        int id = Convert.ToInt32(Request.Cookies["UserLh"]["Id"]);
                        DAL.USUARIOS obj = DAL.USUARIOS.getByPk(id);

                        DateTime fec = LaHerradura.Utils.Utils.getFechaActual();

                        txtFechaHora.Text = string.Format("{0} - {1}",
                            fec.ToShortDateString(),
                            fec.ToShortTimeString());
                        txtUsuario.Text = obj.USUARIO;
                        hIdUsuario.Value = obj.ID.ToString();
                    }
                }
                else
                {
                    divError.Visible = true;
                    lblMsj.InnerHtml = string.Format("No puede abrirse una nueva caja porque ya esta abierta la caja del {0}",
                        objPlanilla.FECHA.ToShortDateString());
                    divCaja.Visible = false;
                }
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                lblMsj.InnerHtml = ex.Message;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                DAL.PLANILLA_CAJA objAnt = DAL.PLANILLA_CAJA.getMax();
                DAL.PLANILLA_CAJA obj = new DAL.PLANILLA_CAJA();
                obj.EGRESOS_BANCO = 0;
                obj.EGRESOS_CHEQUES = 0;
                obj.EGRESOS_EFVO = 0;
                obj.ESTADO = 0;
                obj.FECHA = fec;
                obj.FECHA_APERTURA = fec;
                obj.ID_CAJA = 1;
                obj.INGRESOS_BANCO = 0;
                obj.INGRESOS_CHEQUES = 0;
                obj.INGRESOS_EFVO = 0;
                obj.OBS_ABRE = txtObs.Text;
                obj.OBS_CIERRE = string.Empty;
                if (objAnt != null)
                {
                    obj.SALDO_ANTERIOR_BANCO = objAnt.SALDO_BANCO;
                    obj.SALDO_ANTERIOR_CHEQUES = objAnt.SALDO_CHEQUES;
                    obj.SALDO_ANTERIOR_EFVO = objAnt.SALDO_EFVO;
                    obj.ID = objAnt.ID + 1;
                }
                else
                {
                    obj.SALDO_ANTERIOR_BANCO = 0;
                    obj.SALDO_ANTERIOR_CHEQUES = 0;
                    obj.SALDO_ANTERIOR_EFVO = 0;
                    obj.ID = 1;
                }
                obj.SALDO_BANCO = obj.SALDO_ANTERIOR_BANCO;
                obj.SALDO_CHEQUES = obj.SALDO_ANTERIOR_CHEQUES;
                obj.SALDO_EFVO = obj.SALDO_ANTERIOR_EFVO;
                obj.USUARIO_ABRE = int.Parse(hIdUsuario.Value);
                DAL.PLANILLA_CAJA.insert(obj);
                Response.Redirect("Home.aspx");
            }
            catch (Exception ex)
            {
                divError.Visible = true;
                lblMsj.InnerHtml = ex.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                divError.Visible = true;
                lblMsj.InnerHtml = ex.Message;
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}