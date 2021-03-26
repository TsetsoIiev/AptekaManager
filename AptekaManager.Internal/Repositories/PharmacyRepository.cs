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
        private readonly IMapper _mapper;
        private readonly AptekaManagerContext _context;

        public PharmacyRepository(IMapper mapper, AptekaManagerContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<PharmacyDto> GetPharmacies()
        {
            return _context.Pharmacies.Select(x => _mapper.Map<PharmacyDto>(x));
        }

        public PharmacyDto GetPharmaciesById(int pharmacyId)
        {
            var pharmacy = _context.Pharmacies.FirstOrDefault(x => x.Id == pharmacyId);
            return _mapper.Map<PharmacyDto>(pharmacy);
        }

        public PharmacyDto InsertPharmacy(PharmacyDto pharmacy)
        {
            var newPharmacy = _mapper.Map<Pharmacy>(pharmacy);
            _context.Pharmacies.Add(newPharmacy);
            return pharmacy;
        }

        public PharmacyDto DeletePharmacy(PharmacyDto pharmacy)
        {
            var pharmacyToDelete = _mapper.Map<Pharmacy>(pharmacy);
            _context.Pharmacies.Remove(pharmacyToDelete);
            return pharmacy;
        }

        public PharmacyDto UpdatePharmacy(PharmacyDto pharmacy)
        {
            var pharmacyToUpdate = _mapper.Map<Pharmacy>(pharmacy);
            _context.Entry(pharmacyToUpdate).State = EntityState.Modified;
            return pharmacy;
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}