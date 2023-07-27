using Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.FileToProduct;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Services.Base;
using Pr_Signal_ir.MVC.Models.FileToProduct;

using Pr_Signal_ir.MVC.Models.FileImages;

namespace Pr_Signal_ir.MVC.Contracts
{
    public interface IFileToProductService
    {
        Task<List<FileToProductVM>> GetFileToProduct();
        Task<FileToProductVM> GetFileToProductWithProductId(int id);
        Task<FileImagesVM> GetPathWithProductId(int id);
        Task<FileToProductVM> GetFileToProductDWithImageId(int id);
        Task<Response<int>> CreateFileToProduct(CreateFileToProductVM leaveType);

        Task<Response<int>> DeleteFileToProduct(int id);
        Task<Response<bool>> ExistsFileToProduct(int id);
    }
}
