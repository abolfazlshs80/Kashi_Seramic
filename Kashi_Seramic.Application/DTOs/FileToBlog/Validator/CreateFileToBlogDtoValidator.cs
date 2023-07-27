using FluentValidation;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.FileToBlog.Validator
{
    public class CreateFileToBlogDtoValidator : AbstractValidator<CreateFileToBlogDto>
    {
        private readonly IFileToBlogRepository _rep;

        public CreateFileToBlogDtoValidator(IFileToBlogRepository rep)
        {
            _rep = rep;

            //RuleFor(p => p.Id)
            //    .GreaterThan(0)
            //    .MustAsync(async (id, token) =>
            //    {
            //        var leaveTypeExists = await _rep.Exists(id);
            //        return leaveTypeExists;
            //    })
            //    .WithMessage("{PropertyName} does not exist.");
        }
    }
}
