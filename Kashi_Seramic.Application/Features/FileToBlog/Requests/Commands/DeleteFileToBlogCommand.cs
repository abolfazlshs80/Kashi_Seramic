using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.FileToBlog.Requests.Commands
{
    public class DeleteFileToBlogCommand : IRequest
    {
        public int Id { get; set; }
    }
}
