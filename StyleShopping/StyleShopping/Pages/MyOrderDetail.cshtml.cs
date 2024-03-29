using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;
using StyleShopping.DTO;

namespace StyleShopping.Pages
{
    public class MyOrderDetailModel : PageModel
    {
        public List<OrderDetail> list { get; set; } = default!;
        public int totalCart = 0;
        public int totalDesign = 0;
        public Order order { get; set; } = default!;
        private readonly IQuotationService _quotationService;
        public MyOrderDetailModel(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }
        public IActionResult OnGetAsync(int id)
        {
            list = _quotationService.GetAllOrderDetail(id);
            if (list != null)
            {
                foreach (var item in list)
                {
                    totalCart += (int)item.Quantity * (int)item.Interior.Price;
                }
            }
            order = _quotationService.GetOrder(id);
            list = _quotationService.GetAllOrderDetail(id);
            totalDesign = ((int)order.Height * (int)order.Width) * ((int)order.Style.PricePerSquare + (int)order.Ceil.PricePerSquare + (int)order.TypeHouse.PricePerSquare + (int)order.Background.PricePerSquare) +
                            ((int)order.Long + (int)order.Width) * (int)order.Height * 2 * (int)order.Wall.PricePerSquare;
            return Page();
        }
    }
}
