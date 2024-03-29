using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class ApproveOrderModel : PageModel
    {
        private readonly IQuotationService _quotationService;
        public ApproveOrderModel(IQuotationService quotationService)
        {
            _quotationService = quotationService;
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
            _quotationService.ApproveOrder(id);
            return RedirectToPage("./ManageOrder");
        }
    }
}
