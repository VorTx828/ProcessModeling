﻿using Microsoft.AspNetCore.Mvc;

namespace Model.Controllers
{   
    
    public class MyController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Test(IFormCollection Collection)
        {

        }


        public IActionResult Test()
        {
            
            return View();
        }
    }
}