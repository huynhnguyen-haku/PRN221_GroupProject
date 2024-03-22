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
    }
}
