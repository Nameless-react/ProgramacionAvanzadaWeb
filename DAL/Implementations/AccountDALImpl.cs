using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class AccountDALImpl : DALGenericoImpl<Account>, IAccountDAL
    {
        ProyectoWebAvanzadaContext context;

        public AccountDALImpl(ProyectoWebAvanzadaContext context) : base(context)
        {
            this.context = context;
        }
    }
}