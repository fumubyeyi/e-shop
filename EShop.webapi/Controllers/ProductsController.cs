using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EShop.webapi.Services;

using EShop.webapi.Data;

namespace EShop.webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService service)
        {
            _productsService = service;
        }

        // GET api/products
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var products = await _productsService.GetProductsAsync();
            return Ok(products);
        } 

        // GET api/products/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id){
            var product = await _productsService.GetProductAsync(id);
            return Ok(product);
        }
    }
}