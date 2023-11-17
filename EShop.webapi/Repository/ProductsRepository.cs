using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EShop.webapi.Models;
using EShop.webapi.Data;
using EShop.webapi.Services;

namespace EShop.webapi.Repository
{
    public class ProductsRepository : IProductsService
    {
        private readonly EshopContext _eshopContext;

        public ProductsRepository(EshopContext eshopContext){
            _eshopContext = eshopContext;
        }

        public async Task<Product[]> GetProductsAsync(){
        
            return await _eshopContext.Products.ToArrayAsync();
        }

        public async Task<Product> GetProductAsync(int id){
            return await _eshopContext.Products.FindAsync(id);
        }
    }
}