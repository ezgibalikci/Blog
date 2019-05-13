using EzgiBlog.Data.DTO;
using EzgiBlog.Services.Comments;
using EzgiBlog.Services.Posts;
using EzgiBlog.Services.Users;
using EzgiBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzgiBlog.AdminApp.Controllers
{
    public class HomeController : Controller
    {
        private IPostService _postService;
        private IUserService _userService;
        private ICommentService _commentService;
        public HomeController(IPostService postService, IUserService userService, ICommentService commentService)
        {
            _postService = postService;
            _userService = userService;
            _commentService = commentService;
        }
        public ActionResult Index()
        {
            var data = _postService.GetPosts();
            var comment = _commentService.GetComments();
            var model = new IndexViewModel
            {
                Posts = data,
                Comment = comment
            };

            return View("Index", model);
        }

        [HttpPost]
        public ActionResult Index(PostDTO model, CommentDTO modell)
        {
            _postService.Createpost(model);
            _commentService.Createcomment(modell);
            return RedirectToAction("Index");
        }

        public ActionResult New()
        {

            return View(new PostDTO());
        }

   
        [HttpPost]
        public ActionResult New(PostDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _postService.Createpost(model);
            return RedirectToAction("Index");
        }
        public ActionResult Icons(int id)
        {
            var post = _postService.GetPostById(id);
            return View(post);
        }

        [HttpPost]
        public ActionResult Icons(PostDTO model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            _postService.UpdatePost(model);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _postService.DeletePost(id);
            return RedirectToAction("Index");

        }
        public ActionResult Notifications()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(UserDTO Model)
        {

            var users = _userService.GetUsers();
            var user = users.FirstOrDefault(x => x.UserName == Model.UserName && x.Password == Model.Password);
            if (user != null)
            {
                Session["UserName"] = user;
                return RedirectToAction("Index");
            }
           var msg = "Kullanıcı adı veya şifre yanlış";
            return Redirect(string.Format("http://localhost:53908/Home/Giris?msg={0}",msg));
        }


    }
}