using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Data;
using System.Security.Claims;

namespace Model.Controllers
{
    public class AuthController : Controller
    {
        private readonly TeploobmenContext _context;
        //public TeploobmenContext(DbContextOptions<TeploobmenContext> options) : base(options) { }
        public AuthController(TeploobmenContext context)
        {
            _context=context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string login, string password)
        {
            var user=_context.Users.FirstOrDefault(x=>x.Login==login && x.Password == password);
            if (user!=null)
            {
                var claims = new List<Claim> {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, login) };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
