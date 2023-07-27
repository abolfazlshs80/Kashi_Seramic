
using Kashi_Seramic.Application.DTOs.FilterProduct;
using Kashi_Seramic.Application.DTOs.Inventory;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;

using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateInventoryCommand : IRequest<Unit>
    {
        public UpdateInventoryDto InventoryDto { get; set; }
        public int Id { get; set; }

    }
}
