namespace API_Capacitacion.Model
{
    public class TaskModel
    {
        public int idTarea {  get; set; }

        public string Tarea { get; set; }

        public string Descripcion { get; set; }

        public bool Completada { get; set; }

        public UserModel Usuarioos { get; set; }
    }
}