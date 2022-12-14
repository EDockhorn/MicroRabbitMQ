using MicroRabbitMQ.Microservice.Banking.Application.Models;
using MicroRabbitMQ.Microservice.Banking.Data.Context;
using MicroRabbitMQ.Microservice.Banking.Domain.Interfaces;
using MicroRabbitMQ.Microservice.Banking.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Microservice.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private BankingDbContext _ctx;

        public AccountRepository(BankingDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _ctx.Accounts;
        }

    }
}
