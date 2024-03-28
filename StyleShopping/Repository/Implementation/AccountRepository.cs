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
        public Account getByNameAndPass(string username, string password) => AccountDAO.Instance.GetByNameAndPassword(username, password);
    }
}
