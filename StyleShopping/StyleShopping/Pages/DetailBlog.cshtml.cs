using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class DetailBlogModel : PageModel
    {
        private readonly IBlogService blogService;
        public IEnumerable<Blog> list { get; set; } = default!;
        public DetailBlogModel()
        {
            blogService = new BlogService();
        }
        public Blog blog { get; set; } = default!;
        public IActionResult OnGetAsync(int id)
        {
            blog = blogService.Get(id);
            return Page();
        }
    }
}
