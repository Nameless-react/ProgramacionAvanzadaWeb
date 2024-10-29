using Backend.DTO;

namespace Backend.Services.Interfaces
{
    public interface IAccountService
    {

        bool Add(AccountDTO account);
        bool Update(AccountDTO account);
        bool Remove(AccountDTO account);
        AccountDTO Get(int id);
        List<AccountDTO> GetAll();
    
}
}
