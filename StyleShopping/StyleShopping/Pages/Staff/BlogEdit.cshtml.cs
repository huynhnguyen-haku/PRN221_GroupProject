using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Staff
{
    public class BlogEditModel : PageModel
    {
        private readonly IBlogService blogService;

        public BlogEditModel()
        {
            blogService = new BlogService();
        }
        [BindProperty]
        public Blog blog { get; set; } = default!;
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
            blog = blogService.Get(id);
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
            foreach (var item in blogService.ListAdmin())
            {
                count++;
                if (item.Id == blog.Id)
                {
                    break;
                }
            }
            blog.Status = 1;
            int? indexPage = (count - 1) / 5 + 1;
            blogService.Update(blog);

            return RedirectToPage("BlogManage", new { id = indexPage });
        }
    }
}
