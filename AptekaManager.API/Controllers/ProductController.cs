using AptekaManager.Internal.Dto;
using AptekaManager.Internal.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AptekaManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("[action]")]
        public IActionResult GetProducts()
        {
            return Ok(_productRepository.GetProducts());
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetProductById([FromRoute] int id)
        {
            var product = _productRepository.GetProductsById(id);
            return product is null
                ? NotFound()
                : Ok(product);
        }

        [HttpPost("[action]")]
        public IActionResult CreateProduct([FromBody]ProductDto product)
        {
            return CreatedAtAction("CreateProduct", _productRepository.InsertProduct(product));
        }

        [HttpPut("[action]")]
        public IActionResult UpdateProduct([FromBody]ProductDto product)
        {
            return CreatedAtAction("UpdateProduct", _productRepository.UpdateProduct(product));
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteProduct([FromBody]ProductDto product)
        {
            return Ok(_productRepository.DeleteProduct(product));
        }
    }
}