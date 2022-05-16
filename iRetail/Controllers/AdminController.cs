using iRetail.Model;
using iRetail.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace iRetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminRepository adminRepository;
        private readonly ProductRepository productRepository;

        public AdminController()
        {
            adminRepository = new AdminRepository();
            productRepository = new ProductRepository();
        }

        // GET: api/<AdminController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetAll();
        }

        // GET api/<AdminController>/5
        [HttpGet("{category}")]
        public IEnumerable<Product> Get(string category)
        {
            return productRepository.GetByCategory(category);
        }

        // POST api/<AdminController>
        [HttpPost("add")]
        public void Post(Product prod)
        {
            adminRepository.AddProduct(prod);
        }

        // PUT api/<AdminController>/5
        [HttpPut("update")]
        public void Put(Product prod)
        {
            adminRepository.UpdateQuantity(prod);
        }

        // DELETE api/<AdminController>/5
        [HttpDelete("delete")]
        public void Delete(Product prod)
        {
            adminRepository.RemoveProduct(prod);
        }
    }
}
