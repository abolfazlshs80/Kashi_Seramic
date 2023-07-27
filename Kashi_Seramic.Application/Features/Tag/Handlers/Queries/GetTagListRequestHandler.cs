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
using Kashi_Seramic.Application.DTOs.Tag;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetTagListRequestHandler : IRequestHandler<GetTagListRequest, List<TagDto>>
    {
        private readonly ITagRepository _rep_cate;
        private readonly IMapper _mapper;

        public GetTagListRequestHandler(ITagRepository rep_cate, IMapper mapper)
        {
            _rep_cate = rep_cate;
            _mapper = mapper;
        }

        public async Task<List<TagDto>> Handle(GetTagListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_cate.GetTagWithDetails();
            return _mapper.Map<List<TagDto>>(leaveTypes);
        }
    }
}
