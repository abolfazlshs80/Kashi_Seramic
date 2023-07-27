using Kashi_Seramic.Application.DTOs.FilterProduct;
using Pr_Signal_ir.Application.Contracts.Persistence;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.Contracts.Persistence
{
    public interface IFilterProductRepository : IGenericRepository<FilterProduct>
    {
        Task<FilterProduct> GetFilterProductWithDetails(int id);
        Task<List<FilterProduct>> GetFilterProductsWithDetails();

        Task<bool> FilterProductExists(string userId, int FilterProductId);

    }
}
