using BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IAccountRepository
    {
        Account getByNameAndPass(string username, string password);

        public void add(string username, string password, string phone, string address);
    }
}
