using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Interface;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class DetailStyleModel : PageModel
    {
        private readonly IStyleService _styleService;
        public IEnumerable<Style> list { get; set; } = default!;
        public DetailStyleModel(IStyleService styleService)
        {
            _styleService = styleService;
        }
        public Style style { get; set; } = default!;
        public int idNow { get; set; } = default!;
        public IActionResult OnGetAsync(int id)
        {
            idNow = id;
            list = _styleService.List();
            style = _styleService.Get(id);
            return Page();
        }
    }
}
