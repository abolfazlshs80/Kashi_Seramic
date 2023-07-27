using Kashi_Seramic.Application.DTOs.FilterValueProduct;
using Pr_Signal_ir.Application.Contracts.Persistence;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.Contracts.Persistence
{
    public interface IFilterValueProductRepository : IGenericRepository<FilterValueProduct>
    {
        Task<FilterValueProduct> GetFilterValueProductWithDetails(int id);
        Task<List<FilterValueProduct>> GetFilterValueProductsWithDetails();

        Task<bool> FilterValueProductExists(string userId, int FilterValueProductId);

    }
}
