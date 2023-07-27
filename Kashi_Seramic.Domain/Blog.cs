using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Kashi_Seramic.Domain
{
    public class Blog : BaseDomainEntity
    {



        public string TitleBrowser { get; set; }

        public string ShortTitle { get; set; }

        public string LongTitle { get; set; }

        public string Text { get; set; }

        public int Seen { get; set; }
        public string LinkKey { get; set; }


        public ICollection<CategoryToBlog> CategoryToBlog { get; set; }
        public ICollection<FileToBlog> FileToBlog { get; set; }
        public ICollection<CommentToBlog> CommentToBlog { get; set; }
        public ICollection<TagToBlog> TagToBlog { get; set; }

    }
}
