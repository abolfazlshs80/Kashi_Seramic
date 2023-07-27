using FluentValidation;
using Kashi_Seramic.Application.DTOs.Slider;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Blog.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Slider.Validator
{
    public class UpdateSliderDtoValidator : AbstractValidator<UpdateSliderDto>
    {
        private readonly ISliderRepository _rep;

        public UpdateSliderDtoValidator(ISliderRepository rep)
        {
            _rep = rep;
            //Include(new ISliderDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
