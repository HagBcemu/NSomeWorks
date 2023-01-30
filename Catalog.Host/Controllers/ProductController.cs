using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private static readonly Product[] Products = new Product[]
        {
            new Product {Id = 1, Name = "Product10", Prise = 524, CountInStock = 241},
            new Product {Id = 2, Name = "Product9", Prise = 542, CountInStock = 241},
            new Product {Id = 3, Name = "Product8", Prise = 524, CountInStock = 141},
            new Product {Id = 4, Name = "Product7", Prise = 524, CountInStock = 141},
            new Product {Id = 5, Name = "Product6", Prise = 524, CountInStock = 421},
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
