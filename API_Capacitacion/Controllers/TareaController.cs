using API_Capacitacion.Data.Interfaces;
using API_Capacitacion.DTO.Task;
using API_Capacitacion.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

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
        public async Task<IActionResult> FindAll([FromQuery] int userId)
        {
            IEnumerable<TaskModel> tasks = await _services.FindAll(userId);
            if(tasks.Count() == 0)
            {
                return NotFound();
            }

            return Ok(tasks);
        }

        // GET api/<TareaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> FindOne(int id)
        {
            TaskModel? task = await _services.FindOne(id);
            if (task == null)
                return NotFound();

            return Ok(task);
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
        public async Task<IActionResult> Remove(int taskId)
        {
            TaskModel? task = await _services.Remove(taskId);
            if (task == null) 
                return NotFound();

            return Ok(task);
        }

        [HttpPut("Togglestatus/{taskId}")]
        public async Task<IActionResult> Togglestatus(int taskId)
        {
            TaskModel? Tasks = await _services.ToggleStatus(taskId);
            if (Tasks == null)
            {
                return NotFound();
            }
            return Ok(Tasks);

        }
    }
}