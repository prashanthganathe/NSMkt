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
        private IHttpContextAccessor Accessor;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor _accessor)
        {
            _logger = logger;
            this.Accessor = _accessor;
        }

        public IActionResult RefIndex()
        {
            return View();
        }

        public IActionResult Index()
        {
            HttpContext context = this.Accessor.HttpContext;

            if (string.IsNullOrEmpty((HttpContext.Session.GetString(SessionKeys.script))))
                HttpContext.Session.SetString(SessionKeys.script, "BANKNIFTY");
            if (string.IsNullOrEmpty((HttpContext.Session.GetString(SessionKeys.expiry))))
                HttpContext.Session.SetString(SessionKeys.expiry, "27-Jul-2022");

            var scrExpModel = new ModelScriptExpiry();
            scrExpModel.scriptModel = new ScriptModel();
            scrExpModel.expiryDropdownModel = new ExpiryDropdownModel();
            scrExpModel.scriptModel.Script = HttpContext.Session.GetString(SessionKeys.script);
            scrExpModel.expiryDropdownModel.Expiry = HttpContext.Session.GetString(SessionKeys.expiry);
            return View(scrExpModel);
        }

 
        [HttpPost]
       // [ValidateAntiForgeryToken()]
        public  JsonResult setScript(string script,string expiry)
        {
           
            HttpContext.Session.SetString(SessionKeys.script, script);
            HttpContext.Session.SetString(SessionKeys.expiry, expiry);

            HttpContext.Session.SetString(SessionKeys.strike, GetATM(script,expiry));
            HttpContext.Session.SetString(SessionKeys.scriptIteration, GetIteration(script, expiry));

            var scrExpModel = new ModelScriptExpiry();
            scrExpModel.scriptModel = new ScriptModel();
            scrExpModel.expiryDropdownModel = new ExpiryDropdownModel();
            scrExpModel.scriptModel.Script = script;
            scrExpModel.expiryDropdownModel.Expiry = expiry;
            return  Json(scrExpModel);
                
        }

        public string GetATM(string script,string expiry)
        {
            return "16000";
        }

        public string GetIteration(string script,string expiry)
        {
            return "100";
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