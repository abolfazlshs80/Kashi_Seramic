using FluentValidation;
using Kashi_Seramic.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Blog.Validator;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.FaqUser.Validator
{
    public class UpdateFaqUserDtoValidator : AbstractValidator<UpdateFaqUserDto>
    {
        private readonly IFaqUserRepository _rep;

        public UpdateFaqUserDtoValidator(IFaqUserRepository rep)
        {
            _rep = rep;
            //Include(new IFaqUserDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
