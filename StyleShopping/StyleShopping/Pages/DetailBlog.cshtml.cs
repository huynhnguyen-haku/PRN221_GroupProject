using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class DetailBlogModel : PageModel
    {
        private readonly IBlogService _blogService;
        public IEnumerable<Blog> list { get; set; } = default!;
        public DetailBlogModel(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public Blog blog { get; set; } = default!;
        public IActionResult OnGetAsync(int id)
        {
            blog = _blogService.Get(id);
            return Page();
        }
    }
}
