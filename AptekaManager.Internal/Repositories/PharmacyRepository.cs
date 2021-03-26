using System.Collections.Generic;
using System.Linq;
using AptekaManager.Internal.Dto;
using AptekaManager.Internal.Interfaces;
using AptekaManager.Internal.Models;
using AutoMapper;
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

        public PharmacyDto InsertPharmacy(PharmacyDto pharmacy)
        {
            var newPharmacy = MapToDomain(pharmacy);
            _context.Pharmacies.Add(newPharmacy);
            return pharmacy;
        }

        public PharmacyDto DeletePharmacy(PharmacyDto pharmacy)
        {
            var pharmacyToDelete = MapToDomain(pharmacy);
            _context.Pharmacies.Remove(pharmacyToDelete);
            return pharmacy;
        }

        public PharmacyDto UpdatePharmacy(PharmacyDto pharmacy)
        {
            var pharmacyToUpdate = MapToDomain(pharmacy);
            _context.Entry(pharmacyToUpdate).State = EntityState.Modified;
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
                Id = pharmacy.Id,
                Name = pharmacy.Name,
                AddressStreetName = pharmacy.Address.StreetName,
                AddressStreetNumber = pharmacy.Address.DoorNumber,
                Products = pharmacy.PharmacyProducts.Select(x => x.Product).ToList()
            };
        }

        private Pharmacy MapToDomain(PharmacyDto pharmacyDto)
        {
            return new()
            {
                Id = pharmacyDto.Id,
                Name = pharmacyDto.Name,
                Address = new Address()
                {
                    StreetName = pharmacyDto.AddressStreetName,
                    DoorNumber = pharmacyDto.AddressStreetNumber
                }
            };
        }
    }
}