﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConversorDistancias.Models;

namespace ConversorDistancias.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(DistanciasViewModel distancias)
        {
            if (ModelState.IsValid)
            {
                distancias.DistanciaKm = distancias.DistanciaMilhas * 1.609;
                return View(distancias);
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError(nameof(distancias.DistanciaMilhas),
                    "Informe uma distância em milhas entre 0.01 e 9999999.99!");
                return View();
            }
                
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
