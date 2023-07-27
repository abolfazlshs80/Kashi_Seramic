
using MediatR;
using Pr_Signal_ir.Application.DTOs.Setting;

using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateSiteSettingCommand : IRequest<Unit>
    {
        public UpdateSiteSettingDto SiteSettingDto { get; set; }
        public int Id { get; set; }

    }
}
