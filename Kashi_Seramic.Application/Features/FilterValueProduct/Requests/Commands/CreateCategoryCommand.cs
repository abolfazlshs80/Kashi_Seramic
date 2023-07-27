﻿
using Kashi_Seramic.Application.DTOs.FaqUser;
using Kashi_Seramic.Application.DTOs.FilterValueProduct;
using Kashi_Seramic.Application.DTOs.Inventory;
using Kashi_Seramic.Application.Responses;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;

using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateFilterValueProductCommand : IRequest<BaseCommandResponse>
    {
        public CreateFilterValueProductDto CreateFilterValueProductDto { get; set; }

    }
}
