
using MediatR;
using Pr_Signal_ir.Application.DTOs.CommentToBlog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetCommentToBlogListRequest : IRequest<List<CommentToBlogDto>>
    {
    }
}
