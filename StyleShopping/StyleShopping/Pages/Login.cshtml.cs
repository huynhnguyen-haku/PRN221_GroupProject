using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService accountService;

        public LoginModel()
        {
            accountService = new AccountService();
        }
        public IActionResult OnGetAsync()
        {
            return Page();
        }
        public string error { get; set; } = default!;

        public IActionResult OnPostAsync()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            var account = accountService.getByNameAndPass(username, password);
            if(account == null)
            {
                error = "Wrong Account";
                return Page();
            }
            else
            {
                HttpContext.Session.SetInt32("user_id", account.Id);
                HttpContext.Session.SetInt32("role", (int)account.Role);
                if (account.Role == 0)
                {
                    return RedirectToPage("/Index");
                }
                else if(account.Role == 1)
                {
                    return RedirectToPage("/Admin/ManageInterior");
                }
                else
                {
                    return RedirectToPage("/Admin/ManageInterior");
                }
               
               
            }
            
        }
    }
}
