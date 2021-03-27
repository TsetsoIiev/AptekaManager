using AptekaManager.Internal.Dto;
using AptekaManager.Internal.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AptekaManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PharmacyController : ControllerBase
    {
        private readonly IPharmacyRepository _pharmacyRepository;

        public PharmacyController(IPharmacyRepository pharmacyRepository)
        {
            _pharmacyRepository = pharmacyRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetPharmacies()
        {
            return Ok(_pharmacyRepository.GetPharmacies());
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetPharmacyById([FromRoute]int id)
        {
            var pharmacy = _pharmacyRepository.GetPharmaciesById(id);
            return pharmacy is null
                ? NotFound()
                : Ok(pharmacy);
        }

        [HttpGet("[action]/{name}")]
        public IActionResult GetMedicines([FromRoute] string name)
        {
            var pharmacies = _pharmacyRepository.GetPharmaciesForMedicine(name);

            return pharmacies != null && pharmacies.Any()
                ? Ok(pharmacies)
                : NotFound();
        }

        [HttpPost("[action]")]
        public IActionResult CreatePharmacy([FromBody]PharmacyDto pharmacy)
        {
            return CreatedAtAction("CreatePharmacy", _pharmacyRepository.InsertPharmacy(pharmacy));
        }

        [HttpPut("[action]")]
        public IActionResult UpdatePharmacy([FromBody]PharmacyDto pharmacy)
        {
            return CreatedAtAction("UpdatePharmacy", pharmacy);
        }

        [HttpDelete("[action]")]
        public IActionResult DeletePharmacy([FromBody]PharmacyDto pharmacy)
        {
            return Ok(_pharmacyRepository.DeletePharmacy(pharmacy));
        }
    }
}