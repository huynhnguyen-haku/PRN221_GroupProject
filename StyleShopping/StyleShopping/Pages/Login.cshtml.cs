using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService;

        public LoginModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult OnGetAsync()
        {
            return Page();
        }
        public string error { get; set; } = default!;
        public string success { get; set; } = default!;

        public string errorRegister { get; set; } = default!;

        [BindProperty]
        public Account account { get; set; } = default!;

        public IActionResult OnPostAsync()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            var account = _accountService.getByNameAndPass(username, password);
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
                    return RedirectToPage("/Staff/BlogManage");
                }
               
               
            }
            
        }
        public IActionResult OnPostSubmitAsync()
        {
            if (_accountService.getByName(account.Username) != null)
            {
                errorRegister = "Username : " + account.Username + " already exist";
                return Page();
            }
            if (account.Username.Length >= 100 || account.Password.Length >= 100 || account.Phone.Length >= 100 || account.Address.Length >= 100)
            {
                errorRegister = "All text is not over 100 characters";
                return Page();
            }
            success = "Register successfully";
            account.Status = 1;
            account.Role = 0;
            _accountService.Add(account);

            return Page();

        }
    }
}
