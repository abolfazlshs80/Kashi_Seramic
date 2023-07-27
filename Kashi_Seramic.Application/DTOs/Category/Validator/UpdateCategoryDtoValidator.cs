using FluentValidation;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Blog.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.Category.Validator
{
    public class UpdateCategoryDtoValidator: AbstractValidator<UpdateCategoryDto>
    {
        private readonly ICategoryRepository _rep;

        public UpdateCategoryDtoValidator(ICategoryRepository rep)
        {
            _rep = rep;
            //Include(new ICategoryDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
