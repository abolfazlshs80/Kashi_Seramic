
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

namespace Pr_Signal_ir.MVC.Models.CategoryToBlog
{
    public class CategoryToBlogVM

    {
        public int CategoryId { get; set; }
        public int BlogId { get; set; }

    }
    public class CreateCategoryToBlogVM
    {
        public int CategoryId { get; set; }
        public int BlogId { get; set; }
    }
    public class UpdateCategoryToBlogVM
    {
        public int CategoryId { get; set; }
        public int BlogId { get; set; }

    }

    public class AdminCategoryToBlogVM : BaseDomainEntity
    {
    }

}
