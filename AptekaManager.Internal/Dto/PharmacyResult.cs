using AptekaManager.Internal.Models;
using AptekaManager.Internal.Constants;

namespace AptekaManager.Internal.Dto
{
    public class PharmacyResult
    {
        public PharmacyResult(PharmacyDto pharmacy, Product product)
        {
            PharmacyName = pharmacy.Name;
            PharmacyAddress = $"{pharmacy.AddressCity} {pharmacy.AddressStreetName} {pharmacy.AddressStreetNumber}";
            Price = product.Price;
            IsInStock = product.Quantity > IntConstants.ZERO;
        }

        public string PharmacyName { get; set; }

        public string PharmacyAddress { get; set; }

        public decimal Price { get; set; }

        public bool IsInStock { get; set; }
    }
}
