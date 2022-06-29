using Microsoft.AspNetCore.Mvc;

namespace NSMkt.Controllers
{
    public class SelectedStocksController : Controller
    {
        public IActionResult BullishList()
        {
            return View();
        }

        public IActionResult BearishList()
        {
            return View();
        }
    }
}
