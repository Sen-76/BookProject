using Microsoft.AspNetCore.Mvc;

namespace BookProject.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
