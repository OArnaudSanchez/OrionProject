using OrionProject.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrionProject.Core.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClients();
        Task<Client> GetClient(int id);
        Task<Client> AddClient(Client client);
        Task<bool> UpdateClient(Client client);
        Task<bool> DeleteClient(Client client);
    }
}
