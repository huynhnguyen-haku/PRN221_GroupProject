using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class ActiveBlogModel : PageModel
    {
        private readonly IBlogService _blogService;

        public ActiveBlogModel(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult OnGetAsync(int id)
        {

            int count = 0;
            foreach (var item in _blogService.ListAdmin())
            {
                count++;
                if (item.Id == id)
                {
                    break;
                }
            }
            Blog blog = _blogService.Get(id);
            blog.Status = 1;
            int? indexPage = (count - 1) / 5 + 1;
            _blogService.Update(blog);
            return RedirectToPage("ManageBlog", new { id = indexPage });
        }
    }
}
