using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnidadDeTrabajo: IDisposable
    {
        IEmployeeDAL EmployeeDAL { get; }
        IAccountTypeDAL AccountTypeDAL { get; }
        IClientDAL ClientDAL { get; }
        IAccountDAL AccountDAL { get; }
        ITransactionDAL TransactionDAL { get; }
        IAccessReportDAL AccessReportDAL { get;}
        bool Complete();
    }
}

