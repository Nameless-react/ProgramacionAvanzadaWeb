using DAL.Interfaces;
using Entities.Entities;

public class UnidadDeTrabajo : IUnidadDeTrabajo
{
    public IEmployeeDAL EmployeeDAL { get; set; }
    public IClientDAL ClientDAL { get; set; }
    public IAccountDAL AccountDAL { get; set; } // Agregado para Account

    private readonly ProyectoWebAvanzadaContext _proyectoWebAvanzada;

    public UnidadDeTrabajo(ProyectoWebAvanzadaContext proyectoWebAvanzadaContext,
                           IEmployeeDAL employeesDAL,
                           IClientDAL clientDAL,
                           IAccountDAL accountDAL) // Asegúrate de recibir AccountDAL
    {
        this._proyectoWebAvanzada = proyectoWebAvanzadaContext;
        this.EmployeeDAL = employeesDAL;
        this.ClientDAL = clientDAL;
        this.AccountDAL = accountDAL; // Asignar AccountDAL
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
            // Manejar el error si es necesario
            return false;
        }
    }

    public void Dispose()
    {
        this._proyectoWebAvanzada.Dispose();
    }
}
