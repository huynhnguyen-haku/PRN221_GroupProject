using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class BeStaffModel : PageModel
    {
        private readonly IAccountService accountService;

        public BeStaffModel()
        {
            accountService = new AccountService();
        }
        public IActionResult OnGetAsync(int id)
        {

            int count = 0;
            foreach (var item in accountService.ListAdmin())
            {
                count++;
                if (item.Id == id)
                {
                    break;
                }
            }
            Account account = accountService.Get(id);
            account.Role = 2;
            int? indexPage = (count - 1) / 5 + 1;
            accountService.Update(account);
            return RedirectToPage("ManageAccount", new { id = indexPage });
        }
    }
}
