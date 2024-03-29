using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class ActiveStyleModel : PageModel
    {
        private readonly IStyleService _styleService;

        public ActiveStyleModel(IStyleService styleService)
        {
           _styleService = styleService;
        }
        public IActionResult OnGetAsync(int id)
        {

            int count = 0;
            foreach (var item in _styleService.ListAdmin())
            {
                count++;
                if (item.Id == id)
                {
                    break;
                }
            }
            Style style = _styleService.Get(id);
            style.Status = 1;
            int? indexPage = (count - 1) / 5 + 1;
            _styleService.Update(style);
            return RedirectToPage("ManageStyle", new { id = indexPage });
        }
    }
}
