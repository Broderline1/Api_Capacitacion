using API_Capacitacion.DTO.User;
using API_Capacitacion.Model;

namespace API_Capacitacion.Data.Interfaces
{
    public interface IUserServices
    {
        public Task<UserModel?> Create(CreateUserDTO createUserDTO);

        public Task<IEnumerable<UserModel>> FindAll();

        public Task<UserModel?> FindOne( int userId);

        public Task<UserModel?> Update(UpdateUserDTO updateuserDto);

        public Task<UserModel?> Remove(int userId);
    }
}