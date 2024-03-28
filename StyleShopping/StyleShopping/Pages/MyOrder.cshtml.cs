using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;
using StyleShopping.DTO;

namespace StyleShopping.Pages
{
    public class MyOrderModel : PageModel
    {
        public List<Order> list { get; set; } = default!;
        private readonly IQuotationService quotationService;
        public MyOrderModel()
        {
            quotationService = new QuotationService();
        }
        public List<OrderDTO> listO { get; set; } = default!;
        public IActionResult OnGetAsync()
        {
            try
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
                list = quotationService.GetAllOrder(a_id);
                if (!list.Contains(null))
                {
                    listO = new List<OrderDTO>();
                    foreach (var item in list)
                    {
                        int totalCart = 0;
                        OrderDTO o = new OrderDTO();
                        o.style = item.Style.Name;
                        o.priceStyle = (int)item.Style.PricePerSquare;
                        o.square = (int)item.Square;
                        o.totalStylePrice = (int)item.Square * (int)item.Style.PricePerSquare;
                        o.status = (int)item.Status;
                        var details = quotationService.GetAllOrderDetail(item.OrderId);
                        foreach (var i in details)
                        {
                            totalCart += (int)i.Quantity * (int)i.Interior.Price;
                        }
                        o.totalCartPrice = totalCart;
                        listO.Add(o);
                    }
                }

                return Page();
            }
            catch(Exception ex) {
                return Page();
            }
           
        }
    }
}
