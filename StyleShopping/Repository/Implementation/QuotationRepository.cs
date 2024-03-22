﻿using BussinessObject;
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
    }
}