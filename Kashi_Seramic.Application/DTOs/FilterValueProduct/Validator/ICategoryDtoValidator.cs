using FluentValidation;
using Kashi_Seramic.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.FilterValueProduct.Validator
{
    public class IFilterValueProductDtoValidator : AbstractValidator<IFilterValueProductDto>
    {
        private IFilterValueProductRepository _rep_blog;
        public IFilterValueProductDtoValidator(IFilterValueProductRepository rep_blog)
        {
            _rep_blog = rep_blog;




        }
    }
}
