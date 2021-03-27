using System.Collections.Generic;
using AptekaManager.Internal.Dto;

namespace AptekaManager.Internal.Interfaces
{
    public interface IPharmacyRepository
    {
        IEnumerable<PharmacyDto> GetPharmacies();
        
        PharmacyDto GetPharmaciesById(int pharmacyId);

        IEnumerable<PharmacyResult> GetPharmaciesForMedicine(string name);

        PharmacyDto InsertPharmacy(PharmacyDto pharmacy);

        PharmacyDto DeletePharmacy(PharmacyDto pharmacy);

        PharmacyDto UpdatePharmacy(PharmacyDto pharmacy);

        void Save();
    }
}