using FluentValidation;
using Kashi_Seramic.Application.DTOs.TicketToReply;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TicketToReply.Validator
{
    public class ITicketToReplyDtoValidator : AbstractValidator<ITicketToReplyDto>
    {
        private ITicketToReplyRepository _rep_blog;
        public ITicketToReplyDtoValidator(ITicketToReplyRepository rep_blog)
        {
            _rep_blog = rep_blog;




        }
    }
}
