using Microsoft.AspNetCore.Mvc;
using NSMkt.Models.VM;

namespace NSMkt.Controllers
{
    public class SelectedStocksController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IHttpContextAccessor Accessor;
        public SelectedStocksController(ILogger<HomeController> logger, IHttpContextAccessor _accessor)
        {
            _logger = logger;
            this.Accessor = _accessor;
          
        }

        public IActionResult BullishList()
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

        public IActionResult BearishList()
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
    }
}
