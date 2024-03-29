using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class BlockModel : PageModel
    {
        private readonly IInteriorService _interService;

        public BlockModel(IInteriorService interService)
        {
            interService = new InteriorService();
        }
        public IActionResult OnGetAsync(int id)
        {

            int count = 0;
            foreach (var item in _interService.ListAdmin())
            {
                count++;
                if (item.Id == id)
                {
                    break;
                }
            }
            Interior interior = _interService.Get(id);
            interior.Status = 0;
            int? indexPage = (count - 1) / 5 + 1;
            _interService.Update(interior);
            return RedirectToPage("ManageInterior", new { id = indexPage });
        }
    }
}
