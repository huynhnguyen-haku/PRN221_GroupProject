using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Staff
{
    public class BlogAddModel : PageModel
    {
        private readonly IBlogService blogService;

        public BlogAddModel()
        {
            blogService = new BlogService();
        }
        [BindProperty]
        public Blog blog { get; set; } = default!;
        public IActionResult OnGetAsync()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 2)
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
            if (HttpContext.Session.GetInt32("role") != 2)
            {
                return RedirectToPage("/AccessDenied");
            }
            blog.Status = 1;
            blog.CreateDate = DateTime.Now;
            blog.AccountId = HttpContext.Session.GetInt32("user_id");
            blogService.Add(blog);
            int totalInter = blogService.ListAdmin().Count;
            int? index = (totalInter % 5) == 0 ? (totalInter / 5) : (totalInter / 5) + 1;
            return RedirectToPage("BlogManage", new { id = index });
        }
    }
}
