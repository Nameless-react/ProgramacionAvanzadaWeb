using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class TransactionReportDALImpl : DALGenericoImpl<TransactionReport>, ITransactionReportDAL
    {
        ProyectoWebAvanzadaContext context;

        public TransactionReportDALImpl(ProyectoWebAvanzadaContext context) : base(context) 
        {
            this.context = context;
        }


    }
}
