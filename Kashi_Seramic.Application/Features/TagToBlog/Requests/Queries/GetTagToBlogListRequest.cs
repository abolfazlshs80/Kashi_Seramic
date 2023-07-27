
using Kashi_Seramic.Application.DTOs.TagToBlog;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetTagToBlogListRequest : IRequest<List<TagToBlogDto>>
    {
    }
}
