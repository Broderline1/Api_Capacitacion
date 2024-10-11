using API_Capacitacion.DTO.Task;
using API_Capacitacion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Capacitacion.Data.Interfaces
{
    public interface ITaskServices
    {
        public Task<TaskModel> Create(CreateTaskDTO createTareaDTO);
    }
}
