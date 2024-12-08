using DAL.Interfaces;
using Entities.Entities;

public class UnidadDeTrabajo : IUnidadDeTrabajo
{
    public IEmployeeDAL EmployeeDAL { get; set; }
    public IAccountTypeDAL AccountTypeDAL { get; set; }
    public IClientDAL ClientDAL { get; set; }
    public IAccountDAL AccountDAL { get; set; }
    public ITransactionDAL TransactionDAL { get; set; }

    public IAccessReportDAL AccessReportDAL { get; set; }

    private ProyectoWebAvanzadaContext _proyectoWebAvanzada;


    public UnidadDeTrabajo(ProyectoWebAvanzadaContext proyectoWebAvanzadaContext,
                           IEmployeeDAL employeesDAL,
                           IAccountTypeDAL accountTypeDAL,
                           IClientDAL clientDAL,
                           IAccountDAL accountDAL,
                           ITransactionDAL transactionDAL,
                           IAccessReportDAL accessReportDAL)
       
    {
        this._proyectoWebAvanzada = proyectoWebAvanzadaContext;
        this.EmployeeDAL = employeesDAL;
        this.ClientDAL = clientDAL;
        this.AccountDAL = accountDAL; 
        this.TransactionDAL = transactionDAL;
        this.AccountTypeDAL = accountTypeDAL;
        this.AccessReportDAL = accessReportDAL;

    }


    public bool Complete()
    {
        try
        {
            _proyectoWebAvanzada.SaveChanges();
            return true;
        }
        catch (Exception e)
        {
           
            return false;
        }
    }

    public void Dispose()
    {
        this._proyectoWebAvanzada.Dispose();
    }
}
