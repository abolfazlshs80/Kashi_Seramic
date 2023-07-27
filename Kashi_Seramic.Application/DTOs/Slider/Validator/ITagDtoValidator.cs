using FluentValidation;
using Kashi_Seramic.Application.DTOs.Slider;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Slider.Validator
{
    public class ISliderDtoValidator : AbstractValidator<ISliderDto>
    {
        private ISliderRepository _rep_blog;
        public ISliderDtoValidator(ISliderRepository rep_blog)
        {
            _rep_blog = rep_blog;




        }
    }
}
