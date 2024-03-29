using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class EditStyleModel : PageModel
    {
        private readonly IStyleService styleService;

        public EditStyleModel()
        {
            styleService = new StyleService();
        }
        [BindProperty]
        public Style style { get; set; } = default!;
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
            style = styleService.Get(id);
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
            foreach (var item in styleService.ListAdmin())
            {
                count++;
                if (item.Id == style.Id)
                {
                    break;
                }
            }
            style.Status = 1;
            int? indexPage = (count - 1) / 5 + 1;
            styleService.Update(style);

            return RedirectToPage("ManageStyle", new { id = indexPage });
        }
    }
}
