using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InventoryRESTApi.Entities;
using InventoryRESTApi.Models;
using InventoryRESTApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryRESTApi.Controllers
{
    [Route("api/products")]
    public class ProductsController : Controller
    {
        private IInventoryRepository _inventoryRepository;
        public ProductsController(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }
        [HttpGet()]
        public IActionResult GetProducts()
        {
            var productsFromRepo = _inventoryRepository.GetProducts();
            var products = Mapper.Map<IEnumerable<ProductDto>>(productsFromRepo);
            return Ok(products);
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult GetProduct(Guid id)
        {
            var productFromRepo = _inventoryRepository.GetProduct(id);
            if (productFromRepo == null)
            {
                return NotFound();
            }

            var product = Mapper.Map<ProductDto>(productFromRepo);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDto product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var productEntity = Mapper.Map<Product>(product);

            _inventoryRepository.AddProduct(productEntity);

            if (!_inventoryRepository.Save())
            {
                throw new Exception("Creating a product failed on save");
            }

            var productToReturn = Mapper.Map<ProductDto>(productEntity);

            return CreatedAtRoute("GetProduct", new { id = productToReturn.Id }, productToReturn);
        }
    }
}