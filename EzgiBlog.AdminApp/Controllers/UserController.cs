using EzgiBlog.Data.DTO;
using EzgiBlog.Services.Users;
using EzgiBlog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzgiBlog.AdminApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult New()
        {
            return View(new UserDTO());
        }

        [HttpPost]
        public ActionResult New(UserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _userService.Createuser(model);
            return RedirectToAction("List");
        }

        public ActionResult Edit(int id)
        {
            var user = _userService.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(UserDTO model)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            _userService.UpdateUser(model);
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _userService.DeleteUser(id);
            return RedirectToAction("List");

        }

        public ActionResult List()
        {
            var model = _userService.GetUsers();
            return View("List", model);
        }
    }
}