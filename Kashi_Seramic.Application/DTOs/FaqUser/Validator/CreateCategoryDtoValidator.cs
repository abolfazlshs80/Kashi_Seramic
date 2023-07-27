using FluentValidation;
using Kashi_Seramic.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.FaqUser.Validator
{
    public class CreateFaqUserDtoValidator : AbstractValidator<CreateFaqUserDto>
    {
        private readonly IFaqUserRepository _rep;

        public CreateFaqUserDtoValidator(IFaqUserRepository rep)
        {
            _rep = rep;

            //RuleFor(p => p.Id)
            //    .GreaterThan(0)
            //    .MustAsync(async (id, token) =>
            //    {
            //        var leaveTypeExists = await _rep.Exists(id);
            //        return leaveTypeExists;
            //    })
            //    .WithMessage("{PropertyName} does not exist.");
        }
    }
}
