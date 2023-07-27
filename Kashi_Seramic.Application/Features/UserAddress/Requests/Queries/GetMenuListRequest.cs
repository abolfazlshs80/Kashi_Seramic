
using Kashi_Seramic.Application.DTOs.UserAddress;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetUserAddressListRequest : IRequest<List<UserAddressDto>>
    {
    }
}
