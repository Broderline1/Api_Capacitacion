using API_Capacitacion.Data.Interfaces;
using API_Capacitacion.DTO.User;
using API_Capacitacion.Model;
using Dapper;
using Npgsql;

namespace API_Capacitacion.Data.Services
{
    public class UserServices : IUserServices
    {
        private PostgresSQLConfiguration _postgresConfig;

        public UserServices(PostgresSQLConfiguration postgresConfig) => _postgresConfig = postgresConfig;

        public NpgsqlConnection CreateConnection() => new NpgsqlConnection(_postgresConfig.Connection);

        #region Create
        public async Task<UserModel?> Create(CreateUserDTO createUserDto)
        {
            using NpgsqlConnection database = CreateConnection();
            string sqlQuery = "Select * From fun_user_create(" +
                "p_nombre := @nombre," +
                "p_usuario := @usuario," +
                "p_contrasena := @contrasena);";
            try
            {
                await database.OpenAsync();
                IEnumerable<UserModel?> result = await database.QueryAsync<UserModel>(
                        sqlQuery,
                        param: new
                        {
                            nombre = createUserDto.names,
                            usuario = createUserDto.users,
                            contrasena = createUserDto.password
                        }
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

        #region FindAll
        //tipos genericos <>
        public async Task<IEnumerable<UserModel>> FindAll()
        {
            string sqlQuery = "Select * From view_usuario";

            using NpgsqlConnection database = CreateConnection();

            Dictionary<int, List<TaskModel>> userTasks = [];

            try
            {
                await database.OpenAsync();

                IEnumerable<UserModel> result = await database.QueryAsync<UserModel, TaskModel, UserModel>(
                    sql: sqlQuery,
                    map: (user, task) => {
                        List<TaskModel> currentTasks = [];

                        userTasks.TryGetValue(user.IdUsuario, out currentTasks);

                        currentTasks ??= [];

                        if (currentTasks.Count == 0 && task != null)
                        {
                            currentTasks = [task];
                        }
                        else if (currentTasks.Count > 0 && task != null)
                        {
                            currentTasks.Add(task);
                        }

                        userTasks[user.IdUsuario] = currentTasks;
                        return user;
                    },
                    splitOn: "idTarea"
                    );
                await database.CloseAsync();

                IEnumerable<UserModel> users = result.Distinct().Select(user => {
                    user.tasks = userTasks[user.IdUsuario];
                    return user;
                });
                return users;
            }
            catch (Exception ex)
            {
                //[] esto representa una lista
                return [];
            }
        }
        #endregion

        #region FindOne
        public async Task<UserModel?> FindOne(int userId)
        {
            NpgsqlConnection database = CreateConnection();
            string sqlQuery = "Select * from usuario where idUsuario = @idusuario";

            try
            {
                await database.OpenAsync();
                UserModel? result = await database.QueryFirstOrDefaultAsync<UserModel>(
                    sqlQuery,
                    param: new
                    {
                        IdUsuario = userId
                    }
                    );
                await database.CloseAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Remove
        public async Task<UserModel?> Remove(int userId)
        {
            NpgsqlConnection database = CreateConnection();
            string sqlQuery = "select * from fun_user_remove(" +
                "p_idUsuario := @IdUsuario)";
            try
            {
                await database.OpenAsync();
                UserModel? result = await database.QueryFirstOrDefaultAsync<UserModel>(
                    sqlQuery,
                    param: new
                    {
                        idUsuario = userId
                    });
                await database.CloseAsync();
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Update
        public async Task<UserModel?> Update(int iduser, UpdateUserDTO updateUserDto)
        {
            NpgsqlConnection database = CreateConnection();
            string sqlQuery = "Select * from fun_user_update(" +
                "p_idUsuario := @idusuario," +
                "p_nombre := @nombre," +
                "p_usuario := @usuario," +
                "p_contrasena := @contrasena);";

            try
            {
                await database.OpenAsync();
                var result = await database.QueryAsync<UserModel>(
                    sqlQuery,
                    param: new
                    {
                        idusuario = iduser,
                        nombre = updateUserDto.Names,
                        usuario = updateUserDto.Users,
                        contrasena = updateUserDto.Passwd
                    }
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