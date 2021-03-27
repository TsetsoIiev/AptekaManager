using AptekaManager.Internal.Dto;
using AptekaManager.Internal.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AptekaManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeasurementUnitController : ControllerBase
    {
        private readonly IMeasurementUnitRepository _measurementUnitRepository;

        public MeasurementUnitController(IMeasurementUnitRepository measurementUnitRepository)
        {
            _measurementUnitRepository = measurementUnitRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetMeasurementUnits()
        {
            return Ok(_measurementUnitRepository.GetMeasurementUnits());
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetMeasurementUnitById([FromRoute] int id)
        {
            var measurementUnit = _measurementUnitRepository.GetMeasurementUnitById(id);
            return measurementUnit is null
                ? NotFound()
                : Ok(measurementUnit);
        }

        [HttpPost("[action]")]
        public IActionResult CreateMeasurementUnit(MeasurementUnitDto measurementUnit)
        {
            return CreatedAtAction("CreateMeasurementUnit", 
                _measurementUnitRepository.InsertMeasurementUnit(measurementUnit));
        }

        [HttpPut("[action]")]
        public IActionResult UpdateMeasurementUnit(MeasurementUnitDto measurementUnitDto)
        {
            return CreatedAtAction("UpdateMeasurementUnit",
                _measurementUnitRepository.UpdateMeasurementUnit(measurementUnitDto));
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteMeasurementUnit(MeasurementUnitDto measurementUnit)
        {
            return Ok(_measurementUnitRepository.DeleteMeasurementUnit(measurementUnit));
        }
    }
}