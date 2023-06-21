using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaHerradura.RapiPago
{
    public class CodigoBarra
    {
        //048 Fijo
        public string Identificador { get; set; }
        //Nro cta. 8 digitos (3 digitos) completar con 0 a la izq.
        public int IdCliente { get; set; }
        //Nro factura 11 digitos 3 digitos ptovta 8 digitos nro facura
        public string NroComprobante { get; set; }
        //8 digitos 6 enteros 2 decimales sin separador
        public string Importe1Venc { get; set; }
        //Fecha juliano 5 digitos sin el uno adelante
        public string Fec1Venc { get; set; }
        //Importe mora segundo venc. 6 digitos 4 enteros 2 decimales
        public string ImporteMora2Venc { get; set; }
        //Dias mora segundo vencimiento 2 digitos
        public string DiasMora2Venc { get; set; }
        //Importe mora tercer venc. 6 digitos 4 enteros 2 decimales
        public string ImporteMora3Venc { get; set; }
        //Dias mora segundo vencimiento 2 digitos
        public string DiasMora3Venc { get; set; }
        //Digito verificador

        public CodigoBarra()
        {
            Identificador = string.Empty;
            IdCliente = 0;
            NroComprobante = string.Empty;
            Importe1Venc = string.Empty;
            Fec1Venc = string.Empty;
            ImporteMora2Venc = string.Empty;
            DiasMora2Venc = string.Empty;
            ImporteMora3Venc = string.Empty;
            DiasMora3Venc = string.Empty;
        }

        public static string getCodigoBarra(int nroCta, int ptoVta, Int64 nroComp, decimal importe, DateTime venc1,
            decimal impMora2venc, int diasMora2venc, decimal impMora3venc, int diasMora3venc)
        {
            try
            {
                string codBarra = string.Empty;
                codBarra = string.Format("048{0}{1}{2}{3}{4}{5}{6}{7}{8}",
                    nroCta.ToString().PadLeft(8, Convert.ToChar("0")),
                    ptoVta.ToString().PadLeft(3, Convert.ToChar("0")),
                    nroComp.ToString().PadLeft(8, Convert.ToChar("0")),
                    decimalToString(importe, 6, 2),
                    juliano(venc1.Month, venc1.Day, venc1.Year),
                    decimalToString(impMora2venc, 4, 2),
                    diasMora2venc.ToString().PadLeft(2, Convert.ToChar("0")),
                    decimalToString(impMora3venc, 4, 2),
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
        public static string getCodigoBarraPrueba()
        {
            try
            {
                string codBarra = string.Empty;
                codBarra = "048000000060020000148901000000200400500000711500017";
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