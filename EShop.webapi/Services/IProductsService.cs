using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.webapi.Models;

namespace EShop.webapi.Services
{
    public interface IProductsService
    {
        Task<Product[]> GetProductsAsync();

        Task<Product> GetProductAsync(int id);
    }
}