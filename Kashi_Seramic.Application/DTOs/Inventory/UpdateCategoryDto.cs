
using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Inventory
{
    public class UpdateInventoryDto : BaseDto, IInventoryDto
    {
        public string Title { get; set; }
        public string TitleInBrowser { get; set; }
        public string Text { get; set; }
    }
}
