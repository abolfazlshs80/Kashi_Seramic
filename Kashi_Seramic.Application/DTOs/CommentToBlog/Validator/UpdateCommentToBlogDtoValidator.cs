using FluentValidation;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.CommentToBlog.Validator
{
    public class UpdateCommentToBlogDtoValidator : AbstractValidator<UpdateCommentToBlogDto>
    {
        private readonly ICommentToBlogRepository _rep;

        public UpdateCommentToBlogDtoValidator(ICommentToBlogRepository rep)
        {
            _rep = rep;
            //Include(new ICommentToBlogDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
