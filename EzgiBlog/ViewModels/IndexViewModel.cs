using EzgiBlog.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EzgiBlog.ViewModels
{
    public class IndexViewModel
    {
            public List<PostDTO> Posts { get; set; }
            public List<CommentDTO> Comment { get; set; }
    }
}