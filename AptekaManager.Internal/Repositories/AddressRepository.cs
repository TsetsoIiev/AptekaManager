using System.Collections.Generic;
using System.Linq;
using AptekaManager.Internal.Dto;
using AptekaManager.Internal.Interfaces;
using AptekaManager.Internal.Models;
using Microsoft.EntityFrameworkCore;

namespace AptekaManager.Internal.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AptekaManagerContext _context;

        public AddressRepository(AptekaManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<AddressDto> GetAddresses()
        {
            return _context.Addresses.Select(x => MapToDto(x));
        }

        public AddressDto GetAddressById(int addressId)
        {
            var address = _context.Addresses.FirstOrDefault(x => x.Id == addressId);
            return MapToDto(address);
        }

        public AddressDto InsertAddress(AddressDto address)
        {
            var newAddress = MapToDomain(address);
            _context.Addresses.Add(newAddress);
            _context.SaveChanges();
            return address;
        }

        public AddressDto DeleteAddress(AddressDto address)
        {
            var addressToDelete = MapToDomain(address);
            _context.Addresses.Remove(addressToDelete);
            _context.SaveChanges();
            return address;
        }

        public AddressDto UpdateAddress(AddressDto address)
        {
            var addressToUpdate = MapToDomain(address);
            _context.Entry(addressToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return address;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private static AddressDto MapToDto(Address address)
        {
            return new()
            {
                City = address.City,
                StreetName = address.StreetName,
                StreetNumber = address.DoorNumber
            };
        }

        private static Address MapToDomain(AddressDto addressDto)
        {
            return new()
            {
                City = addressDto.City,
                StreetName = addressDto.StreetName,
                DoorNumber = addressDto.StreetNumber
            };
        }
    }
}