using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.CategoryToBlog;
using Pr_Signal_ir.MVC.Models.CategoryToBlog;
using Pr_Signal_ir.MVC.Models.FileToBlog;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface ICategoryToBlogService
    {

        Task<List<CategoryToBlogVM>> GetCategoryToBlogs();
        Task<CategoryToBlogVM> GetCategoryToBlogWithBlogId(int id);
        Task<CategoryToBlogVM> GetCategoryToBlogDWithCateId(int id);
    
        Task<Response<int>> CreateCategoryToBlog(CreateCategoryToBlogVM cate);
       
        Task<Response<int>> DeleteCategoryToBlog(int id);
        Task<Response<int>> DeleteCategoryToAnyBlog(int id);
        Task<Response<int>> ExistsCategoryToBlog(int id);
    }
}
