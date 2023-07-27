
using Kashi_Seramic.Application.DTOs.Blog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.Blog.Requests.Queries
{
    public class GetBlogListRequest : IRequest<List<BlogDto>>
    {
    }
}
