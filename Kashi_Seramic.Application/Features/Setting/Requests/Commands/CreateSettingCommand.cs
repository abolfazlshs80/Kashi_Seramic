
using Kashi_Seramic.Application.DTOs.SiteSetting;
using Kashi_Seramic.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateSiteSettingCommand : IRequest<BaseCommandResponse>
    {
        public CreateSiteSettingDto CreateSiteSettingDto { get; set; }

    }
}
