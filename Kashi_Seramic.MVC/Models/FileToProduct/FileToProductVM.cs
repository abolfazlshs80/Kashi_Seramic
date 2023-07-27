
using Pr_Signal_ir.MVC.Models.FileImages;

namespace Pr_Signal_ir.MVC.Models.FileToProduct
{
    public class FileToProductVM 
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public FileImagesVM FileManager { get; set; }
    }
    public class CreateFileToProductVM : BaseDomainEntity
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
    }
    public class UpdateFileToProductVM : BaseDomainEntity
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
    }

    public class AdminFileToProductVM : BaseDomainEntity
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
    }

}
