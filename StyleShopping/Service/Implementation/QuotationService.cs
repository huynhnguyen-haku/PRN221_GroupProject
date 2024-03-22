using BussinessObject;
using DAO;
using Repository.Implementation;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class QuotationService : IQuotationService
    {
        private IQuotationRepository _repository;
        public QuotationService()
        {
            _repository = new QuotationRepository();
        }

        public Quotation AddQuotation(Quotation quotation)
        {
            return _repository.AddQuotation(quotation);
        }

        public void AddQuotationDetail(QuotationDetail detail)
        {
             _repository.AddQuotationDetail(detail);
        }

        public Quotation GetQuotationUser(int userID)
        {
            return _repository.GetQuotationUser(userID);
        }

        public QuotationDetail GetQuotationDetail(int id,int productID)
        {
            return _repository.GetQuotationDetail(id, productID);
        }

        public void UpdateQuotationDetail(QuotationDetail detail)
        {
            _repository.UpdateQuotationDetail(detail);
        }

        public List<QuotationDetail> GetCart(int user_id)
        {
            return _repository.GetCart(user_id);
        }

        public void RemoveQuotationDetail(int id)
        {
            _repository.RemoveQuotationDetail(id);
        }

        public QuotationDetail GetQuotationDetail(int id)
        {
            return _repository.GetQuotationDetail(id);
        }

        public void AddOrder(int userID, int square, int style, string phone, string note, string address, List<QuotationDetail> list)
        {
            _repository.AddOrder(userID,square,style,phone,note,address,list);
        }

        public void RemoveQuotation(int userID)
        {
           _repository.RemoveQuotation(userID);
        }
        public List<Order> GetAllOrder(int user_id)
        {
            return _repository.GetAllOrder(user_id);
        }

        public List<OrderDetail> GetAllOrderDetail(int id)
        {
            return _repository.GetAllOrderDetail(id);
        }
    }
}
