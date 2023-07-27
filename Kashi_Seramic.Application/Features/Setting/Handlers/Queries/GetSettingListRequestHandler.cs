using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries;
using Pr_Signal_ir.Application.Contracts.Persistence;

using Kashi_Seramic.Application.DTOs.SiteSetting;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Handlers.Queries
{
    public class GetSiteSettingListRequestHandler : IRequestHandler<GetSiteSettingListRequest, List<SiteSettingDto>>
    {
        private readonly ISiteSettingRepository _rep_SiteSetting;
        private readonly IMapper _mapper;

        public GetSiteSettingListRequestHandler(ISiteSettingRepository rep_SiteSetting, IMapper mapper)
        {
            _rep_SiteSetting = rep_SiteSetting;
            _mapper = mapper;
        }

        public async Task<List<SiteSettingDto>> Handle(GetSiteSettingListRequest request, CancellationToken cancellationToken)
        {
            var leaveTypes = await _rep_SiteSetting.GetAll();
            return _mapper.Map<List<SiteSettingDto>>(leaveTypes);
        }
    }
}
