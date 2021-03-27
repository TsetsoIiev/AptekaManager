using System.Collections.Generic;

namespace AptekaManager.Internal.Models
{
    public partial class Pharmacy
    {
        public Pharmacy()
        {
            PharmacyProducts = new HashSet<PharmacyProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        
        public virtual ICollection<PharmacyProduct> PharmacyProducts { get; set; }
    }
}
