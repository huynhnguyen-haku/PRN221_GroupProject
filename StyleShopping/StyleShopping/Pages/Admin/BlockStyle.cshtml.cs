using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class BlockStyleModel : PageModel
    {
        private readonly IStyleService styleService;

        public BlockStyleModel()
        {
            styleService = new StyleService();
        }
        public IActionResult OnGetAsync(int id)
        {

            int count = 0;
            foreach (var item in styleService.ListAdmin())
            {
                count++;
                if (item.Id == id)
                {
                    break;
                }
            }
            Style style = styleService.Get(id);
            style.Status = 0;
            int? indexPage = (count - 1) / 5 + 1;
            styleService.Update(style);
            return RedirectToPage("ManageStyle", new { id = indexPage });
        }
    }
}
