using FluentValidation;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.CategoryToBlog.Validator
{
    public class ICategoryToBlogDtoValidator : AbstractValidator<CategoryToBlogDto>
    {
        private ICategoryToBlogRepository _rep_CategoryToBlog;
        public ICategoryToBlogDtoValidator(ICategoryToBlogRepository rep_CategoryToBlog)
        {
            _rep_CategoryToBlog = rep_CategoryToBlog;
            //RuleFor(p => p.ShortName)
            //  .Empty().WithMessage("{PropertyName} must not emty");
            //RuleFor(p => p.LognName)
            // .Empty().WithMessage("{PropertyName} must not emty");
            //RuleFor(p => p.Tag)
            // .Empty().WithMessage("{PropertyName} must not emty");
            //RuleFor(p => p.Text)
            // .Empty().WithMessage("{PropertyName} must not emty");


        }
    }
}
