using BussinessObject;
using Service.Implementation;
using Service.Interface;

namespace StyleShopping.HandleRequest
{
    public class AddCartRequest
    {
        private readonly IQuotationService quotationService;
        public AddCartRequest()
        {
            quotationService = new QuotationService();
        }
        public void AddCart(int productID, int? quantity, int id)
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
