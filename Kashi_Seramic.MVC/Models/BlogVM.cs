using Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.Setting;

namespace Pr_Signal_ir.MVC.Models
{
    using global::Pr_Signal_ir.Application.DTOs.FileToBlog;
    using global::Pr_Signal_ir.MVC.Models.CategoryToBlog;
    using global::Pr_Signal_ir.MVC.Models.FileToBlog;
    using global::Pr_Signal_ir.MVC.Models.Pr_Signal_ir.MVC.Models.CommentToBlog;
    using global::Pr_Signal_ir.MVC.Models.TagToBlog;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Pr_Signal_ir.MVC.Models
    {
        public class BlogVM : BaseDomainEntity
        {
            public string TitleBrowser { get; set; }

            public string ShortTitle { get; set; }

            public string LongTitle { get; set; }

            public string Text { get; set; }

            public int Seen { get; set; }
            public string Tag { get; set; }
            public string LinkKey { get; set; }


            public SettingVM Setting { get; set; }
            public ICollection<CategoryToBlogVM> CategoryToBlog { get; set; }
            public ICollection<FileToBlogVM> FileToBlog { get; set; }
            public ICollection<CommentToBlogVM> CommentToBlog { get; set; }
            public ICollection<TagToBlogVM> TagToBlog { get; set; }

        }
        public class CreateBlogVM : BaseDomainEntity
        {
            public CreateBlogVM()
            {
                //LognName = "LognName" + new Random().Next(0, 999999);
                //    ShortName = "ShortName" + new Random().Next(0, 999999);
                //    TitleBrowser = "TitleBrowser" + new Random().Next(0, 999999);
                //    Tag = "Tag" + new Random().Next(0, 999999);
                //    Text = "Text" + new Random().Next(0, 999999);
                //    Show = false;
            }

            public IFormFile FileForDetials { get; set; }
            public IFormFile FileHeader { get; set; }
            public string TitleBrowser { get; set; }

            public string ShortTitle { get; set; }

            public string LongTitle { get; set; }

            public string Text { get; set; }

            public int Seen { get; set; }
            public string Tag { get; set; }
            public List<int> TagId { get; set; }
            public string LinkKey { get; set; }
            public List<int> CategoryId { get; set; }

        }

        public class EditBlogVM: BaseDomainEntity
        {
            public int Id { get; set; }
            [Display(Name = "عنوان نمایش در مرورگر")]
            public string TitleBrowser { get; set; }
            [Display(Name = "عنوان   ")]
            public string ShortName { get; set; }
            public int CategoryId { get; set; }

            public IFormFile FileForDetials { get; set; }

            public IFormFile FileHeader { get; set; }
            [Display(Name = "عنوان   ")]
            public string LognName { get; set; }
            [Display(Name = "متن مقاله")]
            public string Text { get; set; }


            public bool Show { get; set; }
            [Display(Name = "تگ های مقاله")]
            public string Tag { get; set; }
            public string UserId { get; set; } = "8e445865-a24d-4543-a6c6-9443d048cdb9";
        }
        public class UpdateBlogVM : BaseDomainEntity
        {
            public List<int> CategoryId { get; set; }
            public List<int> TagId { get; set; }
            public string TitleBrowser { get; set; }

            public string ShortTitle { get; set; }

            public string LongTitle { get; set; }
            public IFormFile FileForDetials { get; set; }
            public IFormFile FileHeader { get; set; }
            public string Text { get; set; }
        }

        public class AdminBlogVMViewVM : BaseDomainEntity
        {
            public string TitleBrowser { get; set; }
            public bool Show { get; set; }
            public DateTime CreateDate { get; set; }

            public string UserId { get; set; }
        }

    }
    }

   


    


