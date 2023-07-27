using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.Search;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface ICategoryService
    {

        Task<List<CategoryVM>> GetCategorys();
        Task<List<CategoryVM>> GetCategorysActive();
        Task<CategoryVM> GetCategorysDetails(int id);
        Task<IEnumerable<SearchVM>> GetBlogsCategoryBySearchVM(int cateid);
        Task<Response<int>> CreateCategory(CreateCategoryVM cate);
        Task<Response<int>> UpdateCategory(int id, UpdateCategoryVM cate);
        Task<Response<int>> DeleteCategory(int id);
        Task<Response<int>> ExistsCategory(int id);
    }
}
