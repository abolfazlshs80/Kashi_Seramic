using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.FileToBlog;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using Pr_Signal_ir.MVC.Models.FileToBlog;

using Pr_Signal_ir.MVC.Models.FileImages;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IFileToBlogService
    {
        Task<List<FileToBlogVM>> GetFileToBlog();
        Task<FileToBlogVM> GetFileToBlogWithBlogId(int id);
        Task<FileImagesVM> GetPathWithBlogId(int id);
        Task<FileToBlogVM> GetFileToBlogDWithImageId(int id);
        Task<Response<int>> CreateFileToBlog(CreateFileToBlogVM leaveType);

        Task<Response<int>> DeleteFileToBlog(int id);
        Task<Response<bool>> ExistsFileToBlog(int id);
    }
}
