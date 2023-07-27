
using Kashi_Seramic.Application.DTOs.FilterProduct;
using Kashi_Seramic.Application.DTOs.Product;
using Kashi_Seramic.Domain;
using Pr_Signal_ir.MVC.Models.FilterProduct;

namespace Pr_Signal_ir.MVC.Models.FilterToProduct
{
    public class FilterToProductVM 
    {
        public int FilterId { get; set; }
        public int ProductId { get; set; }

        public ProductVM Product { get; set; }

        public FilterValueProductVM FilterValueProduct { get; set; }
    }
    public class CreateFilterToProductVM : BaseDomainEntity
    {
        public int FilterId { get; set; }
        public int ProductId { get; set; }
    }
    public class UpdateFilterToProductVM : BaseDomainEntity
    {
        public int FilterId { get; set; }
        public int ProductId { get; set; }
    }

    public class AdminFilterToProductVM : BaseDomainEntity
    {
        public int FilterId { get; set; }
        public int ProductId { get; set; }
    }

}
