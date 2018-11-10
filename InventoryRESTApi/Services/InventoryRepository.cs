using InventoryRESTApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryRESTApi.Services
{
    public class InventoryRepository : IInventoryRepository
    {
        private InventoryContext _context;

        public InventoryRepository(InventoryContext context)
        {
            _context = context;
        }
        public void AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            _context.Products.Add(product);

        }
        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
        }
        public void UpdateProduct(Product product)
        {
            // no code in this implementation
        }
        public bool ProductExists(Guid productId)
        {
            return _context.Products.Any(p => p.Id == productId);
        }

        public IEnumerable<Product> GetProducts(IEnumerable<Guid> productIds)
        {
            return _context.Products.Where(p => productIds.Contains(p.Id))
                .OrderBy(p => p.Name)
                .ToList();
        }
        public Product GetProduct(Guid productId)
        {
            return _context.Products.FirstOrDefault(p => p.Id == productId);
        }


    }
}
