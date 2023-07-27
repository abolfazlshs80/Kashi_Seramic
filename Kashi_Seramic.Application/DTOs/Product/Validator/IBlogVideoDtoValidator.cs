using FluentValidation;
using Kashi_Seramic.Application.DTOs.Product;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.Product.Validator
{
    public class IProductDtoValidator : AbstractValidator<IProductDto>
    {
        private IProductRepository _rep_Product;
        public IProductDtoValidator(IProductRepository rep_Product)
        {
            _rep_Product = rep_Product;
            RuleFor(p => p.Title)
              .Empty().WithMessage("{PropertyName} must not emty");
            RuleFor(p => p.TitleInBrowser)
             .Empty().WithMessage("{PropertyName} must not emty");
      
            RuleFor(p => p.Text)
             .Empty().WithMessage("{PropertyName} must not emty");


        }
    }
}
