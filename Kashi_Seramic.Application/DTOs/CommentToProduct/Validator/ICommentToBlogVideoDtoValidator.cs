using FluentValidation;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.CommentToProduct.Validator
{
    public class ICommentToProductDtoValidator : AbstractValidator<ICommentToProductDto>
    {
        private ICommentToProductRepository _rep_CommentToProduct;
        public ICommentToProductDtoValidator(ICommentToProductRepository rep_CommentToProduct)
        {
            _rep_CommentToProduct = rep_CommentToProduct;
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
