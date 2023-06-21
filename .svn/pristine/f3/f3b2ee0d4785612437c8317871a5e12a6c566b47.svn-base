using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<DAL.CTACTE_EXPENSAS> lst =
                DAL.CTACTE_EXPENSAS.actualizaFacturas(20200300);

            foreach (var item in lst)
            {
                DAL.FACTURAS_X_EXPENSA factu = new DAL.FACTURAS_X_EXPENSA();
                factu.CAE = item.CAE;
                factu.FECHA_CAE = item.FECHA_CAE;
                factu.ID_CTACTE = item.ID;
                factu.NRO_CTA = item.NRO_CTA;
                factu.NRO_CTE = item.NRO_CTE;
                factu.PERIODO = item.PERIODO;
                factu.PTO_VTA = item.PTO_VTA;
                factu.VENC_CAE = item.VENC_CAE;
                factu.TIPO_COMPROBANTE = 11;
                factu.MONTO = item.MONTO_ORIGINAL;
                string me = string.Empty;
                switch (item.FECHA_CAE.Month)
                {
                    case 1:
                        me = "Enero";
                        break;
                    case 2:
                        me = "Febrero";
                        break;
                    case 3:
                        me = "Marzo";
                        break;
                    case 4:
                        me = "Abril";
                        break;
                    case 5:
                        me = "Mayo";
                        break;
                    case 6:
                        me = "Junio";
                        break;
                    case 7:
                        me = "Julio";
                        break;
                    case 8:
                        me = "Agosto";
                        break;
                    case 9:
                        me = "Septiembre";
                        break;
                    case 10:
                        me = "Octubre";
                        break;
                    case 11:
                        me = "Noviembre";
                        break;
                    case 12:
                        me = "Diciembre";
                        break;

                    default:
                        break;
                }
                factu.DETALLE = string.Format("Expensas ordinarias mes de {0} de {1}",
                    me, item.FECHA_CAE.Year);

                DAL.FACTURAS_X_EXPENSA.insert(factu);
            }
        }
    }
}