using Kashi_Seramic.Application.DTOs.OrderSatus;

using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.FileImages;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Order;

namespace Pr_Signal_ir.MVC.Models.FilterProduct
{
    public class OrderSatusVM: BaseDomainEntity
    {
        public int OrderId { get; set; }

        public OrderVM Orders { get; set; }



    }
    public class CreateOrderSatusVM : BaseDomainEntity
    {
        public int OrderId { get; set; }

        public OrderVM Orders { get; set; }
    }
    public class UpdateOrderSatusVM : BaseDomainEntity
    {
      public int OrderId { get; set; }

        public OrderVM Orders { get; set; }
    }

    public class AdminOrderSatusVM : BaseDomainEntity
    { 
     public string Title { get; set; }
    public string TitleInBrowser { get; set; }
    public string Text { get; set; }
}

}
