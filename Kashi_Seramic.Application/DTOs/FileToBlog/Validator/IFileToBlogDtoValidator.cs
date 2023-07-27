using FluentValidation;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr_Signal_ir.Application.DTOs.FileToBlog.Validator
{
    public class IFileToBlogDtoValidator : AbstractValidator<FileToBlogDto>
    {
        private IFileToBlogRepository _rep_FileToBlog;
        public IFileToBlogDtoValidator(IFileToBlogRepository rep_FileToBlog)
        {
            _rep_FileToBlog = rep_FileToBlog;
      
        


        }
    }
}
