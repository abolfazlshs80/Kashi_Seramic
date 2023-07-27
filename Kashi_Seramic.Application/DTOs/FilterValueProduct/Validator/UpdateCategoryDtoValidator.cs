using FluentValidation;
using Kashi_Seramic.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Blog.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.FilterValueProduct.Validator
{
    public class UpdateFilterValueProductDtoValidator : AbstractValidator<UpdateFilterValueProductDto>
    {
        private readonly IFilterValueProductRepository _rep;

        public UpdateFilterValueProductDtoValidator(IFilterValueProductRepository rep)
        {
            _rep = rep;
            //Include(new IFilterValueProductDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
