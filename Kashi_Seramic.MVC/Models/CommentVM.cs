
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToBlog;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToProduct;

namespace Pr_Signal_ir.MVC.Models
{
    public class CommentVM
    {
        public List<CommentToBlogVM> CommentToBlogVM { get; set; }
        public List<CommentToProductVM> CommentToProductVM { get; set; }
        public string Message { get; set; }
    }

  
}
