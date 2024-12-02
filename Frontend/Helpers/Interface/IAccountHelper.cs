using Frontend.Models;

namespace Frontend.Helpers.Interface
{
    public interface IAccountHelper
    {
        List<AccountViewModel> GetAccounts();
        string Token { get; set; }
        AccountViewModel GetAccount(int? id);
        AccountViewModel Add(AccountViewModel account);
        AccountViewModel Update(AccountViewModel account);
        void Delete(int id);
    }
}
