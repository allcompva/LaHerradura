using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class PERSONAS_X_INMUEBLES
    {
        public static void updateResponsable(int idPersona, int nroCta)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    DAL.PERSONAS_X_INMUEBLES.updateResponsable(nroCta);
                    DAL.PERSONAS_X_INMUEBLES.updateResponsable(idPersona, nroCta);
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
