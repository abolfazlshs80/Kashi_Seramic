using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Blog
{
    public interface IBlogDto
    {

        public string TitleBrowser { get; set; }

        public string ShortTitle { get; set; }

        public string LongTitle { get; set; }

        public string Text { get; set; }

        public int Seen { get; set; }
        public string Tag { get; set; }

    }
}
