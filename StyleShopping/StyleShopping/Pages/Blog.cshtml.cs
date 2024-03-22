using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class BlogModel : PageModel
    {
        public IEnumerable<Blog> list { get; set; } = default!;
        private readonly IBlogService blogService;
        public int totalPage { get; set; } = default!;
        public int? indexPage { get; set; } = 1;
        public BlogModel()
        {
            blogService = new BlogService();
        }
        public IActionResult OnGetAsync(int? id)
        {
            indexPage = id == null ? 1 : id;
            list = blogService.List();
            if (list.Count() % 3 == 0)
            {
                totalPage = list.Count() / 3;
            }
            else
            {
                totalPage = (list.Count() / 3) + 1;
            }

            if (indexPage != totalPage)
            {
                list = list.Skip(((int)indexPage - 1) * 3).Take(3);
            }
            else
            {
                list = list.Skip(((int)indexPage - 1) * 3).Take(3);
            }
            return Page();
        }
    }
}
