using FluentValidation;
using Kashi_Seramic.Application.DTOs.TicketGroup;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Blog.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TicketGroup.Validator
{
    public class UpdateTicketGroupDtoValidator : AbstractValidator<UpdateTicketGroupDto>
    {
        private readonly ITicketGroupRepository _rep;

        public UpdateTicketGroupDtoValidator(ITicketGroupRepository rep)
        {
            _rep = rep;
            //Include(new ITicketGroupDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
