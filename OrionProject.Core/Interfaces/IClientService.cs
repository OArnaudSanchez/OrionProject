using OrionProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrionProject.Core.Interfaces
{
    public interface IClientService
    {
        Task<List<Client>> GetClients();
        Task<Client> GetClient(int id);
        Task AddClient(Client client);
        Task UpdateClient(Client client);
        Task DeleteClient(int id);
    }
}
