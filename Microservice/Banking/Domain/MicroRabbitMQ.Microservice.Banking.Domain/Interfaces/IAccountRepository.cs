using MicroRabbitMQ.Microservice.Banking.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Microservice.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
