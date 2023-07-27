
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Ticket
{
    public interface ITicketDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public bool Status { get; set; }


    }
}
