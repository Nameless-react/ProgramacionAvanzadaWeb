using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class AccountDALImpl : DALGenericoImpl<Account>, IAccountDAL
    {
        private readonly ProyectoWebAvanzadaContext context;

        public AccountDALImpl(ProyectoWebAvanzadaContext context) : base(context)
        {
            this.context = context;
        }
    }
}