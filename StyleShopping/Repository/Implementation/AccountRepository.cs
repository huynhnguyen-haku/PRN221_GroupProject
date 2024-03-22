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
    public class AccountRepository : IAccountRepository
    {
        public void add(string username, string password, string phone, string address) => AccountDAO.Instance.add(username, password, phone, address);
        public Account getByNameAndPass(string username, string password) => AccountDAO.Instance.GetByNameAndPassword(username, password);
    }
}
