using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.Features.OrderDetials.Requests.Queries;
using Kashi_Seramic.Application.DTOs.OrderDetials;

namespace Kashi_Seramic.Application.Features.OrderDetials.Handlers.Queries
{
    public class GetOrderDetialsDetailRequestHandler : IRequestHandler<GetOrderDetialsDetailRequest, OrderDetialsDto>
    {
        private readonly IOrderDetailsRepository _Repository;
        private readonly IMapper _mapper;

        public GetOrderDetialsDetailRequestHandler(IOrderDetailsRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<OrderDetialsDto> Handle(GetOrderDetialsDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetOrderDetialsWithDetails(request.Id);
            return _mapper.Map<OrderDetialsDto>(leaveType);
        }
    }
}
