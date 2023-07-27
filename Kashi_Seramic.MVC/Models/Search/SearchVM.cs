using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models;

namespace Pr_Signal_ir.MVC.Models.Search
{
  
    public class SearchVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Type { get; set; }
        public string Tage { get; set; }
        public string path { get; set; }
        public string Url { get; set; }
        public string Owener { get; set; }
        public DateTime Date { get; set; }
        public BlogVM Blog { get; set; }
        public ProductVM Product { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
    
}
