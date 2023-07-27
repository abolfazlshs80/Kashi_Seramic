using FluentValidation;
using Kashi_Seramic.Application.DTOs.TagToBlog;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.TagToBlog.Validator
{
    public class ITagToBlogDtoValidator : AbstractValidator<ITagToBlogDto>
    {
        private ITagToBlogRepository _rep_blog;
        public ITagToBlogDtoValidator(ITagToBlogRepository rep_blog)
        {
            _rep_blog = rep_blog;




        }
    }
}
