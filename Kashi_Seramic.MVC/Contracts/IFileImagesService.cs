using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.FileImages;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;


namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IFileImagesService
    {
        Task<List<FileImagesVM>> GetFileImages();
        Task<FileImagesVM> GetFileImagesDetails(int id);
        Task<Response<int>> CreateFileImages(CreateFileImagesVM leaveType);
        Task<Response<int>> UpdateFileImages(int id, UpdateFileImagesVM leaveType);
        Task<Response<int>> DeleteFileImages(int id);
        Task<Response<bool>> ExistsFileImages(int id);
    }
}
