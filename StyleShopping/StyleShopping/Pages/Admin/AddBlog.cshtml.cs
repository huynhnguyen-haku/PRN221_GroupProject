using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class AddBlogModel : PageModel
    {
        private readonly IBlogService _blogService;

        public AddBlogModel(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [BindProperty]
        public Blog blog { get; set; } = default!;
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
            blog.Status = 1;
            blog.CreateDate = DateTime.Now;
            blog.AccountId = HttpContext.Session.GetInt32("user_id");
            _blogService.Add(blog);
            int totalInter = _blogService.ListAdmin().Count;
            int? index = (totalInter % 5) == 0 ? (totalInter / 5) : (totalInter / 5) + 1;
            return RedirectToPage("ManageBlog", new { id = index });
        }
    }
}
