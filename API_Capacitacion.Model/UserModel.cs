namespace API_Capacitacion.Model
{
    public class UserModel
    {
        public int IdUsuario { get; set; }

        public string nombre { get; set; }

        public string usuario { get; set; }

        public string contrasena { get; set; }

        public List<TaskModel> tasks { get; set; } = [];
    }
}
