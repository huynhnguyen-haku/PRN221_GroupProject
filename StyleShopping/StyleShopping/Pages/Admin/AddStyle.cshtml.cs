using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class AddStyleModel : PageModel
    {
        private readonly IStyleService _styleService;

        public AddStyleModel(IStyleService styleService)
        {
            _styleService = styleService;
        }
        [BindProperty]
        public Style style { get; set; } = default!;
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
            style.Status = 1;
            _styleService.Add(style);
            int totalInter = _styleService.ListAdmin().Count;
            int? index = (totalInter % 5) == 0 ? (totalInter / 5) : (totalInter / 5) + 1;
            return RedirectToPage("ManageStyle", new { id = index });
        }
    }
}
