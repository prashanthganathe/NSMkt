using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NSMkt.Models;
using NSMkt.Models.VM;
using System.Diagnostics;

namespace NSMkt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult RefIndex()
        {
            return View();
        }

        public IActionResult Index(string script)
        {
            if (script==null)
                script="BANKNIFTY";
            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeys.script)))
                HttpContext.Session.SetString(SessionKeys.script,script);

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