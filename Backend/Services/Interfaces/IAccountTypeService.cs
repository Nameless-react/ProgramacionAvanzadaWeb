using Backend.DTO;

namespace Backend.Services.Interfaces
{
    public interface IAccountTypeService
    {
        AccountTypeDTO Get(int id);
        List<AccountTypeDTO> GetAll();

    }
}
