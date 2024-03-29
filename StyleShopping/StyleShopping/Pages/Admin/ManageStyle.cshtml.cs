using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class ManageStyleModel : PageModel
    {
        public IEnumerable<Style> list { get; set; } = default!;

        private readonly IStyleService _styleService;

        public int totalPage { get; set; } = default!;
        public int? indexPage { get; set; } = 1;

        public ManageStyleModel(IStyleService styleService)
        {
            _styleService = styleService;
        }
        public IActionResult OnGetAsync(int? id)
        {
            indexPage = id == null ? 1 : id;
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 1)
            {
                return RedirectToPage("/AccessDenied");
            }
            list = _styleService.ListAdmin();
            if (list.Count() % 5 == 0)
            {
                totalPage = list.Count() / 5;
            }
            else
            {
                totalPage = (list.Count() / 5) + 1;
            }

            if (indexPage != totalPage)
            {
                list = list.Skip(((int)indexPage - 1) * 5).Take(5);
            }
            else
            {
                list = list.Skip(((int)indexPage - 1) * 5).Take(5);
            }
            return Page();
        }
    }
}
