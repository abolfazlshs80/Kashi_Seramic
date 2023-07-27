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
    public class IUserAddressDtoValidator : AbstractValidator<IUserAddressDto>
    {
        private IUserAddressRepository _rep_UserAddress;
        public IUserAddressDtoValidator(IUserAddressRepository rep_UserAddress)
        {
            _rep_UserAddress = rep_UserAddress;
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
