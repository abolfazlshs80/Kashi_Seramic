using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.DTOs.UserAddress;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetUserAddressDetailRequestHandler : IRequestHandler<GetUserAddressDetailRequest, UserAddressDto>
    {
        private readonly IUserAddressRepository _Repository;
        private readonly IMapper _mapper;

        public GetUserAddressDetailRequestHandler(IUserAddressRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<UserAddressDto> Handle(GetUserAddressDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.Get(request.Id);
            return _mapper.Map<UserAddressDto>(leaveType);
        }
    }
}
