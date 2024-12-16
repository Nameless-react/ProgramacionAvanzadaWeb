using Backend.DTO;
using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        IUnidadDeTrabajo Unidad;

        public EmployeeService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.Unidad = unidadDeTrabajo;
        }


        #region Convert
        Employee Convert(EmployeeDTO employee)
        {
            return new Employee()
            {
                EmployeeId = employee.EmployeeID,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Idnumber = employee.IDNumber,
                Phone = employee.Phone,
                Address = employee.Address,
                Email = employee.Email,
                HireDate = employee.HireDate,
                Position = employee.Position
            };
        }

        EmployeeDTO Convert(Employee employee)
        {
            return new EmployeeDTO
            {
                EmployeeID = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                IDNumber = employee.Idnumber,
                Phone = employee.Phone,
                Address = employee.Address,
                Email = employee.Email,
                HireDate = employee.HireDate,
                Position = employee.Position
            };
        }
        #endregion


        public bool Add(EmployeeDTO employee)
        {
            Employee entity = Convert(employee);
            Unidad.EmployeeDAL.Add(entity);
            return Unidad.Complete();
        }

        public EmployeeDTO Get(int id)
        {
            return Convert(Unidad.EmployeeDAL.Get(id));
            
        }

        public List<EmployeeDTO> GetAll()
        {
            List<EmployeeDTO> list = new List<EmployeeDTO>();
            var employees = Unidad.EmployeeDAL.GetAll().ToList();
            foreach ( var item in employees)
            {
                list.Add(Convert(item));
            }
            return list;
        }

        public void Remove(int id)
        {
            Employee employee = new Employee { EmployeeId = id };
            Unidad.EmployeeDAL.Remove(employee);
            Unidad.Complete();
        }

        public bool Update(EmployeeDTO employee)
        {
            var entity = Convert(employee);
            Unidad.EmployeeDAL.Update(entity);
            return Unidad.Complete();
        }
    }
}
