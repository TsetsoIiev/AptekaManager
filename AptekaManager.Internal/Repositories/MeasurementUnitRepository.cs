using System.Collections.Generic;
using System.Linq;
using AptekaManager.Internal.Dto;
using AptekaManager.Internal.Interfaces;
using AptekaManager.Internal.Models;
using Microsoft.EntityFrameworkCore;

namespace AptekaManager.Internal.Repositories
{
    public class MeasurementUnitRepository : IMeasurementUnitRepository
    {
        private readonly AptekaManagerContext _context;

        public MeasurementUnitRepository(AptekaManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<MeasurementUnitDto> GetMeasurementUnits()
        {
            return _context.MeasurementUnits.Select(x => MapToDto(x));
        }

        public MeasurementUnitDto GetMeasurementUnitById(int measurementUnitId)
        {
            var measurementUnit = _context.MeasurementUnits.FirstOrDefault(x => x.Id == measurementUnitId);
            return MapToDto(measurementUnit);
        }

        public MeasurementUnitDto InsertMeasurementUnit(MeasurementUnitDto measurementUnit)
        {
            var newMeasurementUnit = MapToDomain(measurementUnit);
            _context.MeasurementUnits.Add(newMeasurementUnit);
            return measurementUnit;
        }

        public MeasurementUnitDto DeleteMeasurementUnit(MeasurementUnitDto measurementUnit)
        {
            var measurementUnitToDelete = MapToDomain(measurementUnit);
            _context.MeasurementUnits.Remove(measurementUnitToDelete);
            return measurementUnit;
        }

        public MeasurementUnitDto UpdateMeasurementUnit(MeasurementUnitDto measurementUnit)
        {
            var measurementUnitToUpdate = MapToDomain(measurementUnit);
            _context.Entry(measurementUnitToUpdate).State = EntityState.Modified;
            return measurementUnit;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private static MeasurementUnitDto MapToDto(MeasurementUnit measurementUnit)
        {
            return new()
            {
                Id = measurementUnit.Id,
                Name = measurementUnit.Name
            };
        }

        private static MeasurementUnit MapToDomain(MeasurementUnitDto measurementUnitDto)
        {
            return new MeasurementUnit()
            {
                Id = measurementUnitDto.Id,
                Name = measurementUnitDto.Name
            };
        }
    }
}