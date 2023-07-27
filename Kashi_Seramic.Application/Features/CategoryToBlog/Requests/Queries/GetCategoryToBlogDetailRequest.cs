
using MediatR;
using Pr_Signal_ir.Application.DTOs.Blog;
using Pr_Signal_ir.Application.DTOs.CategoryToBlog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kashi_Seramic.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetCategoryToBlogDetailRequest : IRequest<CategoryToBlogDto>
    {
        public int Id { get; set; }
    }
}
