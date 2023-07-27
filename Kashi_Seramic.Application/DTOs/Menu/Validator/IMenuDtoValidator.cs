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
    public class IMenuDtoValidator : AbstractValidator<IMenuDto>
    {
        private IMenuRepository _rep_Menu;
        public IMenuDtoValidator(IMenuRepository rep_Menu)
        {
            _rep_Menu = rep_Menu;
            //RuleFor(p => p.ShortName)
            //  .Empty().WithMessage("{PropertyName} must not emty");
            //RuleFor(p => p.LognName)
            // .Empty().WithMessage("{PropertyName} must not emty");
            //RuleFor(p => p.Tag)
            // .Empty().WithMessage("{PropertyName} must not emty");
            //RuleFor(p => p.Text)
            // .Empty().WithMessage("{PropertyName} must not emty");


        }
    }
}
