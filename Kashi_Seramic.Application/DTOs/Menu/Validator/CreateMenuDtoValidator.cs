using FluentValidation;
using Kashi_Seramic.Application.DTOs.Menu;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Menu.Validator
{
    public class CreateMenuDtoValidator : AbstractValidator<CreateMenuDto>
    {
        private readonly IMenuRepository _rep;

        public CreateMenuDtoValidator(IMenuRepository rep)
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
