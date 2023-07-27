using FluentValidation;
using Kashi_Seramic.Application.DTOs.FileManager;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.FileManager.Validator
{
    public class IFileManagersDtoValidator : AbstractValidator<IFileManagerDto>
    {
        private IFileManagerRepository _rep_blog;
        public IFileManagersDtoValidator(IFileManagerRepository rep_blog)
        {
            _rep_blog = rep_blog;
            RuleFor(p => p.Title)
              .Empty().WithMessage("{PropertyName} must not emty");
            RuleFor(p => p.Path)
             .Empty().WithMessage("{PropertyName} must not emty");
            RuleFor(p => p.Type)
             .Empty().WithMessage("{PropertyName} must not emty");


        }
    }
}
