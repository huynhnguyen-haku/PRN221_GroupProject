using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class BlockAccountModel : PageModel
    {
        private readonly IAccountService _accountService;

        public BlockAccountModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult OnGetAsync(int id)
        {

            int count = 0;
            foreach (var item in _accountService.ListAdmin())
            {
                count++;
                if (item.Id == id)
                {
                    break;
                }
            }
            Account account = _accountService.Get(id);
            account.Status = 0;
            int? indexPage = (count - 1) / 5 + 1;
            _accountService.Update(account);
            return RedirectToPage("ManageAccount", new { id = indexPage });
        }
    }
}
