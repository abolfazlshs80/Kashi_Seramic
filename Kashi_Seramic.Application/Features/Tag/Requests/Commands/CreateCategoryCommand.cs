
using Kashi_Seramic.Application.DTOs.Tag;
using Kashi_Seramic.Application.Responses;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateTagCommand : IRequest<BaseCommandResponse>
    {
        public CreateTagDto CreateTagDto { get; set; }

    }
}
