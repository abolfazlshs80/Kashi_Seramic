using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.Order.Requests.Queries;
using Kashi_Seramic.Application.DTOs.Order;

namespace Kashi_Seramic.Application.Features.Order.Handlers.Queries
{
    public class GetOrderListRequestHandler : IRequestHandler<GetOrderListRequest, List<OrdersDto>>
    {
        private readonly IOrdersRepository _rep_Order;
        private readonly IMapper _mapper;

        public GetOrderListRequestHandler(IOrdersRepository rep_Order, IMapper mapper)
        {
            _rep_Order = rep_Order;
            _mapper = mapper;
        }

        public async Task<List<OrdersDto>> Handle(GetOrderListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_Order.GetOrdersWithDetails();
            return _mapper.Map<List<OrdersDto>>(leaveTypes);
        }
    }
}
