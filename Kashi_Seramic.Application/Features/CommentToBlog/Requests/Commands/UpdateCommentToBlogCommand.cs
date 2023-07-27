
using MediatR;
using Pr_Signal_ir.Application.DTOs.CommentToBlog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class UpdateCommentToBlogCommand : IRequest<Unit>
    {
        public UpdateCommentToBlogDto CommentToBlogDto { get; set; }
        public int Id { get; set; }

    }
}
