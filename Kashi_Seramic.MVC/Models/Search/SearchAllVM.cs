using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Setting;

namespace Pr_Signal_ir.MVC.Models.Search
{
    public class SearchAllVM
    {
        public SearchAllVM()
        {
            SearchVM=new List<SearchVM>();
        }
        public SettingVM Setting { get; set; }
        public List<SearchVM> SearchVM { get; set; }
        public IEnumerable<SearchVM> Search { get; set; }
        public string Path1 { get; set; }
        public string Path2 { get; set; }
        public string Desc { get; set; }
        public string Type { get; set; }
    }
}
