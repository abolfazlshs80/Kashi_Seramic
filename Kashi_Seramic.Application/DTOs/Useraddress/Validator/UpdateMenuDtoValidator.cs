using FluentValidation;
using Kashi_Seramic.Application.DTOs.UserAddress;
using Pr_Signal_ir.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashi_Seramic.Application.DTOs.UserAddress.Validator
{
    public class UpdateUserAddressDtoValidator : AbstractValidator<UpdateUserAddressDto>
    {
        private readonly IUserAddressRepository _rep;

        public UpdateUserAddressDtoValidator(IUserAddressRepository rep)
        {
            _rep = rep;
            //Include(new IUserAddressDtoValidator(_rep));

            //RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
