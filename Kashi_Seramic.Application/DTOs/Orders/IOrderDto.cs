
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Order
{
    public interface IOrdersDto
    {
        public string UserId { get; set; }
        public bool TeacherPaymentStatus { get; set; }
        public bool Finaly { get; set; }

    }
}
