using System.Collections.Generic;
using System.Linq;
using AptekaManager.Internal.Dto;
using AptekaManager.Internal.Interfaces;
using AptekaManager.Internal.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AptekaManager.Internal.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IMapper _mapper;
        private readonly AptekaManagerContext _context;

        public AddressRepository(IMapper mapper, AptekaManagerContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<AddressDto> GetAddresses()
        {
            return _context.Addresses.Select(x => _mapper.Map<AddressDto>(x));
        }

        public AddressDto GetAddressById(int addressId)
        {
            var address = _context.Addresses.FirstOrDefault(x => x.Id == addressId);
            return _mapper.Map<AddressDto>(address);
        }

        public AddressDto InsertAddress(AddressDto address)
        {
            var newAddress = _mapper.Map<Address>(address);
            _context.Addresses.Add(newAddress);
            return address;
        }

        public AddressDto DeleteAddress(AddressDto address)
        {
            var addressToDelete = _mapper.Map<Address>(address);
            _context.Addresses.Remove(addressToDelete);
            return address;
        }

        public AddressDto UpdateAddress(AddressDto address)
        {
            var addressToUpdate = _mapper.Map<Address>(address);
            _context.Entry(addressToUpdate).State = EntityState.Modified;
            return address;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}