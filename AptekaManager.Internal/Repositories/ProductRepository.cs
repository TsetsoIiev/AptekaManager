using System.Collections.Generic;
using System.Linq;
using AptekaManager.Internal.Dto;
using AptekaManager.Internal.Interfaces;
using AptekaManager.Internal.Models;
using Microsoft.EntityFrameworkCore;

namespace AptekaManager.Internal.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AptekaManagerContext _context;

        public ProductRepository(AptekaManagerContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            return _context.Products.Select(x => MapToDto(x));
        }

        public ProductDto GetProductsById(int productId)
        {
            var address = _context.Products.FirstOrDefault(x => x.Id == productId);
            return MapToDto(address);
        }

        public ProductDto InsertProduct(ProductDto product)
        {
            var newProduct = MapToDomain(product);
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return product;
        }

        public ProductDto DeleteProduct(ProductDto product)
        {
            var productToDelete = MapToDomain(product);
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            return product;
        }

        public ProductDto UpdateProduct(ProductDto product)
        {
            var productToUpdate = MapToDomain(product);
            _context.Entry(productToUpdate).State = EntityState.Modified;
            _context.SaveChanges();
            return product;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public static ProductDto MapToDto(Product product)
        {
            return new()
            {
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                Description = product.Description,
                MeasurementUnitsPerBox = product.MeasurementUnitsPerBox,
                MeasurementUnit = product.MeasurementUnit,
                IsSeparableSale = product.IsSeparableSale
            };
        }

        public static Product MapToDomain(ProductDto productDto)
        {
            return new()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Quantity = productDto.Quantity,
                Description = productDto.Description,
                MeasurementUnitsPerBox = productDto.MeasurementUnitsPerBox,
                MeasurementUnit = productDto.MeasurementUnit,
                IsSeparableSale = productDto.IsSeparableSale
            };
        }
    }
}