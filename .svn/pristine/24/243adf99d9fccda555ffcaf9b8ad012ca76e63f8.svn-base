using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace LaHerradura.Back
{
    public partial class Facturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    List<DAL.CUENTA_COMBO> lst = DAL.CUENTA_COMBO.read();
                    DDLCuentas.DataTextField = "MOSTRAR";
                    DDLCuentas.DataValueField = "NRO_CTA";
                    DDLCuentas.DataSource = lst;
                    DDLCuentas.DataBind();
                    fillDatosPersona(lst[0].NRO_CTA);

                    if (!IsPostBack)
                    {
                        List<DAL.FACTURAS_X_EXPENSA> lstF = 
                            DAL.FACTURAS_X_EXPENSA.readNoPropietario();
                        gvFacturas.DataSource = lstF;
                        gvFacturas.DataBind();
                        if (lst.Count > 0)
                        {
                            gvFacturas.UseAccessibleHeader = true;
                            gvFacturas.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                    }

                    DDLHaber.DataTextField = "DESC_SUBCUENTA";
                    DDLHaber.DataValueField = "ID";
                    DDLHaber.DataSource = DAL.PLAN_CUENTA.read();
                    DDLHaber.DataBind();
                    DDLDebe.DataTextField = "DESC_SUBCUENTA";
                    DDLDebe.DataValueField = "ID";
                    DDLDebe.DataSource = DAL.PLAN_CUENTA.read();
                    DDLDebe.DataBind();
                }
                DAL.USUARIOS obj =
    DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                if (obj.ROL == 3)
                {
                    btnAddFactura.Visible = false;                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLConceptos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDLConceptos.SelectedIndex == 0)
                {
                    divServicio.Visible = false;
                }
                else
                {
                    divServicio.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void DDLVincular_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDLVincular.SelectedIndex == 0)
                {
                    divCtas.Visible = true;
                    fillDatosPersona(int.Parse(DDLCuentas.SelectedItem.Value));
                }
                else
                {
                    divCtas.Visible = false;
                    txtNombre.Text = string.Empty;
                    txtNroDoc.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSig1_Click(object sender, EventArgs e)
        {
            try
            {
                if (DDLVincular.SelectedIndex == 0)
                {
                    switch (DDLTipoComp.SelectedItem.Value)
                    {
                        case "11":
                            facturar_a_propietario();
                            break;
                        case "12":
                            NotaDebitoPropietario();
                            break;
                        case "13":
                            nota_credito_a_propietario();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (DDLTipoComp.SelectedItem.Value)
                    {
                        case "11":
                            facturar_a_no_propietario();
                            break;
                        case "12":
                            break;
                        default:
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void nota_credito_a_propietario()
        {
            try
            {
                List<DAL.CTACTE_EXPENSAS> lst = new
                    List<DAL.CTACTE_EXPENSAS>();

                DAL.CTACTE_EXPENSAS obj = new DAL.CTACTE_EXPENSAS();
                obj.NRO_CTA = int.Parse(DDLCuentas.SelectedItem.Value);
                lst.Add(obj);



                DateTime fec = Convert.ToDateTime(txtFecha.Text);
                string fecha = string.Format("{0}{1}{2}", fec.Year,
                fec.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                fec.Day.ToString().PadLeft(2, Convert.ToChar("0")));

                NOTAS_CREDITO.EmitoNotasCredito(lst,
                    Server.MapPath("certificado.pfx"), fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void facturar_a_propietario()
        {
            try
            {
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();

                int PtoVta = int.Parse(System.Configuration.ConfigurationManager.AppSettings["PtoVta"].ToString());
                int nroCta = Convert.ToInt32(DDLCuentas.SelectedItem.Value);

                DAL.FACTURAS_X_EXPENSA obj = new DAL.FACTURAS_X_EXPENSA();
                obj.PTO_VTA = PtoVta;
                obj.CUIT = txtNroDoc.Text;
                obj.DETALLE = txtDescripcion.Text;
                obj.ID_CTA_DEBE = Convert.ToInt32(
                    DDLDebe.SelectedItem.Value);
                obj.ID_CTA_HABER = Convert.ToInt32(
                    DDLHaber.SelectedItem.Value);
                decimal importe = 0;
                if (txtTotal.Text.Contains(".")) // si tiene un punto la caja de texto, usa configuracion regional
                {
                    importe = Convert.ToDecimal(txtTotal.Text,
                        System.Globalization.CultureInfo.InvariantCulture);

                }
                else // aca quiere decir que puso una coma y lo reemplaza por un punto
                {

                    string coma = txtTotal.Text;
                    coma.Replace(',', '.');
                    importe = Convert.ToDecimal(coma);
                }

                obj.MONTO = importe;
                obj.NOMBRE = txtNombre.Text;
                obj.NRO_CTA = nroCta;
                obj.PAGADO = false;
                obj.TIPO_COMPROBANTE = 11;

                obj.PERIODO = int.Parse(string.Format("{0}{1}10",
                    fec.Year,
                    fec.Month.ToString().PadLeft(
                        2, Convert.ToChar("0"))));

                while (DAL.CTACTE_EXPENSAS.getByPeriodo(obj.PERIODO,
                    obj.NRO_CTA))
                    obj.PERIODO = obj.PERIODO + 1;

                //using (System.Transactions.TransactionScope scope =
                //    new System.Transactions.TransactionScope())
                //{
                int idCta = BLL.CTACTE_EXPENSAS.factura(obj,
                         Convert.ToInt32(Request.Cookies["UserLh"]["Id"]), 100);
                obj.ID_CTACTE = idCta;
                FEProd.FECAEResponse cae = null;
                if (int.Parse(DDLTipoComp.SelectedItem.Value) > 1)
                {
                    cae = AFIPHomo.FE_AFIP.AutorizaCAE_C(PtoVta,
                        Convert.ToInt32(DDLConceptos.SelectedItem.Value),
                        obj.MONTO, 11, Server.MapPath("certificado.pfx"),
                        fec, Convert.ToDateTime(
                            txtServiciosDesde.Text),
                        Convert.ToDateTime(txtServiciosHasta.Text),
                        Convert.ToDateTime(txtServiciosVenc.Text),
                        Convert.ToInt64(txtNroDoc.Text));
                }
                else
                {
                    cae = AFIPHomo.FE_AFIP.AutorizaCAE_C(PtoVta,
                        Convert.ToInt32(DDLTipoComp.SelectedItem.Value),
                        obj.MONTO, 11, Server.MapPath("certificado.pfx"),
                        fec, Convert.ToInt64(txtNroDoc.Text));
                }


                if (cae != null)
                {
                    if (cae.FeDetResp[0].Resultado == "A")
                    {
                        DAL.CTACTE_EXPENSAS objCta = new DAL.CTACTE_EXPENSAS();

                        objCta.ID = idCta;
                        objCta.NRO_CTA = nroCta;
                        objCta.CAE = Convert.ToInt64(cae.FeDetResp[0].CAE);
                        //objCta.CAE = 11111111111111;
                        obj.CAE = objCta.CAE;
                        objCta.NRO_CTE = cae.FeDetResp[0].CbteDesde;
                        //objCta.NRO_CTE = obj.PERIODO;
                        obj.NRO_CTE = objCta.NRO_CTE;
                        objCta.PTO_VTA = PtoVta;
                        int anio = Convert.ToInt32(cae.FeDetResp[0].CbteFch.Substring(0, 4));
                        int mes = Convert.ToInt32(cae.FeDetResp[0].CbteFch.Substring(4, 2));
                        int dia = Convert.ToInt32(cae.FeDetResp[0].CbteFch.Substring(6, 2));
                        objCta.FECHA_CAE = new DateTime(anio, mes, dia);
                        //objCta.FECHA_CAE = fec;
                        obj.FECHA_CAE = objCta.FECHA_CAE;
                        anio = Convert.ToInt32(cae.FeDetResp[0].CAEFchVto.Substring(0, 4));
                        mes = Convert.ToInt32(cae.FeDetResp[0].CAEFchVto.Substring(4, 2));
                        dia = Convert.ToInt32(cae.FeDetResp[0].CAEFchVto.Substring(6, 2));
                        objCta.VENC_CAE = new DateTime(anio, mes, dia);
                        //objCta.VENC_CAE = fec;
                        obj.VENC_CAE = objCta.VENC_CAE;
                        DAL.FACTURAS_X_EXPENSA factu = new
                            DAL.FACTURAS_X_EXPENSA();
                        factu.CUIT = obj.CUIT;
                        factu.NOMBRE = obj.NOMBRE;
                        factu.CAE = obj.CAE;
                        factu.FECHA_CAE = obj.FECHA_CAE;
                        factu.ID_CTACTE = idCta;
                        factu.NRO_CTA = obj.NRO_CTA;
                        factu.NRO_CTE = obj.NRO_CTE;
                        factu.PERIODO = obj.PERIODO;
                        factu.PTO_VTA = obj.PTO_VTA;
                        factu.VENC_CAE = obj.VENC_CAE;
                        factu.TIPO_COMPROBANTE = 11;
                        factu.MONTO = obj.MONTO;

                        factu.DETALLE = obj.DETALLE;
                        DAL.CTACTE_EXPENSAS.setAFIP(objCta);
                        DAL.FACTURAS_X_EXPENSA.insert(factu);
                        //scope.Complete();
                        Response.Redirect(string.Format(
                            "inmueble.aspx?nrocta={0}", objCta.NRO_CTA));
                    }
                    else
                    {
                        divError.Visible = true;
                        txtError.InnerText = string.Format("Resultado: {0} - Observaciones: {1}",
                            cae.FeDetResp[0].Resultado, cae.FeDetResp[0].Observaciones);
                    }
                }

                //}
            }
            catch (Exception ex)
            {

            }
        }
        private void NotaDebitoPropietario()
        {
            try
            {
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();
                int PtoVta = int.Parse(System.Configuration.ConfigurationManager.AppSettings["PtoVta"].ToString());
                int nroCta = Convert.ToInt32(DDLCuentas.SelectedItem.Value);

                DAL.FACTURAS_X_EXPENSA obj = new DAL.FACTURAS_X_EXPENSA();
                obj.PTO_VTA = PtoVta;
                obj.CUIT = txtNroDoc.Text;
                obj.DETALLE = txtDescripcion.Text;

                decimal importe = 0;
                if (txtTotal.Text.Contains(".")) // si tiene un punto la caja de texto, usa configuracion regional
                {
                    importe = Convert.ToDecimal(txtTotal.Text,
                        System.Globalization.CultureInfo.InvariantCulture);

                }
                else // aca quiere decir que puso una coma y lo reemplaza por un punto
                {

                    string coma = txtTotal.Text;
                    coma.Replace(',', '.');
                    importe = Convert.ToDecimal(coma);
                }

                obj.MONTO = importe;
                obj.NOMBRE = txtNombre.Text;
                obj.NRO_CTA = nroCta;
                obj.PAGADO = false;
                obj.TIPO_COMPROBANTE = 12;

                obj.PERIODO = int.Parse(string.Format("{0}{1}20",
                    fec.Year,
                    fec.Month.ToString().PadLeft(
                        2, Convert.ToChar("0"))));

                while (DAL.CTACTE_EXPENSAS.getByPeriodo(obj.PERIODO,
                    obj.NRO_CTA))
                    obj.PERIODO = obj.PERIODO + 1;

                //using (System.Transactions.TransactionScope scope =
                //    new System.Transactions.TransactionScope())
                //{
                int idCta = BLL.CTACTE_EXPENSAS.factura(obj,
                         Convert.ToInt32(Request.Cookies["UserLh"]["Id"]), 12);
                obj.ID_CTACTE = idCta;
                FEProd.FECAEResponse cae = null;
                if (int.Parse(DDLTipoComp.SelectedItem.Value) > 1)
                {
                    cae = AFIPHomo.FE_AFIP.AutorizaCAE_C(PtoVta,
                        Convert.ToInt32(DDLConceptos.SelectedItem.Value),
                        obj.MONTO, 12, Server.MapPath("certificado.pfx"),
                        fec, Convert.ToDateTime(
                            txtServiciosDesde.Text),
                        Convert.ToDateTime(txtServiciosHasta.Text),
                        Convert.ToDateTime(txtServiciosVenc.Text),
                        Convert.ToInt64(txtNroDoc.Text));
                }
                else
                {
                    cae = AFIPHomo.FE_AFIP.AutorizaCAE_C(PtoVta,
                        Convert.ToInt32(DDLTipoComp.SelectedItem.Value),
                        obj.MONTO, 12, Server.MapPath("certificado.pfx"),
                        fec, Convert.ToInt64(txtNroDoc.Text));
                }


                if (cae != null)
                {
                    if (cae.FeDetResp[0].Resultado == "A")
                    {
                        DAL.CTACTE_EXPENSAS objCta = new DAL.CTACTE_EXPENSAS();

                        objCta.ID = idCta;
                        objCta.NRO_CTA = nroCta;
                        objCta.CAE = Convert.ToInt64(cae.FeDetResp[0].CAE);
                        //objCta.CAE = 11111111111111;
                        obj.CAE = objCta.CAE;
                        objCta.NRO_CTE = cae.FeDetResp[0].CbteDesde;
                        //objCta.NRO_CTE = obj.PERIODO;
                        obj.NRO_CTE = objCta.NRO_CTE;
                        objCta.PTO_VTA = PtoVta;
                        int anio = Convert.ToInt32(cae.FeDetResp[0].CbteFch.Substring(0, 4));
                        int mes = Convert.ToInt32(cae.FeDetResp[0].CbteFch.Substring(4, 2));
                        int dia = Convert.ToInt32(cae.FeDetResp[0].CbteFch.Substring(6, 2));
                        objCta.FECHA_CAE = new DateTime(anio, mes, dia);
                        //objCta.FECHA_CAE = fec;
                        obj.FECHA_CAE = objCta.FECHA_CAE;
                        anio = Convert.ToInt32(cae.FeDetResp[0].CAEFchVto.Substring(0, 4));
                        mes = Convert.ToInt32(cae.FeDetResp[0].CAEFchVto.Substring(4, 2));
                        dia = Convert.ToInt32(cae.FeDetResp[0].CAEFchVto.Substring(6, 2));
                        objCta.VENC_CAE = new DateTime(anio, mes, dia);
                        //objCta.VENC_CAE = fec;
                        obj.VENC_CAE = objCta.VENC_CAE;
                        DAL.FACTURAS_X_EXPENSA factu = new
                            DAL.FACTURAS_X_EXPENSA();
                        factu.CUIT = obj.CUIT;
                        factu.NOMBRE = obj.NOMBRE;
                        factu.CAE = obj.CAE;
                        factu.FECHA_CAE = obj.FECHA_CAE;
                        factu.ID_CTACTE = idCta;
                        factu.NRO_CTA = obj.NRO_CTA;
                        factu.NRO_CTE = obj.NRO_CTE;
                        factu.PERIODO = obj.PERIODO;
                        factu.PTO_VTA = obj.PTO_VTA;
                        factu.VENC_CAE = obj.VENC_CAE;
                        factu.TIPO_COMPROBANTE = 12;
                        factu.MONTO = obj.MONTO;

                        factu.DETALLE = obj.DETALLE;
                        DAL.CTACTE_EXPENSAS.setAFIP(objCta);
                        DAL.FACTURAS_X_EXPENSA.insert(factu);
                        //scope.Complete();
                        Response.Redirect(string.Format(
                            "inmueble.aspx?nrocta={0}", objCta.NRO_CTA));
                    }
                }

                //}
            }
            catch (Exception ex)
            {

            }
        }
        private void facturar_a_no_propietario()
        {
            try
            {
                int PtoVta = int.Parse(System.Configuration.ConfigurationManager.AppSettings["PtoVta"].ToString());
                int nroCta = Convert.ToInt32(DDLCuentas.SelectedItem.Value);

                DAL.FACTURAS_X_EXPENSA obj = new DAL.FACTURAS_X_EXPENSA();
                obj.PTO_VTA = PtoVta;
                obj.CUIT = txtNroDoc.Text;
                obj.DETALLE = txtDescripcion.Text;

                var culturaArgentina = CultureInfo.GetCultureInfo("es-AR");
                decimal importe = Convert.ToDecimal(
    txtTotal.Text.Replace(".", ","),
        culturaArgentina);

                obj.MONTO = importe;
                obj.NOMBRE = txtNombre.Text;
                obj.NRO_CTA = 0;
                obj.PAGADO = false;
                obj.TIPO_COMPROBANTE = 11;


                using (System.Transactions.TransactionScope scope =
                    new System.Transactions.TransactionScope())
                {
                    //int idCta = BLL.CTACTE_EXPENSAS.factura(obj,
                    //     Convert.ToInt32(Request.Cookies["UserLh"]["Id"]), 100);
                    obj.ID_CTACTE = 0;
                    FEProd.FECAEResponse cae = null;
                    if (int.Parse(DDLConceptos.SelectedItem.Value) > 1)
                    {
                        cae = AFIPHomo.FE_AFIP.AutorizaCAE_C(PtoVta,
                            Convert.ToInt32(DDLConceptos.SelectedItem.Value),
                            obj.MONTO, 11, Server.MapPath("certificado.pfx"),
                            LaHerradura.Utils.Utils.getFechaActual(), Convert.ToDateTime(
                                txtServiciosDesde.Text),
                            Convert.ToDateTime(txtServiciosHasta.Text),
                            Convert.ToDateTime(txtServiciosVenc.Text),
                            Convert.ToInt64(txtNroDoc.Text));
                    }
                    else
                    {
                        cae = AFIPHomo.FE_AFIP.AutorizaCAE_C(PtoVta,
                            Convert.ToInt32(DDLConceptos.SelectedItem.Value),
                            obj.MONTO, 11, Server.MapPath("certificado.pfx"),
                            Convert.ToDateTime(txtFecha.Text),
                            Convert.ToInt64(txtNroDoc.Text));
                    }


                    if (cae != null)
                    {
                        if (cae.FeDetResp[0].Resultado == "A")
                        {
                            DAL.FACTURAS_X_EXPENSA factu = new
                                DAL.FACTURAS_X_EXPENSA();
                            factu.CUIT = obj.CUIT;
                            factu.NOMBRE = obj.NOMBRE;
                            factu.CAE = Int64.Parse(cae.FeDetResp[0].CAE);

                            int anio = Convert.ToInt32(cae.FeDetResp[0].CbteFch.Substring(0, 4));
                            int mes = Convert.ToInt32(cae.FeDetResp[0].CbteFch.Substring(4, 2));
                            int dia = Convert.ToInt32(cae.FeDetResp[0].CbteFch.Substring(6, 2));

                            factu.FECHA_CAE = new DateTime(anio, mes, dia);
                            factu.ID_CTACTE = 0;
                            factu.NRO_CTA = 0;
                            factu.NRO_CTE = cae.FeDetResp[0].CbteDesde;
                            factu.PERIODO = obj.PERIODO;
                            factu.PTO_VTA = obj.PTO_VTA;
                            factu.VENC_CAE = new DateTime(anio, mes, dia);
                            factu.TIPO_COMPROBANTE = 11;
                            factu.MONTO = obj.MONTO;

                            factu.DETALLE = obj.DETALLE;

                            DAL.FACTURAS_X_EXPENSA.insert(factu);
                            scope.Complete();
                            Response.Redirect("Facturacion.aspx");
                        }
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
        protected void DDLCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillDatosPersona(int.Parse(DDLCuentas.SelectedItem.Value));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void fillDatosPersona(int nroCta)
        {
            try
            {
                DAL.CUENTA_COMBO obj = DAL.CUENTA_COMBO.getByNroCta(nroCta);
                txtNroDoc.Text = obj.CUIT;
                txtNombre.Text = obj.PROPIETARIO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvFacturas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.FACTURAS_X_EXPENSA obj = (DAL.FACTURAS_X_EXPENSA)e.Row.DataItem;
                    HtmlGenericControl lblFactura = (HtmlGenericControl)e.Row.FindControl("lblFactura");
                    lblFactura.InnerHtml = string.Format("{0}-{1}",
                        obj.PTO_VTA.ToString().PadLeft(2, Convert.ToChar("0")),
                        obj.NRO_CTE.ToString().PadLeft(10, Convert.ToChar("0")));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAddFactura_Click(object sender, EventArgs e)
        {
            try
            {
                divListaFactura.Visible = false;
                divAddFactura.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DDLTipoComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (DDLTipoComp.SelectedItem.Value)
                {
                    case "11":
                        divCompAsociado.Visible = false;
                        DDLConceptos.Enabled = true;
                        divPlanCuentas.Visible = true;
                        break;
                    case "12":
                        divCompAsociado.Visible = false;
                        DDLConceptos.Enabled = false;
                        divPlanCuentas.Visible = false;
                        break;
                    case "13":
                        divServicio.Visible = false;
                        divCompAsociado.Visible = true;
                        DDLConceptos.Enabled = false;
                        divPlanCuentas.Visible = false;
                        break;
                    default:
                        break;
                }
                DDLConceptos.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}