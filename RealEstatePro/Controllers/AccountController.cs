using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using RealEstatePro.Identity;
using RealEstatePro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealEstatePro.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

      public ActionResult UpdatePassword()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult UpdatePassword(UpdatePassword model)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.ChangePassword(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
                return View("Update");
            }
            return View(model);
        }


        //Get 
        public ActionResult Profile()
        {
            var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
            var user = UserManager.FindById(id);
            var data = new EditProfile()
            {
            id = user.Id,
            Name=user.Name,
            Surname=user.Surname,
            Username=user.UserName,
            Email=user.Email,
            };
            return View(data);
        }
        [HttpPost]
        public ActionResult Profile( EditProfile model)
        {
            var user = UserManager.FindById(model.id);
            user.Name = model.Name;
            user.UserName = model.Username;
            user.Surname = model.Surname;
            user.Email = model.Email;
            UserManager.Update(user);
            return View("Update");

        }

        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);


        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model , string ReturnURl)
        {
            if (ModelState.IsValid)
            {
                var user = UserManager.Find(model.Username, model.Password);
                if(user!= null) 
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    // Session Close or Not Rememeber me 
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties,identityclaims);
                    // Authentication of pages
                    if(!String.IsNullOrEmpty(ReturnURl))
                    {
                        return Redirect(ReturnURl);
                    }
                    //after Login 
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı bulamadı");
                    return RedirectToAction("Login", "Account");

                }

            }
            return View(model);
        }

        public ActionResult LogOut()
        {
            
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index" ,"Home");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.UserName = model.Username;
                user.Surname = model.Surname;
                user.Email = model.Email;
                var result = UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {

                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");   
                }else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıccı oluşturma hatası");
                }
            }
            return View(model);
        }


        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}