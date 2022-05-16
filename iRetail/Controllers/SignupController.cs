using iRetail.Models;
using iRetail.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace iRetail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly SignupRepository signupRepository;

        public SignupController()
        {
            signupRepository = new SignupRepository();
        }

        // GET: api/<SignupController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return signupRepository.GetAllUser();
        }

        // GET api/<SignupController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<SignupController>
        [HttpPost]
        public IActionResult Post(User userinfo)
        {
            if (signupRepository.RegisterUser(userinfo))
            {
                return Ok("User Created");
            }
            return BadRequest("User Already Exist");
        }

        // PUT api/<SignupController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<SignupController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
