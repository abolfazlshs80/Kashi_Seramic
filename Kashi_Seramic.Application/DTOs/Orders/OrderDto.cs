using Kashi_Seramic.Application.DTOs.OrderDetials;
using Pr_Signal_ir.Application.DTOs.CategoryToBlog;
using Pr_Signal_ir.Application.DTOs.CommentToBlog;
using Pr_Signal_ir.Application.DTOs.Common;
using Pr_Signal_ir.Application.DTOs.FileToBlog;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Order
{
    public class OrdersDto : BaseDto
    {
        public bool TeacherPaymentStatus { get; set; }
        public string UserId { get; set; }
        public bool Finaly { get; set; }

        public ICollection<OrderDetialsDto> orderDetails { get; set; }

    }
}
