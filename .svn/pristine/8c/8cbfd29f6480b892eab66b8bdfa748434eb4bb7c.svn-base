using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class LIQUIDACION_EXPENSAS
    {
        public static List<DAL.LIQUIDACION_EXPENSAS> read()
        {
            try
            {
                return DAL.LIQUIDACION_EXPENSAS.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DAL.LIQUIDACION_EXPENSAS getByPk(int PERIODO)
        {
            try
            {
                return DAL.LIQUIDACION_EXPENSAS.getByPk(PERIODO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void insert(DAL.LIQUIDACION_EXPENSAS obj)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.LIQUIDACION_EXPENSAS.insert(obj);
                    DAL.CONCEPTOS_X_LIQUIDACION objOrdinario = 
                        new DAL.CONCEPTOS_X_LIQUIDACION();
                    if (obj.PERIODO.ToString().Substring(7, 1) == "0")
                    {
                        objOrdinario.ID_CONCEPTO = 1;
                        objOrdinario.DESC_CONCEPTO = "EXPENSA ORDINARA";
                    }
                    else
                    {
                        objOrdinario.ID_CONCEPTO = 15;
                        objOrdinario.DESC_CONCEPTO = "EXPENSA EXORDINARA";
                    }
                    objOrdinario.CANT = 1;
                    objOrdinario.MONTO = obj.MONTO_3;
                    objOrdinario.SUBTOTAL = objOrdinario.CANT * objOrdinario.MONTO;
                    objOrdinario.PERIODO = obj.PERIODO;
                    objOrdinario.NRO_ORDEN = 1;
                    DAL.CONCEPTOS_X_LIQUIDACION.insert(objOrdinario);
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(DAL.LIQUIDACION_EXPENSAS obj, int periodoNuevo)
        {
            try
            {
                DAL.LIQUIDACION_EXPENSAS.update(obj, periodoNuevo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int periodo)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.DETALLE_DEUDA.delete(periodo);
                    List<DAL.CONCEPTOS_X_INMUEBLE> lst = DAL.CONCEPTOS_X_INMUEBLE.read(periodo);
                    foreach (var item in lst)
                    {
                        DAL.CONCEPTOS_X_INMUEBLE.desimputar(periodo);
                    }
                    DAL.CTACTE_EXPENSAS.deletePeriodo(periodo);
                    DAL.LIQUIDACION_EXPENSAS.updateLiquida(periodo);
                    DAL.CONCEPTOS_X_LIQUIDACION.delete(periodo);
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
