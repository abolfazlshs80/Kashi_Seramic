
using Kashi_Seramic.Application.DTOs.FileManager;
using Kashi_Seramic.Application.Responses;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.FileManager.Requests.Commands
{
    public class CreateFileManagerCommand : IRequest<BaseCommandResponse>
    {
        public CreateFileManagerDto CreateFileImageDto { get; set; }

    }
}
