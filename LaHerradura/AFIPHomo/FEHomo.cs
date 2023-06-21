using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaHerradura.FEHomo;

namespace LaHerradura.AFIPHomo
{
    public class FE_AFIP_HOMO
    {
        private static Service fe = new Service();

        public static DummyResponse dummy()
        {
            return fe.FEDummy();
        }
        public static CbteTipoResponse GetTipoComprobante(string path)
        {
            return fe.FEParamGetTiposCbte(LogiAfipHomo.ObtenerLoginTicketResponse(path));
        }
        public static OpcionalTipoResponse GetTipoOpcionales(string path)
        {
            return fe.FEParamGetTiposOpcional(LogiAfipHomo.ObtenerLoginTicketResponse(path));
        }
        public static FETributoResponse GetTtipoTribbuto(string path)
        {
            return fe.FEParamGetTiposTributos(LogiAfipHomo.ObtenerLoginTicketResponse(path));
        }
        public static FEPtoVentaResponse GetPtoVta(string path)
        {
            return fe.FEParamGetPtosVenta(LogiAfipHomo.ObtenerLoginTicketResponse(path));
        }
        public static ConceptoTipoResponse GetTipoConceptos(string path)
        {
            return fe.FEParamGetTiposConcepto(LogiAfipHomo.ObtenerLoginTicketResponse(path));
        }
        public static DocTipoResponse GetTiposDoc(string path)
        {
            return fe.FEParamGetTiposDoc(LogiAfipHomo.ObtenerLoginTicketResponse(path));
        }
        public static IvaTipoResponse GetTiposIva(string path)
        {
            return fe.FEParamGetTiposIva(LogiAfipHomo.ObtenerLoginTicketResponse(path));
        }
        public static int GetNroComprobante(int ptoVta, int cbteTipo, string path)
        {
            FEAuthRequest aut = LogiAfipHomo.ObtenerLoginTicketResponse(path);
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

            return fe.FECompConsultar(LogiAfipHomo.ObtenerLoginTicketResponse(path), comp);
        }
        public static LaHerradura.FEHomo.FECAEResponse AutorizaCAE_C(int PtoVta, int Concepto,
            List<DAL.CTACTE_EXPENSAS> lst, int tipoComp, string path)
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

                //DAL.FACTURAS_X_EXPENSA objControl = DAL.FACTURAS_X_EXPENSA.getByPk(PtoVta, 
                //    primerComprobante, tipoComp);
                //if (primerComprobante != 0)
                //{
                //    if (objControl == null)
                //    {
                //        throw new System.ArgumentException("Se ha detectado una inconsistencia en la facruacion AFIP. Por favor comuniquese con soporte del sistema para seguir facturando", "Nro comprobante inconsistente");

                //    }
                //}

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
                    det.CbteFch = string.Format("{0}{1}{2}", DateTime.Now.Year,
                        DateTime.Now.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                        DateTime.Now.Day.ToString().PadLeft(2, Convert.ToChar("0")));
                    det.ImpTotal = tot;
                    det.ImpNeto = tot;
                    det.ImpTotConc = 0;
                    det.ImpOpEx = 0;
                    det.MonId = "PES";
                    det.MonCotiz = 1;

                    Service fe = new Service();
                    req.FeDetReq[i] = det;

                }

                return fe.FECAESolicitar(LogiAfipHomo.ObtenerLoginTicketResponse(path), req);
                //return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static FECAEResponse AutorizaCAENotaDebito_C(int PtoVta, int Concepto,
            int DocTipo, Int64 NroCuit, double impTotal, int tipoComp, string path, CbteAsoc cbteAsoc)
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

            int primerComprobante = GetNroComprobante(PtoVta, tipoComp, path);

            DAL.FACTURAS_X_EXPENSA objControl = DAL.FACTURAS_X_EXPENSA.getByPk(PtoVta,
                primerComprobante, tipoComp);
            if (primerComprobante != 0)
            {
                if (objControl == null)
                {
                    throw new System.ArgumentException("Se ha detectado una inconsistencia en la facruacion AFIP. Por favor comuniquese con soporte del sistema para seguir facturando", "Nro comprobante inconsistente");

                }
            }
            det.CbteDesde = primerComprobante + 1;

            det.CbteHasta = det.CbteDesde;
            det.CbteFch = string.Format("{0}{1}{2}", DateTime.Now.Year,
                DateTime.Now.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                DateTime.Now.Day.ToString().PadLeft(2, Convert.ToChar("0")));

            det.ImpTotal = impTotal;
            det.ImpNeto = impTotal;

            det.ImpTotConc = 0;


            det.ImpOpEx = 0;

            det.MonId = "PES";
            det.MonCotiz = 1;

            //det.Iva = lstIva;

            det.CbtesAsoc = new CbteAsoc[1];
            det.CbtesAsoc[0] = cbteAsoc;

            req.FeDetReq = new FECAEDetRequest[1];

            Service fe = new Service();

            req.FeDetReq[0] = det;
            return fe.FECAESolicitar(LogiAfipHomo.ObtenerLoginTicketResponse(path), req);

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
                throw new System.ArgumentException("Se ha detectado una inconsistencia en la facruacion AFIP. Por favor comuniquese con soporte del sistema para seguir facturando", "Nro comprobante inconsistente");

            }

            det.CbteDesde = primerComprobante + 1;
            det.CbteHasta = det.CbteDesde;
            det.CbteFch = string.Format("{0}{1}{2}", DateTime.Now.Year,
                DateTime.Now.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                DateTime.Now.Day.ToString().PadLeft(2, Convert.ToChar("0")));

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

            FECAEResponse respuesta = fe.FECAESolicitar(LogiAfipHomo.ObtenerLoginTicketResponse(path), req);
            return respuesta;

        }
    }
}