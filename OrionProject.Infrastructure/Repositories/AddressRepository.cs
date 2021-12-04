using Microsoft.EntityFrameworkCore;
using OrionProject.Core.Interfaces;
using OrionProject.Core.Models;
using OrionProject.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrionProject.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly OrionProjectContext _context;
        public AddressRepository(OrionProjectContext context)
        {
            _context = context;
        }
        public async Task<List<Address>> GetAddresses()
        {
            return await _context.Addresses.ToListAsync();
        }
        public async Task<Address> GetAddress(int id)
        {
            return await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Address> AddAddress(Address address)
        {
            try
            {
                _context.Addresses.Add(address);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return address;
        }
        public async Task<bool> UpdateAddress(Address address)
        {
            try
            {
                _context.Entry(address).State = EntityState.Modified;
            }
            catch (Exception)
            {

                throw;
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAddress(Address address)
        {
            try
            {
                _context.Addresses.Remove(address);
            }
            catch (Exception)
            {
                throw;
            }

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
