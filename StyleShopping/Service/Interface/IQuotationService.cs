using BussinessObject;
using Repository.Implementation;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IQuotationService
    {
       
        public Quotation GetQuotationUser(int userID);

        public Quotation AddQuotation(Quotation quotation);

        public void AddQuotationDetail(QuotationDetail detail);

        public QuotationDetail GetQuotationDetail(int id);

        public void UpdateQuotationDetail(QuotationDetail detail);
    }
}
