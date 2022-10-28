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
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbitMQ.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            // Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();

            // Domain Banking Commands
            services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();

            // Application Services
            services.AddTransient<IAccountService, AccountService>();

            // Data
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();


        }
    }
}
