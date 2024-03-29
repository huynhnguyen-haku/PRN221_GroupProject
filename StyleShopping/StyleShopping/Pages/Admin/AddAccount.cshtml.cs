using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class AddAccountModel : PageModel
    {
        private readonly IAccountService accountService;

        public AddAccountModel()
        {
            accountService = new AccountService();
        }
        [BindProperty]
        public Account account { get; set; } = default!;

        public string error { get; set; } = default!;
        public IActionResult OnGetAsync()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 1)
            {
                return RedirectToPage("/AccessDenied");
            }
            return Page();
        }
        public IActionResult OnPostAsync()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 1)
            {
                return RedirectToPage("/AccessDenied");
            }
            if(accountService.getByName(account.Username) != null) { 
                error = "Username : " + account.Username + " already exist";
                return Page();
            }
            if (account.Username.Length >= 100 || account.Password.Length >= 100 || account.Phone.Length >= 100 || account.Address.Length >= 100)
            {
                error = "All text is not over 100 characters";
                return Page();
            }
            account.Status = 1;
            accountService.Add(account);
            int totalInter = accountService.ListAdmin().Count;
            int? index = (totalInter % 5) == 0 ? (totalInter / 5) : (totalInter / 5) + 1;
            return RedirectToPage("ManageAccount", new { id = index });
        }
    }
}
