using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.FaqUser
{
    public interface IFaqUserDto
    {
        public string Text { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string ReplayText { get; set; }
    }
}
