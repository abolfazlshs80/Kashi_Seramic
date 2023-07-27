using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.DTOs.UserAddress;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetUserAddressListRequestHandler : IRequestHandler<GetUserAddressListRequest, List<UserAddressDto>>
    {
        private readonly IUserAddressRepository _rep_UserAddress;
        private readonly IMapper _mapper;

        public GetUserAddressListRequestHandler(IUserAddressRepository rep_UserAddress, IMapper mapper)
        {
            _rep_UserAddress = rep_UserAddress;
            _mapper = mapper;
        }

        public async Task<List<UserAddressDto>> Handle(GetUserAddressListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_UserAddress.GetAll();
            return _mapper.Map<List<UserAddressDto>>(leaveTypes);
        }
    }
}
