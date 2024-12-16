using Backend.DTO;

namespace Backend.Services.Interfaces
{
    public interface IEmployeeService
    {
        bool Add(EmployeeDTO employee);
        bool Update(EmployeeDTO employee);
        void Remove(int id);
        
        EmployeeDTO Get(int id);
        
        List<EmployeeDTO> GetAll();

    }
}
