using FluentValidation;
using Kashi_Seramic.Application.Contracts.Persistence;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.Inventory.Validator
{
    public class IInventoryDtoValidator : AbstractValidator<IInventoryDto>
    {
        private IInventoryRepository _rep_blog;
        public IInventoryDtoValidator(IInventoryRepository rep_blog)
        {
            _rep_blog = rep_blog;
         


        }
    }
}
