using iRetail.Model;
using iRetail.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace iRetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository productRepository;

        public ProductController()
        {
            productRepository = new ProductRepository();
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{category}")]
        public IEnumerable<Product> Get(string category)
        {
            return productRepository.GetByCategory(category);
        }

        [HttpGet("categories")]
        public IEnumerable<string> GetCategories()
        {
            return productRepository.GetAllCategories();
        }

        // POST api/<ProductController>
        //[HttpPost]
        //public void Post(Product prod)
        //{
        //    productRepository.AddProduct(prod);
        //}

        // PUT api/<ProductController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ProductController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
