using BussinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.Pages
{
    public class AddCartModel : PageModel
    {
        private readonly IQuotationService quotationService;
        public AddCartModel()
        {
            quotationService = new QuotationService();
        }
        public IActionResult OnGetAsync(int productID,int? quantity)
        {
            if (HttpContext.Session.GetInt32("user_id") == null)
            {
                return RedirectToPage("/Login");
            }
            if (HttpContext.Session.GetInt32("role") != 0)
            {
                return RedirectToPage("/AccessDenied");
            }
            quantity = (quantity == null) ? 1 : quantity;
            int id = (int)HttpContext.Session.GetInt32("user_id");
            var quotation = quotationService.GetQuotationUser(id);
            if(quotation == null)
            {
                Quotation newQuotation = new Quotation();
                newQuotation.QuotationStatus = "Pending";
                newQuotation.AccountId = id;
                newQuotation.CreateDate = DateTime.Now;
                newQuotation = quotationService.AddQuotation(newQuotation);
                QuotationDetail detail = new QuotationDetail();
                detail.QuotationId = newQuotation.QuotationId;
                detail.InteriorId = productID;
                detail.Quantity = quantity;
                quotationService.AddQuotationDetail(detail);


            }
            else
            {
                var detail = quotationService.GetQuotationDetail(quotation.QuotationId);
                
                if(detail == null)
                {
                    QuotationDetail newDetail = new QuotationDetail();
                    newDetail.QuotationId = quotation.QuotationId;
                    newDetail.InteriorId = productID;
                    newDetail.Quantity = quantity;
                    quotationService.AddQuotationDetail(newDetail);
                }
                else
                {

                }
            }
            return Page();


        }
    }
}
