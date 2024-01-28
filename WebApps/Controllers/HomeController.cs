using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
//creates a reference to the Distance converter
using ConsoleAppProject.App01;
using ConsoleAppProject.App02;


namespace WebApps.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DistanceConverter(DistanceConverter converter)
        {

            return View(converter);
        }

        public IActionResult BmiCalculator()
        {
            return View();
        }

        public IActionResult StudentMarks()
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
