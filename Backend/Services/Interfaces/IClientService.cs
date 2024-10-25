

using Backend.DTO;

namespace Backend.Services.Interfaces
{
    public interface IClientService
    {
        bool Add(ClientDTO client);
        bool Update(ClientDTO client);
        bool Remove(ClientDTO client);
        ClientDTO Get(int id);
        List<ClientDTO> GetAll();
    }
}
