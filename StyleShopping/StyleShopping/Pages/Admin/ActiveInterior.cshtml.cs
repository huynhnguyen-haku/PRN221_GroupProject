using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class ActiveModel : PageModel
    {
        private readonly IInteriorService interService;

        public ActiveModel()
        {
            interService = new InteriorService();
        }
        public IActionResult OnGetAsync(int id)
        {

            int count = 0;
            foreach (var item in interService.ListAdmin())
            {
                count++;
                if (item.Id == id)
                {
                    break;
                }
            }
            Interior interior = interService.Get(id);
            interior.Status = 1;
            int? indexPage = (count - 1) / 5 + 1;
            interService.Update(interior);
            return RedirectToPage("ManageInterior", new { id = indexPage });
        }
    }
}
