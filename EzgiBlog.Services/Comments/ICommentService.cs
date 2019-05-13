using EzgiBlog.Data.DTO;
using System.Collections.Generic;

namespace EzgiBlog.Services.Comments
{
    public interface ICommentService
    {
        void Createcomment(CommentDTO dto);
        List<CommentDTO> GetLastComments(int count);
        List<CommentDTO> GetComments();
        List<CommentDTO> SearchComment(string keyword);
      
    }
}