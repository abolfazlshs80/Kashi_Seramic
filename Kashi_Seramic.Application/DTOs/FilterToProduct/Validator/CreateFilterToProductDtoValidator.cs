using FluentValidation;
using Kashi_Seramic.Application.DTOs.FilterToProduct;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kashi_Seramic.Application.DTOs.FileToProduct;

namespace Kashi_Seramic.Application.DTOs.FilterToProduct.Validator
{
    public class CreateFilterToProductDtoValidator : AbstractValidator<CreateFilterToProductDto>
    {
        private readonly IFilterToProductRepository _rep;

        public CreateFilterToProductDtoValidator(IFilterToProductRepository rep)
        {
            _rep = rep;

            //RuleFor(p => p.Id)
            //    .GreaterThan(0)
            //    .MustAsync(async (id, token) =>
            //    {
            //        var leaveTypeExists = await _rep.Exists(id);
            //        return leaveTypeExists;
            //    })
            //    .WithMessage("{PropertyName} does not exist.");
        }
    }
}
