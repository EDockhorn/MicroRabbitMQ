using MicroRabbitMQ.Microservice.Transfer.Data.Context;
using MicroRabbitMQ.Microservice.Transfer.Domain.Interfaces;
using MicroRabbitMQ.Microservice.Transfer.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Microservice.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDbContext _ctx;

        public TransferRepository(TransferDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task Add(TransferLog transferLog)
        {
            _ctx.Add(transferLog);

            return Task.FromResult(_ctx.SaveChanges());
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return _ctx.TransferLog;
        }
    }
}
