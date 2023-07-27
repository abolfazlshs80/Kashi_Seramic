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

public class IOrderSatusDtoValidator : AbstractValidator<IOrderSatusDto>
{
    private IOrderSatusRepository _rep_OrderSatus;
    public IOrderSatusDtoValidator(IOrderSatusRepository rep_OrderSatus)
    {
        _rep_OrderSatus = rep_OrderSatus;



    }
}
