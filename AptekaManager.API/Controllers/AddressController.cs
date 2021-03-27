using AptekaManager.Internal.Dto;
using AptekaManager.Internal.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AptekaManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetAddresses()
        {
            return Ok(_addressRepository.GetAddresses());
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetAddressById([FromRoute] int id)
        {
            var address = _addressRepository.GetAddressById(id);
            return address is null
                ? NotFound()
                : Ok(address);
        }

        [HttpPost("[action]")]
        public IActionResult CreateAddress(AddressDto address)
        {
            return CreatedAtAction("CreateAddress", _addressRepository.InsertAddress(address));
        }

        [HttpPut("[action]")]
        public IActionResult UpdateAddress(AddressDto address)
        {
            return CreatedAtAction("UpdateAddress", _addressRepository.UpdateAddress(address));
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteAddress(AddressDto address)
        {
            return Ok(_addressRepository.DeleteAddress(address));
        }
    }
}