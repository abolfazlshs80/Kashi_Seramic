using FluentValidation;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Blog.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TagToProduct.Validator
{
    public class UpdateTagToProductDtoValidator : AbstractValidator<UpdateTagToProductDto>
    {
        private readonly ITagToProductRepository _rep;

        public UpdateTagToProductDtoValidator(ITagToProductRepository rep)
        {
            _rep = rep;
            //Include(new ITagToProductDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
