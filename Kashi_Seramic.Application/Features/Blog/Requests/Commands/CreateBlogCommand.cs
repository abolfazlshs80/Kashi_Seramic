
using Kashi_Seramic.Application.DTOs.Blog;
using Kashi_Seramic.Application.Responses;
using MediatR;

using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.Blog.Requests.Commands
{
    public class CreateBlogCommand : IRequest<BaseCommandResponse>
    {
        public CreateBlogDto CreateBlogDto { get; set; }

    }
}
