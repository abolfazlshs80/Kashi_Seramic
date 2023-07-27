
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Slider
{
    public interface ISliderDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string PathImage { get; set; }
        public int Order { get; set; }

    }
}
