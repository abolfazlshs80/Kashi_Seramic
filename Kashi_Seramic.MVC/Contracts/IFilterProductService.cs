using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.FilterProduct;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IFilterProductService
    {
        Task<List<FilterProductVM>> GetFilterProducts();
        Task<List<FilterProductVM>> GetFilterProductsByCatId(int cateId);
        Task<FilterProductVM> GetFilterProductsDetails(int id);
        Task<Response<int>> CreateFilterProduct(CreateFilterProductVM leaveType);
        Task<Response<int>> UpdateFilterProduct(int id,UpdateFilterProductVM leaveType);
        Task<Response<int>> DeleteFilterProduct(int id);
    }
}
