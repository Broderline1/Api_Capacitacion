using API_Capacitacion.Data.Interfaces;
using API_Capacitacion.DTO.User;
using API_Capacitacion.Model;
using Dapper;
using Npgsql;

namespace API_Capacitacion.Data.Services
{
    public class UserServices : IUserServices
    {
        private PostgresSQLConfiguration _postgresConfig {  get; set; }

        public UserServices(PostgresSQLConfiguration postgresConfig) => _postgresConfig = postgresConfig;

        public NpgsqlConnection CreateConnection() => new NpgsqlConnection(_postgresConfig.Connection);

        #region Create
        public Task<UserModel?> Create(CreateUserDTO createUserDTO)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region FindAll
        public async Task<IEnumerable<UserModel>> FindAll()
        {
            string sqlQuery = "select * from view_usuario;";

            using NpgsqlConnection database = CreateConnection();

            Dictionary<int, List<TaskModel>> userTasks = [];

            try
            {
                await database.OpenAsync();

                IEnumerable<UserModel> users = await database.QueryAsync<UserModel, TaskModel, UserModel>(
                    sql : sqlQuery,
                    map : (user, task) =>
                    {
                        List<TaskModel> currentTasks = userTasks[user.IdUsuario] ?? [];
                        currentTasks.Add(task);
                        userTasks[user.IdUsuario] = currentTasks; 

                        return user;
                    },
                    splitOn: "idTarea"
                );
                await database.CloseAsync();

                return users;
            }
            catch(Exception e)
            {
                return [];
            }
        }
        #endregion

        #region FindOne
        public Task<UserModel?> FindOne(int userId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Remove
        public Task<UserModel?> Remove(int userId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Update
        public Task<UserModel?> Update(UpdateUserDTO updateuserDto)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
