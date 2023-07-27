using FluentValidation;
using Kashi_Seramic.Application.DTOs.FilterToProduct;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kashi_Seramic.Application.Contracts.Persistence;
using Kashi_Seramic.Application.DTOs.FileToProduct;

namespace Kashi_Seramic.Application.DTOs.FilterToProduct.Validator
{
    public class IFilterToProductDtoValidator : AbstractValidator<FilterToProductDto>
    {
        private IFilterToProductRepository _rep_FilterToProduct;
        public IFilterToProductDtoValidator(IFilterToProductRepository rep_FilterToProduct)
        {
            _rep_FilterToProduct = rep_FilterToProduct;




        }
    }
}
