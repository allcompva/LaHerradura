﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class INMUEBLES
    {
        public static List<DAL.INMUEBLES> read()
        {
            try
            {
                return DAL.INMUEBLES.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DAL.INMUEBLES getByNroCta(int nroCta)
        {
            try
            {
                return DAL.INMUEBLES.getByNroCta(nroCta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int insert(DAL.INMUEBLES obj)
        {
            try
            {
                return DAL.INMUEBLES.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(DAL.INMUEBLES obj)
        {
            try
            {
                DAL.INMUEBLES.update(obj);
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
                DAL.INMUEBLES.delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void bajaDebito(int nroCta)
        {
            try
            {
                DAL.INMUEBLES.bajaDebito(nroCta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
