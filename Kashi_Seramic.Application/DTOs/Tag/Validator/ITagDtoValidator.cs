using FluentValidation;
using Kashi_Seramic.Application.DTOs.Tag;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Tag.Validator
{
    public class ITagDtoValidator : AbstractValidator<ITagDto>
    {
        private ITagRepository _rep_blog;
        public ITagDtoValidator(ITagRepository rep_blog)
        {
            _rep_blog = rep_blog;




        }
    }
}
