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
    public class UpdateMenuDtoValidator : AbstractValidator<UpdateMenuDto>
    {
        private readonly IMenuRepository _rep;

        public UpdateMenuDtoValidator(IMenuRepository rep)
        {
            _rep = rep;
            //Include(new IMenuDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
