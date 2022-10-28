using MicroRabbitMQ.Domain.Core.Bus;
using MicroRabbitMQ.Microservice.Banking.Application.Interfaces;
using MicroRabbitMQ.Microservice.Banking.Application.Models;
using MicroRabbitMQ.Microservice.Banking.Domain.Commands;
using MicroRabbitMQ.Microservice.Banking.Domain.Interfaces;
using MicroRabbitMQ.Microservice.Banking.Domain.Models;
using System.Collections.Generic;

namespace MicroRabbitMQ.Microservice.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountRepository, IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }
        
        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var transferCreateCommand = new CreateTransferCommand
            (
                accountTransfer.FromAccount,
                accountTransfer.ToAccount,
                accountTransfer.TransferAmount
            );

            _bus.SendCommand(transferCreateCommand);
        }
    }
}
