using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.FileManager.Requests.Commands
{
    public class DeleteFileManagerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
