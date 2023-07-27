
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using Pr_Signal_ir.Application.DTOs.Category;

using Pr_Signal_ir.Application.DTOs.FileToBlog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.FileToBlog.Requests.Queries
{
    public class GetFileToBlogListRequest : IRequest<List<FileToBlogDto>>
    {
    }
}
