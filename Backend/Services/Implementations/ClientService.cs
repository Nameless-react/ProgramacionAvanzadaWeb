using Backend.DTO;
using Backend.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace Backend.Services.Implementations
{
    public class ClientService : IClientService
    {
        IUnidadDeTrabajo Unidad;

        public ClientService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            this.Unidad = unidadDeTrabajo;
        }

        Client Convertir(ClientDTO client)
        {
            return new Client()
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                DateOfBirth = client.DateOfBirth,
                Phone = client.Phone,
                Email = client.Email,
                Address = client.Address,
                City = client.City,
                Country = client.Country,
                RegistrationDate = client.RegistrationDate
            };
        }

        ClientDTO Convertir(Client client)
        {
            return new ClientDTO
            {
                ClientId = client.ClientId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                DateOfBirth = client.DateOfBirth,
                Phone = client.Phone,
                Email = client.Email,
                Address = client.Address,
                City = client.City,
                Country = client.Country,
                RegistrationDate = client.RegistrationDate
            };
        }

        public bool Add(ClientDTO client)
        {
            Client entity = Convertir(client);
            Unidad.ClientDAL.Add(entity);
            return Unidad.Complete();
        }

        public ClientDTO Get(int id)
        {
            return Convertir(Unidad.ClientDAL.Get(id));
        }

        public List<ClientDTO> GetAll()
        {
            List<ClientDTO> list = new List<ClientDTO>();
            var clients = Unidad.ClientDAL.GetAll().ToList();

            foreach (var item in clients)
            {
                list.Add(Convertir(item));
            }
            return list;
        }

        public bool Remove(ClientDTO client)
        {
            Unidad.ClientDAL.Remove(Convertir(client));
            return Unidad.Complete();
        }

        public bool Update(ClientDTO client)
        {
            var entity = Convertir(client);
            Unidad.ClientDAL.Update(entity);
            return Unidad.Complete();
        }
    }
}
