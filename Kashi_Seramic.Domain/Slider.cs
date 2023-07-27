using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Kashi_Seramic.Domain.Common;

namespace Kashi_Seramic.Domain
{
    public class Slider:BaseDomainEntity
    {
        public string Title { get; set; }
        [AllowHtml]
        public string Text { get; set; }
        public string PathImage { get; set; }
        public int Order { get; set; }

    }
}
