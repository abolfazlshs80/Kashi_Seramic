using FluentValidation;
using Kashi_Seramic.Application.DTOs.Product;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.Blog.Validator
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        private readonly IProductRepository _rep;

        public UpdateProductDtoValidator(IProductRepository rep)
        {
            _rep = rep;
            //Include(new IBlogDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
