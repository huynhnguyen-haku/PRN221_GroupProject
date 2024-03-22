﻿using BussinessObject;
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

        public void add(string username, string password, string phone, string address)
        {
           _repository.add(username, password, phone, address);
        }

        public Account getByNameAndPass(string username, string password)
        {
            return _repository.getByNameAndPass(username, password);   
        }
    }
}
