using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Staff
{
    public class InteriorEditModel : PageModel
    {
        private readonly IInteriorService interService;

        public InteriorEditModel()
        {
            interService = new InteriorService();
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
            if (HttpContext.Session.GetInt32("role") != 2)
            {
                return RedirectToPage("/AccessDenied");
            }
            list = interService.ListCategory();
            interior = interService.Get(id);
            return Page();
        }
        public IActionResult OnPostAsync()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 2)
            {
                return RedirectToPage("/AccessDenied");
            }
            int count = 0;
            foreach (var item in interService.ListAdmin())
            {
                count++;
                if (item.Id == interior.Id)
                {
                    break;
                }
            }
            interior.Status = 1;
            int? indexPage = (count - 1) / 5 + 1;
            interService.Update(interior);

            return RedirectToPage("InteriorManage", new { id = indexPage });
        }
    }
}
