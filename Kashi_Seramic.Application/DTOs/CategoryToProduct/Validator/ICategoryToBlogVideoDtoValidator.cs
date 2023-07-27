using FluentValidation;
using Kashi_Seramic.Application.DTOs.CategoryToProduct;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.CategoryToProduct.Validator
{
    public class ICategoryToProductDtoValidator : AbstractValidator<CategoryToProductDto>
    {
        private ICategoryToProductRepository _rep_CategoryToProduct;
        public ICategoryToProductDtoValidator(ICategoryToProductRepository rep_CategoryToProduct)
        {
            _rep_CategoryToProduct = rep_CategoryToProduct;
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
