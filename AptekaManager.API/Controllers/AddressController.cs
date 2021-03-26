using AptekaManager.Internal.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AptekaManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        [HttpGet]
        public IActionResult GetAddresses()
        {
            return Ok(_addressRepository.GetAddresses());
        }
    }
}