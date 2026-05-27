using Microsoft.AspNetCore.Mvc;

namespace MiniBookstoreCatalogMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: /  hoặc  /Home/Index
        // Trang chủ giới thiệu hệ thống
        public IActionResult Index()
        {
            return View();
        }
    }
}
