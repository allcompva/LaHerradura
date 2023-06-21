﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class Facturacion_Intereses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divError.Visible = false;
                if (!IsPostBack)
                {
                    fillGrilla();
                }
                DAL.USUARIOS obj =
    DAL.USUARIOS.getByPk(Convert.ToInt32(Request.Cookies["UserLh"]["Id"]));
                if (obj.ROL == 3)
                {
                    Response.Redirect("Home.aspx");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void fillGrilla()
        {
            try
            {
                if (DDLAnio.SelectedItem.Value == "2020")
                {
                    if (int.Parse(DDLMes.SelectedItem.Value) > 3)
                    {
                        List<DAL.FACTURACION_INTERESES> lst =
            DAL.FACTURACION_INTERESES.read(
                int.Parse(DDLMes.SelectedItem.Value),
                int.Parse(DDLAnio.SelectedItem.Value));
                        gvCtas.DataSource = lst;
                        gvCtas.DataBind();
                        if (lst.Count > 0)
                        {
                            gvCtas.UseAccessibleHeader = true;
                            gvCtas.HeaderRow.TableSection = TableRowSection.TableHeader;
                        }
                        lblCantCta.InnerHtml = lst.Count.ToString();
                        lblDeuda.InnerHtml = string.Format("{0:c}", lst.Sum(l => l.MONTO));
                    }
                    else
                    {
                        divError.Visible = true;
                        lblMsjError.InnerHtml =
                            "El periodo seleccionado es anterior a la facturación del sistema";
                        gvCtas.DataSource = null;
                        gvCtas.DataBind();
                        lblCantCta.InnerHtml = 0.ToString();
                        lblDeuda.InnerHtml = 0.ToString();
                    }
                }
                else
                {
                    List<DAL.FACTURACION_INTERESES> lst =
DAL.FACTURACION_INTERESES.read(
int.Parse(DDLMes.SelectedItem.Value),
int.Parse(DDLAnio.SelectedItem.Value));
                    gvCtas.DataSource = lst;
                    gvCtas.DataBind();
                    if (lst.Count > 0)
                    {
                        gvCtas.UseAccessibleHeader = true;
                        gvCtas.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    lblCantCta.InnerHtml = lst.Count.ToString();
                    lblDeuda.InnerHtml = string.Format("{0:c}", lst.Sum(l => l.MONTO));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void DDLAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrilla();
        }

        protected void DDLMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillGrilla();
        }

        protected void gvCtas_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void btnEmitirNC_Click(object sender, EventArgs e)
        {
            try
            {
                if (hIdCta.Value != string.Empty)
                    NotaDebitoPropietario(int.Parse(hIdCta.Value), int.Parse(hNroRecibo.Value),
                        decimal.Parse(hMonto.Value));
                else
                {
                    List<DAL.FACTURACION_INTERESES> lst =
    DAL.FACTURACION_INTERESES.read(
        int.Parse(DDLMes.SelectedItem.Value),
        int.Parse(DDLAnio.SelectedItem.Value));
                    foreach (var item in lst)
                    {
                        NotaDebitoPropietario(item.NRO_CTA, item.NRO_RECIBO, item.MONTO);
                    }
                }
                Response.Redirect("Facturacion_Intereses.aspx");
                //List<DAL.CTACTE_EXPENSAS> lst = new List<DAL.CTACTE_EXPENSAS>();
                //if (hIdCta.Value == string.Empty)
                //{
                //    int periodo = Convert.ToInt32(
                //    string.Format("{0}{1}{2}",
                //    DDLAnio.SelectedItem.Value,
                //    DDLMes.SelectedItem.Value, "00"));
                //    lst = DAL.CTACTE_EXPENSAS.Read_NC_aEmitir(periodo);
                //}
                //else
                //{
                //    DAL.CTACTE_EXPENSAS obj = DAL.CTACTE_EXPENSAS.getByPk(int.Parse(hIdCta.Value));
                //    lst.Add(obj);
                //}
                ////
                //DateTime fec = Convert.ToDateTime(txtFecha.Text);
                //string fecha = string.Format("{0}{1}{2}", fec.Year,
                //fec.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                //fec.Day.ToString().PadLeft(2, Convert.ToChar("0")));

                //NOTAS_CREDITO.EmitoNotasCredito(lst,
                //    Server.MapPath("certificado.pfx"), fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvCtas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void NotaDebitoPropietario(int nroCta, int nroRecibo, decimal importe)
        {
            try
            {
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();

                int PtoVta = int.Parse(System.Configuration.ConfigurationManager.AppSettings["PtoVta"].ToString());
                //int nroCta = Convert.ToInt32(DDLCuentas.SelectedItem.Value);
                DAL.PERSONAS_X_INMUEBLES objPxI = DAL.PERSONAS_X_INMUEBLES.getByNroCta(nroCta);
                DAL.FACTURAS_X_EXPENSA obj = new DAL.FACTURAS_X_EXPENSA();
                obj.PTO_VTA = PtoVta;
                obj.CUIT = objPxI.CUIT;
                obj.DETALLE = string.Format("Facturacion intereses recibo Nro.: {0}",
                    nroRecibo);

                obj.MONTO = importe;
                //obj.NOMBRE = txtNombre.Text;
                obj.NRO_CTA = nroCta;
                obj.PAGADO = true;
                obj.TIPO_COMPROBANTE = 12;

                obj.PERIODO = int.Parse(string.Format("{0}{1}20",
                    DDLAnio.SelectedItem.Value,
                    DDLMes.SelectedItem.Value.ToString().PadLeft(
                        2, Convert.ToChar("0"))));

                while (DAL.CTACTE_EXPENSAS.getByPeriodo(obj.PERIODO,
                    obj.NRO_CTA))
                    obj.PERIODO = obj.PERIODO + 1;

                //using (System.Transactions.TransactionScope scope =
                //    new System.Transactions.TransactionScope())
                //{
                int idCta = BLL.CTACTE_EXPENSAS.facturaND(obj,
                         Convert.ToInt32(Request.Cookies["UserLh"]["Id"]), 12, nroRecibo);
                obj.ID_CTACTE = idCta;
                FEProd.FECAEResponse cae = null;

                DateTime fecDesde = Convert.ToDateTime(string.Format("{0}-{1}-01",
                        DDLAnio.SelectedItem.Value,
                        DDLMes.SelectedItem.Value.ToString().PadLeft(
                        2, Convert.ToChar("0"))));
                DateTime fecHasta = Convert.ToDateTime(string.Format("{0}-{1}-28",
                        DDLAnio.SelectedItem.Value,
                        DDLMes.SelectedItem.Value.ToString().PadLeft(
                        2, Convert.ToChar("0"))));
                DateTime fecVenc = Convert.ToDateTime(string.Format("{0}-{1}-{2}",
                        fec.Year,
                        fec.Month.ToString().PadLeft(
                        2, Convert.ToChar("0")),
                        fec.Day.ToString().PadLeft(
                        2, Convert.ToChar("0"))));

                cae = AFIPHomo.FE_AFIP.AutorizaCAE_C(PtoVta, 2,
                    obj.MONTO, 12, Server.MapPath("certificado.pfx"),
                    Convert.ToDateTime(txtFecha.Text), fecDesde, fecHasta, fecVenc,
                    long.Parse(objPxI.CUIT));


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
                        factu.ID_COMPROBANTE = nroRecibo;
                        factu.DETALLE = obj.DETALLE;
                        DAL.CTACTE_EXPENSAS.setAFIP(objCta);
                        DAL.FACTURAS_X_EXPENSA.insert(factu);
                        //scope.Complete();
                    }
                }

                //}
            }
            catch (Exception ex)
            {

            }
        }
    }
}