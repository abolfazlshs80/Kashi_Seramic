using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.Features.Order.Requests.Queries;
using Kashi_Seramic.Application.DTOs.Order;

namespace Kashi_Seramic.Application.Features.Order.Handlers.Queries
{
    public class GetUserOrderDetailRequestHandler : IRequestHandler<GetUserOrderDetailRequest, OrdersDto>
    {
        private readonly IOrdersRepository _Repository;
        private readonly IMapper _mapper;

        public GetUserOrderDetailRequestHandler(IOrdersRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<OrdersDto> Handle(GetUserOrderDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetOrdersUserWithDetails(request.Id);
            return _mapper.Map<OrdersDto>(leaveType);
        }


    }
}
