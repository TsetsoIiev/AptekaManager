using System.Collections.Generic;

namespace AptekaManager.Internal.Models
{
    public partial class MeasurementUnit
    {
        public MeasurementUnit()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
