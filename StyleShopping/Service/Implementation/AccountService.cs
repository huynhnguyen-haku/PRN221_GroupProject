using BussinessObject;
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
    public class AccountService : IAccountService
    {
        private IAccountRepository _repository;
        public AccountService()
        {
            _repository = new AccountRepository();
        }
        public Account getByNameAndPass(string username, string password)
        {
            return _repository.getByNameAndPass(username, password);   
        }
        public Account getByName(string username)
        {
            return _repository.getByName(username);
        }

        public Account Get(int id) => _repository.Get(id);


        public List<Account> ListAdmin() => _repository.ListAdmin();


        public void Add(Account account) => _repository.Add(account);

        public void Update(Account account) => _repository.Update(account);

        public Account GetByID(int id)
        {
            return _repository.GetByID(id);
        }
    }
}
