using FluentValidation;
using Kashi_Seramic.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.FaqUser.Validator
{
    public class IFaqUserDtoValidator : AbstractValidator<IFaqUserDto>
    {
        private IFaqUserRepository _rep_blog;
        public IFaqUserDtoValidator(IFaqUserRepository rep_blog)
        {
            _rep_blog = rep_blog;
   



        }
    }
}
