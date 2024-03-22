using BussinessObject;
using DAO;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementation
{
    public class QuotationRepository : IQuotationRepository
    {
        public Quotation AddQuotation(Quotation quotation) => QuotationDAO.Instance.AddQuotation(quotation);

        public Quotation GetQuotationUser(int userID) => QuotationDAO.Instance.GetQuotationUser(userID);

        public void AddQuotationDetail(QuotationDetail detail) => QuotationDAO.Instance.AddQuotationDetail(detail);

        public QuotationDetail GetQuotationDetail(int id,int productID) => QuotationDAO.Instance.GetQuotationDetail(id,productID);

        public void UpdateQuotationDetail(QuotationDetail detail) => QuotationDAO.Instance.UpdateQuotationDetail(detail);

        public List<QuotationDetail> GetCart(int user_id) => QuotationDAO.Instance.GetCart(user_id);

        public void RemoveQuotationDetail(int id) => QuotationDAO.Instance.RemoveQuotationDetail(id);

        public QuotationDetail GetQuotationDetail(int id) => QuotationDAO.Instance.GetQuotationDetail(id);

        public void AddOrder(int userID, int square, int style, string phone, string note, string address, List<QuotationDetail> list) => QuotationDAO.Instance.AddOrder(userID, square, style, phone, note, address, list);

        public void RemoveQuotation(int userID) => QuotationDAO.Instance.RemoveQuotation(userID);

        public List<Order> GetAllOrder(int user_id) => QuotationDAO.Instance.GetAllOrder(user_id);

        public List<OrderDetail> GetAllOrderDetail(int id) => QuotationDAO.Instance.GetAllOrderDetail(id);
    }
}
