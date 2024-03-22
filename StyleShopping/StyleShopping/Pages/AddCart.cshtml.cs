using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;
using StyleShopping.HandleRequest;

namespace StyleShopping.Pages
{
    public class AddCartModel : PageModel
    {
        private readonly IQuotationService quotationService;
        public AddCartModel()
        {
            quotationService = new QuotationService();
        }
        public IActionResult OnGetAsync(int id,int? quantity)
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
            new AddCartRequest().AddCart(id, 1, a_id);
            return RedirectToPage("./Index");
            


        }
       

        
    }
}
