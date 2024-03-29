using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Staff
{
    public class BlogActiveModel : PageModel
    {
        private readonly IBlogService blogService;

        public BlogActiveModel()
        {
            blogService = new BlogService();
        }
        public IActionResult OnGetAsync(int id)
        {

            int count = 0;
            foreach (var item in blogService.ListAdmin())
            {
                count++;
                if (item.Id == id)
                {
                    break;
                }
            }
            Blog blog = blogService.Get(id);
            blog.Status = 1;
            int? indexPage = (count - 1) / 5 + 1;
            blogService.Update(blog);
            return RedirectToPage("BlogManage", new { id = indexPage });
        }
    }
}
