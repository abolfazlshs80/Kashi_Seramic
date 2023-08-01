using Pr_Signal_ir.MVC.Models.FilterToProduct;

namespace Pr_Signal_ir.MVC.Models
{

 
    using global::Pr_Signal_ir.MVC.Models.CategoryToProduct;
 
    using global::Pr_Signal_ir.MVC.Models.FileToProduct;
    using global::Pr_Signal_ir.MVC.Models.OrderDetials;
    using global::Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToProduct;
    using global::Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Setting;
    using global::Pr_Signal_ir.MVC.Models.TagToProduct;
    using Kashi_Seramic.Domain;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Pr_Signal_ir.MVC.Models
    {
        public class ProductVM: BaseDomainEntity
        {
            public string Title { get; set; }
            public string TitleInBrowser { get; set; }
            public string Text { get; set; }
            public decimal Price { get; set; }
            public string Type { get; set; }
            public decimal OffPrice { get; set; }
            public int Qountity { get; set; }
            public int Seen { get; set; }
            public string LinkKey { get; set; }
            public SettingVM Setting { get; set; }
            public IEnumerable<OrderDetialsVM> orderDetails { get; set; }
            public IEnumerable<CategoryToProductVM> CategoryToProduct { get; set; }
            public IEnumerable<FileToProductVM> FileToProduct { get; set; }
            public IEnumerable<CommentToProductVM> CommentToProduct { get; set; }
            public IEnumerable<TagToProductVM> TagToProduct { get; set; }
            public ICollection<FilterToProductVM> FilterToProduct { get; set; }

        }

        public class CreateProductVM : BaseDomainEntity
        {
            public List<int> CategoryId { get; set; }
            public IFormFile FileForDetials { get; set; }
            public IFormFile FileHeader { get; set; }
            public List<int> TagId { get; set; }
            public List<int> FilterId { get; set; }
            public CreateProductVM()
            {
      
            }
            public string Title { get; set; }
            public string TitleInBrowser { get; set; }
            public string Text { get; set; }
            public decimal Price { get; set; }

            public decimal OffPrice { get; set; }
            public int Qountity { get; set; }
            public int Seen { get; set; }
            public string LinkKey { get; set; }

        }

        public class EditProductVM
        {
          
        }
        public class UpdateProductVM : BaseDomainEntity
        {
            public List<int> CategoryId { get; set; }
            public IFormFile FileForDetials { get; set; }
            public IFormFile FileHeader { get; set; }
            public List<int> TagId { get; set; }
            public List<int> FilterId { get; set; }
            public string Title { get; set; }
            public string TitleInBrowser { get; set; }
            public string Text { get; set; }
            public decimal Price { get; set; }

            public decimal OffPrice { get; set; }
            public int Qountity { get; set; }
            public int Seen { get; set; }
            public string LinkKey { get; set; }
        }


 

    }

}
