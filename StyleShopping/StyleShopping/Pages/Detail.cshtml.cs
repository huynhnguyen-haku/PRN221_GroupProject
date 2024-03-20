using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class DetailModel : PageModel
    {
        private readonly IInteriorService interService;
        public IEnumerable<Category> listC { get; set; } = default!;
        public DetailModel()
        {
            interService = new InteriorService();
        }
        public Interior interior { get; set; } = default!;
        public IActionResult OnGetAsync(int id)
        {
            listC = interService.ListCategory();
            interior = interService.Get(id);
            return Page();
        }
    }
}
