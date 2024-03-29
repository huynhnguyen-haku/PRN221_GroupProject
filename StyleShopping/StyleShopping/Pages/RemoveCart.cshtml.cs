using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class RemoveCartModel : PageModel
    {
        private readonly IQuotationService _quotationService;
        public RemoveCartModel(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }
        public IActionResult OnGetAsync(int id)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            _quotationService.RemoveQuotationDetail(id);
            return RedirectToPage("./ShowCart");
        }
    }
}
