
using Kashi_Seramic.Application.DTOs.Menu;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateMenuCommand : IRequest<Unit>
    {
        public UpdateMenuDto MenuDto { get; set; }
        public int Id { get; set; }

    }
}
