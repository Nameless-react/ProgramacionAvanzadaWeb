using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class AccountTypeDALImpl : DALGenericoImpl<AccountType>, IAccountTypeDAL
    {
       ProyectoWebAvanzadaContext context;

        public AccountTypeDALImpl(ProyectoWebAvanzadaContext context) : base(context)
        {
            this.context = context;
        }
    }
}
