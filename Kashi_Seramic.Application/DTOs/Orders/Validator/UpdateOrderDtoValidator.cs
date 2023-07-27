using FluentValidation;
using Kashi_Seramic.Application.DTOs.Order;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Order.Validator
{
    public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrdersDto>
    {
        private readonly IOrdersRepository _rep;

        public UpdateOrderDtoValidator(IOrdersRepository rep)
        {
            _rep = rep;
            //Include(new IOrderDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
