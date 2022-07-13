using BookProject.Logics;
using BookProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace BookProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string jsonStr = HttpContext.Session.GetString("user");
            User u;
            if (jsonStr is null) u = new User();
            else u = JsonConvert.DeserializeObject<User>(jsonStr);
            ViewBag.UserId = u.UserId;
            ViewBag.UserName = u.UserName;
            ViewBag.UserAvatar = u.Avatar;

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult DoLogin(string Account, string Password)
        {
            UserManager user = new UserManager();
            User u = user.Loged(Account, Password);
            if (u == null)
            {
                ViewBag.Message = "Sai tài khoản hoặc mật khẩu.";
                ViewBag.Theme = "Warning";
                ViewBag.Title = "Login thất bại";
                ViewBag.Account = Account;
                ViewBag.Password = Password;
                return View("/Views/Home/Login.cshtml");
            }
            else
            {
                string jsonStr = JsonConvert.SerializeObject(u);
                HttpContext.Session.SetString("user", jsonStr);
                ViewBag.Message = "Xin chào "+ u.UserName + ".";
                ViewBag.Theme = "Success";
                ViewBag.Title = "Login thành công";
                return RedirectToAction("Index");
                //return View("/views/home/index.cshtml");
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return View("/views/home/index.cshtml");
        }

        public IActionResult Register(string Account, string Password, string RePassword, string Email)
        {
            UserManager user = new UserManager();
            List<User> luser = user.ExistAccount();
            if (!Password.Equals(RePassword))
            {
                ViewBag.Message = "Mật khẩu không trùng nhau.";
                ViewBag.Theme = "Warning";
                ViewBag.Title = "Regis thất bại";
                ViewBag.Accounts = Account;
                ViewBag.Passwords = Password;
                ViewBag.RePassword = RePassword;
                ViewBag.Email = Email;
                ViewBag.Active = "active";
                return View("/Views/Home/Login.cshtml");
            }

            if (Account == null || Password == null || Account == "" || Password == "" || RePassword == "" || RePassword == null || Email == null || Email == "")
            {
                ViewBag.Message = "Bạn phải nhập đầy đủ các trường.";
                ViewBag.Theme = "Warning";
                ViewBag.Title = "Regis thất bại";
                ViewBag.Accounts = Account;
                ViewBag.Passwords = Password;
                ViewBag.RePassword = RePassword;
                ViewBag.Email = Email;
                ViewBag.Active = "active";
                return View("/Views/Home/Login.cshtml");
            }
            foreach (User u in luser)
            {
                if (u.Account.Equals(Account))
                {
                    ViewBag.Message = "Tài khoản đã tồn tại.";
                    ViewBag.Theme = "Warning";
                    ViewBag.Title = "Regis thất bại";
                    ViewBag.Accounts = Account;
                    ViewBag.Passwords = Password;
                    ViewBag.RePassword = RePassword;
                    ViewBag.Email = Email;
                    ViewBag.Active = "active";
                    return View("/Views/Home/Login.cshtml");
                }
                if (u.Email.Equals(Email))
                {
                    ViewBag.Message = "Email đã có người sử dụng.";
                    ViewBag.Theme = "Warning";
                    ViewBag.Title = "Regis thất bại";
                    ViewBag.Accounts = Account;
                    ViewBag.Passwords = Password;
                    ViewBag.RePassword = RePassword;
                    ViewBag.Email = Email;
                    ViewBag.Active = "active";
                    return View("/Views/Home/Login.cshtml");
                }
            }
            user.AddAccount(Account, Password, RePassword, Email);
            ViewBag.Message = "Hãy đăng nhập tài khoản của bạn.";
            ViewBag.Theme = "Success";
            ViewBag.Title = "Regis thành công";
            return View("/Views/Home/Login.cshtml");
        }
    }
}
