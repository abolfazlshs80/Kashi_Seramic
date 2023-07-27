
using Kashi_Seramic.Application.DTOs.UserAddress;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateUserAddressCommand : IRequest<Unit>
    {
        public UpdateUserAddressDto UserAddressDto { get; set; }
        public int Id { get; set; }

    }
}
