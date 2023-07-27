using Kashi_Seramic.Application.DTOs.Product;
using Kashi_Seramic.Domain;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.Contracts.Persistence
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<Product> GetProductWithDetails(int id);
        Task<List<Product>> GetProductsWithDetails();
        Task<bool> UpdateProduct(Product model);
        Task<List<Product>> GetProductsUserWithDetails(string userId);
        Task<bool> ProductExists(string userId, int ProductId);

    }
}
