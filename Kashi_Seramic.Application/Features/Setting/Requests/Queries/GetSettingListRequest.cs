
using Kashi_Seramic.Application.DTOs.SiteSetting;

using MediatR;
using Pr_Signal_ir.Application.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetSiteSettingListRequest : IRequest<List<SiteSettingDto>>
    {
    }
}
