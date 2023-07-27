
using Pr_Signal_ir.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.FaqUser
{
    public class CreateFaqUserDto : BaseDto, IFaqUserDto
    {
        public string Text { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string ReplayText { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
    }
}
