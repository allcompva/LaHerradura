using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class PLANES_PAGO
    {
        public static void insert(DAL.PLANES_PAGO obj, decimal montoCuota,
            List<int> lstCta, int idUsuario)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    int nroPlan = DAL.PLANES_PAGO.insert(obj);

                    foreach (var item in lstCta)
                    {
                        DAL.CTACTE_EXPENSAS.setPlanPago(item, nroPlan);
                    }
                    DateTime fecPeriodo = obj.FECHA_PRIMERA_CUOTA;
                    for (int i = 0; i < obj.CANT_CUOTAS; i++)
                    {
                        string anio = fecPeriodo.Year.ToString();
                        string mes =
                            fecPeriodo.Month.ToString().PadLeft(
                                2, Convert.ToChar("0"));
                        DAL.CTACTE_EXPENSAS objExpensa = new DAL.CTACTE_EXPENSAS();
                        objExpensa.DEBE = montoCuota;
                        objExpensa.DETALLE_DEUDA = string.Format(
                            "Plan de pagos Nro.: {0} - Cuota Nro.: {1}", 
                            nroPlan, i + 1);
                        objExpensa.MONTO_ORIGINAL = montoCuota;
                        objExpensa.NRO_CTA = obj.NRO_CTA;
                        objExpensa.NRO_CUOTA = i + 1;
                        objExpensa.NRO_PLAN_PAGO = nroPlan;
                        objExpensa.PERIODO = int.Parse(string.Format("{0}{1}00",
                            anio, mes));
                        objExpensa.VENCIMIENTO = fecPeriodo;
                        objExpensa.TIPO_MOVIMIENTO = 3;
                        objExpensa.SALDO = montoCuota;
                        int nroCte = DAL.CTACTE_EXPENSAS.getMaxNroCtePlan();
                        objExpensa.PTO_VTA = 10;
                        objExpensa.NRO_CTE = nroCte;
                        string codBarra = getCodigoBarra(objExpensa.NRO_CTA, 
                            objExpensa.PTO_VTA, objExpensa.NRO_CTE,
                            objExpensa.MONTO_ORIGINAL, 
                            objExpensa.VENCIMIENTO, objExpensa.MONTO_ORIGINAL,
                            0, objExpensa.MONTO_ORIGINAL, 0);

                        objExpensa.COD_BARRA_RAPIPAGO = codBarra;
                    
                        DAL.CTACTE_EXPENSAS.insertPlanPago(objExpensa);

                        //DETALLE DEUDA
                        DAL.DETALLE_DEUDA objDet = new DAL.DETALLE_DEUDA();
                        objDet.CANT = 1;
                        objDet.COSTO = montoCuota;
                        objDet.DEBE = montoCuota;
                        objDet.FECHA = UTILS.getFechaActual();
                        objDet.FECHA_CARGA = UTILS.getFechaActual();
                        objDet.HABER = 0;
                        objDet.ID_CONCEPTO = 18;
                        objDet.MASIVO = true;
                        objDet.NRO_CTA = obj.NRO_CTA;
                        objDet.NRO_ORDEN = 1;
                        objDet.OBS = string.Empty;
                        objDet.PERIODO = objExpensa.PERIODO;
                        objDet.SALDO = montoCuota;
                        objDet.SUBTOTAL = montoCuota;
                        objDet.USUARIO_CARGA = idUsuario;
                        objDet.MONTO_ORIGINAL = montoCuota;
                        objDet.NRO_PLAN_PAGO = objExpensa.NRO_PLAN_PAGO;
                        objDet.NRO_CUOTA = objExpensa.NRO_CUOTA;
                        DAL.DETALLE_DEUDA.insertPlan(objDet);
                        fecPeriodo = fecPeriodo.AddMonths(1);
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string getCodigoBarra(int nroCta, int ptoVta, 
            long nroComp, decimal importe, DateTime venc1,
    decimal impMora2venc, int diasMora2venc, decimal impMora3venc, int diasMora3venc)
        {
            try
            {
                string codBarra = string.Empty;
                codBarra = string.Format("048{0}{1}{2}{3}{4}{5}{6}{7}{8}",
                    nroCta.ToString().PadLeft(8, Convert.ToChar("0")),
                    ptoVta.ToString().PadLeft(3, Convert.ToChar("0")),
                    nroComp.ToString().PadLeft(8, Convert.ToChar("0")),
                    decimalToString(Math.Round(importe,2), 6, 2),
                    juliano(venc1.Month, venc1.Day, venc1.Year),
                    decimalToString(Math.Round(impMora2venc), 4, 2),
                    diasMora2venc.ToString().PadLeft(2, Convert.ToChar("0")),
                    decimalToString(Math.Round(impMora3venc), 4, 2),
                    diasMora3venc.ToString().PadLeft(2, Convert.ToChar("0")));
                int dv = Calcula_digito_verificador(codBarra);
                codBarra = string.Format("{0}{1}", codBarra, dv);
                return codBarra;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string decimalToString(decimal importe, int digitosEnteros, int digitosDecimales)
        {
            try
            {
                string _importe = string.Empty;
                string[] Importe = new string[2];
                if (importe.ToString().Contains("."))
                {
                    Importe = importe.ToString().Split(Convert.ToChar("."));
                    _importe = string.Format("{0}{1}",
                        Importe[0].ToString().PadLeft(digitosEnteros, Convert.ToChar("0")),
                        Importe[1].ToString().PadLeft(digitosDecimales, Convert.ToChar("0")));
                }
                if (importe.ToString().Contains(","))
                {
                    Importe = importe.ToString().Split(Convert.ToChar(","));
                    _importe = string.Format("{0}{1}",
                        Importe[0].ToString().PadLeft(digitosEnteros, Convert.ToChar("0")),
                        Importe[1].ToString().PadLeft(digitosDecimales, Convert.ToChar("0")));
                }
                return _importe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string juliano(int Month, int Day, int Year)
        {
            DateTime newDate = new DateTime(Year, Month, Day);
            DateTime oldDate = new DateTime(Year, 1, 1);

            // Difference in days, hours, and minutes.
            TimeSpan ts = newDate - oldDate;

            // Difference in days.
            int differenceInDays = ts.Days + 1;
            //=(YEAR(B1)-2000+100)*1000+B1-DATE(YEAR(B1),"01","01")+1
            string juliano = string.Empty;
            juliano = ((Year - 2000 + 100) * 1000 + ts.Days + 1).ToString();
            return juliano.Substring(1, juliano.Length - 1);
        }
        public static int Calcula_digito_verificador(string CodS)
        {
            int nCant;
            int nSuma, nFloat;
            int[] V1;
            string V2;
            int j;
            int starindex;

            V2 = "135793579357935793579357935793579357935793579357935";

            nCant = CodS.Length;

            V1 = new int[nCant];

            for (j = 0; j < nCant; j++)
            {
                V1[j] = 0;
            }
            Console.Write(j);
            // 1ª etapa
            for (int i = 0; i < nCant; i++)
            {
                V1[i] = Convert.ToInt32(CodS[i].ToString()) * Convert.ToInt32(V2[i].ToString());
            }
            nSuma = 0;
            // 2ª etapa
            for (int i = 0; i < nCant; i++)
            {
                nSuma = nSuma + V1[i];
            }
            nFloat = nSuma / 2;
            starindex = nFloat.ToString().Length - 1;
            return Convert.ToInt32(nFloat.ToString().Substring(starindex, 1));
        }
    }
}
