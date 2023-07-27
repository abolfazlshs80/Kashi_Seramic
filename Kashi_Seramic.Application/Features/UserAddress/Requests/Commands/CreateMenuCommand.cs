
using Kashi_Seramic.Application.DTOs.UserAddress;
using Kashi_Seramic.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateUserAddressCommand : IRequest<BaseCommandResponse>
    {
        public CreateUserAddressDto CreateUserAddressDto { get; set; }

    }
}
