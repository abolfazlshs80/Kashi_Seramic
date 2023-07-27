using FluentValidation;
using Kashi_Seramic.Application.Contracts.Persistence;
using Kashi_Seramic.Application.DTOs.OrderSatus;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.OrderSatus.Validator;

public class UpdateOrderSatusDtoValidator : AbstractValidator<UpdateOrderSatusDto>
{
    private readonly IOrderSatusRepository _rep;

    public UpdateOrderSatusDtoValidator(IOrderSatusRepository rep)
    {
        _rep = rep;
        //Include(new IOrderSatusDtoValidator(_rep));

        //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
    }
}
