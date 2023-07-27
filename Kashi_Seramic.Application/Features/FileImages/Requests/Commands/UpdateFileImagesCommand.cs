
using Kashi_Seramic.Application.DTOs.FileManager;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.FileManager.Requests.Commands
{
    public class UpdateFileManagerCommand : IRequest<Unit>
    {
        public UpdateFileManagerDto FileImageDto { get; set; }
        public int Id { get; set; }

    }
}
