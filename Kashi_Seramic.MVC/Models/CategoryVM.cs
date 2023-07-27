using Kashi_Seramic.Application.DTOs.FilterProduct;
using Pr_Signal_ir.MVC.Models.CategoryToBlog;
using Pr_Signal_ir.MVC.Models.CategoryToProduct;
using Pr_Signal_ir.MVC.Models.FilterProduct;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

namespace Pr_Signal_ir.MVC.Models.Category
{
    public class CategoryVM:BaseDomainEntity
        
    {
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public ICollection<FilterProductVM> FilterProduct { get; set; }
        public ICollection<CategoryToBlogVM> CategoryToBlog { get; set; }
        public ICollection<CategoryToProductVM> CategoryToProduct { get; set; }

        public CategoryVM()
        {
            CategoryToBlog=new List<CategoryToBlogVM>();
        }
    }

    public class CreateCategoryVM:BaseDomainEntity
    {
        public string Text { get; set; }
        public IFormFile FileHeader { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Type { get; set; }

    }
    public class UpdateCategoryVM:BaseDomainEntity
    {
        public string Text { get; set; }
        public IFormFile FileHeader { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Type { get; set; }
    }

    public class AdminCategoryVM : BaseDomainEntity
    {
    }

}
