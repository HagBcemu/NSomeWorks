using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private static readonly Product[] Products = new Product[]
    {
        new Product {Id = 1, Name = "Product11", Price = 457 , CountInStock = 345},
        new Product {Id = 2, Name = "Product10", Price = 455 , CountInStock = 245},
        new Product {Id = 3, Name = "Product9", Price = 645 , CountInStock = 145},
        new Product {Id = 4, Name = "Product8", Price = 455 , CountInStock = 45},
        new Product {Id = 5, Name = "Product7", Price = 445 , CountInStock = 5},
        new Product {Id = 6, Name = "Product6", Price = 345 , CountInStock = 5},
    };

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Products;
        }
    }
}
