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
    public class IOrderDtoValidator : AbstractValidator<IOrdersDto>
    {
        private IOrdersRepository _rep_Order;
        public IOrderDtoValidator(IOrdersRepository rep_Order)
        {
            _rep_Order = rep_Order;



        }
    }
}
