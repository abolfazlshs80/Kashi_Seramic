using FluentValidation;
using Kashi_Seramic.Application.DTOs.SiteSetting;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.SiteSetting.Validator
{
    public class ISettingDtoValidator : AbstractValidator<ISettingDto>
    {
        private ISiteSettingRepository _rep_Setting;
        public ISettingDtoValidator(ISiteSettingRepository rep_Setting)
        {
            _rep_Setting = rep_Setting;
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
