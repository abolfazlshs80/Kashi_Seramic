using FluentValidation;
using Kashi_Seramic.Application.DTOs.Ticket;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Ticket.Validator
{
    public class ITicketDtoValidator : AbstractValidator<ITicketDto>
    {
        private ITicketRepository _rep_blog;
        public ITicketDtoValidator(ITicketRepository rep_blog)
        {
            _rep_blog = rep_blog;




        }
    }
}
