using System.Collections.Generic;
using AptekaManager.Internal.Dto;

namespace AptekaManager.Internal.Interfaces
{
    public interface IMeasurementUnitRepository
    {
        IEnumerable<MeasurementUnitDto> GetMeasurementUnits();
        
        MeasurementUnitDto GetMeasurementUnitById(int measurementUnitId);

        MeasurementUnitDto InsertMeasurementUnit(MeasurementUnitDto measurementUnit);

        MeasurementUnitDto DeleteMeasurementUnit(MeasurementUnitDto measurementUnit);

        MeasurementUnitDto UpdateMeasurementUnit(MeasurementUnitDto measurementUnit);

        void Save();
    }
}
