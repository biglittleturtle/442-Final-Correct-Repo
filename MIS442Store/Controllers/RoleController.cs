using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MIS442Store.Models;
using MIS442Store.DataLayer.DataModels;
using MIS442Store.Controllers;
using MIS442_Store.Models;
using MIS442Store;

namespace CST465_MVC.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationRoleManager _RoleManager;
        private ApplicationUserManager _UserManager;

        protected ApplicationRoleManager RoleManager
        {
            get
            {
                if (_RoleManager == null)
                {
                    _RoleManager = HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
                }
                return _RoleManager;
            }

        }

        protected ApplicationUserManager UserManager
        {
            get
            {
                if (_UserManager == null)
                {
                    _UserManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                }
                return _UserManager;
            }
            private set
            {
                _UserManager = value;
            }
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult JoinRole(string RoleName)
        {

            UserManager.AddToRole(User.Identity.GetUserId(), RoleName);

            return RedirectToAction("Roles");


        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult JoinRole(string RoleName, string UserName)
        {

            UserManager.AddToRole(User.Identity.GetUserId(), RoleName);

            return RedirectToAction("Roles");


        }
        [HttpGet]
        [Authorize]
        public ActionResult Roles()
        {
            List<string> roleNames = RoleManager.Roles.Select(role => role.Name).ToList();
            return View(roleNames);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Roles(string RoleName)
        {
            var role = new ApplicationRole();
            role.Id = Guid.NewGuid().ToString();
            role.Name = RoleName;
            RoleManager.Create(role);

            return RedirectToAction("Roles");
        }
    }
}
