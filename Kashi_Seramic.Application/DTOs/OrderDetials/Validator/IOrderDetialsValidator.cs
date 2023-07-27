using FluentValidation;
using Kashi_Seramic.Application.DTOs.OrderDetials;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.OrderDetials.Validator
{
    public class IOrderDetialsDtoValidator : AbstractValidator<IOrderDetialsDto>
    {
        private IOrderDetailsRepository _rep_OrderDetials;
        public IOrderDetialsDtoValidator(IOrderDetailsRepository rep_OrderDetials)
        {
            _rep_OrderDetials = rep_OrderDetials;



        }
    }
}
