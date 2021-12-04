using OrionProject.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrionProject.Core.Interfaces
{
    public interface IAddressService
    {
        Task<List<Address>> GetAddresses();
        Task<Address> GetAddress(int id);
        Task AddAddress(Address address);
        Task UpdateAddress(Address address);
        Task DeleteAddress(int id);
    }
}
