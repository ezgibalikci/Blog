using EzgiBlog.Data.DTO;
using EzgiBlog.Data.Models.EntityFramework;
using EzgiBlog.Service.Singles;
using EzgiBlog.Services.Comments;
using EzgiBlog.Services.Posts;
using EzgiBlog.Services.Users;
using EzgiBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EzgiBlog.ViewModels;
using Autofac;

namespace EzgiBlog.Controllers
{
    public class HomeController : Controller
    {
        private IPostService _postService;
        private IUserService _userService;
        private ICommentService _commentService;
        private ISingleService _singleService;

        public HomeController(IPostService postService, ICommentService commentService, ISingleService singleService, IUserService userService)
        {
            _postService = postService;
            _commentService = commentService;
            _singleService = singleService;
            _userService = userService;
        }
        
        public ActionResult Index()
        {
            var data = _postService.GetLastPosts(8);
            var comments = _commentService.GetComments();

            var model = new IndexViewModel
            {
                Posts = data,
                Comment = comments
            };

            return View(model);

        }

        public ActionResult Search()
        {
            var keyword = Request.QueryString["search"];
            var data = _postService.SearchPosts(keyword);
            var comments = _commentService.SearchComment(keyword);
            var model = new IndexViewModel
            {
                Posts = data,
                Comment = comments
            };

            return View("Index", model);
        }

        public ActionResult About()
        {
            var model = _postService.GetPosts();
            return View(model);
        }

        public ActionResult Contact(CommentDTO model)
        {
            _commentService.Createcomment(model);
            return View(model);
        }
        public ActionResult Single()
        {
            int id = int.Parse((string) RouteData.Values["id"]);
            var model = _singleService.GetSingleById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Single(int id)
        {
            var single = _singleService.GetSingleById(id);
            return View(single);
        }
        public ActionResult Comment()
        {

            var model = _commentService.GetComments();
            return View(model);
        }

        [HttpPost]
        public ActionResult Comment(CommentDTO model)
        {
            _commentService.Createcomment(model);
            return RedirectToAction("Single");
        }

        public ActionResult Giris(string msg)
        {
            var loginModel = new LoginModel();
            loginModel.Msg = msg;
            loginModel.User = new UserDTO();
            return View(loginModel);
        }

        public ActionResult RecentPost()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserDTO model)
        {
            _userService.Createuser(model);
            return RedirectToAction("SignUp");
        }

    }
}
