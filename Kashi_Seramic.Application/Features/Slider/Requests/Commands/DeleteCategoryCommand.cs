﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class DeleteSliderCommand : IRequest
    {
        public int Id { get; set; }
    }
}
