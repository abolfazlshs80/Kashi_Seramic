using Pr_Signal_ir.MVC.Models.TagToBlog;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.TagToProduct;

namespace Pr_Signal_ir.MVC.Models.Tag
{
    public class TagVM:BaseDomainEntity
        
    {
        public string Name { get; set; }
      public IEnumerable<TagToBlogVM> TagToBlog { get; set; }
        public IEnumerable<TagToProductVM> TagToProduct { get; set; }
    }

    public class CreateTagVM : BaseDomainEntity
    {

        public string Name { get; set; }
        public ICollection<TagToBlogVM> TagToBlog { get; set; }
    }
    public class UpdateTagVM:BaseDomainEntity
    {
        public string Name { get; set; }
    }

    public class AdminTagVM : BaseDomainEntity
    {
    }
    
}
