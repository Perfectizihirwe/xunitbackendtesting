using APITesting.Models;
using Microsoft.AspNetCore.Mvc;

namespace APITesting.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products { get; set; } = Enumerable.Range(1, 6).Select(p => new Product
        {
            Id = p,
            Name = $"iPhone {p}",
            Price = 200 * p,
        }).ToList();

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            Console.WriteLine(id);

            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return await Task.FromResult(Ok(product));
        }
    }
}
