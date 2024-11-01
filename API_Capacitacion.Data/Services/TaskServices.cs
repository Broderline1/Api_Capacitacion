using API_Capacitacion.Data.Interfaces;
using API_Capacitacion.DTO.Task;
using API_Capacitacion.Model;
using Dapper;
using Npgsql;

namespace API_Capacitacion.Data.Services
{
    public class TaskServices : ITaskServices
    {
        private PostgresSQLConfiguration _connection;

        public TaskServices(PostgresSQLConfiguration connection) => _connection = connection;

        private NpgsqlConnection CreateConnection() => new(_connection.Connection);

        #region Create
        public async Task<TaskModel> Create(CreateTaskDTO createTareaDTO)
        {
            using NpgsqlConnection database = CreateConnection();
            string sqlQuery = "select * from fun_task_create (" +
                "p_tarea := @task," +
                "p_descripcion := @descripcion," +
                "p_idUsuario := @userId" +
                ");";

            try
            {
                await database.OpenAsync();

                var result = await database.QueryAsync<TaskModel,
                UserModel, TaskModel>(
                    sqlQuery,
                    param: new
                    {
                        task = createTareaDTO.Tarea,
                        descripcion = createTareaDTO.Descripcion,
                        userId = createTareaDTO.IdUsuario
                    },
                    map: (tarea, usuario) =>
                    {
                        tarea.Usuarios = usuario;

                        return tarea;
                    },

                    splitOn: "UsuarioId"
                    );
                await database.CloseAsync();

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Update
        public async Task<TaskModel?> Update(int idtask, UpdateTaskDTO updateTaskDto)
        {
            NpgsqlConnection database = CreateConnection();
            string sqlQuery = "Select * from fun_task_update(" +
                "p_IdTarea := @IdTarea," +
                "p_tarea := @tarea," +
                "p_descripcion := @descripcion" +
                ");";

            try
            {
                await database.OpenAsync();

                var result = await database.QueryAsync<TaskModel>(
                    sqlQuery,
                    param: new
                    {
                        IdTarea = idtask,
                        tarea = updateTaskDto.Tarea,
                        descripcion = updateTaskDto.Descripcion
                    }
                    );
                await database.CloseAsync();
                return result.FirstOrDefault();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region FindAll

        #endregion

        #region Delete 

        #endregion
    }
}