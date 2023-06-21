using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaHerradura.Back
{
    public class Utils
    {
        public static string periodo(int periodo)
        {
            try
            {
                string per = string.Empty;
                if (periodo != 20190100)
                {
                    string me, mes = string.Empty;
                    me = periodo.ToString().Substring(4, 2);
                    switch (me)
                    {
                        case "01":
                            mes = "Enero";
                            break;
                        case "02":
                            mes = "Febrero";
                            break;
                        case "03":
                            mes = "Marzo";
                            break;
                        case "04":
                            mes = "Abril";
                            break;
                        case "05":
                            mes = "Mayo";
                            break;
                        case "06":
                            mes = "Junio";
                            break;
                        case "07":
                            mes = "Julio";
                            break;
                        case "08":
                            mes = "Agosto";
                            break;
                        case "09":
                            mes = "Septiembre";
                            break;
                        case "10":
                            mes = "Octubre";
                            break;
                        case "11":
                            mes = "Noviembre";
                            break;
                        case "12":
                            mes = "Diciembre";
                            break;
                        default:
                            break;
                    }
                    if (periodo.ToString().Substring(6, 2) == "00")
                    {
                        per =
                            string.Format(
                                "Expensas Ordinarias {0} de {1}",
                                mes,
                                periodo.ToString().Substring(0, 4));
                    }
                    else
                    {
                        per =
                            string.Format(
                                "Expensas Extraordinarias {0} de {1}",
                                mes,
                                periodo.ToString().Substring(0, 4));
                    }
                }
                else
                {
                    per = "Saldo capital a Septiembre de 2019";

                }
                return per;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}