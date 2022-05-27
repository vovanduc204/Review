using MC.Data;
using MC.Service;
using MC.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MC.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IUserProfileService userProfileService;

        public UserController(IUserService userService, IUserProfileService userProfileService)
        {
            this.userService = userService;
            this.userProfileService = userProfileService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UserViewModel> model = new List<UserViewModel>();

            var userList = userService.GetUsers().ToList();

            userService.GetUsers().ToList().ForEach(u =>
            {
                UserProfile userProfile = userProfileService.GetUserProfile(u.Id);
                UserViewModel user = new UserViewModel
                {
                    Id = u.Id,
                    Name = $"{userProfile.FirstName} {userProfile.LastName}",
                    Email = u.Email,
                    Address = userProfile.Address
                };
                model.Add(user);
            });

            return View(model);
        }

        [HttpGet]
        public ActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();

            return PartialView("_AddUser", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState.Clear();
                User userEntity = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    Password = model.Password,
                    AddedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    UserProfile = new UserProfile
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Address = model.Address,
                        AddedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow,
                        IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
                    }
                };
                userService.InsertUser(userEntity);
                if (userEntity.Id > 0)
                {
                    return RedirectToAction("index");
                }
            }
            return PartialView("_AddUser", model);
        }

        [HttpGet]
        public ActionResult EditUser(int? id)
        {
            UserViewModel model = new UserViewModel();
            if (id.HasValue && id != 0)
            {
                User userEntity = userService.GetUser(id.Value);
                UserProfile userProfileEntity = userProfileService.GetUserProfile(id.Value);
                model.FirstName = userProfileEntity.FirstName;
                model.LastName = userProfileEntity.LastName;
                model.Address = userProfileEntity.Address;
                model.Email = userEntity.Email;
            }
            return PartialView("_EditUser", model);
        }

        [HttpPost]
        public ActionResult EditUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User userEntity = userService.GetUser(model.Id);
                userEntity.Email = model.Email;
                userEntity.ModifiedDate = DateTime.UtcNow;
                userEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                UserProfile userProfileEntity = userProfileService.GetUserProfile(model.Id);
                userProfileEntity.FirstName = model.FirstName;
                userProfileEntity.LastName = model.LastName;
                userProfileEntity.Address = model.Address;
                userProfileEntity.ModifiedDate = DateTime.UtcNow;
                userProfileEntity.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                userEntity.UserProfile = userProfileEntity;
                userService.UpdateUser(userEntity);
                if (userEntity.Id > 0)
                {
                    return RedirectToAction("index");
                }
            }
            return PartialView("_EditUser", model);
        }

        [HttpGet]
        public PartialViewResult DeleteUser(int id)
        {
            UserProfile userProfile = userProfileService.GetUserProfile(id);
            string name = $"{userProfile.FirstName} {userProfile.LastName}";
            return PartialView("_DeleteUser", name);
        }

        [HttpPost]
        public ActionResult DeleteUser(long id)
        {
            userService.DeleteUser(id);
            return RedirectToAction("Index");
        }
    }
}
