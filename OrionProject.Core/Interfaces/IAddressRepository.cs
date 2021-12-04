using OrionProject.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrionProject.Core.Interfaces
{
    public interface IAddressRepository
    {
        Task<List<Address>> GetAddresses();
        Task<Address> GetAddress(int id);
        Task<Address> AddAddress(Address client);
        Task<bool> UpdateAddress(Address client);
        Task<bool> DeleteAddress(Address client);
    }
}
