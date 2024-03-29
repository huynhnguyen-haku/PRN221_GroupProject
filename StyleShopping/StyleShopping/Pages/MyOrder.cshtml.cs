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
        private readonly IQuotationService _quotationService;
        public MyOrderModel(IQuotationService quotationService)
        {
            _quotationService = quotationService;
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
                list = _quotationService.GetAllOrder(a_id);
                if (!list.Contains(null))
                {
                    listO = new List<OrderDTO>();
                    foreach (var item in list)
                    {
                        int totalCart = 0;
                        OrderDTO o = new OrderDTO();
                        o.id = item.OrderId;
                        o.orderDate = item.OrderDate;
                        o.address = item.Address;
                        o.phone = item.Phone;
                        o.note = item.Note;
                        o.totalStylePrice = ((int)item.Height * (int)item.Width) * ((int)item.Style.PricePerSquare + (int)item.Ceil.PricePerSquare + (int)item.TypeHouse.PricePerSquare+(int)item.Background.PricePerSquare ) + 
                            ((int)item.Long + (int)item.Width)*(int)item.Height*2*(int)item.Wall.PricePerSquare;
                        o.status = (int)item.Status;
                        var details = _quotationService.GetAllOrderDetail(item.OrderId);
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
