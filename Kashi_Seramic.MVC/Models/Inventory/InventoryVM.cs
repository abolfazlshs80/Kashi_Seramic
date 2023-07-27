using Kashi_Seramic.Application.DTOs.Inventory;

using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.FileImages;

namespace Pr_Signal_ir.MVC.Models.FilterProduct
{
    public class InventoryVM: BaseDomainEntity
    {
        public string Title { get; set; }
        public string TitleInBrowser { get; set; }
        public string Text { get; set; }



    }
    public class CreateInventoryVM : BaseDomainEntity
    {
        public string Title { get; set; }
        public string TitleInBrowser { get; set; }
        public string Text { get; set; }
    }
    public class UpdateInventoryVM : BaseDomainEntity
    {
        public string Title { get; set; }
        public string TitleInBrowser { get; set; }
        public string Text { get; set; }
    }

    public class AdminInventoryVM : BaseDomainEntity { 
     public string Title { get; set; }
    public string TitleInBrowser { get; set; }
    public string Text { get; set; }
}

}
