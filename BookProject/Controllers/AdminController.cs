using BookProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookProject.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult WebManagerment()
        {
            string jsonStr = HttpContext.Session.GetString("user");
            User u;
            if (jsonStr is null) u = new User();
            else u = JsonConvert.DeserializeObject<User>(jsonStr);
            if(u.Status == 4)
            {
                ViewBag.UserId = u.UserId;
                ViewBag.UserName = u.UserName;
                ViewBag.UserAvatar = u.Avatar;
                ViewBag.Status = u.Status;
                string active = HttpContext.Session.GetString("active");
                ViewBag.LeftActive = active;
                return View();
            }
            else
            {
                return View("/views/home/index.cshtml");
            }
        }
    }
}
