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
    public class IBlogDtoValidator : AbstractValidator<IBlogDto>
    {
        private IBlogRepository _rep_blog;
        public IBlogDtoValidator(IBlogRepository rep_blog)
        {
            _rep_blog = rep_blog;

             
            RuleFor(p => p.Tag)
             .Empty().WithMessage("{PropertyName} must not emty");
            RuleFor(p => p.Text)
             .Empty().WithMessage("{PropertyName} must not emty");


        }
    }
}
