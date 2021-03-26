using System.Collections.Generic;
using AptekaManager.Internal.Dto;

namespace AptekaManager.Internal.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetProducts();
        
        ProductDto GetProductsById(int productId);

        ProductDto InsertProduct(ProductDto product);

        ProductDto DeleteProduct(ProductDto product);

        ProductDto UpdateProduct(ProductDto product);

        void Save();
    }
}