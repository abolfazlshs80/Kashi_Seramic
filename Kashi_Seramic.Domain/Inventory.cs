using Kashi_Seramic.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Domain
{
    public class Inventory:BaseDomainEntity
    {
        public string Title { get; set; }
        public string TitleInBrowser  { get; set; }
        public string Text { get; set; }
    }
}
