using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BLL
{
    public class ASIENTOS
    {
        public static void delete(int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                DAL.ASIENTOS_DETALLE.delete(id);
                DAL.ASIENTOS.delete(id);
                scope.Complete();
            }


        }
    }
}
