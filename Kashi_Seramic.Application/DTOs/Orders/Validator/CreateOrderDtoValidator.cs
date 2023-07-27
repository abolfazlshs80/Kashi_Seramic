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
    public class CreateOrderDtoValidator : AbstractValidator<CreateOrdersDto>
    {
        private readonly IOrdersRepository _rep;

        public CreateOrderDtoValidator(IOrdersRepository rep)
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
