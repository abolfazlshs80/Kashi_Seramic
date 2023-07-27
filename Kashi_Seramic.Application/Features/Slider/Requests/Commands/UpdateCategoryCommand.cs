
using Kashi_Seramic.Application.DTOs.Slider;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateSliderCommand : IRequest<Unit>
    {
        public UpdateSliderDto SliderDto { get; set; }
        public int Id { get; set; }

    }
}
