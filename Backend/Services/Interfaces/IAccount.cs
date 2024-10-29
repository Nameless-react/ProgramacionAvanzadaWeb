using Backend.DTO;

namespace Backend.Services.Interfaces
{
    public interface IAccount
    {

        bool Add(AccountDTO account);
        bool Update(AccountDTO account);
        bool Remove(AccountDTO account);
        AccountDTO Get(int id);
        List<AccountDTO> GetAll();
    
}
}
