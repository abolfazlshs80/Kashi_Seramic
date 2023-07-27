using FluentValidation;
using Kashi_Seramic.Application.DTOs.Tag;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Blog.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Tag.Validator
{
    public class UpdateTagDtoValidator : AbstractValidator<UpdateTagDto>
    {
        private readonly ITagRepository _rep;

        public UpdateTagDtoValidator(ITagRepository rep)
        {
            _rep = rep;
            //Include(new ITagDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
