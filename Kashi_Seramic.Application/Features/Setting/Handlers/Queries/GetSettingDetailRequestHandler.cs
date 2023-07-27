using AutoMapper;


using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;

using Kashi_Seramic.Application.DTOs.SiteSetting;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetSiteSettingDetailRequestHandler : IRequestHandler<GetSiteSettingDetailRequest, SiteSettingDto>
    {
        private readonly ISiteSettingRepository _Repository;
        private readonly IMapper _mapper;

        public GetSiteSettingDetailRequestHandler(ISiteSettingRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<SiteSettingDto> Handle(GetSiteSettingDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _Repository.Get(request.Id);
            return _mapper.Map<SiteSettingDto>(leaveType);
        }
    }
}
