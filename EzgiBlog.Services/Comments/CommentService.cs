using EzgiBlog.Data.DTO;
using EzgiBlog.Data.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EzgiBlog.Services.Comments
{
    public class CommentService : ICommentService
    {
        private EzgiBlogDbEntities _db;

        public CommentService(EzgiBlogDbEntities db)
        {
            _db = db;
        }
        public List<CommentDTO> GetComments()
        {
            var comment = _db.Comments.Select(c => new CommentDTO
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                Message = c.Message
            }).ToList();
            return comment;
        }

        public List<CommentDTO> GetLastComments(int count)
        {
            var comment = _db.Comments.OrderByDescending(c => c.Id).Take(count).Select(c => new CommentDTO
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                Message = c.Message
            }).ToList();
            return comment;
        }

        public List<CommentDTO> SearchComment(string keyword)
        {
            var comment = _db.Comments.Where(c => c.Message.Contains(keyword) || c.Name.Contains(keyword)).Select(c => new CommentDTO
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Phone = c.Phone,
                Message = c.Message
            }).ToList();
            return comment;
        }
        public void Createcomment(CommentDTO dto)
        {
            _db.Comments.Add(new Comment
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Message = dto.Message
            });

            _db.SaveChanges();
        }
    }
}

