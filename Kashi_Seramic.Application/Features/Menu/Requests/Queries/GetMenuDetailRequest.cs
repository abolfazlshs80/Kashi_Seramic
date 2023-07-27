
using Kashi_Seramic.Application.DTOs.Menu;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetMenuDetailRequest : IRequest<MenuDto>
    {
        public int Id { get; set; }
    }
}
