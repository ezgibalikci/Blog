using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EzgiBlog.Data.Models.EntityFramework;
using System.Web.Mvc;
namespace EzgiBlog.Data.DTO
{
   
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }
}