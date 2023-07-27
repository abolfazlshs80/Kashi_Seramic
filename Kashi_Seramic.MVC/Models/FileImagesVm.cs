using Pr_Signal_ir.Application.DTOs.FileToBlog;
using Pr_Signal_ir.MVC.Models.FileToBlog;
using Pr_Signal_ir.MVC.Models.FileToProduct;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

namespace Pr_Signal_ir.MVC.Models.FileImages
{



    public class FileImagesVM : BaseDomainEntity

    {
        public string Path { get; set; }

        public string Title { get; set; }
        public string? Type { get; set; }
        public bool IsUploaderFile { get; set; }
     //   public ICollection<FileToBlogVM> FileToBlog { get; set; }
        public ICollection<FileToProductVM> FileToProduct { get; set; }

    }

    public class CreateFileImagesVM : BaseDomainEntity
    {
        public string Path { get; set; }

        public string Title { get; set; }
        public string? Type { get; set; }
        public bool IsUploaderFile { get; set; }
    }
    public class UpdateFileImagesVM : BaseDomainEntity
    {
        public string Path { get; set; }

        public string Title { get; set; }
        public string? Type { get; set; }
        public bool IsUploaderFile { get; set; }
    }

    public class AdminFileImagesVM : BaseDomainEntity
    {
    }


}
