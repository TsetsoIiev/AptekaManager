using System.Collections.Generic;

namespace AptekaManager.Internal.Models
{
    public partial class Address
    {
        public Address()
        {
            Pharmacies = new HashSet<Pharmacy>();
        }

        public int Id { get; set; }
        
        public string City { get; set; }
        
        public string StreetName { get; set; }
        
        public int DoorNumber { get; set; }

        public virtual ICollection<Pharmacy> Pharmacies { get; set; }
    }
}
