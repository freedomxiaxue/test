using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebMatrix.WebData;
using tcpjw3.oa.Filters;
using tcpjw3.oa.Models;

namespace tcpjw3.oa.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (!string.IsNullOrEmpty(WebSecurity.CurrentUserName))
                return RedirectToAction("Roles", "Account");
            else
                return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public JsonResult Login(LoginModel model, string returnUrl)
        {

            //var person = new { Name:"1" }
            if (ModelState.IsValid)
            {

                if (WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe.Value))
                {
                    return Json(new { success = true, message = "登录成功" });
                    //return Redirect(returnUrl ?? "/");
                }
                ModelState.AddModelError("", "The user name or password provided is incorrect.");
            }

            // If we got this far, something failed, redisplay form
            return Json(new { success = false, message = "您的密码输入不正确。" }); //View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
                    WebSecurity.Login(model.UserName, model.Password);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                bool changePasswordSucceeded;
                try
                {
                    changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }
                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        public ActionResult Roles()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion

        #region GridViewRole操作
        tcpjw3.oa.Models.UsersContext db = new tcpjw3.oa.Models.UsersContext();

        [ValidateInput(false)]
        public ActionResult RoleGridViewRole()
        {
            var model = db.webpages_Roles;
            return PartialView("_RoleGridViewRole", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult RoleGridViewRoleAddNew([Bind(Include = "RoleName")]tcpjw3.oa.Models.webpages_Roles item)
        {
            var model = db.webpages_Roles;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_RoleGridViewRole", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RoleGridViewRoleUpdate(tcpjw3.oa.Models.webpages_Roles item)
        {
            var model = db.webpages_Roles;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.RoleId == item.RoleId);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_RoleGridViewRole", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult RoleGridViewRoleDelete(System.Int32 RoleId)
        {
            var model = db.webpages_Roles;
            if (RoleId >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.RoleId == RoleId);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_RoleGridViewRole", model.ToList());
        }
        #endregion

        #region GridViewUserInRole操作

        [ValidateInput(false)]
        public ActionResult RoleGridViewUserInRole(int? roleId)
        {
            //var model = db1.webpages_UsersInRoles.Where(e => e.RoleId == roleId);
            var model = from u in db.UserProfiles
                        join ur in db.webpages_UsersInRoles on u.UserId equals ur.UserId
                        join r in db.webpages_Roles on ur.RoleId equals r.RoleId
                        where r.RoleId == roleId
                        select new
                        {
                            UserId = u.UserId,
                            RoleId = r.RoleId,
                            UserName = u.UserName,
                            RoleName = r.RoleName
                        };

            return PartialView("_RoleGridViewUserInRole", model.ToList());
        }

        #endregion

        public ActionResult RoleListBoxSelectedUsers()
        {
            var model = from u in db.UserProfiles
                        from r in db.webpages_UsersInRoles
                        where u.UserId != r.UserId
                        select u;
            return PartialView("_RoleListBoxSelectedUsers", db.UserProfiles.ToList());
        }

        [HttpPost]
        public JsonResult AddUsersToRole(int[] itemValue, int roleId)
        {
            var model = db.webpages_UsersInRoles;
            string sql = string.Format("DELETE FROM [webpages_UsersInRoles] WHERE RoleId={0};", roleId);
            if (itemValue != null)
                foreach (int id in itemValue)
                    sql += string.Format("INSERT INTO [webpages_UsersInRoles] Values({0},{1});", id, roleId);
            db.Database.ExecuteSqlCommand(sql);
            return Json(new { success = true, message = "更新唱功。" }); //View(model);
        }
    }
}