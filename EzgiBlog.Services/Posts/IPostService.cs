using System.Collections.Generic;
using EzgiBlog.Data.DTO;

namespace EzgiBlog.Services.Posts
{
    public interface IPostService
    {
        void Createpost(PostDTO dto);
        void UpdatePost(PostDTO dto);
        PostDTO GetPostById(int id);
        List<PostDTO> GetLastPosts(int count);
        List<PostDTO> GetPosts();
        List<PostDTO> SearchPosts(string keyword);
        void DeletePost(int id);


    }
}