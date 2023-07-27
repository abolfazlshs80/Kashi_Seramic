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
    public class UpdateOrderDetialsDtoValidator : AbstractValidator<UpdateOrderDetialsDto>
    {
        private readonly IOrderDetailsRepository _rep;

        public UpdateOrderDetialsDtoValidator(IOrderDetailsRepository rep)
        {
            _rep = rep;
            //Include(new IOrderDetialsDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
