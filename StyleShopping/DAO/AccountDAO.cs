using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        private AccountDAO() { }
        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }

            }
        }


        public Account GetByName(string username)
        {
            Account account = null;
            try
            {
                using (var MySale = new styleContext())
                {
                    account = MySale.Accounts.SingleOrDefault(x => x.Username.Equals(username));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return account;
        }
        public Account GetByNameAndPassword(string username,string password)
        {
            Account account = null;
            try
            {
                using (var MySale = new styleContext())
                {
                    account = MySale.Accounts.SingleOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return account;
        }
        public void add(string username, string password,string phone,string address)
        {
            Account account = new Account()
            {
                Username = username,
                Password = password,
                Phone = phone,
                Address = address,
                Status = 1,
                Role = 0
            };
            try
            {
                using (var MySale = new styleContext())
                {
                   
                    MySale.Accounts.Add(account);
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
