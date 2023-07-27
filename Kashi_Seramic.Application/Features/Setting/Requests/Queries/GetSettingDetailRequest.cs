
using Kashi_Seramic.Application.DTOs.SiteSetting;

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetSiteSettingDetailRequest : IRequest<SiteSettingDto>
    {
        public int Id { get; set; }
    }
}
