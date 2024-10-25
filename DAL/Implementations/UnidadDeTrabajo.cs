using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IEmployeeDAL EmployeeDAL { get; set; }

        public IClientDAL ClientDAL { get; set; }

        private ProyectoWebAvanzadaContext _proyectoWebAvanzada;

        public UnidadDeTrabajo(ProyectoWebAvanzadaContext proyectoWebAvanzadaContext,
                        IEmployeeDAL employeesDAL,
                        IClientDAL clientDAL

            ) 
        {
                this._proyectoWebAvanzada = proyectoWebAvanzadaContext;
                this.EmployeeDAL = employeesDAL;
            this.ClientDAL = clientDAL;

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
}
