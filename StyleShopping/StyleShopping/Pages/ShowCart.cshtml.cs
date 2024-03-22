using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class ShowCartModel : PageModel
    {
        private readonly IQuotationService quotationService;
        public ShowCartModel()
        {
            quotationService = new QuotationService();
        }
        public List<QuotationDetail> list = new List<QuotationDetail>();
        public IActionResult OnGetAsync()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            int a_id = (int)HttpContext.Session.GetInt32("user_id");
            list = quotationService.GetCart(a_id);
            return Page();
        }
    }
}
