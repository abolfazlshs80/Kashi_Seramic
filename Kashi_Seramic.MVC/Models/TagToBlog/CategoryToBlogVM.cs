
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Tag;


namespace Pr_Signal_ir.MVC.Models.TagToBlog
{
    public class TagToBlogVM

    {
        public int TagId { get; set; }
        public int BlogId { get; set; }

        public virtual TagVM Tag { get; set; }
        public virtual BlogVM Blog { get; set; }
    }
    public class CreateTagToBlogVM
    {
        public int TagId { get; set; }
        public int BlogId { get; set; }
    }
    public class UpdateTagToBlogVM
    {
        public int TagId { get; set; }
        public int BlogId { get; set; }

    }

    public class AdminTagToBlogVM
    {
        public int TagId { get; set; }
        public int BlogId { get; set; }
    }

}
