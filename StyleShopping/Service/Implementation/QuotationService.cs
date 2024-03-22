﻿using BussinessObject;
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
    }
}
