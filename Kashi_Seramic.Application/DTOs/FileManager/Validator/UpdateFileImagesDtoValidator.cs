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
    public class UpdateFileManagersDtoValidator : AbstractValidator<UpdateFileManagerDto>
    {
        private readonly IFileManagerRepository _rep;

        public UpdateFileManagersDtoValidator(IFileManagerRepository rep)
        {
            _rep = rep;
            Include(new IFileManagersDtoValidator(_rep));

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
