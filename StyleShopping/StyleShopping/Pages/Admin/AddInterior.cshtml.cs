using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class AddInteriorModel : PageModel
    {
        private readonly IInteriorService _interService;

        public AddInteriorModel(InteriorService interiorService)
        {
            _interService = interiorService;
        }
        public IEnumerable<Category> list { get; set; } = default!;
        [BindProperty]
        public Interior interior { get; set; } = default!;
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
            list = _interService.ListCategory();
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
            interior.Status = 1;
            _interService.Add(interior);
            int totalInter = _interService.ListAdmin().Count;
            int? index = (totalInter % 5) == 0 ? (totalInter / 5) : (totalInter / 5) + 1;
            return RedirectToPage("ManageInterior", new { id = index });
        }


    }
}
