using FluentValidation;
using Kashi_Seramic.Application.Contracts.Persistence;
using Kashi_Seramic.Application.DTOs.Blog;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Blog.Validator
{
    public class UpdateBlogDtoValidator : AbstractValidator<UpdateBlogDto>
    {
        private readonly IBlogRepository _rep;

        public UpdateBlogDtoValidator(IBlogRepository rep)
        {
            _rep = rep;
            //Include(new IBlogDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
