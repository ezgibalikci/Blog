using EzgiBlog.Data.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EzgiBlog.Data.DTO
{
    public class UserDTO
    {
      
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Adress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        
        public String Phone { get; set; }

        public string Password { get; set; }
        public Nullable<int> PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual Comment Comment { get; set; }
        public Nullable<int> CommentId { get; set; }

        
    }
}