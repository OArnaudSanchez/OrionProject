using Microsoft.EntityFrameworkCore;
using OrionProject.Core.Interfaces;
using OrionProject.Core.Models;
using OrionProject.Infrastructure.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrionProject.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly OrionProjectContext _context;
        public ClientRepository(OrionProjectContext context)
        {
            _context = context;
        }
        public async Task<List<Client>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }
        public async Task<Client> GetClient(int id)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Client> AddClient(Client client)
        {
            try
            {
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
            }
            return client;
        }
        public async Task<bool> UpdateClient(Client client)
        {
            try
            {
                _context.Entry(client).State = EntityState.Modified;
            }
            catch (System.Exception)
            {
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteClient(Client client)
        {
            try
            {
                _context.Clients.Remove(client);
            }
            catch (System.Exception)
            {
            }
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
