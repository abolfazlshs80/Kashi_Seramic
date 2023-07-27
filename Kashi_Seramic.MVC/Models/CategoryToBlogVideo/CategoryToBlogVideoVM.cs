
using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

namespace Pr_Signal_ir.MVC.Models.CategoryToProduct
{
    public class CategoryToProductVM:BaseDomainEntity

    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
        public ProductVM Product { get; set; }
        public CategoryVM Category { get; set; }
    }
    public class CreateCategoryToProductVM:BaseDomainEntity
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
    }
    public class UpdateCategoryToProductVM : BaseDomainEntity
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }
    }

    public class AdminCategoryToProductVM : BaseDomainEntity
    {
    }

}
