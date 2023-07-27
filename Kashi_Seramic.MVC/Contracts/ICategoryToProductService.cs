using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.CategoryToProduct;
using Pr_Signal_ir.MVC.Models.CategoryToProduct;
using Pr_Signal_ir.MVC.Models.FileToProduct;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface ICategoryToProductService
    {

        Task<List<CategoryToProductVM>> GetCategoryToProducts();
        Task<CategoryToProductVM> GetCategoryToProductWithProductId(int id);
        Task<CategoryToProductVM> GetCategoryToProductDWithCateId(int id);
    
        Task<Response<int>> CreateCategoryToProduct(CreateCategoryToProductVM cate);
       
        Task<Response<int>> DeleteCategoryToProduct(int id);
        Task<Response<int>> DeleteAnyCategoryToProduct(int id);
        Task<Response<int>> ExistsCategoryToProduct(int id);
    }
}
