namespace Pr_Signal_ir.MVC.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    namespace Pr_Signal_ir.MVC.Models.CommentToBlog
    {
        public class CommentToBlogVM:BaseDomainEntity
        {
            public string Text { get; set; }

            public string FullName { get; set; }

            public string Email { get; set; }

            public string? WebSite { get; set; }
            public int BlogId { get; set; }

            public int? CommentSubId { get; set; }
            public int? Like { get; set; }
            public virtual BlogVM? Blog { get; set; }



        }

        public class CreateCommentToBlogVM:BaseDomainEntity
        {
            public string Text { get; set; }

            public string FullName { get; set; }

            public string Email { get; set; }

            public string? WebSite { get; set; }
            public int BlogId { get; set; }

            public int? CommentSubId { get; set; }
            public int? Like { get; set; }
            public DateTime? DateCreated { get; set; }
            public string? CreatedBy { get; set; }
        }
        public class UpdateCommentToBlogVM:BaseDomainEntity
        {
            public string Text { get; set; }

            public string FullName { get; set; }

            public string Email { get; set; }

            public string? WebSite { get; set; }
            public int BlogId { get; set; }

            public int? CommentSubId { get; set; }
            public int? Like { get; set; }
        }



    }

}
