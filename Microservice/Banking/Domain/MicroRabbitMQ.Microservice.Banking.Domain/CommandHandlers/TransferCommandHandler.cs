using MediatR;
using MicroRabbitMQ.Domain.Core.Bus;
using MicroRabbitMQ.Microservice.Banking.Domain.Commands;
using MicroRabbitMQ.Microservice.Banking.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Microservice.Banking.Domain.CommandHandlers
{
    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {
        private readonly IEventBus _bus;

        public TransferCommandHandler(IEventBus bus)
        {
            _bus = bus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {

            _bus.Publish(new TransferCreatedEvent(from: request.From, to: request.To, amount: request.Amount));

            return Task.FromResult(true);
        }
    }
}
