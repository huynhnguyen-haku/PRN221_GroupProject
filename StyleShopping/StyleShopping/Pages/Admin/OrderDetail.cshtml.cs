using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages.Admin
{
    public class OrderDetailModel : PageModel
    {
        public List<OrderDetail> list { get; set; } = default!;
        public int totalCart = 0;
        public int totalDesign = 0;
        public Order order { get; set; } = default!;
        private readonly IQuotationService quotationService;
        public OrderDetailModel()
        {
            quotationService = new QuotationService();
        }
        public IActionResult OnGetAsync(int id)
        {
            list = quotationService.GetAllOrderDetail(id);
            if (list != null)
            {
                foreach (var item in list)
                {
                    totalCart += (int)item.Quantity * (int)item.Interior.Price;
                }
            }
            order = quotationService.GetOrder(id);
            list = quotationService.GetAllOrderDetail(id);
            totalDesign = ((int)order.Height * (int)order.Width) * ((int)order.Style.PricePerSquare + (int)order.Ceil.PricePerSquare + (int)order.TypeHouse.PricePerSquare + (int)order.Background.PricePerSquare) +
                            ((int)order.Long + (int)order.Width) * (int)order.Height * 2 * (int)order.Wall.PricePerSquare;
            return Page();
        }
    }
}
