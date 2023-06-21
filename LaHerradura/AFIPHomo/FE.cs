
using LaHerradura.FEProd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaHerradura.Utils;

namespace LaHerradura.AFIPHomo
{
    public class FE_AFIP
    {
        private static Service fe = new Service();

        public static DummyResponse dummy()
        {
            return fe.FEDummy();
        }
        public static CbteTipoResponse GetTipoComprobante(string path)
        {
            return fe.FEParamGetTiposCbte(LoginAfip.ObtenerLoginTicketResponse(path));
        }
        public static OpcionalTipoResponse GetTipoOpcionales(string path)
        {
            return fe.FEParamGetTiposOpcional(LoginAfip.ObtenerLoginTicketResponse(path));
        }
        public static FETributoResponse GetTtipoTribbuto(string path)
        {
            return fe.FEParamGetTiposTributos(LoginAfip.ObtenerLoginTicketResponse(path));
        }
        public static FEPtoVentaResponse GetPtoVta(string path)
        {
            return fe.FEParamGetPtosVenta(LoginAfip.ObtenerLoginTicketResponse(path));
        }
        public static ConceptoTipoResponse GetTipoConceptos(string path)
        {
            return fe.FEParamGetTiposConcepto(LoginAfip.ObtenerLoginTicketResponse(path));
        }
        public static DocTipoResponse GetTiposDoc(string path)
        {
            return fe.FEParamGetTiposDoc(LoginAfip.ObtenerLoginTicketResponse(path));
        }
        public static IvaTipoResponse GetTiposIva(string path)
        {
            return fe.FEParamGetTiposIva(LoginAfip.ObtenerLoginTicketResponse(path));
        }
        public static int GetNroComprobante(int ptoVta, int cbteTipo, string path)
        {
            FEAuthRequest aut = LoginAfip.ObtenerLoginTicketResponse(path);
            FERecuperaLastCbteResponse ultimo = fe.FECompUltimoAutorizado(aut, ptoVta, cbteTipo);
            return ultimo.CbteNro;
        }
        public static FECompConsultaResponse ConsultaComprobante(int CbteTipo, int PtoVta, int NroComp,
            string path)
        {
            FECompConsultaReq comp = new FECompConsultaReq();
            comp.CbteNro = NroComp;
            comp.CbteTipo = CbteTipo;
            comp.PtoVta = PtoVta;

            return fe.FECompConsultar(LoginAfip.ObtenerLoginTicketResponse(path), comp);
        }
        public static FECAEResponse AutorizaCAE_C(int PtoVta, int Concepto,
            List<DAL.CTACTE_EXPENSAS> lst, int tipoComp, string path,
            DateTime fecha)
        {
            try
            {
                FECAERequest req = new FECAERequest();
                FECAECabRequest cab = new FECAECabRequest();

                cab.CantReg = lst.Count;
                cab.CbteTipo = tipoComp;
                cab.PtoVta = PtoVta;

                req.FeCabReq = cab;

                int primerComprobante = GetNroComprobante(PtoVta, tipoComp, path);

                DAL.FACTURAS_X_EXPENSA objControl = DAL.FACTURAS_X_EXPENSA.getByPk(PtoVta,
                    primerComprobante, tipoComp);
                if (primerComprobante != 0)
                {
                    if (objControl == null)
                    {
                        throw new System.ArgumentException("Se ha detectado una inconsistencia en la Facturacion de AFIP. Por favor comuniquese con soporte del sistema para seguir facturando", "Nro comprobante inconsistente");

                    }
                }

                /*Concepto del Comprobante. Valores permitidos: 1 Productos 2 Servicios 3 Productos y Servicios*/
                req.FeDetReq = new FECAEDetRequest[lst.Count];
                for (int i = 0; i < lst.Count; i++)
                {
                    primerComprobante++;
                    FECAEDetRequest det = new FECAEDetRequest();

                    double tot = Convert.ToDouble(lst[i].MONTO_ORIGINAL);

                    det.Concepto = Concepto;

                    if (lst[i].MONTO_ORIGINAL >= 10000)
                    {
                        det.DocTipo = 1;
                        det.DocNro = Convert.ToInt64(lst[i].NRO_CUIT);
                    }
                    else
                    {
                        det.DocTipo = 99;
                        det.DocNro = 0;
                    }
                    //Comprador objComp = new Comprador();
                    //objComp.DocNro = nroDoc;
                    //objComp.DocTipo = 99;
                    //objComp.Porcentaje = 100;
                    //det.Compradores = new Comprador[1];
                    //det.Compradores[0] = objComp;

                    det.CbteDesde = primerComprobante;
                    det.CbteHasta = det.CbteDesde;
                    det.CbteFch = string.Format("{0}{1}{2}", fecha.Year,
                        fecha.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                        fecha.Day.ToString().PadLeft(2, Convert.ToChar("0")));

                    //det.FchServDesde = string.Format("{0}{1}{2}", fecha.Year,
                    //    fecha.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                    //    fecha.Day.ToString().PadLeft(2, Convert.ToChar("0")));

                    //det.FchServDesde = "20220501";
                    //det.FchServHasta = "20220531";
                    //det.FchVtoPago = "20220527";
                    //
                    det.FchServDesde = string.Format("{0}{1}{2}", fecha.Year,
                       fecha.Month.ToString().PadLeft(2, Convert.ToChar("0")), "01");

                    det.FchServHasta = string.Format("{0}{1}{2}", fecha.Year,
                       fecha.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                       Utils.Utils.UltimoDiadelMes(fecha).ToString().PadLeft(2, Convert.ToChar("0")));

                    det.FchVtoPago = string.Format("{0}{1}{2}", fecha.Year,
                       fecha.Month.ToString().PadLeft(2, Convert.ToChar("0")), "27");

                    det.ImpTotal = tot;
                    det.ImpNeto = tot;
                    det.ImpTotConc = 0;
                    det.ImpOpEx = 0;
                    det.MonId = "PES";
                    det.MonCotiz = 1;
                    Service fe = new Service();
                    req.FeDetReq[i] = det;

                }

                return fe.FECAESolicitar(LoginAfip.ObtenerLoginTicketResponse(path), req);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static FECAEResponse AutorizaCAE_C(int PtoVta, int Concepto,
            decimal monto, int tipoComp, string path, DateTime fecha,
            DateTime fechaDesde, DateTime fechaHasta, DateTime fechaVencPago,
            Int64 cuit)
        {
            try
            {
                FECAERequest req = new FECAERequest();
                FECAECabRequest cab = new FECAECabRequest();

                cab.CantReg = 1;
                cab.CbteTipo = tipoComp;
                cab.PtoVta = PtoVta;

                req.FeCabReq = cab;

                int primerComprobante =
                    GetNroComprobante(PtoVta, tipoComp, path);

                DAL.FACTURAS_X_EXPENSA objControl =
                    DAL.FACTURAS_X_EXPENSA.getByPk(PtoVta,
                    primerComprobante, tipoComp);
                if (primerComprobante != 0)
                {
                    if (objControl == null)
                    {
                        throw new System.ArgumentException(
                            "Se ha detectado una inconsistencia en la Facturacion AFIP. Por favor comuniquese con soporte del sistema para seguir facturando", "Nro comprobante inconsistente");

                    }
                }

                /*Concepto del Comprobante. Valores permitidos: 1 Productos 2 Servicios 3 Productos y Servicios*/
                req.FeDetReq = new FECAEDetRequest[1];

                primerComprobante++;
                FECAEDetRequest det = new FECAEDetRequest();

                double tot = Convert.ToDouble(monto);

                det.Concepto = Concepto;

                if (monto >= 10000)
                {
                    det.DocTipo = 1;
                    det.DocNro = Convert.ToInt64(cuit);
                }
                else
                {
                    det.DocTipo = 99;
                    det.DocNro = 0;
                }
                //Comprador objComp = new Comprador();
                //objComp.DocNro = nroDoc;
                //objComp.DocTipo = 99;
                //objComp.Porcentaje = 100;
                //det.Compradores = new Comprador[1];
                //det.Compradores[0] = objComp;

                det.CbteDesde = primerComprobante;
                det.CbteHasta = det.CbteDesde;
                det.CbteFch = string.Format("{0}{1}{2}", fecha.Year,
                    fecha.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                    fecha.Day.ToString().PadLeft(2, Convert.ToChar("0")));

                det.FchServDesde = string.Format("{0}{1}{2}", fechaDesde.Year,
                    fechaDesde.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                    fechaDesde.Day.ToString().PadLeft(2, Convert.ToChar("0")));

                det.FchServHasta = string.Format("{0}{1}{2}", fechaHasta.Year,
                    fechaHasta.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                    fechaHasta.Day.ToString().PadLeft(2, Convert.ToChar("0")));

                det.FchVtoPago = string.Format("{0}{1}{2}", fechaVencPago.Year,
                    fechaVencPago.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                    fechaVencPago.Day.ToString().PadLeft(2, Convert.ToChar("0")));

                det.ImpTotal = tot;
                det.ImpNeto = tot;
                det.ImpTotConc = 0;
                det.ImpOpEx = 0;
                det.MonId = "PES";
                det.MonCotiz = 1;

                Service fe = new Service();
                req.FeDetReq[0] = det;



                return fe.FECAESolicitar(LoginAfip.ObtenerLoginTicketResponse(path), req);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static FECAEResponse AutorizaCAE_C(int PtoVta, int Concepto,
            decimal monto, int tipoComp, string path, DateTime fecha,
            Int64 cuit)
        {
            try
            {
                FECAERequest req = new FECAERequest();
                FECAECabRequest cab = new FECAECabRequest();

                cab.CantReg = 1;
                cab.CbteTipo = tipoComp;
                cab.PtoVta = PtoVta;

                req.FeCabReq = cab;

                int primerComprobante =
                    GetNroComprobante(PtoVta, tipoComp, path);

                DAL.FACTURAS_X_EXPENSA objControl =
                    DAL.FACTURAS_X_EXPENSA.getByPk(PtoVta,
                    primerComprobante, tipoComp);
                if (primerComprobante != 0)
                {
                    if (objControl == null)
                    {
                        throw new System.ArgumentException(
                            "Se ha detectado una inconsistencia en la Facturacion AFIP. Por favor comuniquese con soporte del sistema para seguir facturando", "Nro comprobante inconsistente");

                    }
                }

                /*Concepto del Comprobante. Valores permitidos: 1 Productos 2 Servicios 3 Productos y Servicios*/
                req.FeDetReq = new FECAEDetRequest[1];

                primerComprobante++;
                FECAEDetRequest det = new FECAEDetRequest();

                double tot = Convert.ToDouble(monto);

                det.Concepto = Concepto;

                if (monto >= 10000)
                {
                    det.DocTipo = 1;
                    det.DocNro = Convert.ToInt64(cuit);
                }
                else
                {
                    det.DocTipo = 99;
                    det.DocNro = 0;
                }
                //Comprador objComp = new Comprador();
                //objComp.DocNro = nroDoc;
                //objComp.DocTipo = 99;
                //objComp.Porcentaje = 100;
                //det.Compradores = new Comprador[1];
                //det.Compradores[0] = objComp;

                det.CbteDesde = primerComprobante;
                det.CbteHasta = det.CbteDesde;
                det.CbteFch = string.Format("{0}{1}{2}", fecha.Year,
                    fecha.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                    fecha.Day.ToString().PadLeft(2, Convert.ToChar("0")));

                det.ImpTotal = tot;
                det.ImpNeto = tot;
                det.ImpTotConc = 0;
                det.ImpOpEx = 0;
                det.MonId = "PES";
                det.MonCotiz = 1;

                Service fe = new Service();
                req.FeDetReq[0] = det;



                return fe.FECAESolicitar(LoginAfip.ObtenerLoginTicketResponse(path), req);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static FECAEResponse AutorizaCAENotaCredito_C(int PtoVta, int Concepto,
            int DocTipo, Int64 NroCuit, double impTotal, int tipoComp,
            string path, CbteAsoc cbteAsoc, string fecha)
        {
            FECAERequest req = new FECAERequest();
            FECAECabRequest cab = new FECAECabRequest();
            FECAEDetRequest det = new FECAEDetRequest();

            //---------------------------------------------------------------------------------------------------------------------
            cab.CantReg = 1;
            cab.CbteTipo = tipoComp;
            cab.PtoVta = 2;
            req.FeCabReq = cab;
            //---------------------------------------------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------------------------------------------
            /*Concepto del Comprobante. Valores permitidos: 1 Productos 2 Servicios 3 Productos y Servicios*/
            det.Concepto = Concepto;


            if (impTotal >= 10000)
            {
                det.DocTipo = 1;
                det.DocNro = NroCuit;
            }
            else
            {
                det.DocTipo = 99;
                det.DocNro = 0;
            }

            int primerComprobante = GetNroComprobante(2, tipoComp, path);

            DAL.FACTURAS_X_EXPENSA objControl = DAL.FACTURAS_X_EXPENSA.getByPk(2,
                primerComprobante, tipoComp);
            if (primerComprobante != 0)
            {
                if (objControl == null)
                {
                    throw new System.ArgumentException("Se ha detectado una inconsistencia en la Facturacion AFIP. Por favor comuniquese con soporte del sistema para seguir facturando", "Nro comprobante inconsistente");

                }
            }
            det.CbteDesde = primerComprobante + 1;

            det.CbteHasta = det.CbteDesde;
            det.CbteFch = fecha;
            det.FchServDesde = fecha;

            det.FchServHasta = fecha;

            det.FchVtoPago = fecha;
            det.ImpTotal = impTotal;
            det.ImpNeto = impTotal;

            det.ImpTotConc = 0;


            det.ImpOpEx = 0;

            det.MonId = "PES";
            det.MonCotiz = 1;

            //det.Iva = lstIva;

            if (cbteAsoc != null)
            {
                det.CbtesAsoc = new CbteAsoc[1];
                det.CbtesAsoc[0] = cbteAsoc;
            }
            req.FeDetReq = new FECAEDetRequest[1];

            Service fe = new Service();

            req.FeDetReq[0] = det;
            return fe.FECAESolicitar(LoginAfip.ObtenerLoginTicketResponse(path), req);

        }

        public static FECAEResponse NotaCredito_A_B(int PtoVta, int Concepto,
            int DocTipo, Int64 DocNro, double impTotal, AlicIva[] lstIva, double impNeto, int tipoComp,
            CbteAsoc factAnular, string path)
        {
            FECAERequest req = new FECAERequest();
            FECAECabRequest cab = new FECAECabRequest();
            FECAEDetRequest det = new FECAEDetRequest();

            //---------------------------------------------------------------------------------------------------------------------
            cab.CantReg = 1;
            cab.CbteTipo = tipoComp;
            cab.PtoVta = PtoVta;

            req.FeCabReq = cab;
            //---------------------------------------------------------------------------------------------------------------------

            //---------------------------------------------------------------------------------------------------------------------
            /*Concepto del Comprobante. Valores permitidos: 1 Productos 2 Servicios 3 Productos y Servicios*/
            det.Concepto = Concepto;
            det.DocTipo = DocTipo;
            det.DocNro = DocNro;

            int primerComprobante = GetNroComprobante(PtoVta, tipoComp, path);

            DAL.FACTURAS_X_EXPENSA objControl = DAL.FACTURAS_X_EXPENSA.getByPk(PtoVta,
                primerComprobante, tipoComp);
            if (objControl == null)
            {
                throw new System.ArgumentException("Se ha detectado una inconsistencia en la Facturacion de AFIP. Por favor comuniquese con soporte del sistema para seguir facturando", "Nro comprobante inconsistente");

            }

            DateTime fec = Utils.Utils.getFechaActual();

            det.CbteDesde = primerComprobante + 1;
            det.CbteHasta = det.CbteDesde;
            det.CbteFch = string.Format("{0}{1}{2}", fec.Year,
                fec.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                fec.Day.ToString().PadLeft(2, Convert.ToChar("0")));

            det.ImpTotal = impTotal;
            det.ImpNeto = impNeto;

            det.ImpTotConc = 0;


            det.ImpOpEx = 0;

            det.MonId = "PES";
            det.MonCotiz = 1;

            det.Iva = lstIva;
            foreach (var item in lstIva)
            {
                det.ImpIVA += item.Importe;
            }
            det.Iva = lstIva;

            req.FeDetReq = new FECAEDetRequest[1];

            Service fe = new Service();
            CbteAsoc cbteAsoc = new CbteAsoc();

            req.FeDetReq[0] = det;

            FECAEResponse respuesta = fe.FECAESolicitar(LoginAfip.ObtenerLoginTicketResponse(path), req);
            return respuesta;

        }
    }
}