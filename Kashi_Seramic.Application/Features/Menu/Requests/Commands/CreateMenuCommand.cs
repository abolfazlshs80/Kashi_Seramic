
using Kashi_Seramic.Application.DTOs.Menu;
using Kashi_Seramic.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateMenuCommand : IRequest<BaseCommandResponse>
    {
        public CreateMenuDto CreateMenuDto { get; set; }

    }
}
