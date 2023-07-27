using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToBlog;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToProduct;
using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface ICommentToProductService
    {
        Task<List<CommentToProductVM>> GetCommentToProducts();
        Task<List<CommentToProductVM>> GetCommentToProductsByUserId(string id);
        Task<List<CommentToProductVM>> GetCommentToBlogsGetByProductId(int id);
        Task<CommentToProductVM> GetCommentToProductsDetails(int id);
        Task<Response<int>> CreateCommentToProduct(CreateCommentToProductVM leaveType);
        Task<Response<int>> UpdateCommentToProduct(int id, UpdateCommentToProductVM leaveType);
        Task<Response<int>> DeleteCommentToProduct(int id);
        Task<Response<bool>> ExistsCommentToProduct(int id);
    }
}
