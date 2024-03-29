using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class ShowCartModel : PageModel
    {
        private readonly IQuotationService quotationService;
        private readonly IStyleService styleService;
        public ShowCartModel()
        {
            quotationService = new QuotationService();
            styleService = new StyleService();
        }
        public int total = 0;
        public List<QuotationDetail> list = new List<QuotationDetail>();
        public IEnumerable<Style> listS = new List<Style>();
        public IEnumerable<TypeHouse> listT = new List<TypeHouse>();
        public IEnumerable<Background> listB = new List<Background>();
        public IEnumerable<Wall> listW = new List<Wall>();
        public IEnumerable<CeilingHouse> listC = new List<CeilingHouse>();

        [BindProperty]
        public Order order { get; set; } = default!;
        public IActionResult OnGetAsync()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            int a_id = (int)HttpContext.Session.GetInt32("user_id");
            list = quotationService.GetCart(a_id);
            if(list != null)
            {
                foreach (var item in list)
                {
                    total += (int)item.Quantity * (int)item.Interior.Price;
                }
            }
            
            listS = styleService.List();
            listW = quotationService.GetAllWall();
            listT = quotationService.GetAllTypeHouse();
            listC = quotationService.GetAllCeil();
            listB = quotationService.GetAllBackground();
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
            int a_id = (int)HttpContext.Session.GetInt32("user_id");
            int id = int.Parse(Request.Form["id"]);
            int quantity = int.Parse(Request.Form["quantity"]);
            QuotationDetail q = quotationService.GetQuotationDetail(id);
            q.Quantity = quantity;
            quotationService.UpdateQuotationDetail(q);
            list = quotationService.GetCart(a_id);
            foreach (var item in list)
            {
                total += (int)item.Quantity * (int)item.Interior.Price;
            }
            listS = styleService.List();
            listW = quotationService.GetAllWall();
            listT = quotationService.GetAllTypeHouse();
            listC = quotationService.GetAllCeil();
            listB = quotationService.GetAllBackground();
            return Page();
        }
        public IActionResult OnPostSubmitAsync()
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            int a_id = (int)HttpContext.Session.GetInt32("user_id");
            order.UserId = a_id;
            List<QuotationDetail> carts = quotationService.GetCart(a_id);
            quotationService.AddOrder(order, carts);
            quotationService.RemoveQuotation(a_id);
            return RedirectToPage("./MyOrder");
        }
         
    }
}
