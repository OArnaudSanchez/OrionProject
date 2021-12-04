using OrionProject.Core.Interfaces;
using OrionProject.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrionProject.Core.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IClientService _clientService;
        public AddressService(IAddressRepository addressRepository, IClientService clientService)
        {
            _addressRepository = addressRepository;
            _clientService = clientService;
        }
        public async Task<List<Address>> GetAddresses()
        {
            return await _addressRepository.GetAddresses();
        }
        public async Task<Address> GetAddress(int id)
        {
            return await _addressRepository.GetAddress(id);
        }
        public async Task AddAddress(Address address)
        {
            address.Id = 0;
            var currentClient = await _clientService.GetClient(address.IdClient);
            if (currentClient == null) throw new System.Exception("Client Not Found");
            await _addressRepository.AddAddress(address);
        }
        public async Task UpdateAddress(Address address)
        {
            var currentClient = await _clientService.GetClient(address.IdClient);
            if (currentClient == null) throw new System.Exception("Client Not Found");

            var currentAddress = await GetAddress(address.Id);
            currentAddress.City = address.City ?? currentAddress.City;
            currentAddress.StreetName = address.StreetName ?? currentAddress.StreetName;
            currentAddress.StreetNumber = address.StreetNumber ?? currentAddress.StreetNumber;
            currentAddress.PostalCode = address.PostalCode ?? currentAddress.PostalCode;
            currentAddress.IdClient = currentClient.Id;

            await _addressRepository.UpdateAddress(currentAddress);
        }

        public async Task DeleteAddress(int id)
        {
            var currentAddress = await GetAddress(id);
            if (currentAddress == null) throw new System.Exception("Address Not Found");
            await _addressRepository.DeleteAddress(currentAddress);
        }
    }
}
