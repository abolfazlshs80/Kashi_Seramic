using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Search;
using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<Models.Pr_Signal_ir.MVC.Models.ProductVM>> GetProducts();
        Task<IEnumerable<Models.Pr_Signal_ir.MVC.Models.ProductVM>> GetProductsActive();
        Task<IEnumerable<Models.Pr_Signal_ir.MVC.Models.ProductVM>> GetProductsTopByNumber(int number);
        Task<IEnumerable<Models.Pr_Signal_ir.MVC.Models.ProductVM>> GetProductsToLasted();
        Task<IEnumerable<Models.Pr_Signal_ir.MVC.Models.ProductVM>> GetProductsByUserId(string UserId);
        Task<IEnumerable<SearchVM>> GetProductsBySearchVM(string text);
        Task<List<SearchVM>> GetProductsCategoryBySearchVM(int cateid);
        Task<List<SearchVM>> GetProductsCategoryBySearchVM();
        Task<List<SearchVM>> GetProductsCategoryByTag(string name);
        Task<List<SearchVM>> GetProductsCategoryByFilter(string name);
        Task<List<SearchVM>> GetProductsCategoryByCategory(string name);

        Task<Models.Pr_Signal_ir.MVC.Models.ProductVM> GetProductsDetails(int id);
        Task<Response<int>> CreateProduct(CreateProductVM leaveType);
        Task<Response<int>> UpdateProduct(int id, Models.Pr_Signal_ir.MVC.Models.UpdateProductVM leaveType);
        Task<Response<int>> UpdateProduct(int id);
        Task<Response<int>> DeleteProduct(int id);
        Task<Response<bool>> ExistsProduct(int id);
        Task<Response<bool>> UserIsOwner(string UserId,int id);
    }
}
