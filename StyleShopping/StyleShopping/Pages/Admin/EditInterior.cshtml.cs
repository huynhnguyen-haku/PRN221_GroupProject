using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class EditInteriorModel : PageModel
    {
        private readonly IInteriorService _interService;

        public EditInteriorModel(IInteriorService interService)
        {
            _interService = interService;
        }
        public IEnumerable<Category> list { get; set; } = default!;
        [BindProperty]
        public Interior interior { get; set; } = default!;
        public IActionResult OnGetAsync(int id)
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
            interior = _interService.Get(id);
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
            int count = 0;
            foreach (var item in _interService.ListAdmin())
            {
                count++;
                if(item.Id == interior.Id)
                {
                    break;
                }
            }
            interior.Status = 1;
            int? indexPage = (count - 1) / 5 + 1;
            _interService.Update(interior);
            
            return RedirectToPage("ManageInterior", new { id = indexPage });
        }
    }
}
