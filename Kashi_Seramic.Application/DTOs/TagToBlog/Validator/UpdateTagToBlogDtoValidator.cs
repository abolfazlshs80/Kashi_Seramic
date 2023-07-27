using FluentValidation;
using Kashi_Seramic.Application.DTOs.TagToBlog;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Blog.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TagToBlog.Validator
{
    public class UpdateTagToBlogDtoValidator : AbstractValidator<UpdateTagToBlogDto>
    {
        private readonly ITagToBlogRepository _rep;

        public UpdateTagToBlogDtoValidator(ITagToBlogRepository rep)
        {
            _rep = rep;
            //Include(new ITagToBlogDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
