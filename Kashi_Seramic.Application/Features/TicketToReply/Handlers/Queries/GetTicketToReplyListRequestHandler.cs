﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.DTOs.Blog;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.TicketToReply.Requests.Queries;
using Kashi_Seramic.Application.DTOs.TicketToReply;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetTicketToReplyListRequestHandler : IRequestHandler<GetTicketToReplyListRequest, List<TicketToReplyDto>>
    {
        private readonly ITicketToReplyRepository _rep_cate;
        private readonly IMapper _mapper;

        public GetTicketToReplyListRequestHandler(ITicketToReplyRepository rep_cate, IMapper mapper)
        {
            _rep_cate = rep_cate;
            _mapper = mapper;
        }

        public async Task<List<TicketToReplyDto>> Handle(GetTicketToReplyListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_cate.GetAll();
            return _mapper.Map<List<TicketToReplyDto>>(leaveTypes);
        }
    }
}
