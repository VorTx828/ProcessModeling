using Microsoft.AspNetCore.Mvc;
using Model.Models;
using System.Diagnostics;
using Formulas;
using Model.Data;

namespace Model.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TeploobmenContext _context;


        private int? GetUserId()
        {
            var userIdStr = User.FindFirst("UserId")?.Value;
            int? userId = userIdStr == null ? null : int.Parse(userIdStr);
            return userId;
        }
        public HomeController(ILogger<HomeController> logger, TeploobmenContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        public IActionResult Calc()
        {
            return View(null);
        }
        
        //double Height, double T_material, double T_gas, double C_gas, double C_material, double G, double d, double W, int av, double step
        public IActionResult Delete(int ID)
        {
            var variant = _context.Variants.FirstOrDefault(x=>x.Id==ID && (x.UserId==GetUserId() || x.UserId==null));
            if (variant!=null)
            {
                _context.Variants.Remove(variant);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Calc(double Height, double T_material, double T_gas, double C_material, double C_gas, double G, double d, double W, int av, double step)
        {
            //var a = Height + C_gas;
            

            //List<List<double>> list = new List<List<double>>();
            //List<double> Height_ = new List<double>();
            //List<double> T_material_ = new List<double>();
            //List<double> T_gas_ = new List<double>();
            //List<double> delta_T = new List<double>();



            List<Par> Both = new List<Par>();

            

            Formulas.Model model = new Formulas.Model(Height, T_material, T_gas, C_gas, C_material, G, d, W, av);

            for (double i = 0; i <= Height; i+=step)
            {
                
                Formulas.Par cur = new Formulas.Par(model.Height(i), i, model.t(i), model.T(i), model.delta_T(i));
                Both.Add(cur);

            }

            CalcViewModel model1 = new CalcViewModel(Both, C_gas, C_material, G, d, W, av);

            
            //ViewData["Result"] = Both;
            _context.Variants.Add(new Variants
            {
                UserId= GetUserId(),
                Height = model.h,
                T_material=model.T_material,
                T_gas=model.T_gas,
                C_gas=model.C_gas,
                C_material=model.C_material,
                G=model.G,
                d=model.d,
                W=model.w,
                av=model.av,
                step=step

            });
            _context.SaveChanges();

            
            return View(model1);
        }

        public IActionResult Index()
        {
            var vars = _context.Variants.Where(x=> x.UserId == GetUserId() || x.UserId==null).ToList();
            return View(vars);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
