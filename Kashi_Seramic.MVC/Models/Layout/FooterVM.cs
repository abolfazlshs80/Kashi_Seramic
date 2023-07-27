
    using Pr_Signal_ir.MVC.Models.Category;
    using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Setting;

    public class FooterVM
    {
        public SettingVM Setting { get; set; }  
        public IEnumerable<CategoryVM>  Categories { get; set; }  
    }

