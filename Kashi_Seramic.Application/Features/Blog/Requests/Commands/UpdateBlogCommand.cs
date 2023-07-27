
using Kashi_Seramic.Application.DTOs.Blog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.Blog.Requests.Commands
{
    public class UpdateBlogCommand : IRequest<Unit>
    {
        public UpdateBlogDto blogDto { get; set; }
        public int Id { get; set; }

    }
}
