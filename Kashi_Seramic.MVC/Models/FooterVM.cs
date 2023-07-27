using Pr_Signal_ir.MVC.Models.Category;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;
using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Setting;


namespace Pr_Signal_ir.MVC.Models
{
    public class FooterVM
    {
        public IEnumerable<CategoryVM> CategoryVM { get; set; }
        public IEnumerable<BlogVM> BlogVM { get; set; }
        public IEnumerable<ProductVM> Product { get; set; }
        public SettingVM Setting { get; set; }
    }
}
