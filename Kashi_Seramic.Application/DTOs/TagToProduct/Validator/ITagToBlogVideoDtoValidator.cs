using FluentValidation;
using Kashi_Seramic.Application.DTOs.TagToProduct;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TagToProduct.Validator
{
    public class ITagToProductDtoValidator : AbstractValidator<ITagToProductDto>
    {
        private ITagToProductRepository _rep_blog;
        public ITagToProductDtoValidator(ITagToProductRepository rep_blog)
        {
            _rep_blog = rep_blog;




        }
    }
}
