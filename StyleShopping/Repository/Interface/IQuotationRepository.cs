using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IQuotationRepository
    {
        public Quotation GetQuotationUser(int userID);

        public Quotation AddQuotation(Quotation quotation);

        public void AddQuotationDetail(QuotationDetail detail);

        public QuotationDetail GetQuotationDetail(int id, int productID);

        public void UpdateQuotationDetail(QuotationDetail detail);

        public List<QuotationDetail> GetCart(int user_id);

        public void RemoveQuotationDetail(int id);

        public QuotationDetail GetQuotationDetail(int id);

        public void AddOrder(int userID, int square, int style, string phone, string note, string address, List<QuotationDetail> list);

        public void RemoveQuotation(int userID);
        public List<Order> GetAllOrder(int user_id);

        public List<OrderDetail> GetAllOrderDetail(int id);
    }
}
