using FluentValidation;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.Category.Validator
{
    public class ICategoryDtoValidator: AbstractValidator<ICategoryDto>
    {
        private ICategoryRepository _rep_blog;
        public ICategoryDtoValidator(ICategoryRepository rep_blog)
        {
            _rep_blog = rep_blog;
            RuleFor(p => p.Name)
              .Empty().WithMessage("{PropertyName} must not emty");
  


        }
    }
}
