using MicroRabbitMQ.Microservice.Transfer.Domain.Models;
using System.Collections.Generic;

namespace MicroRabbitMQ.Microservice.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        public IEnumerable<TransferLog> GetTransferLogs();
    }
}
