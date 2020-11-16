using ProductsConsumeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductsConsumeAPI.Services
{
    public class ProductAPIService : IProductAPIService
    {
        private readonly HttpClient _client;
        private JsonSerializerOptions _options;

        public ProductAPIService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<Product> GetProduct(int productId)
        {
            var response = await _client.GetAsync($"Products/{productId}");

            var jsonString = await response.Content.ReadAsStringAsync();

            var product =  JsonSerializer.Deserialize<Product>(jsonString, _options);

            return product;

        }

        public async Task<List<ProductOverview>> GetProducts()
        {
            var response = await _client.GetAsync("Products.");

            var jsonString = await response.Content.ReadAsStringAsync();

            var productsList = JsonSerializer.Deserialize<List<ProductOverview>>(jsonString, _options);

            return productsList;
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByMaxPrice(decimal maxPrice)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsBySupplier(int supplierId)
        {
            throw new NotImplementedException();
        }
    }
}
