using Pr_Signal_ir.Application.DTOs.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Order;

public class CreateOrdersDto : IOrdersDto
{
    public bool TeacherPaymentStatus { get; set; }
    public string UserId { get; set; }
    public bool Finaly { get; set; }

    public DateTime? DateCreated { get; set; }
    public string? CreatedBy { get; set; }
}
