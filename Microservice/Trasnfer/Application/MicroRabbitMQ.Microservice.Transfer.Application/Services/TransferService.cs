using MicroRabbitMQ.Domain.Core.Bus;
using MicroRabbitMQ.Microservice.Transfer.Application.Interfaces;
using MicroRabbitMQ.Microservice.Transfer.Domain.Interfaces;
using MicroRabbitMQ.Microservice.Transfer.Domain.Models;
using System.Collections.Generic;

namespace MicroRabbitMQ.Microservice.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _accountRepository;
        private readonly IEventBus _bus;

        public TransferService(ITransferRepository accountRepository, IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _accountRepository.GetTransferLogs();
        }
    }
}
