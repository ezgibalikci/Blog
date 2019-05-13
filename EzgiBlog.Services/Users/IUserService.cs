using EzgiBlog.Data.DTO;
using System.Collections.Generic;

namespace EzgiBlog.Services.Users
{
    public interface IUserService
    {
        void Createuser(UserDTO dto);
      
        void UpdateUser(UserDTO dto);
        List<UserDTO> GetUsers();
        UserDTO GetUserById(int id);
        void DeleteUser(int id);

    }
}