using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ClientDALImpl: DALGenericoImpl<Client>, IClientDAL
    {
        ProyectoWebAvanzadaContext context;

        public ClientDALImpl(ProyectoWebAvanzadaContext context): base(context)
        {
            this.context = context;
        }
    }
}
