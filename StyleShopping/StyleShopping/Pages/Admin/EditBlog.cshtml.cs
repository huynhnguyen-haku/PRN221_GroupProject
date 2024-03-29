using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class EditBlogModel : PageModel
    {
        private readonly IBlogService _blogService;

        public EditBlogModel(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [BindProperty]
        public Blog blog { get; set; } = default!;
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
            blog = _blogService.Get(id);
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
            foreach (var item in _blogService.ListAdmin())
            {
                count++;
                if (item.Id == blog.Id)
                {
                    break;
                }
            }
            blog.Status = 1;
            int? indexPage = (count - 1) / 5 + 1;
            _blogService.Update(blog);

            return RedirectToPage("ManageBlog", new { id = indexPage });
        }
    }
}
