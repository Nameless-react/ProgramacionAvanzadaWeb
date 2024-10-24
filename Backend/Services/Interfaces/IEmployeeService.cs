using Backend.DTO;

namespace Backend.Services.Interfaces
{
    public interface IEmployeeService
    {
        bool Add(EmployeeDTO employee);
        bool Edit(EmployeeDTO employee);
        bool Delete(EmployeeDTO employee);
        /// <summary>
        /// Obtiene Category por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EmployeeDTO Get(int id);
        /// <summary>
        /// Obtiene todas la categories
        /// </summary>
        /// <returns></returns>
        List<EmployeeDTO> Get();

    }
}
