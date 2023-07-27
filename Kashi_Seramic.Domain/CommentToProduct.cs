using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Xml.Linq;

using Kashi_Seramic.Domain.Common;


namespace Kashi_Seramic.Domain
{
    public class CommentToProduct : BaseDomainEntity
    {
  
        //[AllowHtml]
        public string Text { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string? WebSite { get; set; }
        public int ProductId { get; set; }
        public bool? Status { get; set; } = false;
        public int? CommentSubId { get; set; } = 0;
   
        public int? Like { get; set; } = 0;
        public virtual Product? Product { get; set; }
    }
}
