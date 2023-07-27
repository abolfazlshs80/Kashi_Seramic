using FluentValidation;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.CommentToBlog.Validator
{
    public class ICommentToBlogDtoValidator : AbstractValidator<ICommentToBlogDto>
    {
        private ICommentToBlogRepository _rep_CommentToBlog;
        public ICommentToBlogDtoValidator(ICommentToBlogRepository rep_CommentToBlog)
        {
            _rep_CommentToBlog = rep_CommentToBlog;
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
