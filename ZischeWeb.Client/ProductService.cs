using System.Net.Http.Json;
using ZischeWeb.Shared.Models;

namespace ZischeWeb.Client
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("https://localhost:7179/Products");
        }
    }
}
