

namespace NSMkt.Controllers.API
{
    using Microsoft.AspNetCore.Mvc;
    using NSMkt.Models.VM;
    public class AjaxController : Controller
    {

        private readonly ICommonService _commonService;

        private readonly ILogger<AjaxController> _logger;
        private IHttpContextAccessor Accessor;
        public AjaxController(ILogger<AjaxController> logger, IHttpContextAccessor _accessor, ICommonService commonService)
        {
            _logger = logger;
            this.Accessor = _accessor;
            _commonService = commonService;
        }


        [HttpPost]
        [ValidateAntiForgeryToken()]
        public JsonResult setScript(string script, string expiry)
        {

            HttpContext.Session.SetString(SessionKeys.script, script);
            HttpContext.Session.SetString(SessionKeys.expiry, expiry);

            HttpContext.Session.SetString(SessionKeys.strike, GetATM(script, expiry));
            HttpContext.Session.SetString(SessionKeys.scriptIteration, GetIteration(script, expiry));

            var scrExpModel = new ModelScriptExpiry();
            scrExpModel.scriptModel = new ScriptModel();
            scrExpModel.expiryDropdownModel = new ExpiryDropdownModel();
            scrExpModel.scriptModel.Script = script;
            scrExpModel.expiryDropdownModel.Expiry = expiry;
            return Json(scrExpModel);

        }

        public string GetATM(string script, string expiry)
        {
            return "16000";
        }

        public string GetIteration(string script, string expiry)
        {
            return "100";
        }
    }
}
