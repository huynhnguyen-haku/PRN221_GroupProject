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
        private readonly IQuotationService _quotationService;
        private readonly IStyleService _styleService;
        public ShowCartModel(IQuotationService quotationService, IStyleService styleService)
        {
            _quotationService = quotationService;
            _styleService = styleService;
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
            list = _quotationService.GetCart(a_id);
            if(list != null)
            {
                foreach (var item in list)
                {
                    total += (int)item.Quantity * (int)item.Interior.Price;
                }
            }
            
            listS = _styleService.List();
            listW = _quotationService.GetAllWall();
            listT = _quotationService.GetAllTypeHouse();
            listC = _quotationService.GetAllCeil();
            listB = _quotationService.GetAllBackground();
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
            QuotationDetail q = _quotationService.GetQuotationDetail(id);
            q.Quantity = quantity;
            _quotationService.UpdateQuotationDetail(q);
            list = _quotationService.GetCart(a_id);
            foreach (var item in list)
            {
                total += (int)item.Quantity * (int)item.Interior.Price;
            }
            listS = _styleService.List();
            listW = _quotationService.GetAllWall();
            listT = _quotationService.GetAllTypeHouse();
            listC = _quotationService.GetAllCeil();
            listB = _quotationService.GetAllBackground();
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
            List<QuotationDetail> carts = _quotationService.GetCart(a_id);
            _quotationService.AddOrder(order, carts);
            _quotationService.RemoveQuotation(a_id);
            return RedirectToPage("./MyOrder");
        }
         
    }
}
