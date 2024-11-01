using API_Capacitacion.DTO.Task;
using API_Capacitacion.Model;

namespace API_Capacitacion.Data.Interfaces
{
    public interface ITaskServices
    {
        public Task<TaskModel> Create(CreateTaskDTO createTareaDTO);

        public Task<TaskModel> Update(int idtask, UpdateTaskDTO updateTaskDto);
    }
}