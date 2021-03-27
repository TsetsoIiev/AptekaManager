using System.Collections.Generic;
using AptekaManager.Internal.Models;

namespace AptekaManager.Internal.Dto
{
    public class PharmacyDto
    {
        public PharmacyDto()
        {
            Products = new List<Product>();
        }

        public string Name { get; set; }

        public string AddressCity { get; set; }

        public string AddressStreetName { get; set; }

        public int AddressStreetNumber { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}