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
        public IActionResult OnGetAsync(int id,int? quantity)
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
            AddCart(id, 1, a_id);
            return RedirectToPage("./Index");
            


        }
        public IActionResult OnPostAsync(int id, int? quantity)
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
            AddCart(id, quantity, a_id);
            return RedirectToPage("./Detail?id="+ id);



        }

        public void AddCart(int productID, int? quantity,int id)
        {
            var quotation = quotationService.GetQuotationUser(id);
            if (quotation == null)
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
                QuotationDetail detail = quotationService.GetQuotationDetail(quotation.QuotationId, productID);

                if (detail == null)
                {
                    QuotationDetail newDetail = new QuotationDetail();
                    newDetail.QuotationId = quotation.QuotationId;
                    newDetail.InteriorId = productID;
                    newDetail.Quantity = quantity;
                    quotationService.AddQuotationDetail(newDetail);
                }
                else
                {
                    detail.Quantity = detail.Quantity + quantity;
                    quotationService.UpdateQuotationDetail(detail);
                }
            }
        }
    }
}
