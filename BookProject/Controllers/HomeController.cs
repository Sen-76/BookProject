using BookProject.Logics;
using BookProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace BookProject.Controllers
{
    public class HomeController : Controller
    {
        public string randomNum()
        {
            Random rnd = new Random();
            string rs = "";
            for (int i = 0; i < 6; i++)
            {
                int card = rnd.Next(10);
                rs += card;
            }
            return rs;
        }

        public static string RandomString(int length)
        {
            Random rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());
        }
        public void Send_Email(string SendTo, string Subject, string Body)
        {
            string to = SendTo; //To address    
            string from = "ducnmhe150901@fpt.edu.vn"; //From address    
            MailMessage message = new MailMessage(from, to);

            message.Subject = Subject;
            message.Body = Body;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("ducnmhe150901@fpt.edu.vn", "sechan76");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
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
            string Subject = "Đăng kí tài khoản thành công";
            string Body = "Bạn vừa đăng kí tài khoản thành công tại web của đức đấy";
            Send_Email(Email, Subject, Body);
            ViewBag.Message = "Hãy đăng nhập tài khoản của bạn.";
            ViewBag.Theme = "Success";
            ViewBag.Title = "Regis thành công";
            return View("/Views/Home/Login.cshtml");
        }
    }
}
