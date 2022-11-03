using MediatR;
using MicroRabbitMQ.Domain.Core.Bus;
using MicroRabbitMQ.Infra.Bus;
using MicroRabbitMQ.Microservice.Banking.Application.Interfaces;
using MicroRabbitMQ.Microservice.Banking.Application.Services;
using MicroRabbitMQ.Microservice.Banking.Data.Context;
using MicroRabbitMQ.Microservice.Banking.Data.Repository;
using MicroRabbitMQ.Microservice.Banking.Domain.CommandHandlers;
using MicroRabbitMQ.Microservice.Banking.Domain.Commands;
using MicroRabbitMQ.Microservice.Banking.Domain.Interfaces;
using MicroRabbitMQ.Microservice.Transfer.Application.Interfaces;
using MicroRabbitMQ.Microservice.Transfer.Application.Services;
using MicroRabbitMQ.Microservice.Transfer.Data.Context;
using MicroRabbitMQ.Microservice.Transfer.Data.Repository;
using MicroRabbitMQ.Microservice.Transfer.Domain.EventHandlers;
using MicroRabbitMQ.Microservice.Transfer.Domain.Events;
using MicroRabbitMQ.Microservice.Transfer.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbitMQ.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            // Domain Bus
            services.AddSingleton<IEventBus, RabbitMQBus>(sp =>
            {
                var scope = sp.GetRequiredService<IServiceScopeFactory>();
                return new RabbitMQBus(sp.GetRequiredService<IMediator>(), scope);
            }
            );

            // Subscriptions
            services.AddTransient<TransferEventHandler>();

            // Domain Events
            services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            // Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Application Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ITransferService, TransferService>();

            // Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<ITransferRepository, TransferRepository>();

            services.AddTransient<BankingDbContext>();
            services.AddTransient<TransferDbContext>();


        }
    }
}
