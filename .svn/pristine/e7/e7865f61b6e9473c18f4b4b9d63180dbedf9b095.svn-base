using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class PLANILLA_CAJA
    {
        public static List<DAL.PLANILLA_CAJA_GRAL> read(int id_empresa)
        {
            try
            {
                return DAL.PLANILLA_CAJA_GRAL.read(id_empresa);
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public static DAL.PLANILLA_CAJA_GRAL getByPk(int pk, int id_empresa)
        {
            try
            {
                return DAL.PLANILLA_CAJA_GRAL.getByPk(pk, id_empresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static bool Valida_Existe_Cajas_Cerradas(int id_planilla, int id_empresa)
        {
            try
            {
                return DAL.PLANILLA_CAJA_GRAL.Valida_Existe_Cajas_Cerradas(id_planilla, id_empresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static bool Valida_Existe_Caja_Abierta(int id_empresa)
        {
            try
            {
                return DAL.PLANILLA_CAJA_GRAL.Valida_Existe_Caja_Abierta(id_empresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //public static void Apertura_caja(DAL.PLANILLA_CAJA obj)
        //{
        //    SqlConnection cn;

        //    try
        //    {
        //        using (TransactionScope scope = new TransactionScope())
        //        {
        //            DAL.PLANILLA_CAJA.Apertura_caja(obj);
        //            scope.Complete();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {

        //    }
        //}
        //public static void Cierre_caja(DateTime desde, DateTime hasta, ref DAL.PLANILLA_CAJA oPC)
        //{
        //    //try
        //    //{
        //    //    using (TransactionScope scope = new TransactionScope())
        //    //    {
        //    //        //DAL.PLANILLA_CAJA.Elimina_caja(desde, hasta, oPC);
        //    //        DAL.PLANILLA_CAJA.Cierre_caja(desde, hasta, oPC);
        //    //        scope.Complete();
        //    //    }
        //    //}
        //    //catch (Exception e)
        //    //{

        //    //    throw e;
        //    //}

        //    SqlConnection cn = DAL.DALBase.GetConnection();
        //    SqlTransaction trx = null;

        //    try
        //    {
        //        cn.Open();
        //        trx = cn.BeginTransaction();
        //        DAL.PLANILLA_CAJA.Cierre_caja(desde, hasta, oPC, cn, trx);
        //        trx.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        trx.Rollback();
        //        throw ex;
        //    }
        //    finally
        //    { cn.Close(); }
        //}
        //public static void Cierre_cajaScope(DateTime desde, DateTime hasta, ref DAL.PLANILLA_CAJA oPC)
        //{
        //    try
        //    {
        //        using (TransactionScope scope = new TransactionScope())
        //        {
        //            //DAL.PLANILLA_CAJA.Elimina_caja(desde, hasta, oPC);
        //            DAL.PLANILLA_CAJA.Cierre_cajaScope(desde, hasta, oPC);
        //            scope.Complete();
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}
        //public static void Elimina_caja(DateTime desde, DateTime hasta, DAL.PLANILLA_CAJA oPC)
        //{
        //    SqlConnection cn = DAL.DALBase.GetConnection();
        //    SqlTransaction trx = null;

        //    try
        //    {
        //        cn.Open();
        //        trx = cn.BeginTransaction();
        //        DAL.PLANILLA_CAJA.Elimina_caja(desde, hasta, oPC, cn, trx);
        //        trx.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        trx.Rollback();
        //        throw ex;
        //    }
        //    finally
        //    { cn.Close(); }
        //}
        //public static void Elimina_cajaScope(DateTime desde, DateTime hasta, DAL.PLANILLA_CAJA oPC)
        //{
        //    try
        //    {
        //        using (TransactionScope scope = new TransactionScope())
        //        {
        //            DAL.PLANILLA_CAJA.Elimina_cajaScope(desde, hasta, oPC);
        //            scope.Complete();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public static DataSet ListTurnos(int id)
        //{
        //    return DAL.PLANILLA_CAJA.ListTurnos(id);
        //}
        //public static string MovimientosCaja(int id_planilla)
        //{
        //    try
        //    {
        //        return DAL.PLANILLA_CAJA.MovimientosTarjetas(id_planilla);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

    }
}
