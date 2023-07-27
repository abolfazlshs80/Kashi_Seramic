using FluentValidation;
using Kashi_Seramic.Application.DTOs.TicketGroup;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TicketGroup.Validator
{
    public class ITicketGroupDtoValidator : AbstractValidator<ITicketGroupDto>
    {
        private ITicketGroupRepository _rep_blog;
        public ITicketGroupDtoValidator(ITicketGroupRepository rep_blog)
        {
            _rep_blog = rep_blog;




        }
    }
}
