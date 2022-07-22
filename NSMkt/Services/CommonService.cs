using NSMkt.Models.VM;

namespace NSMkt.Services
{
    public class CommonService:ICommonService
    {
        //public ModelScriptExpiry GetSessionObj()
        //{
        //    if (string.IsNullOrEmpty((HttpContext.Session.GetString(SessionKeys.script))))
        //        HttpContext.Session.SetString(SessionKeys.script, "BANKNIFTY");
        //    if (string.IsNullOrEmpty((HttpContext.Session.GetString(SessionKeys.expiry))))
        //        HttpContext.Session.SetString(SessionKeys.expiry, "27-Jul-2022");

        //    var scrExpModel= new ModelScriptExpiry();
        //    scrExpModel.scriptModel = new ScriptModel();
        //    scrExpModel.expiryDropdownModel = new ExpiryDropdownModel();
        //    scrExpModel.scriptModel.Script = HttpContext.Session.GetString(SessionKeys.script);
        //    scrExpModel.expiryDropdownModel.Expiry = HttpContext.Session.GetString(SessionKeys.expiry);
        //    return scrExpModel;
        //}
    }
}
