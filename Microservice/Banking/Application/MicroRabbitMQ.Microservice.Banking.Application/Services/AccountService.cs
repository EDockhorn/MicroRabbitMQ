using MicroRabbitMQ.Microservice.Banking.Application.Interfaces;
using MicroRabbitMQ.Microservice.Banking.Domain.Interfaces;
using MicroRabbitMQ.Microservice.Banking.Domain.Models;
using System.Collections.Generic;

namespace MicroRabbitMQ.Microservice.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        
        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }
    }
}
