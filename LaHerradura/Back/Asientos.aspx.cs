using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace LaHerradura.Back
{
    public partial class Asientos : System.Web.UI.Page
    {
        DAL.ASIENTOS_GRILLA obj = null;
        DAL.ASIENTOS_GRILLA objAnt = null;
        int primero = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                divErrorAsiento.Visible = false;
                if (!IsPostBack)
                {
                    clear();
                    fillCombo();
                    fillAsientos(1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

                List<DAL.ASIENTOS_GRILLA> lst = new List<DAL.ASIENTOS_GRILLA>();

                switch (filtro)
                {
                    case 1:
                        fechaInicio = Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                            fec.Year, fec.Month, 1));
                        fechaFin = Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                            fec.Year, fec.Month,
                            DateTime.DaysInMonth(fec.Year, fec.Month)));
                        lst = DAL.ASIENTOS_GRILLA.read(fechaInicio, fechaFin);
                        break;
                    case 2:
                        fechaInicio = Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                            fec.Year, fec.Month, fec.Day));
                        fechaFin = Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                            fec.Year, fec.Month,
                            fec.Day));
                        lst = DAL.ASIENTOS_GRILLA.read(fechaInicio, fechaFin);
                        break;
                    case 3:
                        fechaInicio = Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                            fec.Year, 1, 1));
                        fechaFin = Convert.ToDateTime(string.Format("{0}/{1}/{2}",
                            fec.Year, 12, 31));
                        lst = DAL.ASIENTOS_GRILLA.read(fechaInicio, fechaFin);
                        break;
                    case 4:
                        fechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
                        fechaFin = Convert.ToDateTime(txtFechaFin.Text);
                        lst = DAL.ASIENTOS_GRILLA.read(fechaInicio, fechaFin);
                        break;
                    default:
                        break;
                }

                lst.Add(new DAL.ASIENTOS_GRILLA());
                hCantRegistros.Value = lst.Count().ToString();
                gvListaAsientos.DataSource = lst;
                gvListaAsientos.DataBind();
                if (lst.Count > 0)
                {
                    gvListaAsientos.UseAccessibleHeader = true;
                    gvListaAsientos.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        private void fillCombo()
        {
            try
            {
                List<DAL.PLAN_CUENTA> lst = DAL.PLAN_CUENTA.read();
                List<DAL.ASIENTOS_DETALLE> lstUsadas = leerGrilla();
                foreach (var item in lstUsadas)
                {
                    lst.RemoveAll(l => l.ID == item.ID_CUENTA);
                }

                DDLCuentas.DataTextField = "NOMBRE_COMBO";
                DDLCuentas.DataValueField = "ID";
                DDLCuentas.DataSource = lst;
                DDLCuentas.DataBind();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnAddAsiento_Click(object sender, EventArgs e)
        {
            try
            {
                divAddAsiento.Visible = true;
                divListado.Visible = false;
                clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void clear()
        {
            try
            {
                DateTime fec = LaHerradura.Utils.Utils.getFechaActual();

                txtFecha.Text = string.Format("{0}-{1}-{2}",
    fec.Year,
    fec.Month.ToString().PadLeft(2, Convert.ToChar("0")),
    fec.Day.ToString().PadLeft(2, Convert.ToChar("0")));

                txtHaber.Text = 0.ToString();
                txtDetalle.Text = string.Empty;
                txtTotalDebe.Text = string.Empty;
                txtTotalHaber.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnAddCuenta_Click(object sender, EventArgs e)
        {
            try
            {
                decimal importe = 0;
                if (txtHaber.Text.Contains(".")) // si tiene un punto la caja de texto, usa configuracion regional
                {
                    importe = Convert.ToDecimal(txtHaber.Text,
                        System.Globalization.CultureInfo.InvariantCulture);

                }
                else // aca quiere decir que puso una coma y lo reemplaza por un punto
                {

                    string coma = txtHaber.Text;
                    coma.Replace(',', '.');
                    importe = Convert.ToDecimal(coma);
                }
                if (importe <= 0)
                {
                    lblErrorAsiento.InnerHtml = "El monto debe ser superior a $0,00";
                    divErrorAsiento.Visible = true;
                    return;
                }
                List<DAL.ASIENTOS_DETALLE> lst = leerGrilla();
                DAL.ASIENTOS_DETALLE obj = new DAL.ASIENTOS_DETALLE();
                if (DDLDebeHaber.SelectedIndex == 0)
                    obj.DEBE = importe;
                else
                    obj.HABER = importe;

                obj.ID_CUENTA = int.Parse(
                    DDLCuentas.SelectedItem.Value);
                obj.NOMBRE_CUENTA = DDLCuentas.SelectedItem.Text;
                lst.Add(obj);
                gvAddAsiento.DataSource = lst;
                gvAddAsiento.DataBind();
                fillCombo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<DAL.ASIENTOS_DETALLE> leerGrilla()
        {
            List<DAL.ASIENTOS_DETALLE> lst = new List<DAL.ASIENTOS_DETALLE>();
            for (int i = 0; i < gvAddAsiento.Rows.Count; i++)
            {
                GridViewRow row = gvAddAsiento.Rows[i];
                DAL.ASIENTOS_DETALLE obj = new DAL.ASIENTOS_DETALLE();
                obj.ID_CUENTA = int.Parse(
                    gvAddAsiento.DataKeys[i].Values["ID_CUENTA"].ToString());
                obj.DEBE =
                    Convert.ToDecimal(
                        gvAddAsiento.DataKeys[i].Values["DEBE"].ToString());
                obj.HABER = Convert.ToDecimal(
                    gvAddAsiento.DataKeys[i].Values["HABER"]);
                obj.NOMBRE_CUENTA =
    gvAddAsiento.DataKeys[i].Values["NOMBRE_CUENTA"].ToString();
                obj.DESCRIPCION =
gvAddAsiento.DataKeys[i].Values["DESCRIPCION"].ToString();

                lst.Add(obj);
            }
            //txtTot.Text = tot.ToString();
            return lst;
        }
        decimal totDebe = 0;
        decimal totHaber = 0;
        protected void gvAddAsiento_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DAL.ASIENTOS_DETALLE obj =
                        (DAL.ASIENTOS_DETALLE)e.Row.DataItem;
                    totDebe += obj.DEBE;
                    totHaber += obj.HABER;
                }
                txtTotalDebe.Text = string.Format("{0:c}", totDebe);
                txtTotalHaber.Text = string.Format("{0:c}", totHaber);
                if (totHaber > 0)
                    if (totHaber == totDebe)
                        btnAceptarAdd.Visible = true;
                    else
                        btnAceptarAdd.Visible = false;
                else
                    btnAceptarAdd.Visible = false;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelAdd_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptarAdd_Click(object sender, EventArgs e)
        {
            try
            {
                List<DAL.ASIENTOS_DETALLE> lst = leerGrilla();
                List<DAL.ASIENTOS_DETALLE> lstDebe = lst.FindAll(
                    l => l.DEBE > 0);
                List<DAL.ASIENTOS_DETALLE> lstHaber = lst.FindAll(
                    l => l.HABER > 0);

                if (lstDebe.Sum(l => l.DEBE) != lstHaber.Sum(l => l.HABER))
                {
                    divErrorAsiento.Visible = true;
                    lblErrorAsiento.InnerHtml = "La suma del Debe debe ser igual a la suma del Haber";
                    return;
                }
                if (txtDetalle.Text == string.Empty)
                {
                    divErrorAsiento.Visible = true;
                    lblErrorAsiento.InnerHtml = "Ingrese la descripción del asiento";
                    return;
                }
                if (txtFecha.Text == string.Empty)
                {
                    divErrorAsiento.Visible = true;
                    lblErrorAsiento.InnerHtml = "Ingrese la fecha del asiento";
                    return;
                }
                decimal debe = lstDebe.Sum(l => l.DEBE);
                decimal haber = lstDebe.Sum(l => l.HABER);
                if (debe <= 0)
                {
                    lblErrorAsiento.InnerHtml = "El monto debe ser superior a $0,00";
                    divErrorAsiento.Visible = true;
                    return;
                }
                using (TransactionScope scope = new TransactionScope())
                {
                    int mes = Convert.ToDateTime(
                        txtFecha.Text).Month;
                    int anio = Convert.ToDateTime(
                        txtFecha.Text).Year;
                    int nroAsiento = DAL.ASIENTOS.getMaxAsiento(
                        mes, anio);
                    DAL.ASIENTOS objAsiento = new DAL.ASIENTOS();
                    objAsiento.DESCRIPCION = txtDetalle.Text;
                    objAsiento.FECHA = Convert.ToDateTime(txtFecha.Text);
                    objAsiento.MONTO = debe;
                    objAsiento.USUARIO = 1;
                    objAsiento.NRO = nroAsiento + 1;
                    objAsiento.TIPO = 6;
                    int idAsiento = DAL.ASIENTOS.insert(objAsiento);

                    foreach (var item in lstDebe)
                    {
                        DAL.ASIENTOS_DETALLE objDebe = new DAL.ASIENTOS_DETALLE();
                        objDebe.DEBE = item.DEBE;
                        objDebe.ID_CUENTA = item.ID_CUENTA;
                        objDebe.ID_ASIENTO = idAsiento;
                        DAL.ASIENTOS_DETALLE.insert(objDebe);
                    }
                    foreach (var item2 in lstHaber)
                    {
                        DAL.ASIENTOS_DETALLE objHaber = new DAL.ASIENTOS_DETALLE();
                        objHaber.HABER = item2.HABER;
                        objHaber.ID_CUENTA = item2.ID_CUENTA;
                        objHaber.ID_ASIENTO = idAsiento;
                        DAL.ASIENTOS_DETALLE.insert(objHaber);
                    }
                    scope.Complete();
                }
                divAddAsiento.Visible = false;
                divListado.Visible = true;
                fillAsientos(1);
                clear();
                btnCancelAdd_Click(null, null);
                fillCombo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            fillAsientos(4);
        }

        protected void DDLPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDLPeriodo.SelectedItem.Value == "4")
                {
                    btnFiltro.Visible = true;
                    txtFechaInicio.Enabled = true;
                    txtFechaFin.Enabled = true;
                }
                else
                {
                    btnFiltro.Visible = false;
                    txtFechaInicio.Enabled = false;
                    txtFechaFin.Enabled = false;
                }
                fillAsientos(int.Parse(DDLPeriodo.SelectedItem.Value.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAsientoNotaCredito_Click(object sender, EventArgs e)
        {
            try
            {
                //ASIENTO NOTAS DE CREDITO
                List<DAL.FACTURAS_X_EXPENSA> lst =
                    DAL.FACTURAS_X_EXPENSA.readNotasCredito();
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (var item in lst)
                    {
                        int mes = item.FECHA_CAE.Month;
                        int anio = item.FECHA_CAE.Year;
                        int nroAsiento = DAL.ASIENTOS.getMaxAsiento(
                            mes, anio);
                        DAL.ASIENTOS objAsiento = new DAL.ASIENTOS();
                        objAsiento.DESCRIPCION = item.DETALLE;
                        objAsiento.FECHA = item.FECHA_CAE;
                        objAsiento.MONTO = item.MONTO;
                        objAsiento.USUARIO = 1;
                        objAsiento.NRO = nroAsiento + 1;
                        objAsiento.TIPO = 2;
                        objAsiento.REFERENCIA = item.ID_CTACTE.ToString();
                        int idAsiento = DAL.ASIENTOS.insert(objAsiento);

                        DAL.ASIENTOS_DETALLE objDebe = new DAL.ASIENTOS_DETALLE();
                        objDebe.DEBE = item.MONTO;
                        objDebe.ID_CUENTA = 119;
                        objDebe.ID_ASIENTO = idAsiento;
                        objDebe.ID_REFERENCIA = item.ID_CTACTE.ToString();
                        DAL.ASIENTOS_DETALLE.insert(objDebe);

                        List<DAL.DETALLE_DEUDA> lstDet = DAL.DETALLE_DEUDA.readAsiento(item.PERIODO,
                            item.NRO_CTA);

                        DAL.ASIENTOS_DETALLE objHaber = new DAL.ASIENTOS_DETALLE();
                        objHaber.HABER = item.MONTO;
                        objHaber.ID_CUENTA = 12;
                        objHaber.ID_ASIENTO = idAsiento;
                        objHaber.ID_REFERENCIA = item.ID_CTACTE.ToString();
                        DAL.ASIENTOS_DETALLE.insert(objHaber);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAsientoProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                //ASIENTO LIQUIDACION EXPENSAS
                List<DAL.ASIENTO_PROV> lst = DAL.ASIENTO_PROV.read();
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (var item in lst)
                    {
                        int mes = Convert.ToDateTime(
                            txtFecha.Text).Month;
                        int anio = Convert.ToDateTime(
                            txtFecha.Text).Year;
                        int nroAsiento = DAL.ASIENTOS.getMaxAsiento(
                            mes, anio);
                        DAL.ASIENTOS objAsiento = new DAL.ASIENTOS();

                        objAsiento.DESCRIPCION = string.Format(
                            "{0} - {1} - Factura N°: {2}-{3}",
                            item.PROVEEDOR,
                            item.OBS,
                            item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                            item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));

                        objAsiento.FECHA = item.FECHA;
                        objAsiento.MONTO = item.MONTO_ORIGINAL;
                        objAsiento.USUARIO = 1;
                        objAsiento.NRO = nroAsiento + 1;
                        objAsiento.TIPO = 3;
                        objAsiento.EJERCICIO = item.FECHA.Year;
                        objAsiento.REFERENCIA = item.ID.ToString();

                        int idAsiento = DAL.ASIENTOS.insert(objAsiento);
                        DAL.ASIENTOS_DETALLE objDebe = new DAL.ASIENTOS_DETALLE();
                        objDebe.HABER = item.MONTO_ORIGINAL;
                        objDebe.ID_CUENTA = item.CUENTA_PASIVO;
                        objDebe.ID_ASIENTO = idAsiento;
                        objDebe.ID_REFERENCIA = item.ID.ToString();
                        DAL.ASIENTOS_DETALLE.insert(objDebe);


                        DAL.ASIENTOS_DETALLE objHaber = new DAL.ASIENTOS_DETALLE();
                        objHaber.DEBE = item.MONTO_ORIGINAL;
                        objHaber.ID_CUENTA = item.CUENTA_GASTO;
                        objHaber.ID_ASIENTO = idAsiento;
                        objHaber.ID_REFERENCIA = item.ID.ToString();
                        DAL.ASIENTOS_DETALLE.insert(objHaber);

                    }
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAsientoPagoProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                //ASIENTO PAGO PROVEEDORES
                List<int> lst = DAL.CTACTE_GASTOS.readRecibos();


                foreach (var item in lst)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        List<DAL.ASIENTO_PAGO_PROV_DEBE> lstDebe =
                            DAL.ASIENTO_PAGO_PROV_DEBE.read(item);
                        if (lstDebe.Count != 0)
                        {
                            int mes = Convert.ToDateTime(
                            txtFecha.Text).Month;
                            int anio = Convert.ToDateTime(
                                txtFecha.Text).Year;
                            int nroAsiento = DAL.ASIENTOS.getMaxAsiento(
                                mes, anio);
                            DAL.ASIENTOS objAsiento = new DAL.ASIENTOS();
                            objAsiento.DESCRIPCION = string.Format(
                                "Pago {0} - Recibo Nro {1}",
                                lstDebe[0].RAZON_SOCIAL,
                                item);

                            objAsiento.FECHA = lstDebe[0].FECHA;
                            objAsiento.MONTO = lstDebe.Sum(l => l.HABER);
                            objAsiento.USUARIO = 1;
                            objAsiento.NRO = nroAsiento + 1;
                            objAsiento.TIPO = 4;
                            objAsiento.REFERENCIA = item.ToString();
                            objAsiento.EJERCICIO = 2020;
                            int idAsiento = DAL.ASIENTOS.insert(objAsiento);

                            foreach (var itemDebe in lstDebe)
                            {
                                DAL.ASIENTOS_DETALLE objDebe = new DAL.ASIENTOS_DETALLE();
                                objDebe.DEBE = itemDebe.HABER;
                                objDebe.ID_CUENTA = itemDebe.CUENTA_GASTO;
                                objDebe.DESCRIPCION = string.Format(
                                    "Factura N°: {0}-{1}",
                                    itemDebe.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                    itemDebe.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                                objDebe.ID_ASIENTO = idAsiento;
                                objDebe.ID_REFERENCIA = itemDebe.ID.ToString();
                                DAL.ASIENTOS_DETALLE.insert(objDebe);
                            }


                            List<DAL.ASIENTO_PAGO_PROV_HABER> lstHaber =
                                DAL.ASIENTO_PAGO_PROV_HABER.read(item);

                            foreach (var itemHaber in lstHaber)
                            {
                                DAL.ASIENTOS_DETALLE objHaber = new DAL.ASIENTOS_DETALLE();
                                objHaber.HABER = itemHaber.MONTO;
                                objHaber.ID_CUENTA = itemHaber.ID_PLAN_CUENTA;
                                if (itemHaber.ID_PLAN_PAGO != 2)
                                    objHaber.DESCRIPCION = itemHaber.DESCRIPCION;
                                else
                                    objHaber.DESCRIPCION = string.Format(
                                        "Cheque N°: {0} - Banco {1}",
                                        itemHaber.NRO_CHEQUE, itemHaber.DENOMINACION);
                                objHaber.ID_ASIENTO = idAsiento;
                                objHaber.ID_REFERENCIA = itemHaber.ID.ToString();
                                DAL.ASIENTOS_DETALLE.insert(objHaber);
                            }
                            if (lstDebe.Sum(ld => ld.HABER) != lstHaber.Sum(lh => lh.MONTO))
                            {
                                DAL.ASIENTOS_DETALLE objHaber = new DAL.ASIENTOS_DETALLE();
                                objHaber.HABER = lstHaber.Sum(lh => lh.MONTO) - lstDebe.Sum(ld => ld.HABER);
                                objHaber.ID_CUENTA = 296;
                                objHaber.ID_ASIENTO = idAsiento;
                                objHaber.ID_REFERENCIA = 0.ToString();
                                objHaber.DESCRIPCION = "ANTICIPO PROVEEDORES";
                                DAL.ASIENTOS_DETALLE.insert(objHaber);
                            }
                        }
                        scope.Complete();
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAsientoPagoExpensas_Click(object sender, EventArgs e)
        {
            try
            {
                //ASIENTO PAGO EXPENSAS
                List<int> lst = DAL.CTACTE_EXPENSAS.readRecibos();

                foreach (var item in lst)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {//if (item == 234)
                        //{

                        //}
                        List<DAL.ASIENTO_PAGO_EXPENSAS_DEBE> lstDebe =
                             DAL.ASIENTO_PAGO_EXPENSAS_DEBE.read(item);

                        int mes = lstDebe[0].FECHA.Month;
                        int anio = lstDebe[0].FECHA.Year;
                        int nroAsiento = DAL.ASIENTOS.getMaxAsiento(
                            mes, anio);
                        DAL.ASIENTOS objAsiento = new DAL.ASIENTOS();
                        objAsiento.DESCRIPCION = string.Format(
                            "Cobro Cuenta N°: {0} - Recibo Nro {1}",
                            lstDebe[0].NRO_CTA,
                            item);

                        objAsiento.FECHA = lstDebe[0].FECHA;
                        objAsiento.MONTO = lstDebe.Sum(l => l.MONTO);
                        objAsiento.USUARIO = 1;
                        objAsiento.NRO = nroAsiento + 1;
                        objAsiento.TIPO = 5;
                        objAsiento.REFERENCIA = item.ToString();
                        objAsiento.EJERCICIO = 2020;
                        int idAsiento = DAL.ASIENTOS.insert(objAsiento);

                        foreach (var itemDebe in lstDebe)
                        {
                            DAL.ASIENTOS_DETALLE objDebe = new DAL.ASIENTOS_DETALLE();
                            objDebe.DEBE = itemDebe.MONTO;
                            objDebe.ID_CUENTA = itemDebe.ID_PLAN_CUENTA;
                            objDebe.DESCRIPCION = itemDebe.DESCRIPCION;
                            objDebe.ID_ASIENTO = idAsiento;
                            objDebe.ID_REFERENCIA = item.ToString();
                            DAL.ASIENTOS_DETALLE.insert(objDebe);
                        }


                        List<DAL.ASIENTO_PAGO_EXPENSAS_HABER> lstHaber =
                            DAL.ASIENTO_PAGO_EXPENSAS_HABER.read(item);


                        DAL.ASIENTOS_DETALLE objHaber = new DAL.ASIENTOS_DETALLE();
                        objHaber.HABER = lstHaber[0].CAPITAL;
                        objHaber.ID_CUENTA = 12;
                        objHaber.DESCRIPCION = string.Format("Pago Capital recibo N°: {0}",
                            item);
                        objHaber.ID_ASIENTO = idAsiento;
                        objHaber.ID_REFERENCIA = item.ToString();
                        DAL.ASIENTOS_DETALLE.insert(objHaber);

                        if (lstHaber[0].INTERES > 0)
                        {
                            DAL.ASIENTOS_DETALLE objHaber2 = new DAL.ASIENTOS_DETALLE();
                            objHaber2.HABER = lstHaber[0].INTERES;
                            objHaber2.ID_CUENTA = 128;
                            objHaber2.DESCRIPCION = string.Format("Pago Interes por mora recibo N°: {0}",
                                item);
                            objHaber2.ID_ASIENTO = idAsiento;
                            objHaber2.ID_REFERENCIA = item.ToString();
                            DAL.ASIENTOS_DETALLE.insert(objHaber2);
                        }
                        if (lstDebe.Sum(ld => ld.MONTO) > lstHaber.Sum(lh => lh.TOTAL))
                        {
                            DAL.ASIENTOS_DETALLE objHaber3 = new DAL.ASIENTOS_DETALLE();
                            objHaber3.HABER = lstDebe.Sum(ld => ld.MONTO) - lstHaber.Sum(lh => lh.TOTAL);
                            objHaber3.ID_CUENTA = 101;
                            objHaber3.ID_ASIENTO = idAsiento;
                            objHaber3.ID_REFERENCIA = 0.ToString();
                            objHaber3.DESCRIPCION = "A BILLETERA";
                            DAL.ASIENTOS_DETALLE.insert(objHaber3);
                        }
                        scope.Complete();
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvAddAsiento_DataBound(object sender, EventArgs e)
        {

        }

        protected void gvListaAsientos_DataBound(object sender, EventArgs e)
        {

        }

        protected void gvListaAsientos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int cantRegistros = int.Parse(hCantRegistros.Value);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                obj = (DAL.ASIENTOS_GRILLA)e.Row.DataItem;
                if (primero == 0)
                {
                    objAnt = (DAL.ASIENTOS_GRILLA)e.Row.DataItem;
                    LinkButton btnEliminar = (LinkButton)
                        e.Row.FindControl("btnEliminar");
                    if (obj.TIPO != 6)
                        btnEliminar.Visible = false;

                    primero++;
                }
                else
                {
                    primero++;
                    if (obj.NRO == objAnt.NRO)
                    {
                        e.Row.Cells[0].Text = string.Empty;
                        e.Row.Cells[1].Text = string.Empty;
                        LinkButton btnEliminar = (LinkButton)
                            e.Row.FindControl("btnEliminar");
                        btnEliminar.Visible = false;
                    }
                    else
                    {
                        LinkButton btnEliminar = (LinkButton)
                            e.Row.FindControl("btnEliminar");
                        if (obj.TIPO != 6)
                            btnEliminar.Visible = false;
                        HtmlGenericControl p = new HtmlGenericControl();
                        p.TagName = "p";
                        //if(gvListaAsientos.Rows[e.Row.RowIndex - 1].Cells[3].Text != "$0.00")
                        //    p.Style.Add("margin-left", "85px");
                        p.InnerHtml = string.Format(
                            "{0}<br><br><strong style=\"font-style: italic;\">{1}</strong>",
                            gvListaAsientos.Rows[e.Row.RowIndex - 1].Cells[2].Text,
                            objAnt.DESCRIPCION);
                        gvListaAsientos.Rows[e.Row.RowIndex - 1].Cells[2].Controls.Add(p);

                        HtmlGenericControl pDebe = new HtmlGenericControl();
                        pDebe.TagName = "p";
                        pDebe.InnerHtml = string.Format("{0:c}<br><br><strong>{1:c}</strong>",
                            gvListaAsientos.Rows[e.Row.RowIndex - 1].Cells[3].Text,
                            objAnt.TOTAL_DEBE);
                        gvListaAsientos.Rows[e.Row.RowIndex - 1].Cells[3].Controls.Add(pDebe);

                        HtmlGenericControl pHaber = new HtmlGenericControl();
                        pHaber.TagName = "p";
                        pHaber.InnerHtml = string.Format("{0:c}<br><br><strong>{1:c}</strong>",
                            gvListaAsientos.Rows[e.Row.RowIndex - 1].Cells[4].Text,
                            objAnt.TOTAL_HABER);

                        gvListaAsientos.Rows[e.Row.RowIndex - 1].Cells[4].Controls.Add(pHaber);

                        gvListaAsientos.Rows[e.Row.RowIndex - 1].Style.Add("border-bottom", "1px solid");
                        objAnt = obj;


                    }



                }
                if (cantRegistros == primero)
                {
                    e.Row.Visible = false;
                }
            }
        }

        protected void gvAddAsiento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "eliminar")
                {
                    List<DAL.ASIENTOS_DETALLE> lst = leerGrilla();
                    lst.RemoveAt(Convert.ToInt32(e.CommandArgument));
                    gvAddAsiento.DataSource = lst;
                    gvAddAsiento.DataBind();
                    if (lst.Count == 0)
                    {
                        txtTotalDebe.Text = 0.ToString();
                        txtTotalHaber.Text = 0.ToString();
                    }
                    fillCombo();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvListaAsientos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "eliminar")
                {
                    BLL.ASIENTOS.delete(
                        Convert.ToInt32(e.CommandArgument));
                    fillAsientos(1);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAsientoExpensas_Click(object sender, EventArgs e)
        {
            //gvAddAsiento.DataSource = null;
            //gvAddAsiento.DataBind();
            //clear();
            //divAddAsiento.Visible = false;
            //divListado.Visible = true;
            try
            {



                using (TransactionScope scope = new TransactionScope())
                {
                    int anio = 2022;
                    for (int mes = 1; mes < 13; mes++)
                    {
                        int i = DAL.ASIENTOS.getMaxAsiento(mes, anio);
                        int periodo = int.Parse(anio.ToString() + mes.ToString().PadLeft(2, Convert.ToChar("0")) + "00");
                        List<DAL.CTACTE_EXPENSAS> lst = DAL.CTACTE_EXPENSAS.read(periodo);
                        foreach (var item in lst)
                        {
                            DAL.ASIENTOS objAsiento = new DAL.ASIENTOS();
                            switch (mes)
                            {
                                case 1:
                                    objAsiento.DESCRIPCION = string.Format(
                                        "Expensas Ordinarias Enero " + anio + " Cuenta N°: {0} - Factura {1}-{2}",
                                        item.NRO_CTA,
                                        item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                        item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                                    break;
                                case 2:
                                    objAsiento.DESCRIPCION = string.Format(
                                        "Expensas Ordinarias Febrero " + anio + " Cuenta N°: {0} - Factura {1}-{2}",
                                        item.NRO_CTA,
                                        item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                        item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                                    break;
                                case 3:
                                    objAsiento.DESCRIPCION = string.Format(
                                        "Expensas Ordinarias Marzo " + anio + " Cuenta N°: {0} - Factura {1}-{2}",
                                        item.NRO_CTA,
                                        item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                        item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                                    break;
                                case 4:
                                    objAsiento.DESCRIPCION = string.Format(
                                        "Expensas Ordinarias Abril " + anio + " Cuenta N°: {0} - Factura {1}-{2}",
                                        item.NRO_CTA,
                                        item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                        item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                                    break;
                                case 5:
                                    objAsiento.DESCRIPCION = string.Format(
                                        "Expensas Ordinarias Mayo " + anio + " Cuenta N°: {0} - Factura {1}-{2}",
                                        item.NRO_CTA,
                                        item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                        item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                                    break;
                                case 6:
                                    objAsiento.DESCRIPCION = string.Format(
                                        "Expensas Ordinarias Junio " + anio + " Cuenta N°: {0} - Factura {1}-{2}",
                                        item.NRO_CTA,
                                        item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                        item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                                    break;
                                case 7:
                                    objAsiento.DESCRIPCION = string.Format(
                                        "Expensas Ordinarias Julio " + anio + " Cuenta N°: {0} - Factura {1}-{2}",
                                        item.NRO_CTA,
                                        item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                        item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                                    break;
                                case 8:
                                    objAsiento.DESCRIPCION = string.Format(
                                        "Expensas Ordinarias Agosto " + anio + " Cuenta N°: {0} - Factura {1}-{2}",
                                        item.NRO_CTA,
                                        item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                        item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                                    break;
                                case 9:
                                    objAsiento.DESCRIPCION = string.Format(
                                        "Expensas Ordinarias Septiembre " + anio + " Cuenta N°: {0} - Factura {1}-{2}",
                                        item.NRO_CTA,
                                        item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                        item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                                    break;
                                case 10:
                                    objAsiento.DESCRIPCION = string.Format(
                                        "Expensas Ordinarias Octubre " + anio + " Cuenta N°: {0} - Factura {1}-{2}",
                                        item.NRO_CTA,
                                        item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                        item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                                    break;
                                case 11:
                                    objAsiento.DESCRIPCION = string.Format(
                                        "Expensas Ordinarias Noviembre " + anio + " Cuenta N°: {0} - Factura {1}-{2}",
                                        item.NRO_CTA,
                                        item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                        item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                                    break;
                                case 12:
                                    objAsiento.DESCRIPCION = string.Format(
                                        "Expensas Ordinarias Diciembre " + anio + " Cuenta N°: {0} - Factura {1}-{2}",
                                        item.NRO_CTA,
                                        item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                                        item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                                    break;
                                default:
                                    break;
                            }


                            //objAsiento.DESCRIPCION = string.Format(
                            //    "Expensas Ordinarias Febrero 2020 Cuenta N°: {0} - Factura {1}-{2}",
                            //    item.NRO_CTA,
                            //    item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                            //    item.NRO_CTE.ToString().PadLeft(8, Convert.ToChar("0")));
                            //objAsiento.DESCRIPCION = string.Format(
                            //    "Expensas Ordinarias Marzo 2021 Cuenta N°: {0}",
                            //item.NRO_CTA);

                            //objAsiento.DESCRIPCION = item.DESCRIPCION;
                            objAsiento.FECHA = item.FECHA_CAE;
                            objAsiento.MONTO = item.MONTO_ORIGINAL;
                            objAsiento.USUARIO = 1;
                            objAsiento.NRO = i;
                            objAsiento.TIPO = 1;
                            objAsiento.REFERENCIA = item.ID.ToString();
                            objAsiento.EJERCICIO = anio;
                            i++;
                            int idAsiento = DAL.ASIENTOS.insert(objAsiento);
                            DAL.ASIENTOS_DETALLE objDebe = new DAL.ASIENTOS_DETALLE();
                            objDebe.DEBE = item.MONTO_ORIGINAL;
                            objDebe.ID_CUENTA = 12;
                            objDebe.ID_ASIENTO = idAsiento;
                            objDebe.ID_REFERENCIA = item.ID.ToString();
                            DAL.ASIENTOS_DETALLE.insert(objDebe);

                            List<DAL.DETALLE_DEUDA> lstDet = DAL.DETALLE_DEUDA.readAsiento(item.PERIODO,
                                item.NRO_CTA);

                            foreach (var item2 in lstDet)
                            {
                                DAL.ASIENTOS_DETALLE objHaber = new DAL.ASIENTOS_DETALLE();
                                objHaber.HABER = item2.SUBTOTAL;
                                objHaber.ID_CUENTA = item2.ID_PLAN_CUENTA;
                                objHaber.ID_ASIENTO = idAsiento;
                                objHaber.ID_REFERENCIA = item.ID.ToString();
                                DAL.ASIENTOS_DETALLE.insert(objHaber);
                            }

                        }

                    }
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}