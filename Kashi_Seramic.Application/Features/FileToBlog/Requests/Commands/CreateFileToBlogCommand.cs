
using Kashi_Seramic.Application.Responses;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;

using Pr_Signal_ir.Application.DTOs.FileToBlog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.FileToBlog.Requests.Commands
{
    public class CreateFileToBlogCommand : IRequest<BaseCommandResponse>
    {
        public CreateFileToBlogDto CreateFileImageDto { get; set; }

    }
}
