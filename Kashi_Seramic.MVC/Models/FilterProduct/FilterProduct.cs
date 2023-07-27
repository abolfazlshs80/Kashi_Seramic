using Kashi_Seramic.Application.DTOs.FilterValueProduct;

using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.FileImages;

namespace Pr_Signal_ir.MVC.Models.FilterProduct
{
    public class FilterProductVM :BaseDomainEntity
    {
        public string Title { get; set; }
        public string TitleInBrowser { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
        public CategoryVM Categories { get; set; }
        public IEnumerable<FilterValueProductVM> FilterValueProduct { get; set; }

    }
    public class CreateFilterProductVM : BaseDomainEntity
    {
        public string Title { get; set; }
        public string TitleInBrowser { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
    }
    public class UpdateFilterProductVM : BaseDomainEntity
    {
        public string Title { get; set; }
        public string TitleInBrowser { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
    }

    public class AdminFilterProductVM : BaseDomainEntity
    {
        public string Title { get; set; }
        public string TitleInBrowser { get; set; }
        public string Text { get; set; }
        public int CategoryId { get; set; }
    }

}
