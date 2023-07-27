using FluentValidation;
using Kashi_Seramic.Application.DTOs.TicketToReply;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Blog.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TicketToReply.Validator
{
    public class UpdateTicketToReplyDtoValidator : AbstractValidator<UpdateTicketToReplyDto>
    {
        private readonly ITicketToReplyRepository _rep;

        public UpdateTicketToReplyDtoValidator(ITicketToReplyRepository rep)
        {
            _rep = rep;
            //Include(new ITicketToReplyDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
