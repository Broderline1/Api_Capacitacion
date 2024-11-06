using API_Capacitacion.DTO.Task;
using API_Capacitacion.Model;

namespace API_Capacitacion.Data.Interfaces
{
    public interface ITaskServices
    {
        public Task<TaskModel> Create(CreateTaskDTO createTareaDTO);

        public Task<TaskModel> Update(int idtask, UpdateTaskDTO updateTaskDto);

        public Task<TaskModel> FindOne(int taskId);

        public Task<IEnumerable<TaskModel>> FindAll(int userId);

        public Task<TaskModel> Remove(int taskId);

        public Task<TaskModel?> ToggleStatus(int taskId);
    }
}