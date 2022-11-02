using MicroRabbitMQ.Domain.Core.Bus;
using MicroRabbitMQ.Microservice.Transfer.Domain.Events;
using MicroRabbitMQ.Microservice.Transfer.Domain.Interfaces;
using MicroRabbitMQ.Microservice.Transfer.Domain.Models;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Microservice.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;

        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public TransferEventHandler()
        {

        }

        public Task Handle(TransferCreatedEvent @event)
        {
            var transferLog = new TransferLog
            {
                FromAccount = @event.From, ToAccount = @event.To, TransferAmount = @event.Amount
            };

            return _transferRepository.Add(transferLog);
        }
    }
}
