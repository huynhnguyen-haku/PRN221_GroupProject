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
        public Order GetOrder(int id)
        {
            Order order = null;
            try
            {
                using (var MySale = new styleContext())
                {
                    order = MySale.Orders.Include(x => x.Style).Include(x => x.Ceil).Include(x => x.Background).Include(x => x.Wall).Include(x => x.TypeHouse).SingleOrDefault(x => x.OrderId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return order;
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
        public QuotationDetail GetQuotationDetail(int id)
        {
            QuotationDetail detail = null;
            try
            {
                using (var MySale = new styleContext())
                {
                    detail = MySale.QuotationDetails.SingleOrDefault(x => x.QuotationDetailId == id);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return detail;
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
        public List<OrderDetail> GetAllOrderDetail(int id)
        {
            List<OrderDetail> list = new ();
            try
            {
                using (var MySale = new styleContext())
                {
                    list = MySale.OrderDetails.Include(x => x.Interior).Where(x => x.OrderId == id).ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }
        public List<Order> GetAllOrder(int user_id)
        {
            List<Order> list = new();
            try
            {
                using (var MySale = new styleContext())
                {
                    Order q = MySale.Orders.Include(x => x.Style).Include(x => x.Ceil).Include(x => x.Background).Include(x => x.Wall).Include(x => x.TypeHouse).FirstOrDefault(x => x.UserId == user_id);
                    list.Add(q);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }
        public List<TypeHouse> GetAllTypeHouse()
        {
            List<TypeHouse> list = new();
            try
            {
                using (var MySale = new styleContext())
                {
                   
                    list = MySale.TypeHouses.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }
        public List<CeilingHouse> GetAllCeil()
        {
            List<CeilingHouse> list = new();
            try
            {
                using (var MySale = new styleContext())
                {

                    list = MySale.CeilingHouses.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }
        public List<Wall> GetAllWall()
        {
            List<Wall> list = new();
            try
            {
                using (var MySale = new styleContext())
                {

                    list = MySale.Walls.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }
        public List<Background> GetAllBackground()
        {
            List<Background> list = new();
            try
            {
                using (var MySale = new styleContext())
                {

                    list = MySale.Backgrounds.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }
        public List<QuotationDetail> GetCart(int user_id)
        {
            List<QuotationDetail> list = null;
            try
            {
                using (var MySale = new styleContext())
                {
                    Quotation q = MySale.Quotations.FirstOrDefault(x => x.AccountId == user_id);
                    if (q != null)
                    {
                        list = MySale.QuotationDetails.Include(x => x.Interior).Where(x => x.QuotationId == q.QuotationId).ToList();
                    }
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
        public void AddOrder(Order o,List<QuotationDetail> list)
        {
            try
            {
                using (var MySale = new styleContext())
                {
                    o.Status = 1;
                    o.OrderDate = DateTime.Now;
                    MySale.Orders.Add(o);
                    MySale.SaveChanges();
                    foreach (var item in list)
                    {
                        OrderDetail od = new OrderDetail()
                        {
                            InteriorId = item.InteriorId,
                            Quantity = item.Quantity,
                            OrderId = o.OrderId
                        };
                        MySale.OrderDetails.Add(od); 
                    }

                    MySale.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void CancelOrder(int id)
        {
            try
            {
                using (var MySale = new styleContext())
                {
                    var order = MySale.Orders.FirstOrDefault(x => x.OrderId == id);
                    order.Status = 0;
                    MySale.Orders.Update(order);
                    MySale.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void RemoveQuotation(int userID)
        {
            try
            {
                using (var MySale = new styleContext())
                {
                    var q = MySale.Quotations.FirstOrDefault(x => x.AccountId == userID);
                    var details = MySale.QuotationDetails.Where(x => x.QuotationId == q.QuotationId).ToList();
                    MySale.QuotationDetails.RemoveRange(details);
                    MySale.Quotations.Remove(q);
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
