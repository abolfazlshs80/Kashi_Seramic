using Pr_Signal_ir.Application.DTOs.Blog;

using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kashi_Seramic.Application.DTOs.Slider
{
    public class SliderDto : BaseDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string PathImage { get; set; }
        public int Order { get; set; }


    }
}
