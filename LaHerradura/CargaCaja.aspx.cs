using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura
{
    public partial class CargaCaja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(Request.Cookies["UserLh"]["Id"]);
                List<DAL.PAGOS_X_FACTURA> lst = DAL.PAGOS_X_FACTURA.read();
                foreach (var item in lst)
                {
                    DAL.TB_MOVIM_CAJA objMovim = new DAL.TB_MOVIM_CAJA();
                    objMovim.DETALLE = string.Format(
                        "Pago expensa cuenta nro.: {0}", item.NRO_CTA);
                    objMovim.HORA = item.FECHA;
                    objMovim.ID_CAJA = 1;
                    switch (item.ID_PLAN_PAGO)
                    {
                        case 1:
                            objMovim.ID_CTA_INGRESO = 1;
                            objMovim.ID_CTA_EGRESO = 1;
                            break;
                        case 2:
                            objMovim.ID_CTA_INGRESO = 3;
                            objMovim.ID_CTA_EGRESO = 3;
                            break;
                        default:
                            objMovim.ID_CTA_INGRESO = 2;
                            objMovim.ID_CTA_EGRESO = 2;
                            break;
                    }

                    objMovim.ID_RESPONSABLE = id;
                    objMovim.ID_USUARIO = id;
                    objMovim.MONTO = item.MONTO;
                    objMovim.ID_FACTURA = item.ID;
                    objMovim.TIPO_MOV = 1;
                    objMovim.ID_SUCURSAL = 1;
                    DAL.TB_MOVIM_CAJA.insert(objMovim);
                }

                List<DAL.PAGOS_X_FACTURA_GASTOS> lstGasto =
                    DAL.PAGOS_X_FACTURA_GASTOS.read();
                foreach (var item in lstGasto)
                {
                    DAL.TB_MOVIM_CAJA objMovim = new DAL.TB_MOVIM_CAJA();
                    objMovim.DETALLE = string.Format(
                        "Pago expensa cuenta nro.: {0}", item.NRO_CHEQUE);
                    objMovim.HORA = item.FECHA;
                    objMovim.ID_CAJA = 1;
                    switch (item.ID_PLAN_PAGO)
                    {
                        case 1:
                            objMovim.ID_CTA_INGRESO = 1;
                            objMovim.ID_CTA_EGRESO = 1;
                            break;
                        case 2:
                            objMovim.ID_CTA_INGRESO = 3;
                            objMovim.ID_CTA_EGRESO = 3;
                            break;
                        default:
                            objMovim.ID_CTA_INGRESO = 2;
                            objMovim.ID_CTA_EGRESO = 2;
                            break;
                    }


                    objMovim.ID_RESPONSABLE = id;
                    objMovim.ID_USUARIO = id;
                    objMovim.MONTO = item.MONTO;
                    objMovim.ID_FACTURA = item.ID;
                    objMovim.TIPO_MOV = 2;
                    objMovim.ID_SUCURSAL = 1;
                    DAL.TB_MOVIM_CAJA.insert(objMovim);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}