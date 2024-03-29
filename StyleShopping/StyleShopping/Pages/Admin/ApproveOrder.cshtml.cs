using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class ApproveOrderModel : PageModel
    {
        private readonly IQuotationService quotationService;
        public ApproveOrderModel()
        {
            quotationService = new QuotationService();
        }
        public IActionResult OnGetAsync(int id)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 1)
            {
                return RedirectToPage("/AccessDenied");
            }
            quotationService.ApproveOrder(id);
            return RedirectToPage("./ManageOrder");
        }
    }
}
