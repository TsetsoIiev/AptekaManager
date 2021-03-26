using System.Collections.Generic;
using System.Linq;
using AptekaManager.Internal.Dto;
using AptekaManager.Internal.Interfaces;
using AptekaManager.Internal.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AptekaManager.Internal.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private readonly AptekaManagerContext _context;

        public ProductRepository(IMapper mapper, AptekaManagerContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            return _context.Products.Select(x => _mapper.Map<ProductDto>(x));
        }

        public ProductDto GetProductsById(int productId)
        {
            var address = _context.Products.FirstOrDefault(x => x.Id == productId);
            return _mapper.Map<ProductDto>(address);
        }

        public ProductDto InsertProduct(ProductDto product)
        {
            var newProduct = _mapper.Map<Product>(product);
            _context.Products.Add(newProduct);
            return product;
        }

        public ProductDto DeleteProduct(ProductDto product)
        {
            var productToDelete = _mapper.Map<Product>(product);
            _context.Products.Remove(productToDelete);
            return product;
        }

        public ProductDto UpdateProduct(ProductDto product)
        {
            var productToUpdate = _mapper.Map<Product>(product);
            _context.Entry(productToUpdate).State = EntityState.Modified;
            return product;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}