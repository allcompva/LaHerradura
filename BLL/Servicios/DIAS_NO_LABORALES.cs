using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Carnets
{
    public class DIAS_NO_LABORALES
    {

        public static List<DAL.Carnets.DIAS_NO_LABORALES> read()
        {
            try
            {
                return DAL.Carnets.DIAS_NO_LABORALES.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static DAL.Carnets.DIAS_NO_LABORALES getByFecha(DateTime fecha)
        {
            try
            {
                return DAL.Carnets.DIAS_NO_LABORALES.getByFecha(fecha);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void insert(DAL.Carnets.DIAS_NO_LABORALES obj)
        {
            try
            {
                DAL.Carnets.DIAS_NO_LABORALES.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void delete(DateTime FECHA)
        {
            try
            {
                DAL.Carnets.DIAS_NO_LABORALES.delete(FECHA);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
