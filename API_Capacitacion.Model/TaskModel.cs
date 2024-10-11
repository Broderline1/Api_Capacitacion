using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Capacitacion.Model
{
    public class TaskModel
    {
        public int idTarea {  get; set; }

        public string Tarea { get; set; }

        public string Descripcion { get; set; }

        public bool Completada { get; set; }

        public UserModel Usuario { get; set; }
    }
}
