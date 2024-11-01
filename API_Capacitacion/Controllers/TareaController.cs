using API_Capacitacion.Data.Interfaces;
using API_Capacitacion.DTO.Task;
using API_Capacitacion.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Capacitacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        ITaskServices _services;

        public TareaController(ITaskServices service) => _services = service;

        // GET: api/<TareaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TareaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TareaController>
        [HttpPost]
        public async Task<IActionResult> Create ([FromBody] CreateTaskDTO createTaskDTO)
        {
            TaskModel? task = await _services.Create(createTaskDTO);

            if(task == null) return NotFound();

            return Ok(task);
        }

        // PUT api/<TareaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int idtask, [FromBody] UpdateTaskDTO updateTaskDto)
        {
            TaskModel? task = await _services.Update(idtask, updateTaskDto);
            if(task == null) 
                return NotFound();

            return Ok(task);
        }

        // DELETE api/<TareaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}