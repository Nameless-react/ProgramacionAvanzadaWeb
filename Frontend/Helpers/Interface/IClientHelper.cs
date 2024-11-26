using Frontend.Models;

namespace Frontend.Helpers.Interface
{
    public interface IClientHelper
    {
       List<ClientViewModel> GetClients();
        ClientViewModel Get(int id);
        ClientViewModel Add (ClientViewModel client);
        ClientViewModel Update (ClientViewModel client);
        void Delete (int id);
    }
}
