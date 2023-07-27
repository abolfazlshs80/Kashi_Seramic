using FluentValidation;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.SiteSetting.Validator
{
    public class UpdateSiteSettingDtoValidator : AbstractValidator<UpdateSiteSettingDto>
    {
        private readonly ISiteSettingRepository _rep;

        public UpdateSiteSettingDtoValidator(ISiteSettingRepository rep)
        {
            _rep = rep;
            //Include(new ISettingDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
