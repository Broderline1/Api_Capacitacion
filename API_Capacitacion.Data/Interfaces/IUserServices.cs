using API_Capacitacion.DTO.User;
using API_Capacitacion.Model;

namespace API_Capacitacion.Data.Interfaces
{
    public interface IUserServices
    {
        public Task<UserModel?> Create(CreateUserDTO createUserDto);

        public Task<IEnumerable<UserModel>> FindAll();

        public Task<UserModel?> FindOne( int userId);

        public Task<UserModel?> Update(int iduser, UpdateUserDTO updateUserDto);

        public Task<UserModel?> Remove(int userId);
    }
}