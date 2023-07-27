namespace Pr_Signal_ir.MVC.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Pr_Signal_ir.MVC.Models.CommentToProduct
    {
        public class CommentToProductVM: BaseDomainEntity
        {

            public string Text { get; set; }

            public string FullName { get; set; }

            public string Email { get; set; }

            public string? WebSite { get; set; }
            public int ProductId { get; set; }
            public int? CommentSubId { get; set; } = 0;

            public int? Like { get; set; } = 0;
            public virtual ProductVM? Product { get; set; }



        }

        public class CreateCommentToProductVM:BaseDomainEntity
        {
            public string Text { get; set; }

            public string FullName { get; set; }

            public string Email { get; set; }

            public string? WebSite { get; set; }
            public int ProductId { get; set; }
            public int? CommentSubId { get; set; } = 0;

            public int? Like { get; set; } = 0;

        }
        public class UpdateCommentToProductVM:BaseDomainEntity
        {
 
        }

        public class AdminCommentToProductVMViewVM:BaseDomainEntity
        {
            public string Text { get; set; }

            public string FullName { get; set; }

            public string Email { get; set; }

            public string? WebSite { get; set; }
            public int ProductId { get; set; }
            public int? CommentSubId { get; set; } = 0;

            public int? Like { get; set; } = 0;
            public bool Status { get; set; } = false;


            public virtual ProductVM Product { get; set; }
        }


    }

}
