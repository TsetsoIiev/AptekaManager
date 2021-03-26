using System.Collections.Generic;
using System.Linq;
using AptekaManager.Internal.Dto;
using AptekaManager.Internal.Interfaces;
using AptekaManager.Internal.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AptekaManager.Internal.Repositories
{
    public class MeasurementUnitRepository : IMeasurementUnitRepository
    {
        private readonly IMapper _mapper;
        private readonly AptekaManagerContext _context;

        public MeasurementUnitRepository(IMapper mapper, AptekaManagerContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<MeasurementUnitDto> GetMeasurementUnits()
        {
            return _context.MeasurementUnits.Select(x => _mapper.Map<MeasurementUnitDto>(x));
        }

        public MeasurementUnitDto GetMeasurementUnitById(int measurementUnitId)
        {
            var measurementUnit = _context.MeasurementUnits.FirstOrDefault(x => x.Id == measurementUnitId);
            return _mapper.Map<MeasurementUnitDto>(measurementUnit);
        }

        public MeasurementUnitDto InsertMeasurementUnit(MeasurementUnitDto measurementUnit)
        {
            var newMeasurementUnit = _mapper.Map<MeasurementUnit>(measurementUnit);
            _context.MeasurementUnits.Add(newMeasurementUnit);
            return measurementUnit;
        }

        public MeasurementUnitDto DeleteMeasurementUnit(MeasurementUnitDto measurementUnit)
        {
            var measurementUnitToDelete = _mapper.Map<MeasurementUnit>(measurementUnit);
            _context.MeasurementUnits.Remove(measurementUnitToDelete);
            return measurementUnit;
        }

        public MeasurementUnitDto UpdateMeasurementUnit(MeasurementUnitDto measurementUnit)
        {
            var measurementUnitToUpdate = _mapper.Map<MeasurementUnit>(measurementUnit);
            _context.Entry(measurementUnitToUpdate).State = EntityState.Modified;
            return measurementUnit;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}