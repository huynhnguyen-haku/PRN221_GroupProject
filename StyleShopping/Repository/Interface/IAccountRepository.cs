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

        Account getByName(string username);

        Account GetByID(int id);

        Account Get(int id);

        void Add(Account account);
        void Update(Account account);

        List<Account> ListAdmin();
    }
}
