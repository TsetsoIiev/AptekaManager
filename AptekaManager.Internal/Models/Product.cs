using System.Collections.Generic;

namespace AptekaManager.Internal.Models
{
    public partial class Product
    {
        public Product()
        {
            PharmacyProducts = new HashSet<PharmacyProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }
        public int MeasurementUnitsPerBox { get; set; }
        public int MeasurementUnitId { get; set; }
        public bool IsSeparableSale { get; set; }

        public virtual MeasurementUnit MeasurementUnit { get; set; }
        public virtual ICollection<PharmacyProduct> PharmacyProducts { get; set; }
    }
}
