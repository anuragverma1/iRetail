using iRetail.Models;
using iRetail.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace iRetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartRepository cartRepository;

        public CartController()
        {
            cartRepository = new CartRepository();
        }

        // GET: api/<CartController>
        [HttpGet("getname/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok($"{cartRepository.GetProductName(id)}");
        }

        // GET api/<CartController>/5
        [HttpGet("{username}")]
        public IEnumerable<Cart> Get(string username)
        {
            return cartRepository.GetAllItems(username);
        }

        // POST api/<CartController>
        [HttpPost]
        public void Post(Cart item)
        {
            cartRepository.AddToCart(item);
        }

        // PUT api/<CartController>/5
        [HttpPut("update")]
        public void Put(Cart prod)
        {
            cartRepository.UpdateQuantity(prod);
        }

        // DELETE api/<CartController>/5
        [HttpDelete("delete")]
        public void Delete(Cart prod)
        {
            cartRepository.RemoveFromCart(prod);
        }
    }
}
