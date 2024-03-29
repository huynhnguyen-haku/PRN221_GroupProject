using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StyleShopping.Pages.Staff
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGetAsync()
        {
            HttpContext.Session.Remove("role");
            HttpContext.Session.Remove("user_id");
            return RedirectToPage("/Index");
        }
    }
}
