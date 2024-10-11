using API_Capacitacion.Data.Interfaces;
using API_Capacitacion.DTO.Task;
using API_Capacitacion.Model;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        tarea.Usuario = usuario;

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
    }
}
