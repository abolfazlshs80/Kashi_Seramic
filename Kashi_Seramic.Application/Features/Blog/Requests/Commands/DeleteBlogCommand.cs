using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.Blog.Requests.Commands
{
    public class DeleteBlogCommand : IRequest
    {
        public int Id { get; set; }
    }
}
