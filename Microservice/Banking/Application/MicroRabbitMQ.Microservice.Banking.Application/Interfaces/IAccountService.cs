using MicroRabbitMQ.Microservice.Banking.Domain.Models;
using System.Collections.Generic;

namespace MicroRabbitMQ.Microservice.Banking.Application.Interfaces
{
    public interface IAccountService
    {
        public IEnumerable<Account> GetAccounts();
    }
}
