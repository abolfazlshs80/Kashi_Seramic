using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToBlog;
using Pr_Signal_ir.MVC.Services.Base;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface ICommentToBlogService
    {
        Task<List<CommentToBlogVM>> GetCommentToBlogs();
        Task<List<CommentToBlogVM>> GetCommentToBlogsByUserId(string id);
        Task<List<CommentToBlogVM>> GetCommentToBlogsGetByBlogId(int id);
        Task<CommentToBlogVM> GetCommentToBlogsDetails(int id);
        Task<Response<int>> CreateCommentToBlog(CreateCommentToBlogVM leaveType);
        Task<Response<int>> UpdateCommentToBlog(int id, UpdateCommentToBlogVM leaveType);
        Task<Response<int>> DeleteCommentToBlog(int id);
        Task<Response<bool>> ExistsCommentToBlog(int id);
    }
}
