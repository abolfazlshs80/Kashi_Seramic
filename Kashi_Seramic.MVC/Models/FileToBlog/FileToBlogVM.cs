
using Pr_Signal_ir.MVC.Models.FileImages;

namespace Pr_Signal_ir.MVC.Models.FileToBlog
{
    public class FileToBlogVM 
    {
        public int ImageId { get; set; }
        public int BlogId { get; set; }
        public FileImagesVM FileManager { get; set; }
    }
    public class CreateFileToBlogVM : BaseDomainEntity
    {
        public int ImageId { get; set; }
        public int BlogId { get; set; }
    }
    public class UpdateFileToBlogVM : BaseDomainEntity
    {
        public int ImageId { get; set; }
        public int BlogId { get; set; }
    }

    public class AdminFileToBlogVM : BaseDomainEntity
    {
        public int ImageId { get; set; }
        public int BlogId { get; set; }
    }

}
