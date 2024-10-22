using API_Capacitacion.Data.Interfaces;
using API_Capacitacion.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Capacitacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserServices _services;

        public UserController(IUserServices services) => _services = services;

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            IEnumerable<UserModel> users = await _services.FindAll();
            return Ok(users);
        }

     /*
        200 Ok
        201 Creted
        400 Bad request
        404 Not Found
        403 Forbidden
        401 Unauthorized
        500 Interal Server Error
        418 I'm a teapot
     */

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
