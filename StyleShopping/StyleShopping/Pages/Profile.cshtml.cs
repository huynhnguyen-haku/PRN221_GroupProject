using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly IAccountService accountService;

        public ProfileModel()
        {
            accountService = new AccountService();
        }
        public string success { get; set; } = default!;

        public string errorUpdate { get; set; } = default!;

        [BindProperty]
        public Account account { get; set; } = default!;
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
            account = accountService.Get(a_id);
            return Page();

        }
        public IActionResult OnPostAsync()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            if (account.Username.Length >= 100 || account.Password.Length >= 100 || account.Phone.Length >= 100 || account.Address.Length >= 100)
            {
                errorUpdate = "All text is not over 100 characters";
                return Page();
            }
            success = "Update successfully";
            accountService.Update(account);
            return Page();

        }
    }
}
