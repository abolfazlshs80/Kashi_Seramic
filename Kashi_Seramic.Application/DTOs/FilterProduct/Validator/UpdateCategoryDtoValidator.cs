using FluentValidation;
using Kashi_Seramic.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Blog.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.FilterProduct.Validator
{
    public class UpdateFilterProductDtoValidator : AbstractValidator<UpdateFilterProductDto>
    {
        private readonly IFilterProductRepository _rep;

        public UpdateFilterProductDtoValidator(IFilterProductRepository rep)
        {
            _rep = rep;
            //Include(new IFilterProductDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
