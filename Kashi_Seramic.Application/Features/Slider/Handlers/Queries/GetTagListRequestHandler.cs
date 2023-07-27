using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.DTOs.Blog;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.DTOs.Slider;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetSliderListRequestHandler : IRequestHandler<GetSliderListRequest, List<SliderDto>>
    {
        private readonly ISliderRepository _rep_cate;
        private readonly IMapper _mapper;

        public GetSliderListRequestHandler(ISliderRepository rep_cate, IMapper mapper)
        {
            _rep_cate = rep_cate;
            _mapper = mapper;
        }

        public async Task<List<SliderDto>> Handle(GetSliderListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_cate.GetSliderWithDetails();
            return _mapper.Map<List<SliderDto>>(leaveTypes);
        }
    }
}
