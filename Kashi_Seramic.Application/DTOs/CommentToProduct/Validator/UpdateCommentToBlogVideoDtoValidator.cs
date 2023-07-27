using FluentValidation;
using Kashi_Seramic.Application.DTOs.CommentToProduct;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.CommentToProduct.Validator
{
    public class UpdateCommentToProductDtoValidator : AbstractValidator<UpdateCommentToProductDto>
    {
        private readonly ICommentToProductRepository _rep;

        public UpdateCommentToProductDtoValidator(ICommentToProductRepository rep)
        {
            _rep = rep;
            //Include(new ICommentToProductDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
