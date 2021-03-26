using System.Collections.Generic;
using AptekaManager.Internal.Models;

namespace AptekaManager.Internal.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public decimal Price { get; set; }
        
        public decimal Quantity { get; set; }
        
        public string Description { get; set; }
        
        public int MeasurementUnitsPerBox { get; set; }
        
        public bool IsSeparableSale { get; set; }

        public MeasurementUnit MeasurementUnit { get; set; }
    }
}