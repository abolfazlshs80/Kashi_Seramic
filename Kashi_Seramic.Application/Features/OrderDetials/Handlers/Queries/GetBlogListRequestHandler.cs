using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.OrderDetials.Requests.Queries;
using Kashi_Seramic.Application.DTOs.OrderDetials;

namespace Kashi_Seramic.Application.Features.OrderDetials.Handlers.Queries
{
    public class GetOrderDetialsListRequestHandler : IRequestHandler<GetOrderDetialsListRequest, List<OrderDetialsDto>>
    {
        private readonly IOrderDetailsRepository _rep_OrderDetials;
        private readonly IMapper _mapper;

        public GetOrderDetialsListRequestHandler(IOrderDetailsRepository rep_OrderDetials, IMapper mapper)
        {
            _rep_OrderDetials = rep_OrderDetials;
            _mapper = mapper;
        }

        public async Task<List<OrderDetialsDto>> Handle(GetOrderDetialsListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_OrderDetials.GetOrderDetialssWithDetails();
            return _mapper.Map<List<OrderDetialsDto>>(leaveTypes);
        }
    }
}
