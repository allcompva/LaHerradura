using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LaHerradura.Macro
{
    public class ArchivoFacturacion
    {
        public static string crear(int periodo, DateTime fecha)
        {
            try
            {
                StringBuilder txt = new StringBuilder();
                //HEADER
                txt.Append("126067          00000");

                txt.Append(string.Format("{0}{1}{2}",
                fecha.Year,
                fecha.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                fecha.Day.ToString().PadLeft(2, Convert.ToChar("0"))));

                List<DAL.CTACTE_EXPENSAS> lstExpensas = DAL.CTACTE_EXPENSAS.getDebito(periodo);
                decimal total = lstExpensas.Sum(m => m.SALDO - m.DESC_VENCIMIENTO);
                string[] importe = new string[2];
                if (total.ToString().Contains(","))
                {
                    importe = total.ToString().Split(Convert.ToChar(","));
                }
                if (total.ToString().Contains("."))
                {
                    importe = total.ToString().Split(Convert.ToChar("."));
                }
                string imp = importe[0].PadLeft(16, Convert.ToChar("0")) +
                    importe[1].PadLeft(2, Convert.ToChar("0"));
                txt.Append(imp);
                txt.Append("0800100000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000                                                                     0");
                
                
                foreach (var item in lstExpensas)
                {
                    txt.AppendLine();
                    StringBuilder txtDet = new StringBuilder();
                    txtDet.Append("026067          00000");
                    txtDet.Append(item.BANCO);
                    txtDet.Append(item.SUCURSAL);
                    txtDet.Append(item.TIPO_COBIS);
                    txtDet.Append(item.CUENTA_BANCO);
                    txtDet.Append(item.IDENTIFICACION);
                    txtDet.Append(string.Format("{0}{1}",
                        item.PTO_VTA.ToString().PadLeft(4, Convert.ToChar("0")),
                        item.NRO_CTE.ToString().PadLeft(11, Convert.ToChar("0"))));
                    txtDet.Append("      ");
                    txtDet.Append(string.Format("{0}{1}{2}",
                       fecha.Year,
                       fecha.Month.ToString().PadLeft(2, Convert.ToChar("0")),
                       fecha.Day.ToString().PadLeft(2, Convert.ToChar("0"))));
                    txtDet.Append("080");
                    txtDet.Append("");
                    item.SALDO = item.SALDO - item.CAPITAL_PAGADO - item.DESC_VENCIMIENTO;
                    importe = new string[2];
                    if (item.SALDO.ToString().Contains(","))
                    {
                        importe = item.SALDO.ToString().Split(Convert.ToChar(","));
                    }
                    if (item.SALDO.ToString().Contains("."))
                    {
                        importe = item.SALDO.ToString().Split(Convert.ToChar("."));
                    }
                    imp = importe[0].PadLeft(11, Convert.ToChar("0")) +
                                        importe[1].PadLeft(2, Convert.ToChar("0"));
                    txtDet.Append(imp);
                    txtDet.Append("00000000");
                    txtDet.Append("000000000000000000000000000000000");
                    txtDet.Append("                      ");
                    string tipoExpensa = string.Empty;
                    if (periodo.ToString().Substring(6, 2) == "00")
                        tipoExpensa = "ORDINARIAS";
                    else
                        tipoExpensa = "EXTRAORDINARIAS";

                    txtDet.Append(string.Format("EXPENSAS {0} {1} {2}",
                        tipoExpensa, 
                        periodo.ToString().Substring(4,2),
                        periodo.ToString().Substring(0,4)).PadRight(40, Convert.ToChar(" ")));
                    txtDet.Append("     0");
                    txt.Append(txtDet.ToString());
                }

                return txt.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}