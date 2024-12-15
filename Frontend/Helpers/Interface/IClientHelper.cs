using Frontend.Models;

namespace Frontend.Helpers.Interface
{
    public interface IClientHelper
    {
       List<ClientViewModel> GetClients();
        string Token { get; set; }
        ClientViewModel Get(int id);
        ClientViewModel Add (ClientViewModel client);
        ClientViewModel Update (ClientViewModel client);
        void Delete (int id);
    }
}
