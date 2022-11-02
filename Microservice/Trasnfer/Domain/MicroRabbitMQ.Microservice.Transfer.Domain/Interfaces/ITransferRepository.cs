using MicroRabbitMQ.Microservice.Transfer.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroRabbitMQ.Microservice.Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<TransferLog> GetTransferLogs();

        Task Add(TransferLog transferLog); 
    }
}
