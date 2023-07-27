
using Kashi_Seramic.Application.Responses;
using MediatR;
using Pr_Signal_ir.Application.DTOs.CommentToBlog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateCommentToBlogCommand : IRequest<BaseCommandResponse>
    {
        public CreateCommentToBlogDto CreateCommentToBlogDto { get; set; }

    }
}
