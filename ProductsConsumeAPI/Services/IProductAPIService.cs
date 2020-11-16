using ProductsConsumeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsConsumeAPI.Services
{
    public interface IProductAPIService
    {
        public Task<List<ProductOverview>> GetProducts();

        public Task<Product> GetProduct(int productId);

        public List<Product> GetProductsByCategory(int categoryId);

        public List<Product> GetProductsBySupplier(int supplierId);

        public List<Product> GetProductsByMaxPrice(decimal maxPrice);
    }
}
