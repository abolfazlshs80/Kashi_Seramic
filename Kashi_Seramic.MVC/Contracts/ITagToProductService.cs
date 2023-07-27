using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.TagToProduct;
using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface ITagToProductService
    {
        Task<List<TagToProductVM>> GetTagToProducts();
        Task<TagToProductVM> GetTagToProductsDetails(int id);
        Task<Response<int>> CreateTagToProduct(CreateTagToProductVM leaveType);
        Task<Response<int>> UpdateTagToProduct(int id,UpdateTagToProductVM leaveType);
        Task<Response<int>> DeleteTagToProduct(int id);
        Task<Response<int>> DeleteAnyTagToProduct(int productId);
    }
}
