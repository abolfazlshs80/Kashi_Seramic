using FluentValidation;
using Kashi_Seramic.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.DTOs.Blog.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Inventory.Validator
{
    public class UpdateInventoryDtoValidator : AbstractValidator<UpdateInventoryDto>
    {
        private readonly IInventoryRepository _rep;

        public UpdateInventoryDtoValidator(IInventoryRepository rep)
        {
            _rep = rep;
            //Include(new IInventoryDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
