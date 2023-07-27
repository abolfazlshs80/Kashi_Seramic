using FluentValidation;
using Kashi_Seramic.Application.DTOs.Ticket;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Blog.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Ticket.Validator
{
    public class UpdateTicketDtoValidator : AbstractValidator<UpdateTicketDto>
    {
        private readonly ITicketRepository _rep;

        public UpdateTicketDtoValidator(ITicketRepository rep)
        {
            _rep = rep;
            //Include(new ITicketDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
