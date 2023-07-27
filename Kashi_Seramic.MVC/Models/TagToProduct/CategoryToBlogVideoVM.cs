
using Pr_Signal_ir.MVC.Models.FileImages;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Tag;

namespace Pr_Signal_ir.MVC.Models.TagToProduct
{
    public class TagToProductVM:BaseDomainEntity

    {
        public int TagId { get; set; }
        public int ProductId { get; set; }

        public virtual TagVM Tag { get; set; }
        public virtual ProductVM Product { get; set; }
    }
    public class CreateTagToProductVM:BaseDomainEntity
    {
        public int TagId { get; set; }
        public int ProductId { get; set; }
    }
    public class UpdateTagToProductVM : BaseDomainEntity
    {
        public int TagId { get; set; }
        public int ProductId { get; set; }
    }

    public class AdminTagToProductVM : BaseDomainEntity
    {
        public int TagId { get; set; }
        public int ProductId { get; set; }

    }

}
