using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.FilterToProduct;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using Pr_Signal_ir.MVC.Models.FilterToProduct;


namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IFilterToProductService
    {
        Task<List<FilterToProductVM>> GetFilterToProduct();
        Task<FilterToProductVM> GetFilterToProductWithProductId(int id);

        Task<FilterToProductVM> GetFilterToProductDWithImageId(int id);
        Task<Response<int>> CreateFilterToProduct(CreateFilterToProductVM leaveType);

        Task<Response<int>> DeleteFilterToProduct(int id);
        Task<Response<int>> DeleteAnyFilterToProduct(int ProductId);
        Task<Response<bool>> ExistsFilterToProduct(int id);
    }
}
