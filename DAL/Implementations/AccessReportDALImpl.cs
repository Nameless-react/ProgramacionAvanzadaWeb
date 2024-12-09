using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Implementations
{
    public class AccessReportDALImpl : DALGenericoImpl<AccessReport>, IAccessReportDAL
    {
        public AccessReportDALImpl(ProyectoWebAvanzadaContext context) : base(context)
        {
        }
    }
}
