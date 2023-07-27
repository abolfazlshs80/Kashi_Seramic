using Kashi_Seramic.Domain;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.FilterProduct;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IFilterValueProductService
    {
        Task<List<FilterValueProductVM>> GetFilterValueProducts();
        Task<List<FilterValueProductVM>> GetFilterValueProductsByFilterId(int id);
        Task<FilterValueProductVM> GetFilterValueProductsDetails(int id);
        Task<Response<int>> CreateFilterValueProduct(CreateFilterValueProductVM leaveType);
        Task<Response<int>> UpdateFilterValueProduct(int id, UpdateFilterValueProductVM leaveType);
        Task<Response<int>> DeleteFilterValueProduct(int id);
    }
}
