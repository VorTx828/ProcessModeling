using Microsoft.AspNetCore.Mvc;
using Model.Models;
using System.Diagnostics;
using Formulas;

namespace Model.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Calc(double Height, double T_material, double T_gas, double C_gas, double C_material, double G, double d, double W, int av, double step)
        {
            var a = Height + C_gas;
            

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

            

            ViewData["Result"] = Both;
            ViewData["C_gas"] = C_gas;
            ViewData["C_material"] = C_material;
            ViewData["G"] = G;
            ViewData["d"] = d;
            ViewData["W"] = W;
            ViewData["av"] = av;
            return View();
        }

        public IActionResult Index()
        {
            return View();
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
