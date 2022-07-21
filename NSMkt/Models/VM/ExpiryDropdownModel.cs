

namespace NSMkt.Models.VM
{


    public class ExpiryDropdownModel
    {
        public string Expiry { get; set; }
        public SelectList Expiries { get; set; }

        public ExpiryDropdownModel()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "30-Jun-2022", Value = "30-Jun-2022" });
            items.Add(new SelectListItem { Text = "07-Jul-2022", Value = "07-Jul-2022" });
            items.Add(new SelectListItem { Text = "14-Jul-2022", Value = "14-Jul-2022" });
            items.Add(new SelectListItem { Text = "21-Jul-2022", Value = "21-Jul-2022" });
            this.Expiries = new SelectList(items, "Value", "Text");
        }
    }
}
