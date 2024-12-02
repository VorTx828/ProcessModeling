using Microsoft.AspNetCore.Mvc;

namespace Model.Controllers
{
    public class Out : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
