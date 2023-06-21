using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Servicios
    {
        public static List<DAL.SERVICIOS> read()
        {
            try
            {
                return DAL.SERVICIOS.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DAL.SERVICIOS getByPk(int id)
        {
            try
            {
                return DAL.SERVICIOS.getByPk(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(DAL.SERVICIOS obj)
        {
            try
            {
                return DAL.SERVICIOS.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(DAL.SERVICIOS obj)
        {
            try
            {
                DAL.SERVICIOS.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(int id)
        {
            try
            {
                DAL.SERVICIOS.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
