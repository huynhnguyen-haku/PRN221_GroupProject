using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;
using StyleShopping.HandleRequest;
using System.Reflection.Metadata;

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
        public IActionResult OnPostAsync()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            int number = int.Parse(Request.Form["quantity"]);
            int productID = int.Parse(Request.Form["productID"]);
            int a_id = (int)HttpContext.Session.GetInt32("user_id");
            new AddCartRequest().AddCart(productID, number, a_id);
            return RedirectToPage("/Detail", new { id = productID });
        }
    }
}
