using EzgiBlog.Data.DTO;
using EzgiBlog.Data.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EzgiBlog.Services.Users
{

    public class UserService : IUserService
    {
        private EzgiBlogDbEntities _db;
        public UserService(EzgiBlogDbEntities db)
        {
            _db = db;
        }

        public List<UserDTO> GetUsers()
        {
            var user = _db.Users.Select(u => new UserDTO
            {
                UserId = u.UserId,
                UserName = u.UserName,
                Adress = u.Adress,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Phone = u.Phone,
                PostId = u.PostId,
                Password = u.Password,
                CommentId = u.CommentId
            }).ToList();
            return user;
        }
        public void Createuser(UserDTO dto)
        {
            _db.Users.Add(new User
            {
                UserId = dto.UserId,
                UserName = dto.UserName,
                Adress = dto.Adress,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                PostId = dto.PostId,
                Password = dto.Password,
                CommentId = dto.CommentId
            });

            _db.SaveChanges();
        }


        public void UpdateUser(UserDTO dto)
        {
            var user = _db.Users.FirstOrDefault(x => x.UserId == dto.UserId);

            user.Adress = dto.Adress;
            user.Phone = dto.Phone;
            user.Password = dto.Password;
            
            _db.SaveChanges();
        }

        public UserDTO GetUserById(int id)
        {
            var user = _db.Users.FirstOrDefault(x => x.UserId == id);

            if (user == null) return new UserDTO();

            return new UserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Adress = user.Adress,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                PostId = user.PostId,
                Password = user.Password,
                CommentId = user.CommentId
            };
        }

        public void DeleteUser(int id)
        {
            var user = _db.Users.FirstOrDefault(x => x.UserId == id);
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

    }

}

