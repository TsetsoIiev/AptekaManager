using System.Collections.Generic;
using AptekaManager.Internal.Dto;

namespace AptekaManager.Internal.Interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<AddressDto> GetAddresses();
        
        AddressDto GetAddressById(int addressId);

        AddressDto InsertAddress(AddressDto address);

        AddressDto DeleteAddress(AddressDto address);

        AddressDto UpdateAddress(AddressDto address);

        void Save();
    }
}