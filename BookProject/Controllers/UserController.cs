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
            if (jsonStr is null) u = new User();
            else u = JsonConvert.DeserializeObject<User>(jsonStr);
            ViewBag.UserId = u.UserId;
            ViewBag.UserName = u.UserName;
            ViewBag.UserAvatar = u.Avatar;
            ViewBag.User = u;
            return View();
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
            user.UpdateAccount(NewUser);
            HttpContext.Session.Remove("user");
            jsonStr = JsonConvert.SerializeObject(NewUser);
            HttpContext.Session.SetString("user", jsonStr);
            return RedirectToAction("Profile");
        }
    }
}
