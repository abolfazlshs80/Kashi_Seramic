using Kashi_Seramic.Application.DTOs.FilterValueProduct;

using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.FileImages;

namespace Pr_Signal_ir.MVC.Models.FilterProduct
{
    public class FilterValueProductVM:BaseDomainEntity
    {
        public string Value { get; set; }
        public int FilterId { get; set; }
        public FilterProductVM FilterProduct { get; set; }



    }
    public class CreateFilterValueProductVM : BaseDomainEntity
    {
        public string Value { get; set; }
        public int FilterId { get; set; }
    }
    public class UpdateFilterValueProductVM : BaseDomainEntity
    {
        public string Value { get; set; }
        public int FilterId { get; set; }
    }

    public class AdminFilterValueProductVM : BaseDomainEntity
    {
        public string Value { get; set; }
        public int FilterId { get; set; }
    }

}
