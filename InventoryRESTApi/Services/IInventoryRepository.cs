using InventoryRESTApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryRESTApi.Services
{
    public interface IInventoryRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(IEnumerable<Guid> productIds);
        Product GetProduct(Guid productId);
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
        bool ProductExists(Guid productId);
        bool Save();
    }
}
