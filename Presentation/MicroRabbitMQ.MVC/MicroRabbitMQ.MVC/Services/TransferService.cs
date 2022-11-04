using MicroRabbitMQ.MVC.Models.DTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroRabbitMQ.MVC.Services
{
    public interface ITransferService
    {
        Task Transfer(TransferDto transferDto);
    }

    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;

        public TransferService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task Transfer(TransferDto transferDto)
        {
            var uri = "https://localhost:5001/api/Banking";
            var transferContent = new StringContent(
                JsonConvert.SerializeObject(transferDto), 
                System.Text.Encoding.UTF8, "application/json");

            var response = await _apiClient.PostAsync(uri, transferContent);
            response.EnsureSuccessStatusCode();


        }
    }
}
