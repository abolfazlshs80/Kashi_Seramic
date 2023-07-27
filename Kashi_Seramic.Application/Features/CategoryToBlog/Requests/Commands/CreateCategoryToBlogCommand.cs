
using Kashi_Seramic.Application.Responses;
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using Pr_Signal_ir.Application.DTOs.CategoryToBlog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateCategoryToBlogCommand : IRequest<BaseCommandResponse>
    {
        public CreateCategoryToBlogDto CreateCategoryToBlogDto { get; set; }

    }
}
