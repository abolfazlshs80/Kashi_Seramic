﻿using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Kashi_Seramic.Application.DTOs.FaqUser;
using Kashi_Seramic.Application.DTOs.Inventory;
using Kashi_Seramic.Application.Contracts.Persistence;
using Kashi_Seramic.Application.DTOs.OrderSatus;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetOrderSatusDetailRequestHandler : IRequestHandler<GetOrderSatusDetailRequest, OrderSatusDto>
    {
        private readonly IOrderSatusRepository _Repository;
        private readonly IMapper _mapper;

        public GetOrderSatusDetailRequestHandler(IOrderSatusRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<OrderSatusDto> Handle(GetOrderSatusDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.GetOrderSatusWithDetails(request.Id);
            return _mapper.Map<OrderSatusDto>(leaveType);
        }
    }
}
