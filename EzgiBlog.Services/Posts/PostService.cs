using EzgiBlog.Data.DTO;
using EzgiBlog.Data.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EzgiBlog.Services.Posts
{
    public class PostService : IPostService
    {
        private EzgiBlogDbEntities _db;

        public PostService(EzgiBlogDbEntities db)
        {
            _db = db;

        }
        public List<PostDTO> GetPosts()
        {

            List<PostDTO> post = _db.Posts.Select(o => new PostDTO
            {
                Id = o.Id,
                Title = o.Title,
                Post1 = o.Post1
            }).ToList();
            return post;
        }

        public List<PostDTO> GetLastPosts(int count)
        {
            var post = _db.Posts.OrderByDescending(o=>o.Id).Take(count).Select(o => new PostDTO
            {
                Id = o.Id,
                Title = o.Title,
                Post1 = o.Post1
            }).ToList();
            return post;
        }

        public List<PostDTO> SearchPosts(string keyword)
        {
            var post = _db.Posts.Where(o=>o.Title.Contains(keyword) || o.Post1.Contains(keyword)).Select(o => new PostDTO
            {
                Id = o.Id,
                Title = o.Title,
                Post1 = o.Post1
            }).ToList();
            return post;
        }

        public void Createpost(PostDTO dto)
        {
            _db.Posts.Add(new Post
            {
                Id = dto.Id,
                Title =dto.Title,
                Post1 =dto.Post1
            });
            _db.SaveChanges();
        }
        public PostDTO GetPostById(int id)
        {
            var post = _db.Posts.FirstOrDefault(x => x.Id == id);
            if (post == null) return new PostDTO();
            return new PostDTO
            {
                Id=post.Id,
                Title=post.Title,
                Post1=post.Post1,
            };
        }
        public void UpdatePost(PostDTO dto)
        {
            var post = _db.Posts.FirstOrDefault(x => x.Id == dto.Id);

            post.Post1 = dto.Post1;
            post.Title = dto.Title;

            _db.SaveChanges();
        }
        public void DeletePost(int id)
        {
            var post = _db.Posts.FirstOrDefault(x => x.Id == id);
            _db.Posts.Remove(post);
            _db.SaveChanges();
        }

    }
}
