using OrionProject.Core.Interfaces;
using OrionProject.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrionProject.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<List<Client>> GetClients()
        {
            return await _clientRepository.GetClients();
        }
        public async Task<Client> GetClient(int id)
        {
            return await _clientRepository.GetClient(id);
        }

        public async Task AddClient(Client client)
        {
            client.Id = 0;
            await _clientRepository.AddClient(client);
        }
        public async Task UpdateClient(Client client)
        {
            var currentClient = await GetClient(client.Id);
            currentClient.Email = client.Email ?? currentClient.Email;
            await _clientRepository.UpdateClient(currentClient);
        }

        public async Task DeleteClient(int id)
        {
            var currentClient = await GetClient(id);
            if (currentClient == null) throw new System.Exception("Client not Found");
            await _clientRepository.DeleteClient(currentClient);
        }

    }
}
