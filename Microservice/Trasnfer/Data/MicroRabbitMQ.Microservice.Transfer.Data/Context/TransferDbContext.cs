using MicroRabbitMQ.Microservice.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbitMQ.Microservice.Transfer.Data.Context
{
    public class TransferDbContext : DbContext
    {

        public TransferDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<TransferLog> TransferLog { get; set; }
    }
}
