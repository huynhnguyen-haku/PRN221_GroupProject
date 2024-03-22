using BussinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class QuotationDAO
    {
        private static QuotationDAO instance = null;
        private static readonly object instanceLock = new object();
        private QuotationDAO() { }
        public static QuotationDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new QuotationDAO();
                    }
                    return instance;
                }

            }
        }



        public Quotation GetQuotationUser(int userID)
        {
            Quotation quotation = null;
            try
            {
                using (var MySale = new styleContext())
                {
                    quotation = MySale.Quotations.SingleOrDefault(x => x.AccountId == userID);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return quotation;
        }
        public Quotation AddQuotation(Quotation quotation)
        {
            try
            {
                using (var MySale = new styleContext())
                {
                    MySale.Quotations.Add(quotation);
                    MySale.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return quotation;
        }
        public void AddQuotationDetail(QuotationDetail detail)
        {
            try
            {
                using (var MySale = new styleContext())
                {
                    MySale.QuotationDetails.Add(detail);
                    MySale.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public QuotationDetail GetQuotationDetail(int id, int productID)
        {
            QuotationDetail detail = null;
            try
            {
                using (var MySale = new styleContext())
                {
                    detail = MySale.QuotationDetails.SingleOrDefault(x => x.QuotationId == id && x.InteriorId == productID);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return detail;
        }
        public List<QuotationDetail> GetCart(int user_id)
        {
            List<QuotationDetail> list = null;
            try
            {
                using (var MySale = new styleContext())
                {
                    Quotation q = MySale.Quotations.FirstOrDefault(x => x.AccountId == user_id);
                    list = MySale.QuotationDetails.Include(x => x.Interior).Where(x => x.QuotationId == q.QuotationId).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }
        public void UpdateQuotationDetail(QuotationDetail detail)
        {
            try
            {
                using (var MySale = new styleContext())
                {
                    MySale.QuotationDetails.Update(detail);
                    MySale.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void RemoveQuotationDetail(int id)
        {
            try
            {
                using (var MySale = new styleContext())
                {
                    var q = MySale.QuotationDetails.FirstOrDefault(X => X.QuotationDetailId == id); 
                    MySale.QuotationDetails.Remove(q);
                    MySale.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
