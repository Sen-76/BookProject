using BookProject.Logics;
using BookProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookProject.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            string jsonStr = HttpContext.Session.GetString("user");
            User u;
            if(jsonStr != null){
                if (jsonStr is null) u = new User();
                else u = JsonConvert.DeserializeObject<User>(jsonStr);
                ViewBag.UserId = u.UserId;
                ViewBag.UserName = u.UserName;
                ViewBag.UserAvatar = u.Avatar;
                ViewBag.User = u;
                string active = HttpContext.Session.GetString("active");
                ViewBag.LeftActive = active;
                return View();
            }
            else
            {
                return View("/views/home/index.cshtml");
            }
        }
        public IActionResult UpdateProfile(User NewUser)
        {
            string jsonStr = HttpContext.Session.GetString("user");
            User u;
            if (jsonStr is null) u = new User();
            else u = JsonConvert.DeserializeObject<User>(jsonStr);
            UserManager user = new UserManager();
            NewUser.Account = u.Account;
            NewUser.Password = u.Password;
            ViewBag.UserId = NewUser.UserId;
            ViewBag.UserName = NewUser.UserName;
            ViewBag.UserAvatar = NewUser.Avatar;
            user.UpdateAccount(NewUser);
            HttpContext.Session.Remove("user");
            jsonStr = JsonConvert.SerializeObject(NewUser);
            HttpContext.Session.SetString("user", jsonStr);
            return View("/Views/User/Profile.cshtml", ViewBag.User = NewUser);
        }
        public IActionResult ChangePass(int UserId, string OldPass, string NewPass, string ReNewPass)
        {
            UserManager user = new UserManager();
            User uu = user.Profile(UserId);
            string jsonStr = HttpContext.Session.GetString("user");
            User u;
            if (jsonStr is null) u = new User();
            else u = JsonConvert.DeserializeObject<User>(jsonStr);
            ViewBag.UserId = u.UserId;
            ViewBag.UserName = u.UserName;
            ViewBag.UserAvatar = u.Avatar;
            ViewBag.User = u;
            ViewBag.OldPass = OldPass;
            ViewBag.NewPass = NewPass;
            ViewBag.ReNewPass = ReNewPass;
            if (!uu.Password.Equals(OldPass))
            {
                ViewBag.Message = "Mật khẩu cũ không chính xác, vui lòng nhập lại.";
                ViewBag.Theme = "Warning";
                ViewBag.Title = "Change password thất bại";
                return View("/views/home/index.cshtml");
            }
            if (!NewPass.Equals(ReNewPass))
            {
                ViewBag.Message = "Mật khẩu mới không giống nhau, vui lòng nhập lại.";
                ViewBag.Theme = "Warning";
                ViewBag.Title = "Change password thất bại";
                return View("/views/home/index.cshtml");
                //return View("/Views/User/Profile.cshtml");
            }
            user.ChangePass(uu.Email, NewPass);
            ViewBag.Message = "OK.";
            ViewBag.Theme = "Warning";
            ViewBag.Title = "Change password thất bại";
            return View("/views/home/index.cshtml");
        }
    }
}
