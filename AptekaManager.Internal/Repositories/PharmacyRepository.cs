using System.Collections.Generic;
using System.Linq;
using AptekaManager.Internal.Dto;
using AptekaManager.Internal.Interfaces;
using AptekaManager.Internal.Models;
using Microsoft.EntityFrameworkCore;

namespace AptekaManager.Internal.Repositories
{
    public class PharmacyRepository : IPharmacyRepository
    {
        private readonly AptekaManagerContext _context;

        public PharmacyRepository(AptekaManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<PharmacyDto> GetPharmacies()
        {
            return _context.Pharmacies.Select(x => MapToDto(x));
        }

        public PharmacyDto GetPharmaciesById(int pharmacyId)
        {
            var pharmacy = _context.Pharmacies.FirstOrDefault(x => x.Id == pharmacyId);
            return MapToDto(pharmacy);
        }

        public IEnumerable<PharmacyResult> GetPharmaciesForMedicine(string name)
        {
            var advancedContext = _context.PharmacyProducts
                .Include(p => p.Product)
                .Include(p => p.Pharmacy)
                .ThenInclude(p => p.Address);

            return advancedContext
                .Where(x => x.Product.Name.ToLower().Contains(name))
                .Select(x => new PharmacyResult(
                    MapToDto(_context.Pharmacies
                    .Where(y => y.Id == x.PharmacyId)
                    .Include(p => p.Address)
                    .FirstOrDefault())
                    , x.Product))
                .ToList();
        }

        public PharmacyDto InsertPharmacy(PharmacyDto pharmacy)
        {
            var newPharmacy = MapToDomain(pharmacy);
            _context.Pharmacies.Add(newPharmacy);
            _context.SaveChanges();
            return pharmacy;
        }

        public PharmacyDto DeletePharmacy(PharmacyDto pharmacy)
        {
            var pharmacyToDelete = MapToDomain(pharmacy);
            _context.Pharmacies.Remove(pharmacyToDelete);
            _context.SaveChanges();
            return pharmacy;
        }

        public PharmacyDto UpdatePharmacy(PharmacyDto pharmacy)
        {
            var pharmacyToUpdate = MapToDomain(pharmacy);
            _context.Entry(pharmacyToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return pharmacy;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private static PharmacyDto MapToDto(Pharmacy pharmacy)
        {
            return new()
            {
                Name = pharmacy.Name,
                AddressCity = pharmacy.Address.City,
                AddressStreetName = pharmacy.Address.StreetName,
                AddressStreetNumber = pharmacy.Address.DoorNumber,
                Products = pharmacy.PharmacyProducts.Select(x => x.Product).ToList()
            };
        }

        private static Pharmacy MapToDomain(PharmacyDto pharmacyDto)
        {
            return new()
            {
                Name = pharmacyDto.Name,
                Address = new Address()
                {
                    City = pharmacyDto.AddressCity,
                    StreetName = pharmacyDto.AddressStreetName,
                    DoorNumber = pharmacyDto.AddressStreetNumber
                }
            };
        }
    }
}