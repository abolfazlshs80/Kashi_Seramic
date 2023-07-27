
using Kashi_Seramic.Application.DTOs.FileManager;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using Pr_Signal_ir.Application.DTOs.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.FileManager.Requests.Queries
{
    public class GetFileManagerDetailRequest : IRequest<FileManagerDto>
    {
        public int Id { get; set; }
    }
}
