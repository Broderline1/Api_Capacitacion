using API_Capacitacion.Data.Interfaces;
using API_Capacitacion.DTO.User;
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

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> FindOne(int id)
        {
            UserModel? user = await _services.FindOne(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDTO createUserDto)
        {
            UserModel? user = await _services.Create(createUserDto);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // DELETE api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int iduser, [FromBody] UpdateUserDTO updateUserDto)
        {
            UserModel? task = await _services.Update(iduser, updateUserDto);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int userId)
        {
            UserModel? user = await _services.Remove(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
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
    }
}
